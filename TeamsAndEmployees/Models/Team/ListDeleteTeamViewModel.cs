using System;
using System.ComponentModel.DataAnnotations;

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

        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Employees")]
        public int EmployeeCount
        {
            get { return _employeeCount; }
        }
    }
}