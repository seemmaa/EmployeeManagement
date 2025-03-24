![what-are-employee-management-systems](https://github.com/user-attachments/assets/a0eff6e0-e841-4cc3-8a43-c4cbf118758e)

Welcome to the Employee Management API! This project is built using ASP.NET Core Web API to manage employee and department data. It provides a set of endpoints to perform CRUD operations and additional features to track employee status and service years.

# API Endpoints

### Employee API

GET /api/employees/all - Get all employees

GET /api/employee/active - Get all active employees

GET /api/employee/InActive - Get all inactive employees

GET /api/employee/{id} - Get an employee by ID

POST /api/employee/AddNewEmployee - Create a new employee

PUT /api/employee/UpdateEmployee - Update an employee

DELETE /api/employee/DeleteEmployee - Delete an employee

GET /api/employee/DepId - Get employees by department ID

GET /api/employee/ByPosition - Get employees by position

GET /api/employee/MinYearsOfService - Get employees with a minimum number of service years

PUT /api/employee/deactivateEmployee - Deactivate an employee

### Department API

GET /api/department/All - Get all departments

GET /api/department/getDepartmentById - Get a department by ID

POST /api/department/AddNewDepartment - Create a new department

PUT /api/department/UpdateDepartment - Update a department

DELETE /api/department/deleteDepartment - Delete a department

GET /api/department/{id}/GetEmployeesByDepartmentName - Get employees in a specific department

