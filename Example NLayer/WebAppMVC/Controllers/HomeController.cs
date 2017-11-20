using Application.Main.ERPModule.Services;
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
            //Example
            var items = customerAppService.FindCountries(0, 100);
            var countries = customerAppService.GetAll();

            return View();
        }
    }
}