using EmployeeManagement.Models;
using Microsoft.OpenApi.Validations;

namespace EmployeeManagement.Services
{
    public class EmployeeService
    {
        private readonly List<Employee> _employees = new List<Employee>();
       // private readonly DepartmentService _department;
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

       // private static int _id = 5;

        public List<Employee> GetAllEmployees() => _employees;

        public Employee? GetEmployeeById(int id) => _employees.FirstOrDefault(e => e.Id == id);
        public List<Employee> GetEmployeeByDepId(int departmentId) => _employees.Where(e => e.DepartmentId == departmentId).ToList();

        public List<Employee> GetActiveEmployees() => _employees.Where(n => n.IsActive == true).ToList();

        public List<Employee> GetEmployeesByPosition(string position) => _employees.Where(n => n.Position.ToLower() ==  position.ToLower()).ToList();
        public Employee GetEmployeesByFullName(string fullName) => _employees.FirstOrDefault(n =>string.Equals(  $"{n.FirstName.ToLower()} {n.LastName.ToLower()}" ,fullName.ToLower()));

        public List<Employee> GetInActiveEmployees() => _employees.Where(n => n.IsActive == false).ToList();
        public string AddEmployee(CustomAddEmp employee)
        {
           
          

                var emp = new Employee
                {
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Position = employee.Position,
                    DateOfBirth = employee.DateOfBirth,
                    EndOfServiceDate = employee.EndOfServiceDate,
                    IsActive = true,
                    DepartmentId = employee.DepartmentId,
                    DateOfEmployment = employee.DateOfEmployment,

                };
                //fix
                //  employee.Id = ++_id;
                emp.Id = _employees.Any() ? _employees.Max(e => e.Id) + 1 : 1;
                _employees.Add(emp);
                return "Employee added successfully";
            
           
        }

        public string DeleteEmployee(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee == null) return "Employee not found";
            _employees.Remove(employee);
            return "Employee deleted successfully";
        }

        public string UpdateEmployee(int id, CustomEmployee e)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee == null) return "Employee not found";
            int depid = (int)employee.DepartmentId;
            
                if (!string.IsNullOrEmpty(e.FirstName))
                    employee.FirstName = e.FirstName;
                if (!string.IsNullOrEmpty(e.LastName))
                    employee.LastName = e.LastName;
                if (e.DateOfBirth != new DateTime(1990, 1, 1))
                    employee.DateOfBirth = e.DateOfBirth;
                if (e.EndOfServiceDate != new DateTime(1990, 1, 1))
                    employee.EndOfServiceDate = e.EndOfServiceDate;
                if (e.IsActive != null)
                    employee.IsActive = e.IsActive;
                if (!string.IsNullOrEmpty(e.Position))
                    employee.Position = e.Position;
                if (e.DateOfEmployment != new DateTime(1990, 1, 1))
                    employee.DateOfEmployment = e.DateOfEmployment;
                if (e.DepartmentId != null && e.DepartmentId != 0)
                    employee.DepartmentId = e.DepartmentId;


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
            if(employee == null) return "Employee not found";
            if(employee.IsActive==false)
                return "Employee already inActive";
            employee.IsActive = false;
            employee.EndOfServiceDate = DateTime.Now;
            return "Employee deactivated successfully";
        }
    }
}
