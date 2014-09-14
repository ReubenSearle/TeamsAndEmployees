using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamsAndEmployees.Models
{
    public class EmployeeViewModel : Employee
    {
        public int OriginalTeamId { get; set; }

        public EmployeeViewModel() { }
        public EmployeeViewModel(Employee employee)
        {
            base.Id = employee.Id;
            base.FirstName = employee.FirstName;
            base.LastName = employee.LastName;
            base.DateOfBirth = employee.DateOfBirth;
            base.TeamId = employee.TeamId;
            base.Team = employee.Team;

            this.OriginalTeamId = employee.TeamId;
        }
    }
}