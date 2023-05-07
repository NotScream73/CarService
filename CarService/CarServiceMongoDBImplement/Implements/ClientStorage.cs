using CarServiceContracts.BindingModels;
using CarServiceContracts.SearchModels;
using CarServiceContracts.ViewModels;
using CarServiceMongoDBImplement.Models;
using ClientServiceContracts.StoragesContracts;
using MongoDB.Driver;

namespace CarServiceMongoDBImplement.Implements
{
    public class ClientStorage : IClientStorage
    {
        private CarServiceConnect connect = new();
        public long AddTest(int count)
        {
            var clientsCollection = connect.ConnectToMongo<Client>("clients");
            List<string> listName = new();
            StreamReader f = new StreamReader("Names.txt");
            while (!f.EndOfStream)
            {
                listName.Add(f.ReadLine());
            }
            f.Close();
            List<string> listSurname = new();
            f = new StreamReader("Surnames.txt");
            while (!f.EndOfStream)
            {
                listSurname.Add(f.ReadLine());
            }
            f.Close();
            List<string> ListPatronymic = new();
            f = new StreamReader("Patronymics.txt");
            while (!f.EndOfStream)
            {
                ListPatronymic.Add(f.ReadLine());
            }
            f.Close();
            Random rand = new Random();
            for (int i = 0; i < count; i++)
            {
                int randName = rand.Next(0, 100);
                int randSurname = rand.Next(0, 100);
                int randPatronymic = rand.Next(0, 100);
                int num1 = rand.Next(001, 999);
                int num2 = rand.Next(000, 999);
                int num3 = rand.Next(00, 99);
                int num4 = rand.Next(00, 99);
                string result = "8" + num1.ToString() + num2.ToString() + num3.ToString() + num4.ToString();
                var newClient = Client.Create(new()
                {
                    Name = listName[randName],
                    Surname = listSurname[randSurname],
                    Patronymic = ListPatronymic[randPatronymic],
                    Phone = result
                });
                if (newClient == null)
                {
                    continue;
                }
                clientsCollection.InsertOne(newClient);
            }
            return 1L;
        }

        public ClientViewModel? Delete(ClientBindingModel model)
        {
            var clientsCollection = connect.ConnectToMongo<Client>("clients");
            var element = clientsCollection.Find(rec => rec.Id == model.MId).FirstOrDefault();
            if (element != null)
            {
                clientsCollection.DeleteOne(x => x.Id == model.MId);
                return element.GetViewModel;
            }
            return null;
        }

        public ClientViewModel? GetElement(ClientSearchModel model)
        {
            if (string.IsNullOrEmpty(model.Phone) && string.IsNullOrEmpty(model.MId))
            {
                return null;
            }
            var clientsCollection = connect.ConnectToMongo<Client>("clients");
            return clientsCollection.Find(x => (!string.IsNullOrEmpty(model.Phone) && x.Phone == model.Phone) ||
                                        (!string.IsNullOrEmpty(model.MId) && x.Id == model.MId))
                                    .FirstOrDefault()
                                    ?.GetViewModel;
        }

        public List<ClientViewModel> GetFilteredList(ClientSearchModel model)
        {
            if (string.IsNullOrEmpty(model.Phone))
            {
                return new();
            }
            var clientsCollection = connect.ConnectToMongo<Client>("clients");
            return clientsCollection.Find(x => x.Phone.Contains(model.Phone))
                                 .ToList()
                                 .Select(x => x.GetViewModel)
                                 .ToList();
        }

        public List<ClientViewModel> GetFullList()
        {
            var clientsCollection = connect.ConnectToMongo<Client>("clients");
            return clientsCollection.Find(_ => true)
                                 .ToList()
                                 .Select(x => x.GetViewModel)
                                 .ToList();
        }

        public ClientViewModel? Insert(ClientBindingModel model)
        {
            var clientsCollection = connect.ConnectToMongo<Client>("clients");
            var newClient = Client.Create(model);
            if (newClient == null)
            {
                return null;
            }
            clientsCollection.InsertOne(newClient);
            return newClient.GetViewModel;
        }

        public bool InsertMany(List<ClientViewModel> model)
        {
            var clientsCollection = connect.ConnectToMongo<Client>("clients");
            List<Client> models = model.Select(x => Client.Create(new() { Name = x.Name, Patronymic = x.Patronymic, Phone = x.Phone, Surname = x.Surname })).ToList();
            clientsCollection.InsertMany(models);
            return true;
        }

        public ClientViewModel? Update(ClientBindingModel model)
        {
            var clientsCollection = connect.ConnectToMongo<Client>("clients");
            var client = clientsCollection.Find(x => x.Id == model.MId).FirstOrDefault();
            if (client == null)
            {
                return null;
            }
            client.Update(model);
            var filter = Builders<Client>.Filter.Eq("Id", model.MId);
            clientsCollection.ReplaceOne(filter, client, new ReplaceOptions { IsUpsert = true });
            return client.GetViewModel;
        }
    }
}
