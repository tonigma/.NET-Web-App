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
    public class PlacesManagmentSercies
    {

        private TravelDbContext6 context = new TravelDbContext6();

        public List<PlaceDTO> GetAllByName(string name)
        {
            using (UnitOfWork repo = new UnitOfWork())
            {
                var Places = repo.PlaceRepository.GetAllByName(PlaceName => PlaceName.Placename == name);
                return Places.Select(place => new PlaceDTO
                {
                    Id = place.Id,
                    Placename = place.Placename,
                    averageAge = place.averageAge,
                    PlaceArrival = place.PlaceArrival,
                    RoadToPlace = place.RoadToPlace,
                    distance = place.distance,
                    EntryTax = place.EntryTax,
                    Region = new RegionDTO
                    {
                        Id = place.RegionId,
                        RegionName = place.Region.RegionName,
                        RegionLanguage = place.Region.RegionLanguage,
                        RegionPopulation = place.Region.RegionPopulation,
                        Landmark = place.Region.Landmark,
                        RegionPriceOfWaterBottle = place.Region.RegionPriceOfWaterBottle,
                        RegionArrival = place.Region.RegionArrival
                    }

                }).ToList();
            }
        }

        public List<PlaceDTO> Get()
        {

            using (UnitOfWork repo = new UnitOfWork())
            {
                var Places = repo.PlaceRepository.Get();
                var result = Places.Select(place => new PlaceDTO
                {
                    Id = place.Id,
                    Placename = place.Placename,
                    averageAge = place.averageAge,
                    PlaceArrival = place.PlaceArrival,
                    RoadToPlace = place.RoadToPlace,
                    distance = place.distance,
                    EntryTax = place.EntryTax,
                    Region = new RegionDTO
                    {
                        Id = place.RegionId,
                        RegionName = place.Region.RegionName,
                        RegionLanguage = place.Region.RegionLanguage,
                        RegionPopulation = place.Region.RegionPopulation,
                        Landmark = place.Region.Landmark,
                        RegionPriceOfWaterBottle = place.Region.RegionPriceOfWaterBottle,
                        RegionArrival = place.Region.RegionArrival
                    }
                }).ToList();

                return result;
            }


        }


        public PlaceDTO GetById(int id)
        {

            using (UnitOfWork repo = new UnitOfWork())
            {
                var place = repo.PlaceRepository.GetByID(id);
                return place == null ? null : new PlaceDTO
                {
                    Id = place.Id,
                    Placename = place.Placename,
                    averageAge = place.averageAge,
                    PlaceArrival = place.PlaceArrival,
                    RoadToPlace = place.RoadToPlace,
                    distance = place.distance,
                    EntryTax = place.EntryTax,
                    Region = new RegionDTO
                    {
                        Id = place.RegionId,
                        RegionName = place.Region.RegionName,
                        RegionLanguage = place.Region.RegionLanguage,
                        RegionPopulation = place.Region.RegionPopulation,
                        Landmark = place.Region.Landmark,
                        RegionPriceOfWaterBottle = place.Region.RegionPriceOfWaterBottle,
                        RegionArrival = place.Region.RegionArrival
                    }
                };
            }
        }

        public bool Save(PlaceDTO placeDto)
        {

            try
            {
                using (UnitOfWork repo = new UnitOfWork())
                {
                    try
                    {
                        var place = new Place()
                        {
                            Placename = placeDto.Placename,
                            averageAge = placeDto.averageAge,
                            PlaceArrival = placeDto.PlaceArrival,
                            RoadToPlace = placeDto.RoadToPlace,
                            distance = placeDto.distance,
                            EntryTax = placeDto.EntryTax,
                            RegionId = placeDto.Region.Id,
                            Region = repo.RegionRepository.GetByID(placeDto.Region.Id),
                            CreatedOn = DateTime.Now
                        };
                        repo.PlaceRepository.Insert(place);
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


        public bool Update(PlaceDTO placeDto)
        {

            using (UnitOfWork repo = new UnitOfWork())
            {
                try
                {
                    var result = repo.PlaceRepository.GetByID(placeDto.Id);
                    if (result == null)
                    {
                        return false;
                    }
                    result.Placename = placeDto.Placename;
                    result.averageAge = placeDto.averageAge;
                    result.PlaceArrival = placeDto.PlaceArrival;
                    result.RoadToPlace = placeDto.RoadToPlace;
                    result.distance = placeDto.distance;
                    result.EntryTax = placeDto.EntryTax;
                    result.RegionId = placeDto.RegionId;
                    repo.PlaceRepository.Update(result);
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
                    Place place = repo.PlaceRepository.GetByID(id);
                    repo.PlaceRepository.Delete(place);
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
