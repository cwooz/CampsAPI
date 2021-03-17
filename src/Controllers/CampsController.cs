using CoreCodeCamp.Data;
using Microsoft.AspNetCore.Http;
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
        private readonly ICampRepository _repository;

        public CampsController(ICampRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }


        [HttpGet(Name = "GetCamps")]
        public async Task<IActionResult> GetCamps()
        {
            try
            {
                var results= await _repository.GetAllCampsAsync(false);

                return Ok(results);
            }
            catch (Exception ex)
            {
                //return StatusCode(500, "A problem happened while handling your request.");
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
