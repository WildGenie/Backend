using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using WordPressPCL;
using WordPressPCL.Models;
using Guid = System.Guid;

namespace GelecekBilimde.Backend.Articles
{
    public class WordpressArticleStore : IArticleStore
    {
        // todo: needs caching

        private readonly WordPressClient _wordpressClient;

        public WordpressArticleStore(
            IOptions<WordpressConfiguration> wordpressOptions)
        {
            _wordpressClient = new WordPressClient(wordpressOptions.Value.JsonEndpoint);
        }

        public async Task<ICollection<Article>> GetAllArticlesAsync()
        {
            var articles =
                (await _wordpressClient.Posts.GetAll())
                .Select(MapWordpressArticle);

            return articles.ToList();
        }

        public async Task<ICollection<Article>> GetArticlesByAuthorAsync(int authorId)
        {
            var articles =
                (await _wordpressClient.Posts.GetPostsByAuthor(authorId))
                .Select(MapWordpressArticle);

            return articles.ToList();
        }

        public async Task<ICollection<Article>> GetArticlesByCategoryAsync(int categoryId)
        {
            var articles =
                (await _wordpressClient.Posts.GetPostsByCategory(categoryId))
                .Select(MapWordpressArticle);

            return articles.ToList();
        }

        public async Task<ICollection<Article>> GetArticlesByTagAsync(int tagId)
        {
            var articles =
                (await _wordpressClient.Posts.GetPostsByTag(tagId))
                .Select(MapWordpressArticle);

            return articles.ToList();
        }

        public async Task<ICollection<Article>> GetArticlesBySearchAsync(string searchTerm)
        {
            var articles =
                (await _wordpressClient.Posts.GetPostsBySearch(searchTerm))
                .Select(MapWordpressArticle);

            return articles.ToList();
        }

        public async Task<ICollection<Article>> GetStickyArticlesAsync()
        {
            var articles =
                (await _wordpressClient.Posts.GetStickyPosts())
                .Select(MapWordpressArticle);

            return articles.ToList();
        }

        public Article MapWordpressArticle(Post post)
        {
            return new Article
            {
                AllowComments = post.CommentStatus == OpenStatus.Open,
                AuthorId = post.Author,
                Categories = post.Categories,
                Content = post.Content.Rendered,
                Link = post.Link,
                ModifiedDate = post.ModifiedGmt,
                PublishDate = post.DateGmt,
                Sticky = post.Sticky,
                Tags = post.Tags,
                Title = post.Title.Rendered,
            };
        }

        public async Task<Article> GetArticle(Guid id)
        {
            var post = await _wordpressClient.Posts.GetByID(id);
            return MapWordpressArticle(post);
        }
    }
}