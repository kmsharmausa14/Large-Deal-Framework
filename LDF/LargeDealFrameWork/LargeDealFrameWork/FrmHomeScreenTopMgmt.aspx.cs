using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;
using BO;
namespace LargeDealFrameWork
{
    public partial class FrmHomeScreenTopMgmt : System.Web.UI.Page
    {
        int Id = 0;
        string UserId = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblClosedNoRecords.Text = string.Empty;
                lblOpenNoRecords.Text = string.Empty;
                if (Session["UserID"] == null)
                {
                    Response.Redirect("/Login/SignInPage.aspx");
                }
                Id = (int)Session["Designation"];
                UserId = (string)Session["UserID"];
                if (!IsPostBack)
                {
                    checkpostback.Value = "1";
                    lnkadmin.Visible = false;
                    FillDdlVerticalOpp(UserId);
                    div_openoppr.Visible = false;
                    div_closedoppr.Visible = false;
                    string verticalId = new BLL.HomeScreensBLL().GetVerticalId(UserId);
                    GetCountOpportunity(UserId, Id.ToString());

                    if (Id == clsDesignationList.GetDesignationID(EnumDesignation.GPTMember))
                    {
                        lnkadmin.Visible = true;
                    }
                }
                if (IsPostBack)
                {
                    checkpostback.Value = "0";
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

        protected void FillDdlVerticalOpp(string UserID)
        {

            DataSet VerticalOpportunity_details = new BLL.HomeScreensBLL().Get_VerticalWithOpportunityDetails(UserID);
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

        //protected void loadGridviewSalesVertical(string verticalId)
        //{
        //    int Id = (int)Session["Designation"];
        //    string UserId = (string)Session["UserID"];
        //    div_openoppr.Visible = true;
        //    div_closedoppr.Visible = true;

        //    DataSet Opportunity_details = new BLL.HomeScreensBLL().loadGridviewSalesVertical(verticalId);
        //    DataTable dt_openopp = new DataTable();
        //    dt_openopp.Columns.Add("opportnumber");
        //    dt_openopp.Columns.Add("opportdesc");
        //    dt_openopp.Columns.Add("startdate");
        //    dt_openopp.Columns.Add("submissiondate");
        //    dt_openopp.Columns.Add("status");

        //    int count = Opportunity_details.Tables[0].Rows.Count;
        //    if (count == 0)
        //    {
        //        lblOpenNoRecords.Text = "No Records found!!!";
        //    }
        //    for (int i = 0; i <= count - 1; i++)
        //    {
        //        if (!string.IsNullOrEmpty(Opportunity_details.Tables[0].Rows[i].ItemArray[4].ToString()))
        //        {
        //            if (Convert.ToBoolean(Opportunity_details.Tables[0].Rows[i].ItemArray[4].ToString()) == false)
        //            {
        //                DataRow dr = dt_openopp.NewRow();
        //                dr["opportnumber"] = Opportunity_details.Tables[0].Rows[i].ItemArray[0].ToString();
        //                dr["opportdesc"] = Opportunity_details.Tables[0].Rows[i].ItemArray[5].ToString();
        //                string oppId = Opportunity_details.Tables[0].Rows[i].ItemArray[0].ToString();
        //                ViewState["OppNumber"] = dr["opportnumber"];
        //                dr["startdate"] = Opportunity_details.Tables[0].Rows[i].ItemArray[2].ToString();
        //                dr["submissiondate"] = Opportunity_details.Tables[0].Rows[i].ItemArray[3].ToString();

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
        //    gvOpenOpportunities.DataBind();
        //    ViewState["dt_openopp"] = dt_openopp;
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

        protected void FillDdlSalesPersonOppor(string VerticalID)
        {

            DataSet SalesPersonOpportunity_details = new BLL.HomeScreensBLL().Get_SalesPersonWithOpportunityDetails(VerticalID);
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

            try
            {
                checkpostback.Value = "1";
                ViewState["CurrentPageIndex"] = null;
                if (ddlSalesPersonwithOpportunity.SelectedIndex > 0)
                {
                    int DesignationId = new BLL.HomeScreensBLL().Get_DesignationByUserId(ddlSalesPersonwithOpportunity.SelectedValue);
                    //int Id = (int)Session["Designation"];
                    string SalesUserId = Convert.ToString(ddlSalesPersonwithOpportunity.SelectedValue);
                    int UserID1 = Convert.ToInt32(ddlSalesPersonwithOpportunity.SelectedValue);
                    int VerticalId = Convert.ToInt32(ddlVerticalWithOpportunity.SelectedValue);
                    loadGridview(SalesUserId, DesignationId, VerticalId);
                    DataSet dsGetFlag = new BLL.HomeScreensBLL().GetTopOppFlag(SalesUserId, Id, VerticalId);
                    ViewState["dsGetFlag"] = dsGetFlag;
                    TopMangmtClosedOpportunity(SalesUserId, DesignationId, VerticalId);

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Message", "alert('Select A SalesPerson')");
                    gvOpenOpportunities.DataSource = null;
                    gvOpenOpportunities.DataBind();
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


        private void loadGridview(string UserID1, int designationid, int VerticalId)
        {
            div_openoppr.Visible = true;
            div_closedoppr.Visible = true;

            DataSet Opportunity_details = new BLL.HomeScreensBLL().Get_OpenOpportunityDetails(UserID1, designationid, VerticalId);

            DataTable dt_openopp = new DataTable();
            dt_openopp.Columns.Add("opportnumber");
            dt_openopp.Columns.Add("opportdesc");
            dt_openopp.Columns.Add("startdate");
            dt_openopp.Columns.Add("submissiondate");
            dt_openopp.Columns.Add("status");

            int count = Opportunity_details.Tables[0].Rows.Count;
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
                        //dr["status"] = Opportunity_details.Tables[0].Rows[i].ItemArray[1].ToString();
                        string oppId = Opportunity_details.Tables[0].Rows[i].ItemArray[0].ToString();
                        DataTable ds = new BLL.Assign().getPrimarySecondaryContact(oppId);
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

        protected void TopMangmtClosedOpportunity(string SalesUserId, int DesignationId, int VerticalId)
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            DataSet TopMangmtClosedOpportunity_details = new BLL.HomeScreensBLL().Get_ClosedOpportunityDetails(SalesUserId, DesignationId, VerticalId);
            int Id = (int)Session["Designation"];
            if (TopMangmtClosedOpportunity_details.Tables[0].Rows.Count == 0)
            {
                lblClosedNoRecords.Text = "No Records found!!!";
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
            else
            {
                lblClosedNoRecords.Text = string.Empty;
                GridView1.DataSource = TopMangmtClosedOpportunity_details;
                GridView1.DataBind();

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
        protected void gvOpenOpportunities_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "OppIdRedirect")
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
                DataSet dsGetFlag = (DataSet)ViewState["dsGetFlag"];

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
                        int rowindexForDataTable = (GridView1.PageSize * (pageindex - 1)) + index;
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

        protected void gvClosedOpportunities_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "OppIdRedirect")
                {
                    string OppIDRedirect = string.Empty;
                    int RowIndecs = Convert.ToInt32(e.CommandArgument);
                    GridViewRow grow = GridView1.Rows[RowIndecs];
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

        protected void lnkadmin_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("/FrmAddNewUser.aspx");
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
                int DesignationId = new BLL.HomeScreensBLL().Get_DesignationByUserId(ddlSalesPersonwithOpportunity.SelectedValue);
                //int Id = (int)Session["Designation"];
                string SalesUserId = Convert.ToString(ddlSalesPersonwithOpportunity.SelectedValue);
                string UserID1 = Convert.ToString(ddlSalesPersonwithOpportunity.SelectedValue);
                int VerticalId = Convert.ToInt32(ddlVerticalWithOpportunity.SelectedValue);
                loadGridview(UserID1, DesignationId, VerticalId);
                
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

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                ViewState["CurrentPageIndexForClose"] = e.NewPageIndex + 1;
                int DesignationId = new BLL.HomeScreensBLL().Get_DesignationByUserId(ddlSalesPersonwithOpportunity.SelectedValue);                
               string SalesUserId = Convert.ToString(ddlSalesPersonwithOpportunity.SelectedValue);                
                int VerticalId = Convert.ToInt32(ddlVerticalWithOpportunity.SelectedValue);
                TopMangmtClosedOpportunity(SalesUserId, DesignationId, VerticalId);
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
