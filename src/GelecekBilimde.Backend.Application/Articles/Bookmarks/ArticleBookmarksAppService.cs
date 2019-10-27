using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Users;
using Guid = System.Guid;

namespace GelecekBilimde.Backend.Articles.Bookmarks
{
    [Authorize]
    [UsedImplicitly]
    public class ArticleBookmarksAppService : BackendAppService, IArticleBookmarksAppService
    {
        private readonly IArticleBookmarkService _bookmarkService;
        private readonly ICurrentUser _currentUser;

        public ArticleBookmarksAppService(
            IArticleBookmarkService bookmarkService,
            ICurrentUser currentUser)
        {
            _bookmarkService = bookmarkService;
            _currentUser = currentUser;
        }

        public Task AddAsync(Guid id)
        {
            return _bookmarkService.AddBookmarkAsync(_currentUser.GetId(), id);
        }

        public async Task RemoveAsync(Guid id)
        {
            bool result = await _bookmarkService.RemoveBookmarkAsync(_currentUser.GetId(), id);
            if (result == false)
            {
                throw new UserFriendlyException("Article is not bookmarked.", "GelecekBilimde.ArticleBookmarks:10010");
            }
        }

        public Task<ICollection<Guid>> Get()
        {
            return _bookmarkService.GetBookmarks(_currentUser.GetId());
        }
    }
}