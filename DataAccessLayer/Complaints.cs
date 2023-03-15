using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Complaints
    {
        public int ID { get; set; }
        public string Explanation { get; set; }
        public int ComplaintReasonID { get; set; }
        public string ComplaintReason { get; set; }
        public int CommentID { get; set; }
        public string CommentContent { get; set; }
        public int ArtworkID { get; set; }
        public string ArtworkName { get; set; }
        public int MemberID { get; set; }
        public string MemberUserName { get; set; }
        public int ComplainantID { get; set; }
        public string ComplainantName { get; set; }
        public string ComplainantUserName { get; set; }
        public int AnswerStatusID { get; set; }
        public string AnswerStatusName { get; set; }
        public DateTime ComplainantDate { get; set; }
        public string ComplainantDateStr { get; set; }
        public string ComplainantTimeStr { get; set; }
        public int ApproverID { get; set; }
        public DateTime ApprovedDate { get; set; }
        public string ApprovedDateStr { get; set; }
        public string ApprovedTimeStr { get; set; }
    }
}
