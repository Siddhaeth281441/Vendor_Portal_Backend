using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VendorPortal.API.Data;

namespace VendorPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RFPSController : ControllerBase
    {
        private readonly VendorPortalDbContext dbContext;

        public RFPSController(VendorPortalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


     

    }
}
