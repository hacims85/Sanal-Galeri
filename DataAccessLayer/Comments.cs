using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Comments
    {
        public int ID { get; set; }
        public string Contents { get; set; }
        public int ArtworkID { get; set; }
        public string ArtworkName { get; set; }
        public int WriterID { get; set; }
        public string WriterName { get; set; }
        public string WriterUserName { get; set; }
        public int CommentsID { get; set; }
        public int LikeCounts { get; set; }
        public int DislikeCounts { get; set; }
        public int ViewsCounts { get; set; }
        public DateTime UploadDate { get; set; }
        public string UploadDateStr { get; set; }
        public string UploadTimeStr { get; set; }
        public int ApproverID { get; set; }
        public string ApproverName { get; set; }
        public string ApproverUserName { get; set; }
        public DateTime ApprovedDate { get; set; }
        public string ApprovedDateStr { get; set; }
        public string ApprovedTimeStr { get; set; }
        public int AnswerStatusID { get; set; }
        public string AnswerStatusName { get; set; }
    }
}