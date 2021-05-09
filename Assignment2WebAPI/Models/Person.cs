using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Assignment2WebAPI.Models
{
    public class Person
    {
        [JsonPropertyName("Id"), Key]
        [Required]
        public int Id { get; set; }
        
        [JsonPropertyName("FirstName")]
        [Required]
        public string FirstName { get; set; }
        
        [JsonPropertyName("LastName")]
        [Required]
        public string LastName { get; set; }
        
        [JsonPropertyName("HairColor")]
        [Required]
        public string HairColor { get; set; }
        
        [JsonPropertyName("EyeColor")]
        [Required]
        public string EyeColor { get; set; }
        
        [JsonPropertyName("Age")]
        [Required]
        public int Age { get; set; }
        
        [JsonPropertyName("Weight")]
        [Required]
        public float Weight { get; set; }
        
        [JsonPropertyName("Height")]
        [Required]
        public int Height { get; set; }
        
        [JsonPropertyName("Sex")]
        [Required]
        public string Sex { get; set; }
        
        public void Update(Person toUpdate)
        {
            Age = toUpdate.Age;
            Height = toUpdate.Height;
            HairColor = toUpdate.HairColor;
            Sex = toUpdate.Sex;
            Weight = toUpdate.Weight;
            EyeColor = toUpdate.EyeColor;
            FirstName = toUpdate.FirstName;
            LastName = toUpdate.LastName;
        }
    }
}