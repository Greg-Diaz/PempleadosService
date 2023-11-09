using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PempleadosService.models;
using PempleadosService.repository;

namespace PempleadosService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployesController : ControllerBase
    {
        private readonly iemployeRepository _employeRepository;

        public EmployesController(iemployeRepository employeRepository)
        {
            _employeRepository = employeRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetEmployes(string? nombre)
        {
            if (nombre == null)
            {
                return Ok(await _employeRepository.GetEmployes());
            }
            else
            {
                return Ok(await _employeRepository.GetEmployesDetails(nombre));
            }


        }

        [HttpPost]
        public async Task<ActionResult> CreateEmploye([FromBody] employe emp)
        {
            if (emp == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _employeRepository.CreateEmploye(emp);
            return Created("Created", created);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateEmploye([FromBody] employe emp)
        {
            if (emp == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _employeRepository.UpdateEmploye(emp);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteEmploye([FromBody] int id)
        {

            await _employeRepository.DeleteEmploye(id); 
            return NoContent();
        }
    }


}
