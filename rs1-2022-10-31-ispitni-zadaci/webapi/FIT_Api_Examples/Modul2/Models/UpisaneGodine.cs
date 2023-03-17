using FIT_Api_Examples.Modul0_Autentifikacija.Models;
using FIT_Api_Examples.Modul3_MaticnaKnjiga.Models;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Examples.Modul2.Models
{

//    - datum upisa u zimski semestar: DateTime
//- godina studija: int
//- akademska godina: FK na tabelu AkademskaGodina(prikazati unutar
//combobox-a)
//- cijena školarine: float
//- obnova: bool
//- datum ovjere: DateTime
//- napomena za ovjeru: text
    public class UpisaneGodine
    {
        [Key]
        public int id { get; set; }
        public int godina { get; set; }
        public DateTime datum_upisa_zimski { get; set; } 
        public DateTime? datum_ovjere_zimski { get; set; }
        public float cijena_skolarine { get; set; }
        public bool obnova { get; set; }
        public string? napomena_za_ovjeru { get; set; }
        [ForeignKey(nameof(akademska_godina))]
        public int akademska_godina_id { get;set; }
        public AkademskaGodina akademska_godina { get; set; }
        [ForeignKey(nameof(student))]
        public int student_id { get; set; }
        public Student student { get; set; }
        [ForeignKey(nameof(evidentirao_korisnik))]
        public int evidentirao_korisnik_id { get; set; }
        public KorisnickiNalog evidentirao_korisnik { get; set; }

    }
}
