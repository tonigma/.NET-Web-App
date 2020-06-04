using ApplicationSeriveces.DTOs;
using MVC.Models;
using MVC.ServiceReference1;
using MVC.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class RegionController : Controller
    {
        [Authorize]
        public ActionResult Index(string name)
        {
            List<RegionViewModel> RegionVM = new List<RegionViewModel>();
            using (Service1Client service = new Service1Client())
            {
                foreach (var item in service.GetRegions())
                {
                    RegionVM.Add(new RegionViewModel(item));
                }
            }
            if (!String.IsNullOrEmpty(name))
            {
                RegionVM.Clear();
                using (Service1Client service = new Service1Client())
                {
                    foreach (var item in service.GetAllRegionsByName(name))
                    {
                        RegionVM.Add(new RegionViewModel(item));
                    }
                }
                return View(RegionVM);
            }

            return View(RegionVM);
        }
        [Authorize]
        public ActionResult Details(int id)
        {
            RegionViewModel RegionVM = new RegionViewModel();
            using (Service1Client service = new Service1Client())
            {
                var RegionDTO = service.GetRegionById(id);
                RegionVM = new RegionViewModel(RegionDTO);
            }
            return View(RegionVM);
        }
        [Authorize]
        public ActionResult Create()
        {
            using (Service1Client service = new Service1Client())
            {
                ViewBag.Country = new SelectList(service.GetCountrys(), "Id", "Name");
            }
            return View();
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RegionViewModel RegionVM)
        {
            try
            {
                using (Service1Client service = new Service1Client())
                {
                    RegionDTO RegionDTO = new RegionDTO
                    {
                        Id = RegionVM.Id,
                        RegionName = RegionVM.RegionName,
                        RegionLanguage = RegionVM.RegionLanguage,
                        RegionPopulation = RegionVM.RegionPopulation,
                        Landmark = RegionVM.Landmark,
                        RegionPriceOfWaterBottle = RegionVM.RegionPriceOfWaterBottle,
                        RegionArrival = RegionVM.RegionArrival,
                        CountryId = RegionVM.CountryId,
                        country = new CountryDTO
                        {
                            Id = RegionVM.CountryId
                        }
                    };
                    service.PostRegion(RegionDTO);
                }
                ViewBag.Country = LoadCountry.LoadCountrysData();
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Country = LoadCountry.LoadCountrysData();
                return View();
            }
        }
        [Authorize]
        public ActionResult Edit(int id)
        {
            RegionViewModel projctVM = new RegionViewModel();
            using (Service1Client service = new Service1Client())
            {
                var RegionDTO = service.GetRegionById(id);
                projctVM = new RegionViewModel(RegionDTO);
            }

            ViewBag.Country = LoadCountry.LoadCountrysData();
            return View(projctVM);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RegionViewModel RegionVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (Service1Client service = new Service1Client())
                    {
                        RegionDTO RegionDTO = new RegionDTO
                        {
                            Id = RegionVM.Id,
                            RegionName = RegionVM.RegionName,
                            RegionLanguage = RegionVM.RegionLanguage,
                            RegionPopulation = RegionVM.RegionPopulation,
                            Landmark = RegionVM.Landmark,
                            RegionPriceOfWaterBottle = RegionVM.RegionPriceOfWaterBottle,
                            RegionArrival = RegionVM.RegionArrival,
                            CountryId = RegionVM.CountryId,
                            country = new CountryDTO
                            {
                                Id = RegionVM.CountryId
                            }

                        };
                        service.PutRegion(RegionDTO);
                    }
                    ViewBag.Country = LoadCountry.LoadCountrysData();
                    return RedirectToAction("Index");
                }
                ViewBag.Country = LoadCountry.LoadCountrysData();
                return View();
            }
            catch
            {
                ViewBag.Country = LoadCountry.LoadCountrysData();
                return View();
            }
        }
        [Authorize]
        public ActionResult Delete(int id)
        {
            RegionViewModel RegionVM = new RegionViewModel();
            using (Service1Client service = new Service1Client())
            {
                service.DeleteRegion(id);
            }
            return RedirectToAction("Index");
        }
    }
}