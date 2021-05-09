using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Assignment2WebAPI.Models
{
    public class Adult : Person
    {
        [Required]
        [JsonPropertyName("JobTitle")]
        public String JobTitle { get; set; }
        
        public void Update(Adult toUpdate) {
            JobTitle = toUpdate.JobTitle;
            base.Update(toUpdate);
        }
        
    }
}