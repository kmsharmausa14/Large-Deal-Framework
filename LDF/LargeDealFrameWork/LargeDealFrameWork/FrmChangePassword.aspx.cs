using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace LargeDealFrameWork
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Label1.Text = String.Empty;
                txtUserID.Text = User.Identity.Name;
            }

        }       

        

        protected void ChangePasswordPushButton_Click(object sender, EventArgs e)
        {
            DataTable dtUser = new BLL.LoginBLL().validateUser(User.Identity.Name, CurrentPassword.Text);

            try
            {
                if (dtUser != null && dtUser.Rows.Count > 0)
                {
                    bool pass = new BLL.LoginBLL().changePassword(User.Identity.Name, NewPassword.Text);

                    if (pass)
                    {
                        Label1.Text = "Password changed successfully.";
                        Label1.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        Label1.Text = "Password change failed. Please re-enter your values and try again.";
                        Label1.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {

                    Label1.Text = "Please enter valid current password.";
                    Label1.ForeColor = System.Drawing.Color.Red;
                    
                }

            }
            catch (Exception ex)
            {
                Label1.Text = "An exception occurred: " + Server.HtmlEncode(ex.Message) + ". Please re-enter your values and try again.";
            }

        }

        protected void CancelPushButton_Click(object sender, EventArgs e)
        {
            CurrentPassword.Text = String.Empty;
            NewPassword.Text = String.Empty;
            ConfirmNewPassword.Text = String.Empty;
            Label1.Text = String.Empty;
        }
    }
}