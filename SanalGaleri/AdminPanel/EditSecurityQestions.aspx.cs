using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SanalGaleri.AdminPanel
{
    public partial class EditSecurityQestions : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                if (!IsPostBack)
                {
                    int sqid = Convert.ToInt32(Request.QueryString["sqid"]);
                    SecurityQestions sq = dm.GetSecurityQestion(sqid);
                    if (sq != null && sq.Questions != null)
                    {
                        tb_addSecurityQestion.Text = sq.Questions;
                    }
                    else
                    {
                        Response.Redirect("EditProcesses.aspx");
                    }
                }
            }
            else
            {
                Response.Redirect("EditProcesses.aspx");
            }
        }

        protected void lbtn_editSecurityQestion_Click(object sender, EventArgs e)
        {
            SecurityQestions sq = new SecurityQestions();
            sq.ID = Convert.ToInt32(Request.QueryString["sqid"]);
            sq.Questions = tb_addSecurityQestion.Text;
            if (dm.dataControl("SecurityQestions", "Qestions", tb_addSecurityQestion.Text.Trim()))
            {
                if (dm.EditSecurityQestion(sq))
                {
                    pnl_successful.Visible = true;
                    pnl_unsuccessful.Visible = false;
                }
                else
                {
                    pnl_successful.Visible = false;
                    pnl_unsuccessful.Visible = true;
                    lbl_mesaj.Text = "Güncelleme İşlemi Başarısız";
                }
            }
            else
            {
                pnl_successful.Visible = false;
                pnl_unsuccessful.Visible = true;
                lbl_mesaj.Text = "Giriş Zaten Kullanımda";
            }
        }
    }
}