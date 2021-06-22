using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.AppBuilders
{
    public static class UseCulture
    {
        public static IApplicationBuilder Culture(this IApplicationBuilder app)
        {
            var cultureInfo = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
            return app;
        }
    }
}
