using CarServiceContracts.BindingModels;
using CarServiceContracts.SearchModels;
using CarServiceContracts.StoragesContracts;
using CarServiceContracts.ViewModels;
using CarServiceDatabaseImplement.Models;

namespace CarServiceDatabaseImplement.Implements
{
	public class CarStorage : ICarStorage
	{
		public CarViewModel? Delete(CarBindingModel model)
		{
			using var context = new CarServiceDatabase();
			var element = context.Cars.FirstOrDefault(rec => rec.Id == model.Id);
			if (element != null)
			{
				context.Cars.Remove(element);
				context.SaveChanges();
				return element.GetViewModel;
			}
			return null;
		}

		public CarViewModel? GetElement(CarSearchModel model)
		{
			if (string.IsNullOrEmpty(model.Number) && !model.Id.HasValue)
			{
				return null;
			}
			using var context = new CarServiceDatabase();
			return context.Cars
					.FirstOrDefault(x => (!string.IsNullOrEmpty(model.Number) && x.Number == model.Number) ||
										(model.Id.HasValue && x.Id == model.Id))
					?.GetViewModel;
		}

		public List<CarViewModel> GetFilteredList(CarSearchModel model)
		{
			if (string.IsNullOrEmpty(model.Number))
			{
				return new();
			}
			using var context = new CarServiceDatabase();
			return context.Cars
					.Where(x => x.Number.Contains(model.Number))
					.Select(x => x.GetViewModel)
					.ToList();
		}

		public List<CarViewModel> GetFullList()
		{
			using var context = new CarServiceDatabase();
			return context.Cars
					.Select(x => x.GetViewModel)
					.ToList();
		}

		public CarViewModel? Insert(CarBindingModel model)
		{
			var newCar = Car.Create(model);
			if (newCar == null)
			{
				return null;
			}
			using var context = new CarServiceDatabase();
			context.Cars.Add(newCar);
			context.SaveChanges();
			return newCar.GetViewModel;
		}

		public CarViewModel? Update(CarBindingModel model)
		{
			using var context = new CarServiceDatabase();
			var car = context.Cars.FirstOrDefault(x => x.Id == model.Id);
			if (car == null)
			{
				return null;
			}
			car.Update(model);
			context.SaveChanges();
			return car.GetViewModel;
		}
	}
}