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
    public class PlaceController : Controller
    {
        [Authorize]
        public ActionResult Index(string name)
        {
            List<PlaceViewModel> PlaceVM = new List<PlaceViewModel>();
            using (Service1Client service = new Service1Client())
            {
                foreach (var item in service.GetPlaces())
                {
                    PlaceVM.Add(new PlaceViewModel(item));
                }
            }
            if (!String.IsNullOrEmpty(name))
            {
                PlaceVM.Clear();
                using (Service1Client service = new Service1Client())
                {
                    foreach (var item in service.GetAllPlacesByName(name))
                    {
                        PlaceVM.Add(new PlaceViewModel(item));
                    }
                }
                return View(PlaceVM);
            }
            return View(PlaceVM);
        }
        [Authorize]
        public ActionResult Details(int id)
        {
            PlaceViewModel PlaceVM = new PlaceViewModel();
            using (Service1Client service = new Service1Client())
            {
                var placeDto = service.GetPlaceById(id);
                PlaceVM = new PlaceViewModel(placeDto);
            }
            return View(PlaceVM);
        }
        [Authorize]
        public ActionResult Create()
        {
            using (Service1Client service = new Service1Client())
            {
                ViewBag.Regions = new SelectList(service.GetRegions(), "Id", "RegionName");
            }
            return View();
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlaceViewModel PlaceVM)
        {
            try
            {
                using (Service1Client service = new Service1Client())
                {
                    PlaceDTO placeDto = new PlaceDTO
                    {
                        Id = PlaceVM.Id,
                        Placename = PlaceVM.Placename,
                        averageAge = PlaceVM.averageAge,
                        PlaceArrival = PlaceVM.PlaceArrival,
                        RoadToPlace = PlaceVM.RoadToPlace,
                        distance = PlaceVM.distance,
                        EntryTax = PlaceVM.EntryTax,
                        RegionId = PlaceVM.Id,
                        Region = new RegionDTO
                        {
                            Id = PlaceVM.RegionId
                        }
                    };
                    service.PostPlace(placeDto);
                }
                ViewBag.Regions = LoadRegion.LoadRegionsData();
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Regions = LoadRegion.LoadRegionsData();
                return View();
            }
        }
        [Authorize]
        public ActionResult Edit(int id)
        {
            PlaceViewModel projctVM = new PlaceViewModel();
            using (Service1Client service = new Service1Client())
            {
                var placeDto = service.GetPlaceById(id);
                projctVM = new PlaceViewModel(placeDto);
            }

            ViewBag.Regions = LoadRegion.LoadRegionsData();
            return View(projctVM);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PlaceViewModel PlaceVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (Service1Client service = new Service1Client())
                    {
                        PlaceDTO placeDto = new PlaceDTO
                        {
                            Id = PlaceVM.Id,
                            Placename = PlaceVM.Placename,
                            averageAge = PlaceVM.averageAge,
                            PlaceArrival = PlaceVM.PlaceArrival,
                            RoadToPlace = PlaceVM.RoadToPlace,
                            distance = PlaceVM.distance,
                            EntryTax = PlaceVM.EntryTax,
                            RegionId = PlaceVM.Id,
                            Region = new RegionDTO
                            {
                                Id = PlaceVM.RegionId
                            }

                        };
                        service.PutPlace(placeDto);
                    }
                    ViewBag.Regions = LoadRegion.LoadRegionsData();
                    return RedirectToAction("Index");
                }
                ViewBag.Regions = LoadRegion.LoadRegionsData();
                return View();
            }
            catch
            {
                ViewBag.Regions = LoadRegion.LoadRegionsData();
                return View();
            }
        }
        [Authorize]
        public ActionResult Delete(int id)
        {
            PlaceViewModel PlaceVM = new PlaceViewModel();
            using (Service1Client service = new Service1Client())
            {
                service.DeletePlace(id);
            }
            return RedirectToAction("Index");
        }
    }
}