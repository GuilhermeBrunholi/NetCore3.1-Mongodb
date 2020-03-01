using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace TesteApi.Models
{
    public class Company
    {
        [BsonId]
        public string Id { get; set; } = Convert.ToString(Guid.NewGuid());
        [Required]
        public string Document { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string FantasyName { get; set; }
        [Required]
        public List<string> Users { get; set; }
    }
}