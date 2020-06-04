using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Entity
{
    public class Country : BaseEntity
    {
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Language { get; set; }
        [MaxLength(50)]
        public string Capital { get; set; }
        public int Population { get; set; }
        public decimal PriceOfWaterBottle { get; set; }
        public DateTimeOffset Arrival { get; set; }

        public ICollection<Region> regions { get; set; }
    }
}
