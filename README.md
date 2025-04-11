![what-are-employee-management-systems](https://github.com/user-attachments/assets/a0eff6e0-e841-4cc3-8a43-c4cbf118758e)

Welcome to the Employee Management API! This project is built using ASP.NET Core Web API to manage employee and department data. It provides a set of endpoints to perform CRUD operations and additional features to track employee status and service years.

# API Endpoints

### Employee API

GET /api/Employees - Get all employees

GET /api/Employees/active - Get all active employees

GET /api/Employees/InActive - Get all inactive employees

GET /api/Employees/{id} - Get an employee by ID

POST /api/Employees - Create a new employee

PUT /api/Employees - Update an employee

DELETE /api/Employees - Delete an employee

GET /api/Employee/DepId - Get employees by department ID

GET /api/Employees/ByPosition - Get employees by position

GET /api/Employees/ByFullName - Get employees by fullname

GET /api/Employees/min-years-of-service - Get employees with a minimum number of service years

PUT /api/Employees/deactivate-employee - Deactivate an employee

### Department API

GET /api/Departments - Get all departments

GET /api/Departments/{id} - Get a department by ID

POST /api/Departments - Create a new department

PUT /api/Departments - Update a department

DELETE /api/Departments - Delete a department

GET /api/Departments/emp-by-dep-id - Get employees in a specific department

