using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Services;
namespace EmployeeManagement.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController:ControllerBase
    {
        private readonly DepartmentService _department;
        public DepartmentController(DepartmentService department)
        {
            _department = department;
        }

        [HttpGet("All")]
        public ActionResult<List<Department>> GetAllDep()
        {
            return _department.GetAllDepartments();

        }
        [HttpGet("getDepartentById")]
        public ActionResult<Department> GetDepById(int id)
        {
            return _department.GetDepartmentById(id);
        }

        [HttpPost("AddNewDepartment")]
        public ActionResult<string> AddDep(Department department)
        {
            return _department.AddDepartment(department);
        }
        [HttpPut("UpdateDepartment")]
        public ActionResult<string> UpdateDep(int id, Department department)
        {
            return _department.UpdateDepartment(id, department);
        }
        [HttpDelete("deleteDepartment")]
        public ActionResult<string> DeleteDep(int id)
        {
            return _department.DeleteDepartment(id);
        }
        [HttpGet("GetEmployeesByDepartmentName")]
        public ActionResult<List<Employee>> GetEmpByDepName(string name)
        {
            return _department.GetEmpByDepName(name);
        }
    }
}