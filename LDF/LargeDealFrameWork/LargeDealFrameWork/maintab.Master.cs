using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Text.RegularExpressions;
using System.Data;
using BO;

namespace LargeDealFrameWork
{
    public partial class maintab : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Designation"] == null)
            {
                Response.Redirect("/Login/SignInPage.aspx");
            }
            string Username = Session["FirstName"].ToString();
            string DesignationName = Session["DesignationName"].ToString();

            System.Globalization.TextInfo ti = new System.Globalization.CultureInfo("en-US", false).TextInfo;
            Username = ti.ToTitleCase(Username);

            userName.Text = "Welcome " + Username + " (" + DesignationName + ")";

        }

        protected void OnMenuItemDataBound(object sender, MenuEventArgs e)
        {
            System.Web.UI.WebControls.Menu menu = (System.Web.UI.WebControls.Menu)sender;
            SiteMapNode mapNode = (SiteMapNode)e.Item.DataItem;

            System.Web.UI.WebControls.MenuItem itemToRemove = menu.FindItem(mapNode.Title);

            if (mapNode.Title == "RGY Checklist")
            {
                itemToRemove.Enabled = false;

                DataSet dsGetStatusValueRGY = new BLL.ScoreOppQuaBLL().GetOpportunityQualificationDetailsAll((string)Session["Oppid"]);
                DataSet dsGetStatusValueBid = new BLL.RGYBLL().retrievestatus((string)Session["Oppid"]);
                if (dsGetStatusValueRGY.Tables.Count > 0)
                {
                    if (dsGetStatusValueRGY.Tables[0].Rows.Count > 0)
                    {
                        if (dsGetStatusValueRGY.Tables[0].Rows[0][4].ToString().Trim() == "Approved")
                        {
                            itemToRemove.Enabled = true;
                        }
                    }
                }
                if (dsGetStatusValueBid.Tables.Count > 0)
                {
                    if (dsGetStatusValueBid.Tables[1].Rows.Count > 0)
                    {
                        if (dsGetStatusValueBid.Tables[1].Rows[0][7].ToString().Trim() != null)
                        {
                            if (dsGetStatusValueBid.Tables[1].Rows[0][7].ToString().Trim() == "True")
                            {
                                itemToRemove.Enabled = false;
                                //itemToRemove.Selected=false;
                            }
                        }
                    }
                }
            }

            if (mapNode.Title == "Bid Winability")
            {
                itemToRemove.Enabled = false;

                DataSet dsGetStatusValueBid = new BLL.RGYBLL().retrievestatus((string)Session["Oppid"]);

                if (dsGetStatusValueBid.Tables.Count > 0)
                {
                    if (dsGetStatusValueBid.Tables[0].Rows.Count > 0)
                    {
                        if (dsGetStatusValueBid.Tables[0].Rows[0][14].ToString().Trim() != null)
                        {
                            //if (dsGetStatusValueBid.Tables[0].Rows[0][14].ToString().Trim() == "True")
                           // {
                                itemToRemove.Enabled = true;
                           // }
                        }
                    }
                }
                if (dsGetStatusValueBid.Tables.Count > 0)
                {
                    if (dsGetStatusValueBid.Tables[1].Rows.Count > 0)
                    {
                        if (dsGetStatusValueBid.Tables[1].Rows[0][7].ToString().Trim() != null)
                        {
                            if (dsGetStatusValueBid.Tables[1].Rows[0][7].ToString().Trim() == "True")
                            {
                                itemToRemove.Enabled = true;
                                //itemToRemove.Selected=true;
                            }
                        }
                    }
                }
            }

            if (mapNode.Title == "Qualification Analysis")
            {
                //itemToRemove.Enabled = false;

                DataSet dsGetStatusValueBid = new BLL.RGYBLL().retrievestatus((string)Session["Oppid"]);

                if (dsGetStatusValueBid.Tables.Count > 0)
                {
                    if (dsGetStatusValueBid.Tables[1].Rows.Count > 0)
                    {
                        if (dsGetStatusValueBid.Tables[1].Rows[0][7].ToString().Trim() != null)
                        {
                            if (dsGetStatusValueBid.Tables[1].Rows[0][7].ToString().Trim() == "True")
                            {
                                itemToRemove.Enabled = false;
                               
                            }
                        }
                    }
                }
            }
        }

        protected void lnkbuttonSignout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Response.Redirect("/Login/SignInPage.aspx");
        }

        protected void lnkHome_Click(object sender, EventArgs e)
        {
            //if (Session["Designation"].ToString()=="1")
            if (Session["Designation"].ToString() == clsDesignationList.GetDesignationID(EnumDesignation.Admin).ToString())
            {
                Response.Redirect("/FrmAddNewUser.aspx");
            }
            //else if (Session["Designation"].ToString()=="5")
            else if (Session["Designation"].ToString() == clsDesignationList.GetDesignationID(EnumDesignation.DeliveryDirector).ToString())
            {
                Response.Redirect("/FrmHomeScreenForDeliveryHead.aspx");
            }
           // else if (Session["Designation"].ToString()=="13")
            else if (Session["Designation"].ToString() == clsDesignationList.GetDesignationID(EnumDesignation.BUHead).ToString())
            {
                Response.Redirect("/FrmHomeScreenForBUHead.aspx");
            }
            //else if (Session["Designation"].ToString()=="14" || Session["Designation"].ToString()=="6")
            else if (Session["Designation"].ToString() == clsDesignationList.GetDesignationID(EnumDesignation.GPTHead).ToString() ||
                Session["Designation"].ToString() == clsDesignationList.GetDesignationID(EnumDesignation.VerticalPreSalesHead).ToString())
            {
                Response.Redirect("/FrmHomeScreenForGPTManager.aspx");
            }
            //else if (Session["Designation"].ToString()=="9")
            else if (Session["Designation"].ToString() == clsDesignationList.GetDesignationID(EnumDesignation.DeliveryManager).ToString())
            {
                Response.Redirect("/FrmHomeScreenforDeliveryMgr.aspx");
            }
            //else if (Session["Designation"].ToString()=="10")
            //else if (Session["Designation"].ToString() == "10")
            //{
            //    Response.Redirect("/FrmHomeScreenForBUHead.aspx");
            //}
            else if (Session["Designation"].ToString() == clsDesignationList.GetDesignationID(EnumDesignation.BidManager).ToString() ||
                Session["Designation"].ToString() == clsDesignationList.GetDesignationID(EnumDesignation.DeliveryManagerSPoC).ToString())
            {
                Response.Redirect("/FrmHomeScreenForBidMgr.aspx");
            }
            //else if (Session["Designation"].ToString()=="8")
            else if (Session["Designation"].ToString() == clsDesignationList.GetDesignationID(EnumDesignation.BidCoordinator).ToString())
            {
                Response.Redirect("/FrmHomeScreenForBidCord.aspx");
            }
            //else if (Session["Designation"].ToString()=="11")
            else if (Session["Designation"].ToString() == clsDesignationList.GetDesignationID(EnumDesignation.GPTMember).ToString())
            {
                Response.Redirect("/FrmHomeScreenTopMgmt.aspx");
            }
            //else if (Session["Designation"].ToString()=="12")
            else if (Session["Designation"].ToString() == clsDesignationList.GetDesignationID(EnumDesignation.TopManagement).ToString())
            {
                Response.Redirect("/FrmHomeScreenTopMgmt.aspx");
            }
            //else if (Session["Designation"].ToString()=="6")
            else if (Session["Designation"].ToString() == clsDesignationList.GetDesignationID(EnumDesignation.VerticalPreSalesHead).ToString())
            {
                Response.Redirect("/FrmHomeScreenForGPTManager.aspx");
            }
            else if (Session["Designation"].ToString() == clsDesignationList.GetDesignationID(EnumDesignation.PrimarySalesSPoc).ToString())
            {
                Response.Redirect("/FrmHomeScreenforSale.aspx");
            }
        }
    }

}
