using System.Data.Entity;

namespace TeamsAndEmployees.Models
{
    public class TeamsAndEmployeesContext : DbContext
    {
        public TeamsAndEmployeesContext() : base("name=TeamsAndEmployeesContext") {}
        
        public DbSet<Team> Teams { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
