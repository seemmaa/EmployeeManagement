using EmployeeManagement.Models;
using Microsoft.OpenApi.Validations;

namespace EmployeeManagement.Services
{
    public class EmployeeService
    {
        private readonly List<Employee> _employees = new List<Employee>();

        public EmployeeService()
        {
            
            _employees.Add(new Employee
            {
                Id = 1,
                FirstName = "Sema",
                LastName = "Hodali",
                DateOfBirth = new DateTime(1990, 1, 1),
                DateOfEmployment = new DateTime(2015, 6, 1),
                Position = "Software Engineer",
                DepartmentId = 2,
                IsActive = true
            });

            _employees.Add(new Employee
            {
                Id = 2,
                FirstName = "lana",
                LastName = "Ahmad",
                DateOfBirth = new DateTime(1995, 3, 15),
                DateOfEmployment = new DateTime(2016, 4, 1),
                Position = "HR Manager",
                DepartmentId = 1,
                IsActive = true
            });
            _employees.Add(new Employee
            {
                Id = 3,
                FirstName = "Mohamad",
                LastName = "Jarawan",
                DateOfBirth = new DateTime(1989, 3, 15),
                DateOfEmployment = new DateTime(2016, 4, 1),
                Position = "Quality Assurance",
                DepartmentId = 2,
                IsActive = true
            });
            _employees.Add(new Employee
            {
                Id = 4,
                FirstName = "Salma",
                LastName = "Sameh",
                DateOfBirth = new DateTime(1985, 3, 15),
                DateOfEmployment = new DateTime(2011, 4, 1),
                EndOfServiceDate = new DateTime(2016, 4, 1),
                Position = "Office Manager",
                DepartmentId = 1,
                IsActive = false
            });
            _employees.Add(new Employee
            {
                Id = 5,
                FirstName = "Mariam",
                LastName = "Nada",
                DateOfBirth = new DateTime(1999, 7, 23),
                DateOfEmployment = new DateTime(2020, 4, 1),
                Position = "Logistics Manager",
                DepartmentId = 3,
                IsActive = true
            });

        }

        public List<Employee> GetAllEmployees() => _employees;

        public Employee? GetEmployeeById(int id) => _employees.FirstOrDefault(e => e.Id == id);
        public List<Employee> GetEmployeeByDepId(int departmentId) => _employees.Where(e => e.DepartmentId == departmentId).ToList();

        public List<Employee> GetActiveEmployees() => _employees.Where(n => n.IsActive == true).ToList();

        public List<Employee> GetEmployeesByPosition(string position) => _employees.Where(n => n.Position==position
        ).ToList();

        public List<Employee> GetInActiveEmployees() => _employees.Where(n => n.IsActive == false).ToList();
        public string AddEmployee(Employee employee)
        {
            employee.Id = _employees.Count + 1; 
            _employees.Add(employee);
            return "Employee added successfully";
        }

        public string DeleteEmployee(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee == null) return "Department not found";
            _employees.Remove(employee);
            return "Employee deleted successfully";
        }

        public string UpdateEmployee(int id,Employee e)
        {
            var employee = _employees.FirstOrDefault(e => e.Id==id);
            if (employee == null) return "Department not found";
            employee.FirstName= e.FirstName;
            employee.LastName= e.LastName;
            employee.DateOfBirth= e.DateOfBirth;
            employee.EndOfServiceDate= e.EndOfServiceDate;
            employee.IsActive= e.IsActive;
            employee.Position= e.Position;
            employee.DateOfEmployment=e.DateOfEmployment;
            employee.DepartmentId=e.DepartmentId;
            employee.EndOfServiceDate= e.EndOfServiceDate;
            return "Employee updated successfully";

        }

        public List<Employee> getMinService()
        {
            var minS = _employees.Min(e => e.YearsOfService);
            var EmpMin = _employees.Where(n => n.YearsOfService == minS).ToList();
            return EmpMin;
        }

        public string deactivateEmployee(int id)
        {
            var employee = _employees.FirstOrDefault(n => n.Id == id);
            if(employee == null) return "Employye not found";
            employee.IsActive = false;
            employee.EndOfServiceDate = DateTime.Now;
            return "Employee deactivated successfully";
        }
    }
}
