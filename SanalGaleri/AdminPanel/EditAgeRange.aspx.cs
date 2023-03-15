using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SanalGaleri.AdminPanel
{
    public partial class EditAgeRange : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                if (!IsPostBack)
                {
                    int arid = Convert.ToInt32(Request.QueryString["arid"]);
                    AgeRanges ar = dm.GetAgeRange(arid);
                    if (ar != null && ar.AgeRange != null)
                    {
                        tb_addAgeRange.Text = ar.AgeRange;

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

        protected void lbtn_editAgeRange_Click(object sender, EventArgs e)
        {
            AgeRanges ar = new AgeRanges();
            ar.ID = Convert.ToInt32(Request.QueryString["arid"]);
            ar.AgeRange =Convert.ToString(tb_addAgeRange.Text);
            if (dm.dataControl("AgeRanges", "AgeRange", tb_addAgeRange.Text.Trim()))
            {
                if (dm.EditAgeRange(ar))
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