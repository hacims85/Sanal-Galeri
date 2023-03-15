using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SanalGaleri.AdminPanel
{
    public partial class EditProcesses : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_complaintReasons_Click(object sender, EventArgs e)
        {
            lv_complaintReasons.DataSource = dm.ListComplaintReason();
            lv_complaintReasons.DataBind();
            lv_complaintReasons.Visible = true;
            lbtn_addComplaintReason.Visible = true;
            lv_artCategories.Visible = false;
            lbtn_addArtCategory.Visible = false;
            lv_securityQestions.Visible = false;
            lbtn_addsecurityQestions.Visible = false;
            lbtn_addsecurityQestions.Visible = false;
            lv_ageRanges.Visible = false;
            lbtn_addageRanges.Visible = false;
        }

        protected void lbtn_artworksCategories_Click(object sender, EventArgs e)
        {
            lv_artCategories.DataSource = dm.ListArtCategories();
            lv_artCategories.DataBind();
            lv_complaintReasons.Visible = false;
            lbtn_addComplaintReason.Visible = false;
            lv_artCategories.Visible = true;
            lbtn_addArtCategory.Visible = true;
            lv_securityQestions.Visible = false;
            lbtn_addsecurityQestions.Visible = false;
            lv_ageRanges.Visible = false;
            lbtn_addageRanges.Visible = false;
        }

        protected void lbtn_SeurityQestions_Click(object sender, EventArgs e)
        {
            lv_securityQestions.DataSource = dm.ListSecurityQestions();
            lv_securityQestions.DataBind();
            lv_complaintReasons.Visible = false;
            lbtn_addComplaintReason.Visible = false;
            lv_artCategories.Visible = false;
            lbtn_addArtCategory.Visible = false;
            lv_securityQestions.Visible = true;
            lbtn_addsecurityQestions.Visible = true;
            lv_ageRanges.Visible = false;
            lbtn_addageRanges.Visible = false;
        }

        protected void lbtn_ageRanges_Click(object sender, EventArgs e)
        {
            lv_ageRanges.DataSource = dm.ListAgeRanges();
            lv_ageRanges.DataBind();
            lv_complaintReasons.Visible = false;
            lbtn_addComplaintReason.Visible = false;
            lv_artCategories.Visible = false;
            lbtn_addArtCategory.Visible = false;
            lv_securityQestions.Visible = false;
            lbtn_addsecurityQestions.Visible = false;
            lv_ageRanges.Visible = true;
            lbtn_addageRanges.Visible = true;
        }

        protected void lbtn_addComplaintReason_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddComplaintReasons.aspx");
        }

        protected void lv_complaintReasons_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "remove")
            {
                int crid = Convert.ToInt32(e.CommandArgument);
                dm.deleteComplaintReason(crid);

            }

            lv_complaintReasons.DataSource = dm.ListComplaintReason();
            lv_complaintReasons.DataBind();
            lv_complaintReasons.Visible = true;
            lbtn_addComplaintReason.Visible = true;
            lv_artCategories.Visible = false;
            lbtn_addArtCategory.Visible = false;
            lv_securityQestions.Visible = false;
            lbtn_addsecurityQestions.Visible = false;
            lbtn_addsecurityQestions.Visible = false;
            lv_ageRanges.Visible = false;
            lbtn_addageRanges.Visible = false;

        }

        protected void lbtn_addArtCategory_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddArtCategories.aspx");
        }

        protected void lv_artCategories_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "changestatus")
            {
                int acid = Convert.ToInt32(e.CommandArgument);
                ArtCategories ac = dm.GetArtCategories(acid);
                if (ac.ArtCategoriesStatus == true)
                {
                    if (dm.DisableArtCategories(acid))
                    {
                        lv_artCategories.DataSource = dm.ListArtCategories();
                        lv_artCategories.DataBind();
                        lv_complaintReasons.Visible = false;
                        lbtn_addComplaintReason.Visible = false;
                        lv_artCategories.Visible = true;
                        lbtn_addArtCategory.Visible = true;
                        lv_securityQestions.Visible = false;
                        lbtn_addsecurityQestions.Visible = false;
                        lv_ageRanges.Visible = false;
                        lbtn_addageRanges.Visible = false;
                    }
                }
                else
                {
                    if (dm.ActivateArtCategories(acid))
                    {
                        lv_artCategories.DataSource = dm.ListArtCategories();
                        lv_artCategories.DataBind();
                        lv_complaintReasons.Visible = false;
                        lbtn_addComplaintReason.Visible = false;
                        lv_artCategories.Visible = true;
                        lbtn_addArtCategory.Visible = true;
                        lv_securityQestions.Visible = false;
                        lbtn_addsecurityQestions.Visible = false;
                        lv_ageRanges.Visible = false;
                        lbtn_addageRanges.Visible = false;
                    }
                }
            }
            if (e.CommandName == "remove")
            {
                int acid = Convert.ToInt32(e.CommandArgument);
                dm.DeleteArtCategories(acid);
                lv_artCategories.DataSource = dm.ListArtCategories();
                lv_artCategories.DataBind();
                lv_complaintReasons.Visible = false;
                lbtn_addComplaintReason.Visible = false;
                lv_artCategories.Visible = true;
                lbtn_addArtCategory.Visible = true;
                lv_securityQestions.Visible = false;
                lbtn_addsecurityQestions.Visible = false;
                lv_ageRanges.Visible = false;
                lbtn_addageRanges.Visible = false;
            }
        }

        protected void lbtn_addsecurityQestions_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddSecurityQestions.aspx");
        }

        protected void lv_securityQestions_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "remove")
            {
                int sqid = Convert.ToInt32(e.CommandArgument);
                dm.DeleteSecurityQestion(sqid);
                lv_securityQestions.DataSource = dm.ListSecurityQestions();
                lv_securityQestions.DataBind();
                lv_complaintReasons.Visible = false;
                lbtn_addComplaintReason.Visible = false;
                lv_artCategories.Visible = false;
                lbtn_addArtCategory.Visible = false;
                lv_securityQestions.Visible = true;
                lbtn_addsecurityQestions.Visible = true;
                lv_ageRanges.Visible = false;
                lbtn_addageRanges.Visible = false;
            }
        }

        protected void lbtn_addageRanges_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddAgeRange.aspx");
        }

        protected void lv_ageRanges_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "remove")
            {
                int arid = Convert.ToInt32(e.CommandArgument);
                dm.DeleteAgeRange(arid);
                lv_ageRanges.DataSource = dm.ListAgeRanges();
                lv_ageRanges.DataBind();
                lv_complaintReasons.Visible = false;
                lbtn_addComplaintReason.Visible = false;
                lv_artCategories.Visible = false;
                lbtn_addArtCategory.Visible = false;
                lv_securityQestions.Visible = false;
                lbtn_addsecurityQestions.Visible = false;
                lv_ageRanges.Visible = true;
                lbtn_addageRanges.Visible = true;
            }
        }
    }
}
