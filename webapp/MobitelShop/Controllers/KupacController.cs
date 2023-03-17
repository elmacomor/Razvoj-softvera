using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobitelShop.Data;
using MobitelShop.Models;
using MobitelShop.ViewModels;

namespace MobitelShop.Controllers
{
  [Route("[controller]/[action]")]
  [ApiController]
  public class KupacController : ControllerBase
  {
    private readonly MojDbContext _dbContext;
    public KupacController(MojDbContext dbContext)
    {
      this._dbContext = dbContext;
    }


    [HttpPost]
    public ActionResult Snimi([FromBody] KorisnikGetAllVM k)
    {
      Korisnik? kupac;
      if (k.ID == 0)
      {
        kupac = new Korisnik();
        _dbContext.Add(kupac);
      }
      else
      {
        kupac = _dbContext.Korisnik.Find(k.ID);
        if (kupac == null)
          return BadRequest("Pogresan ID");

      }

      kupac.Email = k.Email;
      kupac.Ime = k.Ime;
      kupac.Prezime = k.Prezime;
      kupac.Username = k.Username;
      kupac.Password = k.Password;

      _dbContext.SaveChanges();
      return Ok(kupac);
    }



    [HttpGet]
    public ActionResult GetAll()
    {
      var podaci = _dbContext.Korisnik.Select(k => new KorisnikGetAllVM()
      {
        ID=k.ID,
        Email = k.Email,
        Ime=k.Ime,
        Prezime=k.Prezime,
        Username=k.Username,
       Password=k.Password 
      });
      return Ok(podaci.ToList());
    }



    [HttpPost]
    public ActionResult Delete([FromBody] KorisnikDeleteVM x)
    {
      Korisnik? korisnik = _dbContext.Korisnik.Find(x.ID);

      if (korisnik == null)
        return BadRequest("Pogresan ID");

      _dbContext.Remove(korisnik);

      _dbContext.SaveChanges();
      return Ok(korisnik);
    }
  }
}
