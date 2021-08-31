using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusteriEko.Models
{
    public class Araba
    {
        public int AracId { get; set; }
        public int MusteriId { get; set; }
        public int MarkaId { get; set; }
        public int Yil { get; set; }
        public string Model { get; set; }
        public string Motor { get; set; }
        public string ResimUrl { get; set; }
        public string Base64 { get; set; }
    }
}