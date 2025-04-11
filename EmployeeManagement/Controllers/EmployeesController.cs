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


    public class EmployeesController : ControllerBase
    {

        private readonly EmployeeService _employee;
        public EmployeesController(EmployeeService employee)
        {
            _employee = employee;
        }
        [HttpGet]
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

        { if(_employee.GetEmployeeById(id) is null)
                return NotFound($"Employee with ID {id} not found.");
            else
                return Ok( _employee.GetEmployeeById(id));

        }
        [HttpGet("InActive")]
        public ActionResult<List<Employee>> GetINActiveEmp()
        {
            return _employee.GetInActiveEmployees();
        }
        [HttpGet("DepId")]
        public ActionResult<List<Employee>> GetEmpByDepId(int depId)

        {
            if (_employee.GetEmployeeByDepId(depId) is null)
                return NotFound($"Department with ID {depId} not found");
            return Ok(_employee.GetEmployeeByDepId(depId));
        }
        [HttpGet("ByPosition")] //string
        public ActionResult<List<Employee>> GetEmpByPosition(string position)
        {
            if (_employee.GetEmployeesByPosition(position) is null)
                return NotFound("No Employee in this position");
            return _employee.GetEmployeesByPosition(position);
        }

        [HttpGet("ByFullName")]
        public ActionResult<Employee> GetEmpByFullName(string fullName)
            
        {
            if (_employee.GetEmployeesByFullName(fullName) is null)
                return NotFound("No Employee with this name");
            return _employee.GetEmployeesByFullName(fullName);
        }
        [HttpGet("min-years-of-service")]
        public ActionResult<List<Employee>> getEmpMinYears()
        {
            return _employee.getMinService();
        }
        [HttpPut("deactivate-employee")]
        public ActionResult<string> DeactivateEmp(int id)
        {
            return _employee.deactivateEmployee(id);
        }
        [HttpPost]
        public ActionResult<string> AddEmp( CustomAddEmp e)
        {
            return _employee.AddEmployee(e);
        }
        [HttpPut]
        public ActionResult<string> UpdateEmp(int id, [FromBody] CustomEmployee e)
        {
            return _employee.UpdateEmployee(id, e);
        }
        [HttpDelete]
        public ActionResult<string> DeleteEmp(int id)
        {
            return _employee.DeleteEmployee(id);
        }
    }
}

