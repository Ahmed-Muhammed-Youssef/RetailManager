using DataManager.Data;
using DataManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RMDataManager.Library.DataAccess.Internal.DataAccess;
using RMDataManager.Library.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DataManager.API
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly UserManager<IdentityUser> userManager;

        public UserController(ApplicationDbContext applicationDbContext, UserManager<IdentityUser> userManager)
        {
            this.applicationDbContext = applicationDbContext;
            this.userManager = userManager;
        }
        // GET: User/Id/
        [HttpGet]
        [Route("id")]
        public ActionResult<UserModel> GetUser()
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            UserData userData = new UserData();

            return Ok(userData.GetUserById(id).First());
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("get/all")]
        public ActionResult<List<ToDisplayUserModel>> GetAllUsers()
        {
            List<ToDisplayUserModel> toDisplayUserModels = new List<ToDisplayUserModel>();

            var users = applicationDbContext.Users.ToList();
            var roles = applicationDbContext.Roles.ToList();
            var userRoles = applicationDbContext.UserRoles.ToList();

            foreach (var user in users)
            {
                var userToDisplay = new ToDisplayUserModel()
                {
                    Id = user.Id,
                    Email = user.Email
                };
                //To get the role name corresponding to the role id
                foreach (var userRole in userRoles)
                {
                    if (user.Id == userRole.UserId)
                    {
                        userToDisplay.Roles.Add(userRole.RoleId, roles.Find(r => r.Id == userRole.RoleId).Name);
                    }
                }
                toDisplayUserModels.Add(userToDisplay);

            }
            return Ok(toDisplayUserModels);
        }

        //[Authorize(Roles = "Admin")]
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("add/role")]
        public async Task<IActionResult> AddRole(UserRolePairModel userRolePair)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            await userManager.AddToRoleAsync(await userManager.FindByIdAsync(userRolePair.UserId), userRolePair.RoleName);
            return CreatedAtAction(nameof(AddRole), userRolePair);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("remove/role")]
        public async Task<IActionResult> RemoveRole(UserRolePairModel userRolePair)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await userManager.RemoveFromRoleAsync(await userManager.FindByIdAsync(userRolePair.UserId), userRolePair.RoleName);
            return Ok(userRolePair);
        }
    }
}
