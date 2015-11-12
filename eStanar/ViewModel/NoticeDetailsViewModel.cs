using eStanar.Domain.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eStanar.ViewModel
{
    public class NoticeDetailsViewModel
    {
        public NoticeDetails Notice { get; set; }
        public List<NoticeComment> NoticeComments { get; set; }
    }
}