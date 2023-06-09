﻿using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SanalGaleri.AdminPanel
{
    public partial class ComplaintsProcesses : System.Web.UI.Page
    {
        DataModel dm = new DataModel();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_comments_Click(object sender, EventArgs e)
        {
            lv_comments.DataSource = dm.ListCommendComplaintsNotAccepted(1);
            lv_comments.DataBind();
            lv_comments.Visible = true;
            lv_artworks.Visible = false;
            lv_members.Visible = false;

        }

        protected void lbtn_artworks_Click(object sender, EventArgs e)
        {
            lv_artworks.DataSource = dm.ListArtworkComplaintsNotAccepted(1);
            lv_artworks.DataBind();
            lv_comments.Visible = false;
            lv_artworks.Visible = true;
            lv_members.Visible = false;
        }

        protected void lbtn_members_Click(object sender, EventArgs e)
        {
            lv_members.DataSource = dm.ListMemberComplaintsNotAccepted(1);
            lv_members.DataBind();
            lv_comments.Visible = false;
            lv_artworks.Visible = false;
            lv_members.Visible = true;
        }

        protected void lv_comments_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            Members mem = (Members)Session["Member"];
            if (e.CommandName == "approve")
            {
                
                int comid = Convert.ToInt32(e.CommandArgument.ToString());
                Complaints com = dm.GetCommendComplaintNotAccepted(comid);
                com.ApproverID = mem.ID;
                com.ApprovedDate = DateTime.Now;
                com.AnswerStatusID = 2;
                dm.SoftDeleteAnswers(com.CommentID);
                dm.CommentsSoftDelete(com.CommentID);
                if (dm.UpdateComplaintsForAccepted(com))
                {
                    lv_comments.DataSource = dm.ListCommendComplaintsNotAccepted(1);
                    lv_comments.DataBind();
                    lv_comments.Visible = true;
                    lv_artworks.Visible = false;
                    lv_members.Visible = false;
                }
            }
            if (e.CommandName == "reject")
            {
                int comid = Convert.ToInt32(e.CommandArgument.ToString());
                Complaints com = dm.GetCommendComplaintNotAccepted(comid);
                com.ApproverID = mem.ID;
                com.ApprovedDate = DateTime.Now;
                com.AnswerStatusID = 3;
                if (dm.UpdateComplaintsForAccepted(com))
                {
                    lv_comments.DataSource = dm.ListCommendComplaintsNotAccepted(1);
                    lv_comments.DataBind();
                    lv_comments.Visible = true;
                    lv_artworks.Visible = false;
                    lv_members.Visible = false;
                }
            }
        }
    }
}