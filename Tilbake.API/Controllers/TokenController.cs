using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Tilbake.Application.ViewModels;
using Tilbake.Domain.Models;

namespace Tilbake.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : BaseApiController
    {
        #region Constructor
        public TokenController(
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager,
            IConfiguration configuration) : base (roleManager, userManager, configuration)
        {

        }
        #endregion

        [HttpPost("Auth")]
        public async Task<IActionResult> Jwt([FromBody] TokenRequestViewModel model)
        {
            //  return a generic HTTP Status 500 (Server Error)
            //  if the client payload is invalid.
            if (model == null) return new StatusCodeResult(500);

            return model.GrantType switch
            {
                "password" => await GetToken(model).ConfigureAwait(true),
                _ => new UnauthorizedResult() //  not supported - return a HTTP 401 (UnAuthorized)
            };
        }

        private async Task<IActionResult> GetToken(TokenRequestViewModel model)
        {
            //  Check if there's a user with the given username
            var user = await UserManager.FindByNameAsync(model.Username).ConfigureAwait(true);

            //  Fallback to support email address instead of username
            if (user == null && model.Username.Contains("@", StringComparison.OrdinalIgnoreCase))
                user = await UserManager.FindByEmailAsync(model.Username).ConfigureAwait(true);

            if (user == null || !await UserManager.CheckPasswordAsync(user, model.Password).ConfigureAwait(true))
            {
                //  user does not exists or password mismatch
                return new UnauthorizedResult();
            }

            //  Username & password matches: create and return the Jwt token.
            DateTime now = DateTime.UtcNow;

            //  Add the registered claims JWT (RFC7519).
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, new DateTimeOffset(now).ToUnixTimeSeconds().ToString(CultureInfo.CurrentCulture))
                //  TODO: Add additional claims here
            };

            var tokenExpirationMins = Configuration.GetValue<int>("Auth:Jwt:TokenExpirationInMinutes");
            var issuerSigningkey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(Configuration["Auth:Jwt:Key"]));

            var token = new JwtSecurityToken(
                issuer: Configuration["Auth:Jwt:Issuer"],
                audience: Configuration["Auth:Jwt:Audience"],
                claims: claims,
                notBefore: now,
                expires:
                now.Add(TimeSpan.FromMinutes(tokenExpirationMins)),
                signingCredentials: new SigningCredentials(issuerSigningkey,
                SecurityAlgorithms.HmacSha256)
                );

            var encodedToken = new JwtSecurityTokenHandler().WriteToken(token);

            //Build & return the response
            var response = new TokenResponseViewModel()
            {
                Token = encodedToken,
                Expiration = tokenExpirationMins
            };
            return Ok(response);
        }
    }
}
