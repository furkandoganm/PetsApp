using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
	public class Owner
	{
        public int Id { get; set; }

        [Required]
        [StringLength(60)]
        public string Name { get; set; }

		[Required]
		[StringLength(60)]
		public string Surname { get; set; }

		public List<PetOwner> PetOwners { get; set; } = new List<PetOwner>();
	}
}
