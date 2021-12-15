using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RMDataManager.Library.DataAccess.Internal.DataAccess;
using RMDataManager.Library.Models;
using RMDataManager.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace RMDataManager.Controllers
{
    [Authorize]
    [RoutePrefix("api")]
    public class UserController : ApiController
    {
        // GET: User/Id/
        [HttpGet]
        [Route("userid")]
        public UserModel GetUser()
        {
            string id = RequestContext.Principal.Identity.GetUserId();
            UserData userData = new UserData();
            
            return userData.GetUserById(id).First();
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("admin/users")]
        public List<ToDisplayUserModel> GetAllUsers()
        {
            List<ToDisplayUserModel> toDisplayUserModels = new List<ToDisplayUserModel>();
            using (var context = new ApplicationDbContext())
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                var users = userManager.Users.ToList();
                var roles = context.Roles.ToList();

                foreach (var user in users)
                {
                    var userToDisplay = new ToDisplayUserModel()
                    {
                        Id = user.Id,
                        Email = user.Email
                    };
                    foreach (var userRole in user.Roles)
                    {
                        //To get the role name corresponding to the role id
                        foreach (var role in roles)
                        {
                            if (role.Id == userRole.RoleId)
                            {
                                userToDisplay.Roles.Add(role.Id, role.Name);
                            }

                        }
                    }
                    toDisplayUserModels.Add(userToDisplay);
                }
            }

            return toDisplayUserModels;
        }
    }
}
