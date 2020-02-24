using MongoDB.Driver;
using TesteApi.Model;
using TesteApi.DbContext;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TesteApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly MongoDbContext _db;

        public PeopleController() 
        {
            _db = new MongoDbContext();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Person> peoples = _db.Peoples.Find(m => true).ToList();
            return Ok(peoples);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            Person person = _db.Peoples.Find(m => m.Id == id).FirstOrDefault();
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            _db.Peoples.InsertOne(person);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] Person person)
        {
            _db.Peoples.ReplaceOne(p => p._id == person._id, person);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(string id)
        {
            _db.Peoples.DeleteOne(p => p.Id == id);
            return Ok();
        }
    }
}