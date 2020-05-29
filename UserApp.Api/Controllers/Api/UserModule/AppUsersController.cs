using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UserApp.Domain.UserModule;
using UserApp.Models.Main;
using RxWeb.Core.AspNetCore;
using RxWeb.Core.Security.Authorization;
using Microsoft.AspNetCore.Authorization;

namespace UserApp.Api.Controllers.UserModule
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
	
	public class AppUsersController : BaseDomainController<AppUser,AppUser>

    {
        public AppUsersController(IAppUserDomain domain):base(domain) {}

    }
}
