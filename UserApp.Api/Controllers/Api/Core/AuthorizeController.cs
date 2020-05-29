using Microsoft.AspNetCore.Mvc;
using UserApp.Models.Main;
using UserApp.Infrastructure.Security;
using UserApp.Infrastructure.Singleton;
using UserApp.Models.ViewModels;
using UserApp.UnitOfWork.Main;
using Newtonsoft.Json;
using RxWeb.Core;
using RxWeb.Core.Security;
using System.Threading.Tasks;

namespace UserApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorizeController : ControllerBase
    {
        private ILoginUow LoginUow { get; set; }

        private IUserClaim UserClaim { get; set; }
        private UserAccessConfigInfo UserAccessConfig { get; set; }

        private IApplicationTokenProvider ApplicationTokenProvider { get; set; }

        public AuthorizeController(ILoginUow loginUow, UserAccessConfigInfo userAccessConfig, IUserClaim userClaim, IApplicationTokenProvider applicationTokenProvider)
        {
            this.LoginUow = loginUow;
            UserAccessConfig = userAccessConfig;
            this.UserClaim = userClaim;
            this.ApplicationTokenProvider = applicationTokenProvider;
        }

        [HttpGet(ACCESS)]
        public async Task<IActionResult> Get()
        {
            var accessModules = await UserAccessConfig.GetFullInfoAsync(UserClaim.UserId, LoginUow);
            return Ok(JsonConvert.SerializeObject(accessModules));
        }

        [HttpPost(LOGOUT)]
        public async Task<IActionResult> LogOut(UserConfig userConfig)
        {
            await ApplicationTokenProvider.RemoveTokenAsync(userConfig);
            return Ok();
        }

        [HttpPost(REFRESH)]
        public async Task<IActionResult> Refresh(UserConfig userConfig)
        {
            var user = await this.LoginUow.Repository<AppUser>().SingleAsync(t => t.AppUserId == UserClaim.UserId);
            var token = await ApplicationTokenProvider.RefereshTokenAsync(user, userConfig);
            return Ok(token);
        }

        const string LOGOUT = "logout";

        const string ACCESS = "access";

        const string REFRESH = "refresh";
    }
}

