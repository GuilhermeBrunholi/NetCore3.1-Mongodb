using MongoDB.Driver;
using TesteApi.DbContext;
using TesteApi.Models;

namespace TesteApi.Business
{
    public static class ValidateUser
    {
        public static User ValidateNewUser(User user)
        {
            var db = new MongoDbContext();
            var exist = db.Users.Find(u => u.Email == user.Email || u.Document == user.Document).FirstOrDefault();
            if (exist == null) 
            {
                user.Password = Encryption.GerarHashMd5(user.Password);
                return (user);
            }
            else
            {
                return (null);
            }
        }

        public static string ValidateSwapPassword(string password)
        {
            return Encryption.GerarHashMd5(password);
        }
    }
}