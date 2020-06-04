using MVC.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Utils
{
    public class LoadRegion
    {
        public static SelectList LoadRegionsData()
        {
            using (Service1Client service = new Service1Client())
            {
                return new SelectList(service.GetRegions(), "Id", "RegionName");
            }
        }
    }
}