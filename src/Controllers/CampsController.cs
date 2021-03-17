using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCodeCamp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CampsController : ControllerBase
    {
        public CampsController()
        {

        }

        //public object Get()
        //{
        //    return new { Moniker = "TJones", Name = "Tom Jones" };
        //}

        [HttpGet(Name = "GetCamps")]
        public IActionResult GetCamps()
        {
            return Ok(new { Moniker = "TJones", Name = "Tom Jones" });
        }
    }
}
