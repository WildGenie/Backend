using AutoMapper;
using GelecekBilimde.Backend.Articles;

namespace GelecekBilimde.Backend
{
    public class BackendApplicationAutoMapperProfile : Profile
    {
        public BackendApplicationAutoMapperProfile()
        {
            CreateMap<Article, ArticleDto>();
        }
    }
}
