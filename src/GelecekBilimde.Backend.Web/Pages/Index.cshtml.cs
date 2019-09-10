using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace GelecekBilimde.Backend.Web.Pages
{
    public class IndexModel : BackendPageModel
    {
        public void OnGet()
        {
            
        }

        public async Task OnPostLoginAsync()
        {
            await HttpContext.ChallengeAsync("oidc");
        }
    }
}