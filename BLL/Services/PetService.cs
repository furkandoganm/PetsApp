using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    // Way 1:
    //public interface IPetService
    //{
    //    public IQueryable<PetModel> Query();
    //    public ServiceBase Create(Pet record);
    //    public ServiceBase Update(Pet record);
    //    public ServiceBase Delete(int id);
    //}

    // Way 1:
    //public class PetService : ServiceBase, IPetService
    // Way 2:
    public class PetService : ServiceBase, IService<Pet, PetModel>
    {
        public PetService(Db db) : base(db)
        {
        }

        public IQueryable<PetModel> Query()
        {
            return _db.Pets.Include(p => p.Species).OrderByDescending(p => p.BirthDate).ThenByDescending(p => p.IsFemale).ThenBy(p => p.Name).
                Select(p => new PetModel() { Record = p });
        }

        public ServiceBase Create(Pet record)
        {
            if (_db.Pets.Any(p => p.Name.ToLower() == record.Name.ToLower().Trim() && p.IsFemale == record.IsFemale &&
                p.BirthDate == record.BirthDate))
                return Error("Pet with the same name, birth date and gender exists!");
            record.Name = record.Name?.Trim();
            _db.Pets.Add(record);
            _db.SaveChanges();
            return Success("Pet created successfully.");
        }

        public ServiceBase Update(Pet record)
        {
            if (_db.Pets.Any(p => p.Id != record.Id && p.Name.ToLower() == record.Name.ToLower().Trim() && 
                p.IsFemale == record.IsFemale && p.BirthDate == record.BirthDate))
                return Error("Pet with the same name, birth date and gender exists!");
            record.Name = record.Name?.Trim();
            _db.Pets.Update(record);
            _db.SaveChanges();
            return Success("Pet updated successfully.");
        }

        public ServiceBase Delete(int id)
        {
            var entity = _db.Pets.Include(p => p.PetOwners).SingleOrDefault(p => p.Id == id);
            if (entity is null)
                return Error("Pet can't be found!");
            _db.PetOwners.RemoveRange(entity.PetOwners);
            _db.Pets.Remove(entity);
            _db.SaveChanges();
            return Success("Pet deleted successfully.");
        }
    }
}
