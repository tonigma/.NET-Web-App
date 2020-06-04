using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSeriveces.DTOs
{
    public class CountryDTO : BaseDTO, IValidate
    {
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Language { get; set; }
        [MaxLength(50)]
        public string Capital { get; set; }
        public int Population { get; set; }
        public decimal PriceOfWaterBottle { get; set; }
        public DateTimeOffset Arrival { get; set; }

        public bool Validate()
        {
            return !string.IsNullOrEmpty(Name);
        }
    }
}
