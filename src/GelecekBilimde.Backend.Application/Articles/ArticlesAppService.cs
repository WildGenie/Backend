using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;

namespace GelecekBilimde.Backend.Articles
{
    [UsedImplicitly]
    public class ArticlesAppService : BackendAppService, IArticlesAppService
    {
        private readonly IArticleStore _articleStore;

        public ArticlesAppService(IArticleStore articleStore)
        {
            _articleStore = articleStore;
        }
        public async Task<IEnumerable<ArticleDto>> Get()
        {
            var articles = await _articleStore.GetAllArticlesAsync();
            return articles.Select(MapArticleToDto);
        }

        public async Task<IEnumerable<ArticleDto>> GetByAuthorAsync(int authorId)
        {
            var articles = await _articleStore.GetArticlesByAuthorAsync(authorId);
            return articles.Select(MapArticleToDto);
        }

        public async Task<IEnumerable<ArticleDto>> GetByCategoryAsync(int categoryId)
        {
            var articles = await _articleStore.GetArticlesByCategoryAsync(categoryId);
            return articles.Select(MapArticleToDto);
        }

        public async Task<IEnumerable<ArticleDto>> GetByTagAsync(int tagId)
        {
            var articles = await _articleStore.GetArticlesByTagAsync(tagId);
            return articles.Select(MapArticleToDto);
        }

        public async Task<IEnumerable<ArticleDto>> SearchAsync(string searchTerm)
        {
            var articles = await _articleStore.GetArticlesBySearchAsync(searchTerm);
            return articles.Select(MapArticleToDto);
        }

        public async Task<IEnumerable<ArticleDto>> GetStickyAsync()
        {
            var articles = await _articleStore.GetStickyArticlesAsync();
            return articles.Select(MapArticleToDto);
        }

        public async Task<ArticleDto> Get(Guid id)
        {
            var article = await _articleStore.GetArticle(id);
            if (article == null)
            {
                throw new UserFriendlyException($"Article with ID \"{id}\" was not found.", "GelecekBilimde.Articles:10010");
            }

            return MapArticleToDto(article);
        }

        private ArticleDto MapArticleToDto(Article article)
        {
            return ObjectMapper.Map<Article, ArticleDto>(article);
        }
    }
}