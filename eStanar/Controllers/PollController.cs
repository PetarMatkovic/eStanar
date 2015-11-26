using eStanar.Domain.Business;
using eStanar.Domain.Entities;
using eStanar.ViewModel;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;

namespace eStanar.Controllers
{
    public class PollController : Controller
    {
        public ActionResult NewPoll()
        {
            return View();
        }

        public ActionResult InsertPoll(string text, DateTime dateFrom, DateTime? dateTo)
        {
            int? idPoll = DBHelper.InsertPoll(null, text, dateFrom, dateTo);

            if (idPoll.HasValue)
                return RedirectToAction("EditPoll", new RouteValueDictionary(new { controller = "Poll", action = "EditPoll", idPoll = idPoll.ToString() }));
            else
                return RedirectToAction("NewPoll");
        }

        public ActionResult EditPoll(int idPoll)
        {
            PollDetails pollDetails;
            List<PollOption> pollOptionList;

            DBHelper.GetPoll(idPoll, out pollDetails, out pollOptionList);

            UpdatePollViewModel upvm = new UpdatePollViewModel() { IdPoll = idPoll, PollDetails = pollDetails, PollOptionList = pollOptionList };

            return View(upvm);
        }

        public ActionResult UpdatePoll(int idPoll, string text, DateTime dateFrom, DateTime? dateTo)
        {
            if (Request["save"] != null) // u pitanju je spremanje promjena
            {
                DBHelper.UpdatePoll(idPoll, null, text, dateFrom, dateTo);

                return RedirectToAction("EditPoll", new RouteValueDictionary(new { controller = "Poll", action = "EditPoll", idPoll = idPoll.ToString() }));
            }
            else if (Request["delete"] != null) // u pitanju je brisanje ankete
            {
                DBHelper.DeletePoll(idPoll);

                return RedirectToAction("NewPoll");
            }
            else
            {
                return RedirectToAction("NewPoll");
            }
        }

        public ActionResult InsertPollOption(int? idPollOption, int idPoll, string text)
        {
            if (idPollOption.HasValue)
            {
                if (Request["save"] != null) // u pitanju je ažuriranje odgovora
                {
                    DBHelper.UpdatePollOption(idPollOption.Value, text);
                }
                else if (Request["delete"] != null) // u pitanju je brisanje odgovora
                {
                    DBHelper.DeletePollOption(idPollOption.Value);
                }
            }
            else
            {
                if (Request["save"] != null) // u pitanju je spremanje novog odgovora
                {
                    DBHelper.InsertPollOption(idPoll, text);
                }
            }

            return RedirectToAction("EditPoll", new RouteValueDictionary(new { controller = "Poll", action = "EditPoll", idPoll = idPoll.ToString() }));
        }
    }
}