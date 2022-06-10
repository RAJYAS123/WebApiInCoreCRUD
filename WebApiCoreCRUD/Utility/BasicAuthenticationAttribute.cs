using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebApiCoreCRUD.Utility
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization != null)
            {
                var authToken = actionContext.Request.Headers
                    .Authorization.Parameter;
                var decodeauthToken = authToken;

                //var arrUserNameandPassword = decodeauthToken.Split(':');

                if (IsAuthorizedUser(decodeauthToken))
                {

                    Thread.CurrentPrincipal = new GenericPrincipal(
                           new GenericIdentity(decodeauthToken), null);
                }
                else
                {
                    actionContext.Response = actionContext.Request
                        .CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
            else
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }


        public static bool IsAuthorizedUser(string decodeauthToken)
        {
            var data = WebApiCoreCRUD.Utility.GlobalUtilities.Decryption(decodeauthToken);
            if (!string.IsNullOrEmpty(data))
            {
                var de_token = data.Split('@');
                if (de_token[0] == "compiler" && de_token[1] == "coder" && Convert.ToDateTime(de_token[2]).AddMinutes(20) >= DateTime.Now)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
