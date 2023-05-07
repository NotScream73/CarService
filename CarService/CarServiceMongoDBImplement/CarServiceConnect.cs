using MongoDB.Driver;

namespace CarServiceMongoDBImplement
{
    public class CarServiceConnect
    {
        private const string ConnectionString = "mongodb://127.0.0.1:27017";
        private const string DatabaseName = "carservice";
        public IMongoCollection<T> ConnectToMongo<T>(in string collection)
        {
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase(DatabaseName);
            return db.GetCollection<T>(collection);
        }
    }
}