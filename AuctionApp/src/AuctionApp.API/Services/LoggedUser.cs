using AuctionApp.API.Entities;
using AuctionApp.API.Interfaces;

namespace AuctionApp.API.Services
{
    public class LoggedUser : ILoggedUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUsersRepository _repository;
        public LoggedUser(IHttpContextAccessor httpContext, IUsersRepository repository)
        {
            _httpContextAccessor = httpContext;
            _repository = repository;   
        }

        public User User()
        {
            var token = TokenOnRequest();
            var email = FromBase64String(token);

            return _repository.GetByEmail(email);
        }
        
        private string TokenOnRequest()
        {
            var authentication = _httpContextAccessor.HttpContext!.Request.Headers.Authorization.ToString();            

            return authentication["Bearer ".Length..];
        }

        private string FromBase64String(string base64)
        {
            var data = Convert.FromBase64String(base64);

            return System.Text.Encoding.UTF8.GetString(data);
        }
    }
}
