using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SanalGaleri.AdminPanel
{
    public partial class CommentDetail : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                int cid = Convert.ToInt32(Request.QueryString["cid"]);
                Comments c = dm.GetCommentsNotAccepted(cid);

                if (c.CommentsID == 0)
                {
                    lbl_artworkID.Visible = true;
                    lbl_commentID.Visible = false;
                }
                else
                {
                    lbl_artworkID.Visible = false;
                    lbl_commentID.Visible = true;
                }
                ltrl_ID.Text = c.ID.ToString();
                ltrl_artworkID.Text = c.ArtworkID.ToString();
                ltrl_commentID.Text = c.CommentsID.ToString();
                ltrl_writerUserName.Text = c.WriterUserName;
                ltrl_content.Text = c.Contents;

            }
            else
            {
                Response.Redirect("ApprovalProcesses.aspx");
            }

        }
    }
}