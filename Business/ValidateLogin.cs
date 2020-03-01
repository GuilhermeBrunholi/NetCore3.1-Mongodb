using MongoDB.Driver;
using TesteApi.DbContext;
using TesteApi.Models;

namespace TesteApi.Business
{
    public static class ValidateLogin
    {
        public static User ReturnLogin (string email, string password)
        {
            MongoDbContext db = new MongoDbContext();
            password = Encryption.GerarHashMd5(password);
            var user = db.Users.Find(u => u.Email == email && u.Password == password).FirstOrDefault();
            user.Password = null;
            return user;
        }
    }
}