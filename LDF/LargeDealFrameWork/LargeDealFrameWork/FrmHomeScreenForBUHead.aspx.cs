using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BO;
using System.Data;
namespace LargeDealFrameWork
{
    public partial class HomeScreenBUHead : System.Web.UI.Page
    {
        int DesignationId = 0;
        string UserId = string.Empty;
        /// <summary>
        /// Call the Fill dropdown list method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                UserId = (string)Session["UserID"];
                DesignationId = (int)Session["Designation"];
                if (Session["UserID"] == null)
                {
                    Response.Redirect("/Login/SignInPage.aspx");
                }
                if (!IsPostBack)
                {
                    checkpostback.Value = "1";
                    if (DesignationId == clsDesignationList.GetDesignationID(EnumDesignation.DeliveryManagerSPoC))
                    {
                        loadGridview(UserId, DesignationId);
                        BuHeadClosedOpportunity(UserId);
                        ddlSalesPeople.Visible = false;
                        lblselectvertical.Visible = false;

                    }
                    else
                    {
                        fillDdlPersonSales();
                    }

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
        /// <summary>
        /// Fill the PersonSale Dropdownlist based on the verticalid and designation of salesperson
        /// which we can get using BUHead UserID and Designation.
        /// </summary>
        /// 
        protected void gvCloseOpportunities_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                //{
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

                                LinkButton lnkButtonOppId = (LinkButton)e.Row.FindControl("ClosedOppIDLnkButton");
                                lnkButtonOppId.Enabled = false;
                                lnkButtonOppId.ForeColor = System.Drawing.Color.Black;
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
                // }

                //catch (Exception ex)
                //{
                //    string _strErrorMessage = string.Format("{0}", ex.Message.ToString());

                //    var cleanChars = _strErrorMessage.Where(c => !"\n\r".Contains(c));
                //    string cleanText = new string(cleanChars.ToArray());

                //    Response.Redirect("/frmErrorPage.aspx?ErrorMessage=" + cleanText);
                //}
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
        protected void fillDdlPersonSales()
        {
            string UserId = (string)Session["UserID"];
            int DesignationId = (int)Session["Designation"];
            DataSet SalesPerson_details = new BLL.HomeScreensBLL().Get_SalesPerson(UserId, DesignationId);
            if (SalesPerson_details.Tables.Count > 0)
            {
                if (SalesPerson_details.Tables[0].Rows.Count > 0)
                {
                    ddlSalesPeople.DataSource = SalesPerson_details.Tables[0];
                    ddlSalesPeople.DataTextField = "FullName";
                    ddlSalesPeople.DataValueField = "vspkUsrId";
                    ddlSalesPeople.DataBind();

                    ddlSalesPeople.Items.Insert(0, new ListItem("--Select---", "0"));
                    ddlSalesPeople.SelectedIndex = 0;
                }
            }

        }
        /// <summary>
        /// on the selection of SalesPerson UserID get the DesignationID and passed to
        /// the method which loading the opportunity gridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlSalesPeople_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int DesignationId = 0;
                checkpostback.Value = "1";
                ViewState["CurrentPageIndex"] = null;
                if (ddlSalesPeople.SelectedIndex > 0)
                {
                    DesignationId = new BLL.HomeScreensBLL().Get_DesignationByUserId(ddlSalesPeople.SelectedValue);
                    loadGridview(ddlSalesPeople.SelectedValue, DesignationId);
                    //added by sachin 20 feb 2014
                    BuHeadClosedOpportunity(ddlSalesPeople.SelectedValue);
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
        /// <summary>
        /// Loading the Gridview with open and closed opprtunity based on the Sales person 
        /// UserID and DesignationID
        /// </summary>
        /// <param name="SalesUserId"></param>
        /// <param name="DesignationId"></param>
        protected void loadGridview(string SalesUserId, int DesignationId)
        {
            //lblClosedNoRecords.Text = string.Empty;
            lblOpenNoRecords.Text = string.Empty;
            DataSet Opportunity_details = new BLL.HomeScreensBLL().Get_OpportunityDetails(SalesUserId, DesignationId);
            DataTable dt_openopp = new DataTable();
            dt_openopp.Columns.Add("opportnumber");
            dt_openopp.Columns.Add("opportdesc");
            dt_openopp.Columns.Add("startdate");
            dt_openopp.Columns.Add("submissiondate");

            int count = Opportunity_details.Tables[0].Rows.Count;
            if (count == 0)
            {
                lblOpenNoRecords.Text = "No Records found!!!";
                gvOpenOpportunities.DataSource = null;
                gvOpenOpportunities.DataBind();
            }
            for (int i = 0; i <= count - 1; i++)
            {
                if (Convert.ToBoolean(Opportunity_details.Tables[0].Rows[i].ItemArray[4].ToString()) == false)
                {
                    DataRow dr = dt_openopp.NewRow();
                    dr["opportnumber"] = Opportunity_details.Tables[0].Rows[i].ItemArray[0].ToString();
                    dr["startdate"] = Opportunity_details.Tables[0].Rows[i].ItemArray[2].ToString();
                    dr["submissiondate"] = Opportunity_details.Tables[0].Rows[i].ItemArray[3].ToString();
                    dr["opportdesc"] = Opportunity_details.Tables[0].Rows[i].ItemArray[5].ToString();
                    //dr["status"] = Opportunity_details.Tables[0].Rows[i].ItemArray[1].ToString();
                    dt_openopp.Rows.Add(dr);

                }
            }
            gvOpenOpportunities.DataSource = dt_openopp;
            ViewState["dt_openopp"] = dt_openopp;
            gvOpenOpportunities.DataBind();
        }


        protected void BuHeadClosedOpportunity(string _SalesUserId)
        {
            lblClosedNoRecords.Text = string.Empty;
            //lblOpenNoRecords.Text = string.Empty;
            string UserID = (string)Session["UserID"];
            string Salesid = ddlSalesPeople.SelectedValue;
            DataSet TopMangmtClosedOpportunity_details = new BLL.HomeScreensBLL().Get_BuHeadClosedOpportunityDetails(UserID, Salesid);

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

                gvCloseOpportunities.DataSource = TopMangmtClosedOpportunity_details;
                gvCloseOpportunities.DataBind();
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

                            //TextBox txtDate1 = new TextBox();
                            //txtDate1 = (TextBox)e.Row.FindControl("txtEditReview");

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

        protected void gvCloseOpportunities_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                string UserID = (string)Session["UserID"];
                string Salesid = ddlSalesPeople.SelectedValue;
                DataSet BUHeadClosedOpportunity_details = new BLL.HomeScreensBLL().Get_BuHeadClosedOpportunityDetails(UserID, Salesid);
                gvCloseOpportunities.DataSource = BUHeadClosedOpportunity_details;
                int count = BUHeadClosedOpportunity_details.Tables[0].Rows.Count;

                if (e.CommandName == "OppIdRedirect")
                {
                    string OppIdRedirectClosed = string.Empty;
                    int RowIndecs = Convert.ToInt32(e.CommandArgument);
                    GridViewRow grow = gvCloseOpportunities.Rows[RowIndecs];
                    LinkButton lnkoppClosed = null;
                    lnkoppClosed = (LinkButton)grow.FindControl("ClosedOppIDLnkButton");
                    OppIdRedirectClosed = lnkoppClosed.Text;
                    DataSet dsGetStatusValueBid = new BLL.RGYBLL().retrievestatus(OppIdRedirectClosed);
                    if (dsGetStatusValueBid.Tables.Count > 0)
                    {
                        if (dsGetStatusValueBid.Tables[1].Rows.Count > 0)
                        {
                            if (dsGetStatusValueBid.Tables[1].Rows[0][7].ToString().Trim() != null)
                            {
                                if (dsGetStatusValueBid.Tables[1].Rows[0][7].ToString().Trim() == "True")
                                {
                                    Response.Redirect("/FrmBidWinability.aspx?OppID=" + OppIdRedirectClosed);
                                }
                                else
                                {
                                    Response.Redirect("/FrmQualificationmain.aspx?OppID=" + OppIdRedirectClosed);
                                }
                            }
                            else
                            {
                                Response.Redirect("/FrmQualificationmain.aspx?OppID=" + OppIdRedirectClosed);
                            }
                        }
                        else
                        {
                            Response.Redirect("/FrmQualificationmain.aspx?OppID=" + OppIdRedirectClosed);
                        }
                    }
                    else
                    {
                        Response.Redirect("/FrmQualificationmain.aspx?OppID=" + OppIdRedirectClosed);
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
                ViewState["CurrentPageIndexForClose"] = e.NewPageIndex + 1;
                BuHeadClosedOpportunity(ddlSalesPeople.SelectedValue);
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
                DesignationId = new BLL.HomeScreensBLL().Get_DesignationByUserId(ddlSalesPeople.SelectedValue);
                loadGridview(ddlSalesPeople.SelectedValue, DesignationId);
                
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
