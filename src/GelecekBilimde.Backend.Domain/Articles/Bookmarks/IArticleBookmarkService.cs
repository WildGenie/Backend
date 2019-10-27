using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GelecekBilimde.Backend.Articles.Bookmarks
{
    public interface IArticleBookmarkService
    {
        Task AddBookmarkAsync(Guid userId, Guid articleId);

        Task<bool> RemoveBookmarkAsync(Guid userId, Guid articleId);

        Task<ICollection<Guid>> GetBookmarks(Guid userId);
    }
}