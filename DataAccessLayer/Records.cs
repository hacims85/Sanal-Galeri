using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Records
    {
        public int ID { get; set; }
        public int RecorderID { get; set; }
        public int Artwork_ID { get; set; }
        public DateTime RecordDate { get; set; }
        public string RecordDateStr { get; set; }
        public string RecordTimeStr { get; set; }
    }
}
