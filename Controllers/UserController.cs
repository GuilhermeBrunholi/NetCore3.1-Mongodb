using MongoDB.Driver;
using TesteApi.Models;
using TesteApi.DbContext;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TesteApi.Business;

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
            user = ValidateUser.ValidateNewUser(user);
            if (user != null)
            {
                _db.Users.InsertOne(user);
                return Ok();
            }
            else
            {
                return BadRequest("Registered email or document");
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] User user)
        {
            if(user.Id == null) return BadRequest();
            _db.Users.ReplaceOne(u => u.Id == user.Id, user);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(string id)
        {
            _db.Users.DeleteOne(u => u.Id == id);
            return Ok();
        }

        [HttpPut("edit-password")]
        public IActionResult SwapPassword([FromBody] User user)
        {
            if(user.Id == null) return BadRequest();
            user.Password = ValidateUser.ValidateSwapPassword(user.Password);
            _db.Users.ReplaceOne(u => u.Id == user.Id, user);
            return Ok();
        }
    }
}