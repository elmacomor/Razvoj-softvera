using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FIT_Api_Examples.Data;
using FIT_Api_Examples.Helper;
using FIT_Api_Examples.Helper.AutentifikacijaAutorizacija;
using FIT_Api_Examples.Modul0_Autentifikacija.Models;
using FIT_Api_Examples.Modul2.Models;
using FIT_Api_Examples.Modul2.ViewModels;
using FIT_Api_Examples.Modul3_MaticnaKnjiga.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIT_Api_Examples.Modul2.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public static int brojIndeksa = 200000;

        public StudentController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        [HttpPost]
        public ActionResult Snimi([FromBody] StudentSnimiVM x)
        {
            Student obj;
            if (x.id == 0)
            {
                obj=new Student();
                _dbContext.Add(obj);    
                obj.created_time= DateTime.Now;
                obj.broj_indeksa = "IB" + brojIndeksa.ToString();
                brojIndeksa++;
            }
            else
            {
                obj=_dbContext.Student.Find(x.id);
                if (obj == null)
                    return BadRequest("Nije pronadjen student sa datim idjem");
            }
            obj.ime = x.ime;
            obj.prezime = x.prezime;
            obj.opstina_rodjenja_id = x.opstina_rodjenja_id;
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public ActionResult Obrisi(int id) {
            Student obj=_dbContext.Student.Find(id);
            if (obj == null) return BadRequest("Objekat ne postoji");
            _dbContext.Student.Remove(obj); 
            _dbContext.SaveChanges();   
            return Ok();
        }

        [HttpGet]
        public ActionResult<List<Student>> GetAll(string ime_prezime)
        {
            var data = _dbContext.Student
                .Include(s => s.opstina_rodjenja.drzava)
                .Where(x => ime_prezime == null || (x.ime + " " + x.prezime).StartsWith(ime_prezime) || (x.prezime + " " + x.ime).StartsWith(ime_prezime))
                .OrderByDescending(s => s.id)
                .AsQueryable();
            return data.Take(100).ToList();
        }

    }
}
