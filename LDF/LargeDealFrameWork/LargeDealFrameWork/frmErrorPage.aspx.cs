using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace LargeDealFrameWork
{
    public partial class frmErrorPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Username = Session["FirstName"].ToString();
            string DesignationName = Session["DesignationName"].ToString();

            userName.Text = "Welcome " + Username + "(" + DesignationName + ")";

            if (Request.QueryString["ErrorMessage"] != null)
            {
                lblExceptionMessage.Text = Request.QueryString["ErrorMessage"].ToString();
            }
        }

        protected void lnkbuttonSignout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("/Login/SignInPage.aspx");
        }

        protected void lnkHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmHome.aspx");
        }
        

    }
}
