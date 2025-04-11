using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace EmployeeManagement.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DefaultValue("")]
        public string Name { get; set; }
        [DefaultValue("")]
        public string DepartmentSupervisor {  get; set; }
    }
}
