using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace TesteApi.Models
{
    
    public class User
    {
        [BsonId]
        public string Id { get; set; } = Convert.ToString(Guid.NewGuid());
        [Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public DateTime Birth { get; set; }
        [Required]
        public string Document { get; set; }
        public string Rule { get; set;} = "user";
    }


}