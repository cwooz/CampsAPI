using AutoMapper;
using CoreCodeCamp.Data;
using CoreCodeCamp.Models;
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
        private readonly object _mapper;

        public CampsController(ICampRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        [HttpGet(Name = "GetCamps")]
        public async Task<ActionResult<CampModel[]>> GetCamps()
        {
            try
            {
                var results= await _repository.GetAllCampsAsync(false);

                //CampModel[] models = _mapper.Map<CampModel[]>(results);


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
