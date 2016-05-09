using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LargeDealFrameWork
{
    public partial class Mainworkpages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["TotalScoreScreen1"] != null)
            {
                h1.Value = Request.QueryString["TotalScoreScreen1"];
                Session["totalScoreScreen1"] = h1.Value;
                //this.FindControl("");
                //Qualification qs = new Qualification();
                //l1.HRef = "Qualification.aspx";
                
                
                
               
            }
            if (Request.QueryString["TotalScoreScreen2"] != null)
            {
                h2.Value = Request.QueryString["TotalScoreScreen2"];
                Session["totalScoreScreen2"] = h2.Value;
            }

        }
        protected void homeSale_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("HomeScreenforSale.aspx");
        }
    }
}