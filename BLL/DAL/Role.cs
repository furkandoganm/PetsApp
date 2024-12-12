using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class Role
    {
        public int Id { get; set; }

        [Required, StringLength(5)] // Admin, User
        public string Name { get; set; }

        public List<Role> Roles { get; set; } = new List<Role>();
    }
}