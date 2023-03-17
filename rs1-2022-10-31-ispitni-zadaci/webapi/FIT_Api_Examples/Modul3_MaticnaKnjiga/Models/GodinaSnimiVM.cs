using FIT_Api_Examples.Modul0_Autentifikacija.Models;
using FIT_Api_Examples.Modul2.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace FIT_Api_Examples.Modul3_MaticnaKnjiga.Models
{
    public class GodinaSnimiVM
    {
        public int id { get; set; }
        public int godina { get; set; }
        public DateTime datum_upisa_zimski { get; set; }
        public float cijena_skolarine { get; set; }
        public bool obnova { get; set; }
        public int akademska_godina_id { get; set; }
        public int student_id { get; set; }
    }
}
