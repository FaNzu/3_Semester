﻿using System.ComponentModel;

namespace WeatherAppWeb.Models
{
    public class ForecastRequestVM
    {
        [DisplayName("City Name")]
        public string CityName { get; set; } = string.Empty;

        [DisplayName("unit type")]
        public string UnitType { get; set; } = string.Empty;
    }
}
