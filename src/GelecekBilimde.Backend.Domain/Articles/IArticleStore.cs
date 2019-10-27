using System.Collections.Generic;
using System.Threading.Tasks;
using Guid = System.Guid;

namespace GelecekBilimde.Backend.Articles
{
    public interface IArticleStore
    {
        Task<ICollection<Article>> GetAllArticlesAsync();
        Task<ICollection<Article>> GetArticlesByAuthorAsync(int authorId);
        Task<ICollection<Article>> GetArticlesByCategoryAsync(int categoryId);
        Task<ICollection<Article>> GetArticlesByTagAsync(int tagId);
        Task<ICollection<Article>> GetArticlesBySearchAsync(string searchTerm);
        Task<ICollection<Article>> GetStickyArticlesAsync();

        Task<Article> GetArticle(Guid id);
    }
}