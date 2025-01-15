
namespace DomainLayer.TaskManager.Entities
{
    public class Todos
    {
        public Guid Id_Todo { get; set; }
        public string TodoName { get; set; }
        public string TodoDescription { get; set; }
        public DateTime TodoCreatedAt { get; set; }
        public DateTime TodoUpdatedAt { get; set; }
        public DateTime TodoFinishedAt { get; set; }
        public bool TodoIsClosed { get; set; }
        public bool TodoPriority { get; set; }
        public TodoStatus Status { get; set; }
        public Users User { get; set; }
    }
}
