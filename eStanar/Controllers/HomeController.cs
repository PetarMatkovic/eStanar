using System.Collections.Generic;
using System.Web.Mvc;
using eStanar.Domain.Abstract;
using eStanar.Domain.Entities;

namespace eStanar.Controllers
{
    public class HomeController : Controller
    {
        private IEStanarRepository repository;

        public HomeController(IEStanarRepository eStanarRepository)
        {
            this.repository = eStanarRepository;
        }

        public ActionResult Index()
        {
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