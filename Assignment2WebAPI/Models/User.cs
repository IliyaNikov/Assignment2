using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Assignment2WebAPI.Models
{
    public class User
    {
        [JsonPropertyName("UserName"), Key]
        public string UserName { get; set; }
        
        [JsonPropertyName("Password")]
        public string Password { get; set; }
        
        [JsonPropertyName("SecurityLevel")]
        public string SecurityLevel { get; set; }
    }
}