using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeamsAndEmployees.Models
{
    public class Team : TeamBase
    {
        public DateTime DateCreated { get; set; }
        public virtual List<Employee> Employees { get; set; }

        public Team() { }
        public Team(EditCreateTeamViewModel teamModel)
        {
            base.Id = teamModel.Id;
            base.Name = teamModel.Name;
            this.DateCreated = DateTime.Now;
        }
    }
}