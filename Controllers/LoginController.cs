using MongoDB.Driver;
using TesteApi.DbContext;
using Microsoft.AspNetCore.Mvc;
using TesteApi.Business;

namespace TesteApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly MongoDbContext _db;
        public LoginController()
        {
            _db = new MongoDbContext();
        }

        [HttpGet("{email}/{password}")]
        public IActionResult Login(string email, string password)
        {
            var user = ValidateLogin.ReturnLogin(email, password);
            if (user == null) return BadRequest("E-mail or Password invalid");
            return Ok(user);
        }
    }
}