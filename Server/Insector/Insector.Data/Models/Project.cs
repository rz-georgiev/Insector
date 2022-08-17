namespace Insector.Data.Models
{
    public class Project : BaseModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string LogoUrl { get; set; }

        public int AssignedToTeamId { get; set; }

        public virtual Team AssignedToTeam { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}