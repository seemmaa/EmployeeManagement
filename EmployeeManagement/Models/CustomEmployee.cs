using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EmployeeManagement.Models
{
    public class CustomEmployee
    {
        [DefaultValue("")]
        public string FirstName { get; set; }
        [DefaultValue("")]
        public string LastName { get; set; }
        [DefaultValue("1990-01-01T00:00:00")]
        public DateTime DateOfBirth { get; set; }
        [DefaultValue("1990-01-01T00:00:00")]
        public DateTime DateOfEmployment { get; set; }
        [DefaultValue("1990-01-01T00:00:00")]
        public DateTime EndOfServiceDate { get; set; }
        [Required]
        public int YearsOfService
        {
            get
            {
                DateTime endDate = EndOfServiceDate == DateTime.MinValue ? DateTime.Now : EndOfServiceDate;
                int years = endDate.Year - DateOfEmployment.Year;
                return years;
            }
        }
        [DefaultValue("")]
        public string Position { get; set; }

        public int? DepartmentId { get; set; }

        public bool? IsActive { get; set; }

    }
}

