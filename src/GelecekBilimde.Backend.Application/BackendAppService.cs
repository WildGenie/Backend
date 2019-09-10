using System;
using System.Collections.Generic;
using System.Text;
using GelecekBilimde.Backend.Localization;
using Volo.Abp.Application.Services;

namespace GelecekBilimde.Backend
{
    /* Inherit your application services from this class.
     */
    public abstract class BackendAppService : ApplicationService
    {
        protected BackendAppService()
        {
            LocalizationResource = typeof(BackendResource);
        }
    }
}
