using DataAccessLayer;
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
            lv_artworks.DataSource=dm.ListArtworkComplaintsNotAccepted(1);
            lv_artworks.DataBind();
            lv_comments.Visible = false;
            lv_artworks.Visible = true;
            lv_members.Visible = false;
        }

        protected void lbtn_members_Click(object sender, EventArgs e)
        {
            lv_members.DataSource=dm.ListMemberComplaintsNotAccepted(1);
            lv_members.DataBind();
            lv_comments.Visible = false;
            lv_artworks.Visible = false;
            lv_members.Visible = true;
        }
    }
}