﻿using System.ComponentModel.DataAnnotations;

namespace CitiesManager.WebAPI.Models
{
    public class City
    {
        [Key]
        public Guid Id { get; set; }
        [Required (ErrorMessage = "City Name can't be blank")]
        public string? Name { get; set; }
    }
}
