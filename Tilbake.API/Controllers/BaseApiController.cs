using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Tilbake.Domain.Models;

namespace Tilbake.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        #region Constructor
        public BaseApiController(
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager,
            IConfiguration configuration)
        {
            RoleManager = roleManager;
            UserManager = userManager;
            Configuration = configuration;

            //  Instantiate a single JsonSerializerSettings object
            //  that can be reused  multiple times.
            JsonSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented
            };
        }
        #endregion

        #region Shared Properties
        protected RoleManager<IdentityRole> RoleManager { get; set; }
        protected UserManager<ApplicationUser> UserManager { get; set; }
        protected IConfiguration Configuration { get; set; }
        protected JsonSerializerSettings JsonSettings { get; set; }
        #endregion
    }
}
