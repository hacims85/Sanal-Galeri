using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SanalGaleri.AdminPanel
{
    public partial class EditArtworkCategories : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                if (!IsPostBack)
                {
                    int acid = Convert.ToInt32(Request.QueryString["acid"]);
                    ArtCategories ac = dm.GetArtCategories(acid);
                    if (ac != null && ac.Name != null)
                    {
                        tb_addArtCategories.Text = ac.Name;
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

        protected void lbtn_addACategories_Click(object sender, EventArgs e)
        {
            ArtCategories ac = new ArtCategories();
            ac.ID = Convert.ToInt32(Request.QueryString["acid"]);
            ac.Name = tb_addArtCategories.Text;
            if (dm.dataControl("ArtCategories", "Name", tb_addArtCategories.Text.Trim()))
            {
                if (dm.ArtCategoriesNameUpdate(ac))
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