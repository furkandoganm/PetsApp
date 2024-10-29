using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
	public interface ISpeciesService
	{
		public IQueryable<SpeciesModel> Query();
		public ServiceBase Create(Species record);
		public ServiceBase Update(Species record);
		public ServiceBase Delete(int id);
	}

	public class SpeciesService : ServiceBase, ISpeciesService
	{
		public SpeciesService(Db db) : base(db)
		{
		}

		public IQueryable<SpeciesModel> Query()
		{
			return _db.Species.OrderBy(s => s.Name).Select(s => new SpeciesModel() { Record = s });
		}

		public ServiceBase Create(Species record)
		{
			if (_db.Species.Any(s => s.Name.ToUpper() == record.Name.ToUpper().Trim()))
				return Error("Species with the same name exists!");
			record.Name = record.Name?.Trim();
			_db.Species.Add(record);
			_db.SaveChanges(); // commit to the database
			return Success("Species created successfully.");
		}

		public ServiceBase Update(Species record)
		{
			if (_db.Species.Any(s => s.Id != record.Id && s.Name.ToUpper() == record.Name.ToUpper().Trim()))
				return Error("Species with the same name exists!");
			// Way 1:
			//var entity = _db.Species.Find(record.Id);
			// Way 2:
			var entity = _db.Species.SingleOrDefault(s => s.Id == record.Id);
			if (entity is null)
				return Error("Species can't be found!");
			entity.Name = record.Name?.Trim();
			_db.Species.Update(entity);
			_db.SaveChanges(); // commit to the database
			return Success("Species updated successfully.");
		}

		public ServiceBase Delete(int id)
		{
			var entity = _db.Species.Include(s => s.Pets).SingleOrDefault(s => s.Id == id);
			if (entity is null)
				return Error("Species can't be found!");
			if (entity.Pets.Any()) // Count > 0
				return Error("Species has relational pets!");
			_db.Species.Remove(entity);
			_db.SaveChanges(); // commit to the database
			return Success("Species deleted successfully.");
		}
	}
}
