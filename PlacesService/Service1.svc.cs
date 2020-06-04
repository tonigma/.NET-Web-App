using ApplicationSeriveces.DTOs;
using ApplicationSeriveces.Implametations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PlacesService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        private CountryManagmentSevices CountryService = new CountryManagmentSevices();

        public List<CountryDTO> GetCountrys()
        {
            return CountryService.Get();
        }

        public CountryDTO GetCountryById(int id)
        {
            return CountryService.GetById(id);
        }

        public string PostCountry(CountryDTO CountryDTO)
        {
            if (!CountryService.Save(CountryDTO))
            {
                return "Country is not inserted";
            }

            return "Country is inserted";
        }

        public string PutCountry(CountryDTO CountryDTO)
        {
            if (!CountryService.Update(CountryDTO))
            {
                return "Country is not updated";
            }

            return "Country is updated";
        }

        public string DeleteCountry(int id)
        {
            if (!CountryService.Delete(id))
            {
                return "Country is not deleted";
            }

            return "Country is deleted";
        }
        public List<CountryDTO> GetAllCountrysByName(string name)
        {
            return CountryService.GetAllByName(name);
        }







        private RegionManagmentServices RegionService = new RegionManagmentServices();

        public List<RegionDTO> GetRegions()
        {
            return RegionService.Get();
        }

        public RegionDTO GetRegionById(int id)
        {
            return RegionService.GetById(id);
        }

        public string PostRegion(RegionDTO regionDto)
        {
            if (!RegionService.Save(regionDto))
            {
                return "Region is not inserted";
            }
            return "Region is inserted";
        }

        public string PutRegion(RegionDTO regionDto)
        {
            if (!RegionService.Update(regionDto))
            {
                return "Region is not updated";
            }
            return "Region is updated";
        }

        public string DeleteRegion(int id)
        {
            if (!RegionService.Delete(id))
            {
                return "Region is not deleted";
            }
            return "Region is deleted";
        }

        public List<RegionDTO> GetAllRegionsByName(string name)
        {
            return RegionService.GetAllByName(name);
        }




        private PlacesManagmentSercies placeService = new PlacesManagmentSercies();

        public List<PlaceDTO> GetPlaces()
        {
            return placeService.Get();
        }

        public PlaceDTO GetPlaceById(int id)
        {
            return placeService.GetById(id);
        }

        public string PostPlace(PlaceDTO PlaceDto)
        {
            if (!placeService.Save(PlaceDto))
            {
                return "Place is not inserted";
            }
            return "Place is inserted";
        }

        public string PutPlace(PlaceDTO PlaceDto)
        {
            if (!placeService.Update(PlaceDto))
            {
                return "Place is not updated";
            }
            return "Place is updated";
        }

        public string DeletePlace(int id)
        {
            if (!placeService.Delete(id))
            {
                return "Place is not deleted";
            }
            return "Place is deleted";
        }

        public List<PlaceDTO> GetAllPlacesByName(string name)
        {
            return placeService.GetAllByName(name);
        }

    }
}
