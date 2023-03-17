using FIT_Api_Examples.Data;
using FIT_Api_Examples.Helper.AutentifikacijaAutorizacija;
using FIT_Api_Examples.Modul0_Autentifikacija.Models;
using FIT_Api_Examples.Modul2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace FIT_Api_Examples.Modul3_MaticnaKnjiga.Models
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MaticnaKnjigaController:ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public MaticnaKnjigaController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpPost]
        public ActionResult Snimi([FromBody] GodinaSnimiVM x)
        {
            if (HttpContext.GetLoginInfo().isLogiran == false)
                return BadRequest("Korisnik nije logiran");
            UpisaneGodine nova;
            if (x.id == 0)
            {
                nova = new UpisaneGodine();
                _dbContext.UpisaneGodine.Add(nova);

            }
            else
            {
                nova = _dbContext.UpisaneGodine.Find(x.id);
                if (nova == null)
                    return BadRequest("Godina nije pronadjena");
            }
            nova.cijena_skolarine = x.cijena_skolarine;
            nova.obnova = x.obnova;
            nova.student_id = x.student_id;
            nova.datum_upisa_zimski = x.datum_upisa_zimski;
            nova.akademska_godina_id = x.akademska_godina_id;
            nova.godina = x.godina;
            nova.evidentirao_korisnik_id = HttpContext.GetLoginInfo().korisnickiNalog.id;
            _dbContext.SaveChanges();
            return Ok();
        }


        //public int id { get; set; }
        //public int godina { get; set; }
        //public DateTime datum_upisa_zimski { get; set; }
        //public DateTime? datum_ovjere_zimski { get; set; }
        //public float cijena_skolarine { get; set; }
        //public bool obnova { get; set; }
        //public string? napomena_za_ovjeru { get; set; }
        //public int akademska_godina_id { get; set; }
        //public AkademskaGodina akademska_godina { get; set; }
        //public int evidentirao_korisnik_id { get; set; }
        //public KorisnickiNalog evidentirao_korisnik { get; set; }

        [HttpGet]
        public ActionResult GetMaticnaPodaci(int id)
        {
            var student = _dbContext.Student.Find(id);
            var podaci = new MaticnaKnjigaVM
            {
                id = id,
                ime = student.ime,
                prezime = student.prezime,
                godine = _dbContext.UpisaneGodine.Where(x => x.student_id == id).Select(s => new GetGodineVM()
                {
                    id = s.id,
                    godina = s.godina,
                    datum_upisa_zimski = s.datum_upisa_zimski,
                    datum_ovjere_zimski = s.datum_ovjere_zimski,
                    cijena_skolarine = s.cijena_skolarine,
                    obnova = s.obnova,
                    napomena_za_ovjeru = s.napomena_za_ovjeru,
                    akademska_godina_id = s.akademska_godina_id,
                    akademska_godina = s.akademska_godina,
                    evidentirao_korisnik_id = s.evidentirao_korisnik_id,
                    evidentirao_korisnik = s.evidentirao_korisnik
                }).ToList()
            };
            return Ok(podaci);
        }

        [HttpPost]
        public ActionResult Ovjeri([FromBody] OvjeriVM x)
        {
            var obj = _dbContext.UpisaneGodine.Find(x.id);
            if (obj == null)
                return BadRequest("Nije pronadjen objekat");
            obj.datum_ovjere_zimski = x.datum_ovjere_zimski;
            obj.napomena_za_ovjeru = x.napomena_za_ovjeru;
            _dbContext.SaveChanges();
            return Ok(obj);
        }


    }
}
