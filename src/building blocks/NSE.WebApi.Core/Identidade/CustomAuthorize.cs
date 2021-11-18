using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Security.Claims;

namespace NSE.WebApi.Core.Identidade
{
    public class CustomAuthorization
    {
        public static bool ValidarClaimsUsuario(HttpContext context, string claimName, string claimValue)
        {
            bool estaAutenticado = context.User.Identity.IsAuthenticated;
            bool possuiClaim = context.User.Claims.Any(c => c.Type == claimName && c.Value.Contains(claimValue));
            return estaAutenticado && possuiClaim;
        }
    }

    public class ClaimsAuthorizeAttribute : TypeFilterAttribute
    {
        public ClaimsAuthorizeAttribute(string claimName, string claimValue): base(typeof(RequisitoClaimFilter))
        {
            Arguments = new object[] { new Claim(claimName, claimValue)};
        }
    }

    public class RequisitoClaimFilter : IAuthorizationFilter
    {
        private readonly Claim _claim;

        public RequisitoClaimFilter(Claim claim)
        {
            _claim = claim;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            bool usuarioAutenticado = context.HttpContext.User.Identity.IsAuthenticated;
            if (!usuarioAutenticado)
            {
                context.Result = new StatusCodeResult(401);
                return;
            }

            bool possuiClaimsValidas = CustomAuthorization.ValidarClaimsUsuario(context.HttpContext, _claim.Type, _claim.Value);
            if (!possuiClaimsValidas)
            {
                context.Result = new StatusCodeResult(403);
            }
        }

    }

}
