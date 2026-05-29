using EmployeeManagementSystem.DTOs;
using EmployeeManagementSystem.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    [Route("api/departments")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _service;
        public DepartmentController(IDepartmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();

            return Ok(result.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result.Value == null)
            {
                return NotFound("Department not found.");
            }
            return Ok(result.Value);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DepartmentCreateRequestDto department)
        {
            var result = await _service.CreateAsync(department);
            if (result.IsFailed)
            {
                return BadRequest(result.Errors);
            }
            return Ok(result.Value);
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] DepartmentUpdateRequestDto department)
        {
            var result = await _service.UpdateAsync(department);
            if (result.IsFailed)
            {
                return BadRequest(result.Errors);
            }
            else if (result.Value is null)
            {
                return NotFound("Department not found.");
            }
            return Ok(result.Value);
        }
    }
}
