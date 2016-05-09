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
    public partial class FrmHomeScreenForBidMgr : System.Web.UI.Page
    {
        int DesignationId = 0;
        string UserId = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DesignationId = (int)Session["Designation"];
                UserId = (string)Session["UserID"];
                if (Session["UserID"] == null)
                {
                    Response.Redirect("signInPage.aspx");
                }
                if (!IsPostBack)
                {
                    checkpostback.Value = "1";
                    div_openoppr.Visible = false;
                    div_closedoppr.Visible = false;
                    loadGridview(UserId, DesignationId);
                    TopMangmtClosedOpportunity(UserId, DesignationId);
                    GetCountOpportunity(UserId, DesignationId.ToString());

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
            //lblClosedNoRecords.Text = string.Empty;
            //lblOpenNoRecords.Text = string.Empty;
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
                        dr["opportnumber"] = Opportunity_details.Tables[0].Rows[i].ItemArray[0].ToString();
                        dr["startdate"] = Opportunity_details.Tables[0].Rows[i].ItemArray[2].ToString();
                        dr["submissiondate"] = Opportunity_details.Tables[0].Rows[i].ItemArray[3].ToString();
                        dr["opportdesc"] = Opportunity_details.Tables[0].Rows[i].ItemArray[5].ToString();

                        string oppId = Opportunity_details.Tables[0].Rows[i].ItemArray[0].ToString();

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
            if ((int)Session["Designation"] == clsDesignationList.GetDesignationID(EnumDesignation.BidManager))
            {
                DataSet TopMangmtClosedOpportunity_details = new BLL.HomeScreensBLL().Get_TopMangmtClosedOpportunityDetails(SalesUserId, DesignationId);

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
                    lblOpenNoRecords.Visible = false;

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

                    gvCloseOpportunities.DataSource = dt_openopp;
                    gvCloseOpportunities.DataBind();

                }
            }
            else
            {
                div_openoppr.Visible = true;
                div_closedoppr.Visible = true;
                string UserId = (string)Session["UserID"];
                DataSet TopMangmtClosedOpportunity_details = new BLL.HomeScreensBLL().getClosedOpportunityForDeliveryManagerSpoc(UserId);
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
                }
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

        protected void gvOpenOpportunities_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DataTable dt = (DataTable)ViewState["dt_openopp"];

                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows.Count > 0)
                        {

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
                                if ((OpportunityAssign.Tables[0].Rows[0].ItemArray[1].ToString() == string.Empty) ||
                                    (OpportunityAssign.Tables[0].Rows[0].ItemArray[2].ToString() == string.Empty) ||
                                    (OpportunityAssign.Tables[0].Rows[0].ItemArray[3].ToString() == string.Empty) ||
                                    (OpportunityAssign.Tables[0].Rows[0].ItemArray[4].ToString() == string.Empty) ||
                                    (OpportunityAssign.Tables[0].Rows[0].ItemArray[5].ToString() == string.Empty) ||
                                    (OpportunityAssign.Tables[0].Rows[0].ItemArray[6].ToString() == string.Empty) ||
                                    (OpportunityAssign.Tables[0].Rows[0].ItemArray[7].ToString() == string.Empty))
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
                            }


                            TextBox txtDate = new TextBox();
                            txtDate = (TextBox)e.Row.FindControl("txtEditReview");

                            txtDate.Enabled = false;

                            txtDate = (TextBox)e.Row.FindControl("txtStartDat");

                            txtDate.Enabled = false;
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
        protected void gvOpenOpportunities_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Trim().ToLower() != "Page".ToLower())
                {
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
                    int pageSize = gvOpenOpportunities.PageSize;
                    int pageindex = Convert.ToInt32(e.CommandArgument);
                    this.gvOpenOpportunities.PageIndex = pageindex;
                    ViewState["CurrentPageIndex"] = e.CommandArgument;
                    loadGridview(UserId, DesignationId);
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

       

        //protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    GridView1.PageIndex = e.NewPageIndex;
        //    GridView1.DataBind();
        //}

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

        protected void gvCloseOpportunities_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvCloseOpportunities.PageIndex = e.NewPageIndex;
                ViewState["CurrentPageIndexForClose"] = e.NewPageIndex + 1;
                TopMangmtClosedOpportunity(UserId, DesignationId);
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
