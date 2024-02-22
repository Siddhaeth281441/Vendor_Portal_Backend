using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VendorPortal.API.Data;
using VendorPortal.API.Models.Domain;
using VendorPortal.API.Models.Dto;

namespace VendorPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectHeadsController : ControllerBase
    {
        private readonly UserManager<UserProfile> userManager;
        private readonly VendorPortalDbContext dbContext;

        public ProjectHeadsController(UserManager<UserProfile> userManager,VendorPortalDbContext dbContext)
        {
            this.userManager = userManager;
            this.dbContext = dbContext;
        }

        //Get By ID
        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] string Id)
        {
            UserProfile user = await userManager.Users.FirstOrDefaultAsync(x => x.Id == Id);
            if (user == null)
            {
                return BadRequest("Error, Invalid Id !!");
            }
            var userDto = new ProjectHeadDto
            {
                Name = user.Name,
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };
            return Ok(userDto);
        }

        //Update
        [HttpPut]
        [Route("{Id}")]
        public async Task<IActionResult> Update([FromRoute] string Id, [FromBody] ProjectHeadUpdateDto projectHead)
        {
            UserProfile user = await userManager.FindByIdAsync(Id);
            if (user == null)
            {
                return BadRequest("Error, Invalid Id !!");
            }
 
            user.PhoneNumber = projectHead.PhoneNumber;
            user.Name = projectHead.Name;

            var result = await userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return Ok(user);
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        //Get assigned Project
        [HttpGet]
        [Route("Project/{Id}")]
        public async Task<IActionResult> GetProjectDetials([FromRoute] string Id)
        {
            Project project = await dbContext.Projects.FirstOrDefaultAsync(x=> x.ProjectHeadId == Id);
            if (project == null)
            {
                return NotFound();
            }
            var projectdto = new ProjectDto
            {
                Name = project.Name,
                ProjectHeadId = project.ProjectHeadId,
                ProjectHeadName = project.ProjectHeadName,
                ProjectStatus = project.ProjectStatus,
                CreatedOn = project.CreatedOn,
                Description = project.Description 
            };
            return Ok(projectdto);
        }

    }
}
