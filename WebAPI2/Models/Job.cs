using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI2.Models
{
    public class Job
    {
        public string JobTitle { get; set; }
        public int Salary { get; set; }
    }
}