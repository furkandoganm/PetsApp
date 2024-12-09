using BLL.DAL;

namespace BLL.Models
{
    public class OwnerModel
    {
        public Owner Record { get; set; }

        public string Name => Record.Name;

        public string Surname => Record.Surname;

        public string NameAndSurname => Record.Name + " " + Record.Surname;
    }
}
