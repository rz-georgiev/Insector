namespace Insector.Shared.WebAppViewModels.Responses
{
    public class TeamResponse
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string LogoUrl { get; set; }

        public ICollection<int> ProjectsIds { get; set; }

        public ICollection<int> UsersIds { get; set; }
    }
}