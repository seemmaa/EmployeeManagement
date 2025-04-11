using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class CustomDepartment
    {
        [Required]
        [DefaultValue("")]
        public string Name { get; set; }
        [DefaultValue("")]
        public string DepartmentSupervisor { get; set; }
    }
}
