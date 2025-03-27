using Microsoft.AspNetCore.Http;
using System.Linq;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Services;
namespace EmployeeManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]


    public class EmployeeController : ControllerBase
    {

        private readonly EmployeeService _employee;
        public EmployeeController(EmployeeService employee)
        {
            _employee = employee;
        }
        [HttpGet("all")]
        public ActionResult<List<Employee>> All()
        {
            return _employee.GetAllEmployees();
        }
        [HttpGet("active")]
        public ActionResult<List<Employee>> GetActive()
        {


            return _employee.GetActiveEmployees();
        }
        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmpById(int id)
        {
            return _employee.GetEmployeeById(id);
        }
        [HttpGet("InActive")]
        public ActionResult<List<Employee>> GetINActiveEmp()
        {
            return _employee.GetInActiveEmployees();
        }
        [HttpGet("DepId")]
        public ActionResult<List<Employee>> GetEmpByDepId(int depId)
        {
            return _employee.GetEmployeeByDepId(depId);
        }
        [HttpGet("ByPosition")]
        public ActionResult<List<Employee>> GetEmpByPosition(string position)
        {
            return _employee.GetEmployeesByPosition(position);
        }
        [HttpGet("MinYearsOfService")]
        public ActionResult<List<Employee>> getEmpMinYears()
        {
            return _employee.getMinService();
        }
        [HttpPut("deactivateEmployee")]
        public ActionResult<string> DeactivateEmp(int id)
        {
            return _employee.deactivateEmployee(id);
        }
        [HttpPost("AddNewEmployee")]
        public ActionResult<string> AddEmp(Employee e)
        {
            return _employee.AddEmployee(e);
        }
        [HttpPut("UpdteEmployee")]
        public ActionResult<string> UpdateEmp(int id, [FromBody] Employee e)
        {
            return _employee.UpdateEmployee(id, e);
        }
        [HttpDelete("DeletEmployee")]
        public ActionResult<string> DeleteEmp(int id)
        {
            return _employee.DeleteEmployee(id);
        }
    }
}

