using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
	public class Species
	{
        public int Id { get; set; }

        [Required]
        [StringLength(70)]
        public string Name { get; set; }

        public List<Pet> Pets { get; set; } = new List<Pet>();
    }
}