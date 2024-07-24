﻿using Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Domain.Model
{
    public class HumidityMeasurement: IEntity
    {
        [Required]
        public required DateTime DateTime { get; set; }
        /// <summary>
        /// Soil humidity reading from capacitive sensor
        /// </summary>
        [Required]
        [Range(0,1000, ErrorMessage = "Value must be between 0 and 1000")]
        public int SoilHumidity { get; set; }
        [Required]
        public int WateringDeviceId { get; set; }
        public WateringDevice WateringDevice { get; set; } = default!;
    }
}
