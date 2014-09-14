using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TeamsAndEmployees.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

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