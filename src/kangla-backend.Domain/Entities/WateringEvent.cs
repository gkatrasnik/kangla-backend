﻿using Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class WateringEvent : IEntity
    {
        [Required]
        public DateTime Start { get; set; }
        [Required]
        public DateTime End { get; set; }
        [Required]
        public int PlantId { get; set; }
        public Plant Plant { get; set; } = default!;
    }
}
