using CarServiceContracts.BindingModels;
using CarServiceContracts.SearchModels;
using CarServiceContracts.StoragesContracts;
using CarServiceContracts.ViewModels;
using CarServiceMongoDBImplement.Models;
using MongoDB.Driver;

namespace CarServiceMongoDBImplement.Implements
{
    public class EmployeeStorage : IEmployeeStorage
    {
        private CarServiceConnect connect = new();
        public long AddTest(int count)
        {
            var employeesCollection = connect.ConnectToMongo<Employee>("employees");
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
                var newEmployee = Employee.Create(new()
                {
                    Name = listName[randName],
                    Surname = listSurname[randSurname],
                    Patronymic = ListPatronymic[randPatronymic],
                    Phone = result
                });
                if (newEmployee == null)
                {
                    continue;
                }
                employeesCollection.InsertOne(newEmployee);
            }
            return 1L;
        }

        public EmployeeViewModel? Delete(EmployeeBindingModel model)
        {
            var employeesCollection = connect.ConnectToMongo<Employee>("employees");
            var element = employeesCollection.Find(rec => rec.Id == model.MId).FirstOrDefault();
            if (element != null)
            {
                employeesCollection.DeleteOne(x => x.Id == model.MId);
                return element.GetViewModel;
            }
            return null;
        }

        public EmployeeViewModel? GetElement(EmployeeSearchModel model)
        {
            if (string.IsNullOrEmpty(model.Phone) && string.IsNullOrEmpty(model.MId))
            {
                return null;
            }
            var employeesCollection = connect.ConnectToMongo<Employee>("employees");
            return employeesCollection.Find(x => (!string.IsNullOrEmpty(model.Phone) && x.Phone == model.Phone) ||
                                        (!string.IsNullOrEmpty(model.MId) && x.Id == model.MId))
                                    .FirstOrDefault()
                                    ?.GetViewModel;
        }

        public List<EmployeeViewModel> GetFilteredList(EmployeeSearchModel model)
        {
            if (string.IsNullOrEmpty(model.Phone))
            {
                return new();
            }
            var employeesCollection = connect.ConnectToMongo<Employee>("employees");
            return employeesCollection.Find(x => x.Phone.Contains(model.Phone))
                                 .ToList()
                                 .Select(x => x.GetViewModel)
                                 .ToList();
        }

        public List<EmployeeViewModel> GetFullList()
        {
            var employeesCollection = connect.ConnectToMongo<Employee>("employees");
            return employeesCollection.Find(_ => true)
                                 .ToList()
                                 .Select(x => x.GetViewModel)
                                 .ToList();
        }

        public EmployeeViewModel? Insert(EmployeeBindingModel model)
        {
            var employeesCollection = connect.ConnectToMongo<Employee>("employees");
            var newEmployee = Employee.Create(model);
            if (newEmployee == null)
            {
                return null;
            }
            employeesCollection.InsertOne(newEmployee);
            return newEmployee.GetViewModel;
        }

        public bool InsertMany(List<EmployeeViewModel> model)
        {
            var employeesCollection = connect.ConnectToMongo<Employee>("employees");
            List<Employee> models = model.Select(x => Employee.Create(new() { Name = x.Name, Patronymic = x.Patronymic, Phone = x.Phone, Surname = x.Surname })).ToList();
            employeesCollection.InsertMany(models);
            return true;
        }

        public EmployeeViewModel? Update(EmployeeBindingModel model)
        {
            var employeesCollection = connect.ConnectToMongo<Employee>("employees");
            var employee = employeesCollection.Find(x => x.Id == model.MId).FirstOrDefault();
            if (employee == null)
            {
                return null;
            }
            employee.Update(model);
            var filter = Builders<Employee>.Filter.Eq("Id", model.MId);
            employeesCollection.ReplaceOne(filter, employee, new ReplaceOptions { IsUpsert = true });
            return employee.GetViewModel;
        }
    }
}
