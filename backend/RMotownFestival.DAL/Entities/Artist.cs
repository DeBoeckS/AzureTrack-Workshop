using System;
using System.Collections.Generic;
using System.Text;

namespace RMotownFestival.DAL.Entities
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public Uri Website { get; set; }
    }
}
