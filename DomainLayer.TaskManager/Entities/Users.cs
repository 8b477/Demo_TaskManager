using System.ComponentModel.DataAnnotations;


namespace DomainLayer.TaskManager.Entities
{
    public class Users
    {
        [Key]
        public Guid Id_User { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public Guid FK_Role { get; set; }
        public Roles Role { get; set; }
        public ICollection<Todos> Todos { get; set; }
    }
}
