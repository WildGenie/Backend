using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace GelecekBilimde.Backend.Articles.Bookmarks
{
    public interface IArticleBookmarksAppService : IApplicationService
    {
        Task AddAsync(Guid articleId);

        Task RemoveAsync(Guid articleId);

        Task<ICollection<Guid>> Get();
    }
}