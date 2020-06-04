using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSeriveces.DTOs
{
    public class RegionDTO : BaseDTO, IValidate
    {
        public string RegionName { get; set; }
        public string RegionLanguage { get; set; }
        public string Landmark { get; set; }
        public int RegionPopulation { get; set; }
        public decimal RegionPriceOfWaterBottle { get; set; }
        public DateTimeOffset RegionArrival { get; set; }
        public int CountryId { get; set; }
        public virtual CountryDTO country { get; set; }

        public bool Validate()
        {
            return !string.IsNullOrEmpty(RegionName);
        }
    }
}
