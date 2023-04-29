using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SanalGaleri.AdminPanel
{
    public partial class CommentDetails : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                int cid = Convert.ToInt32(Request.QueryString["cid"]);
                Comments c = dm.GetCommentsNotAccepted(cid);
                ltrl_ID.Text = c.ID.ToString();
                ltrl_commentArtwork.Text = c.ArtworkID.ToString();
                ltrl_answerComment.Text = c.CommentsID.ToString();
                ltrl_uploaderUserName.Text = c.WriterUserName;
                ltrl_UploadDate.Text = (c.UploadDateStr + " " + c.UploadTimeStr).ToString();
                ltrl_info.Text = c.Contents;
                if (c.CommentsID == 0)
                {
                    lbl_commentArtwork.Visible = true;
                    lbl_ansverComment.Visible = false;
                    lbl_artworkTitle.Visible = true;
                    lbl_answerTitle.Visible = false;
                }
                else
                {
                    lbl_commentArtwork.Visible = false;
                    lbl_ansverComment.Visible = true;
                    lbl_artworkTitle.Visible = false;
                    lbl_answerTitle.Visible = true;
                }

            }
            else
            {
                Response.Redirect("ApprovalProcesses.aspx");
            }

        }
    }
}