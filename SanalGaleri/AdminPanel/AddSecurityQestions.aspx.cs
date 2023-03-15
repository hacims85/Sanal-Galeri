using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SanalGaleri.AdminPanel
{
    public partial class AddSecurityQestions : System.Web.UI.Page
    {
        DataModel dm=new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_addSecurityQestion_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_addSecurityQestion.Text.Trim()))
            {
                if (dm.dataControl("SecurityQestions", "Qestions",tb_addSecurityQestion.Text.Trim()))
                {
                    SecurityQestions sq=new SecurityQestions();
                    sq.Questions = tb_addSecurityQestion.Text;
                    if (dm.AddSecurityQestions(sq))
                    {
                        pnl_successful.Visible = true;
                        pnl_unsuccessful.Visible = false;
                        tb_addSecurityQestion.Text = "";
                    }
                    else
                    {
                        pnl_successful.Visible = false;
                        pnl_unsuccessful.Visible = true;
                        lbl_mesaj.Text = "Ekleme Esnasında Hata Oluştu";
                    }
                }
                else
                {
                    pnl_successful.Visible = false;
                    pnl_unsuccessful.Visible = true;
                    lbl_mesaj.Text = "Daha Önce Eklenmiş";
                }
            }
            else
            {
                pnl_successful.Visible = false;
                pnl_unsuccessful.Visible = true;
                lbl_mesaj.Text = "Alan Boş Bırakılamaz";
            }
        }
    }
}