using eStanar.Domain.Entities;
using System;

namespace eStanar.Domain.Business
{
    public class NoticeDetails
    {
        public int IdNotice { get; set; }

        public int IdNoticeType { get; set; }

        public int IdStructure { get; set; }

        public string Text { get; set; }

        public int IdAuthor { get; set; }

        public DateTime Date { get; set; }

        public int? IdEntrance { get; set; }

        public int? IdMeeting { get; set; }

        public string NoticeTypeName { get; set; }

        public string CssClass { get { return (IdNoticeType == (int)NoticeTypeEnum.GeneralNotice) ? "bg-info" : "bg-warning"; } }
    }

    public enum NoticeTypeEnum { GeneralNotice = 1, MeetingOfTenants = 2 }
}
