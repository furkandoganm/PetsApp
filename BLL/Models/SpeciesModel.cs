using BLL.DAL;

namespace BLL.Models
{
	public class SpeciesModel
	{
        public Species Record { get; set; }

        public string Name => Record.Name;
    }
}
