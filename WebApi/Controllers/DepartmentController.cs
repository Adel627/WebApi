using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Repositores;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly DepartmentRepository _repository;
        public DepartmentController(DepartmentRepository departmentRepository)
        {
            _repository = departmentRepository;
        }

        [HttpGet]
        public IActionResult GetAllDepartments()
        {
            List<Department> departments = _repository.GetAll();
            return Ok(departments);
        }
        [HttpGet("{id:int}",Name ="GetDeptRoute")]
        public IActionResult GetDepartment(int id) 
        {
           Department? dept = _repository.GetbyId(id);
            return Ok(dept);
        }

        [HttpGet("{name:alpha}")]
        public IActionResult GetDepartmentName(string name)
        {
            Department? dept = _repository.GetbyName(name);
            return Ok(dept);
        }
        [HttpPost]
        public IActionResult CreatDepartment (Department dept)
        {
            if (ModelState.IsValid)
            {
                _repository.Creat_Department(dept);
                 string? url = Url.Link("GetDeptRoute", new {id=dept.Id});
                return Created(url,dept);
            }
            return BadRequest("Department Not Valid");
        }
        [HttpPut]
        public IActionResult UpdateDepartment(Department department) 
        {
            if (ModelState.IsValid)
            {
                _repository.Update(department);
                return StatusCode(204,department);
            }
            return BadRequest("Not valid");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                _repository.DeleteById(id);
                return StatusCode(204, "Record Remove Success");
            }
            return BadRequest("Id not Found");
        }

    }
}
