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
    public partial class HomeScreenForDeliveryHead : System.Web.UI.Page
    {
        string UserID = string.Empty;
        int Id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] == null)
                {
                    Response.Redirect("/Login/SignInPage.aspx");
                }
                UserID = (string)Session["UserID"];
                Id = (int)Session["Designation"];
                lblClosedNoRecords.Text = string.Empty;
                lblOpenNoRecords.Text = string.Empty;
                //loadOpportunities();
                if (!IsPostBack)
                {
                    fillDdlPersonSales();
                    GetCountOpportunity(UserID, Id.ToString());
                    string verticalID = (string)Session["VertId"];
                    int _intdesignation = clsDesignationList.GetDesignationID(EnumDesignation.DeliveryManager);
                    DataTable userTable = new BLL.HomeScreensBLL().getUserName(_intdesignation, verticalID);
                    if (userTable != null && userTable.Rows.Count > 0)
                    {
                        ddlprimarycontact.DataSource = userTable;
                        ddlprimarycontact.DataTextField = "Name";
                        ddlprimarycontact.DataValueField = "vspkUsrID";
                        ddlprimarycontact.DataBind();
                        ddlprimarycontact.Items.Insert(0, new ListItem("--Select---", "0"));
                        ddlprimarycontact.SelectedIndex = 0;
                        ddlsecondarycontact.DataSource = userTable;
                        ddlsecondarycontact.DataTextField = "Name";
                        ddlsecondarycontact.DataValueField = "vspkUsrID";
                        ddlsecondarycontact.DataBind();
                        ddlsecondarycontact.Items.Insert(0, new ListItem("--Select---", "0"));
                        ddlsecondarycontact.SelectedIndex = 0;


                    }
                    div_openopprDH.Visible = false;
                    div_closedopprDH.Visible = false;
                }
                else
                {
                    checkpostback.Value = "0";
                    if (ddlselectsales.SelectedIndex > 0)
                    {
                        int _intDesignationId = new BLL.HomeScreensBLL().Get_DesignationByUserId(ddlselectsales.SelectedValue);
                        loadOpportunities(_intDesignationId);
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

        private DataSet GetCountOpportunity(string userid, string designationId)
        {
            DataSet dsGetCount = new BLL.HomeScreensBLL().GetCountOpenLargeNonLargeDealOpportunity(userid, designationId);
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


        protected void btnAssign_Click(object sender, EventArgs e)
        {
            try
            {
                modal_assign.Hide();
                string _stroppid = (string)ViewState["oppid"];
                string _primaryContactid = ddlprimarycontact.SelectedValue.ToString();
                string _secondaryContactid = ddlsecondarycontact.SelectedValue.ToString();
                string _deliveryManager = string.Empty;
                bool _boolassignstatus = new BLL.Assign().AssignDH(_stroppid, _primaryContactid, _secondaryContactid, _deliveryManager);
                //int AssigneeId = 9; Delivery Manager
                int AssigneeId = new BLL.HomeScreensBLL().GetDesignationIdByDesgDesc("Delivery Manager");

                DataSet ds = new BLL.HomeScreensBLL().AssignStatus((string)ViewState["oppid"], "Assigned", Id, AssigneeId);
                GetStakeholderstoApproveRGYChecklist(_primaryContactid, _secondaryContactid, _deliveryManager);
                //Response.Redirect("~/FrmHomeScreenforDeliveryHead.aspx");
                if (ddlselectsales.SelectedIndex > 0)
                {
                    int _intDesgId = new BLL.HomeScreensBLL().Get_DesignationByUserId(ddlselectsales.SelectedValue);
                    loadOpportunities(_intDesgId);
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

        private void loadOpportunities(int _intdesinationid)
        {
            try
            {
                string salesID = ddlselectsales.SelectedValue;//.DataValueField.ToString() ;//
                string deliveryHeadID = (string)Session["UserID"];
                int designationId = _intdesinationid;
                DataSet Opportunity_details = new BLL.HomeScreensBLL().GetOpportunityDetailsDeliveryHeadbySales(salesID, deliveryHeadID);

                DataTable dt_openopp = new DataTable();
                dt_openopp.Columns.Add("opportnumber");
                dt_openopp.Columns.Add("opportdesc");
                dt_openopp.Columns.Add("startdate");
                dt_openopp.Columns.Add("submissiondate");
                dt_openopp.Columns.Add("status");
                int count = Opportunity_details.Tables[0].Rows.Count;
                if (count == 0)
                {
                    lblOpenNoRecords.Visible = true;
                    lblOpenNoRecords.Text = "No Records found!!!";
                    gvOpenOpportunities.DataSource = null;
                    gvOpenOpportunities.DataBind();
                }
                else
                {
                    lblOpenNoRecords.Visible = false;
                }
                for (int i = 0; i <= count - 1; i++)
                {
                    if (Convert.ToBoolean(Opportunity_details.Tables[0].Rows[i].ItemArray[4].ToString()) == false)
                    {
                        DataRow dr = dt_openopp.NewRow();
                        string oppId = Opportunity_details.Tables[0].Rows[i].ItemArray[0].ToString();
                        dr["opportnumber"] = Opportunity_details.Tables[0].Rows[i].ItemArray[0].ToString();
                        dr["opportdesc"] = Opportunity_details.Tables[0].Rows[i].ItemArray[5].ToString();
                        dr["startdate"] = Opportunity_details.Tables[0].Rows[i].ItemArray[2].ToString();
                        dr["submissiondate"] = Opportunity_details.Tables[0].Rows[i].ItemArray[3].ToString();
                        //dr["status"] = Opportunity_details.Tables[0].Rows[i].ItemArray[1].ToString();
                        DataTable ds = new BLL.Assign().getDHDMPrimarySecondaryContact(oppId);
                        if (ds.Rows.Count > 0)
                        {
                            if (ds.Rows[0][0].ToString() == "Assigned")
                            {
                                dr["status"] = "Reassign";
                                ViewState["UnassignStatus"] = dr["status"];
                            }
                            else
                            {
                                dr["status"] = "Assign";
                            }
                        }
                        else
                        {
                            dr["status"] = "Assign";
                        }
                        dt_openopp.Rows.Add(dr);

                    }
                }

                gvOpenOpportunities.DataSource = dt_openopp;
                ViewState["dt_openopp"] = dt_openopp;
                gvOpenOpportunities.DataBind();



            }
            catch
            {

            }


        }



        protected void lnkCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                //Retrieve Customer ID  
                LinkButton lnkCustomerID = sender as LinkButton;
                string strCustomerID = lnkCustomerID.Text;

                modal_assign.Show();
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
                    string oppid = dt.Rows[currentRowIndexForDataTable]["opportnumber"].ToString();
                    ViewState["oppid"] = oppid;
                    if (e.CommandName == "Assign")
                    {
                        ddlprimarycontact.SelectedIndex = 0;
                        ddlsecondarycontact.SelectedIndex = 0;
                        int RowIndex = Convert.ToInt32(e.CommandArgument);
                        //GridViewRow row = gvOpenOpportunities.Rows[RowIndex];
                        //DataTable dt = (DataTable)ViewState["dt_openopp"];
                        //string oppid = dt.Rows[RowIndex]["opportnumber"].ToString();
                       
                        //LinkButton lnkstatus = (LinkButton)row.FindControl("lnkCustomer");
                        //lnkstatus.Text = "Reassign";
                        
                        //using calculated rowindex
                        ///string status = dt.Rows[RowIndex]["Status"].ToString();
                        string status = dt.Rows[currentRowIndexForDataTable]["Status"].ToString();

                        if (ViewState["UnassignStatus"] != null)
                        {
                            string _strUnassign = ViewState["UnassignStatus"].ToString();
                            //LinkButton lnkstatus = (LinkButton)row.FindControl("lnkCustomer");
                            //lnkstatus.Text = "Reassign";
                            if (_strUnassign.Trim() == "Reassign")
                            {

                                DataTable dt1 = new BLL.Assign().getDMgrPrimarySecondaryContact((string)ViewState["oppid"]);
                                if (dt1.Rows[0][0].ToString() != string.Empty)
                                {

                                    DataSet dtUserName = new BLL.HomeScreensBLL().getlblPrimarySecondaryContact(dt1.Rows[0][0].ToString(), dt1.Rows[0][1].ToString(), "");
                                    if (dtUserName.Tables[0].Rows.Count > 0)
                                    {
                                        lbldisplayPrimaryContact.Text = dtUserName.Tables[0].Rows[0][0].ToString();
                                        if (dtUserName.Tables[1].Rows.Count > 0)
                                        {
                                            lbldisplaySecondaryContact.Text = dtUserName.Tables[1].Rows[0][0].ToString();
                                        }

                                    }
                                }

                            }
                        }
                    }
                    else if (e.CommandName == "OppIdRedirect")
                    {
                        string OppIDRedirect = string.Empty;
                        int RowIndecs = Convert.ToInt32(e.CommandArgument);
                        GridViewRow grow = gvOpenOpportunities.Rows[RowIndecs];
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

                    }
                }
                else if (e.CommandName.Trim().ToLower() == "Page".ToLower())
                {
                    // int pageindex = 0;
                    int pageSize = gvOpenOpportunities.PageSize;
                    int pageindex = Convert.ToInt32(e.CommandArgument);
                    this.gvOpenOpportunities.PageIndex = pageindex;
                    ViewState["CurrentPageIndex"] = e.CommandArgument;
                    int _intDesignationId = 0;
                    _intDesignationId = new BLL.HomeScreensBLL().Get_DesignationByUserId(ddlselectsales.SelectedValue);
                    loadOpportunities(_intDesignationId);
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
        protected void fillDdlPersonSales()
        {
            string UserId = (string)Session["UserID"];
            int DesignationId = (int)Session["Designation"];
            DataSet SalesPerson_details = new BLL.HomeScreensBLL().Get_SalesPerson(UserId, DesignationId);
            if (SalesPerson_details.Tables.Count > 0)
            {
                if (SalesPerson_details.Tables[0].Rows.Count > 0)
                {
                    ddlselectsales.DataSource = SalesPerson_details.Tables[0];
                    ddlselectsales.DataTextField = "FullName";
                    ddlselectsales.DataValueField = "vspkUsrId";
                    ddlselectsales.DataBind();

                    ddlselectsales.Items.Insert(0, new ListItem("--Select---", "0"));
                    ddlselectsales.SelectedIndex = 0;
                }
            }

        }

        protected void loadClosedOpportunities(string _Salesid)
        {
            try
            {
                div_openopprDH.Visible = true;
                div_closedopprDH.Visible = true;
                string UserID = (string)Session["UserID"];
                string Salesid = ddlselectsales.SelectedValue;


                DataSet TopMangmtClosedOpportunity_details = new BLL.HomeScreensBLL().Get_DDClosedOpportunityDetails(UserID, Salesid);

                DataTable dt_closedopp = new DataTable();
                dt_closedopp.Columns.Add("opportnumber");
                dt_closedopp.Columns.Add("opportdesc");
                dt_closedopp.Columns.Add("startdate");
                dt_closedopp.Columns.Add("submissiondate");
                dt_closedopp.Columns.Add("status");
                dt_closedopp.Columns.Add("closeddate");

                int countclosed = TopMangmtClosedOpportunity_details.Tables[0].Rows.Count;
                if (countclosed == 0)
                {
                    lblClosedNoRecords.Visible = true;
                    lblClosedNoRecords.Text = "No Records found!!!";
                    gvCloseOpportunities.DataSource = null;
                    gvCloseOpportunities.DataBind();
                }
                else
                {
                    for (int i = 0; i <= countclosed - 1; i++)
                    {

                        DataRow dr = dt_closedopp.NewRow();
                        dr["opportnumber"] = TopMangmtClosedOpportunity_details.Tables[0].Rows[i].ItemArray[0].ToString();
                        dr["startdate"] = TopMangmtClosedOpportunity_details.Tables[0].Rows[i].ItemArray[3].ToString();
                        dr["submissiondate"] = TopMangmtClosedOpportunity_details.Tables[0].Rows[i].ItemArray[4].ToString();
                        dr["opportdesc"] = TopMangmtClosedOpportunity_details.Tables[0].Rows[i].ItemArray[1].ToString();
                        dr["status"] = TopMangmtClosedOpportunity_details.Tables[0].Rows[i].ItemArray[2].ToString();
                        dr["closeddate"] = TopMangmtClosedOpportunity_details.Tables[0].Rows[i].ItemArray[5].ToString();
                        string oppId = TopMangmtClosedOpportunity_details.Tables[0].Rows[i].ItemArray[0].ToString();

                        dt_closedopp.Rows.Add(dr);

                    }

                    gvCloseOpportunities.DataSource = dt_closedopp;
                    gvCloseOpportunities.DataBind();
                }

            }
            catch
            {

            }
        }

        protected void ddlselectsales_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int _intDesignationId = 0;
                checkpostback.Value = "1";
                string _Salesid = string.Empty;
                ViewState["CurrentPageIndex"] = null;
                if (ddlselectsales.SelectedIndex > 0)
                {
                    _intDesignationId = new BLL.HomeScreensBLL().Get_DesignationByUserId(ddlselectsales.SelectedValue);
                    loadOpportunities(_intDesignationId);
                    loadClosedOpportunities(_Salesid);
                    ViewState["_Salesid"] = _Salesid;
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Message", "alert('Select A SalesPerson')");
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

        private void GetStakeholderstoApproveRGYChecklist(string _strDeliveryDirectorPrimary, string _strDeliveryDirectorSecondary, string _deliveryManager)
        {

            string _strBidCoordinatorEmail = string.Empty;
            string _strBidManagerEmail = string.Empty;
            string _strBidCoordinatorName = string.Empty;
            string _strOppNumber = (string)Session["OppId"];
            string _strOppName = string.Empty;

            DataSet dsStakeHoldersDetails = new BLL.AutomatedMailBLL().getEmailAddresses(_strDeliveryDirectorPrimary, _strDeliveryDirectorSecondary);

            if (dsStakeHoldersDetails.Tables.Count > 0)
            {
                if (dsStakeHoldersDetails.Tables[0].Rows.Count > 0)
                {
                    _strBidCoordinatorName = dsStakeHoldersDetails.Tables[0].Rows[0][0].ToString();
                    _strBidCoordinatorEmail = dsStakeHoldersDetails.Tables[0].Rows[0][1].ToString();
                }
                if (dsStakeHoldersDetails.Tables[1].Rows.Count > 0)
                {

                    _strBidManagerEmail = dsStakeHoldersDetails.Tables[1].Rows[0][1].ToString();
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
            string _EmailBody = "<html><body><div style='border:1px solid black;padding:10px;font-family:arial'> Dear " + _strBidCoordinatorName + " ";
            _EmailBody += "</br>";
            _EmailBody += "</br>";
            _EmailBody += "<p style='colr:red;'>RFP<b>" + _strOppName + "</b>(<b>" + _strOppNumber + "</b>)" + "has been assigned to you by <b>Delivery Head</b></p> ";
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

            MailMessage myhtmlMessage = new MailMessage(fromAddress.ToString(), _strBidCoordinatorEmail, "Automated Mail for Assigned Status of Delivery Head", _EmailBody);
            if (!string.IsNullOrEmpty(_strBidManagerEmail))
            {
                myhtmlMessage.CC.Add(_strBidManagerEmail);
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
                    DataSet dsGetStatusValueBid = new BLL.RGYBLL().retrievestatus((string)Session["Oppid"]);
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
                DataSet dsGetFlag = new BLL.HomeScreensBLL().GetOppFlag((string)Session["UserID"]);

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

                    if (dsGetFlag.Tables.Count > 0)
                    {
                        if (dsGetFlag.Tables[0].Rows.Count > 0)
                        {
                            if (dsGetFlag.Tables[0].Rows[(index)][2].ToString().Trim() == "No Go")
                            {
                                //DropDownList dropDownListStatus = (DropDownList)e.Row.FindControl("ddlstatus");
                                //dropDownListStatus.SelectedIndex = 3;
                                //dropDownListStatus.Enabled = false;
                                LinkButton lnkButtonOppId = (LinkButton)e.Row.FindControl("OppIDLnkButton");
                                lnkButtonOppId.Enabled = false;
                                lnkButtonOppId.ForeColor = System.Drawing.Color.Black;
                                //btnSubmit.Visible = false;
                            }

                            else if (dsGetFlag.Tables[0].Rows[(index)][2].ToString().Trim() == string.Empty || dsGetFlag.Tables[0].Rows[(index)][2].ToString().Trim() == "Approved"
                                     || dsGetFlag.Tables[0].Rows[(index)][2].ToString().Trim() == "Win" || dsGetFlag.Tables[0].Rows[(index)][2].ToString().Trim() == "Loss"
                                     || dsGetFlag.Tables[0].Rows[(index)][2].ToString().Trim() == "Hold")
                            {
                                LinkButton lnkButtonOppId = (LinkButton)e.Row.FindControl("OppIDLnkButton");
                                lnkButtonOppId.Enabled = true;
                                lnkButtonOppId.ForeColor = System.Drawing.Color.Blue;
                                if (dsGetFlag.Tables.Count > 0)
                                {
                                    if (dsGetFlag.Tables[0].Rows.Count > 0)
                                    {
                                        if (dsGetFlag.Tables[0].Rows[(index)][3].ToString().Trim().Contains("0"))
                                        {
                                            //DropDownList dropDownListStatus = (DropDownList)e.Row.FindControl("ddlstatus");
                                            //dropDownListStatus.SelectedIndex = 0;
                                            //dropDownListStatus.Enabled = false;
                                        }

                                        else
                                        {
                                            //DropDownList dropDownListStatus = (DropDownList)e.Row.FindControl("ddlstatus");
                                            //dropDownListStatus.SelectedIndex = 0;
                                            //dropDownListStatus.Enabled = true;
                                            //dropDownListStatus.SelectedIndexChanged+=new EventHandler()
                                        }
                                    }
                                }
                            }

                            else
                            {
                                //DropDownList dropDownListStatus = (DropDownList)e.Row.FindControl("ddlstatus");
                                //dropDownListStatus.SelectedItem.Text = dsGetFlag.Tables[0].Rows[(e.Row.RowIndex)][2].ToString();
                                //dropDownListStatus.Enabled = false;
                            }
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
        protected void gvOpenOpportunities_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    DataTable dt = (DataTable)ViewState["dt_openopp"];
                    //int count = dt.Rows.Count;
                    int count = dt.Rows.Count;
                    //string oppId = dt.Rows[e.Row.RowIndex].ItemArray[0].ToString();
                    int index = 0;
                    int rowIndexForGrid = e.Row.RowIndex;
                    index = rowIndexForGrid;

                    if (ViewState["CurrentPageIndex"] != null)
                    {
                        int pageindex = Convert.ToInt32(ViewState["CurrentPageIndex"]);
                        int rowindexForDataTable = (gvOpenOpportunities.PageSize * (pageindex - 1)) + rowIndexForGrid;
                        index = rowindexForDataTable;
                    }
                    string oppId = dt.Rows[index].ItemArray[0].ToString();
                    //string oppId = dt.Rows[e.Row.RowIndex].ItemArray[0].ToString();
                    DataSet OpportunityAssign = new BLL.HomeScreensBLL().getStatusAssign(oppId);

                    if (OpportunityAssign.Tables[0].Rows.Count > 0)
                    {
                        if ((OpportunityAssign.Tables[0].Rows[0].ItemArray[1].ToString() == string.Empty) || (OpportunityAssign.Tables[0].Rows[0].ItemArray[2].ToString() == string.Empty) || (OpportunityAssign.Tables[0].Rows[0].ItemArray[3].ToString() == string.Empty) || (OpportunityAssign.Tables[0].Rows[0].ItemArray[4].ToString() == string.Empty) || (OpportunityAssign.Tables[0].Rows[0].ItemArray[5].ToString() == string.Empty) || (OpportunityAssign.Tables[0].Rows[0].ItemArray[6].ToString() == string.Empty) || (OpportunityAssign.Tables[0].Rows[0].ItemArray[7].ToString() == string.Empty))
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


                    TextBox txtSubDate = new TextBox();
                    txtSubDate = (TextBox)e.Row.FindControl("txtEditReview");
                    txtSubDate.Enabled = false;

                    TextBox txtStartDate = new TextBox();
                    txtStartDate = (TextBox)e.Row.FindControl("txtStartDat");
                    txtStartDate.Enabled = false;

                    if (txtSubDate.Text == string.Empty || txtStartDate.Text == string.Empty)
                    {
                        LinkButton lnkAssign = new LinkButton();
                        lnkAssign = (LinkButton)e.Row.FindControl("lnkCustomer");
                        lnkAssign.Enabled = false;
                        lnkAssign.ForeColor = System.Drawing.Color.Gray;
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

        protected void gvCloseOpportunities_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvOpenOpportunities_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvOpenOpportunities.PageIndex = e.NewPageIndex;
                //int _intDesignationId = new BLL.HomeScreensBLL().Get_DesignationByUserId(ddlselectsales.SelectedValue);
                loadOpportunities(Id);
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
                ViewState["CurrentPageIndexForClose"] = e.NewPageIndex + 1;
                //string _Salesid = string.Empty;
                loadClosedOpportunities(UserID);
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
