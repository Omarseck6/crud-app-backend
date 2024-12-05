using crud_app_backend.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace crud_app_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRepository _employeeRepository;

        public EmployeeController(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [HttpPost]
        public async Task<ActionResult> AddEmployee([FromBody] Employee model)
        {
          await  _employeeRepository.AddEmployeeAsync(model);
            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult> GetEmployeeList()
        {
            var employeList = await _employeeRepository.GetAllEmployeeAsync();
            return Ok(employeList);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetEmployeeById([FromRoute] int id)
        {
            var employe = await _employeeRepository.GetEmployeeById(id);
            return Ok(employe);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEmployee([FromRoute] int id, [FromBody] Employee model)
        {
            await _employeeRepository.UpdateEmployee(id, model);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee([FromRoute] int id)
        {
            await _employeeRepository.DeleteEmployee(id);
            return Ok();
        }
    }
}
