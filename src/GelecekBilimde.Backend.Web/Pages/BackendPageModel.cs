using GelecekBilimde.Backend.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace GelecekBilimde.Backend.Web.Pages
{
    public abstract class BackendPageModel : AbpPageModel
    {
        protected BackendPageModel()
        {
            LocalizationResourceType = typeof(BackendResource);
        }
    }
}