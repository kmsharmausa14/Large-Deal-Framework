using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using System.Xml;
using BLL;
using BO;

namespace LargeDealFrameWork.Login
{
    public partial class SignInPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Request.QueryString["LoginResult"] != null)
            //{
            //    Login1.FailureText = "Invalid Login Id or Password.";
            //    Login1.FailureAction = LoginFailureAction.Refresh;
            //}
            Login1.FindControl("UserName").Focus();
           
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {

            // Initialize FormsAuthentication (reads the configuration and gets 
            // the cookie values and encryption keys for the given application)
            FormsAuthentication.Initialize();
            string commaSeperatedRoles = string.Empty;
           
                DataTable dtUser = new BLL.LoginBLL().validateUser(Login1.UserName, Login1.Password);

                if (dtUser != null && dtUser.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtUser.Rows)
                    {
                        if (string.IsNullOrEmpty(commaSeperatedRoles))
                        {
                            commaSeperatedRoles = dr["IRoleID"].ToString();
                        }
                        else
                        {
                            commaSeperatedRoles = commaSeperatedRoles + "," + dr["IRoleId"].ToString();
                        }

                        //commaSeperatedRoles = commaSeperatedRoles + ",";

                        Session["Designation"] = dr["IDesgnId"];
                        Session["FirstName"] = dr["vsFirstName"];
                        Session["UserID"] = dr["vspkUsrId"];
                        Session["RoleID"] = commaSeperatedRoles;
                        Session["DesignationName"] = dr["vsDesgn"];
                        Session["VertId"] = dr["vsVertId"];
                    }


                    // Create a new ticket used for authentication
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                    1, // Ticket version
                    Login1.UserName, // Username to be associated with this ticket
                    DateTime.Now, // Date/time issued
                    DateTime.Now.AddMinutes(30), // Date/time to expire
                    true, // "true" for a persistent user cookie (could be a checkbox on form)
                    Session["Designation"].ToString(),//commaSeperatedRoles, // User-data (the roles from this user record in our database)
                    FormsAuthentication.FormsCookiePath); // Path cookie is valid for

                    if (clsDesignationList.hsDesignationList == null)
                    {
                        DataSet dsDesignationDetails = new DataSet();
                        dsDesignationDetails = new BLL.HomeScreensBLL().GetDesignationDetails();
                        clsDesignationList.PopulateDesignationList(dsDesignationDetails);
                    }


                    // Hash the cookie for transport over the wire
                    string hash = FormsAuthentication.Encrypt(ticket);
                    HttpCookie cookie = new HttpCookie(
                    FormsAuthentication.FormsCookieName, // Name of auth cookie (it's the name specified in web.config)
                     hash); // Hashed ticket

                    // Add the cookie to the list for outbound response
                    Response.Cookies.Add(cookie);

                    // Redirect to requested URL, or homepage if no previous page requested
                    string returnUrl = Request.QueryString["ReturnUrl"];
                    if (returnUrl == null) returnUrl = "~/FrmHome.aspx";  //Home.aspx


                    //string returnUrl = string.Empty;// Request.QueryString["ReturnUrl"];
                    ////if (returnUrl == null)
                    ////{
                    //    returnUrl = "~/Home.aspx";  //Home.aspx
                    //}
                    // Don't call the FormsAuthentication.RedirectFromLoginPage since it could
                    // replace the authentication ticket we just added...
                    Response.Redirect(returnUrl);
                }
                else
                {
                    //Response.Redirect("~/Login/SignInPage.aspx?LoginResult=fail");
                    Login1.FailureAction = LoginFailureAction.Refresh;
                }
           
        }
    }
}

