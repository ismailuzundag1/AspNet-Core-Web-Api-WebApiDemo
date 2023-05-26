using System.Security.Claims;
using System.Text;

namespace WebApiDemo.CustomMiddlewares
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            string autHeader = context.Request.Headers["Authorization"];

            if (autHeader == null) 
            {
                await _next(context);
                return;
            }

            //basic iso:123

            if(autHeader != null && autHeader.StartsWith("basic", StringComparison.OrdinalIgnoreCase)) 
            {
                var token = autHeader.Substring(6).Trim();
                var credentialString = Encoding.UTF8.GetString(Convert.FromBase64String(token));
                var credentials = credentialString.Split(':');
                if (credentials[0] == "iso" && credentials[1] == "123")
                {
                    var claims = new[]
                    {
                        new Claim("name", credentials[0]),
                        new Claim(ClaimTypes.Role, "Admin")
                    };
                    var identity = new ClaimsIdentity(claims,"Basic");
                    context.User = new ClaimsPrincipal(identity);
                }

            }
            else
            {
                context.Response.StatusCode = 401;
            }

            await _next(context);
        }
    }
}
