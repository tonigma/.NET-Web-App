using ApplicationSeriveces.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class PlaceViewModel
    {
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Placename { get; set; }
        public int averageAge { get; set; }
        public decimal EntryTax { get; set; }
        public decimal distance { get; set; }
        public int RoadToPlace { get; set; }
        public DateTimeOffset PlaceArrival { get; set; }
        public int RegionId { get; set; }
        public string RegionName { get; set; }
        public RegionViewModel RegionVM { get; set; }

        public PlaceViewModel() { }
        public PlaceViewModel(PlaceDTO placeDto)
        {
            Id = placeDto.Id;
            Placename = placeDto.Placename;
            averageAge = placeDto.averageAge;
            PlaceArrival = placeDto.PlaceArrival;
            RoadToPlace = placeDto.RoadToPlace;
            distance = placeDto.distance;
            EntryTax = placeDto.EntryTax;
            RegionId = placeDto.RegionId;
            RegionName = placeDto.Region.RegionName;
            RegionVM = new RegionViewModel
            {
                Id = placeDto.Region.Id,
                RegionName = placeDto.Region.RegionName,
                RegionLanguage = placeDto.Region.RegionLanguage,
                RegionPopulation = placeDto.Region.RegionPopulation,
                Landmark = placeDto.Region.Landmark,
                RegionPriceOfWaterBottle = placeDto.Region.RegionPriceOfWaterBottle,
                RegionArrival = placeDto.Region.RegionArrival
            };
        }
    }
}