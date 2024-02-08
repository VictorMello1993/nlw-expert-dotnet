using AuctionApp.API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AuctionApp.API.Filters
{
    public class AuthenticationUserAttributes : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly IUsersRepository _repository;

        public AuthenticationUserAttributes(IUsersRepository repository) => _repository = repository;
        
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                var token = TokenOnRequest(context.HttpContext);
                var email = FromBase64String(token);

                var exists = _repository.ExistsWithEmail(email);

                if (!exists)
                {
                    context.Result = new UnauthorizedObjectResult("E-mail is not valid");
                }
            }
            catch (Exception ex)
            {
                context.Result = new UnauthorizedObjectResult(ex.Message);
            }
        }

        private string TokenOnRequest(HttpContext context)
        {
            var authentication = context.Request.Headers.Authorization.ToString();

            if (string.IsNullOrWhiteSpace(authentication))
            {
                throw new Exception("Token is missing.");
            }

            return authentication["Bearer ".Length..];
        }

        private string FromBase64String(string base64)
        {
            var data = Convert.FromBase64String(base64);

            return System.Text.Encoding.UTF8.GetString(data);
        }
    }
}
