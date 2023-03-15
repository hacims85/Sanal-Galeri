using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SanalGaleri.AdminPanel
{
    public partial class Requests : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_request.DataSource = dm.ListRequestsUnread(0);
            lv_request.DataBind();


        }
    }
}