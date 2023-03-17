using System.ComponentModel.DataAnnotations;

namespace MobitelShop.Models
{
    public class VikendAkcija
    {
        [Key]
        public int ID { get; set; }
        public DateTime Od { get; set; }
        public DateTime Do { get; set; }
        public string IznosPopusta { get; set; }
    }
}
