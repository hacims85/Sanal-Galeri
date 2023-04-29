using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Artworks
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public int ArtCategoryID { get; set; }
        public string ArtCategoryName { get; set; }
        public int UploaderID { get; set; }
        public string UploaderName { get; set; }
        public string UploaderUserName { get; set; }
        public int ApproverID { get; set; }
        public string ApproverName { get; set; }
        public string ApproverUserName { get; set; }
        public int AgeRangeID { get; set; }
        public string AgeRangeStr { get; set; }
        public int LikeCounts { get; set; }
        public int DislikeCounts { get; set; }
        public int ViewsCounts { get; set; }
        public DateTime UploadDateTime { get; set; }
        public string UploadDateStr { get; set; }
        public string UploadTimeStr { get; set; }
        public DateTime ApprovedDateTime { get; set; }
        public string ApprovedDateStr { get; set; }
        public string ApprovedTimeStr { get; set; }
        public int AnswerStatusID { get; set; }
        public string AnswerStatusName { get; set; }

    }
}
