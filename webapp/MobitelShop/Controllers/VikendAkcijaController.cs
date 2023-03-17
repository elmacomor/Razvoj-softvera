using Microsoft.AspNetCore.Mvc;
using MobitelShop.Data;
using MobitelShop.Models;
using MobitelShop.ViewModels;

namespace MobitelShop.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class VikendAkcijaController:ControllerBase
    {
        private readonly MojDbContext _dbContext;
        [HttpGet]
        public ActionResult AkcijeGetAlll()
        {
            var podaci = _dbContext.VikendAkcija.Select(s => new VikendAkcijaGetAllVM()
            {
                ID = s.ID,
                IznosPopusta = s.IznosPopusta,
                Od = s.Od,
                Do = s.Do,
            });
            return Ok(podaci.ToList());
        }

        [HttpPost]
        public VikendAkcija Snimi([FromBody] VikendAkcijaSnimiVM x)
        {
            VikendAkcija? nova;
            if (x.ID == 0)
            {
                nova = new VikendAkcija();
                _dbContext.Add(nova);
            }
            else
            {
                nova = _dbContext.VikendAkcija.Find(x.ID);
            }
            nova.Od = x.Od;
            nova.Do = x.Do;
            nova.IznosPopusta = x.IznosPopusta;
            _dbContext.SaveChanges();
            return nova;
        }

    }
}
