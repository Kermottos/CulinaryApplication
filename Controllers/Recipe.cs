using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CulinaryApplication.Controllers
{
    public class Recipe
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Products { get; set; }
        [Required]
        public int Time { get; set; }
        [Required]
        public int Difficulty { get; set; }
        [Required]
        public int Rating { get; set; }
    }
}
