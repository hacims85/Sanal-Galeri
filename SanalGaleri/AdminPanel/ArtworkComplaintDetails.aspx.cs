using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SanalGaleri.AdminPanel
{
    public partial class ArtworkComplaintDetails : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                int comid = Convert.ToInt32(Request.QueryString["comid"]);
                Complaints com = dm.GetArtworkComplaintNotAccepted(comid);
                ltrl_ID.Text = com.ID.ToString();
                ltrl_artworkID.Text = com.ArtworkID.ToString();
                ltrl_conplainantUserName.Text = com.ComplainantUserName;
                ltrl_conplainantDate.Text = (com.ComplainantDateStr + " " + com.ComplainantTimeStr);
                ltrl_complaintReason.Text = com.ComplaintReason;
                ltrl_explanation.Text = com.Explanation;
            }
            else
            {
                Response.Redirect("ComplaintsProcesses.aspx");
            }


        }
    }
}