using System;
using System.ComponentModel.DataAnnotations;

namespace FianlProject.Models
{
	public class Product
	{
        public Product() { }

        public int Id { get; set; }
        [Required]
        public string? Brand { get; set; }
        [Required]
        public string? Color { get; set; }

        
        [Required]
        public double? Price { get; set; }
    }
}

