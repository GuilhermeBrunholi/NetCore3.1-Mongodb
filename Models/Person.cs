using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TesteApi.Models
{
    public class Person
    {
        [BsonId]
        public string Id { get; set; } = Convert.ToString(Guid.NewGuid());
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Birth { get; set; }
    }
}