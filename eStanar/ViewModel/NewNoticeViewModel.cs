using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eStanar.Domain.Business;

namespace eStanar.ViewModel
{
    public class NewNoticeViewModel
    {
        public List<NoticeType> NoticeTypeList { get; set; }
        public int IdStructure { get; set; }
    }
}