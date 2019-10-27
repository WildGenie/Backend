using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Linq;
using Volo.Abp.Uow;

namespace GelecekBilimde.Backend.Articles.Bookmarks
{
    public class ArticleBookmarkService : IArticleBookmarkService
    {
        //todo needs caching

        private readonly IRepository<UserArticleBookmark> _bookmarksRepository;
        private readonly IUnitOfWorkManager _uowManager;
        private readonly IAsyncQueryableExecuter _asyncQueryExecutor;

        public ArticleBookmarkService(
            IRepository<UserArticleBookmark> bookmarksRepository,
            IUnitOfWorkManager uowManager,
            IAsyncQueryableExecuter asyncQueryExecutor)
        {
            _bookmarksRepository = bookmarksRepository;
            _uowManager = uowManager;
            _asyncQueryExecutor = asyncQueryExecutor;
        }

        public async Task AddBookmarkAsync(Guid userId, Guid articleId)
        {
            var query = _bookmarksRepository.Where(d => d.ArticleId == articleId && d.UserId == userId);
            var count = await _asyncQueryExecutor.CountAsync(query);

            if (count > 0)
            {
                return;
            }

            await _bookmarksRepository.InsertAsync(new UserArticleBookmark
            {
                UserId = userId,
                ArticleId = articleId
            });

            await _uowManager.Current.SaveChangesAsync();
        }

        public async Task<bool> RemoveBookmarkAsync(Guid userId, Guid articleId)
        {
            var query = _bookmarksRepository.Where(d => d.ArticleId == articleId && d.UserId == userId);
            var match = await _asyncQueryExecutor.FirstOrDefaultAsync(query);

            if (match == null)
            {
                return false;
            }

            await _bookmarksRepository.DeleteAsync(match);
            await _uowManager.Current.SaveChangesAsync();
            return true;
        }

        public async Task<ICollection<Guid>> GetBookmarks(Guid userId)
        {
            var query = _bookmarksRepository.Where(d => d.UserId == userId);
            var result = await _asyncQueryExecutor.ToListAsync(query);

            return result.Select(d => d.ArticleId).ToList();
        }
    }
}