using eStanar.Domain.Business;
using eStanar.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eStanar.Controllers
{
    public class NoticeController : Controller
    {
        // GET: Notice
        public ActionResult Index()
        {
            NoticeViewModel nvm = new NoticeViewModel();
            nvm.NoticeDetailsList = DBHelper.GetNoticeDetails(1, 1);
            return View(nvm);
        }

        public ActionResult NoticeDetails(int? idNotice)
        {
            NoticeDetailsViewModel ndvm = new NoticeDetailsViewModel();
            if (idNotice.HasValue)
            {
                List<NoticeComment> comments = new List<NoticeComment>();
                NoticeDetails nDet = new NoticeDetails();
                DBHelper.GetNoticeById(idNotice.Value, ref nDet, ref comments );
                ndvm.Notice = nDet;
                ndvm.NoticeComments = comments;
            }
            return View(ndvm);
        }

        public ActionResult InsertComment(string text, int idNotice)
        {
            //Iz sessiona dohvatit usera koji pise komentar
            DBHelper.InsertNoticeComment(idNotice, text, 2);
            return RedirectToAction("NoticeDetails", new { idNotice = idNotice });
        }

        public ActionResult NewNotice()
        {
            //PROVJERITI AUTORIZACIJE korisnika iz sessiona?!
            return View();
        }
    }
}