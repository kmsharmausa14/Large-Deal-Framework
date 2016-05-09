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

namespace LargeDealFrameWork
{
    public partial class HomeScreenForGPTManager : System.Web.UI.Page
    {
        int DesignationId = 0;
        string UserId = string.Empty;
        protected void btnassignBC_Click(object sender, EventArgs e)
        {
            string _stroppid = (string)ViewState["oppid"];
            string _strbidcoordinatorprimary = string.Empty;
            if (ddlprimarycontact.SelectedValue.ToString() != "0")
            {
                _strbidcoordinatorprimary = ddlprimarycontact.SelectedValue.ToString();
            }
            string _strbidcoordinatorsecondary = string.Empty;
            if (ddlsecondarycontact.SelectedValue.ToString() != "0")
            {
                _strbidcoordinatorsecondary = ddlsecondarycontact.SelectedValue.ToString();
            }

            //string _strbidcoordinatorsecondary = ddlsecondarycontact.SelectedValue.ToString();
            bool _boolassignstatus = new BLL.Assign().AssignBC(_stroppid, _strbidcoordinatorprimary, _strbidcoordinatorsecondary);
            int Id = (int)Session["Designation"];
            int AssigneeId = 0;

            //if (Id ==6)
            if (Id == clsDesignationList.GetDesignationID(EnumDesignation.VerticalPreSalesHead))
            {
                // AssigneeId = 7;
                AssigneeId = clsDesignationList.GetDesignationID(EnumDesignation.BidManager);
            }
            else
            {
                //AssigneeId = 8;
                AssigneeId = clsDesignationList.GetDesignationID(EnumDesignation.BidCoordinator);
            }
            DataSet ds = new BLL.HomeScreensBLL().AssignStatus((string)ViewState["oppid"], "Assigned", Id, AssigneeId);
            AssignOpportunityNotification(_strbidcoordinatorprimary, _strbidcoordinatorsecondary);
            if (ddlSalesPersonwithOpportunity.SelectedIndex > 0)
            {
                int DesignationId = new BLL.HomeScreensBLL().Get_DesignationByUserId(ddlSalesPersonwithOpportunity.SelectedValue);
                string verticalID = (string)Session["VertId"];
                int UserID = Convert.ToInt32(ddlSalesPersonwithOpportunity.SelectedValue);
                string UserID1 = Convert.ToString(ddlSalesPersonwithOpportunity.SelectedValue);
                int VerticalId = Convert.ToInt32(ddlVerticalWithOpportunity.SelectedValue);
                loadGridviewSales(UserID1, DesignationId, VerticalId);
                loadGridviewGPTClosedSales(UserID1, DesignationId, VerticalId);
            }
            //Response.Redirect("~/FrmHomeScreenforGPTManager.aspx");
        }

        protected void btnassignBM_Click(object sender, EventArgs e)
        {
            string _stroppid = (string)ViewState["oppid"];
            string _strbidmanagerprimary = ddlprimarycontactsales.SelectedValue.ToString();
            string _strbidmanagersecondary = ddlsecondarycontactsales.SelectedValue.ToString();
            bool _boolassignstatus = new BLL.Assign().AssignBM(_stroppid, _strbidmanagerprimary, _strbidmanagersecondary);
            int Id = (int)Session["Designation"];
            int AssigneeId = 0;
            //if (Id == 6)
            if (Id == clsDesignationList.GetDesignationID(EnumDesignation.VerticalPreSalesHead))
            {
                //AssigneeId = 7;
                AssigneeId = clsDesignationList.GetDesignationID(EnumDesignation.BidManager);
            }
            else
            {
                //AssigneeId = 8;
                AssigneeId = clsDesignationList.GetDesignationID(EnumDesignation.BidCoordinator);
            }
            DataSet ds = new BLL.HomeScreensBLL().AssignStatus((string)ViewState["oppid"], "Assigned", Id, AssigneeId);
            AssignOpportunityNotification(_strbidmanagerprimary, _strbidmanagersecondary);
            //if (ddlVerticalWithOpportunity.SelectedIndex > 0)
            //{
            //    string _intDesgId = (ddlVerticalWithOpportunity.SelectedValue);
            //    FillDdlSalesPersonOppor(_intDesgId);
            //}
            //Response.Redirect("~/FrmHomeScreenforGPTManager.aspx");
            if (ddlSalesPersonwithOpportunity.SelectedIndex > 0)
            {
                int DesignationId = new BLL.HomeScreensBLL().Get_DesignationByUserId(ddlSalesPersonwithOpportunity.SelectedValue);
                string verticalID = (string)Session["VertId"];
                string UserID2 = Convert.ToString(ddlSalesPersonwithOpportunity.SelectedValue);
                //string VerticalID = string.Empty;
                loadGridviewVerticalPresalesClosedSales(UserID2, verticalID);
                loadGridviewVerticalPreSales(UserID2, DesignationId, verticalID);
            }
        }


