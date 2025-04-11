using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Services;
namespace EmployeeManagement.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentsController:ControllerBase
    {
        private readonly DepartmentService _department;
        public DepartmentsController(DepartmentService department)//injection service to controller

        {
            _department = department;
        }

        [HttpGet]
        public ActionResult<List<Department>> GetAllDep()
        {
            return _department.GetAllDepartments();

        }
        [HttpGet("{id}")]
        public ActionResult<Department> GetDepById(int id)
        {
            if (_department.GetDepartmentById == null)
                return NotFound($"Department with ID {id} not found");
            return Ok(_department.GetDepartmentById(id));
        }

        [HttpPost]
        public ActionResult<string> AddDep(CustomDepartment department)
        {
            return _department.AddDepartment(department);
        }
        [HttpPut]
        public ActionResult<string> UpdateDep(int id, CustomDepartment department)
        {
            return _department.UpdateDepartment(id, department);
        }
        [HttpDelete]
        public ActionResult<string> DeleteDep(int id)
        {
            return _department.DeleteDepartment(id);
        }
        [HttpGet("emp-by-dep-id")]
        public ActionResult<List<Employee>> GetEmpByDepName(string name)
        {
            return _department.GetEmpByDepName(name);
        }
    }
}