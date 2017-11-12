using Nlayer.Samples.ExampleNlayer.Application.MainBoundedContext.ERPModule.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomerAppService customerAppService;

        public HomeController(ICustomerAppService _customerAppService)
        {
            this.customerAppService = _customerAppService;
        }

        public ActionResult Index()
        {
            var items = customerAppService.FindCountries(0, 100);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}