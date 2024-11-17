using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
	public class Pet
	{
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public bool IsFemale { get; set; }

        public DateTime? BirthDate { get; set; }

        public decimal? Height { get; set; }
        public decimal? Weight { get; set; }

        // Way 1:
        //public int SpeciesId { get; set; }
        // Way 2:
        //[Required]
        //public int? SpeciesId { get; set; }
        // Way 3:
        [Required(ErrorMessage = "Species is required!")] // ErrorMessage will be shown in the view
        public int? SpeciesId { get; set; }

        public Species Species { get; set; } // navigational property

        public List<PetOwner> PetOwners { get; set; } = new List<PetOwner>(); // navigational property
    }
}
