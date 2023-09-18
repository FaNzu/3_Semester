﻿namespace DependencyInjection.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Duration { get; set; }

        public Album Album { get; set; }
    }
}
