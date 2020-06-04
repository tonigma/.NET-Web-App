using MVC.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Utils
{
    public class LoadCountry
    {
        public static SelectList LoadCountrysData()
        {
            using (Service1Client service = new Service1Client())
            {
                return new SelectList(service.GetCountrys(), "Id", "Name");
            }
        }
    }
}