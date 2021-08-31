using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusteriEko.Models
{
    public class Ilce
    {
        public int IlceId { get; set; }
        public int SehirId { get; set; }
        public string IlceIsim { get; set; }
    }
}