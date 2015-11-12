using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eStanar.Domain.Business
{
    public class NoticeComment
    {
        public int IdNoticeComment { get; set; }
        public int IdAuthor { get; set; }
        public string AuthorName { get; set; }
        public string AuthorLastName { get; set; }
        public string Author { get { return String.Format("{0} {1}", AuthorLastName, AuthorName); } }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public int IdNotice { get; set; }
    }
}
