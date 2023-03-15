using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SanalGaleri
{
    public partial class ApprovalProcesses : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_comments_Click(object sender, EventArgs e)
        {
            lv_comments.Visible = true;
            lv_artworks.Visible = false;
            lv_comments.DataSource = dm.ListCommentsNotAccepted(1);
            lv_comments.DataBind();

        }

        protected void lbtn_artworks_Click(object sender, EventArgs e)
        {
            lv_comments.Visible = false;
            lv_artworks.Visible = true;
            lv_artworks.DataSource = dm.ListArtworksNotAccepted(1);
            lv_artworks.DataBind();
        }

        protected void lv_comments_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "approve")
            {
                int id = Convert.ToInt32(e.CommandArgument.ToString());
                Comments c = dm.GetCommentsNotAccepted(id);
                c.ApproverID = 1;
                c.ApprovedDate = DateTime.Now;
                c.AnswerStatusID = 2;
                if (dm.UpdateComments(c))
                {
                    lv_comments.Visible = true;
                    lv_artworks.Visible = false;
                    lv_comments.DataSource = dm.ListCommentsNotAccepted(1);
                    lv_comments.DataBind();
                }
            }
            if (e.CommandName == "reject")
            {
                int cid = Convert.ToInt32(e.CommandArgument);
                Comments c = dm.GetCommentsNotAccepted(cid);
                c.ApproverID = 1;
                c.ApprovedDate = DateTime.Now;
                c.AnswerStatusID = 3;
                if (dm.UpdateComments(c))
                {
                    lv_comments.Visible = true;
                    lv_artworks.Visible = false;
                    lv_comments.DataSource = dm.ListCommentsNotAccepted(1);
                    lv_comments.DataBind();
                }
            }

        }

        protected void lv_artworks_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "approve")
            {
                int awid = Convert.ToInt32(e.CommandArgument);
                Artworks aw = dm.GetArtworksNotAccepted(awid);
                aw.ApproverID = 1;
                aw.ApprovedDateTime = DateTime.Now;
                aw.AnswerStatusID = 2;
                if (dm.UpdateArtwork(aw))
                {
                    lv_comments.Visible = false;
                    lv_artworks.Visible = true;
                    lv_artworks.DataSource = dm.ListArtworksNotAccepted(1);
                    lv_artworks.DataBind();
                }

            }
            if (e.CommandName == "reject")
            {
                int awid = Convert.ToInt32(e.CommandArgument);
                Artworks aw = dm.GetArtworksNotAccepted(awid);
                aw.ApproverID = 1;
                aw.ApprovedDateTime = DateTime.Now;
                aw.AnswerStatusID = 3;
                if (dm.UpdateArtwork(aw))
                {
                    lv_comments.Visible = false;
                    lv_artworks.Visible = true;
                    lv_artworks.DataSource = dm.ListArtworksNotAccepted(1);
                    lv_artworks.DataBind();
                }
            }
        }
    }
}