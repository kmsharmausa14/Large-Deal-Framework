using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LargeDealFrameWork.Login
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMessage.Visible = false;
                lblMessage.Text = "";
            }
        }        

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            bool pass = new BLL.LoginBLL().resetPassword(txtUserName.Text);
            if (pass)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Your password is reset successfully";
                lblMessage.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "User ID not found";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Login/SignInPage.aspx");
        }
    }
}