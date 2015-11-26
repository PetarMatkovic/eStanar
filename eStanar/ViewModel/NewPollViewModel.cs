using eStanar.Domain.Entities;
using System.Collections.Generic;

namespace eStanar.ViewModel
{
    public class NewPollViewModel
    {
        public int? IdNotice { get; set; }
        public List<Notice> NoticeList { get; set; }
    }
}