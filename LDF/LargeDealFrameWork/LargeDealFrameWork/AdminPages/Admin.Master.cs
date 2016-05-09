using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace LargeDealFrameWork.AdminPages
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["FirstName"] == null)
            {
                Response.Redirect("/Login/SignInPage.aspx");
            }
            string Username = Session["FirstName"].ToString();
            System.Globalization.TextInfo ti = new System.Globalization.CultureInfo("en-US", false).TextInfo;
            Username = ti.ToTitleCase(Username);
            userName.Text = "Welcome " + Username  ;
        }

        protected void lnkbuttonSignout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("/Login/SignInPage.aspx");
        }

        protected void Menu_MenuItemDataBound(object sender, MenuEventArgs e)
        {

        }
    }
}