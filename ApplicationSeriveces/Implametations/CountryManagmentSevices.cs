using ApplicationSeriveces.DTOs;
using DataBase.Context;
using DataBase.Entity;
using Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSeriveces.Implametations
{
    public class CountryManagmentSevices
    {
        private TravelDbContext6 context = new TravelDbContext6();


        public List<CountryDTO> GetAllByName(string name)
        {
            using (UnitOfWork repo = new UnitOfWork())
            {
                var countries = repo.CountryRepository.GetAllByName(firstName => firstName.Name == name);
                return countries.Select(Country => new CountryDTO
                {
                    Id = Country.Id,
                    Name = Country.Name,
                    Language = Country.Language,
                    Capital = Country.Capital,
                    Population = Country.Population,
                    PriceOfWaterBottle = Country.PriceOfWaterBottle,
                    Arrival = Country.Arrival
                }).ToList();
            }
        }


        public List<CountryDTO> Get()
        {
            List<CountryDTO> countryDto = new List<CountryDTO>();
            using (UnitOfWork repo = new UnitOfWork())
            {
                foreach (var item in repo.CountryRepository.Get())
                {
                    countryDto.Add(new CountryDTO
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Language = item.Language,
                        Capital = item.Capital,
                        Population = item.Population,
                        PriceOfWaterBottle = item.PriceOfWaterBottle,
                        Arrival = item.Arrival
                    });
                }
            }
            return countryDto;
        }

        public CountryDTO GetById(int id)
        {
            CountryDTO countryDto = new CountryDTO();
            using (UnitOfWork repo = new UnitOfWork())
            {
                Country country = repo.CountryRepository.GetByID(id);
                if (country != null)
                {
                    countryDto = new CountryDTO
                    {
                        Id = country.Id,
                        Name = country.Name,
                        Language = country.Language,
                        Capital = country.Capital,
                        Population = country.Population,
                        PriceOfWaterBottle = country.PriceOfWaterBottle,
                        Arrival = country.Arrival
                    };
                }
            }

            return countryDto;
        }


        public bool Save(CountryDTO countryDto)
        {
            Country country = new Country
            {
                Name = countryDto.Name,
                Language = countryDto.Language,
                Capital = countryDto.Capital,
                Population = countryDto.Population,
                PriceOfWaterBottle = countryDto.PriceOfWaterBottle,
                Arrival = countryDto.Arrival
            };

            try
            {
                using (UnitOfWork repo = new UnitOfWork())
                {
                    repo.CountryRepository.Insert(country);
                    repo.Save();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }



        public bool Update(CountryDTO countryDto)
        {
            Country country = new Country
            {
                Id = countryDto.Id,
                Name = countryDto.Name,
                Language = countryDto.Language,
                Capital = countryDto.Capital,
                Population = countryDto.Population,
                PriceOfWaterBottle = countryDto.PriceOfWaterBottle,
                Arrival = countryDto.Arrival
            };

            try
            {
                using (UnitOfWork repo = new UnitOfWork())
                {
                    repo.CountryRepository.Update(country);
                    repo.Save();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }



        public bool Delete(int id)
        {
            try
            {
                using (UnitOfWork repo = new UnitOfWork())
                {
                    Country country = repo.CountryRepository.GetByID(id);
                    repo.CountryRepository.Delete(country);
                    repo.Save();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
