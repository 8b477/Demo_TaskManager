using System.ComponentModel.DataAnnotations;


namespace DomainLayer.TaskManager.Entities
{
    public class Roles
    {
        [Key]
        public Guid Id_Role { get; set; }
        public string RoleName { get; set; }
    }
}
