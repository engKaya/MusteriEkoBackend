using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusteriEko.Models
{
    public class Musteri
    {
        public int MusteriId { get; set; }
        public string MusteriIsim { get; set; }
        public string MusteriSoyIsim { get; set; }
        public string MusteriTel { get; set; }
        public string MusteriSehir { get; set; }
        public string MusteriIlce { get; set; }
        public string MusteriAdres { get; set; }
        public string MusteriMail { get; set; }
        public string MusteriSikayet { get; set; }
    }
}