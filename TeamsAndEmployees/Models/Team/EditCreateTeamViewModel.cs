namespace TeamsAndEmployees.Models
{
    public class EditCreateTeamViewModel : TeamBase 
    {
        public EditCreateTeamViewModel() { }
        public EditCreateTeamViewModel(Team team)
        {
            base.Id = team.Id;
            base.Name = team.Name;
        }
    }
}