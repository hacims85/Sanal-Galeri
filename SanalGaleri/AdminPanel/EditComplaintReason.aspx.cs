using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SanalGaleri.AdminPanel
{
    public partial class EditComplaintReason : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                if (!IsPostBack)
                {
                    int crid = Convert.ToInt32(Request.QueryString["crid"]);
                    ComplaintReasons cr = dm.GetComplaintReasons(crid);
                    if (cr != null && cr.Reason != null)
                    {
                        tb_addComplaintReason.Text = cr.Reason;
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

        protected void lbtn_addComplaintReason_Click(object sender, EventArgs e)
        {
            ComplaintReasons cr = new ComplaintReasons();
            cr.ID = Convert.ToInt32(Request.QueryString["crid"]);
            cr.Reason = tb_addComplaintReason.Text;
            if (dm.dataControl("ComplaintReasons", "Reason", tb_addComplaintReason.Text.Trim()))
            {
                if (dm.editComplaintReason(cr))
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
