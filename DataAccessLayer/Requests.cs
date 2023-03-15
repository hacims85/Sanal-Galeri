using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Requests
    {
        public int ID { get; set; }
        public string Summary { get; set; }
        public string RequestContents { get; set; }
        public int MemberID { get; set; }
        public DateTime RequestDate { get; set; }
        public string RequestDateStr { get; set; }
        public string RequestTimeStr { get; set; }
        public string MemberName { get; set; }
        public string MemberUserName { get; set; }
        public int ReaderID { get; set; }
        public string ReaderName { get; set; }
        public string ReaderUserName { get; set; }
        public DateTime ReadingDate { get; set; }
        public string ReadingDateStr { get; set; }
        public string ReadingTimeStr { get; set; }
        public bool ReadStatus { get; set; }
        public string ReadStatusStr { get; set; }
    }
}
