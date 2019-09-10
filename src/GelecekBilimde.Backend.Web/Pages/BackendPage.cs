using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using GelecekBilimde.Backend.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace GelecekBilimde.Backend.Web.Pages
{
    public abstract class BackendPage : AbpPage
    {
        [RazorInject]
        public IHtmlLocalizer<BackendResource> L { get; set; }
    }
}
