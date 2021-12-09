using Microsoft.AspNet.Identity;
using RMDataManager.Library.DataAccess.Internal.DataAccess;
using RMDataManager.Library.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace RMDataManager.Controllers
{
    [Authorize]
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        // GET: User/Id/
        [HttpGet]
        public UserModel GetUser()
        {
            string id = RequestContext.Principal.Identity.GetUserId();
            UserData userData = new UserData();
            
            return userData.GetUserById(id).First();
        }
    }
}
