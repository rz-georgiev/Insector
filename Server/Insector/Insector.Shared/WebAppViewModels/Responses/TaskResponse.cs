namespace Insector.Shared.WebAppViewModels.Responses
{
    public class TaskResponse
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public float Progress { get; set; }

        public int TypeId { get; set; }

        public int ProgressId { get; set; }

        public int AssignedToUserId { get; set; }
    }
}