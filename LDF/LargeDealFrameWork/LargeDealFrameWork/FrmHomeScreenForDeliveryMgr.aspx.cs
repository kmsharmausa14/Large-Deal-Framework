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
    public partial class FrmHomeScreenForDeliveryMgr : System.Web.UI.Page
    {
        int DesignationId = 0;
        string UserId = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DesignationId = (int)Session["Designation"];
                UserId = (string)Session["UserID"];
                lblClosedNoRecords.Text = string.Empty;
                lblOpenNoRecords.Text = string.Empty;
                if (Session["UserID"] == null)
                {
                    Response.Redirect("/Login/SignInPage.aspx");
                }

                if (!IsPostBack)
                {
                    checkpostback.Value = "1";
                    div_openoppr.Visible = false;
                    div_closedoppr.Visible = false;

                    fillBidCordinators();

                    loadGridview(UserId, DesignationId);
                    loadGridviewForClosed(UserId);
                    //TopMangmtClosedOpportunity(UserId, DesignationId);

                    GetCountOpportunity(UserId, DesignationId.ToString());

                }
                else
                {
                    checkpostback.Value = "0";
                    //int DesignationId = (int)Session["Designation"];

                    ////div_openoppr.Visible = false;
                    ////div_closedoppr.Visible = false;
                    //string UserId = (string)Session["UserID"];
                    //loadGridview(UserId, DesignationId);
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
        protected void gvCloseOpportunities_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                //DataSet dsPopulateCloseOpportunity = new BLL.HomeScreensBLL().getClosedOpportunity((string)Session["UserID"]);
                DataSet dsGetFlag = new BLL.HomeScreensBLL().GetOppFlag(UserId);

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
        protected void loadGridviewForClosed(string strDeliverMrgID)
        {
            if ((int)Session["Designation"] == clsDesignationList.GetDesignationID(EnumDesignation.DeliveryManager))
            {
                div_openoppr.Visible = true;
                div_closedoppr.Visible = true;

                DataSet TopMangmtClosedOpportunity_details = new BLL.HomeScreensBLL().getClosedOpportunityForDeliveryManager(strDeliverMrgID);
                DataTable dt_openopp = new DataTable();
                dt_openopp.Columns.Add("opportnumber");
                dt_openopp.Columns.Add("opportdesc");
                dt_openopp.Columns.Add("startdate");
                dt_openopp.Columns.Add("submissiondate");
                dt_openopp.Columns.Add("status");
                dt_openopp.Columns.Add("closeddate");

                int count = TopMangmtClosedOpportunity_details.Tables[0].Rows.Count;
                if (count == 0)
                {
                    lblClosedNoRecords.Text = "No Records found!!!";
                    gvCloseOpportunities.DataSource = null;
                    gvCloseOpportunities.DataBind();
                }
                else
                {
                    for (int i = 0; i <= count - 1; i++)
                    {

                        DataRow dr = dt_openopp.NewRow();
                        dr["opportnumber"] = TopMangmtClosedOpportunity_details.Tables[0].Rows[i].ItemArray[0].ToString();
                        dr["startdate"] = TopMangmtClosedOpportunity_details.Tables[0].Rows[i].ItemArray[3].ToString();
                        dr["submissiondate"] = TopMangmtClosedOpportunity_details.Tables[0].Rows[i].ItemArray[4].ToString();
                        dr["opportdesc"] = TopMangmtClosedOpportunity_details.Tables[0].Rows[i].ItemArray[1].ToString();
                        dr["status"] = TopMangmtClosedOpportunity_details.Tables[0].Rows[i].ItemArray[2].ToString();
                        dr["closeddate"] = TopMangmtClosedOpportunity_details.Tables[0].Rows[i].ItemArray[5].ToString();
                        string oppId = TopMangmtClosedOpportunity_details.Tables[0].Rows[i].ItemArray[0].ToString();

                        dt_openopp.Rows.Add(dr);

                    }
                    this.gvCloseOpportunities.DataSource = dt_openopp;
                    this.gvCloseOpportunities.DataBind();
                }
            }
           
        }
        protected void loadGridview(string SalesUserId, int DesignationId)
        {
           
                div_openoppr.Visible = true;
                div_closedoppr.Visible = true;

                DataSet Opportunity_details = new BLL.HomeScreensBLL().Get_OpportunityDetails(SalesUserId, DesignationId);

                DataTable dt_openopp = new DataTable();
                dt_openopp.Columns.Add("opportnumber");
                dt_openopp.Columns.Add("opportdesc");
                dt_openopp.Columns.Add("startdate");
                dt_openopp.Columns.Add("submissiondate");
                dt_openopp.Columns.Add("status");

                int count = Opportunity_details.Tables[0].Rows.Count;
                if (count == 0)
                {
                    lblOpenNoRecords.Text = "No Records found!!!";
                    gvOpenOpportunities.DataSource = null;
                    gvOpenOpportunities.DataBind();
                }
                for (int i = 0; i <= count - 1; i++)
                {
                    if (!string.IsNullOrEmpty(Opportunity_details.Tables[0].Rows[i].ItemArray[4].ToString()))
                    {
                        if (Convert.ToBoolean(Opportunity_details.Tables[0].Rows[i].ItemArray[4].ToString()) == false)
                        {
                            DataRow dr = dt_openopp.NewRow();
                            dr["opportnumber"] = Opportunity_details.Tables[0].Rows[i].ItemArray[0].ToString();
                            dr["startdate"] = Opportunity_details.Tables[0].Rows[i].ItemArray[2].ToString();
                            dr["submissiondate"] = Opportunity_details.Tables[0].Rows[i].ItemArray[3].ToString();
                            dr["opportdesc"] = Opportunity_details.Tables[0].Rows[i].ItemArray[5].ToString();

                            string oppId = Opportunity_details.Tables[0].Rows[i].ItemArray[0].ToString();
                            DataTable ds = new BLL.Assign().getDMPrimarySecondaryContact(oppId);
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
                }
                gvOpenOpportunities.DataSource = dt_openopp;
                ViewState["dt_openopp"] = dt_openopp;
                gvOpenOpportunities.DataBind();
            


        }

        protected void TopMangmtClosedOpportunity(string SalesUserId, int DesignationId)
        {
            //DataSet TopMangmtClosedOpportunity_details = new BLL.HomeScreensBLL().Get_TopMangmtClosedOpportunityDetails(SalesUserId, DesignationId);

            //GridView1.DataSource = TopMangmtClosedOpportunity_details;
            //GridView1.DataBind();

        }
        protected void lnkCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                //Retrieve Customer ID  
                LinkButton lnkCustomerID = sender as LinkButton;
                string strCustomerID = lnkCustomerID.Text;
                int id = (int)Session["Designation"];

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

        protected void fillBidCordinators()
        {
            string UserId = (string)Session["UserID"];
            int DesignationId = (int)Session["Designation"];
            string _verticalId = (string)Session["VertId"];
            DataSet dscooridinators_details = new BLL.AssignOpportunity().DMSpoc(_verticalId);
            if (dscooridinators_details.Tables.Count > 0)
            {
                if (dscooridinators_details.Tables[0].Rows.Count > 0)
                {
                    ddlprimarycontact.DataSource = dscooridinators_details.Tables[0];
                    ddlprimarycontact.DataTextField = "Full Name";
                    ddlprimarycontact.DataValueField = "UseriD";
                    ddlprimarycontact.DataBind();
                    ddlprimarycontact.Items.Insert(0, new ListItem("--Select---", "0"));
                    //ddlprimarycontact.Items.Insert(0, new ListItem("--Select---", "0"));
                    //ddlprimarycontact.SelectedIndex = 0;

                }
            }

        }
        protected void gvOpenOpportunities_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DataTable dt = (DataTable)ViewState["dt_openopp"];

                    if (dt.Rows.Count > 0)
                    {

                        int count = dt.Rows.Count;
                        //string oppId = dt.Rows[e.Row.RowIndex].ItemArray[0].ToString();

                        int index = 0;
                        int rowcount = dt.Rows.Count;
                        int rowIndexForGrid = e.Row.RowIndex;
                        index = rowIndexForGrid;

                        if (ViewState["CurrentPageIndex"] != null)
                        {
                            int pageindex = Convert.ToInt32(ViewState["CurrentPageIndex"]);
                            int rowindexForDataTable = (gvOpenOpportunities.PageSize * (pageindex - 1)) + rowIndexForGrid;
                            index = rowindexForDataTable;
                        }
                        string oppId = dt.Rows[index].ItemArray[0].ToString();

                        DataSet OpportunityAssign = new BLL.HomeScreensBLL().getStatusAssign(oppId);

                        if (OpportunityAssign.Tables[0].Rows.Count > 0)
                        {
                            if ((OpportunityAssign.Tables[0].Rows[0].ItemArray[1].ToString() == string.Empty) || (OpportunityAssign.Tables[0].Rows[0].ItemArray[2].ToString() == string.Empty) || (OpportunityAssign.Tables[0].Rows[0].ItemArray[3].ToString() == string.Empty) || (OpportunityAssign.Tables[0].Rows[0].ItemArray[4].ToString() == string.Empty) || (OpportunityAssign.Tables[0].Rows[0].ItemArray[6].ToString() == string.Empty) || (OpportunityAssign.Tables[0].Rows[0].ItemArray[7].ToString() == string.Empty))
                            {
                                LinkButton lbDate = new LinkButton();
                                lbDate = (LinkButton)e.Row.FindControl("OppIDLnkButton");
                                lbDate.Enabled = false;
                                lbDate.ForeColor = System.Drawing.Color.Gray;

                                LinkButton lnkAssign1 = new LinkButton();
                                lnkAssign1 = (LinkButton)e.Row.FindControl("OppIDLnkButton");
                                lnkAssign1.Enabled = false;
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

                        TextBox txtDate1 = new TextBox();
                        txtDate1 = (TextBox)e.Row.FindControl("txtEditReview");
                        if (txtDate1.Text == string.Empty)
                        {
                            LinkButton lnkAssign = new LinkButton();
                            lnkAssign = (LinkButton)e.Row.FindControl("lnkCustomer");
                            lnkAssign.Enabled = false;
                            lnkAssign.ForeColor = System.Drawing.Color.Gray;
                        }
                        TextBox txtDate = new TextBox();
                        txtDate = (TextBox)e.Row.FindControl("txtEditReview");

                        txtDate.Enabled = false;

                        txtDate = (TextBox)e.Row.FindControl("txtStartDat");

                        txtDate.Enabled = false;

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
        protected void btnassignBC_Click(object sender, EventArgs e)
        {
            try
            {
                string _stroppid = (string)ViewState["oppid"];
                string _strbidcoordinatorprimary = ddlprimarycontact.SelectedValue.ToString();
                string _strbidcoordinatorsecondary = string.Empty;
                bool _boolassignstatus = new BLL.Assign().AssignDMSpoc(_stroppid, _strbidcoordinatorprimary, _strbidcoordinatorsecondary);
                int Id = (int)Session["Designation"];
                //int AssigneeId = 10;           
                int AssigneeId = new BLL.HomeScreensBLL().GetDesignationIdByDesgDesc("Delivery Manager SPoC");


                DataSet ds = new BLL.HomeScreensBLL().AssignStatus((string)ViewState["oppid"], "Assigned", Id, AssigneeId);
                GetStakeholderstoApproveRGYChecklist(_strbidcoordinatorprimary);
                int DesignationId = (int)Session["Designation"];

                //div_openoppr.Visible = false;
                //div_closedoppr.Visible = false;
                string UserId = (string)Session["UserID"];
                loadGridview(UserId, DesignationId);
                //Response.Redirect("~/FrmHomeScreenForDeliveryMgr.aspx");
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
                    if (e.CommandName == "Assign")
                    {
                        ddlprimarycontact.SelectedIndex = 0;

                        int RowIndex = Convert.ToInt32(e.CommandArgument);
                        //GridViewRow row = gvOpenOpportunities.Rows[RowIndex];
                        //DataTable dt = (DataTable)ViewState["dt_openopp"];
                        //string oppid = dt.Rows[RowIndex]["opportnumber"].ToString();
                        ViewState["oppid"] = oppid;
                        string status = dt.Rows[currentRowIndexForDataTable]["Status"].ToString();
                        //commented on 20 March
                        //if (status == "Reassign")
                        //{
                        //    DataTable dt1 = new BLL.Assign().getDMgrPrimarySecondaryContact(oppid);
                        //    if (dt1.Rows[0][0].ToString() != string.Empty)
                        //    {
                        //        //ddlprimarycontactsales.Enabled = false;
                        //        //ddlsecondarycontactsales.Enabled = false;
                        //        DataSet dtUserName = new BLL.HomeScreensBLL().getlblPrimarySecondaryContact("", "", dt1.Rows[0][2].ToString());

                        //        //ddlprimarycontactsales.SelectedValue = dt1.Rows[0][0].ToString();
                        //        //ddlsecondarycontactsales.SelectedValue = dt1.Rows[0][1].ToString();

                        //        if (dtUserName.Tables[2].Rows.Count > 0)
                        //        {
                        //            lbldisplayPrimaryContact.Text = dtUserName.Tables[2].Rows[0][0].ToString();
                        //        }
                        //    }
                        //}
                        //End Comments
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

                                    DataSet dtUserName = new BLL.HomeScreensBLL().getlblPrimarySecondaryContact(dt1.Rows[0][0].ToString(), dt1.Rows[0][1].ToString(), dt1.Rows[0][2].ToString());
                                    if (dtUserName.Tables.Count > 0 && dtUserName.Tables[2].Rows.Count > 0)
                                    {
                                        lbldisplayPrimaryContact.Text = dtUserName.Tables[2].Rows[0][0].ToString();

                                    }
                                }

                            }
                        }

                        //if (ViewState["UnassignStatus"] != null)
                        //{
                        //    string _strUnassign = ViewState["UnassignStatus"].ToString();
                        //    if (_strUnassign.Trim() == "Unassign")
                        //    {
                        //        DataTable dt1 = new BLL.Assign().getddlPrimarySecondaryContact((string)ViewState["oppid"]);
                        //        ddlprimarycontactsales.Enabled = false;
                        //        ddlsecondarycontactsales.Enabled = false;
                        //        fillBidManagers();
                        //        ddlprimarycontactsales.SelectedValue = dt1.Rows[0][0].ToString();
                        //        ddlsecondarycontactsales.SelectedValue = dt1.Rows[0][1].ToString();
                        //        btnReassign.Visible = true;
                        //        btnassignBM.Visible = false;
                        //    }

                        //}
                    }
                    else if (e.CommandName == "OppIdRedirect")
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
                    loadGridview(UserId, DesignationId);
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

        private void GetStakeholderstoApproveRGYChecklist(string _strDeliveryDirectorPrimary)
        {
            string _strToEmail = string.Empty;
            string _strToName = string.Empty;
            string _strOppNumber = (string)ViewState["oppid"];
            string _strOppName = string.Empty;

            DataSet dsStakeHoldersDetails = new BLL.AutomatedMailBLL().getEmailAddresses(_strDeliveryDirectorPrimary, string.Empty);

            if (dsStakeHoldersDetails.Tables.Count > 0)
            {
                if (dsStakeHoldersDetails.Tables[0].Rows.Count > 0)
                {
                    _strToName = dsStakeHoldersDetails.Tables[0].Rows[0][0].ToString();
                    _strToEmail = dsStakeHoldersDetails.Tables[0].Rows[0][1].ToString();
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
            string _EmailBody = "<html><body><div style='border:1px solid black;padding:10px;font-family:arial'> Dear " + _strToName + " ";
            _EmailBody += "</br>";
            _EmailBody += "</br>";
            _EmailBody += "<p style='colr:red;'>RFP<b>" + _strOppName + "</b>(<b>" + _strOppNumber + "</b>)" + " has been assigned to you by <b>Delivery Manager</b></p> ";
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

            MailMessage myhtmlMessage = new MailMessage(fromAddress.ToString(), _strToEmail, "Automated Mail for Assigned Status of Delivery Manager", _EmailBody);
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

        protected void gvCloseOpportunities_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvCloseOpportunities.PageIndex = e.NewPageIndex;
                ViewState["CurrentPageIndexForClose"] = e.NewPageIndex + 1;
                loadGridviewForClosed(UserId);
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

        protected void gvOpenOpportunities_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvOpenOpportunities.PageIndex = e.NewPageIndex;
                loadGridview(UserId, DesignationId);
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
