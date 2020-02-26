using MongoDB.Driver;
using TesteApi.Models;
using TesteApi.DbContext;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TesteApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly MongoDbContext _db;

        public UserController() 
        {
            _db = new MongoDbContext();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<User> users = _db.Users.Find(m => true).ToList();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            User user = _db.Users.Find(m => m.Id == id).FirstOrDefault();
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            _db.Users.InsertOne(user);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] User user)
        {
            _db.Users.ReplaceOne(p => p.Id == user.Id, user);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(string id)
        {
            _db.Users.DeleteOne(p => p.Id == id);
            return Ok();
        }
    }
}