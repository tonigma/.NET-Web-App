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
    public class RegionManagmentServices
    {
        private TravelDbContext6 context = new TravelDbContext6();

        public List<RegionDTO> GetAllByName(string name)
        {
            using (UnitOfWork repo = new UnitOfWork())
            {
                var regions = repo.RegionRepository.GetAllByName(RegionName => RegionName.RegionName == name);
                return regions.Select(region => new RegionDTO
                {
                    Id = region.Id,
                    RegionName = region.RegionName,
                    RegionLanguage = region.RegionLanguage,
                    RegionPopulation = region.RegionPopulation,
                    Landmark = region.Landmark,
                    RegionPriceOfWaterBottle = region.RegionPriceOfWaterBottle,
                    RegionArrival = region.RegionArrival,
                    country = new CountryDTO
                    {
                        Id = region.CountryId,
                        Name = region.country.Name,
                        Language = region.country.Language,
                        Capital = region.country.Capital,
                        Population = region.country.Population,
                        PriceOfWaterBottle = region.country.PriceOfWaterBottle,
                        Arrival = region.country.Arrival
                    }

                }).ToList();
            }
        }

        public List<RegionDTO> Get()
        {

            using (UnitOfWork repo = new UnitOfWork())
            {
                var regions = repo.RegionRepository.Get();
                var result = regions.Select(region => new RegionDTO
                {
                    Id = region.Id,
                    RegionName = region.RegionName,
                    RegionLanguage = region.RegionLanguage,
                    RegionPopulation = region.RegionPopulation,
                    Landmark = region.Landmark,
                    RegionPriceOfWaterBottle = region.RegionPriceOfWaterBottle,
                    RegionArrival = region.RegionArrival,
                    country = new CountryDTO
                    {
                        Id = region.CountryId,
                        Name = region.country.Name,
                        Language = region.country.Language,
                        Capital = region.country.Capital,
                        Population = region.country.Population,
                        PriceOfWaterBottle = region.country.PriceOfWaterBottle,
                        Arrival = region.country.Arrival
                    }
                }).ToList();

                return result;
            }


        }


        public RegionDTO GetById(int id)
        {


            using (UnitOfWork repo = new UnitOfWork())
            {
                var region = repo.RegionRepository.GetByID(id);
                return region == null ? null : new RegionDTO
                {
                    Id = region.Id,
                    RegionName = region.RegionName,
                    RegionLanguage = region.RegionLanguage,
                    RegionPopulation = region.RegionPopulation,
                    Landmark = region.Landmark,
                    RegionPriceOfWaterBottle = region.RegionPriceOfWaterBottle,
                    RegionArrival = region.RegionArrival,
                    country = new CountryDTO
                    {
                        Id = region.CountryId,
                        Name = region.country.Name,
                        Language = region.country.Language,
                        Capital = region.country.Capital,
                        Population = region.country.Population,
                        PriceOfWaterBottle = region.country.PriceOfWaterBottle,
                        Arrival = region.country.Arrival
                    }
                };
            }
        }

        public bool Save(RegionDTO regionDto)
        {

            try
            {
                using (UnitOfWork repo = new UnitOfWork())
                {
                    try
                    {
                        var region = new Region()
                        {
                            RegionName = regionDto.RegionName,
                            RegionLanguage = regionDto.RegionLanguage,
                            RegionPopulation = regionDto.RegionPopulation,
                            Landmark = regionDto.Landmark,
                            RegionPriceOfWaterBottle = regionDto.RegionPriceOfWaterBottle,
                            RegionArrival = regionDto.RegionArrival,
                            CountryId = regionDto.CountryId,
                            country = repo.CountryRepository.GetByID(regionDto.CountryId),
                            CreatedOn = DateTime.Now
                        };
                        repo.RegionRepository.Insert(region);
                        repo.Save();
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
                return true;

            }
            catch
            {
                return true;
            }
        }


        public bool Update(RegionDTO regionDto)
        {


            using (UnitOfWork repo = new UnitOfWork())
            {
                try
                {
                    var result = repo.RegionRepository.GetByID(regionDto.Id);
                    if (result == null)
                    {
                        return false;
                    }
                    result.Id = regionDto.Id;
                    result.RegionName = regionDto.RegionName;
                    result.RegionLanguage = regionDto.RegionLanguage;
                    result.RegionPopulation = regionDto.RegionPopulation;
                    result.Landmark = regionDto.Landmark;
                    result.RegionPriceOfWaterBottle = regionDto.RegionPriceOfWaterBottle;
                    result.RegionArrival = regionDto.RegionArrival;
                    result.CountryId = regionDto.CountryId;
                    repo.RegionRepository.Update(result);
                    repo.Save();
                    return true;
                }
                catch
                {
                    return false;
                }

            }
        }

        public bool Delete(int id)
        {
            try
            {
                using (UnitOfWork repo = new UnitOfWork())
                {
                    Region region = repo.RegionRepository.GetByID(id);
                    repo.RegionRepository.Delete(region);
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
