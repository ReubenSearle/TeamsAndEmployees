using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamsAndEmployees.Models
{
    public class ListDeleteTeamViewModel : TeamBase
    {
        private int _employeeCount;

        public ListDeleteTeamViewModel() { }
        public ListDeleteTeamViewModel(Team team)
        {
            base.Id = team.Id;
            base.Name = team.Name;

            this.DateCreated = team.DateCreated;

            if (team.Employees != null)
            {
                _employeeCount = team.Employees.Count;
            }
        }

        public DateTime DateCreated { get; set; }

        public int EmployeeCount
        {
            get { return _employeeCount; }
        }
    }
}