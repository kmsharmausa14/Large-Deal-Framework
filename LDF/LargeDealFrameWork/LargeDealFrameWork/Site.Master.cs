using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace LargeDealFrameWork
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Designation"] == null)
            {
                Response.Redirect("/Login/SignInPage.aspx");
            }
            string Username = Session["FirstName"].ToString();
            string DesignationName = Session["DesignationName"].ToString();

            System.Globalization.TextInfo ti = new System.Globalization.CultureInfo("en-US", false).TextInfo;
            Username = ti.ToTitleCase(Username);

            userName.Text = "Welcome " + Username + " (" + DesignationName + ")";
        }

        protected void lnkbuttonSignout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
                Session.Abandon();
            Response.Redirect("/Login/SignInPage.aspx");
        }

        protected void lnkHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("/FrmHome.aspx");
        }

        protected void lnkChangePWD_Click(object sender, EventArgs e)
        {
            Response.Redirect("/FrmChangePassword.aspx");
        }
    }
}
