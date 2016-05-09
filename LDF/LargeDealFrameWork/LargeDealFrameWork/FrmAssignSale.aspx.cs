using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace LargeDealFrameWork
{
    public partial class AssignSale : System.Web.UI.Page
    {

        override protected void OnInit(EventArgs e)
        {
            btnassignDD.ServerClick += new EventHandler(AssignDeliveryDirector);
            btnAssignGPT.ServerClick += new EventHandler(AssignGPT);
            btnAssignVPH.ServerClick += new EventHandler(AssignVerticalPresalesHead);
        } 

        protected void AssignDeliveryDirector(object sender, EventArgs e)
        {
            string _stroppid = (string)Session["OppId"];
            string _strDeliveryDirectorPrimary = ddlprimarycontact.SelectedValue.ToString(); //lblprimarycontact.Text.ToString();
            string _strDeliveryDirectorSecondary = ddlsecondrycontact.SelectedValue.ToString();//lblsecondrycontact.Text.ToString();
            bool _boolassignstatus = new BLL.Assign().AssigtnDD(_stroppid, _strDeliveryDirectorPrimary, _strDeliveryDirectorSecondary);           
        }

        protected void AssignGPT(object sender, EventArgs e)
        {
            string _stroppid = (string)Session["OppId"];
            string _strGPTPrimary = ddlprimarycnct_GPT.SelectedValue.ToString();// lblprimarycontact.Text.ToString();
            string _strGPTSecondary = ddlseccnct_GPT.SelectedValue.ToString(); //lblsecondrycontact.Text.ToString();
            bool _boolassignstatus = new BLL.Assign().AssigtnGPT(_stroppid, _strGPTPrimary, _strGPTSecondary);
        }

        protected void AssignVerticalPresalesHead(object sender, EventArgs e)
        {
            string _stroppid = (string)Session["OppId"];
            string _strVPH = ddlverticalpresaleshea.SelectedValue.ToString();//lblprimarycontact.Text.ToString();
            bool _boolassignstatus = new BLL.Assign().AssigtnverticalPresalesHead(_stroppid, _strVPH);
        }









        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                onpageload();
            }
            catch
            {

            }
        }


        protected void onpageload()
        {
            try
            {
                if (!IsPostBack)
                {
                    string UserID = (string)Session["UserID"];

                    string _strOppId = Request.QueryString["OppID"].ToString();
                    Session["Oppid"] = _strOppId;
                    DataSet Contact_details = new BLL.AssignOpportunity().Get_ContactDetails(UserID);
                    DataSet dsAssignees = new BLL.AssignOpportunity().GetVerticalPresalesHead(UserID);
                    DataSet dsAssignmentDetails = new BLL.AssignOpportunity().GetAssignmentDetails(_strOppId);
                    if (dsAssignmentDetails != null && dsAssignmentDetails.Tables[0].Rows.Count > 0)
                    {
                        DataTable dtOppAssignments = dsAssignmentDetails.Tables[0];
                        lblprimarycontact.Text = dtOppAssignments.Rows[0].ItemArray[2].ToString();
                        lblsecondrycontact.Text = dtOppAssignments.Rows[0].ItemArray[19].ToString();
                        lblpostprimarycnct_GPT.Text = dtOppAssignments.Rows[0].ItemArray[19].ToString();
                        lblpostseccnct_GPT.Text = dtOppAssignments.Rows[0].ItemArray[19].ToString();
                    }
                    if (dsAssignees.Tables.Count > 0)
                    {
                        if (dsAssignees.Tables[0].Rows.Count > 0)
                        {
                            ddlverticalpresaleshea.DataSource = dsAssignees.Tables[0];
                            ddlverticalpresaleshea.DataTextField = "Full Name";
                            ddlverticalpresaleshea.DataValueField = "Userid";
                            ddlverticalpresaleshea.DataBind();
                            ddlverticalpresaleshea.Items.Insert(0, new ListItem("--Select---", "0"));
                            ddlverticalpresaleshea.SelectedIndex = 0;
                        }

                        if (dsAssignees.Tables[1].Rows.Count > 0)
                        {
                            ddlprimarycontact.DataSource = dsAssignees.Tables[1];
                            ddlprimarycontact.DataTextField = "Full Name";
                            ddlprimarycontact.DataValueField = "Userid";
                            ddlprimarycontact.DataBind();
                            ddlprimarycontact.Items.Insert(0, new ListItem("--Select---", "0"));
                            ddlprimarycontact.SelectedIndex = 0;
                            ddlsecondrycontact.DataSource = dsAssignees.Tables[1];
                            ddlsecondrycontact.DataTextField = "Full Name";
                            ddlsecondrycontact.DataValueField = "Userid";
                            ddlsecondrycontact.DataBind();
                            ddlsecondrycontact.Items.Insert(0, new ListItem("--Select---", "0"));
                            ddlsecondrycontact.SelectedIndex = 0;
                        }
                        if (dsAssignees.Tables[2].Rows.Count > 0)
                        {
                            ddlprimarycnct_GPT.DataSource = dsAssignees.Tables[2];
                            ddlprimarycnct_GPT.DataTextField = "Full Name";
                            ddlprimarycnct_GPT.DataValueField = "Userid";
                            ddlprimarycnct_GPT.DataBind();
                            ddlprimarycnct_GPT.Items.Insert(0, new ListItem("--Select---", "0"));
                            ddlprimarycnct_GPT.SelectedIndex = 0;
                            ddlseccnct_GPT.DataSource = dsAssignees.Tables[2];
                            ddlseccnct_GPT.DataTextField = "Full Name";
                            ddlseccnct_GPT.DataValueField = "Userid";
                            ddlseccnct_GPT.DataBind();
                            ddlseccnct_GPT.Items.Insert(0, new ListItem("--Select---", "0"));
                            ddlseccnct_GPT.SelectedIndex = 0;
                        }
                    }
                }
               
                //int count = Contact_details.Tables[0].Rows.Count;
                //if (count > 0)
                //{

                //    DataTable dt_opencon = new DataTable();
                //    dt_opencon.Columns.Add("name");
                //    dt_opencon.Columns.Add("designation");
                //    dt_opencon.Columns.Add("email");
                //    dt_opencon.Columns.Add("Vertical");


                //    for (int i = 0; i <= count - 1; i++)
                //    {
                //        if (!string.IsNullOrEmpty(Contact_details.Tables[0].Rows[i].ItemArray[3].ToString()))
                //        {
                //            DataRow dr = dt_opencon.NewRow();
                //            dr["name"] = Contact_details.Tables[0].Rows[i].ItemArray[0].ToString();
                //            dr["designation"] = Contact_details.Tables[0].Rows[i].ItemArray[1].ToString();
                //            dr["email"] = Contact_details.Tables[0].Rows[i].ItemArray[1].ToString();
                //            dr["Vertical"] = Contact_details.Tables[0].Rows[i].ItemArray[3].ToString();
                //            dt_opencon.Rows.Add(dr);


                //        }
                //    }




                    //ArrayList arraycontact = new ArrayList();
                   
                    //for (int i = 0; i < count; i++)
                    //{

                    //    arraycontact.Add(dt_opencon.Rows[i].ItemArray[0].ToString());
                    //}

                
                    ////ddlprimarycontact.DataSource = arraycontact;
                    ////ddlprimarycontact.DataBind();
                    //////arraycontact.Reverse();
                    ////ddlsecondrycontact.DataSource = arraycontact;
                    ////ddlsecondrycontact.DataBind();
                    
                   
                    
                    // }


            }
            catch { }



            try
            {
                string UserID = (string)Session["UserID"];
                
                DataSet Contact_details = new BLL.AssignGPT().Get_GPTDetails(UserID);
            //    int count = Contact_details.Tables[0].Rows.Count;
                
            //    if (count > 0)
            //    {

            //        DataTable dt_opengpt = new DataTable();
            //        dt_opengpt.Columns.Add("name");
            //        dt_opengpt.Columns.Add("designation");
            //        dt_opengpt.Columns.Add("email");
            //        dt_opengpt.Columns.Add("Vertical");


            //        for (int i = 0; i <= count - 1; i++)
            //        {
            //            if (!string.IsNullOrEmpty(Contact_details.Tables[0].Rows[i].ItemArray[3].ToString()))
            //            {
            //                DataRow dr = dt_opengpt.NewRow();
            //                dr["name"] = Contact_details.Tables[0].Rows[i].ItemArray[0].ToString();
            //                dr["designation"] = Contact_details.Tables[0].Rows[i].ItemArray[1].ToString();
            //                dr["email"] = Contact_details.Tables[0].Rows[i].ItemArray[1].ToString();
            //                dr["Vertical"] = Contact_details.Tables[0].Rows[i].ItemArray[3].ToString();
            //                dt_opengpt.Rows.Add(dr);


            //            }
            //        }




            //        ArrayList arraygpt = new ArrayList();

            //        for (int i = 0; i < count; i++)
            //        {

            //            arraygpt.Add(dt_opengpt.Rows[i].ItemArray[0].ToString());
            //        }


            //        ddlprimarycnct_GPT.DataSource = arraygpt;
            //        ddlprimarycnct_GPT.DataBind();
            //        arraygpt.Reverse();
            //        ddlseccnct_GPT.DataSource = arraygpt;
            //        ddlseccnct_GPT.DataBind();

                    
            //    }


            }
                    

                    catch { }
              
               
         
                

        }

        protected void homeSale_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("FrmHomeScreenforSale.aspx");
        }

        protected void btassign_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmHomeScreenforSale.aspx");
        }

        protected void ddlprimarycontact_SelectedIndexChanged(object sender, EventArgs e)
                {
                   lblprimarycontact.Text = ddlprimarycontact.SelectedItem.Text; 
                }

        protected void ddlsecondrycontact_SelectedIndexChanged(object sender, EventArgs e)
                {
                    lblsecondrycontact.Text = ddlsecondrycontact.SelectedItem.Text;
           }
        
    }
}   
   