        private DataSet GetCountOpportunity(string UserId, string designationId)
        {
            int DesignationId = (int)Session["Designation"];
            string UserId1 = (string)Session["UserID"];
            //if (DesignationId == 14)
            if (DesignationId == clsDesignationList.GetDesignationID(EnumDesignation.GPTHead))
            {
                DataSet dsGetCount = new BLL.HomeScreensBLL().GetCountOpenLargeNonLargeDealOpportunity(UserId1, designationId);

                if (dsGetCount.Tables.Count > 0)
                {
                    if (dsGetCount.Tables[0].Rows.Count > 0)
                    {
                        lblOpenCount.Text = "(" + dsGetCount.Tables[0].Rows[0][0].ToString() + ")";
                        lblCloseCount.Text = "(" + dsGetCount.Tables[0].Rows[0][1].ToString() + ")";
                        lblLargeCount.Text = "(" + dsGetCount.Tables[0].Rows[0][2].ToString() + ")";
                        lblNonLargeCount.Text = "(" + dsGetCount.Tables[0].Rows[0][3].ToString() + ")";
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
            else
            {
                string verticalID = (string)Session["VertId"];
                DataSet dsGetCount = new BLL.HomeScreensBLL().GetCountDDOpenLargeNonLargeDealOpportunity(verticalID);
                if (dsGetCount.Tables.Count > 0)
                {
                    if (dsGetCount.Tables[0].Rows.Count > 0)
                    {
                        lblOpenCount.Text = "(" + dsGetCount.Tables[0].Rows[0][0].ToString() + ")";
                        lblCloseCount.Text = "(" + dsGetCount.Tables[0].Rows[0][1].ToString() + ")";
                        lblLargeCount.Text = "(" + dsGetCount.Tables[0].Rows[0][2].ToString() + ")";
                        lblNonLargeCount.Text = "(" + dsGetCount.Tables[0].Rows[0][3].ToString() + ")";
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

        }


        protected void Page_Load(object sender, EventArgs e)
        {
            DesignationId = (int)Session["Designation"];
            UserId = (string)Session["UserID"];
            if (Session["UserID"] == null)
            {
                Response.Redirect("/Login/SignInPage.aspx");
            }
            if (!IsPostBack)
            {
                checkpostback.Value = "1";
                int VerticalId = Convert.ToInt16(ddlVerticalWithOpportunity.SelectedValue);
                FillDdlVerticalOpp(UserId);
                //if (DesignationId == 6)
                if (DesignationId == clsDesignationList.GetDesignationID(EnumDesignation.VerticalPreSalesHead))
                {

                    FillDdlSalesPersonOppor1(DesignationId);
                    string verticalID = (string)Session["VertId"];
                    //GetCountOpportunityCountDD(UserId, DesignationId.ToString(), verticalID);
                    //div_openoppr.Visible = false;
                    //div_closedoppr.Visible = false;
                    tabs.Visible = false;
                    lblselect.Visible = true;
                    fillBidManagers();
                    lblselectvertical.Visible = false;
                    ddlVerticalWithOpportunity.Visible = false;

                }
                else
                {
                    fillBidCordinators();
                }

                GetCountOpportunity(UserId, DesignationId.ToString());

            }
            if (IsPostBack)
            {
                checkpostback.Value = "0";
            }
        }
        /// <summary>
        /// Filling Vertical with opportunity dropdown
        /// </summary>
        protected void FillDdlVerticalOpp(string UserId)
        {

            DataSet VerticalOpportunity_details = new BLL.HomeScreensBLL().Get_VerticalWithOpportunityDetails(UserId);
            if (VerticalOpportunity_details.Tables.Count > 0)
            {
                if (VerticalOpportunity_details.Tables[0].Rows.Count > 0)
                {
                    ddlVerticalWithOpportunity.DataSource = VerticalOpportunity_details.Tables[0];
                    ddlVerticalWithOpportunity.DataTextField = "VerticalName";
                    ddlVerticalWithOpportunity.DataValueField = "vspkVertId";
                    ddlVerticalWithOpportunity.DataBind();
                    ddlVerticalWithOpportunity.Items.Insert(0, new ListItem("--Select---", "0"));
                    ddlVerticalWithOpportunity.SelectedIndex = 0;
                }
            }
        }
        protected void gvOpenOpportunities_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            lbldisplayPrimaryContact.Text = "";
            lbldisplaySecondaryContact.Text = "";
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

                int currentRowIndexForDataTable = (gvOpenOpportunities.PageSize * (pageindex - 1)) + RowIndexForGrid;
                if (e.CommandName == "Assign")
                {

                    //int RowIndex = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = gvOpenOpportunities.Rows[RowIndexForGrid];
                    DataTable dt = (DataTable)ViewState["dt_openopp"];

                    string oppid = dt.Rows[currentRowIndexForDataTable]["OpportunityNo"].ToString();
                    ViewState["oppid"] = oppid;
                    string status = dt.Rows[currentRowIndexForDataTable]["OppStatus"].ToString();
                    if (ViewState["UnassignStatus"] != null)
                    {
                        string _strUnassign = ViewState["UnassignStatus"].ToString();
                        if (_strUnassign.Trim() == "Reassign")
                        {
                            if ((int)Session["Designation"] == clsDesignationList.GetDesignationID(EnumDesignation.GPTHead))
                            {
                                DataTable dt1 = new BLL.Assign().getGPTPrimarySecondaryContact((string)ViewState["oppid"]);
                                if (dt1.Rows[0][0].ToString() != string.Empty)
                                {
                                    DataSet dtUserName = new BLL.HomeScreensBLL().getlblPrimarySecondaryContact(dt1.Rows[0][0].ToString(), dt1.Rows[0][1].ToString(), "");
                                    fillBidManagers();
                                    //if ((dtUserName.Tables[0].Rows.Count > 0) && (dtUserName.Tables[1].Rows.Count > 0))
                                    if (dtUserName.Tables[0].Rows.Count > 0)
                                    {
                                        lbldisplayPrimaryContact.Text = dtUserName.Tables[0].Rows[0][0].ToString();

                                    }
                                    if (dtUserName.Tables[1].Rows.Count > 0)
                                    {
                                        lbldisplaySecondaryContact.Text = dtUserName.Tables[1].Rows[0][0].ToString();
                                    }
                                }
                            }
                            else if ((int)Session["Designation"] == clsDesignationList.GetDesignationID(EnumDesignation.VerticalPreSalesHead))
                            {
                                DataTable dt1 = new BLL.Assign().getVPPrimarySecondaryContact((string)ViewState["oppid"]);
                                DataSet dtUserName = new BLL.HomeScreensBLL().getlblPrimarySecondaryContact(dt1.Rows[0][0].ToString(), dt1.Rows[0][1].ToString(), "");
                                if (dtUserName.Tables.Count > 0)
                                {
                                    if (dtUserName.Tables[0].Rows.Count > 0)
                                    {
                                        lbldisplayprimarycontactsales.Text = dtUserName.Tables[0].Rows[0][0].ToString();
                                    }
                                    if (dtUserName.Tables[1].Rows.Count > 0)
                                    {
                                        lbldisplaysecondarycontactsales.Text = dtUserName.Tables[1].Rows[0][0].ToString();
                                    }
                                }
                                if (dt1.Rows[0][0].ToString() != string.Empty)
                                {

                                    fillBidManagers();
                                }
                            }
                            else
                            {


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


                string verticalID = (string)Session["VertId"];
                string UserID2 = Convert.ToString(ddlSalesPersonwithOpportunity.SelectedValue);
                DesignationId = new BLL.HomeScreensBLL().Get_DesignationByUserId(ddlSalesPersonwithOpportunity.SelectedValue);
                int designationid = (int)Session["Designation"];
                //string VerticalID = string.Empty;
                //loadGridviewVerticalPresalesClosedSales(UserID2, verticalID);
                if (designationid == clsDesignationList.GetDesignationID(EnumDesignation.VerticalPreSalesHead))
                {
                    loadGridviewVerticalPreSales(UserID2, DesignationId, verticalID);
                }
                tabs.Visible = true;
                lblselect.Visible = false;

                string UserID1 = Convert.ToString(ddlSalesPersonwithOpportunity.SelectedValue);

                int VerticalId = Convert.ToInt32(ddlVerticalWithOpportunity.SelectedValue);

                int Id = (int)Session["Designation"];
                string SalesUserId = Convert.ToString(ddlSalesPersonwithOpportunity.SelectedValue);
                if (designationid == clsDesignationList.GetDesignationID(EnumDesignation.GPTHead))
                {
                    loadGridviewSales(UserID1, DesignationId, VerticalId);
                }
            }

        }

        //protected void gvCloseOpportunities_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    try
        //    {
        //        //DataSet dsPopulateCloseOpportunity = new BLL.HomeScreensBLL().getClosedOpportunity((string)Session["UserID"]);
        //        DataSet dsGetFlag = new BLL.HomeScreensBLL().GetFlag((string)Session["UserID"]);

        //        //int intRowCount = dsPopulateCloseOpportunity.Tables[0].Rows.Count;

        //        if (e.Row.RowType == DataControlRowType.DataRow)
        //        {
        //            TextBox txtDate = new TextBox();
        //            txtDate = (TextBox)e.Row.FindControl("txtEditReview");

        //            txtDate.Enabled = false;

        //            txtDate = (TextBox)e.Row.FindControl("txtStartDat");

        //            txtDate.Enabled = false;
        //            txtDate = (TextBox)e.Row.FindControl("txtCloseDate");

        //            txtDate.Enabled = false;

        //            if (dsGetFlag.Tables.Count > 0)
        //            {
        //                if (dsGetFlag.Tables[0].Rows.Count > 0)
        //                {
        //                    if (dsGetFlag.Tables[0].Rows[(e.Row.RowIndex)][2].ToString().Trim() == "No Go")
        //                    {
        //                        DropDownList dropDownListStatus = (DropDownList)e.Row.FindControl("ddlstatus");
        //                        dropDownListStatus.SelectedIndex = 3;
        //                        dropDownListStatus.Enabled = false;
        //                        LinkButton lnkButtonOppId = (LinkButton)e.Row.FindControl("OppIDLnkButton");
        //                        lnkButtonOppId.Enabled = false;
        //                        lnkButtonOppId.ForeColor = System.Drawing.Color.Black;
        //                        //btnSubmit.Visible = false;
        //                    }

        //                    else if (dsGetFlag.Tables[0].Rows[(e.Row.RowIndex)][2].ToString().Trim() == string.Empty || dsGetFlag.Tables[0].Rows[(e.Row.RowIndex)][2].ToString().Trim() == "Approved")
        //                    {
        //                        if (dsGetFlag.Tables.Count > 0)
        //                        {
        //                            if (dsGetFlag.Tables[0].Rows.Count > 0)
        //                            {
        //                                if (dsGetFlag.Tables[0].Rows[(e.Row.RowIndex)][3].ToString().Trim().Contains("0"))
        //                                {
        //                                    DropDownList dropDownListStatus = (DropDownList)e.Row.FindControl("ddlstatus");
        //                                    dropDownListStatus.SelectedIndex = 0;
        //                                    dropDownListStatus.Enabled = false;
        //                                }

        //                                else
        //                                {
        //                                    DropDownList dropDownListStatus = (DropDownList)e.Row.FindControl("ddlstatus");
        //                                    dropDownListStatus.SelectedIndex = 0;
        //                                    dropDownListStatus.Enabled = true;
        //                                    //dropDownListStatus.SelectedIndexChanged+=new EventHandler()
        //                                }
        //                            }
        //                        }
        //                    }

        //                    else
        //                    {
        //                        DropDownList dropDownListStatus = (DropDownList)e.Row.FindControl("ddlstatus");
        //                        dropDownListStatus.SelectedItem.Text = dsGetFlag.Tables[0].Rows[(e.Row.RowIndex)][2].ToString();
        //                        dropDownListStatus.Enabled = false;
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        string _strErrorMessage = string.Format("{0}", ex.Message.ToString());

        //        var cleanChars = _strErrorMessage.Where(c => !"\n\r".Contains(c));
        //        string cleanText = new string(cleanChars.ToArray());

        //        Response.Redirect("/frmErrorPage.aspx?ErrorMessage=" + cleanText);
        //    }


        //}
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
                                LinkButton lnkButtonOppId = (LinkButton)e.Row.FindControl("ClosedOppIDLnkButton");
                                lnkButtonOppId.Enabled = false;
                                lnkButtonOppId.ForeColor = System.Drawing.Color.Black;
                                //btnSubmit.Visible = false;
                            }

                            else if (dsGetFlag.Tables[0].Rows[(index)][2].ToString().Trim() == string.Empty || dsGetFlag.Tables[0].Rows[(index)][2].ToString().Trim() == "Approved"
                                    || dsGetFlag.Tables[0].Rows[(index)][2].ToString().Trim() == "Win" || dsGetFlag.Tables[0].Rows[(index)][2].ToString().Trim() == "Loss" 
                                    || dsGetFlag.Tables[0].Rows[(index)][2].ToString().Trim() == "Hold")
                            {
                                LinkButton lnkButtonOppId = (LinkButton)e.Row.FindControl("ClosedOppIDLnkButton");
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

            catch (Exception ex)
            {
                string _strErrorMessage = string.Format("{0}", ex.Message.ToString());

                var cleanChars = _strErrorMessage.Where(c => !"\n\r".Contains(c));
                string cleanText = new string(cleanChars.ToArray());

                Response.Redirect("/frmErrorPage.aspx?ErrorMessage=" + cleanText);
            }


        }

        protected void gvClosedOpportunities_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            lbldisplayPrimaryContact.Text = "";
            lbldisplaySecondaryContact.Text = "";
            if (e.CommandName == "OppIdRedirect")
            {
                string OppIDRedirect = string.Empty;
                int RowIndecs = Convert.ToInt32(e.CommandArgument);
                GridViewRow grow = gvCloseOpportunities.Rows[RowIndecs];
                LinkButton lnkopp = null;
                lnkopp = (LinkButton)grow.FindControl("ClosedOppIDLnkButton");
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

        //protected void gvGPTOpenOpportunities_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    lbldisplayPrimaryContact.Text = "";
        //    lbldisplaySecondaryContact.Text = "";
        //    if (e.CommandName == "OppIdRedirect")
        //    {
        //        string OppIDRedirect = string.Empty;
        //        int RowIndecs = Convert.ToInt32(e.CommandArgument);
        //        GridViewRow grow = GridViewGPTMember.Rows[RowIndecs];
        //        LinkButton lnkopp = null;
        //        lnkopp = (LinkButton)grow.FindControl("OppIDLnkButton");
        //        OppIDRedirect = lnkopp.Text;
        //        Response.Redirect("/FrmQualificationmain.aspx?OppID=" + OppIDRedirect);
              
        //    }
        //}
        protected void ddlVerticalWithOpportunity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlVerticalWithOpportunity.SelectedIndex > 0)
            {
                int Id = (int)Session["Designation"];
                FillDdlSalesPersonOppor(Convert.ToString(ddlVerticalWithOpportunity.SelectedValue));

            }
            else
            {
                gvOpenOpportunities.DataSource = null;
                gvOpenOpportunities.DataBind();
                ddlSalesPersonwithOpportunity.DataSource = null;
                ddlSalesPersonwithOpportunity.DataBind();
                ddlSalesPersonwithOpportunity.Items.Clear();

            }
        }
        /// <summary>
        /// Filling Sales Person with opportunity DropDownlist
        /// </summary>
        /// <param name="VerticalID"></param>
        protected void FillDdlSalesPersonOppor(string Id)
        {
            //string UserId = (string)Session["UserID"];

            DataSet SalesPersonOpportunity_details = new BLL.HomeScreensBLL().Get_SalesPersonWithOpportunityDetails(Id);
            if (SalesPersonOpportunity_details.Tables.Count > 0)
            {
                if (SalesPersonOpportunity_details.Tables[0].Rows.Count > 0)
                {

                    ddlSalesPersonwithOpportunity.DataSource = SalesPersonOpportunity_details.Tables[0];
                    ddlSalesPersonwithOpportunity.DataTextField = "SalesName";
                    ddlSalesPersonwithOpportunity.DataValueField = "vsSalesID";
                    ddlSalesPersonwithOpportunity.DataBind();

                    ddlSalesPersonwithOpportunity.Items.Insert(0, new ListItem("--Select---", "0"));
                    ddlSalesPersonwithOpportunity.SelectedIndex = 0;
                }
            }
        }

        protected void FillDdlSalesPersonOppor1(int Id1)
        {
            //string UserId = (string)Session["UserID"];
            // string UserID = (string)Session["UserID"];
            string verticalID = (string)Session["VertId"];
            //string Id2 = Convert.ToString(new BLL.HomeScreensBLL().Get_VerticalPresales(UserID));
            DataSet SalesPersonOpportunity_details = new BLL.HomeScreensBLL().Get_SalesPersonWithOpportunityDetails1(verticalID);
            if (SalesPersonOpportunity_details.Tables.Count > 0)
            {
                if (SalesPersonOpportunity_details.Tables[0].Rows.Count > 0)
                {

                    ddlSalesPersonwithOpportunity.DataSource = SalesPersonOpportunity_details.Tables[0];
                    ddlSalesPersonwithOpportunity.DataTextField = "SalesName";
                    ddlSalesPersonwithOpportunity.DataValueField = "vsSalesID";
                    ddlSalesPersonwithOpportunity.DataBind();

                    ddlSalesPersonwithOpportunity.Items.Insert(0, new ListItem("--Select---", "0"));
                    ddlSalesPersonwithOpportunity.SelectedIndex = 0;
                }
            }
        }
        /// <summary>
        /// Filling the gridview on select index changes even of sales person
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlSalesPersonwithOpportunity_SelectedIndexChanged(object sender, EventArgs e)
        {
            int DesignationId = 0;
            checkpostback.Value = "1";
            gvOpenOpportunities.DataSource = null;
            gvOpenOpportunities.DataBind();
            gvCloseOpportunities.DataSource = null;
            gvCloseOpportunities.DataBind();
            lblClosedNoRecords.Text = string.Empty;
            lblOpenNoRecords.Text = string.Empty;
            ViewState["CurrentPageIndex"] = null;
            if (ddlSalesPersonwithOpportunity.SelectedIndex > 0)
            {
                DesignationId = new BLL.HomeScreensBLL().Get_DesignationByUserId(ddlSalesPersonwithOpportunity.SelectedValue);
                int Id = (int)Session["Designation"];
                string SalesUserId = Convert.ToString(ddlSalesPersonwithOpportunity.SelectedValue);
                string UserID1 = Convert.ToString(ddlSalesPersonwithOpportunity.SelectedValue);
                int VerticalId = Convert.ToInt32(ddlVerticalWithOpportunity.SelectedValue);
                int designationid = (int)Session["Designation"];
                int Id1 = (int)Session["Designation"];
                string UserID = (string)Session["UserID"];
                //if (designationid == 6)
                if (designationid == clsDesignationList.GetDesignationID(EnumDesignation.VerticalPreSalesHead))
                {
                    string verticalID = (string)Session["VertId"];
                    string UserID2 = Convert.ToString(ddlSalesPersonwithOpportunity.SelectedValue);
                    //string VerticalID = string.Empty;
                    loadGridviewVerticalPresalesClosedSales(UserID2, verticalID);
                    loadGridviewVerticalPreSales(UserID2, DesignationId, verticalID);
                    tabs.Visible = true;
                    lblselect.Visible = false;
                }
                else
                {
                    loadGridviewSales(UserID1, DesignationId, VerticalId);
                    loadGridviewGPTClosedSales(SalesUserId, DesignationId, VerticalId);

                }


            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Message", "alert('Select A SalesPerson')");
                gvOpenOpportunities.DataSource = null;
                gvOpenOpportunities.DataBind();
                int designationid = (int)Session["Designation"];
                if (designationid == clsDesignationList.GetDesignationID(EnumDesignation.VerticalPreSalesHead))
                {
                    tabs.Visible = false;
                    lblselect.Visible = true;
                }

            }
        }


        /// <summary>
        /// Load the gridview based on salesperson id and desigantion 
        /// also vertical 
        /// </summary>
        /// <param name="SalesUserId"></param>
        /// <param name="DesignationId"></param>
        protected void loadGridviewSales(string UserID, int designationid, int VerticalId)
        {
            div_openoppr.Visible = true;
            div_closedoppr.Visible = true;
            if ((int)Session["Designation"] == clsDesignationList.GetDesignationID(EnumDesignation.GPTHead))
            {
                DataSet Opportunity_details = new BLL.HomeScreensBLL().Get_OpenOpportunityDetails(UserID, designationid, VerticalId);
                DataTable dt_openopp = new DataTable();
                dt_openopp.Columns.Add("OpportunityNo");
                dt_openopp.Columns.Add("OpportunityDescription");
                dt_openopp.Columns.Add("StartDate");
                dt_openopp.Columns.Add("SubmissionDate");
                dt_openopp.Columns.Add("OppStatus");

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
                    if (!string.IsNullOrEmpty(Opportunity_details.Tables[0].Rows[i].ItemArray[4].ToString()))
                    {
                        if (Convert.ToBoolean(Opportunity_details.Tables[0].Rows[i].ItemArray[4].ToString()) == false)
                        {
                            DataRow dr = dt_openopp.NewRow();
                            dr["OpportunityNo"] = Opportunity_details.Tables[0].Rows[i].ItemArray[0].ToString();
                            dr["StartDate"] = Opportunity_details.Tables[0].Rows[i].ItemArray[2].ToString();
                            dr["SubmissionDate"] = Opportunity_details.Tables[0].Rows[i].ItemArray[3].ToString();
                            dr["OpportunityDescription"] = Opportunity_details.Tables[0].Rows[i].ItemArray[5].ToString();
                            //dr["status"] = Opportunity_details.Tables[0].Rows[i].ItemArray[1].ToString();
                            string oppId = Opportunity_details.Tables[0].Rows[i].ItemArray[0].ToString();
                            // DataTable ds = new BLL.Assign().getVPSHPrimarySecondaryContact(oppId);
                            DataTable ds = new BLL.Assign().getPrimarySecondaryContact(oppId);
                            if (ds.Rows.Count > 0)
                            {
                                if (ds.Rows[0][0].ToString() == "Assigned")
                                {
                                    dr["OppStatus"] = "Reassign";
                                    ViewState["UnassignStatus"] = dr["OppStatus"];
                                }
                                else
                                {
                                    dr["OppStatus"] = "Assign";
                                }
                            }
                            else
                            {
                                dr["OppStatus"] = "Assign";
                            }
                            dt_openopp.Rows.Add(dr);

                        }
                    }
                }
                gvOpenOpportunities.DataSource = dt_openopp;
                ViewState["dt_openopp"] = dt_openopp;
                gvOpenOpportunities.DataBind();
            }
            //else //GPT Member Code
            //{
            //    DataSet Opportunity_details1 = new BLL.HomeScreensBLL().Get_OpenOpportunityDetails(UserID, designationid, VerticalId);
            //    DataTable dt_openopp1 = new DataTable();
            //    dt_openopp1.Columns.Add("OpportunityNo");
            //    dt_openopp1.Columns.Add("OpportunityDescription");
            //    dt_openopp1.Columns.Add("StartDate");
            //    dt_openopp1.Columns.Add("SubmissionDate");
            //    ////dt_openopp.Columns.Add("OppStatus");

            //    int count1 = Opportunity_details1.Tables[0].Rows.Count;
            //    if (count1 == 0)
            //    {
            //        lblOpenNoRecords.Visible = true;
            //        lblOpenNoRecords.Text = "No Records found!!!";
            //    }
            //    else
            //    {
            //        lblOpenNoRecords.Visible = false;
            //    }
            //    for (int i = 0; i <= count1 - 1; i++)
            //    {
            //        if (!string.IsNullOrEmpty(Opportunity_details1.Tables[0].Rows[i].ItemArray[4].ToString()))
            //        {
            //            if (Convert.ToBoolean(Opportunity_details1.Tables[0].Rows[i].ItemArray[4].ToString()) == false)
            //            {
            //                DataRow dr1 = dt_openopp1.NewRow();
            //                dr1["OpportunityNo"] = Opportunity_details1.Tables[0].Rows[i].ItemArray[0].ToString();
            //                dr1["StartDate"] = Opportunity_details1.Tables[0].Rows[i].ItemArray[2].ToString();
            //                dr1["SubmissionDate"] = Opportunity_details1.Tables[0].Rows[i].ItemArray[3].ToString();
            //                dr1["OpportunityDescription"] = Opportunity_details1.Tables[0].Rows[i].ItemArray[5].ToString();
            //                //dr["status"] = Opportunity_details.Tables[0].Rows[i].ItemArray[1].ToString();
            //                string oppId = Opportunity_details1.Tables[0].Rows[i].ItemArray[0].ToString();
            //                // DataTable ds = new BLL.Assign().getVPSHPrimarySecondaryContact(oppId);
            //                DataTable ds = new BLL.Assign().getPrimarySecondaryContact(oppId);
            //                dt_openopp1.Rows.Add(dr1);
            //            }
            //        }
            //    }
            //    GridViewGPTMember.DataSource = Opportunity_details1;
            //    ViewState["dt_openopp1"] = dt_openopp1;
            //    GridViewGPTMember.DataBind();
            //}
        }

        protected void loadGridviewGPTClosedSales(string SalesUserId, int DesignationId, int VerticalId)
        {
            lblClosedNoRecords.Text = string.Empty;
            //lblOpenNoRecords.Text = string.Empty;
            DataSet Opportunity_detailsSales = new BLL.HomeScreensBLL().Get_ClosedOpportunityDetails(SalesUserId, DesignationId, VerticalId);
            if (Opportunity_detailsSales.Tables[0].Rows.Count == 0)
            {
                lblClosedNoRecords.Visible = true;
                lblClosedNoRecords.Text = "No Records found!!!";
                gvCloseOpportunities.DataSource = null;
                gvCloseOpportunities.DataBind();
            }
            else
            {
                lblClosedNoRecords.Visible = false;
                gvCloseOpportunities.DataSource = Opportunity_detailsSales;
                gvCloseOpportunities.DataBind();
            }
         
        }
        //protected void loadGridviewSalesVertical(string verticalId)
        //{
        protected void loadGridviewVerticalPreSales(string UserID, int designationid, string verticalID)
        {
            div_openoppr.Visible = true;
            div_closedoppr.Visible = true;

            //lblClosedNoRecords.Text = string.Empty;
            lblOpenNoRecords.Text = string.Empty;
            // string Vertical = new BLL.HomeScreensBLL().Get_VerticalPresales(UserID);
            verticalID = (string)Session["VertId"];
            DataSet Opportunity_details = new BLL.HomeScreensBLL().Get_VerticalPreSalesOpenOpprDetails(UserID, designationid, verticalID);
            //DataSet Opportunity_details = new BLL.HomeScreensBLL().loadGridviewSalesVertical(verticalId);
            DataTable dt_openopp = new DataTable();
            dt_openopp.Columns.Add("OpportunityNo");
            dt_openopp.Columns.Add("OpportunityDescription");
            dt_openopp.Columns.Add("StartDate");
            dt_openopp.Columns.Add("SubmissionDate");
            dt_openopp.Columns.Add("OppStatus");

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
                if (!string.IsNullOrEmpty(Opportunity_details.Tables[0].Rows[i].ItemArray[4].ToString()))
                {
                    if (Convert.ToBoolean(Opportunity_details.Tables[0].Rows[i].ItemArray[4].ToString()) == false)
                    {
                        DataRow dr = dt_openopp.NewRow();
                        dr["OpportunityNo"] = Opportunity_details.Tables[0].Rows[i].ItemArray[0].ToString();
                        dr["OpportunityDescription"] = Opportunity_details.Tables[0].Rows[i].ItemArray[5].ToString();
                        string oppId = Opportunity_details.Tables[0].Rows[i].ItemArray[0].ToString();
                        ViewState["OppNumber"] = dr["OpportunityNo"];
                        dr["StartDate"] = Opportunity_details.Tables[0].Rows[i].ItemArray[2].ToString();
                        dr["SubmissionDate"] = Opportunity_details.Tables[0].Rows[i].ItemArray[3].ToString();

                        //DataTable ds = new BLL.Assign().getPrimarySecondaryContact(oppId);
                        DataTable ds = new BLL.Assign().getVPSHPrimarySecondaryContact(oppId);
                        if (ds.Rows.Count > 0)
                        {
                            if (ds.Rows[0][0].ToString() == "Assigned")
                            {
                                dr["OppStatus"] = "Reassign";
                                ViewState["UnassignStatus"] = dr["OppStatus"];
                            }
                            else
                            {
                                dr["OppStatus"] = "Assign";
                            }
                        }
                        else
                        {
                            dr["OppStatus"] = "Assign";
                        }
                        dt_openopp.Rows.Add(dr);


                    }
                }
            }
            gvOpenOpportunities.DataSource = dt_openopp;
            ViewState["dt_openopp"] = dt_openopp;
            gvOpenOpportunities.DataBind();
            //ViewState["dt_openopp"] = dt_openopp;
        }



        //protected void loadGridview(string SalesUserId, int DesignationId)
        //{
        //    div_openoppr.Visible = true;
        //    div_closedoppr.Visible = true;

        //    DataSet Opportunity_details = new BLL.HomeScreensBLL().Get_OpportunityDetails(SalesUserId, DesignationId);
        //    //DataSet Opportunity_details = new BLL.HomeScreensBLL().Get_ClosedOpportunityDetails(SalesUserId, DesignationId,VerticalId);
        //    DataTable dt_openopp = new DataTable();
        //    dt_openopp.Columns.Add("opportnumber");
        //    dt_openopp.Columns.Add("opportdesc");
        //    dt_openopp.Columns.Add("startdate");
        //    dt_openopp.Columns.Add("submissiondate");
        //    dt_openopp.Columns.Add("status");

        //    int count = Opportunity_details.Tables[0].Rows.Count;
        //    for (int i = 0; i <= count - 1; i++)
        //    {
        //        if (!string.IsNullOrEmpty(Opportunity_details.Tables[0].Rows[i].ItemArray[4].ToString()))
        //        {
        //            if (Convert.ToBoolean(Opportunity_details.Tables[0].Rows[i].ItemArray[4].ToString()) == false)
        //            {
        //                DataRow dr = dt_openopp.NewRow();
        //                dr["opportnumber"] = Opportunity_details.Tables[0].Rows[i].ItemArray[0].ToString();
        //                dr["startdate"] = Opportunity_details.Tables[0].Rows[i].ItemArray[2].ToString();
        //                dr["submissiondate"] = Opportunity_details.Tables[0].Rows[i].ItemArray[3].ToString();
        //                dr["opportdesc"] = Opportunity_details.Tables[0].Rows[i].ItemArray[5].ToString();
        //                //dr["status"] = Opportunity_details.Tables[0].Rows[i].ItemArray[1].ToString();
        //                string oppId = Opportunity_details.Tables[0].Rows[i].ItemArray[0].ToString();
        //                DataTable ds = new BLL.Assign().getPrimarySecondaryContact(oppId);
        //                if (ds.Rows.Count > 0)
        //                {
        //                    if (ds.Rows[0][0].ToString() == "Assigned")
        //                    {
        //                        dr["status"] = "Reassign";
        //                        ViewState["UnassignStatus"] = dr["status"];
        //                    }
        //                    else
        //                    {
        //                        dr["status"] = "Assign";
        //                    }
        //                }
        //                else
        //                {
        //                    dr["status"] = "Assign";
        //                }
        //                dt_openopp.Rows.Add(dr);

        //            }
        //        }
        //    }
        //    gvOpenOpportunities.DataSource = dt_openopp;
        //    ViewState["dt_openopp"] = dt_openopp;
        //    gvOpenOpportunities.DataBind();
        //}


        protected void lnkCustomer_Click(object sender, EventArgs e)
        {
            //Retrieve Customer ID  
            LinkButton lnkCustomerID = sender as LinkButton;
            string strCustomerID = lnkCustomerID.Text;
            int id = (int)Session["Designation"];
            //if (id == 14)
            if (id == clsDesignationList.GetDesignationID(EnumDesignation.GPTHead))
            {
                modal_assign.Show();
            }
            //else if (id == 6)
            else if (id == clsDesignationList.GetDesignationID(EnumDesignation.VerticalPreSalesHead))
            {
                modal_assign_sales.Show();

            }
        }

        protected void fillBidCordinators()
        {
            string UserId = (string)Session["UserID"];
            int DesignationId = (int)Session["Designation"];
            string VerticalID = (string)Session["VertId"];
            DataSet dscooridinators_details = new BLL.AssignOpportunity().GetBidCoordinators(VerticalID);
            if (dscooridinators_details.Tables.Count > 0)
            {
                if (dscooridinators_details.Tables[0].Rows.Count > 0)
                {
                    ddlprimarycontact.DataSource = dscooridinators_details.Tables[0];
                    ddlprimarycontact.DataTextField = "Full Name";
                    ddlprimarycontact.DataValueField = "UseriD";
                    ddlprimarycontact.DataBind();
                    ddlprimarycontact.Items.Insert(0, new ListItem("--Select---", "0"));
                    ddlprimarycontact.SelectedIndex = 0;
                    ddlsecondarycontact.DataSource = dscooridinators_details.Tables[0];
                    ddlsecondarycontact.DataTextField = "Full Name";
                    ddlsecondarycontact.DataValueField = "UseriD";
                    ddlsecondarycontact.DataBind();
                    ddlsecondarycontact.Items.Insert(0, new ListItem("--Select---", "0"));
                    ddlsecondarycontact.SelectedIndex = 0;
                }

            }

        }

        protected void fillBidManagers()
        {
            string UserId = (string)Session["UserID"];
            int DesignationId = (int)Session["Designation"];
            string VerticalID = (string)Session["VertId"];
            DataSet dsmanagers_details = new BLL.AssignOpportunity().GetBidManagers(UserId, VerticalID);
            if (dsmanagers_details.Tables.Count > 0)
            {
                if (dsmanagers_details.Tables[0].Rows.Count > 0)
                {
                    ddlprimarycontactsales.DataSource = dsmanagers_details.Tables[0];
                    ddlprimarycontactsales.DataTextField = "Full Name";
                    ddlprimarycontactsales.DataValueField = "UserID";
                    ddlprimarycontactsales.DataBind();
                    ddlprimarycontactsales.Items.Insert(0, new ListItem("--Select---", "0"));
                    ddlprimarycontactsales.SelectedIndex = 0;
                    ddlsecondarycontactsales.DataSource = dsmanagers_details.Tables[0];
                    ddlsecondarycontactsales.DataTextField = "Full Name";
                    ddlsecondarycontactsales.DataValueField = "UserID";
                    ddlsecondarycontactsales.DataBind();
                    ddlsecondarycontactsales.Items.Insert(0, new ListItem("--Select---", "0"));
                    ddlsecondarycontactsales.SelectedIndex = 0;
                }
            }
        }

        private void AssignOpportunityNotification(string _strDeliveryDirectorPrimary, string _strDeliveryDirectorSecondary)
        {
            int Id = (int)Session["Designation"];
            if (Id == 6)
            {
                string _strToEmail = string.Empty;
                string _strCCEmail = string.Empty;
                string _strToName = string.Empty;
                string _strCCname = string.Empty;
                string _strOppNumber = (string)ViewState["oppid"];
                string _strOppName = string.Empty;

                DataSet dsStakeHoldersDetails = new BLL.AutomatedMailBLL().getEmailAddresses(_strDeliveryDirectorPrimary, _strDeliveryDirectorSecondary);

                if (dsStakeHoldersDetails.Tables.Count > 0)
                {

                    if (dsStakeHoldersDetails.Tables[0].Rows.Count > 0)
                    {
                        _strToName = dsStakeHoldersDetails.Tables[0].Rows[0][0].ToString();
                        _strToEmail = dsStakeHoldersDetails.Tables[0].Rows[0][1].ToString();
                    }
                    if (dsStakeHoldersDetails.Tables[1].Rows.Count > 0)
                    {
                        _strCCname = dsStakeHoldersDetails.Tables[1].Rows[0][0].ToString();
                        _strCCEmail = dsStakeHoldersDetails.Tables[1].Rows[0][1].ToString();
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
                _EmailBody += "<p style='colr:red;'>RFP<b>" + _strOppName + "</b>(<b>" + _strOppNumber + "</b>)" + "  has been assigned to you by <b>GPT Manager</b></p> ";
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

                MailMessage myhtmlMessage = new MailMessage(fromAddress.ToString(), _strToEmail, "Automated Mail for Assigned Status of GPT Manager", _EmailBody);
                if (!string.IsNullOrEmpty(_strCCEmail))
                {
                    myhtmlMessage.CC.Add(_strCCEmail);
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
            else
            {

                string _strToEmail = string.Empty;
                string _strCCEmail = string.Empty;
                string _strToName = string.Empty;
                string _strCCname = string.Empty;
                string _strOppNumber = (string)ViewState["oppid"];
                string _strOppName = string.Empty;

                DataSet dsStakeHoldersDetails = new BLL.AutomatedMailBLL().getEmailAddresses(_strDeliveryDirectorPrimary, _strDeliveryDirectorSecondary);

                if (dsStakeHoldersDetails.Tables.Count > 0)
                {

                    if (dsStakeHoldersDetails.Tables[0].Rows.Count > 0)
                    {
                        _strToName = dsStakeHoldersDetails.Tables[0].Rows[0][0].ToString();
                        _strToEmail = dsStakeHoldersDetails.Tables[0].Rows[0][1].ToString();
                    }
                    if (dsStakeHoldersDetails.Tables[1].Rows.Count > 0)
                    {
                        _strCCname = dsStakeHoldersDetails.Tables[1].Rows[0][0].ToString();
                        _strCCEmail = dsStakeHoldersDetails.Tables[1].Rows[0][1].ToString();
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
                _EmailBody += "<p style='colr:red;'>RFP<b>" + _strOppName + "</b>(<b>" + _strOppNumber + "</b>)" + "  has been assigned to you by <b>GPT Manager</b></p> ";
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

                MailMessage myhtmlMessage = new MailMessage(fromAddress.ToString(), _strToEmail, "Automated Mail for Assigned Status of GPT Manager", _EmailBody);
                if (!string.IsNullOrEmpty(_strCCEmail))
                {
                    myhtmlMessage.CC.Add(_strCCEmail);
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
        }

        protected void gvOpenOpportunities_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataTable dt = (DataTable)ViewState["dt_openopp"];

                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows.Count > 0)
                    {
                        int count = dt.Rows.Count;
                        int rowIndexForGrid = e.Row.RowIndex;
                        int index = 0;
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
                            if ((OpportunityAssign.Tables[0].Rows[0].ItemArray[1].ToString() == string.Empty) || (OpportunityAssign.Tables[0].Rows[0].ItemArray[2].ToString() == string.Empty) || (OpportunityAssign.Tables[0].Rows[0].ItemArray[3].ToString() == string.Empty) || (OpportunityAssign.Tables[0].Rows[0].ItemArray[4].ToString() == string.Empty) || (OpportunityAssign.Tables[0].Rows[0].ItemArray[5].ToString() == string.Empty) || (OpportunityAssign.Tables[0].Rows[0].ItemArray[6].ToString() == string.Empty) || (OpportunityAssign.Tables[0].Rows[0].ItemArray[7].ToString() == string.Empty))
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

                        txtDate.Enabled = false;

                        txtDate = (TextBox)e.Row.FindControl("txtStartDat");

                        txtDate.Enabled = false;
                    }
                }

            }

        }

        //protected void loadGridviewVerticalPreSales(string UserID, int designationid, string VerticalID)
        //{

        //    div_openoppr.Visible = true;
        //    div_closedoppr.Visible = true;

        //    string Vertical = new BLL.HomeScreensBLL().Get_VerticalPresales(UserID);

        //    DataSet Opportunity_details = new BLL.HomeScreensBLL().Get_VerticalPreSalesOpenOpprDetails(UserID, designationid, Vertical);
        //    gvOpenOpportunities.DataSource = Opportunity_details;
        //    ViewState["dt_openopVP"] = Opportunity_details;
        //    gvOpenOpportunities.DataBind();
        //}

        protected void loadGridviewVerticalPresalesClosedSales(string UserID, string verticalID)
        {
            div_openoppr.Visible = true;
            div_closedoppr.Visible = true;
            lblClosedNoRecords.Text = string.Empty;
            // lblOpenNoRecords.Text = string.Empty;
            DataSet Opportunity_detailsSales = new BLL.HomeScreensBLL().Get_VerticalPresalesClosedOpportunityDetails(UserID, verticalID);
            if (Opportunity_detailsSales.Tables[0].Rows.Count == 0)
            {
                lblClosedNoRecords.Visible = true;
                lblClosedNoRecords.Text = "No Records found!!!";
                gvCloseOpportunities.DataSource = null;
                gvCloseOpportunities.DataBind(); 
            }
            else
            {
                lblClosedNoRecords.Visible = false;
            }

            gvCloseOpportunities.DataSource = Opportunity_detailsSales;
            gvCloseOpportunities.DataBind();
        }

        protected void gvCloseOpportunities_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvCloseOpportunities.PageIndex = e.NewPageIndex;
                ViewState["CurrentPageIndexForClose"] = e.NewPageIndex + 1;
                string verticalID = (string)Session["VertId"];
                string UserID2 = Convert.ToString(ddlSalesPersonwithOpportunity.SelectedValue);
                int designationid = (int)Session["Designation"];
                if (designationid == clsDesignationList.GetDesignationID(EnumDesignation.VerticalPreSalesHead))
                {
                    loadGridviewVerticalPresalesClosedSales(UserID2, verticalID);
                }

                string UserID1 = Convert.ToString(ddlSalesPersonwithOpportunity.SelectedValue);
                
                int VerticalId = Convert.ToInt32(ddlVerticalWithOpportunity.SelectedValue);
                DesignationId = new BLL.HomeScreensBLL().Get_DesignationByUserId(ddlSalesPersonwithOpportunity.SelectedValue);
                int Id = (int)Session["Designation"];
                string SalesUserId = Convert.ToString(ddlSalesPersonwithOpportunity.SelectedValue);
                if (designationid == clsDesignationList.GetDesignationID(EnumDesignation.GPTHead))
                {
                    loadGridviewGPTClosedSales(SalesUserId, DesignationId, VerticalId);
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

        protected void gvOpenOpportunities_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvOpenOpportunities.PageIndex = e.NewPageIndex;
                string verticalID = (string)Session["VertId"];
                string UserID2 = Convert.ToString(ddlSalesPersonwithOpportunity.SelectedValue);
                DesignationId = new BLL.HomeScreensBLL().Get_DesignationByUserId(ddlSalesPersonwithOpportunity.SelectedValue);
                int designationid = (int)Session["Designation"];
                //string VerticalID = string.Empty;
                //loadGridviewVerticalPresalesClosedSales(UserID2, verticalID);
                if (designationid == clsDesignationList.GetDesignationID(EnumDesignation.VerticalPreSalesHead))
                {
                    loadGridviewVerticalPreSales(UserID2, DesignationId, verticalID);
                }
                tabs.Visible = true;
                lblselect.Visible = false;

                string UserID1 = Convert.ToString(ddlSalesPersonwithOpportunity.SelectedValue);
                
                int VerticalId = Convert.ToInt32(ddlVerticalWithOpportunity.SelectedValue);
                
                int Id = (int)Session["Designation"];
                string SalesUserId = Convert.ToString(ddlSalesPersonwithOpportunity.SelectedValue);
                if (designationid == clsDesignationList.GetDesignationID(EnumDesignation.GPTHead))
                {
                    loadGridviewSales(UserID1, DesignationId, VerticalId);
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

        //protected void gvOpenOpportunities_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{

        //}

        //protected void gvCloseOpportunities_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{

        //}

        //protected void GridViewGPTMember_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        DataTable dt = (DataTable)ViewState["dt_openopp1"];

        //        if (dt.Rows.Count > 0)
        //        {
        //            if (dt.Rows.Count > 0)
        //            {
        //                int count = dt.Rows.Count;
        //                string oppId = dt.Rows[e.Row.RowIndex].ItemArray[0].ToString();
        //                DataSet OpportunityAssign = new BLL.HomeScreensBLL().getStatusAssign(oppId);

        //                if (OpportunityAssign.Tables[0].Rows.Count > 0)
        //                {
        //                    if ((OpportunityAssign.Tables[0].Rows[0].ItemArray[1].ToString() == string.Empty) || (OpportunityAssign.Tables[0].Rows[0].ItemArray[2].ToString() == string.Empty) || (OpportunityAssign.Tables[0].Rows[0].ItemArray[3].ToString() == string.Empty) || (OpportunityAssign.Tables[0].Rows[0].ItemArray[4].ToString() == string.Empty) || (OpportunityAssign.Tables[0].Rows[0].ItemArray[5].ToString() == string.Empty) || (OpportunityAssign.Tables[0].Rows[0].ItemArray[6].ToString() == string.Empty) || (OpportunityAssign.Tables[0].Rows[0].ItemArray[7].ToString() == string.Empty))
        //                    {
        //                        LinkButton lbDate = new LinkButton();
        //                        lbDate = (LinkButton)e.Row.FindControl("OppIDLnkButton");
        //                        lbDate.Enabled = false;
        //                        lbDate.ForeColor = System.Drawing.Color.Gray;

        //                        LinkButton lnkAssign1 = new LinkButton();
        //                        lnkAssign1 = (LinkButton)e.Row.FindControl("OppIDLnkButton");
        //                        lnkAssign1.Enabled = false;
        //                    }
        //                }
        //                else
        //                {
        //                    LinkButton lbDate = new LinkButton();
        //                    lbDate = (LinkButton)e.Row.FindControl("OppIDLnkButton");
        //                    lbDate.Enabled = false;
        //                    lbDate.ForeColor = System.Drawing.Color.Gray;


        //                }

        //                TextBox txtDate1 = new TextBox();
        //                txtDate1 = (TextBox)e.Row.FindControl("txtEditReview");
        //                //if (txtDate1.Text == string.Empty)
        //                //{
        //                //    LinkButton lnkAssign = new LinkButton();
        //                //    lnkAssign = (LinkButton)e.Row.FindControl("lnkCustomer");
        //                //    lnkAssign.Enabled = false;
        //                //}
        //                TextBox txtDate = new TextBox();
        //                txtDate = (TextBox)e.Row.FindControl("txtEditReview");

        //                txtDate.Enabled = false;

        //                txtDate.Enabled = false;

        //                txtDate = (TextBox)e.Row.FindControl("txtStartDat");

        //                txtDate.Enabled = false;
        //            }
        //        }

        //    }

        //}


    }
}
