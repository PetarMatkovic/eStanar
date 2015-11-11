using System.Collections.Generic;
using System.Web.Mvc;
using eStanar.Domain.Abstract;
using eStanar.Domain.Business;
using eStanar.ViewModel;

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
            NoticeViewModel nvm = new NoticeViewModel();
            nvm.NoticeDetailsList = DBHelper.GetNoticeDetails(1, 1); ;

            return View(nvm);
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