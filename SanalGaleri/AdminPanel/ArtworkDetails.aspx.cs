using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SanalGaleri.AdminPanel
{
    public partial class ArtworkDetails : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                int awid = Convert.ToInt32(Request.QueryString["awid"]);
                Artworks aw = dm.GetArtworksNotAccepted(1);
                ltrl_ID.Text = aw.ID.ToString();
                ltrl_artworkCategoriesName.Text = aw.ArtCategoryName;
                ltrl_uploaderUserName.Text = aw.UploaderUserName;
                img_coverIMG.ImageUrl = "../Images/" + "none.png";

            }
            else
            {
                Response.Redirect("ApprovalProcesses.aspx");

            }

        }
    }
}