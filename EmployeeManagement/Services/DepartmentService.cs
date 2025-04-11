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

        public Department GetDepartmentById(int id) => _department.FirstOrDefault(e => e.Id == id);

        public string AddDepartment(CustomDepartment department)
        {
            var dep = new Department
            {
                Name = department.Name,
                DepartmentSupervisor = department.DepartmentSupervisor
            };
            dep.Id =  _department.Any() ? _department.Max(e => e.Id) + 1 : 1; ;
            if (!(_employee.GetEmployeesByFullName(department.DepartmentSupervisor) is null))
            {
                _department.Add(dep);
                return "Department Added successfully";
            }
            else
            {
                return "Department supervisor must be an Employee";
            }
        }

        public string DeleteDepartment(int id)
        {
            var department = _department.FirstOrDefault(e => e.Id == id);
            if (department == null) return "Department not found";
            if(_employee.GetEmployeeByDepId(id).Any() ) return "Department cannot de deleted";
            _department.Remove(department);
            return "Department deleted successfully";
        }

        public string UpdateDepartment(int id, CustomDepartment d)
        {
            var department= _department.FirstOrDefault(e => e.Id == id);
            if (department == null) return "Department not found";
            if (!string.IsNullOrEmpty(d.Name))
                department.Name = d.Name;
            if (!string.IsNullOrEmpty(d.DepartmentSupervisor)&& !(_employee.GetEmployeesByFullName(d.DepartmentSupervisor)is null))
                department.DepartmentSupervisor = d.DepartmentSupervisor;
            else
            {
                return "Department supervisor must be an employee";
            }

                return "Department updated successfully";
           

        }
        public List<Employee> GetEmpByDepName(string DepName)
        {
            List<Employee> Employees = new List<Employee>();
            var dep = _department.FirstOrDefault(n => n.Name.ToLower() == DepName.ToLower());
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
