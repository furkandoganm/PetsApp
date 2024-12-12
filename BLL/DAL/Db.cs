using Microsoft.EntityFrameworkCore;

namespace BLL.DAL
{
	public class Db : DbContext
	{
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Species> Species { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<PetOwner> PetOwners { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public Db(DbContextOptions options) : base(options)
        {
        }
    }
}
