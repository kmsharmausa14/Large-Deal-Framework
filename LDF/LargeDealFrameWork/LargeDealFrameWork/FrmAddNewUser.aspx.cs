using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using System.Net;

namespace LargeDealFrameWork.AdminPages
{
    public partial class AddNewUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    initializeControls();
                }
                lblMessage.Text = string.Empty;
            }
            catch (System.Threading.ThreadAbortException exc)
            {
            }
            catch (Exception ex)
            {
                string _strErrorMessage = string.Format("{0}", ex.Message.ToString());

                var cleanChars = _strErrorMessage.Where(c => !"\n\r".Contains(c));
                string cleanText = new string(cleanChars.ToArray());

                Response.Redirect("/frmErrorPage.aspx?ErrorMessage=" + cleanText);
            }
        }

        void initializeControls()
        {
            try
            {
                BLL.AdminBLL objAdmin = new BLL.AdminBLL();
                DataTable dtVerticals = objAdmin.getVerticals();
                DataTable dtDesignations = objAdmin.getDesignations();
                DataTable dtLocations = objAdmin.getLocations();
                DataTable dtRoles = objAdmin.getRoles();

                ddlVertical.DataSource = dtVerticals;
                ddlVertical.DataTextField = "vsVertDesc";
                ddlVertical.DataValueField = "vspkVertId";
                ddlVertical.DataBind();
                ddlVertical.Items.Insert(0, new ListItem("Select Vertical", "0"));

                ddlDesignation.DataSource = dtDesignations;
                ddlDesignation.DataTextField = "vsDesgn";
                ddlDesignation.DataValueField = "IDesgnId";
                ddlDesignation.DataBind();
                ddlDesignation.Items.Insert(0, new ListItem("Select Designation", "0"));

                ddlLocation.DataSource = dtLocations;
                ddlLocation.DataTextField = "vsLocationName";
                ddlLocation.DataValueField = "ipkId";
                ddlLocation.DataBind();
                ddlLocation.Items.Insert(0, new ListItem("Select Location", "0"));

                txtFirstName.Text = "";
                txtMiddleName.Text = "";
                txtLastName.Text = "";
                txtEmpID.Text = "";
                txtEmailID.Text = "";
            }
            catch (Exception ex)
            {
                string _strErrorMessage = string.Format("{0}", ex.Message.ToString());

                var cleanChars = _strErrorMessage.Where(c => !"\n\r".Contains(c));
                string cleanText = new string(cleanChars.ToArray());

                Response.Redirect("/frmErrorPage.aspx?ErrorMessage=" + cleanText);
            }

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            BLL.AdminBLL objAdmin = new BLL.AdminBLL();

            try
            {
                if (txtEmailID.Text.Contains("@syntelinc.com"))
                {
                    bool isTrue = objAdmin.addNewUser(txtFirstName.Text, txtMiddleName.Text, txtLastName.Text,
                                                        txtEmpID.Text, txtEmailID.Text, Convert.ToString(ddlVertical.SelectedIndex),
                                                        ddlDesignation.SelectedIndex, ddlLocation.SelectedIndex);

                    if (isTrue)
                    {
                        lblMessage.Text = "User added successfully.";
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        SendMailToUserCreated();
                        initializeControls();
                    }
                }
                else
                {

                    lblMessage.Text = "Please enter valid Syntel emailId";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    txtEmailID.Text = string.Empty;
                }
                
            }
            catch (Exception ex)
            {
                string _strErrorMessage = string.Format("{0}", ex.Message.ToString());

                var cleanChars = _strErrorMessage.Where(c => !"\n\r".Contains(c));
                string cleanText = new string(cleanChars.ToArray());

                Response.Redirect("/frmErrorPage.aspx?ErrorMessage=" + cleanText);
            }

        }

        private void SendMailToUserCreated()
        {
            try
            {
                string _strPassword = string.Empty;
                 BLL.AdminBLL objAdmin = new BLL.AdminBLL();
                 DataTable dtGetPassword = objAdmin.getPasswordforNewUserId(txtEmpID.Text);
                 if (dtGetPassword.Rows.Count > 0)
                 {
                      _strPassword = dtGetPassword.Rows[0][0].ToString();
                 }

                string _strToEmail = txtEmailID.Text;
                var fromAddress = new MailAddress(System.Web.Configuration.WebConfigurationManager.AppSettings["EmailFrom"],
                "Large Deal Framework");
                string EmailBody = "<html><body><div style='border:1px solid black;padding:10px;font-family:arial'> Dear " + txtFirstName.Text + " " + txtLastName.Text;
                EmailBody += "</br>";
                EmailBody += "</br>";
                EmailBody += "Your UserId is " + txtEmpID.Text + " and Password is " + _strPassword + " to Login LDF.</br></br>";
                EmailBody += "To Access the LDF Application, Please Click on Link below:";
                EmailBody += "</br>";
                EmailBody += Application["LDFURL"].ToString();
                EmailBody += "</br>";
                EmailBody += "</br>";
                EmailBody += "Thanks,";
                EmailBody += "</br>";
                EmailBody += "LDF Team";
                EmailBody += "</br>";
                EmailBody += "</br>";
                EmailBody += "[Note: This is an system generated email. Please do not reply]";
                EmailBody += "</br>";
                EmailBody += "-------------------------------------------------------------- </div></body></html>";

                MailMessage myhtmlMessage = new MailMessage(fromAddress.ToString(), _strToEmail, "Automated Mail for UserId and Password", EmailBody);
               // myhtmlMessage.CC.Add("priyanka_datir@syntelinc.com");
                myhtmlMessage.IsBodyHtml = true;
                //string _strEmailServer = "cas2.syntelorg.com";

                string username = System.Web.Configuration.WebConfigurationManager.AppSettings["username"].ToString();
                string Password = System.Web.Configuration.WebConfigurationManager.AppSettings["Password"];

                string Host = System.Web.Configuration.WebConfigurationManager.AppSettings["SMTPSERVER"];
                int Port = Convert.ToInt32(System.Web.Configuration.WebConfigurationManager.AppSettings["Port"]);

                SmtpClient mysmtpclient = new SmtpClient(Host, Port);
                mysmtpclient.EnableSsl = true;
                System.Net.NetworkCredential crediantials = new NetworkCredential(username, Password);
                mysmtpclient.UseDefaultCredentials = false;
                mysmtpclient.Credentials = crediantials;
                mysmtpclient.Send(myhtmlMessage);

            }
            catch (Exception ex)
            {
                string _strErrorMessage = string.Format("{0}", ex.Message.ToString());

                var cleanChars = _strErrorMessage.Where(c => !"\n\r".Contains(c));
                string cleanText = new string(cleanChars.ToArray());

                Response.Redirect("/frmErrorPage.aspx?ErrorMessage=" + cleanText);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                lblMessage.Text = "";
                initializeControls();
            }
            catch (System.Threading.ThreadAbortException exc)
            {
            }
            catch (Exception ex)
            {
                string _strErrorMessage = string.Format("{0}", ex.Message.ToString());

                var cleanChars = _strErrorMessage.Where(c => !"\n\r".Contains(c));
                string cleanText = new string(cleanChars.ToArray());

                Response.Redirect("/frmErrorPage.aspx?ErrorMessage=" + cleanText);
            }
        }
    }
}
