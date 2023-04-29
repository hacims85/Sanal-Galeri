using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SanalGaleri.AdminPanel
{
    public partial class AdminMasterPage : System.Web.UI.MasterPage
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Member"] != null)
            {
                Members mem = (Members)Session["Member"];
                lbl_user.Text = mem.UserName + " (" + mem.MembershipStatusName + ")";


            }
            else
            {
                Response.Redirect("AdminLoginPage.aspx");
            }
        }

        protected void lbtn_exit_Click(object sender, EventArgs e)
        {
            Session["Member"] = null;
            Response.Redirect("AdminLoginPage.aspx");

        }
    }
}