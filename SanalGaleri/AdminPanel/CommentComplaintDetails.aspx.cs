using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SanalGaleri.AdminPanel
{
    public partial class CommentComplaintDetails : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                int comid = Convert.ToInt32(Request.QueryString["comid"]);
                Complaints com = dm.GetCommendComplaintNotAccepted(comid);
                Comments c = dm.GetCommentsNotAccepted(com.CommentID);
                ltrl_ID.Text = com.ID.ToString();
                ltrl_commentID.Text = com.CommentID.ToString();
                ltrl_conplainantUserName.Text = com.ComplainantUserName;
                ltrl_conplainantDate.Text = (com.ComplainantDateStr + " " + com.ComplainantTimeStr);
                ltrl_complaintReason.Text = com.ComplaintReason;
                ltrl_explanation.Text = com.Explanation;
                if (c.CommentsID == 0)
                {
                    lbl_commentTitle.Visible = true;
                    lbl_answerTitle.Visible = false;
                    lbl_commentComplaint.Visible = true;
                    lbl_ansverComplaint.Visible = false;
                }
                else
                {
                    lbl_commentTitle.Visible = false;
                    lbl_answerTitle.Visible = true;
                    lbl_commentComplaint.Visible = false;
                    lbl_ansverComplaint.Visible = true;
                }
            }
            else
            {
                Response.Redirect("ComplaintsProcesses.aspx");
            }
        }
    }
}