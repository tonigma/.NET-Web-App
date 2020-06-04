using ApplicationSeriveces.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class RegionViewModel
    {
        public int Id { get; set; }
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
        public string Name { get; set; }
        public CountryViewModels CountryVM { get; set; }

        public RegionViewModel() { }

        public RegionViewModel(RegionDTO regionDto)
        {
            Id = regionDto.Id;
            RegionName = regionDto.RegionName;
            RegionLanguage = regionDto.RegionLanguage;
            RegionPopulation = regionDto.RegionPopulation;
            Landmark = regionDto.Landmark;
            RegionPriceOfWaterBottle = regionDto.RegionPriceOfWaterBottle;
            RegionArrival = regionDto.RegionArrival;
            CountryId = regionDto.country.Id;
            Name = regionDto.country.Name;
            CountryVM = new CountryViewModels
            {
                Id = regionDto.country.Id,
                Name = regionDto.country.Name,
                Language = regionDto.country.Language,
                Capital = regionDto.country.Capital,
                Population = regionDto.country.Population,
                PriceOfWaterBottle = regionDto.country.PriceOfWaterBottle,
                Arrival = regionDto.country.Arrival
            };
        }
    }
}