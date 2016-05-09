using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BO;
using System.Collections;
using BLL;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.Threading;

namespace LargeDealFrameWork
{
    public partial class HomeScreenforSale : System.Web.UI.Page
    {
        int desinationId = 0;
        string userId = string.Empty;
        int counterforenableSubmitbtn = 0;

        #region Page load

        protected void Page_Load(object sender, EventArgs e)
        {
            lblClosedNoRecords.Text = string.Empty;
            lblOpenNoRecords.Text = string.Empty;
            this.HiddenField1.Value = GetCurrentDate();

            if (Session["UserID"] == null)
            {
                Response.Redirect("/Login/SignInPage.aspx");
            }
            else
            {
                userId = (string)Session["UserID"];
            }
            if (Session["Designation"] != null)
            {
                desinationId = (int)Session["Designation"];
            }

            if (!Page.IsPostBack)
            {
                try
                {
                    loadOpenOpportunity();
                    loadClosedOpportunity();
                    GetCountOpportunity();
                    checkpostback.Value = "1";
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
            if (IsPostBack)
            {
                checkpostback.Value = "0";
            }

        }

        #endregion

        #region Private methods

        private void loadOpenOpportunity()
        {
                string UserId = (string)Session["UserID"];
                int designationId = (int)Session["Designation"];
                DataSet Opportunity_details = new BLL.HomeScreensBLL().Get_OpportunityDetails(UserId, designationId);
                if (Opportunity_details.Tables[0].Rows.Count == 0)
                {
                    lblOpenNoRecords.Text = "No Records Found!!!";
                    ButtonDate.Visible = false;
                    gvOpenOpportunities.DataSource = null;
                    gvOpenOpportunities.DataBind();
                }
                populateDropDowns();
                DataTable dt_openopp = new DataTable();
                dt_openopp.Columns.Add("opportnumber");
                dt_openopp.Columns.Add("opportdesc");
                dt_openopp.Columns.Add("startdate");
                dt_openopp.Columns.Add("submissiondate");
                dt_openopp.Columns.Add("status Sales_DH");
                dt_openopp.Columns.Add("status Sales_VPSH");
                dt_openopp.Columns.Add("status Sales_GPTM");
                int count = Opportunity_details.Tables[0].Rows.Count;
                for (int i = 0; i <= count - 1; i++)
                {
                    if (Convert.ToBoolean(Opportunity_details.Tables[0].Rows[i].ItemArray[4].ToString()) == false)
                    {
                        DataRow dr = dt_openopp.NewRow();
                        dr["opportnumber"] = Opportunity_details.Tables[0].Rows[i].ItemArray[0].ToString();
                        dr["opportdesc"] = Opportunity_details.Tables[0].Rows[i].ItemArray[5].ToString();
                        string oppId = Opportunity_details.Tables[0].Rows[i].ItemArray[0].ToString();
                        dr["startdate"] = Opportunity_details.Tables[0].Rows[i].ItemArray[2].ToString();
                        if (Opportunity_details.Tables[0].Rows[i].ItemArray[3].ToString() != null)
                        {
                            dr["submissiondate"] = Opportunity_details.Tables[0].Rows[i].ItemArray[3].ToString();
                        }
                        DataTable ds = new BLL.Assign().getSalesPrimarySecondaryContact(oppId);

                        if (ds.Rows.Count > 0)
                        {
                            if (ds.Rows[0][0].ToString() == "Assigned")
                            {
                                dr["status Sales_DH"] = "Reassign";
                                ViewState["UnassignStatus"] = dr["status Sales_DH"];
                            }
                            else
                            {
                                dr["status Sales_DH"] = "Assign";
                            }
                        }
                        else
                        {
                            dr["status Sales_DH"] = "Assign";
                        }

                        if (ds.Rows.Count > 0)
                        {
                            if (ds.Rows[0][1].ToString() == "Assigned")
                            {
                                dr["status Sales_VPSH"] = "Reassign";
                                ViewState["UnassignStatus"] = dr["status Sales_VPSH"];
                            }
                            else
                            {
                                dr["status Sales_VPSH"] = "Assign";
                            }
                        }
                        else
                        {
                            dr["status Sales_VPSH"] = "Assign";
                        }

                        if (ds.Rows.Count > 0)
                        {
                            if (ds.Rows[0][2].ToString() == "Assigned")
                            {
                                dr["status Sales_GPTM"] = "Reassign";
                                ViewState["UnassignStatus"] = dr["status Sales_GPTM"];
                            }
                            else
                            {
                                dr["status Sales_GPTM"] = "Assign";
                            }
                        }
                        else
                        {
                            dr["status Sales_GPTM"] = "Assign";
                        }
                        dt_openopp.Rows.Add(dr);
                    }
                }


                gvOpenOpportunities.DataSource = dt_openopp;
                ViewState["dt_openopp"] = dt_openopp;
                gvOpenOpportunities.DataBind();

        }
        private void loadClosedOpportunity()
        {
            DataTable dt_closedopp = new DataTable();
            dt_closedopp.Columns.Add("opportnumber");
            dt_closedopp.Columns.Add("opportdesc");
            dt_closedopp.Columns.Add("startdate");
            dt_closedopp.Columns.Add("submissiondate");
            dt_closedopp.Columns.Add("status");
            dt_closedopp.Columns.Add("closeddate");
            DataSet TopMangmtClosedOpportunity_details = new BLL.HomeScreensBLL().Get_SaleClosedOpportunityDetails(userId, desinationId);

            int countclosed = TopMangmtClosedOpportunity_details.Tables[0].Rows.Count;
            if (countclosed == 0)
            {
                lblClosedNoRecords.Text = "No Records found!!!";
                gvCloseOpportunities.DataSource = null;
                gvCloseOpportunities.DataBind();
                btnSubmit.Visible = false;
            }
            for (int i = 0; i <= countclosed - 1; i++)
            {
                //if (Convert.ToBoolean(Opportunity_details.Tables[0].Rows[i].ItemArray[4].ToString()) == true)
                //{
                DataRow dr = dt_closedopp.NewRow();

                dr["opportnumber"] = TopMangmtClosedOpportunity_details.Tables[0].Rows[i].ItemArray[0].ToString();
                dr["startdate"] = TopMangmtClosedOpportunity_details.Tables[0].Rows[i].ItemArray[3].ToString();
                dr["submissiondate"] = TopMangmtClosedOpportunity_details.Tables[0].Rows[i].ItemArray[4].ToString();
                dr["opportdesc"] = TopMangmtClosedOpportunity_details.Tables[0].Rows[i].ItemArray[1].ToString();
                dr["status"] = TopMangmtClosedOpportunity_details.Tables[0].Rows[i].ItemArray[2].ToString();
                dr["closeddate"] = TopMangmtClosedOpportunity_details.Tables[0].Rows[i].ItemArray[5].ToString();
                dt_closedopp.Rows.Add(dr);
                //}
            }
            //dt_closedopp.Rows.Add("1", "OPP101", "Coupa", "Select");
            gvCloseOpportunities.DataSource = dt_closedopp;
            gvCloseOpportunities.DataBind();


            //Close Opportunity
            //DataSet dsPopulateCloseOpportunity = new BLL.HomeScreensBLL().getClosedOpportunity(UserId);
            gvCloseOpportunities.DataSource = TopMangmtClosedOpportunity_details;
            gvCloseOpportunities.DataBind();
            


            if (TopMangmtClosedOpportunity_details.Tables[0].Rows.Count == 0)
            {
                btnSubmit.Visible = false;
            }
            else
            {
                btnSubmit.Visible = true;
            }

            if (TopMangmtClosedOpportunity_details.Tables[0].Rows.Count > 0 && TopMangmtClosedOpportunity_details.Tables[0] != null)
            {
                if (TopMangmtClosedOpportunity_details.Tables[0].Rows[0][2].ToString().Trim() == "No Go")
                {
                    btnSubmit.Visible = false;
                }
            }
            foreach (GridViewRow gvrw in this.gvCloseOpportunities.Rows)
            {
                DropDownList ddlstatus = (DropDownList)gvrw.FindControl("ddlstatus");
                if (ddlstatus.Enabled == true)
                {
                    this.btnSubmit.Visible = true;
                }

            }
        }
        private DataSet GetCountOpportunity()
        {
            DataSet dsGetCount = new BLL.HomeScreensBLL().GetCountOpenLargeNonLargeDealOpportunity(userId, desinationId.ToString());
            if (dsGetCount.Tables.Count > 0)
            {
                if (dsGetCount.Tables[0].Rows.Count > 0)
                {
                    lblOpenCount.Text = "(" + dsGetCount.Tables[0].Rows[0][1].ToString() + ")";
                    lblCloseCount.Text = "(" + dsGetCount.Tables[0].Rows[0][2].ToString() + ")";
                    lblLargeCount.Text = "(" + dsGetCount.Tables[0].Rows[0][3].ToString() + ")";
                    lblNonLargeCount.Text = "(" + dsGetCount.Tables[0].Rows[0][4].ToString() + ")";
                }

                else
                {
                    lblOpenCount.Text = "(0)";
                    lblCloseCount.Text = "(0)";
                    lblLargeCount.Text = "(0)";
                    lblNonLargeCount.Text = "(0)";
                }
            }
            return dsGetCount;
        }
        private void populateDropDowns()
        {
            string UserID = (string)Session["UserID"];
            DataSet Contact_details = new BLL.AssignOpportunity().Get_ContactDetails(UserID);
            DataSet dsAssignees = new BLL.AssignOpportunity().GetVerticalPresalesHead(UserID);
            if (dsAssignees.Tables.Count > 0)
            {
                if (dsAssignees.Tables[0].Rows.Count > 0)
                {
                    if (ddlverticalpresaleshea != null)
                    {
                        if (ddlverticalpresaleshea.Items.Count > 0)
                        {
                            ddlverticalpresaleshea.Items.Clear();
                        }
                    }
                    ddlverticalpresaleshea.DataSource = dsAssignees.Tables[0];
                    ddlverticalpresaleshea.DataTextField = "Full Name";
                    ddlverticalpresaleshea.DataValueField = "Userid";
                    ddlverticalpresaleshea.DataBind();
                    ddlverticalpresaleshea.Items.Insert(0, new ListItem("--Select---", "0"));
                    ddlverticalpresaleshea.SelectedIndex = 0;
                }
            }

            if (dsAssignees.Tables.Count > 0)
            {
                if (dsAssignees.Tables[1].Rows.Count > 0)
                {
                    if (ddlprimarycontact != null)
                    {
                        if (ddlprimarycontact.Items.Count > 0)
                        {
                            ddlprimarycontact.Items.Clear();
                        }
                    }
                    ddlprimarycontact.DataSource = dsAssignees.Tables[1];
                    ddlprimarycontact.DataTextField = "Full Name";
                    ddlprimarycontact.DataValueField = "Userid";
                    ddlprimarycontact.DataBind();
                    ddlprimarycontact.Items.Insert(0, new ListItem("--Select---", "0"));
                    ddlprimarycontact.SelectedIndex = 0;
                    if (ddlsecondrycontact != null)
                    {
                        if (ddlsecondrycontact.Items.Count > 0)
                        {
                            ddlsecondrycontact.Items.Clear();
                        }
                    }
                    ddlsecondrycontact.DataSource = dsAssignees.Tables[1];
                    ddlsecondrycontact.DataTextField = "Full Name";
                    ddlsecondrycontact.DataValueField = "Userid";
                    ddlsecondrycontact.DataBind();
                    ddlsecondrycontact.Items.Insert(0, new ListItem("--Select---", "0"));
                    ddlsecondrycontact.SelectedIndex = 0;
                }

            }

            if (dsAssignees.Tables.Count > 0)
            {
                if (dsAssignees.Tables[2].Rows.Count > 0)
                {
                    if (ddlprimarycnct_GPT != null)
                    {
                        if (ddlprimarycnct_GPT.Items.Count > 0)
                        {
                            ddlprimarycnct_GPT.Items.Clear();
                        }
                    }
                    ddlprimarycnct_GPT.DataSource = dsAssignees.Tables[2];
                    ddlprimarycnct_GPT.DataTextField = "Full Name";
                    ddlprimarycnct_GPT.DataValueField = "Userid";
                    ddlprimarycnct_GPT.DataBind();
                    ddlprimarycnct_GPT.Items.Insert(0, new ListItem("--Select---", "0"));
                    ddlprimarycnct_GPT.SelectedIndex = 0;
                    
                    if (ddlseccnct_GPT != null)
                    {
                        if (ddlseccnct_GPT.Items.Count > 0)
                        {
                            ddlseccnct_GPT.Items.Clear();
                        }
                    }
                    ddlseccnct_GPT.DataSource = dsAssignees.Tables[2];
                    ddlseccnct_GPT.DataTextField = "Full Name";
                    ddlseccnct_GPT.DataValueField = "Userid";
                    ddlseccnct_GPT.DataBind();
                    ddlseccnct_GPT.Items.Insert(0, new ListItem("--Select---", "0"));
                    ddlseccnct_GPT.SelectedIndex = 0;
                }
            }
        }
        private void AssignOpportunityNotificationMail(string _strDeliveryDirectorPrimary, string _strDeliveryDirectorSecondary)
        {

            string strToEmail = string.Empty;
            string strToCCEmail = string.Empty;
            string strToName = string.Empty;
            string _strOppNumber = (string)Session["OppId"];
            string _strOppName = string.Empty;

            DataSet dsStakeHoldersDetails = new BLL.AutomatedMailBLL().getEmailAddresses(_strDeliveryDirectorPrimary, _strDeliveryDirectorSecondary);

            if (dsStakeHoldersDetails.Tables.Count > 0)
            {
                if (dsStakeHoldersDetails.Tables[0].Rows.Count > 0)
                {
                    strToName = dsStakeHoldersDetails.Tables[0].Rows[0][0].ToString();
                    strToEmail = dsStakeHoldersDetails.Tables[0].Rows[0][1].ToString();
                }
                if (dsStakeHoldersDetails.Tables[1].Rows.Count > 0)
                {
                    strToCCEmail = dsStakeHoldersDetails.Tables[1].Rows[0][1].ToString();
                }
            }

            DataSet dsStakeHoldersDetailsOppName = new BLL.AutomatedMailBLL().getOppNameForEmailAddresses(_strOppNumber);

            if (dsStakeHoldersDetailsOppName.Tables.Count > 0)
            {
                if (dsStakeHoldersDetailsOppName.Tables[0].Rows.Count > 0)
                {
                    _strOppName = dsStakeHoldersDetailsOppName.Tables[0].Rows[0][0].ToString();
                }
            }

            //string _EmailServer = "cas2.syntelorg.com";
            string _EmailBody = "<html><body><div style='border:1px solid black;padding:10px;font-family:arial'> Dear " + strToName + " ";
            _EmailBody += "</br>";
            _EmailBody += "</br>";
            _EmailBody += "<p>RFP <b>" + _strOppName + "</b>(<b>" + _strOppNumber + "</b>)" + " has been assigned to you by <b>Sales SPoC</b></p> ";
            _EmailBody += "</br>";
            _EmailBody += "To Access the LDF Application Please Click on Link below";
            _EmailBody += "</br>";
            _EmailBody += "</br>";
            _EmailBody += "<p style='color:blue;font-size:15px'><u>" + Application["LDFURL"].ToString() + "</u></p>";
            _EmailBody += "</br>";
            _EmailBody += "</br>";
            _EmailBody += "Thanks,";
            _EmailBody += "</br>";
            _EmailBody += "LDF Team";
            _EmailBody += "</br>";
            _EmailBody += "</br>";
            _EmailBody += "[Note: This is an system generated email. Please do not reply]";
            _EmailBody += "</br>";
            _EmailBody += "-------------------------------------------------------------- </div></body></html>";


            var fromAddress = new MailAddress(System.Web.Configuration.WebConfigurationManager.AppSettings["EmailFrom"],
                "Large Deal Framework");

            MailMessage myhtmlMessage = new MailMessage(fromAddress.ToString(), strToEmail, "Automated Mail for Assigned Status of Sales SPoc", _EmailBody);
            if (!string.IsNullOrEmpty(strToCCEmail))
            {
                myhtmlMessage.CC.Add(strToCCEmail);
            }
            myhtmlMessage.IsBodyHtml = true;

            string username = System.Web.Configuration.WebConfigurationManager.AppSettings["username"].ToString();
            string Password = System.Web.Configuration.WebConfigurationManager.AppSettings["Password"];

            string Host = System.Web.Configuration.WebConfigurationManager.AppSettings["SMTPSERVER"];
            int Port = Convert.ToInt32(System.Web.Configuration.WebConfigurationManager.AppSettings["Port"]);

            SmtpClient mysmtpclient = new SmtpClient(Host, Port);
            mysmtpclient.EnableSsl = true;
            System.Net.NetworkCredential crediantials = new NetworkCredential(username, Password);
            mysmtpclient.UseDefaultCredentials = false;
            mysmtpclient.Credentials = crediantials;
            //myhtmlMessage.Attachments.Add(myAttachment);
            mysmtpclient.Send(myhtmlMessage);

        }
        private string GetCurrentDate()
        {
            string FinalString = string.Empty;
            string curdate = DateTime.Now.Date.ToShortDateString();

            int curday = DateTime.Now.Day;

            int curmonth = DateTime.Now.Month;
            if (curmonth <= 9)
            {
                FinalString += "0";
                FinalString += curmonth.ToString();

            }
            else
            {
                FinalString += curmonth.ToString();
            }

            FinalString += "/";
            if (curday <= 9)
            {
                FinalString += "0";

            }
            else
            {
                FinalString += curday.ToString();

            }

            FinalString += "/";
            FinalString += DateTime.Now.Year.ToString();

            return FinalString;

        }

        #endregion

        #region Event handlers

        protected void gvOpenOpportunities_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string UserId = (string)Session["UserID"];
                    int designationId = (int)Session["Designation"];
                    DataSet Opportunity_details = new BLL.HomeScreensBLL().Get_OpportunityDetails(UserId, designationId);
                    int count = Opportunity_details.Tables[0].Columns.Count;
                    int index = 0;
                    int rowcount = Opportunity_details.Tables[0].Rows.Count;
                    int rowIndexForGrid = e.Row.RowIndex;
                    index = rowIndexForGrid;
                    
                    if(ViewState["CurrentPageIndex"]!=null)
                    {
                        int pageindex = Convert.ToInt32(ViewState["CurrentPageIndex"]);
                        int rowindexForDataTable = (gvOpenOpportunities.PageSize * (pageindex - 1)) + rowIndexForGrid;
                        index = rowindexForDataTable;
                    }
                    string oppId = Opportunity_details.Tables[0].Rows[index].ItemArray[0].ToString();
                    DataSet OpportunityAssign = new BLL.HomeScreensBLL().getStatusAssign(oppId);
                    for (int a = 0; a <= count - 1; a++)
                    {
                        if (OpportunityAssign.Tables[0].Rows.Count > 0)
                        {
                            if (OpportunityAssign.Tables[0].Rows[0].ItemArray[a].ToString() == string.Empty)
                            {
                                LinkButton lbDate = new LinkButton();
                                lbDate = (LinkButton)e.Row.FindControl("OppIDLnkButton");
                                lbDate.Enabled = false;
                                lbDate.ForeColor = System.Drawing.Color.Gray;
                            }
                            else
                            {
                                LinkButton lbDate = new LinkButton();
                                lbDate = (LinkButton)e.Row.FindControl("OppIDLnkButton");
                                lbDate.Enabled = true;
                                lbDate.ForeColor = System.Drawing.Color.Blue;
                            }
                        }
                        else
                        {
                            LinkButton lbDate = new LinkButton();
                            lbDate = (LinkButton)e.Row.FindControl("OppIDLnkButton");
                            lbDate.Enabled = false;
                            lbDate.ForeColor = System.Drawing.Color.Gray;
                        }

                    }


                    TextBox txtDate = new TextBox();
                    txtDate = (TextBox)e.Row.FindControl("txtEditReview");

                    if (txtDate.Text != string.Empty)
                    {
                        txtDate.Enabled = false;
                        counterforenableSubmitbtn = counterforenableSubmitbtn + 1;

                        if (counterforenableSubmitbtn == rowcount)
                        {
                            ButtonDate.Visible = false;
                        }
                        else
                        {
                            ButtonDate.Visible = true;
                        }
                    }
                    else
                    {
                        LinkButton lbAssign = new LinkButton();
                        lbAssign = (LinkButton)e.Row.FindControl("lnkSales_DH");
                        lbAssign.Enabled = false;
                        lbAssign.ForeColor = System.Drawing.Color.Gray;


                        lbAssign = (LinkButton)e.Row.FindControl("lnkSales_VPSH");
                        lbAssign.Enabled = false;
                        lbAssign.ForeColor = System.Drawing.Color.Gray;

                        lbAssign = (LinkButton)e.Row.FindControl("lnkSales_GPTM");
                        lbAssign.Enabled = false;
                        lbAssign.ForeColor = System.Drawing.Color.Gray;
                    }


                    txtDate = (TextBox)e.Row.FindControl("txtStartDat");
                    if (txtDate.Text != string.Empty)
                    {
                        txtDate.Enabled = false;
                    }
                    txtDate = (TextBox)e.Row.FindControl("txtEditReview");
                    txtDate.Attributes.Add("onchange", "return gvBusinessValidate(" + e.Row.RowIndex.ToString() + ")");

                    TextBox txtstart = (TextBox)e.Row.FindControl("txtStartDat");
                    txtstart.Attributes.Add("onchange", "return gvBusinessValidateStartDate(" + e.Row.RowIndex.ToString() + ")");
                }
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
        protected void gvOpenOpportunities_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName.Trim().ToLower() != "Page".ToLower())
                {
                    int RowIndexForGrid = Convert.ToInt32(e.CommandArgument);
                    int pageindex = 0;
                    if (ViewState["CurrentPageIndex"] != null)
                    {
                        pageindex = Convert.ToInt32(ViewState["CurrentPageIndex"]);
                    }
                    else
                    {
                        pageindex = 1;
                    }

                    int currentRowIndexForDataTable = (gvOpenOpportunities.PageSize * (pageindex - 1)) + RowIndexForGrid; // use when you fetch data from datatable
                    GridViewRow row = gvOpenOpportunities.Rows[RowIndexForGrid];
                    DataTable dt = (DataTable)ViewState["dt_openopp"];
                    string _strOppId = dt.Rows[currentRowIndexForDataTable]["opportnumber"].ToString();

                    Session["Oppid"] = _strOppId;

                    DataSet dsAssignmentDetails = new BLL.AssignOpportunity().GetAssignmentDetails(_strOppId);
                    if (dsAssignmentDetails != null && dsAssignmentDetails.Tables[0].Rows.Count > 0)
                    {
                        DataTable dtOppAssignments = dsAssignmentDetails.Tables[0];
                    }
                    if (e.CommandName == "Assign")
                    {
                        if (ViewState["UnassignStatus"] != null)
                        {
                            DataTable dtOppAssignments = dsAssignmentDetails.Tables[0];
                            lblprimarycontact.Text = dtOppAssignments.Rows[0].ItemArray[2].ToString();
                            lblsecondrycontact.Text = dtOppAssignments.Rows[0].ItemArray[19].ToString();
                            lblpostprimarycnct_GPT.Text = dtOppAssignments.Rows[0].ItemArray[19].ToString();
                            lblpostseccnct_GPT.Text = dtOppAssignments.Rows[0].ItemArray[19].ToString();
                        }
                    }
                    if (e.CommandName == "Assign")
                    {

                        ddlprimarycontact.SelectedIndex = 0;
                        ddlsecondrycontact.SelectedIndex = 0;

                        if (ViewState["UnassignStatus"] != null)
                        {
                            string _strUnassign = ViewState["UnassignStatus"].ToString();
                            if (_strUnassign.Trim() == "Reassign")
                            {
                                DataTable dt1 = new BLL.Assign().getSalePrimarySecondaryContact(_strOppId);
                                if (dt1.Rows[0][0].ToString() != string.Empty)
                                {
                                    DataSet dtUserName = new BLL.HomeScreensBLL().getlblPrimarySecondaryContact(dt1.Rows[0][0].ToString(), dt1.Rows[0][1].ToString(), "");


                                    if (dtUserName.Tables[0].Rows.Count > 0)
                                    {
                                        lblprimarycontact.Text = dtUserName.Tables[0].Rows[0][0].ToString();
                                        if (dtUserName.Tables[1].Rows.Count > 0)
                                        {
                                            lblsecondrycontact.Text = dtUserName.Tables[1].Rows[0][0].ToString();
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (e.CommandName == "Assign Sales_VPSH")
                    {
                        ddlverticalpresaleshea.SelectedIndex = 0;
                        if (ViewState["UnassignStatus"] != null)
                        {
                            string _strUnassign = ViewState["UnassignStatus"].ToString();
                            if (_strUnassign.Trim() == "Reassign")
                            {
                                DataTable dt1 = new BLL.Assign().getSales_VPSHPrimarySecondaryContact(_strOppId);
                                if (dt1.Rows[0][0].ToString() != string.Empty)
                                {
                                    DataSet dtUserName = new BLL.HomeScreensBLL().getlblPrimarySecondaryContact(dt1.Rows[0][0].ToString(), "", "");

                                    if ((dtUserName.Tables[0].Rows.Count > 0))
                                    {
                                        lblprimarycontact0.Text = dtUserName.Tables[0].Rows[0][0].ToString();
                                    }
                                }
                            }
                        }
                    }
                    else if (e.CommandName == "Assign Sales_GPTM")
                    {

                        ddlprimarycnct_GPT.SelectedIndex = 0;
                        ddlseccnct_GPT.SelectedIndex = 0;
                        if (ViewState["UnassignStatus"] != null)
                        {
                            string _strUnassign = ViewState["UnassignStatus"].ToString();
                            if (_strUnassign.Trim() == "Reassign")
                            {
                                DataTable dt1 = new BLL.Assign().getSales_GPTMPrimarySecondaryContact(_strOppId);
                                if (dt1.Rows[0][0].ToString() != string.Empty)
                                {
                                    DataSet dtUserName = new BLL.HomeScreensBLL().getlblPrimarySecondaryContact(dt1.Rows[0][0].ToString(), dt1.Rows[0][1].ToString(), "");

                                    if (dtUserName.Tables[0].Rows.Count > 0)
                                    {
                                        lblpostprimarycnct_GPT.Text = dtUserName.Tables[0].Rows[0][0].ToString();

                                        if (dtUserName.Tables[1].Rows.Count > 0)
                                        {
                                            lblpostseccnct_GPT.Text = dtUserName.Tables[1].Rows[0][0].ToString();
                                        }

                                    }
                                }
                            }
                        }
                    }


                    if (e.CommandName == "OppIdRedirect")
                    {
                        string OppIDRedirect = string.Empty;
                        int RowIndecs = Convert.ToInt32(e.CommandArgument);
                        GridViewRow grow = gvOpenOpportunities.Rows[RowIndecs];
                        LinkButton lnkopp = null;
                        lnkopp = (LinkButton)grow.FindControl("OppIDLnkButton");
                        OppIDRedirect = lnkopp.Text;
                        Response.Redirect("/FrmQualificationmain.aspx?OppID=" + OppIDRedirect);
                    }
                }
                else if (e.CommandName.Trim().ToLower() == "Page".ToLower())
                {
                    // int pageindex = 0;
                    int pageSize = gvOpenOpportunities.PageSize;
                    int pageindex = Convert.ToInt32(e.CommandArgument);
                    this.gvOpenOpportunities.PageIndex = pageindex;
                    ViewState["CurrentPageIndex"] = e.CommandArgument;
                    loadOpenOpportunity();
                }
            }
            catch (ThreadAbortException exc)
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
        protected void gvOpenOpportunities_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvOpenOpportunities.PageIndex = e.NewPageIndex;
                loadOpenOpportunity();
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
        protected void gvCloseOpportunities_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "OppIdRedirect")
                {
                    string OppIDRedirect = string.Empty;
                    int RowIndecs = Convert.ToInt32(e.CommandArgument);
                    GridViewRow grow = gvCloseOpportunities.Rows[RowIndecs];
                    LinkButton lnkopp = null;
                    lnkopp = (LinkButton)grow.FindControl("OppIDLnkButton");
                    OppIDRedirect = lnkopp.Text;
                    DataSet dsGetStatusValueBid = new BLL.RGYBLL().retrievestatus(OppIDRedirect);
                    if (dsGetStatusValueBid.Tables.Count > 0)
                    {
                        if (dsGetStatusValueBid.Tables[1].Rows.Count > 0)
                        {
                            if (dsGetStatusValueBid.Tables[1].Rows[0][7].ToString().Trim() != null)
                            {
                                if (dsGetStatusValueBid.Tables[1].Rows[0][7].ToString().Trim() == "True")
                                {
                                    Response.Redirect("/FrmBidWinability.aspx?OppID=" + OppIDRedirect);
                                }
                                else
                                {
                                    Response.Redirect("/FrmQualificationmain.aspx?OppID=" + OppIDRedirect);
                                }
                            }
                            else
                            {
                                Response.Redirect("/FrmQualificationmain.aspx?OppID=" + OppIDRedirect);
                            }
                        }
                        else
                        {
                            Response.Redirect("/FrmQualificationmain.aspx?OppID=" + OppIDRedirect);
                        }
                    }
                    else
                    {
                        Response.Redirect("/FrmQualificationmain.aspx?OppID=" + OppIDRedirect);
                    }

                    //Response.Redirect("~/FrmQualificationmain.aspx?OppID=" + OppIDRedirect);
                }
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
        protected void gvCloseOpportunities_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                //DataSet dsPopulateCloseOpportunity = new BLL.HomeScreensBLL().getClosedOpportunity((string)Session["UserID"]);
               DataSet dsGetFlag = new BLL.HomeScreensBLL().GetFlag((string)Session["UserID"]);

                //int intRowCount = dsPopulateCloseOpportunity.Tables[0].Rows.Count;

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    TextBox txtDate = new TextBox();
                    txtDate = (TextBox)e.Row.FindControl("txtEditReview");

                    txtDate.Enabled = false;

                    txtDate = (TextBox)e.Row.FindControl("txtStartDat");

                    txtDate.Enabled = false;
                    txtDate = (TextBox)e.Row.FindControl("txtCloseDate");

                    txtDate.Enabled = false;

                    int index = e.Row.RowIndex;

                    if (ViewState["CurrentPageIndexForClose"] != null)
                    {
                        int pageindex = Convert.ToInt32(ViewState["CurrentPageIndexForClose"]);
                        int rowindexForDataTable = (gvCloseOpportunities.PageSize * (pageindex - 1)) + index;
                        index = rowindexForDataTable;
                    }

                    if (dsGetFlag.Tables[0].Rows.Count > 0)
                    {
                        if (dsGetFlag.Tables[0].Rows[index][2].ToString().Trim() == "No Go")
                        {
                                    DropDownList dropDownListStatus = (DropDownList)e.Row.FindControl("ddlstatus");
                                    dropDownListStatus.SelectedIndex = 3;
                                    dropDownListStatus.Enabled = false;
                                    LinkButton lnkButtonOppId = (LinkButton)e.Row.FindControl("OppIDLnkButton");
                                    lnkButtonOppId.Enabled = false;
                                    lnkButtonOppId.ForeColor = System.Drawing.Color.Black;
                                    btnSubmit.Visible = false;
                                }

                        else if (dsGetFlag.Tables[0].Rows[(index)][2].ToString().Trim() == string.Empty || dsGetFlag.Tables[0].Rows[(index)][2].ToString().Trim().ToLower() == "approved"
                                     || dsGetFlag.Tables[0].Rows[(index)][2].ToString().Trim().ToLower() == "win" || dsGetFlag.Tables[0].Rows[(index)][2].ToString().Trim().ToLower() == "loss"
                                     || dsGetFlag.Tables[0].Rows[(index)][2].ToString().Trim().ToLower() == "hold")
                        {
                                    LinkButton lnkButtonOppId = (LinkButton)e.Row.FindControl("OppIDLnkButton");
                                    lnkButtonOppId.Enabled = true;
                                    lnkButtonOppId.ForeColor = System.Drawing.Color.Blue;
                                   if (dsGetFlag.Tables.Count > 0)
                                    {
                                        if (dsGetFlag.Tables[0].Rows.Count > 0)
                                        {
                                            if (dsGetFlag.Tables[0].Rows[index][3].ToString().Trim().Contains("0") || dsGetFlag.Tables[0].Rows[index][2].ToString().Trim().ToLower() != "approved")
                                            {
                                                DropDownList dropDownListStatus = (DropDownList)e.Row.FindControl("ddlstatus");
                                                dropDownListStatus.SelectedItem.Text = dsGetFlag.Tables[0].Rows[index][2].ToString();
                                                dropDownListStatus.Enabled = false;
                                            }

                                            else
                                            {
                                                DropDownList dropDownListStatus = (DropDownList)e.Row.FindControl("ddlstatus");
                                                dropDownListStatus.SelectedIndex = 0;
                                                dropDownListStatus.Enabled = true;

                                                //dropDownListStatus.SelectedIndexChanged+=new EventHandler()
                                            }
                                        }
                                    }
                                }


                                else
                                {
                                    DropDownList dropDownListStatus = (DropDownList)e.Row.FindControl("ddlstatus");
                                    dropDownListStatus.SelectedItem.Text = dsGetFlag.Tables[0].Rows[index][2].ToString();
                                    dropDownListStatus.Enabled = false;
                                }
                        }
                    }
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
        protected void gvCloseOpportunities_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvCloseOpportunities.PageIndex = e.NewPageIndex;
                ViewState["CurrentPageIndexForClose"]=e.NewPageIndex+1;
                loadClosedOpportunity();
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
        protected void btnSubmitDate_Click(object sender, EventArgs e)
        {
            try
            {
                string strOppID = string.Empty;
                string strStatus = string.Empty;
                foreach (GridViewRow gr in gvOpenOpportunities.Rows)
                {
                    TextBox txtStartDat = (TextBox)gr.FindControl("txtStartDat");
                    TextBox txtSubmissionDat = (TextBox)gr.FindControl("txtEditReview");
                    LinkButton lnkopp = null;
                    lnkopp = (LinkButton)gr.FindControl("OppIDLnkButton");
                    if (txtStartDat.Text != string.Empty && txtSubmissionDat.Text != string.Empty && gr.RowIndex >= 0)
                    {
                        OpportunityQualificationBO opportunityQualificationBO = new OpportunityQualificationBO();
                        opportunityQualificationBO.OppNumber = lnkopp.Text;
                        opportunityQualificationBO.StartDate = Convert.ToDateTime(txtStartDat.Text);
                        opportunityQualificationBO.EndDate = Convert.ToDateTime(txtSubmissionDat.Text);
                        if (Convert.ToDateTime(txtStartDat.Text) <= Convert.ToDateTime(txtSubmissionDat.Text))
                        {
                            DataSet dsAddOpp = new BLL.ScoreOppQuaBLL().InsertDates(opportunityQualificationBO);
                        }
                    }

                }
                Response.Redirect("FrmHomeScreenforSale.aspx");
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
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string strOppID = string.Empty;
                string strStatus = string.Empty;

                foreach (GridViewRow gr in gvCloseOpportunities.Rows)
                {
                    DropDownList ddlstatus = (DropDownList)gr.FindControl("ddlstatus");

                    if (ddlstatus.Enabled == true && ddlstatus.SelectedIndex > 0)
                    {
                        OpportunityQualificationBO opportunityQualificationBO = new OpportunityQualificationBO();
                        opportunityQualificationBO.OppNumber = gvCloseOpportunities.DataKeys[gr.RowIndex].Value.ToString();
                        opportunityQualificationBO.Status = ddlstatus.SelectedItem.Text;
                        opportunityQualificationBO.Comments = string.Empty;
                        opportunityQualificationBO.OppDescription = "";
                        ddlstatus.Enabled = false;
                        DataSet dsAddOpp = new BLL.ScoreOppQuaBLL().InsertDeleteOpportunity(opportunityQualificationBO);

                    }
                }
                Response.Redirect("FrmHomeScreenforSale.aspx");
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
        protected void AssignDeliveryDirector_Click(object sender, EventArgs e)
        {
            try
            {
                string _stroppid = (string)Session["OppId"];
                string _strDeliveryDirectorPrimary = string.Empty;
                string _strDeliveryDirectorSecondary = string.Empty;
                if (ddlprimarycontact.SelectedValue.ToString() != "0")
                {
                    _strDeliveryDirectorPrimary = ddlprimarycontact.SelectedValue.ToString();
                }
                if (ddlsecondrycontact.SelectedValue.ToString() != "0")
                {
                    _strDeliveryDirectorSecondary = ddlsecondrycontact.SelectedValue.ToString();
                }
                bool _boolassignstatus = new BLL.Assign().AssigtnDD(_stroppid, _strDeliveryDirectorPrimary, _strDeliveryDirectorSecondary);
                int Id = (int)Session["Designation"];
                //int AssigneeId = 5;
                int AssigneeId = new BLL.HomeScreensBLL().GetDesignationIdByDesgDesc("Delivery Director");
                DataSet ds = new BLL.HomeScreensBLL().AssignStatus(_stroppid, "Assigned", Id, AssigneeId);
                AssignOpportunityNotificationMail(_strDeliveryDirectorPrimary, _strDeliveryDirectorSecondary);
                Response.Redirect("/FrmHomeScreenforSale.aspx");
                //AssignLabel.Text = "Assigned Successfully";
                Response.Redirect("/FrmHomeScreenforSale.aspx");

            }
            catch (ThreadAbortException exc)
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
        protected void btnAssignGPTM_Click(object sender, EventArgs e)
        {
            try
            {
                string _stroppid = (string)Session["OppId"];
                string _strGPTPrimary = string.Empty;
                string _strGPTSecondary = string.Empty;
                if (ddlprimarycnct_GPT.SelectedValue.ToString() != "0")
                {
                    _strGPTPrimary = ddlprimarycnct_GPT.SelectedValue.ToString();
                }
                if (ddlseccnct_GPT.SelectedValue.ToString() != "0")
                {
                    _strGPTSecondary = ddlseccnct_GPT.SelectedValue.ToString();
                }
                bool _boolassignstatus = new BLL.Assign().AssigtnGPT(_stroppid, _strGPTPrimary, _strGPTSecondary);
                int Id = (int)Session["Designation"];
                // int AssigneeId = 14;
                //int AssigneeId = new BLL.HomeScreensBLL().GetDesignationIdByDesgDesc("GPT Head");
                int AssigneeId = clsDesignationList.GetDesignationID(EnumDesignation.GPTHead);

                DataSet ds = new BLL.HomeScreensBLL().AssignStatus(_stroppid, "Assigned", Id, AssigneeId);
                AssignOpportunityNotificationMail(_strGPTPrimary, _strGPTSecondary);
                Response.Redirect("/FrmHomeScreenforSale.aspx");
            }
            catch (ThreadAbortException exc)
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
        protected void btnAssignVPH_Click(object sender, EventArgs e)
        {
            try
            {
                string _stroppid = (string)Session["OppId"];
                string _strVPH = string.Empty;
                if (ddlverticalpresaleshea.SelectedValue.ToString() != "0")
                {
                    _strVPH = ddlverticalpresaleshea.SelectedValue.ToString();
                }
                bool _boolassignstatus = new BLL.Assign().AssigtnverticalPresalesHead(_stroppid, _strVPH);
                int Id = (int)Session["Designation"];
                //int AssigneeId = 6;
                int AssigneeId = new BLL.HomeScreensBLL().GetDesignationIdByDesgDesc("Vertical Pre Sales Head");
                DataSet ds = new BLL.HomeScreensBLL().AssignStatus(_stroppid, "Assigned", Id, AssigneeId);
                AssignOpportunityNotificationMail(_strVPH, string.Empty);
                Response.Redirect("/FrmHomeScreenforSale.aspx");
                
            }
            catch (ThreadAbortException exc)
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
        protected void ddlprimarycontact_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblprimarycontact.Text = ddlprimarycontact.SelectedItem.Text;
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
        protected void ddlsecondrycontact_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblsecondrycontact.Text = ddlsecondrycontact.SelectedItem.Text;
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
        protected void lnkSales_DH_Click(object sender, EventArgs e)
        {
            try
            {
                ModalPopupExtender_Three.Show();
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
        protected void lnkSales_VPSH_Click(object sender, EventArgs e)
        {
            try
            {
                ModalPopupExtender_Two.Show();
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
        protected void lnkSales_GPTM_Click(object sender, EventArgs e)
        {
            try
            {
                ModalPopupExtender_One.Show();
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
        
        #endregion

       
    }
}
