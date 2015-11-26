using eStanar.Domain.Entities;
using System;

namespace eStanar.Domain.Business
{
    public class PollDetails
    {
        public int IdPoll { get; set; }

        public int? IdNotice { get; set; }

        public string NoticeText { get; set; }

        public string Title { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime? DateTo { get; set; }
    }
}
