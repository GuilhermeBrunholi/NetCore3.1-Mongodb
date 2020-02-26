using MongoDB.Driver;
using TesteApi.Models;
using TesteApi.DbContext;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TesteApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScheduleController : ControllerBase
    {
        private readonly MongoDbContext _db;

        public ScheduleController()
        {
            _db = new MongoDbContext();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Schedule> schedules = _db.Schedules.Find(s => true).ToList();
            return Ok(schedules);
        }

        [HttpGet("{id}")]
        public IActionResult GetAll(string id)
        {
            Schedule schedule = _db.Schedules.Find(s => s.Id == id).SingleOrDefault();
            return Ok(schedule);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Schedule schedule)
        {
            _db.Schedules.InsertOne(schedule);
            return Ok(schedule);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Schedule schedule)
        {
            _db.Schedules.ReplaceOne(s => s.Id == schedule.Id, schedule);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(string id)
        {
            _db.Schedules.DeleteOne(s => s.Id == id);
            return Ok();
        }

    }
}