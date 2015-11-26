using eStanar.Domain.Business;
using eStanar.Domain.Entities;
using System.Collections.Generic;

namespace eStanar.ViewModel
{
    public class UpdatePollViewModel
    {
        public int? IdPoll { get; set; }
        public int? IdPollOption { get; set; }
        public int? IdNotice { get; set; }
        public PollDetails PollDetails { get; set; }
        public List<Notice> NoticeList { get; set; }
        public List<PollOption> PollOptionList { get; set; }
    }
}