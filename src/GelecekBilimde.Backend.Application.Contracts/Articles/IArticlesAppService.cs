using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Application.Services;

namespace GelecekBilimde.Backend.Articles
{
    public interface IArticlesAppService : IApplicationService
    {
        [UsedImplicitly]
        Task<IEnumerable<ArticleDto>> Get();

        [UsedImplicitly]
        Task<IEnumerable<ArticleDto>> GetByAuthorAsync(int authorId);

        [UsedImplicitly]
        Task<IEnumerable<ArticleDto>> GetByCategoryAsync(int categoryId);

        [UsedImplicitly]
        Task<IEnumerable<ArticleDto>> GetByTagAsync(int tagId);

        [UsedImplicitly]
        Task<IEnumerable<ArticleDto>> SearchAsync(string searchTerm);

        [UsedImplicitly]
        Task<IEnumerable<ArticleDto>> GetStickyAsync();

        [UsedImplicitly]
        Task<ArticleDto> Get(Guid id);
    }
}