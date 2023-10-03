using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Encodings.Web;
using Vehicle.Model;
using Vehicle.Service.Common;

namespace Vehicle.WebAPI.Authentication
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public static UserModel? LoggedUser;
        private readonly IUserService _userService;

        public BasicAuthenticationHandler(
                IOptionsMonitor<AuthenticationSchemeOptions> options,
                ILoggerFactory logger,
                UrlEncoder encoder,
                ISystemClock clock,
                IUserService userService
                )
                : base(options, logger, encoder, clock)
        {
            _userService = userService;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("Missing Authorization Header");

            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = System.Text.Encoding.UTF8.GetString(credentialBytes).Split(':');
                var username = credentials[0];
                var password = credentials[1];

                LoggedUser = await _userService.Login(username, password);

            }
            catch
            {
                return AuthenticateResult.Fail("Invalid Authorization Header");
            }

            if (LoggedUser == null)
                return AuthenticateResult.Fail("Invalid Username or Password");

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, LoggedUser.Username),
                new Claim(ClaimTypes.Name, LoggedUser.Name),
                new Claim(ClaimTypes.Role, LoggedUser.Role.Name)
            };

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);

        }
    }
}
