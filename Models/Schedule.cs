using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace TesteApi.Models
{
    public class Schedule
    {
        [BsonId]
        public string Id { get; set; } = Convert.ToString(Guid.NewGuid());
        [Required]
        public string PatientId { get; set; }
        [Required]
        public DateTime DateProcedure { get; set; }
        [Required]
        public DateTime SchedulingDate { get; set; } = DateTime.Now;
        [Required]
        public List<string> Procedures { get; set; }
    }
}