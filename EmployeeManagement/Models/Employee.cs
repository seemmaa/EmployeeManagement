
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EmployeeManagement.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [Required]
        public DateTime DateOfEmployment { get; set; }
        public DateTime? EndOfServiceDate { get; set; }
        [Required]
        public int YearsOfService
        {
            get
            {
                DateTime endDate = EndOfServiceDate ?? DateTime.Now;
                int years = endDate.Year - DateOfEmployment.Year;
                return years;
            }
        }
        [Required]
        public string Position { get; set; }
        [Required]
        public int DepartmentId { get; set; }

        public bool? IsActive { get; set; }

    }
}

