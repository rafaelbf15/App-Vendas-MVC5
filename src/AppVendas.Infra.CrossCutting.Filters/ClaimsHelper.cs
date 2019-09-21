using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AppVendas.Infra.CrossCutting.Filters
{
    public static class ClaimsHelper
    {
        public static MvcHtmlString IfClaimHelper(this MvcHtmlString value, string claimName, string claimValue)
        {
            var identity = (ClaimsIdentity)HttpContext.Current.User.Identity;
            return ValidarClaimUsuario(identity, claimName, claimValue) ? value : MvcHtmlString.Empty;
        }

        public static string IfClaimShow(this WebViewPage value, string claimName, string claimValue)
        {
            var identity = (ClaimsIdentity)HttpContext.Current.User.Identity;
            return ValidarClaimUsuario(identity, claimName, claimValue) ? "" : "disabled";
        }

        public static bool IfClaim(this WebViewPage value, string claimName, string claimValue)
        {
            var identity = (ClaimsIdentity)HttpContext.Current.User.Identity;
            return ValidarClaimUsuario(identity, claimName, claimValue);
        }

        public static bool ValidarClaimUsuario(ClaimsIdentity claimsIdentity, string claimName, string claimValue)
        {
            var claim = claimsIdentity.Claims.FirstOrDefault(c => c.Type == claimName);
            return claim != null && claim.Value.Contains(claimValue);
        }

    }
}
