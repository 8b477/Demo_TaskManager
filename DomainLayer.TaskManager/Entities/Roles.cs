using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.TaskManager.Entities
{
    public class Roles
    {
        [Key]
        public Guid Id_Role { get; set; }
        public string RoleName { get; set; }
    }
}
