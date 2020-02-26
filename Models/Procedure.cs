using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace TesteApi.Models
{
    public class Procedure
    {
        [BsonId]
        public string Id { get; set; } = Convert.ToString(Guid.NewGuid());
        [Required]
        public string ProcedureName { get; set; }
        [Required]
        public string Description { get; set; }
        public double Price { get; set; } = 0.00;
        public bool Active { get; set; } = true;
    }

}