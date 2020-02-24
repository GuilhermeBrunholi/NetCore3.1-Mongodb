using System;
using MongoDB.Driver;
using TesteApi.Models;

namespace TesteApi.DbContext
{
    public class MongoDbContext
    {
        public static string ConnectionString { get; set; }
        public static string DatabaseName { get; set; }
        public IMongoDatabase _database { get; }

        public MongoDbContext()
        {
            try
            {
                MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(ConnectionString));
                var mongoClient = new MongoClient(settings);
                _database = mongoClient.GetDatabase(DatabaseName);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível se conectar com o servidor.", ex);
            }

        }
        public IMongoCollection<Person> Peoples
        {
            get
            {
                return _database.GetCollection<Person>("People");
            }
        }
    }
}