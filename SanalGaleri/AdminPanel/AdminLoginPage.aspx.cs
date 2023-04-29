using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SanalGaleri.AdminPanel
{
    public partial class AdminLoginPage : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_loginBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_mail.Text) && !string.IsNullOrEmpty(tb_password.Text))
            {
                Members mem = dm.AdminLogin(tb_mail.Text, tb_password.Text);
                if (mem != null)
                {
                    if (mem.MembershipStatusID == 1 || mem.MembershipStatusID == 2)
                    {
                        if (mem.UserStatus)
                        {
                            Session["Member"] = mem;
                            Response.Redirect("Default.aspx");
                        }
                        else
                        {
                            pnl_mistake.Visible = true;
                            lbl_mistake.Text = "Hesap Aktif Değil";
                        }

                    }
                    else
                    {
                        pnl_mistake.Visible = true;
                        lbl_mistake.Text = "Giriş Yetkiniz Bulunmuyor";
                    }
                }
                else
                {
                    pnl_mistake.Visible = true;
                    lbl_mistake.Text = "Kullanıcı Bulunamadı";
                }




            }

        }
    }
}