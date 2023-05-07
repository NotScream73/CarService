using CarServiceContracts.BindingModels;
using CarServiceContracts.SearchModels;
using CarServiceContracts.StoragesContracts;
using CarServiceContracts.ViewModels;
using CarServiceMongoDBImplement.Models;
using MongoDB.Driver;

namespace CarServiceMongoDBImplement.Implements
{
    public class CarStorage : ICarStorage
    {
        private CarServiceConnect connect = new();
        public long AddTest(int count)
        {
            var carsCollection = connect.ConnectToMongo<Car>("cars");
            List<char> listChar = new() { 'А', 'В', 'Е', 'К', 'М', 'Н', 'О', 'Р', 'С', 'Т', 'У', 'Х' };
            Random rand = new Random();
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
                    Number = result
                });
                if (newCar == null)
                {
                    continue;
                }
                carsCollection.InsertOne(newCar);
            }
            return 1L;
        }

        public CarViewModel? Delete(CarBindingModel model)
        {
            var carsCollection = connect.ConnectToMongo<Car>("cars");
            var element = carsCollection.Find(rec => rec.Id == model.MId).FirstOrDefault();
            if (element != null)
            {
                carsCollection.DeleteOne(x => x.Id == model.MId);
                return element.GetViewModel;
            }
            return null;
        }

        public CarViewModel? GetElement(CarSearchModel model)
        {
            if (string.IsNullOrEmpty(model.Number) && string.IsNullOrEmpty(model.MId))
            {
                return null;
            }
            var carsCollection = connect.ConnectToMongo<Car>("cars");
            return carsCollection.Find(x => (!string.IsNullOrEmpty(model.Number) && x.Number == model.Number) ||
                                        (!string.IsNullOrEmpty(model.MId) && x.Id == model.MId))
                                 .FirstOrDefault()
                                 ?.GetViewModel;
        }

        public List<CarViewModel> GetFilteredList(CarSearchModel model)
        {
            if (string.IsNullOrEmpty(model.Number))
            {
                return new();
            }
            var carsCollection = connect.ConnectToMongo<Car>("cars");
            return carsCollection.Find(x => x.Number.Contains(model.Number))
                                 .ToList()
                                 .Select(x => x.GetViewModel)
                                 .ToList();
        }

        public List<CarViewModel> GetFullList()
        {
            var carsCollection = connect.ConnectToMongo<Car>("cars");
            return carsCollection.Find(_ => true)
                                 .ToList()
                                 .Select(x => x.GetViewModel)
                                 .ToList();
        }

        public CarViewModel? Insert(CarBindingModel model)
        {
            var carsCollection = connect.ConnectToMongo<Car>("cars");
            var newCar = Car.Create(model);
            if (newCar == null)
            {
                return null;
            }
            carsCollection.InsertOne(newCar);
            return newCar.GetViewModel;
        }

        public bool InsertMany(List<CarViewModel> model)
        {
            var carsCollection = connect.ConnectToMongo<Car>("cars");
            List<Car> models = model.Select(x => Car.Create(new() { Number = x.Number })).ToList();
            carsCollection.InsertMany(models);
            return true;
        }

        public CarViewModel? Update(CarBindingModel model)
        {
            var carsCollection = connect.ConnectToMongo<Car>("cars");
            var car = carsCollection.Find(x => x.Id == model.MId).FirstOrDefault();
            if (car == null)
            {
                return null;
            }
            car.Update(model);
            var filter = Builders<Car>.Filter.Eq("Id", model.MId);
            carsCollection.ReplaceOne(filter, car, new ReplaceOptions { IsUpsert = true });
            return car.GetViewModel;
        }
    }
}
