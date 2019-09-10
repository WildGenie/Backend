using GelecekBilimde.Backend.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace GelecekBilimde.Backend.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class BackendController : AbpController
    {
        protected BackendController()
        {
            LocalizationResource = typeof(BackendResource);
        }
    }
}