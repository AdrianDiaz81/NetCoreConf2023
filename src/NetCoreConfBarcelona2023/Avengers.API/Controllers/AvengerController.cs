using Avengers.API.Service;
using Microsoft.AspNetCore.Mvc;

namespace Avengers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvengerController : ControllerBase
    {
        private IAvengerService _avengerService { get; set; }
        public AvengerController(IAvengerService service)
        {
            this._avengerService= service;  
        }

        [HttpGet]       
        public IActionResult Get()
        {
            return Ok( _avengerService.GetAll());
        }

        [HttpGet("{id}", Name = "GetByIDAvenger")]
        public IActionResult Get(int id)
        {
            var result = _avengerService.Get(id.ToString());
            if (result == null)
            {
                return NotFound();
            }            
            return Ok(result);
        }
    }
}
