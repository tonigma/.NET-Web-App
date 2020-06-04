using ApplicationSeriveces.DTOs;
using MVC.Models;
using MVC.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class CountryController : Controller
    {
        [Authorize]
        public ActionResult Index(string name)
        {
            List<CountryViewModels> countryVM = new List<CountryViewModels>();
            using (Service1Client service = new Service1Client())
            {
                foreach (var item in service.GetCountrys())
                {
                    countryVM.Add(new CountryViewModels(item));
                }
            }
            if (!String.IsNullOrEmpty(name))
            {
                countryVM.Clear();
                using (Service1Client service = new Service1Client())
                {
                    foreach (var item in service.GetAllCountrysByName(name))
                    {
                        countryVM.Add(new CountryViewModels(item));
                    }
                }
                return View(countryVM);
            }

            return View(countryVM);
        }

        [Authorize]
        public ActionResult Details(int id)
        {
            CountryViewModels countryVM = new CountryViewModels();
            using (Service1Client service = new Service1Client())
            {
                var CountryDTO = service.GetCountryById(id);
                countryVM = new CountryViewModels(CountryDTO);
            }

            return View(countryVM);
        }
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(CountryViewModels countryVM)
        {
            using (Service1Client service = new Service1Client())
            {
                CountryDTO CountryDTO = new CountryDTO
                {

                    Name = countryVM.Name,
                    Language = countryVM.Language,
                    Capital = countryVM.Capital,
                    Population = countryVM.Population,
                    PriceOfWaterBottle = countryVM.PriceOfWaterBottle,
                    Arrival = countryVM.Arrival
                };
                service.PostCountry(CountryDTO);
            }


            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            CountryViewModels countryVM = new CountryViewModels();
            using (Service1Client service = new Service1Client())
            {
                var CountryDTO = service.GetCountryById(id);
                countryVM = new CountryViewModels(CountryDTO);
            }

            return View(countryVM);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(CountryViewModels countryVM)
        {
            if (ModelState.IsValid)
            {
                using (Service1Client service = new Service1Client())
                {
                    CountryDTO CountryDTO = new CountryDTO
                    {
                        Id = countryVM.Id,
                        Name = countryVM.Name,
                        Language = countryVM.Language,
                        Capital = countryVM.Capital,
                        Population = countryVM.Population,
                        PriceOfWaterBottle = countryVM.PriceOfWaterBottle,
                        Arrival = countryVM.Arrival
                    };
                    service.PutCountry(CountryDTO);
                }
            }

            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            CountryViewModels countryVM = new CountryViewModels();
            using (Service1Client service = new Service1Client())
            {
                service.DeleteCountry(id);
            }
            return RedirectToAction("Index");
        }
    }
}