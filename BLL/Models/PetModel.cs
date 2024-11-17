using BLL.DAL;
using System.ComponentModel;

namespace BLL.Models
{
    public class PetModel // DTO: Data Transfer Object
    {
        public Pet Record { get; set; }

        public string Name => Record.Name;

        [DisplayName("Female")] // title: DisplayNameFor HTML Helper
        public string IsFemale => Record.IsFemale ? "Yes" : "No";

        [DisplayName("Birth Date")]
        public string BirthDate => !Record.BirthDate.HasValue ? string.Empty : Record.BirthDate.Value.ToString("MM/dd/yyyy");

        public string Height => Record.Height.HasValue ? Record.Height.Value.ToString("N2") : "0";

        public string Weight => (Record.Weight ?? 0).ToString("N1");

        public string Species => Record.Species?.Name;
    }
}
