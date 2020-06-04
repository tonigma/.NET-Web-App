using ApplicationSeriveces.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class CountryViewModels
    {
        public int Id { get; set; }
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

        public CountryViewModels() { }

        public CountryViewModels(CountryDTO countryDto)
        {
            Id = countryDto.Id;
            Name = countryDto.Name;
            Language = countryDto.Language;
            Capital = countryDto.Capital;
            Population = countryDto.Population;
            PriceOfWaterBottle = countryDto.PriceOfWaterBottle;
            Arrival = countryDto.Arrival;
        }

    }
}