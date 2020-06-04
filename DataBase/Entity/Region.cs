using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Entity
{
    public class Region : BaseEntity
    {
        [MaxLength(50)]
        [Required]
        public string RegionName { get; set; }
        [MaxLength(50)]
        public string RegionLanguage { get; set; }
        [MaxLength(50)]
        public string Landmark { get; set; }
        public int RegionPopulation { get; set; }
        public decimal RegionPriceOfWaterBottle { get; set; }
        public DateTimeOffset RegionArrival { get; set; }

        public int CountryId { get; set; }
        public virtual Country country { get; set; }

        public ICollection<Place> places { get; set; }
    }
}
