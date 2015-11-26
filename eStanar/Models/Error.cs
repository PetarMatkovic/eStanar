using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eStanar.Models
{
    public class Error : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            Exception ex = filterContext.Exception;
            filterContext.ExceptionHandled = true;
            var model = new HandleErrorInfo(filterContext.Exception, "kontroler", "akcija");
            var viewData = new ViewDataDictionary();
            viewData.Model = model;

            filterContext.Controller.ViewData.Model = model;
            filterContext.Result = new ViewResult()
            {
                ViewName = "DisplayError",
                ViewData = viewData
            };
        }
    }
}