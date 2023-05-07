using CarServiceContracts.BindingModels;
using CarServiceContracts.SearchModels;
using CarServiceContracts.StoragesContracts;
using CarServiceContracts.ViewModels;
using CarServiceDatabaseImplement.Models;
using System.Diagnostics;

namespace CarServiceDatabaseImplement.Implements
{
    public class CarStorage : ICarStorage
    {
        public CarViewModel? Delete(CarBindingModel model)
        {
            using var context = new CarserviceContext();
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
            using var context = new CarserviceContext();
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
            using var context = new CarserviceContext();
            return context.Cars
                    .Where(x => x.Number.Contains(model.Number))
                    .Select(x => x.GetViewModel)
                    .ToList();
        }

        public List<CarViewModel> GetFullList()
        {
            using var context = new CarserviceContext();
            return context.Cars
                    .Select(x => x.GetViewModel)
                    .ToList();
        }

        public CarViewModel? Insert(CarBindingModel model)
        {
            using var context = new CarserviceContext();
            model.Id = context.Cars.Count() > 0 ? context.Cars.Max(x => x.Id) + 1 : 1;
            var newCar = Car.Create(model);
            if (newCar == null)
            {
                return null;
            }
            context.Cars.Add(newCar);
            context.SaveChanges();
            return newCar.GetViewModel;
        }

        public CarViewModel? Update(CarBindingModel model)
        {
            using var context = new CarserviceContext();
            var car = context.Cars.FirstOrDefault(x => x.Id == model.Id);
            if (car == null)
            {
                return null;
            }
            car.Update(model);
            context.SaveChanges();
            return car.GetViewModel;
        }
        public long AddTest(int count)
        {
            using var context = new CarserviceContext();
            List<char> listChar = new() { 'А', 'В', 'Е', 'К', 'М', 'Н', 'О', 'Р', 'С', 'Т', 'У', 'Х' };
            Random rand = new Random();
            int maxId = context.Cars.Count() > 0 ? context.Cars.Max(x => x.Id) + 1 : 1;
            for (int i = 0; i < count; i++)
            {
                int randNumber1 = rand.Next(0, 10);
                int randNumber2 = rand.Next(0, 10);
                int randNumber3 = rand.Next(0, 10);
                int randNumber4 = rand.Next(0, 10);
                int randNumber5 = rand.Next(0, 10);
                int randNumber6 = rand.Next(0, 10);
                string result = listChar[rand.Next(0, listChar.Count)] + randNumber1.ToString() + randNumber2.ToString() + randNumber3.ToString() + listChar[rand.Next(0, listChar.Count)] + listChar[rand.Next(0, listChar.Count)] + randNumber4.ToString() + randNumber5.ToString() + randNumber6.ToString();
                var newCar = Car.Create(new()
                {
                    Id = maxId,
                    Number = result
                });
                maxId++;
                if (newCar == null)
                {
                    continue;
                }
                context.Cars.Add(newCar);
            }
            Stopwatch stopwatch = new();
            stopwatch.Start();
            context.SaveChanges();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        public bool InsertMany(List<CarViewModel> model)
        {
            throw new NotImplementedException();
        }
    }
}