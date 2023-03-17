using System.Collections.Generic;

namespace FIT_Api_Examples.Modul3_MaticnaKnjiga.Models
{
    public class MaticnaKnjigaVM
    {
        public int id { get;set; }
        public string ime { get;set; }
        public string prezime { get; set; }
        public List<GetGodineVM> godine { get; set; }
    }
}
