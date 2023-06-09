﻿using System.ComponentModel.DataAnnotations;

namespace MagicPlace_API.Dto
{
    public class PlaceDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is Required")]
        [MaxLength(100)]
        public string Name { get; set; }

        public string Detail { get; set; }

        [Required(ErrorMessage ="Cost is Required")]
        public double Cost { get; set; }

        public int Ocupants { get; set; }

        public int SquareMeters { get; set; }

        public string ImageUrl { get; set; }

        public string Service { get; set; }
    }
}
