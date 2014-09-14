using System;
using System.ComponentModel.DataAnnotations;

namespace TeamsAndEmployees.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [Display(Name="First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "DOB")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode=true)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public int TeamId { get; set; }
        public Team Team { get; set; }

        public Employee() { }
        public Employee(EmployeeViewModel employeeModel)
        {
            this.Id = employeeModel.Id;
            this.FirstName = employeeModel.FirstName;
            this.LastName = employeeModel.LastName;
            this.DateOfBirth = employeeModel.DateOfBirth;
            this.TeamId = employeeModel.TeamId;
            this.Team = employeeModel.Team;
        }

    }
}