using eStanar.Domain.Business;

namespace eStanar.ViewModel
{
    public class NoticeDetailsItemViewModel
    {
        public NoticeDetails NoticeDetails { get; set; }
        public bool HideMoreDetailsLink { get; set; }
        public bool DisplayBottomBorder { get; set; }
    }
}