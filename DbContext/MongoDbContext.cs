using System;
using MongoDB.Bson;
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
                MongoClient mongoClient = new MongoClient(settings);
                _database = mongoClient.GetDatabase(DatabaseName);
                //bool isMongoLive = _database.RunCommandAsync((Command<BsonDocument>)"{ping:1}").Wait(1000);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível se conectar com o servidor.", ex);
            }

        }

        public IMongoCollection<User> Users
        {
            get { return _database.GetCollection<User>("Users"); }
        }

        public IMongoCollection<Procedure> Procedures
        {
            get { return _database.GetCollection<Procedure>("Procedures"); }
        }

        public IMongoCollection<Schedule> Schedules
        {
            get { return _database.GetCollection<Schedule>("Schedules"); }
        }
    }
}