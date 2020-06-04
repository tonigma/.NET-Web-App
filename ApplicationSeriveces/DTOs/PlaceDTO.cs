using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSeriveces.DTOs
{
    public class PlaceDTO : BaseDTO, IValidate
    {
        [MaxLength(50)]
        [Required]
        public string Placename { get; set; }
        public int averageAge { get; set; }
        public decimal EntryTax { get; set; }
        public decimal distance { get; set; }
        public int RoadToPlace { get; set; }
        public DateTimeOffset PlaceArrival { get; set; }
        public int RegionId { get; set; }
        public virtual RegionDTO Region { get; set; }

        public bool Validate()
        {
            return !string.IsNullOrEmpty(Placename);
        }
    }
}
