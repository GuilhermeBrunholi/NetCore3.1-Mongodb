using MongoDB.Driver;
using TesteApi.Models;
using TesteApi.DbContext;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TesteApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProcedureController : ControllerBase
    {
        private readonly MongoDbContext _db;

        public ProcedureController()
        {
           _db = new MongoDbContext();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Procedure> procedures = _db.Procedures.Find(p => true).ToList();
            return Ok(procedures);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            Procedure procedure = _db.Procedures.Find(p => p.Id == id).SingleOrDefault();
            return Ok(procedure);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Procedure procedure)
        {
            _db.Procedures.InsertOne(procedure);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] Procedure procedure)
        {
            _db.Procedures.ReplaceOne(p => p.Id == procedure.Id, procedure);
            return Ok();
        }

        [HttpDelete("{id}")] 
        public IActionResult Remove(string id)
        {
            _db.Procedures.DeleteOne(p => p.Id == id);
            return Ok();
        }

    }
}