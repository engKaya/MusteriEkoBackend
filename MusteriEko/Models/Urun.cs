using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusteriEko.Models
{
    public class Urun
    {   
        public int UrunId { get; set; }
        public int MusteriId { get; set; }
        public int MarkaId { get; set; }
        public string Model { get; set; }
        public string RAM { get; set; }
        public string CPU { get; set; }
        public string HardDrive { get; set; }
    }
}