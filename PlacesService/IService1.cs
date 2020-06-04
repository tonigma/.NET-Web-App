using ApplicationSeriveces.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PlacesService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        List<CountryDTO> GetCountrys();
        [OperationContract]
        CountryDTO GetCountryById(int id);
        [OperationContract]
        string PostCountry(CountryDTO CountryDTO);
        [OperationContract]
        string PutCountry(CountryDTO CountryDTO);
        [OperationContract]
        string DeleteCountry(int id);
        [OperationContract]
        List<CountryDTO> GetAllCountrysByName(string name);





        [OperationContract]
        List<RegionDTO> GetRegions();
        [OperationContract]
        RegionDTO GetRegionById(int id);
        [OperationContract]
        string PostRegion(RegionDTO regionDto);
        [OperationContract]
        string PutRegion(RegionDTO regionDto);
        [OperationContract]
        string DeleteRegion(int id);
        [OperationContract]
        List<RegionDTO> GetAllRegionsByName(string name);



        [OperationContract]
        List<PlaceDTO> GetPlaces();
        [OperationContract]
        PlaceDTO GetPlaceById(int id);
        [OperationContract]
        string PostPlace(PlaceDTO PlaceDTO);
        [OperationContract]
        string PutPlace(PlaceDTO PlaceDTO);
        [OperationContract]
        string DeletePlace(int id);
        [OperationContract]
        List<PlaceDTO> GetAllPlacesByName(string name);
    }
}
