using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SanalGaleri.AdminPanel
{
    public partial class AddComplaintReasons : System.Web.UI.Page
    {
        DataModel dm=new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_addComplaintReason_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_addComplaintReason.Text.Trim()))
            {
                if (dm.dataControl("ComplaintReasons", "Reason", tb_addComplaintReason.Text.Trim()))
                {
                    ComplaintReasons cr = new ComplaintReasons();
                    cr.Reason = tb_addComplaintReason.Text;
                    if (dm.addComplaintReason(cr))
                    {
                        pnl_successful.Visible = true;
                        pnl_unsuccessful.Visible = false;
                        tb_addComplaintReason.Text = "";
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