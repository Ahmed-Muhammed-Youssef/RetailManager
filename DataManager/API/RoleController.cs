using DataManager.Data;
using DataManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataManager.API
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ApplicationDbContext applicationDbContext;

        public RoleController(RoleManager<IdentityRole> roleManager, ApplicationDbContext applicationDbContext)
        {
            this.roleManager = roleManager;
            this.applicationDbContext = applicationDbContext;
        }
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddRole(UserRolePairModel userRolePair)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if(!(await roleManager.RoleExistsAsync(userRolePair.RoleName)))
            {
                await roleManager.CreateAsync(new IdentityRole(userRolePair.RoleName));
            }
            else
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(AddRole), userRolePair.RoleName);
        }

        [HttpGet]
        [Route("get/all")]
        public ActionResult<Dictionary<string, string>> GetAllRoles()
        {
            return Ok(applicationDbContext.Roles.ToDictionary(x => x.Id, x => x.Name));
        }
    }
}
