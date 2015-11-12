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

        public string AuthorName { get; set; }

        public string AuthorLastName { get; set; }

        public string Auhor { get { return String.Format("{0} {1}", AuthorLastName, AuthorName); } }
    }

    public enum NoticeTypeEnum { GeneralNotice = 1, MeetingOfTenants = 2 }
}
