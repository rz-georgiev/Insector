namespace Insector.Shared.WebAppViewModels.Responses
{
    public class ProjectResponse
    {
        public int Id { get; set; }
        
        public string Title { get; set; }

        public string Description { get; set; }

        public string LogoUrl { get; set; }

        public int AssignedToTeamId { get; set; }
    }
}