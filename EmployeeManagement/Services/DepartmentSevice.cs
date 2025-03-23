using EmployeeManagement.Models;
using System.Collections.Immutable;
using EmployeeManagement.Services;
using System.Linq;
using Microsoft.AspNetCore.Http.HttpResults;

namespace EmployeeManagement.Services
{

    public class DepartmentService
    {
        private readonly List<Department> _department = new List<Department>();
        private readonly EmployeeService _employee;
        public DepartmentService(EmployeeService employeeService)

        {
            _employee = employeeService;
           
            var EmployeeServic = new EmployeeService();
          
            _department.Add(new Department
            {
                Id = 1,
                Name = "Administration",
                DepartmentSupervisor = "Lana Ahmad"
            });

            _department.Add(new Department
            {
                Id = 2,
                Name = "Technical",
                DepartmentSupervisor="Sema Hodali"
            });
            _department.Add(new Department
            {
                Id = 3,
                Name = "Logistics",
                DepartmentSupervisor = "Mariam Nada"
            });

        }
        public List<Department> GetAllDepartments() => _department;

        public Department? GetDepartmentById(int id) => _department.FirstOrDefault(e => e.Id == id);

        public string AddDepartment(Department department)
        {
            department.Id = _department.Count + 1; 
            _department.Add(department);
            return "Department Added successfully";
        }

        public string DeleteDepartment(int id)
        {
            var department = _department.FirstOrDefault(e => e.Id == id);
            if (department == null) return "Department not found";
            if(_employee.GetEmployeeByDepId(id).Any() ) return "Department cannot de deleted";
            _department.Remove(department);
            return "Department deleted successfully";
        }

        public string UpdateDepartment(int id, Department d)
        {
            var department= _department.FirstOrDefault(e => e.Id == id);
            if (department == null) return "Department not found";
           department.Name = d.Name;
           department.DepartmentSupervisor = d.DepartmentSupervisor;
            return "Department updated successfully";
           

        }
        public List<Employee> GetEmpByDepName(string DepName)
        {
            List<Employee> Employees = new List<Employee>();
            var dep = _department.FirstOrDefault(n => n.Name == DepName);
            if (dep != null)
            {

                var id = dep.Id;

               Employees = _employee.GetEmployeeByDepId(id);
                return Employees;
            }
            return Employees;
           
        }

    }
}
