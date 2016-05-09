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
    public partial class RGYChecklistmain : System.Web.UI.Page
    {

        Hashtable htballparameters = new Hashtable();
        ArrayList lstfinal = new ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                pageload();
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

        #region OnPageLoads

        private void SetInitialRow()
        {
            try
            {

                DataTable dtbusiness = new DataTable();
                //DataRow dr = null;
                // dt.Columns.Add(new DataColumn("Inv_No", typeof(string)));
                dtbusiness.Columns.Add(new DataColumn("keyclientrequirement", typeof(string)));
                dtbusiness.Columns.Add(new DataColumn("impactonwhichpart", typeof(string)));
                dtbusiness.Columns.Add(new DataColumn("level", typeof(string)));
                dtbusiness.Columns.Add(new DataColumn("improvementarea", typeof(string)));
                dtbusiness.Columns.Add(new DataColumn("ownertoaddressarea", typeof(string)));
                dtbusiness.Columns.Add(new DataColumn("reviewdate", typeof(DateTime)));

                DataTable dttechnical = new DataTable();
                //DataRow dr = null;
                // dt.Columns.Add(new DataColumn("Inv_No", typeof(string)));
                dttechnical.Columns.Add(new DataColumn("keyclientrequirement", typeof(string)));
                dttechnical.Columns.Add(new DataColumn("impactonwhichpart", typeof(string)));
                dttechnical.Columns.Add(new DataColumn("level", typeof(string)));
                dttechnical.Columns.Add(new DataColumn("improvementarea", typeof(string)));
                dttechnical.Columns.Add(new DataColumn("ownertoaddressarea", typeof(string)));
                dttechnical.Columns.Add(new DataColumn("reviewdate", typeof(DateTime)));

                DataTable dtservice = new DataTable();
                //DataRow dr = null;
                // dt.Columns.Add(new DataColumn("Inv_No", typeof(string)));
                dtservice.Columns.Add(new DataColumn("keyclientrequirement", typeof(string)));
                dtservice.Columns.Add(new DataColumn("impactonwhichpart", typeof(string)));
                dtservice.Columns.Add(new DataColumn("level", typeof(string)));
                dtservice.Columns.Add(new DataColumn("improvementarea", typeof(string)));
                dtservice.Columns.Add(new DataColumn("ownertoaddressarea", typeof(string)));
                dtservice.Columns.Add(new DataColumn("reviewdate", typeof(DateTime)));

                DataTable dttransition = new DataTable();
                //DataRow dr = null;
                // dt.Columns.Add(new DataColumn("Inv_No", typeof(string)));
                dttransition.Columns.Add(new DataColumn("keyclientrequirement", typeof(string)));
                dttransition.Columns.Add(new DataColumn("impactonwhichpart", typeof(string)));
                dttransition.Columns.Add(new DataColumn("level", typeof(string)));
                dttransition.Columns.Add(new DataColumn("improvementarea", typeof(string)));
                dttransition.Columns.Add(new DataColumn("ownertoaddressarea", typeof(string)));
                dttransition.Columns.Add(new DataColumn("reviewdate", typeof(DateTime)));

                DataTable dtgovern = new DataTable();
                //DataRow dr = null;
                // dt.Columns.Add(new DataColumn("Inv_No", typeof(string)));
                dtgovern.Columns.Add(new DataColumn("keyclientrequirement", typeof(string)));
                dtgovern.Columns.Add(new DataColumn("impactonwhichpart", typeof(string)));
                dtgovern.Columns.Add(new DataColumn("level", typeof(string)));
                dtgovern.Columns.Add(new DataColumn("improvementarea", typeof(string)));
                dtgovern.Columns.Add(new DataColumn("ownertoaddressarea", typeof(string)));
                dtgovern.Columns.Add(new DataColumn("reviewdate", typeof(DateTime)));

                DataTable dthr = new DataTable();
                //DataRow dr = null;
                // dt.Columns.Add(new DataColumn("Inv_No", typeof(string)));
                dthr.Columns.Add(new DataColumn("keyclientrequirement", typeof(string)));
                dthr.Columns.Add(new DataColumn("impactonwhichpart", typeof(string)));
                dthr.Columns.Add(new DataColumn("level", typeof(string)));
                dthr.Columns.Add(new DataColumn("improvementarea", typeof(string)));
                dthr.Columns.Add(new DataColumn("ownertoaddressarea", typeof(string)));
                dthr.Columns.Add(new DataColumn("reviewdate", typeof(DateTime)));

                DataTable dtprocess = new DataTable();
                //DataRow dr = null;
                // dt.Columns.Add(new DataColumn("Inv_No", typeof(string)));
                dtprocess.Columns.Add(new DataColumn("keyclientrequirement", typeof(string)));
                dtprocess.Columns.Add(new DataColumn("impactonwhichpart", typeof(string)));
                dtprocess.Columns.Add(new DataColumn("level", typeof(string)));
                dtprocess.Columns.Add(new DataColumn("improvementarea", typeof(string)));
                dtprocess.Columns.Add(new DataColumn("ownertoaddressarea", typeof(string)));
                dtprocess.Columns.Add(new DataColumn("reviewdate", typeof(DateTime)));

                DataTable dtcommercial = new DataTable();
                //DataRow dr = null;
                // dt.Columns.Add(new DataColumn("Inv_No", typeof(string)));
                dtcommercial.Columns.Add(new DataColumn("keyclientrequirement", typeof(string)));
                dtcommercial.Columns.Add(new DataColumn("impactonwhichpart", typeof(string)));
                dtcommercial.Columns.Add(new DataColumn("level", typeof(string)));
                dtcommercial.Columns.Add(new DataColumn("improvementarea", typeof(string)));
                dtcommercial.Columns.Add(new DataColumn("ownertoaddressarea", typeof(string)));
                dtcommercial.Columns.Add(new DataColumn("reviewdate", typeof(DateTime)));

                DataTable dtintegration = new DataTable();
                //DataRow dr = null;
                // dt.Columns.Add(new DataColumn("Inv_No", typeof(string)));
                dtintegration.Columns.Add(new DataColumn("keyclientrequirement", typeof(string)));
                dtintegration.Columns.Add(new DataColumn("impactonwhichpart", typeof(string)));
                dtintegration.Columns.Add(new DataColumn("level", typeof(string)));
                dtintegration.Columns.Add(new DataColumn("improvementarea", typeof(string)));
                dtintegration.Columns.Add(new DataColumn("ownertoaddressarea", typeof(string)));
                dtintegration.Columns.Add(new DataColumn("reviewdate", typeof(DateTime)));
                
                //dt.Rows.Add(dr);
                //ViewState["TempTableLineItemDetails"] = dt;
                ViewState["paramcolumnsbusiness"] = dtbusiness;
                ViewState["paramcolumnstechnical"] = dttechnical;
                ViewState["paramcolumnsservice"] = dtservice;
                ViewState["paramcolumnstransition"] = dttransition;
                ViewState["paramcolumnsgovern"] = dtgovern;
                ViewState["paramcolumnsHR"] = dthr;
                ViewState["paramcolumnsprocess"] = dtprocess;
                ViewState["paramcolumnscommercial"] = dtcommercial;
                ViewState["paramcolumnsint"] = dtintegration;
            }
            catch
            {

            }

        }

        public void populatelevel()
        {
            DataSet dspopulateddlevel = new DataSet();
            try
            {
                dspopulateddlevel = new BLL.RGYBLL().populateddllevel();
            }
            catch 
            {
            
            }
            DataTable dtpoplev = new DataTable();//populateddlevel.Tables 
            if (dspopulateddlevel != null && dspopulateddlevel.Tables.Count > 0)
            {
                dtpoplev = dspopulateddlevel.Tables[0];
                if (dtpoplev.Rows.Count > 0)
                {
                    int cnt = dtpoplev.Rows.Count;
                    foreach (DataRow dr in dtpoplev.Rows)
                    {
                        ddllevel.Items.Add(dr[0].ToString());
                        ddLevelTech.Items.Add(dr[0].ToString());
                        ddLevelServ.Items.Add(dr[0].ToString());
                        ddLevelTrans.Items.Add(dr[0].ToString());
                        ddLevelGov.Items.Add(dr[0].ToString());
                        ddLevelProc.Items.Add(dr[0].ToString());
                        ddLevelHR.Items.Add(dr[0].ToString());
                        ddLevelInt.Items.Add(dr[0].ToString());
                        ddLevelCom.Items.Add(dr[0].ToString());
                    }
                }
            }
        }

        public void getweightage()
        {
            DataSet dsparavalues =new DataSet();
            try
            {
                dsparavalues = new BLL.RGYBLL().getparamvalues();
            }
            catch
            {
            }
            if (dsparavalues != null && dsparavalues.Tables.Count > 0)
            {
                DataTable dtvalues = dsparavalues.Tables[0];
                if (dtvalues.Rows.Count > 0)
                {
                    lblBusinessSolutionWeightage.Text = "Weightage:" + dtvalues.Rows[0][2].ToString();
                    lblTechnicalSolutionWeightage.Text = "Weightage:" + dtvalues.Rows[1][2].ToString();
                    serweight.Text = "Weightage:" + dtvalues.Rows[2][2].ToString();
                    transweight.Text = "Weightage:" + dtvalues.Rows[3][2].ToString();
                    govweight.Text = "Weightage:" + dtvalues.Rows[4][2].ToString();
                    proweight.Text = "Weightage:" + dtvalues.Rows[5][2].ToString();
                    hrweight.Text = "Weightage:" + dtvalues.Rows[6][2].ToString();
                    commweight.Text = "Weightage:" + dtvalues.Rows[7][2].ToString();
                    intweight.Text = "Weightage:" + dtvalues.Rows[8][2].ToString();
                }
            }

        }

        public void dataonpageload()
        {
            string _stroppid = (string)Session["oppId"];
            Label5.Text = _stroppid;
            ParamcolumnsBO finalsend = new ParamcolumnsBO();
            finalsend.OppId = _stroppid;
            Label4.Text = new BLL.RGYBLL().retrieveoppname(finalsend);             
            DataSet dsallrecs = (DataSet)new BLL.RGYBLL().retrieveparams(_stroppid);
            if (dsallrecs.Tables.Count > 0)
            {
                if (dsallrecs.Tables[1].Rows.Count  > 0)
                {
                    DataTable dtBusiness = (DataTable)ViewState["paramcolumnsbusiness"];
                    DataTable dtTechnical = (DataTable)ViewState["paramcolumnstechnical"];
                    DataTable dtService = (DataTable)ViewState["paramcolumnsservice"];
                    DataTable dtTransition = (DataTable)ViewState["paramcolumnstransition"];
                    DataTable dtGovern = (DataTable)ViewState["paramcolumnsgovern"];
                    DataTable dtProcess = (DataTable)ViewState["paramcolumnsHR"];
                    DataTable dtHR = (DataTable)ViewState["paramcolumnsprocess"];
                    DataTable dtCommercials = (DataTable)ViewState["paramcolumnscommercial"];
                    DataTable dtIntegration = (DataTable)ViewState["paramcolumnsint"];
                    for (int i = 0; i <= dsallrecs.Tables[1].Rows.Count - 1; i++)
                    {
                        if (Convert.ToInt32(dsallrecs.Tables[1].Rows[i].ItemArray[2]) == 1)
                        {
                            DataRow dr = dtBusiness.NewRow();
                            dr[0] = dsallrecs.Tables[1].Rows[i].ItemArray[3].ToString();
                            dr[1] = dsallrecs.Tables[1].Rows[i].ItemArray[4].ToString();
                            dr[2] = dsallrecs.Tables[1].Rows[i].ItemArray[5].ToString();
                            dr[3] = dsallrecs.Tables[1].Rows[i].ItemArray[6].ToString();
                            dr[4] = dsallrecs.Tables[1].Rows[i].ItemArray[7].ToString();
                            dr[5] = dsallrecs.Tables[1].Rows[i].ItemArray[8].ToString();
                            dtBusiness.Rows.Add(dr);
                            ViewState["keybusiness"] = dtBusiness;
                        }
                        if (Convert.ToInt32(dsallrecs.Tables[1].Rows[i].ItemArray[2]) == 2)
                        {
                            DataRow dr = dtTechnical.NewRow();
                            dr[0] = dsallrecs.Tables[1].Rows[i].ItemArray[3].ToString();
                            dr[1] = dsallrecs.Tables[1].Rows[i].ItemArray[4].ToString();
                            dr[2] = dsallrecs.Tables[1].Rows[i].ItemArray[5].ToString();
                            dr[3] = dsallrecs.Tables[1].Rows[i].ItemArray[6].ToString();
                            dr[4] = dsallrecs.Tables[1].Rows[i].ItemArray[7].ToString();
                            dr[5] = dsallrecs.Tables[1].Rows[i].ItemArray[8].ToString();
                            dtTechnical.Rows.Add(dr);
                            ViewState["technical"] = dtTechnical;
                        }
                        if (Convert.ToInt32(dsallrecs.Tables[1].Rows[i].ItemArray[2]) == 3)
                        {
                            DataRow dr = dtService.NewRow();
                            dr[0] = dsallrecs.Tables[1].Rows[i].ItemArray[3].ToString();
                            dr[1] = dsallrecs.Tables[1].Rows[i].ItemArray[4].ToString();
                            dr[2] = dsallrecs.Tables[1].Rows[i].ItemArray[5].ToString();
                            dr[3] = dsallrecs.Tables[1].Rows[i].ItemArray[6].ToString();
                            dr[4] = dsallrecs.Tables[1].Rows[i].ItemArray[7].ToString();
                            dr[5] = dsallrecs.Tables[1].Rows[i].ItemArray[8].ToString();
                            dtService.Rows.Add(dr);
                            ViewState["service"] = dtService;
                        }
                        if (Convert.ToInt32(dsallrecs.Tables[1].Rows[i].ItemArray[2]) == 4)
                        {
                            DataRow dr = dtTransition.NewRow();
                            dr[0] = dsallrecs.Tables[1].Rows[i].ItemArray[3].ToString();
                            dr[1] = dsallrecs.Tables[1].Rows[i].ItemArray[4].ToString();
                            dr[2] = dsallrecs.Tables[1].Rows[i].ItemArray[5].ToString();
                            dr[3] = dsallrecs.Tables[1].Rows[i].ItemArray[6].ToString();
                            dr[4] = dsallrecs.Tables[1].Rows[i].ItemArray[7].ToString();
                            dr[5] = dsallrecs.Tables[1].Rows[i].ItemArray[8].ToString();
                            dtTransition.Rows.Add(dr);
                            ViewState["transition"] = dtTransition;
                        }
                        if (Convert.ToInt32(dsallrecs.Tables[1].Rows[i].ItemArray[2]) == 5)
                        {
                            DataRow dr = dtGovern.NewRow();
                            dr[0] = dsallrecs.Tables[1].Rows[i].ItemArray[3].ToString();
                            dr[1] = dsallrecs.Tables[1].Rows[i].ItemArray[4].ToString();
                            dr[2] = dsallrecs.Tables[1].Rows[i].ItemArray[5].ToString();
                            dr[3] = dsallrecs.Tables[1].Rows[i].ItemArray[6].ToString();
                            dr[4] = dsallrecs.Tables[1].Rows[i].ItemArray[7].ToString();
                            dr[5] = dsallrecs.Tables[1].Rows[i].ItemArray[8].ToString();
                            dtGovern.Rows.Add(dr);
                            ViewState["govern"] = dtGovern;
                        }
                        if (Convert.ToInt32(dsallrecs.Tables[1].Rows[i].ItemArray[2]) == 6)
                        {
                            DataRow dr = dtProcess.NewRow();
                            dr[0] = dsallrecs.Tables[1].Rows[i].ItemArray[3].ToString();
                            dr[1] = dsallrecs.Tables[1].Rows[i].ItemArray[4].ToString();
                            dr[2] = dsallrecs.Tables[1].Rows[i].ItemArray[5].ToString();
                            dr[3] = dsallrecs.Tables[1].Rows[i].ItemArray[6].ToString();
                            dr[4] = dsallrecs.Tables[1].Rows[i].ItemArray[7].ToString();
                            dr[5] = dsallrecs.Tables[1].Rows[i].ItemArray[8].ToString();
                            dtProcess.Rows.Add(dr);
                            ViewState["process"] = dtProcess;
                        }
                        if (Convert.ToInt32(dsallrecs.Tables[1].Rows[i].ItemArray[2]) == 7)
                        {
                            DataRow dr = dtHR.NewRow();
                            dr[0] = dsallrecs.Tables[1].Rows[i].ItemArray[3].ToString();
                            dr[1] = dsallrecs.Tables[1].Rows[i].ItemArray[4].ToString();
                            dr[2] = dsallrecs.Tables[1].Rows[i].ItemArray[5].ToString();
                            dr[3] = dsallrecs.Tables[1].Rows[i].ItemArray[6].ToString();
                            dr[4] = dsallrecs.Tables[1].Rows[i].ItemArray[7].ToString();
                            dr[5] = dsallrecs.Tables[1].Rows[i].ItemArray[8].ToString();
                            dtHR.Rows.Add(dr);
                            ViewState["HR"] = dtHR;
                        }
                        if (Convert.ToInt32(dsallrecs.Tables[1].Rows[i].ItemArray[2]) == 8)
                        {
                            DataRow dr = dtCommercials.NewRow();
                            dr[0] = dsallrecs.Tables[1].Rows[i].ItemArray[3].ToString();
                            dr[1] = dsallrecs.Tables[1].Rows[i].ItemArray[4].ToString();
                            dr[2] = dsallrecs.Tables[1].Rows[i].ItemArray[5].ToString();
                            dr[3] = dsallrecs.Tables[1].Rows[i].ItemArray[6].ToString();
                            dr[4] = dsallrecs.Tables[1].Rows[i].ItemArray[7].ToString();
                            dr[5] = dsallrecs.Tables[1].Rows[i].ItemArray[8].ToString();
                            dtCommercials.Rows.Add(dr);
                            ViewState["commercial"] = dtCommercials;
                        }
                        if (Convert.ToInt32(dsallrecs.Tables[1].Rows[i].ItemArray[2]) == 9)
                        {
                            DataRow dr = dtIntegration.NewRow();
                            dr[0] = dsallrecs.Tables[1].Rows[i].ItemArray[3].ToString();
                            dr[1] = dsallrecs.Tables[1].Rows[i].ItemArray[4].ToString();
                            dr[2] = dsallrecs.Tables[1].Rows[i].ItemArray[5].ToString();
                            dr[3] = dsallrecs.Tables[1].Rows[i].ItemArray[6].ToString();
                            dr[4] = dsallrecs.Tables[1].Rows[i].ItemArray[7].ToString();
                            dr[5] = dsallrecs.Tables[1].Rows[i].ItemArray[8].ToString();
                            dtIntegration.Rows.Add(dr);
                            ViewState["integration"] = dtIntegration;
                        }  
                }

                    
                    gridbusiness.DataSource = dtBusiness;
                    gridtechnical.DataSource = dtTechnical;
                    gridservice.DataSource = dtService;
                    gridtransition.DataSource = dtTransition;
                    gridgovern.DataSource = dtGovern;
                    gridprocess.DataSource = dtProcess;
                    gridhr.DataSource = dtHR;
                    gridcommercial.DataSource = dtCommercials;
                    gridintegration.DataSource = dtIntegration;
                    gridbusiness.DataBind();
                    gridtechnical.DataBind();
                    gridservice.DataBind();
                    gridtransition.DataBind();
                    gridgovern.DataBind();
                    gridprocess.DataBind();
                    gridhr.DataBind();
                    gridcommercial.DataBind();
                    gridintegration.DataBind();
                    btn1save();
                    btnSaveTech();
                    btnSaveService();
                    btnSaveTrans();
                    btnSaveGov();
                    btnSaveProc();
                    btnSaveHR();
                    btnSaveCommercial();
                    btnSaveInt();
                   
            }
                if (dsallrecs.Tables[0].Rows.Count > 0)
                {
                    finallbl.Text = dsallrecs.Tables[0].Rows[0].ItemArray[2].ToString() + "%";
                    givecolortofinalscore(dsallrecs.Tables[0].Rows[0].ItemArray[2].ToString());
                    lblBusinessSolutionAverageScore.Text = dsallrecs.Tables[0].Rows[0].ItemArray[3].ToString().Split('.')[0];
                    lblTechnicalSolutionAverageScore.Text = dsallrecs.Tables[0].Rows[0].ItemArray[4].ToString().Split('.')[0];
                    seravscore.Text = dsallrecs.Tables[0].Rows[0].ItemArray[5].ToString().Split('.')[0];
                    tranavscore.Text = dsallrecs.Tables[0].Rows[0].ItemArray[6].ToString().Split('.')[0];
                    govavscore.Text = dsallrecs.Tables[0].Rows[0].ItemArray[7].ToString().Split('.')[0];
                    proavscore.Text = dsallrecs.Tables[0].Rows[0].ItemArray[8].ToString().Split('.')[0];
                    hravscore.Text = dsallrecs.Tables[0].Rows[0].ItemArray[9].ToString().Split('.')[0];
                    comavscore.Text = dsallrecs.Tables[0].Rows[0].ItemArray[10].ToString().Split('.')[0];
                    intavscore.Text = dsallrecs.Tables[0].Rows[0].ItemArray[11].ToString().Split('.')[0];
                    //getfinalscorepercent();
                    if (Convert.ToBoolean(dsallrecs.Tables[0].Rows[0].ItemArray[13].ToString()) == false)
                    {
                        lblIterativeCount.Text = "Iterative Checklist(" + dsallrecs.Tables[0].Rows[0].ItemArray[12].ToString() + ")";
                        ddlrgytype.SelectedValue = "1";
                    }
                    else if (Convert.ToBoolean(dsallrecs.Tables[0].Rows[0].ItemArray[13].ToString()) == true)
                    {
                        lblIterativeCount.Text = "Final Checklist";
                        ddlrgytype.SelectedValue = "2";
                    }
                    if (string.IsNullOrEmpty(dsallrecs.Tables[0].Rows[0].ItemArray[14].ToString()))
                    {
                        lblApprovedResult.Text = "Submitted";
                    }
                    else
                    {
                        if (Convert.ToBoolean(dsallrecs.Tables[0].Rows[0].ItemArray[14].ToString()) == false)
                        {
                            lblApprovedResult.Text = "Not Approved";
                        }
                        else if (Convert.ToBoolean(dsallrecs.Tables[0].Rows[0].ItemArray[14].ToString()) == true)
                        {
                            lblApprovedResult.Text = "Approved";
                        }
                    }
                    if (string.IsNullOrEmpty(dsallrecs.Tables[0].Rows[0].ItemArray[15].ToString()))
                    {
                    }
                    else {
                        txtwinthemetext.Text = dsallrecs.Tables[0].Rows[0].ItemArray[15].ToString();
                    
                    }
                    if (string.IsNullOrEmpty(dsallrecs.Tables[0].Rows[0].ItemArray[16].ToString()))
                    {
                    }
                    else
                    {
                        txtcomments.Text = dsallrecs.Tables[0].Rows[0].ItemArray[16].ToString();
                    }
                    
                }
            
            }
           
        }

        public void pageload()
        {
            if (!IsPostBack)
            {
                string _strOppid = string.Empty;
                int _intdesinationid = 0;
                getweightage();
                SetInitialRow();
                populatelevel();
                //ddlrgytype.Attributes.Add("onChange", "return ifFinalChecklist();");

                if (Session["Oppid"] != null && Session["Designation"] != null)
                {
                    _strOppid = (string)Session["Oppid"];
                    _intdesinationid = (int)Session["Designation"];
                }
                else
                {
                    Response.Redirect("/Login/SignInPage.aspx");
                }
                hidAccordionIndex.Value = "0";
                DataSet dsretrieveparams = (DataSet)new BLL.RGYBLL().retrieveparams(_strOppid);
                if (_intdesinationid == clsDesignationList.GetDesignationID(EnumDesignation.BidCoordinator))
                {
                    ifNotToBeSubmitted();



                    if (dsretrieveparams.Tables[0] != null && dsretrieveparams.Tables[0].Rows.Count > 0)
                    {
                        dataonpageload();
                        disablecontrols();
                        if (Convert.ToBoolean(dsretrieveparams.Tables[0].Rows[0].ItemArray[13].ToString()) == true)
                        {
                            btnmodifychecklist.Visible = false;
                            btnmodifychecklist.Enabled = false;
                        }
                        else
                        {
                            btnmodifychecklist.Visible = true;
                            btnmodifychecklist.Enabled = true;
                        }
                        
                    }
                    else
                    {
                        dataonpageloadbackup();
                        btnmodifychecklist.Visible = false;
                        btnmodifychecklist.Enabled = false;
                    }
                    int _intstatus = 0;
                    if (dsretrieveparams.Tables.Count > 0)
                    {
                        if (dsretrieveparams.Tables[0].Rows.Count > 0)
                        {
                            if (string.IsNullOrEmpty(dsretrieveparams.Tables[0].Rows[0][14].ToString()))
                            {
                                lblApprovedResult.Text = "Submitted";
                            }
                            else
                            {
                                if (Convert.ToInt32(dsretrieveparams.Tables[0].Rows[0][14]) != 0)
                                {
                                    _intstatus = Convert.ToInt32(dsretrieveparams.Tables[0].Rows[0][14]);
                                    lblApprovedResult.Text = "Approved";
                                }
                                else
                                {
                                    _intstatus = 0;
                                    lblcomments.Visible = true;
                                    txtcomments.Visible = true;
                                    txtcomments.Enabled = false;
                                    lblApprovedResult.Text = "Not Approved";
                                }
                            }
                        }
                        else
                        {
                            _intstatus = 0;
                            lblApprovedResult.Text = "Not Submitted";
                        }
                    }
                    else
                    {
                        _intstatus = 0;
                        lblApprovedResult.Text = "Not Submitted";
                    }

                }
                else if (_intdesinationid == clsDesignationList.GetDesignationID(EnumDesignation.BidManager))
                {
                    forBidManager(_strOppid, dsretrieveparams);
                    int _intstatus = 0;

                    if (dsretrieveparams.Tables.Count > 0)
                    {
                        if (dsretrieveparams.Tables[0].Rows.Count > 0)
                        {
                                if (string.IsNullOrEmpty((dsretrieveparams.Tables[0].Rows[0][14]).ToString()))
                                {
                                    btnSubmit.Visible = true;
                                    btnSubmit.Enabled = false;
                                    ddlapproval.Visible = true;
                                    lblapproval.Visible = true;
                                    lblApprovedResult.Text = "Submitted";
                                }
                                else if (Convert.ToInt32(dsretrieveparams.Tables[0].Rows[0][14]) == 1)
                                {
                                    _intstatus = Convert.ToInt32(dsretrieveparams.Tables[0].Rows[0][14]);
                                    txtcomments.Visible = false;
                                    txtcomments.ReadOnly = false;
                                    lblApprovedResult.Text = "Approved";
                                }
                                else
                                {
                                    _intstatus = 0;
                                    txtcomments.Visible = true;
                                    txtcomments.Enabled = false;
                                    lblcomments.Visible = true;
                                    lblApprovedResult.Text = "Not Approved";
                                }
                            
                        }
                        else
                        {
                            _intstatus = 0;
                            lblApprovedResult.Text = "Not Submitted";
                        }
                    }
                    else
                    {
                        _intstatus = 0;
                        lblApprovedResult.Text = "Not Submitted";
                    }
                }
                else
                {
                    dataonpageload();
                    disablecontrols();
                    lblapproval.Visible = false;
                    lblcomments.Visible = false;
                }

                getweightage();
                //getfinalscorepercent();

                ParamcolumnsBO finalsend = new ParamcolumnsBO();
                finalsend.OppId = _strOppid;
                string _strBidCoordinatorID = new BLL.RGYBLL().GetBidId(finalsend);
                string _dtsubmissionDate = new BLL.RGYBLL().GetSubmissionDate(finalsend);
                if (!string.IsNullOrEmpty(_strBidCoordinatorID))
                {
                    lblBidCoordinatorName.Text = _strBidCoordinatorID.ToString();
                }
                if (!string.IsNullOrEmpty(_dtsubmissionDate))
                {
                    SubDate.Text = _dtsubmissionDate;
                }
            }
        }

        public void dataonpageloadbackup()
        {
            string _stroppid = (string)Session["oppId"];
            DataSet dsallrecsbackup = (DataSet)new BLL.RGYBLL().retrieveparamsbckp(_stroppid);
            if (dsallrecsbackup != null)
            {
                //ViewState[]
                if (dsallrecsbackup.Tables.Count > 0)
                {
                    if (dsallrecsbackup.Tables[1].Rows.Count > 0)
                    {
                        DataTable dtBusiness = (DataTable)ViewState["paramcolumnsbusiness"];
                        DataTable dtTechnical = (DataTable)ViewState["paramcolumnstechnical"];
                        DataTable dtService = (DataTable)ViewState["paramcolumnsservice"];
                        DataTable dtTransition = (DataTable)ViewState["paramcolumnstransition"];
                        DataTable dtGovern = (DataTable)ViewState["paramcolumnsgovern"];
                        DataTable dtProcess = (DataTable)ViewState["paramcolumnsHR"];
                        DataTable dtHR = (DataTable)ViewState["paramcolumnsprocess"];
                        DataTable dtCommercials = (DataTable)ViewState["paramcolumnscommercial"];
                        DataTable dtIntegration = (DataTable)ViewState["paramcolumnsint"];
                        for (int i = 0; i < dsallrecsbackup.Tables[1].Rows.Count; i++)
                        {
                            if (Convert.ToInt32(dsallrecsbackup.Tables[1].Rows[i].ItemArray[2]) == 1)
                            {
                                DataRow dr = dtBusiness.NewRow();
                                dr[0] = dsallrecsbackup.Tables[1].Rows[i].ItemArray[3].ToString();
                                dr[1] = dsallrecsbackup.Tables[1].Rows[i].ItemArray[4].ToString();
                                dr[2] = dsallrecsbackup.Tables[1].Rows[i].ItemArray[5].ToString();
                                dr[3] = dsallrecsbackup.Tables[1].Rows[i].ItemArray[6].ToString();
                                dr[4] = dsallrecsbackup.Tables[1].Rows[i].ItemArray[7].ToString();
                                dr[5] = dsallrecsbackup.Tables[1].Rows[i].ItemArray[8].ToString();
                                dtBusiness.Rows.Add(dr);
                                ViewState["keybusiness"] = dtBusiness;
                               
                            }
                            if (Convert.ToInt32(dsallrecsbackup.Tables[1].Rows[i].ItemArray[2]) == 2)
                            {
                                DataRow dr = dtTechnical.NewRow();
                                dr[0] = dsallrecsbackup.Tables[1].Rows[i].ItemArray[3].ToString();
                                dr[1] = dsallrecsbackup.Tables[1].Rows[i].ItemArray[4].ToString();
                                dr[2] = dsallrecsbackup.Tables[1].Rows[i].ItemArray[5].ToString();
                                dr[3] = dsallrecsbackup.Tables[1].Rows[i].ItemArray[6].ToString();
                                dr[4] = dsallrecsbackup.Tables[1].Rows[i].ItemArray[7].ToString();
                                dr[5] = dsallrecsbackup.Tables[1].Rows[i].ItemArray[8].ToString();
                                dtTechnical.Rows.Add(dr);
                                ViewState["technical"] = dtTechnical;
                                //btnSaveTech();
                            }
                            if (Convert.ToInt32(dsallrecsbackup.Tables[1].Rows[i].ItemArray[2]) == 3)
                            {
                                DataRow dr = dtService.NewRow();
                                dr[0] = dsallrecsbackup.Tables[1].Rows[i].ItemArray[3].ToString();
                                dr[1] = dsallrecsbackup.Tables[1].Rows[i].ItemArray[4].ToString();
                                dr[2] = dsallrecsbackup.Tables[1].Rows[i].ItemArray[5].ToString();
                                dr[3] = dsallrecsbackup.Tables[1].Rows[i].ItemArray[6].ToString();
                                dr[4] = dsallrecsbackup.Tables[1].Rows[i].ItemArray[7].ToString();
                                dr[5] = dsallrecsbackup.Tables[1].Rows[i].ItemArray[8].ToString();
                                dtService.Rows.Add(dr);
                                ViewState["service"] = dtService;
                                //btnSaveService();
                            }
                            if (Convert.ToInt32(dsallrecsbackup.Tables[1].Rows[i].ItemArray[2]) == 4)
                            {
                                DataRow dr = dtTransition.NewRow();
                                dr[0] = dsallrecsbackup.Tables[1].Rows[i].ItemArray[3].ToString();
                                dr[1] = dsallrecsbackup.Tables[1].Rows[i].ItemArray[4].ToString();
                                dr[2] = dsallrecsbackup.Tables[1].Rows[i].ItemArray[5].ToString();
                                dr[3] = dsallrecsbackup.Tables[1].Rows[i].ItemArray[6].ToString();
                                dr[4] = dsallrecsbackup.Tables[1].Rows[i].ItemArray[7].ToString();
                                dr[5] = dsallrecsbackup.Tables[1].Rows[i].ItemArray[8].ToString();
                                dtTransition.Rows.Add(dr);
                                ViewState["transition"] = dtTransition;
                               // btnSaveTrans();
                            }
                            if (Convert.ToInt32(dsallrecsbackup.Tables[1].Rows[i].ItemArray[2]) == 5)
                            {
                                DataRow dr = dtGovern.NewRow();
                                dr[0] = dsallrecsbackup.Tables[1].Rows[i].ItemArray[3].ToString();
                                dr[1] = dsallrecsbackup.Tables[1].Rows[i].ItemArray[4].ToString();
                                dr[2] = dsallrecsbackup.Tables[1].Rows[i].ItemArray[5].ToString();
                                dr[3] = dsallrecsbackup.Tables[1].Rows[i].ItemArray[6].ToString();
                                dr[4] = dsallrecsbackup.Tables[1].Rows[i].ItemArray[7].ToString();
                                dr[5] = dsallrecsbackup.Tables[1].Rows[i].ItemArray[8].ToString();
                                dtGovern.Rows.Add(dr);
                                ViewState["govern"] = dtGovern;
                                //btnSaveGov();
                            }
                            if (Convert.ToInt32(dsallrecsbackup.Tables[1].Rows[i].ItemArray[2]) == 6)
                            {
                                DataRow dr = dtProcess.NewRow();
                                dr[0] = dsallrecsbackup.Tables[1].Rows[i].ItemArray[3].ToString();
                                dr[1] = dsallrecsbackup.Tables[1].Rows[i].ItemArray[4].ToString();
                                dr[2] = dsallrecsbackup.Tables[1].Rows[i].ItemArray[5].ToString();
                                dr[3] = dsallrecsbackup.Tables[1].Rows[i].ItemArray[6].ToString();
                                dr[4] = dsallrecsbackup.Tables[1].Rows[i].ItemArray[7].ToString();
                                dr[5] = dsallrecsbackup.Tables[1].Rows[i].ItemArray[8].ToString();
                                dtProcess.Rows.Add(dr);
                                ViewState["process"] = dtProcess;
                                //btnSaveProc();
                            }
                            if (Convert.ToInt32(dsallrecsbackup.Tables[1].Rows[i].ItemArray[2]) == 7)
                            {
                                DataRow dr = dtHR.NewRow();
                                dr[0] = dsallrecsbackup.Tables[1].Rows[i].ItemArray[3].ToString();
                                dr[1] = dsallrecsbackup.Tables[1].Rows[i].ItemArray[4].ToString();
                                dr[2] = dsallrecsbackup.Tables[1].Rows[i].ItemArray[5].ToString();
                                dr[3] = dsallrecsbackup.Tables[1].Rows[i].ItemArray[6].ToString();
                                dr[4] = dsallrecsbackup.Tables[1].Rows[i].ItemArray[7].ToString();
                                dr[5] = dsallrecsbackup.Tables[1].Rows[i].ItemArray[8].ToString();
                                dtHR.Rows.Add(dr);
                                ViewState["HR"] = dtHR;
                                //btnSaveHR();
                            }
                            if (Convert.ToInt32(dsallrecsbackup.Tables[1].Rows[i].ItemArray[2]) == 8)
                            {
                                DataRow dr = dtCommercials.NewRow();
                                dr[0] = dsallrecsbackup.Tables[1].Rows[i].ItemArray[3].ToString();
                                dr[1] = dsallrecsbackup.Tables[1].Rows[i].ItemArray[4].ToString();
                                dr[2] = dsallrecsbackup.Tables[1].Rows[i].ItemArray[5].ToString();
                                dr[3] = dsallrecsbackup.Tables[1].Rows[i].ItemArray[6].ToString();
                                dr[4] = dsallrecsbackup.Tables[1].Rows[i].ItemArray[7].ToString();
                                dr[5] = dsallrecsbackup.Tables[1].Rows[i].ItemArray[8].ToString();
                                dtCommercials.Rows.Add(dr);
                                ViewState["commercial"] = dtCommercials;
                                //btnSaveCommercial();
                            }
                            if (Convert.ToInt32(dsallrecsbackup.Tables[1].Rows[i].ItemArray[2]) == 9)
                            {
                                DataRow drint = dtIntegration.NewRow();
                                drint[0] = dsallrecsbackup.Tables[1].Rows[i].ItemArray[3].ToString();
                                drint[1] = dsallrecsbackup.Tables[1].Rows[i].ItemArray[4].ToString();
                                drint[2] = dsallrecsbackup.Tables[1].Rows[i].ItemArray[5].ToString();
                                drint[3] = dsallrecsbackup.Tables[1].Rows[i].ItemArray[6].ToString();
                                drint[4] = dsallrecsbackup.Tables[1].Rows[i].ItemArray[7].ToString();
                                drint[5] = dsallrecsbackup.Tables[1].Rows[i].ItemArray[8].ToString();
                                dtIntegration.Rows.Add(drint);
                                ViewState["integration"] = dtIntegration;
                                //btnSaveInt();
                            }
                        }

                        gridbusiness.DataSource = dtBusiness;
                        gridtechnical.DataSource = dtTechnical;
                        gridservice.DataSource = dtService;
                        gridtransition.DataSource = dtTransition;
                        gridgovern.DataSource = dtGovern;
                        gridprocess.DataSource = dtProcess;
                        gridhr.DataSource = dtHR;
                        gridcommercial.DataSource = dtCommercials;
                        gridintegration.DataSource = dtIntegration;
                        gridbusiness.DataBind();
                        gridtechnical.DataBind();
                        gridservice.DataBind();
                        gridtransition.DataBind();
                        gridgovern.DataBind();
                        gridprocess.DataBind();
                        gridhr.DataBind();
                        gridcommercial.DataBind();
                        gridintegration.DataBind();
                        btn1save();
                        btnSaveTech();
                        btnSaveService();
                        btnSaveTrans();
                        btnSaveGov();
                        btnSaveProc();
                        btnSaveHR();
                        btnSaveCommercial();
                        btnSaveInt();
                        Hashtable hs = (Hashtable)ViewState["allrecords"];
                        if (hs.Keys.Count >= 8)
                        {
                            int records = 0;
                            int reccount = 0;
                            for (int i = 1; i <= 9; i++)
                            {
                                ArrayList paramlist = ((ArrayList)hs[i]);
                                records = paramlist.Count;
                                if (records > 0)
                                {
                                    reccount += 1;
                                }
                            }
                            if (reccount >= 9)
                            {
                                btnSubmit.Visible = true;  // btnSubmit.Focus();
                            }
                        }

                    }
                    if (dsallrecsbackup.Tables[0].Rows.Count > 0)
                    {
                        finallbl.Text = dsallrecsbackup.Tables[0].Rows[0].ItemArray[2].ToString() + "%";
                        givecolortofinalscore(dsallrecsbackup.Tables[0].Rows[0].ItemArray[2].ToString());
                        lblBusinessSolutionAverageScore.Text = dsallrecsbackup.Tables[0].Rows[0].ItemArray[3].ToString().Split('.')[0];
                        lblTechnicalSolutionAverageScore.Text = dsallrecsbackup.Tables[0].Rows[0].ItemArray[4].ToString().Split('.')[0];
                        seravscore.Text = dsallrecsbackup.Tables[0].Rows[0].ItemArray[5].ToString().Split('.')[0];
                        tranavscore.Text = dsallrecsbackup.Tables[0].Rows[0].ItemArray[6].ToString().Split('.')[0];
                        govavscore.Text = dsallrecsbackup.Tables[0].Rows[0].ItemArray[7].ToString().Split('.')[0];
                        proavscore.Text = dsallrecsbackup.Tables[0].Rows[0].ItemArray[8].ToString().Split('.')[0];
                        hravscore.Text = dsallrecsbackup.Tables[0].Rows[0].ItemArray[9].ToString().Split('.')[0];
                        comavscore.Text = dsallrecsbackup.Tables[0].Rows[0].ItemArray[10].ToString().Split('.')[0];
                        intavscore.Text = dsallrecsbackup.Tables[0].Rows[0].ItemArray[11].ToString();
                        getfinalscorepercent();
                        if (Convert.ToBoolean(dsallrecsbackup.Tables[0].Rows[0].ItemArray[13].ToString()) == false)
                        {
                            lblIterativeCount.Text = "Iterative Checklist(" + dsallrecsbackup.Tables[0].Rows[0].ItemArray[12].ToString() + ")";
                            ddlrgytype.SelectedValue = "1";
                            RGYBLL iterative = new RGYBLL();
                            int iterationCount = (int)iterative.GetIterativeCount(_stroppid);
                            ViewState["iterationcount"] = (iterationCount + 1);

                        }
                        else if (Convert.ToBoolean(dsallrecsbackup.Tables[0].Rows[0].ItemArray[13].ToString()) == true)
                        {
                            lblIterativeCount.Text = "Final Checklist";
                            ddlrgytype.SelectedValue = "2";
                            int iterationCount = 0;
                            ViewState["iterationcount"] = iterationCount;
                            ddlrgytype.Enabled = false;
                        }
                        if (string.IsNullOrEmpty(dsallrecsbackup.Tables[0].Rows[0].ItemArray[14].ToString()))
                        {
                            lblApprovedResult.Text = "Not Submitted";
                        }
                        else
                        {
                            if (Convert.ToBoolean(dsallrecsbackup.Tables[0].Rows[0].ItemArray[14].ToString()) == false)
                            {
                                lblApprovedResult.Text = "Not Approved";
                            }
                            else if (Convert.ToBoolean(dsallrecsbackup.Tables[0].Rows[0].ItemArray[14].ToString()) == true)
                            {
                                lblApprovedResult.Text = "Approved";
                            }
                        }
                        if (!string.IsNullOrEmpty(dsallrecsbackup.Tables[0].Rows[0].ItemArray[15].ToString()))
                        {
                            txtwinthemetext.Text = dsallrecsbackup.Tables[0].Rows[0].ItemArray[15].ToString();
                        }
                    }
                }
            }

            else
            {
                dataonpageload();
                btnmodifychecklist.Visible = false;
                btnmodifychecklist.Enabled = false;
            }
        }

        //Automated Email for approval of RGYChecklist

        private void GetStakeholderstoApproveRGYChecklist()
        {
            string _strBidCoordinatorEmail = string.Empty;
            string _strBidManagerEmail = string.Empty;
            string _strBidMangerName = string.Empty;
            string _strOppNumber = string.Empty;

            DataSet dsStakeHoldersDetails = new BLL.AutomatedMailBLL().getStakeholderstoApproveRGYChecklist((string)Session["oppid"]);

            if (dsStakeHoldersDetails.Tables.Count > 0)
            {
                if (dsStakeHoldersDetails.Tables[0].Rows.Count > 0)
                {
                    _strBidCoordinatorEmail = dsStakeHoldersDetails.Tables[0].Rows[0][1].ToString();
                }
                if (dsStakeHoldersDetails.Tables[1].Rows.Count > 0)
                {
                    _strBidMangerName = dsStakeHoldersDetails.Tables[1].Rows[0][0].ToString();
                    _strBidManagerEmail = dsStakeHoldersDetails.Tables[1].Rows[0][1].ToString();
                }
            }

            //string _EmailServer = "cas2.syntelorg.com";
            string _EmailBody = "<html><body><div style='border:1px solid black;padding:10px;font-family:arial'> Dear " + _strBidMangerName + " ";
            _EmailBody += "</br>";
            _EmailBody += "</br>";
            _EmailBody += "<p style='colr:red;'>RGYChecklist inputs and score is completed for Opportunity number " + _strOppNumber + ". Please approve the Opportunity</p> ";
            _EmailBody += "</br>";
            _EmailBody += "To Access the LDF Application Please Click on Link below";
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

            MailMessage myhtmlMessage = new MailMessage(fromAddress.ToString(), _strBidManagerEmail, "Automated Mail for Approval RGYChecklist", _EmailBody);
            myhtmlMessage.CC.Add(_strBidCoordinatorEmail);
            myhtmlMessage.CC.Add("priyanka_datir@syntelinc.com"); 
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

        private void GetStakeholdersforStatusRGYChecklist()
        {
            string _strBidCoordinatorEmail = string.Empty;
            string _strBidManagerEmail = string.Empty;
            string _strBidManagerName = string.Empty;
            string _strBidCoordinatorName = string.Empty;
            string _strBUHeadEmail = string.Empty;
            string _strOppNumber = string.Empty;
            string _strStatus = lblApprovedResult.Text;

            DataSet dsStakeHoldersDetails = new BLL.AutomatedMailBLL().getStakeholderstoApproveRGYChecklist((string)Session["Oppid"]);

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
                if (dsStakeHoldersDetails.Tables[2].Rows.Count > 0)
                {
                    _strBidManagerName = dsStakeHoldersDetails.Tables[2].Rows[0][0].ToString();
                    _strBUHeadEmail = dsStakeHoldersDetails.Tables[2].Rows[0][1].ToString();
                }
            }

            //string _EmailServer = "cas2.syntelorg.com";
            string _EmailBody = "<html><body><div style='border:1px solid black;padding:10px;font-family:arial'> Dear " + _strBidCoordinatorName + " ";
            _EmailBody += "</br>";
            _EmailBody += "</br>";
            _EmailBody += "<p style='colr:red;'>RGYChecklist is " + _strStatus + " for Opportunity number " + _strOppNumber + " by " + _strBidManagerName + " </p> ";
            _EmailBody += "</br>";
            _EmailBody += "To Access the LDF Application Please Click on Link below";
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

              MailMessage myhtmlMessage = new MailMessage(fromAddress.ToString(), _strBidCoordinatorEmail, "Automated Mail for Status RGYChecklist", _EmailBody);
            myhtmlMessage.IsBodyHtml = true;
            myhtmlMessage.CC.Add(_strBUHeadEmail);
            myhtmlMessage.CC.Add(_strBidManagerEmail);

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

        #endregion

        #region Add Buttons

        protected void clearTextBoxesBusinessSolutions()
        {
            txtkeybusi.Text = String.Empty;
            txtimpact.Text = String.Empty;
            ddllevel.SelectedIndex=0;
            txtgaps.Text = String.Empty;
            txtowner.Text = String.Empty;
            datepicker.Text = String.Empty;
        }
        protected void btnAddBusinessSolution_Click(object sender, EventArgs e)
        {
            DataTable dtcoltable = new DataTable();
            try
            {
                if (txtkeybusi.Text != string.Empty && txtgaps.Text != string.Empty && txtowner.Text != string.Empty &&
                    datepicker.Text != string.Empty && txtimpact.Text != string.Empty && ddllevel.SelectedIndex != 0)
                {
                    if (ViewState["keybusiness"] != null)
                    {
                        dtcoltable = (DataTable)ViewState["keybusiness"];
                    }
                    else
                    {
                        dtcoltable = (DataTable)ViewState["paramcolumnsbusiness"];
                    }

                    foreach (DataRow dr in dtcoltable.Rows)
                    {
                        string _strkeyclientreq = dr[0].ToString();
                        if (txtkeybusi.Text.ToLower() == _strkeyclientreq.ToLower())
                        {
                            lblBusinessSolutionError.Text = "The Key Client Requirement entered already exists";
                            clearTextBoxesBusinessSolutions();
                            return;
                        }
                        else lblBusinessSolutionError.Text = string.Empty;
                    }
                    DataRow drCurrentRow = dtcoltable.NewRow();
                    drCurrentRow["keyclientrequirement"] = txtkeybusi.Text.ToString();
                    drCurrentRow["impactonwhichpart"] = txtimpact.Text.ToString();
                    drCurrentRow["level"] = ddllevel.SelectedItem.Text.ToString();
                    drCurrentRow["improvementarea"] = txtgaps.Text.ToString();
                    drCurrentRow["ownertoaddressarea"] = txtowner.Text.ToString();
                    if (datepicker.Text != string.Empty)
                    {
                        DateTime d = Convert.ToDateTime(datepicker.Text.ToString());
                        drCurrentRow["reviewdate"] = d;
                    }
                   
                    dtcoltable.Rows.Add(drCurrentRow);
                    ViewState["keybusiness"] = dtcoltable;
                    gridbusiness.DataSource = dtcoltable;
                    gridbusiness.DataBind();

                    btn1save();
                    getfinalscorepercent();
                    
                    hidAccordionIndex.Value = "0";
                    clearTextBoxesBusinessSolutions();
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

        protected void clearTextBoxes2()
        {
            txtKeyReqTech.Text = String.Empty;
            txtImpactTech.Text = String.Empty;
            ddLevelTech.SelectedIndex=0;
            txtGapsTech.Text = String.Empty;
            txtOwnerTech.Text = String.Empty;
            txtDateTech.Text = String.Empty;
        }
        protected void btnAddTechnicalSolution_Click(object sender, EventArgs e)
        {
            DataTable coltable;
            try
            {
                if (ViewState["technical"] != null)
                {
                    coltable = (DataTable)ViewState["technical"];
                }
                else
                {
                    coltable = (DataTable)ViewState["paramcolumnstechnical"];
                }
                foreach (DataRow dr in coltable.Rows)
                {
                    string keycl = dr[0].ToString();
                    if (txtKeyReqTech.Text.ToLower() == keycl.ToLower())
                    {
                        lblTechnicalSolutionError.Text = "The Key Client Requirement entered already exists";
                        clearTextBoxes2();
                        return;
                    }
                    else lblTechnicalSolutionError.Text = string.Empty;
                }
                DataRow drCurrentRow = coltable.NewRow();
                drCurrentRow["keyclientrequirement"] = txtKeyReqTech.Text.ToString();
                drCurrentRow["impactonwhichpart"] = txtImpactTech.Text.ToString();
                drCurrentRow["level"] = ddLevelTech.SelectedItem.Text.ToString();
                drCurrentRow["improvementarea"] = txtGapsTech.Text.ToString();
                drCurrentRow["ownertoaddressarea"] = txtOwnerTech.Text.ToString();
                drCurrentRow["reviewdate"] = txtDateTech.Text.ToString();
                coltable.Rows.Add(drCurrentRow);
                ViewState["technical"] = coltable;
                gridtechnical.DataSource = coltable;
                gridtechnical.DataBind();
                int count =gridtechnical.Rows.Count;
                btnSaveTech();
                getfinalscorepercent();
                hidAccordionIndex.Value = "1";
                clearTextBoxes2();
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

        protected void clearTextBoxes3()
        {
            txtKeyReqServ.Text = String.Empty;
            txtImpactServ.Text = String.Empty;
            ddLevelServ.SelectedIndex=0;
            txtGapServ.Text = String.Empty;
            txtOwnerServ.Text = String.Empty;
            txtDateServ.Text = String.Empty;
        }
        protected void btnAddServiceDeliveryModel_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable coltable = new DataTable();
                if (ViewState["service"] != null)
                {
                    coltable = (DataTable)ViewState["service"];
                }
                else
                {
                    coltable = (DataTable)ViewState["paramcolumnsservice"];
                }
                foreach (DataRow dr in coltable.Rows)
                {
                    string keycl = dr[0].ToString();
                    if (txtKeyReqServ.Text.ToLower() == keycl.ToLower())
                    {
                        lblgridsererr.Text = "The Key Client Requirement entered already exists";
                        clearTextBoxes3();
                        return;
                    }
                    else lblgridsererr.Text = string.Empty;
                }
                DataRow drCurrentRow = coltable.NewRow();
                drCurrentRow["keyclientrequirement"] = txtKeyReqServ.Text.ToString();
                drCurrentRow["impactonwhichpart"] = txtImpactServ.Text.ToString();
                drCurrentRow["level"] = ddLevelServ.SelectedItem.Text.ToString();
                drCurrentRow["improvementarea"] = txtGapServ.Text.ToString();
                drCurrentRow["ownertoaddressarea"] = txtOwnerServ.Text.ToString();
                drCurrentRow["reviewdate"] = txtDateServ.Text.ToString();
                coltable.Rows.Add(drCurrentRow);
                ViewState["service"] = coltable;
                gridservice.DataSource = coltable;
                gridservice.DataBind();
                int count = gridservice.Rows.Count;
                btnSaveService();
                getfinalscorepercent();
                hidAccordionIndex.Value = "2";
                clearTextBoxes3();
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

        protected void clearTextBoxes4()
        {
            txtKeyReqTrans.Text = String.Empty;
            txtImpactTrans.Text = String.Empty;
            ddLevelTrans.SelectedIndex=0;
            txtGapsTrans.Text = String.Empty;
            txtOwnrTrans.Text = String.Empty;
            txtDateTrans.Text = String.Empty;
        }
        protected void btnAddTransitionPlanning_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable coltable = new DataTable();
                if (ViewState["transition"] != null)
                {
                    coltable = (DataTable)ViewState["transition"];
                }
                else
                {
                    coltable = (DataTable)ViewState["paramcolumnstransition"];
                }
                foreach (DataRow dr in coltable.Rows)
                {
                    string keycl = dr[0].ToString();
                    if (txtKeyReqTrans.Text.ToLower() == keycl.ToLower())
                    {
                        lblgridtransitionerror.Text = "The Key Client Requirement entered already exists";
                        clearTextBoxes4();
                        return;
                    }
                    else lblgridtransitionerror.Text = string.Empty;
                }
                DataRow drCurrentRow = coltable.NewRow();
                drCurrentRow["keyclientrequirement"] = txtKeyReqTrans.Text.ToString();
                drCurrentRow["impactonwhichpart"] = txtImpactTrans.Text.ToString();
                drCurrentRow["level"] = ddLevelTrans.SelectedItem.Text.ToString();
                drCurrentRow["improvementarea"] = txtGapsTrans.Text.ToString();
                drCurrentRow["ownertoaddressarea"] = txtOwnrTrans.Text.ToString();
                drCurrentRow["reviewdate"] = txtDateTrans.Text.ToString();
                coltable.Rows.Add(drCurrentRow);
                ViewState["transition"] = coltable;
                gridtransition.DataSource = coltable;
                gridtransition.DataBind();
                int count = gridtransition.Rows.Count;
                btnSaveTrans();
                getfinalscorepercent();
                hidAccordionIndex.Value = "3";
                clearTextBoxes4();
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

        protected void clearTextBoxes5()
        {
            txtKeyReqGov.Text = String.Empty;
            txtImpactGov.Text = String.Empty;
            ddLevelGov.SelectedIndex=0;
            txtGapsGov.Text = String.Empty;
            txtOwnrGov.Text = String.Empty;
            txtDateGov.Text = String.Empty;
        }
        protected void btnAddGovernance_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable coltable = new DataTable();
                if (ViewState["govern"] != null)
                {
                    coltable = (DataTable)ViewState["govern"];
                }
                else
                {
                    coltable = (DataTable)ViewState["paramcolumnsgovern"];
                }
                foreach (DataRow dr in coltable.Rows)
                {
                    string keycl = dr[0].ToString();
                    if (txtKeyReqGov.Text.ToLower() == keycl.ToLower())
                    {
                        lblgridgovernerror.Text = "The Key Client Requirement entered already exists";
                        clearTextBoxes5();
                        return;
                    }
                    else lblgridgovernerror.Text = string.Empty;
                }
                DataRow drCurrentRow = coltable.NewRow();
                drCurrentRow["keyclientrequirement"] = txtKeyReqGov.Text.ToString();
                drCurrentRow["impactonwhichpart"] = txtImpactGov.Text.ToString();
                drCurrentRow["level"] = ddLevelGov.SelectedItem.Text.ToString();
                drCurrentRow["improvementarea"] = txtGapsGov.Text.ToString();
                drCurrentRow["ownertoaddressarea"] = txtOwnrGov.Text.ToString();
                drCurrentRow["reviewdate"] = txtDateGov.Text.ToString();
                coltable.Rows.Add(drCurrentRow);
                ViewState["govern"] = coltable;
                gridgovern.DataSource = coltable;
                gridgovern.DataBind();
                int count = gridgovern.Rows.Count;
                getfinalscorepercent();
                btnSaveGov();
                hidAccordionIndex.Value = "4";
                clearTextBoxes5();
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

        protected void clearTextBoxes6()
        {
            txtKeyReqProc.Text = String.Empty;
            txtImpactProc.Text = String.Empty;
            ddLevelProc.SelectedIndex=0;
            txtGapsProc.Text = String.Empty;
            txtOwnrProc.Text = String.Empty;
            txtDateProc.Text = String.Empty;
        }
        protected void btnAddProcess_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable coltable = new DataTable();
                if (ViewState["process"] != null)
                {
                    coltable = (DataTable)ViewState["process"];
                }
                else
                {
                    coltable = (DataTable)ViewState["paramcolumnsprocess"];
                }
                foreach (DataRow dr in coltable.Rows)
                {
                    string keycl = dr[0].ToString();
                    if (txtKeyReqProc.Text.ToLower() == keycl.ToLower())
                    {
                        lblgridprocesserror.Text = "The Key Client Requirement entered already exists";
                        clearTextBoxes6();
                        return;
                    }
                    else lblgridprocesserror.Text = string.Empty;
                }
                DataRow drCurrentRow = coltable.NewRow();
                drCurrentRow["keyclientrequirement"] = txtKeyReqProc.Text.ToString();
                drCurrentRow["impactonwhichpart"] = txtImpactProc.Text.ToString();
                drCurrentRow["level"] = ddLevelProc.SelectedItem.Text.ToString();
                drCurrentRow["improvementarea"] = txtGapsProc.Text.ToString();
                drCurrentRow["ownertoaddressarea"] = txtOwnrProc.Text.ToString();
                drCurrentRow["reviewdate"] = txtDateProc.Text.ToString();
                coltable.Rows.Add(drCurrentRow);
                ViewState["process"] = coltable;
                gridprocess.DataSource = coltable;
                gridprocess.DataBind();
                int count = gridprocess.Rows.Count;
                btnSaveProc();
                getfinalscorepercent();
                hidAccordionIndex.Value = "5";
                clearTextBoxes6();
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

        protected void clearTextBoxes7()
        {
            txtKeyReqHR.Text = String.Empty;
            txtImpactHR.Text = String.Empty;
            ddLevelHR.SelectedIndex=0;
            txtGapsHR.Text = String.Empty;
            txtOwnrHR.Text = String.Empty;
            txtDateHR.Text = String.Empty;
        }
        protected void btnAddHrChangeManagement_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable coltable = new DataTable();
                if (ViewState["HR"] != null)
                {
                    coltable = (DataTable)ViewState["HR"];
                }
                else
                {
                    coltable = (DataTable)ViewState["paramcolumnsHR"];
                }
                foreach (DataRow dr in coltable.Rows)
                {
                    string keycl = dr[0].ToString();
                    if (txtKeyReqHR.Text.ToLower() == keycl.ToLower())
                    {
                        lblgridhrerror.Text = "The Key Client Requirement entered already exists";
                        clearTextBoxes7();
                        return;
                    }
                    else lblgridhrerror.Text = string.Empty;
                }
                DataRow drCurrentRow = coltable.NewRow();
                drCurrentRow["keyclientrequirement"] = txtKeyReqHR.Text.ToString();
                drCurrentRow["impactonwhichpart"] = txtImpactHR.Text.ToString();
                drCurrentRow["level"] = ddLevelHR.SelectedItem.Text.ToString();
                drCurrentRow["improvementarea"] = txtGapsHR.Text.ToString();
                drCurrentRow["ownertoaddressarea"] = txtOwnrHR.Text.ToString();
                drCurrentRow["reviewdate"] = txtDateHR.Text.ToString();
                coltable.Rows.Add(drCurrentRow);
                ViewState["HR"] = coltable;
                gridhr.DataSource = coltable;
                gridhr.DataBind();
                int count = gridhr.Rows.Count;
                getfinalscorepercent();
                btnSaveHR();
                hidAccordionIndex.Value = "5";
                clearTextBoxes7();
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

        protected void clearTextBoxes8()
        {
            txtKeyReqCom.Text = String.Empty;
            txtImpactCom.Text = String.Empty;
            ddLevelCom.SelectedIndex=0;
            txtGapsCom.Text = String.Empty;
            txtOwnrCom.Text = String.Empty;
            txtDateCom.Text = String.Empty;
        }
        protected void btnAddCommercialsPricing_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable coltable = new DataTable();
                if (ViewState["commercial"] != null)
                {
                    coltable = (DataTable)ViewState["commercial"];
                }
                else
                {
                    coltable = (DataTable)ViewState["paramcolumnscommercial"];
                }
                foreach (DataRow dr in coltable.Rows)
                {
                    string keycl = dr[0].ToString();
                    if (txtKeyReqCom.Text.ToLower() == keycl.ToLower())
                    {
                        lblgridcommercialerror.Text = "The Key Client Requirement entered already exists";
                        clearTextBoxes8();
                        return;
                    }
                    else lblgridcommercialerror.Text = string.Empty;
                }
                DataRow drCurrentRow = coltable.NewRow();
                drCurrentRow["keyclientrequirement"] = txtKeyReqCom.Text.ToString();
                drCurrentRow["impactonwhichpart"] = txtImpactCom.Text.ToString();
                drCurrentRow["level"] = ddLevelCom.SelectedItem.Text.ToString();
                drCurrentRow["improvementarea"] = txtGapsCom.Text.ToString();
                drCurrentRow["ownertoaddressarea"] = txtOwnrCom.Text.ToString();
                drCurrentRow["reviewdate"] = txtDateCom.Text.ToString();
                coltable.Rows.Add(drCurrentRow);
                ViewState["commercial"] = coltable;
                gridcommercial.DataSource = coltable;
                gridcommercial.DataBind();
                int count = gridcommercial.Rows.Count;
                btnSaveCommercial();
                getfinalscorepercent();
                hidAccordionIndex.Value = "7";
                clearTextBoxes8();
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

        protected void clearTextBoxes9()
        {
            txtKeyReqInt.Text = String.Empty;
            txtImpactInt.Text = String.Empty;
            ddLevelInt.SelectedIndex=0;
            txtGapsInt.Text = String.Empty;
            txtOwnrInt.Text = String.Empty;
            txtDateInt.Text = String.Empty;
        }
        protected void btnAddIntegration_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable coltable = new DataTable();
                if (ViewState["integration"] != null)
                {
                    coltable = (DataTable)ViewState["integration"];
                }
                else
                {
                    coltable = (DataTable)ViewState["paramcolumnsint"];
                }
                foreach (DataRow dr in coltable.Rows)
                {
                    string keycl = dr[0].ToString();
                    if (txtKeyReqInt.Text.ToLower() == keycl.ToLower())
                    {
                        lblgridintegrationerror.Text = "The Key Client Requirement entered already exists";
                        clearTextBoxes9();
                        return;
                    }
                    else lblgridintegrationerror.Text = string.Empty;
                }
                DataRow drCurrentRow = coltable.NewRow();
                drCurrentRow["keyclientrequirement"] = txtKeyReqInt.Text.ToString();
                drCurrentRow["impactonwhichpart"] = txtImpactInt.Text.ToString();
                drCurrentRow["level"] = ddLevelInt.SelectedItem.Text.ToString();
                drCurrentRow["improvementarea"] = txtGapsInt.Text.ToString();
                drCurrentRow["ownertoaddressarea"] = txtOwnrInt.Text.ToString();
                drCurrentRow["reviewdate"] = txtDateInt.Text.ToString();
                coltable.Rows.Add(drCurrentRow);
                ViewState["integration"] = coltable;
                gridintegration.DataSource = coltable;
                gridintegration.DataBind();
                int count = gridintegration.Rows.Count;
                btnSaveInt();
                getfinalscorepercent();
                hidAccordionIndex.Value = "8";
                clearTextBoxes9();
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

        #region  Save Buttons

        protected void btn1save()
        {
            try
            {
                ArrayList ParamList = new ArrayList();
                ParamcolumnsBO paramobj;
                int cnt = gridbusiness.Rows.Count;
                int i = 0;
                DataTable sveitems = new DataTable();
                for (i = 0; i < cnt; i++)
                {
                    paramobj = new ParamcolumnsBO();
                    sveitems = (DataTable)ViewState["keybusiness"];
                    paramobj.Keyckientrequirement = sveitems.Rows[i].ItemArray[0].ToString();
                    paramobj.Impactingwhichpart = sveitems.Rows[i].ItemArray[1].ToString();
                    paramobj.Gapsimprovementarea = sveitems.Rows[i].ItemArray[4].ToString();
                    paramobj.Ownertoaddressgaps = sveitems.Rows[i].ItemArray[3].ToString();
                    paramobj.Leveltowhichimprovmrnt = sveitems.Rows[i].ItemArray[2].ToString();
                    paramobj.Reviewdate = Convert.ToDateTime(sveitems.Rows[i].ItemArray[5].ToString());
                    paramobj.OppId = (string)Session["Oppid"];
                    paramobj.Paramid = "1";
                    ParamList.Add(paramobj);
                }
                int count = gridbusiness.Rows.Count;
                if (sveitems != null && sveitems.Rows.Count > 0)
                {
                    for (int a = 0; a < count; a++)
                    {
                        //string val = coltable.Rows[i][2].ToString();
                        if (Convert.ToInt32(sveitems.Rows[a][2].ToString()) < 1)
                        {
                            gridbusiness.Rows[a].Cells[6].BackColor = System.Drawing.Color.Red;
                        }
                        else if (1 <= Convert.ToInt32(sveitems.Rows[a][2].ToString()) && Convert.ToInt32(sveitems.Rows[a][2].ToString()) < 4)
                        {
                            gridbusiness.Rows[a].Cells[6].BackColor = System.Drawing.Color.Yellow;
                        }
                        else
                        {
                            gridbusiness.Rows[a].Cells[6].BackColor = System.Drawing.Color.Green;
                        }
                    }
                    double _dbltotalscore = 0;
                    double _dblaverage = 0;
                    foreach (DataRow dr in sveitems.Rows)
                    {
                        _dbltotalscore += Convert.ToInt32(dr[2].ToString());
                        _dblaverage = (_dbltotalscore / Convert.ToDouble(sveitems.Rows.Count));
                        ViewState["avgscore"] = _dblaverage;
                        if (_dblaverage == 0)
                        {
                            lblBusinessSolutionAverageScore.ForeColor = System.Drawing.Color.Red;
                        }
                        else if (_dblaverage >= 1 && _dblaverage <= 3)
                        {
                            lblBusinessSolutionAverageScore.ForeColor = System.Drawing.Color.Yellow;
                        }
                        else
                        {
                            lblBusinessSolutionAverageScore.ForeColor = System.Drawing.Color.Green;
                        }

                    }
                    lblBusinessSolutionAverageScore.Text = _dblaverage.ToString();
                }
                if (ViewState["allrecords"] == null)
                {
                    
                    htballparameters.Add(1, ParamList);
                    ViewState["allrecords"] = htballparameters;
                }
                else
                {

                    htballparameters = (Hashtable)ViewState["allrecords"];
                    htballparameters.Remove(1);
                    htballparameters.Add(1, ParamList);
                    ViewState["allrecords"] = htballparameters;
                }
               // hidAccordionIndex.Value = "1";
            }
            catch (Exception ex)
            {
                string _strErrorMessage = ex.Message;
                Response.Redirect("/frmErrorPage.aspx?ErrorMessage=" + _strErrorMessage);
            }
        }

        protected void btnSaveTech()
        {
            try
            {
                ArrayList ParamList1 = new ArrayList();
                //Hashtable hs = new Hashtable();
                ParamcolumnsBO paramobj;
                int cnt = gridtechnical.Rows.Count;
                int i = 0;
                DataTable sveitems = new DataTable();
                for (i = 0; i < cnt; i++)
                {
                    paramobj = new ParamcolumnsBO();
                    sveitems = (DataTable)ViewState["technical"];
                    paramobj.Keyckientrequirement = sveitems.Rows[i].ItemArray[0].ToString();
                    paramobj.Impactingwhichpart = sveitems.Rows[i].ItemArray[1].ToString();
                    paramobj.Gapsimprovementarea = sveitems.Rows[i].ItemArray[4].ToString();
                    paramobj.Ownertoaddressgaps = sveitems.Rows[i].ItemArray[3].ToString();
                    paramobj.Leveltowhichimprovmrnt = sveitems.Rows[i].ItemArray[2].ToString();
                    paramobj.Reviewdate = Convert.ToDateTime(sveitems.Rows[i].ItemArray[5].ToString());
                    paramobj.OppId = (string)Session["Oppid"];
                    paramobj.Paramid = "2";
                    ParamList1.Add(paramobj);
                }
                if (sveitems != null && sveitems.Rows.Count > 0)
                {
                    for (int it = 0; it < cnt; it++)
                    {
                        //string val = coltable.Rows[i][2].ToString();
                        if (Convert.ToInt32(sveitems.Rows[it][2].ToString()) < 1)
                        {
                            gridtechnical.Rows[it].Cells[6].BackColor = System.Drawing.Color.Red;
                        }
                        else if (1 <= Convert.ToInt32(sveitems.Rows[it][2].ToString()) && Convert.ToInt32(sveitems.Rows[it][2].ToString()) < 4)
                        {
                            gridtechnical.Rows[it].Cells[6].BackColor = System.Drawing.Color.Yellow;
                        }
                        else
                        {
                            gridtechnical.Rows[it].Cells[6].BackColor = System.Drawing.Color.Green;
                        }
                    }

                    double totalscore = 0;
                    double average = 0;
                    foreach (DataRow dr in sveitems.Rows)
                    {
                        totalscore += Convert.ToInt32(dr[2].ToString());
                        average = (totalscore / Convert.ToDouble(sveitems.Rows.Count));
                        ViewState["avgscore"] = average;
                        if (average == 0)
                        {
                            lblTechnicalSolutionAverageScore.ForeColor = System.Drawing.Color.Red;
                        }
                        else if (average >= 1 && average <= 3)
                        {
                            lblTechnicalSolutionAverageScore.ForeColor = System.Drawing.Color.PeachPuff;
                        }
                        else
                        {
                            lblTechnicalSolutionAverageScore.ForeColor = System.Drawing.Color.Green;
                        }
                    }
                    lblTechnicalSolutionAverageScore.Text = average.ToString();
                }
                
                    if (ViewState["allrecords"] == null)
                    {
                        htballparameters.Add(2, ParamList1);
                        ViewState["allrecords"] = htballparameters;
                    }
                    else
                    {

                        htballparameters = (Hashtable)ViewState["allrecords"];
                        htballparameters.Remove(2);
                        htballparameters.Add(2, ParamList1);
                        ViewState["allrecords"] = htballparameters;
                    }
               // hidAccordionIndex.Value = "2";
            }
            catch (Exception ex)
            {
                string _strErrorMessage = ex.Message;
                Response.Redirect("/frmErrorPage.aspx?ErrorMessage=" + _strErrorMessage);
            }
        }

        protected void btnSaveService()
        {
            try
            {
                ArrayList ParamList2 = new ArrayList();
                //Hashtable hs = new Hashtable();
                ParamcolumnsBO paramobj;
                int cnt = gridservice.Rows.Count;
                int i = 0;
                DataTable sveitems = (DataTable)ViewState["service"];
                for (i = 0; i < cnt; i++)
                {
                    paramobj = new ParamcolumnsBO();
                    
                    paramobj.Keyckientrequirement = sveitems.Rows[i].ItemArray[0].ToString();
                    paramobj.Impactingwhichpart = sveitems.Rows[i].ItemArray[1].ToString();
                    paramobj.Gapsimprovementarea = sveitems.Rows[i].ItemArray[4].ToString();
                    paramobj.Ownertoaddressgaps = sveitems.Rows[i].ItemArray[3].ToString();
                    paramobj.Leveltowhichimprovmrnt = sveitems.Rows[i].ItemArray[2].ToString();
                    paramobj.Reviewdate = Convert.ToDateTime(sveitems.Rows[i].ItemArray[5].ToString());
                    paramobj.OppId = (string)Session["Oppid"];
                    paramobj.Paramid = "3";
                    ParamList2.Add(paramobj);
                }
                if (sveitems != null && sveitems.Rows.Count > 0)
                {
                    for (int it = 0; it < cnt; it++)
                    {
                        //string val = coltable.Rows[i][2].ToString();
                        if (Convert.ToInt32(sveitems.Rows[it][2].ToString()) < 1)
                        {
                            gridservice.Rows[it].Cells[6].BackColor = System.Drawing.Color.Red;
                        }
                        else if (1 <= Convert.ToInt32(sveitems.Rows[it][2].ToString()) && Convert.ToInt32(sveitems.Rows[it][2].ToString()) < 4)
                        {
                            gridservice.Rows[it].Cells[6].BackColor = System.Drawing.Color.Yellow;
                        }
                        else
                        {
                            gridservice.Rows[it].Cells[6].BackColor = System.Drawing.Color.Green;
                        }
                    }

                    double totalscore = 0;
                    double average = 0;
                    foreach (DataRow dr in sveitems.Rows)
                    {
                        totalscore += Convert.ToInt32(dr[2].ToString());
                        average = (totalscore / Convert.ToDouble(sveitems.Rows.Count));
                        ViewState["avgscore"] = average;
                        if (average == 0)
                        {
                            seravscore.ForeColor = System.Drawing.Color.Red;
                        }
                        else if (average >= 1 && average <= 3)
                        {
                            seravscore.ForeColor = System.Drawing.Color.PeachPuff;
                        }
                        else
                        {
                            seravscore.ForeColor = System.Drawing.Color.Green;
                        }
                    }
                    seravscore.Text = average.ToString();
                }
                if (ViewState["allrecords"] == null)
                {
                    htballparameters.Add(3, ParamList2);
                    ViewState["allrecords"] = htballparameters;

                }
                else
                {

                    htballparameters = (Hashtable)ViewState["allrecords"];
                    htballparameters.Remove(3);
                    htballparameters.Add(3, ParamList2);
                    ViewState["allrecords"] = htballparameters;
                }
                //hidAccordionIndex.Value = "3";
            }
            catch (Exception ex)
            {
                string _strErrorMessage = ex.Message;
                Response.Redirect("/frmErrorPage.aspx?ErrorMessage=" + _strErrorMessage);
            }
        }

        protected void btnSaveTrans()
        {
            try
            {
                ArrayList ParamList3 = new ArrayList();
                //Hashtable hs = new Hashtable();
                ParamcolumnsBO paramobj;
                int cnt = gridtransition.Rows.Count;
                DataTable sveitems = (DataTable)ViewState["transition"];
                int i = 0;
                for (i = 0; i < cnt; i++)
                {
                    paramobj = new ParamcolumnsBO();
                    
                    paramobj.Keyckientrequirement = sveitems.Rows[i].ItemArray[0].ToString();
                    paramobj.Impactingwhichpart = sveitems.Rows[i].ItemArray[1].ToString();
                    paramobj.Gapsimprovementarea = sveitems.Rows[i].ItemArray[4].ToString();
                    paramobj.Ownertoaddressgaps = sveitems.Rows[i].ItemArray[3].ToString();
                    paramobj.Leveltowhichimprovmrnt = sveitems.Rows[i].ItemArray[2].ToString();
                    paramobj.Reviewdate = Convert.ToDateTime(sveitems.Rows[i].ItemArray[5].ToString());
                    paramobj.OppId =(string)Session["Oppid"];
                    paramobj.Paramid = "4";
                    ParamList3.Add(paramobj);
                }
                if (sveitems != null && sveitems.Rows.Count > 0)
                {
                    for (int it = 0; it < cnt; it++)
                    {
                        //string val = coltable.Rows[i][2].ToString();
                        if (Convert.ToInt32(sveitems.Rows[it][2].ToString()) < 1)
                        {
                            gridtransition.Rows[it].Cells[6].BackColor = System.Drawing.Color.Red;
                        }
                        else if (1 <= Convert.ToInt32(sveitems.Rows[it][2].ToString()) && Convert.ToInt32(sveitems.Rows[it][2].ToString()) < 4)
                        {
                            gridtransition.Rows[it].Cells[6].BackColor = System.Drawing.Color.Yellow;
                        }
                        else
                        {
                            gridtransition.Rows[it].Cells[6].BackColor = System.Drawing.Color.Green;
                        }
                    }

                    double totalscore = 0;
                    double average = 0;
                    foreach (DataRow dr in sveitems.Rows)
                    {
                        totalscore += Convert.ToInt32(dr[2].ToString());
                        average = (totalscore / Convert.ToDouble(sveitems.Rows.Count));
                        ViewState["avgscore"] = average;
                        if (average == 0)
                        {
                            tranavscore.ForeColor = System.Drawing.Color.Red;
                        }
                        else if (average >= 1 && average <= 3)
                        {
                            tranavscore.ForeColor = System.Drawing.Color.PeachPuff;

                        }
                        else
                        {
                            tranavscore.ForeColor = System.Drawing.Color.Green;
                        }
                    }
                    tranavscore.Text = average.ToString();
                }
                if (ViewState["allrecords"] == null)
                {
                    htballparameters.Add(4, ParamList3);
                    ViewState["allrecords"] = htballparameters;

                }
                else
                {

                    htballparameters = (Hashtable)ViewState["allrecords"];
                    htballparameters.Remove(4);
                    htballparameters.Add(4, ParamList3);
                    ViewState["allrecords"] = htballparameters;
                }
               // hidAccordionIndex.Value = "4";
            }
            catch (Exception ex)
            {
                string _strErrorMessage = ex.Message;
                Response.Redirect("/frmErrorPage.aspx?ErrorMessage=" + _strErrorMessage);
            }

        }

        protected void btnSaveGov()
        {
            try
            {
                ArrayList ParamList4 = new ArrayList();
                Hashtable hs = new Hashtable();
                ParamcolumnsBO paramobj;
                int cnt = gridgovern.Rows.Count;
                DataTable sveitems = (DataTable)ViewState["govern"];
                int i = 0;
                for (i = 0; i < cnt; i++)
                {
                    paramobj = new ParamcolumnsBO();
                   
                    paramobj.Keyckientrequirement = sveitems.Rows[i].ItemArray[0].ToString();
                    paramobj.Impactingwhichpart = sveitems.Rows[i].ItemArray[1].ToString();
                    paramobj.Gapsimprovementarea = sveitems.Rows[i].ItemArray[4].ToString();
                    paramobj.Ownertoaddressgaps = sveitems.Rows[i].ItemArray[3].ToString();
                    paramobj.Leveltowhichimprovmrnt = sveitems.Rows[i].ItemArray[2].ToString();
                    paramobj.Reviewdate = Convert.ToDateTime(sveitems.Rows[i].ItemArray[5].ToString());
                    paramobj.OppId = (string)Session["Oppid"];
                    paramobj.Paramid = "5";
                    ParamList4.Add(paramobj);
                }
                if (sveitems != null && sveitems.Rows.Count > 0)
                {
                    for (int it = 0; it < cnt; it++)
                    {
                        //string val = coltable.Rows[i][2].ToString();
                        if (Convert.ToInt32(sveitems.Rows[it][2].ToString()) < 1)
                        {
                            gridgovern.Rows[it].Cells[6].BackColor = System.Drawing.Color.Red;
                        }
                        else if (1 <= Convert.ToInt32(sveitems.Rows[it][2].ToString()) && Convert.ToInt32(sveitems.Rows[it][2].ToString()) < 4)
                        {
                            gridgovern.Rows[it].Cells[6].BackColor = System.Drawing.Color.Yellow;
                        }
                        else
                        {
                            gridgovern.Rows[it].Cells[6].BackColor = System.Drawing.Color.Green;
                        }
                    }
                    double totalscore = 0;
                    double average = 0;
                    foreach (DataRow dr in sveitems.Rows)
                    {
                        totalscore += Convert.ToInt32(dr[2].ToString());
                        average = (totalscore / Convert.ToDouble(sveitems.Rows.Count));
                        ViewState["avgscore"] = average;
                        if (average == 0)
                        {
                            govavscore.ForeColor = System.Drawing.Color.Red;
                        }
                        else if (average >= 1 && average <= 3)
                        {
                            govavscore.ForeColor = System.Drawing.Color.PeachPuff;

                        }
                        else
                        {
                            govavscore.ForeColor = System.Drawing.Color.Green;
                        }
                    }

                    govavscore.Text = average.ToString();
                }
                if (ViewState["allrecords"] == null)
                {
                    hs.Add(5, ParamList4);
                    ViewState["allrecords"] = hs;

                }
                else
                {
                    
                    hs = (Hashtable)ViewState["allrecords"];
                    hs.Remove(5);
                    hs.Add(5, ParamList4);
                    ViewState["allrecords"] = hs;
                }
               // hidAccordionIndex.Value = "5";
            }
            catch (Exception ex)
            {
                string _strErrorMessage = ex.Message;
                Response.Redirect("/frmErrorPage.aspx?ErrorMessage=" + _strErrorMessage);
            }

        }

        protected void btnSaveProc()
        {
            try
            {
                ArrayList ParamList5 = new ArrayList();
                Hashtable hs = new Hashtable();
                ParamcolumnsBO paramobj;
                int cnt = gridprocess.Rows.Count;
                DataTable sveitems = (DataTable)ViewState["process"];
                int i = 0;
                for (i = 0; i < cnt; i++)
                {
                    paramobj = new ParamcolumnsBO();
                    
                    paramobj.Keyckientrequirement = sveitems.Rows[i].ItemArray[0].ToString();
                    paramobj.Impactingwhichpart = sveitems.Rows[i].ItemArray[1].ToString();
                    paramobj.Gapsimprovementarea = sveitems.Rows[i].ItemArray[4].ToString();
                    paramobj.Ownertoaddressgaps = sveitems.Rows[i].ItemArray[3].ToString();
                    paramobj.Leveltowhichimprovmrnt = sveitems.Rows[i].ItemArray[2].ToString();
                    paramobj.Reviewdate = Convert.ToDateTime(sveitems.Rows[i].ItemArray[5].ToString());
                    paramobj.OppId = (string)Session["Oppid"];
                    paramobj.Paramid = "6";
                    ParamList5.Add(paramobj);
                }
                if (sveitems != null && sveitems.Rows.Count > 0)
                {
                    for (int it = 0; it < cnt; it++)
                    {
                        //string val = coltable.Rows[i][2].ToString();
                        if (Convert.ToInt32(sveitems.Rows[it][2].ToString()) < 1)
                        {
                            gridprocess.Rows[it].Cells[6].BackColor = System.Drawing.Color.Red;
                        }
                        else if (1 <= Convert.ToInt32(sveitems.Rows[it][2].ToString()) && Convert.ToInt32(sveitems.Rows[it][2].ToString()) < 4)
                        {
                            gridprocess.Rows[it].Cells[6].BackColor = System.Drawing.Color.Yellow;
                        }
                        else
                        {
                            gridprocess.Rows[it].Cells[6].BackColor = System.Drawing.Color.Green;
                        }
                    }

                    double totalscore = 0;
                    double average = 0;
                    foreach (DataRow dr in sveitems.Rows)
                    {
                        totalscore += Convert.ToInt32(dr[2].ToString());
                        average = (totalscore / Convert.ToDouble(sveitems.Rows.Count));
                        ViewState["avgscore"] = average;
                        if (average == 0)
                        {
                            proavscore.ForeColor = System.Drawing.Color.Red;
                        }
                        else if (average >= 1 && average <= 3)
                        {
                            proavscore.ForeColor = System.Drawing.Color.PeachPuff;

                        }
                        else
                        {
                            proavscore.ForeColor = System.Drawing.Color.Green;
                        }
                    }
                    proavscore.Text = average.ToString();
                }
                if (ViewState["allrecords"] == null)
                {
                    hs.Add(6, ParamList5);
                    ViewState["allrecords"] = hs;

                }
                else
                {
                    
                    hs = (Hashtable)ViewState["allrecords"];
                    hs.Remove(6);
                    hs.Add(6, ParamList5);
                    ViewState["allrecords"] = hs;
                }
               // hidAccordionIndex.Value = "6";
            }
            catch (Exception ex)
            {
                string _strErrorMessage = ex.Message;
                Response.Redirect("/frmErrorPage.aspx?ErrorMessage=" + _strErrorMessage);
            }
        }

        protected void btnSaveHR()
        {
            try
            {
                ArrayList ParamList6 = new ArrayList();
                Hashtable hs = new Hashtable();
                ParamcolumnsBO paramobj;
                int cnt = gridhr.Rows.Count;
                DataTable sveitems = (DataTable)ViewState["HR"];
                int i = 0;
                for (i = 0; i < cnt; i++)
                {
                    paramobj = new ParamcolumnsBO();
                    
                    paramobj.Keyckientrequirement = sveitems.Rows[i].ItemArray[0].ToString();
                    paramobj.Impactingwhichpart = sveitems.Rows[i].ItemArray[1].ToString();
                    paramobj.Gapsimprovementarea = sveitems.Rows[i].ItemArray[4].ToString();
                    paramobj.Ownertoaddressgaps = sveitems.Rows[i].ItemArray[3].ToString();
                    paramobj.Leveltowhichimprovmrnt = sveitems.Rows[i].ItemArray[2].ToString();
                    paramobj.Reviewdate = Convert.ToDateTime(sveitems.Rows[i].ItemArray[5].ToString());
                    paramobj.OppId = (string)Session["Oppid"];
                    paramobj.Paramid = "7";
                    ParamList6.Add(paramobj);
                }
                if (sveitems != null && sveitems.Rows.Count > 0)
                {
                    for (int it = 0; it < cnt; it++)
                    {
                        //string val = coltable.Rows[i][2].ToString();
                        if (Convert.ToInt32(sveitems.Rows[it][2].ToString()) < 1)
                        {
                            gridhr.Rows[it].Cells[6].BackColor = System.Drawing.Color.Red;
                        }
                        else if (1 <= Convert.ToInt32(sveitems.Rows[it][2].ToString()) && Convert.ToInt32(sveitems.Rows[it][2].ToString()) < 4)
                        {
                            gridhr.Rows[it].Cells[6].BackColor = System.Drawing.Color.Yellow;
                        }
                        else
                        {
                            gridhr.Rows[it].Cells[6].BackColor = System.Drawing.Color.Green;
                        }
                    }
                    double totalscore = 0;
                    double average = 0;
                    foreach (DataRow dr in sveitems.Rows)
                    {
                        totalscore += Convert.ToInt32(dr[2].ToString());
                        average = (totalscore / Convert.ToDouble(sveitems.Rows.Count));
                        ViewState["avgscore"] = average;
                        if (average == 0)
                        {
                            hravscore.ForeColor = System.Drawing.Color.Red;
                        }
                        else if (average >= 1 && average <= 3)
                        {
                            hravscore.ForeColor = System.Drawing.Color.PeachPuff;

                        }
                        else
                        {
                            hravscore.ForeColor = System.Drawing.Color.Green;
                        }
                    }
                    hravscore.Text = average.ToString();
                }
                if (ViewState["allrecords"] == null)
                {
                    hs.Add(7, ParamList6);
                    ViewState["allrecords"] = hs;

                }
                else
                {
                    
                    hs = (Hashtable)ViewState["allrecords"];
                    hs.Remove(7);
                    hs.Add(7, ParamList6);
                    ViewState["allrecords"] = hs;
                }
                //hidAccordionIndex.Value = "7";
            }
            catch (Exception ex)
            {
                string _strErrorMessage = ex.Message;
                Response.Redirect("/frmErrorPage.aspx?ErrorMessage=" + _strErrorMessage);
            }
        }

        protected void btnSaveInt()
        {
            try
            {
                ArrayList ParamList7 = new ArrayList();
                Hashtable hs = new Hashtable();
                ParamcolumnsBO paramobj;
                int cnt = gridintegration.Rows.Count;
                DataTable sveitems = (DataTable)ViewState["integration"];
                int i = 0;
                for (i = 0; i < cnt; i++)
                {
                    paramobj = new ParamcolumnsBO();
                    
                    paramobj.Keyckientrequirement = sveitems.Rows[i].ItemArray[0].ToString();
                    paramobj.Impactingwhichpart = sveitems.Rows[i].ItemArray[1].ToString();
                    paramobj.Gapsimprovementarea = sveitems.Rows[i].ItemArray[4].ToString();
                    paramobj.Ownertoaddressgaps = sveitems.Rows[i].ItemArray[3].ToString();
                    paramobj.Leveltowhichimprovmrnt = sveitems.Rows[i].ItemArray[2].ToString();
                    paramobj.Reviewdate = Convert.ToDateTime(sveitems.Rows[i].ItemArray[5].ToString());
                    paramobj.OppId = (string)Session["Oppid"];
                    paramobj.Paramid = "9";
                    ParamList7.Add(paramobj);
                }
                if (sveitems != null && sveitems.Rows.Count > 0)
                {
                  
                for (int it = 0; it < cnt; it++)
                {
                    //string val = coltable.Rows[i][2].ToString();
                    if (Convert.ToInt32(sveitems.Rows[it][2].ToString()) < 1)
                    {
                        gridintegration.Rows[it].Cells[6].BackColor = System.Drawing.Color.Red;
                    }
                    else if (1 <= Convert.ToInt32(sveitems.Rows[it][2].ToString()) && Convert.ToInt32(sveitems.Rows[it][2].ToString()) < 4)
                    {
                        gridintegration.Rows[it].Cells[6].BackColor = System.Drawing.Color.Yellow;
                    }
                    else
                    {
                        gridintegration.Rows[it].Cells[6].BackColor = System.Drawing.Color.Green;
                    }
                }
                double totalscore = 0;
                double average = 0;
                  
                    foreach (DataRow dr in sveitems.Rows)
                    {
                        totalscore += Convert.ToInt32(dr[2].ToString());
                        average = (totalscore / Convert.ToDouble(sveitems.Rows.Count));
                        ViewState["avgscore"] = average;
                        if (average == 0)
                        {
                            intavscore.ForeColor = System.Drawing.Color.Red;
                        }
                        else if (average >= 1 && average <= 3)
                        {
                            intavscore.ForeColor = System.Drawing.Color.PeachPuff;

                        }
                        else
                        {
                            intavscore.ForeColor = System.Drawing.Color.Green;
                        }
                    }

                    intavscore.Text = average.ToString();
                }
                if (ViewState["allrecords"] == null)
                {
                    hs.Add(8, ParamList7);
                    ViewState["allrecords"] = hs;

                }
                else
                {
                    
                    hs = (Hashtable)ViewState["allrecords"];
                    hs.Remove(8);
                    hs.Add(8, ParamList7);
                    ViewState["allrecords"] = hs;
                }
                //hidAccordionIndex.Value = "9";
            }
            catch (Exception ex)
            {
                string _strErrorMessage = ex.Message;
                Response.Redirect("/frmErrorPage.aspx?ErrorMessage=" + _strErrorMessage);
                
            }

        }

        protected void btnSaveCommercial()
        {
            try
            
            {
                ArrayList ParamList8 = new ArrayList();
                Hashtable hsa = new Hashtable();
                ParamcolumnsBO paramobj;
                int cnt = gridcommercial.Rows.Count;
                DataTable sveitems = (DataTable)ViewState["commercial"];
                int i = 0;
                for (i = 0; i < cnt; i++)
                {
                    paramobj = new ParamcolumnsBO();
                    
                    paramobj.Keyckientrequirement = sveitems.Rows[i].ItemArray[0].ToString();
                    paramobj.Impactingwhichpart = sveitems.Rows[i].ItemArray[1].ToString();
                    paramobj.Gapsimprovementarea = sveitems.Rows[i].ItemArray[4].ToString();
                    paramobj.Ownertoaddressgaps = sveitems.Rows[i].ItemArray[3].ToString();
                    paramobj.Leveltowhichimprovmrnt = sveitems.Rows[i].ItemArray[2].ToString();
                    paramobj.Reviewdate = Convert.ToDateTime(sveitems.Rows[i].ItemArray[5].ToString());
                    paramobj.OppId = (string)Session["Oppid"];
                    paramobj.Paramid = "8";
                    ParamList8.Add(paramobj);
                }
                if (sveitems != null && sveitems.Rows.Count > 0)
                {
                    for (int it = 0; it < cnt; it++)
                    {
                        //string val = coltable.Rows[i][2].ToString();
                        if (Convert.ToInt32(sveitems.Rows[it][2].ToString()) < 1)
                        {
                            gridcommercial.Rows[it].Cells[6].BackColor = System.Drawing.Color.Red;
                        }
                        else if (1 <= Convert.ToInt32(sveitems.Rows[it][2].ToString()) && Convert.ToInt32(sveitems.Rows[it][2].ToString()) < 4)
                        {
                            gridcommercial.Rows[it].Cells[6].BackColor = System.Drawing.Color.Yellow;
                        }
                        else
                        {
                            gridcommercial.Rows[it].Cells[6].BackColor = System.Drawing.Color.Green;
                        }
                    }
                    double totalscore = 0;
                    double average = 0;
                    foreach (DataRow dr in sveitems.Rows)
                    {
                        totalscore += Convert.ToInt32(dr[2].ToString());
                        average = (totalscore / Convert.ToDouble(sveitems.Rows.Count));
                        ViewState["avgscore"] = average;
                        if (average == 0)
                        {
                            comavscore.ForeColor = System.Drawing.Color.Red;
                        }
                        else if (average >= 1 && average <= 3)
                        {
                            comavscore.ForeColor = System.Drawing.Color.PeachPuff;

                        }
                        else
                        {
                            comavscore.ForeColor = System.Drawing.Color.Green;
                        }
                    }
                    comavscore.Text = average.ToString();
                }
                if (ViewState["allrecords"] == null)
                {
                    htballparameters.Add(9, ParamList8);
                    ViewState["allrecords"] = htballparameters;

                }
                else
                {

                    htballparameters = (Hashtable)ViewState["allrecords"];
                    htballparameters.Remove(9);
                    htballparameters.Add(9, ParamList8);
                    ViewState["allrecords"] = htballparameters;
                }
               // hidAccordionIndex.Value = "8";
            }
            catch (Exception ex)
            {
                string _strErrorMessage = ex.Message;
                Response.Redirect("/frmErrorPage.aspx?ErrorMessage=" + _strErrorMessage);
            }

        }

        #endregion

        protected void btnSaveBusiness(DataTable business)
        {
            try
            {
                ArrayList ParamList = new ArrayList();
                Hashtable hsa = new Hashtable();
                ParamcolumnsBO paramobj;
                int cnt = business.Rows.Count;
                int i = 0;
                for (i = 0; i < cnt; i++)
                {
                    paramobj = new ParamcolumnsBO();
                    DataTable sveitems = business;
                    paramobj.Keyckientrequirement = sveitems.Rows[i].ItemArray[0].ToString();
                    paramobj.Impactingwhichpart = sveitems.Rows[i].ItemArray[1].ToString();
                    paramobj.Gapsimprovementarea = sveitems.Rows[i].ItemArray[4].ToString();
                    paramobj.Ownertoaddressgaps = sveitems.Rows[i].ItemArray[3].ToString();
                    paramobj.Leveltowhichimprovmrnt = sveitems.Rows[i].ItemArray[2].ToString();
                    paramobj.Reviewdate = Convert.ToDateTime(sveitems.Rows[i].ItemArray[5].ToString());
                    paramobj.OppId = (string)Session["Oppid"];
                    paramobj.Paramid = "1";
                    ParamList.Add(paramobj);
                }
                if (ViewState["allrecords"] == null)
                {
                    htballparameters.Add(1, ParamList);
                    ViewState["allrecords"] = htballparameters;

                }
                else
                {
                    htballparameters = (Hashtable)ViewState["allrecords"];
                    if (!htballparameters.ContainsKey(1))
                    {
                        htballparameters.Add(1, ParamList);
                    }
                    else
                    {
                        htballparameters[1] = ParamList;
                    }
                    ViewState["allrecords"] = htballparameters;
                }
                hidAccordionIndex.Value = "0";
            }
            catch (Exception ex)
            {
                string _strErrorMessage = ex.Message;
                Response.Redirect("/frmErrorPage.aspx?ErrorMessage=" + _strErrorMessage);
            }

        }

        protected void btnSaveTechnical(DataTable business)
        {
            try
            {
                ArrayList ParamList1 = new ArrayList();
                Hashtable hsa = new Hashtable();
                ParamcolumnsBO paramobj;
                int cnt = business.Rows.Count;
                int i = 0;
                for (i = 0; i < cnt; i++)
                {
                    paramobj = new ParamcolumnsBO();
                    DataTable sveitems = business;
                    paramobj.Keyckientrequirement = sveitems.Rows[i].ItemArray[0].ToString();
                    paramobj.Impactingwhichpart = sveitems.Rows[i].ItemArray[1].ToString();
                    paramobj.Gapsimprovementarea = sveitems.Rows[i].ItemArray[4].ToString();
                    paramobj.Ownertoaddressgaps = sveitems.Rows[i].ItemArray[3].ToString();
                    paramobj.Leveltowhichimprovmrnt = sveitems.Rows[i].ItemArray[2].ToString();
                    paramobj.Reviewdate = Convert.ToDateTime(sveitems.Rows[i].ItemArray[5].ToString());
                    paramobj.OppId = (string)Session["Oppid"];
                    paramobj.Paramid = "2";
                    ParamList1.Add(paramobj);
                }
                if (ViewState["allrecords"] == null)
                {
                    htballparameters.Add(2, ParamList1);
                    ViewState["allrecords"] = htballparameters;

                }
                else
                {
                    htballparameters = (Hashtable)ViewState["allrecords"];
                    if (!htballparameters.ContainsKey(2))
                    {
                        htballparameters.Add(2, ParamList1);
                    }
                    else
                    {
                        htballparameters[2] = ParamList1;
                    }
                    ViewState["allrecords"] = htballparameters;
                }
                hidAccordionIndex.Value = "1";
            }
            catch (Exception ex)
            {
                string _strErrorMessage = ex.Message;
                Response.Redirect("/frmErrorPage.aspx?ErrorMessage=" + _strErrorMessage);
            }

        }

        protected void btnSaveService(DataTable business)
        {
            try
            {
                ArrayList ParamList2 = new ArrayList();
                Hashtable hsa = new Hashtable();
                ParamcolumnsBO paramobj;
                int cnt = business.Rows.Count;
                int i = 0;
                for (i = 0; i < cnt; i++)
                {
                    paramobj = new ParamcolumnsBO();
                    DataTable sveitems = business;
                    paramobj.Keyckientrequirement = sveitems.Rows[i].ItemArray[0].ToString();
                    paramobj.Impactingwhichpart = sveitems.Rows[i].ItemArray[1].ToString();
                    paramobj.Gapsimprovementarea = sveitems.Rows[i].ItemArray[4].ToString();
                    paramobj.Ownertoaddressgaps = sveitems.Rows[i].ItemArray[3].ToString();
                    paramobj.Leveltowhichimprovmrnt = sveitems.Rows[i].ItemArray[2].ToString();
                    paramobj.Reviewdate = Convert.ToDateTime(sveitems.Rows[i].ItemArray[5].ToString());
                    paramobj.OppId = (string)Session["Oppid"];
                    paramobj.Paramid = "3";
                    ParamList2.Add(paramobj);
                }
                if (ViewState["allrecords"] == null)
                {
                    htballparameters.Add(3, ParamList2);
                    ViewState["allrecords"] = htballparameters;

                }
                else
                {
                    htballparameters = (Hashtable)ViewState["allrecords"];
                    if (!htballparameters.ContainsKey(3))
                    {
                        htballparameters.Add(3, ParamList2);
                    }
                    else
                    {
                        htballparameters[3] = ParamList2;
                    }
                    ViewState["allrecords"] = htballparameters;
                }
                hidAccordionIndex.Value = "2";
            }
            catch (Exception ex)
            {
                string _strErrorMessage = ex.Message;
                Response.Redirect("/frmErrorPage.aspx?ErrorMessage=" + _strErrorMessage);
            }

        }

        protected void btnSaveTransition(DataTable business)
        {
            try
            {
                ArrayList ParamList3 = new ArrayList();
                Hashtable hsa = new Hashtable();
                ParamcolumnsBO paramobj;
                int cnt = business.Rows.Count;
                int i = 0;
                for (i = 0; i < cnt; i++)
                {
                    paramobj = new ParamcolumnsBO();
                    DataTable sveitems = business;
                    paramobj.Keyckientrequirement = sveitems.Rows[i].ItemArray[0].ToString();
                    paramobj.Impactingwhichpart = sveitems.Rows[i].ItemArray[1].ToString();
                    paramobj.Gapsimprovementarea = sveitems.Rows[i].ItemArray[4].ToString();
                    paramobj.Ownertoaddressgaps = sveitems.Rows[i].ItemArray[3].ToString();
                    paramobj.Leveltowhichimprovmrnt = sveitems.Rows[i].ItemArray[2].ToString();
                    paramobj.Reviewdate = Convert.ToDateTime(sveitems.Rows[i].ItemArray[5].ToString());
                    paramobj.OppId = (string)Session["Oppid"];
                    paramobj.Paramid = "4";
                    ParamList3.Add(paramobj);
                }
                if (ViewState["allrecords"] == null)
                {
                    htballparameters.Add(4, ParamList3);
                    ViewState["allrecords"] = htballparameters;

                }
                else
                {
                    htballparameters = (Hashtable)ViewState["allrecords"];
                    if (!htballparameters.ContainsKey(4))
                    {
                        htballparameters.Add(4, ParamList3);
                    }
                    else
                    {
                        htballparameters[4] = ParamList3;
                    }
                    ViewState["allrecords"] = htballparameters;
                }
                hidAccordionIndex.Value = "3";
            }
            catch (Exception ex)
            {
                string _strErrorMessage = ex.Message;
                Response.Redirect("/frmErrorPage.aspx?ErrorMessage=" + _strErrorMessage);
            }

        }

        protected void btnSaveGovernance(DataTable business)
        {
            try
            {
                ArrayList ParamList4 = new ArrayList();
                Hashtable hsa = new Hashtable();
                ParamcolumnsBO paramobj;
                int cnt = business.Rows.Count;
                int i = 0;
                for (i = 0; i < cnt; i++)
                {
                    paramobj = new ParamcolumnsBO();
                    DataTable sveitems = business;
                    paramobj.Keyckientrequirement = sveitems.Rows[i].ItemArray[0].ToString();
                    paramobj.Impactingwhichpart = sveitems.Rows[i].ItemArray[1].ToString();
                    paramobj.Gapsimprovementarea = sveitems.Rows[i].ItemArray[4].ToString();
                    paramobj.Ownertoaddressgaps = sveitems.Rows[i].ItemArray[3].ToString();
                    paramobj.Leveltowhichimprovmrnt = sveitems.Rows[i].ItemArray[2].ToString();
                    paramobj.Reviewdate = Convert.ToDateTime(sveitems.Rows[i].ItemArray[5].ToString());
                    paramobj.OppId = (string)Session["Oppid"];
                    paramobj.Paramid = "5";
                    ParamList4.Add(paramobj);
                }
                if (ViewState["allrecords"] == null)
                {
                    htballparameters.Add(5, ParamList4);
                    ViewState["allrecords"] = htballparameters;

                }
                else
                {
                    htballparameters = (Hashtable)ViewState["allrecords"];
                    if (!htballparameters.ContainsKey(5))
                    {
                        htballparameters.Add(5, ParamList4);
                    }
                    else
                    {
                        htballparameters[5] = ParamList4;
                    }
                    ViewState["allrecords"] = htballparameters;
                }
                hidAccordionIndex.Value = "4";
            }
            catch (Exception ex)
            {
                string _strErrorMessage = ex.Message;
                Response.Redirect("/frmErrorPage.aspx?ErrorMessage=" + _strErrorMessage);
            }

        }

        protected void btnSaveProcess(DataTable business)
        {
            try
            {
                ArrayList ParamList5 = new ArrayList();
                Hashtable hsa = new Hashtable();
                ParamcolumnsBO paramobj;
                int cnt = business.Rows.Count;
                int i = 0;
                for (i = 0; i < cnt; i++)
                {
                    paramobj = new ParamcolumnsBO();
                    DataTable sveitems = business;
                    paramobj.Keyckientrequirement = sveitems.Rows[i].ItemArray[0].ToString();
                    paramobj.Impactingwhichpart = sveitems.Rows[i].ItemArray[1].ToString();
                    paramobj.Gapsimprovementarea = sveitems.Rows[i].ItemArray[4].ToString();
                    paramobj.Ownertoaddressgaps = sveitems.Rows[i].ItemArray[3].ToString();
                    paramobj.Leveltowhichimprovmrnt = sveitems.Rows[i].ItemArray[2].ToString();
                    paramobj.Reviewdate = Convert.ToDateTime(sveitems.Rows[i].ItemArray[5].ToString());
                    paramobj.OppId = (string)Session["Oppid"];
                    paramobj.Paramid = "6";
                    ParamList5.Add(paramobj);
                }
                if (ViewState["allrecords"] == null)
                {
                    htballparameters.Add(6, ParamList5);
                    ViewState["allrecords"] = htballparameters;

                }
                else
                {
                    htballparameters = (Hashtable)ViewState["allrecords"];
                    if (!htballparameters.ContainsKey(6))
                    {
                        htballparameters.Add(6, ParamList5);
                    }
                    else
                    {
                        htballparameters[6] = ParamList5;
                    }
                    ViewState["allrecords"] = htballparameters;
                }
                hidAccordionIndex.Value = "5";
            }
            catch (Exception ex)
            {
                string _strErrorMessage = ex.Message;
                Response.Redirect("/frmErrorPage.aspx?ErrorMessage=" + _strErrorMessage);
            }

        }

        protected void btnSaveHRChange(DataTable business)
        {
            try
            {
                ArrayList ParamList6 = new ArrayList();
                Hashtable hsa = new Hashtable();
                ParamcolumnsBO paramobj;
                int cnt = business.Rows.Count;
                int i = 0;
                for (i = 0; i < cnt; i++)
                {
                    paramobj = new ParamcolumnsBO();
                    DataTable sveitems = business;
                    paramobj.Keyckientrequirement = sveitems.Rows[i].ItemArray[0].ToString();
                    paramobj.Impactingwhichpart = sveitems.Rows[i].ItemArray[1].ToString();
                    paramobj.Gapsimprovementarea = sveitems.Rows[i].ItemArray[4].ToString();
                    paramobj.Ownertoaddressgaps = sveitems.Rows[i].ItemArray[3].ToString();
                    paramobj.Leveltowhichimprovmrnt = sveitems.Rows[i].ItemArray[2].ToString();
                    paramobj.Reviewdate = Convert.ToDateTime(sveitems.Rows[i].ItemArray[5].ToString());
                    paramobj.OppId = (string)Session["Oppid"];
                    paramobj.Paramid = "7";
                    ParamList6.Add(paramobj);
                }
                if (ViewState["allrecords"] == null)
                {
                    htballparameters.Add(7, ParamList6);
                    ViewState["allrecords"] = htballparameters;

                }
                else
                {
                    htballparameters = (Hashtable)ViewState["allrecords"];
                    if (!htballparameters.ContainsKey(7))
                    {
                        htballparameters.Add(7, ParamList6);
                    }
                    else
                    {
                        htballparameters[7] = ParamList6;
                    }
                    ViewState["allrecords"] = htballparameters;
                }
                hidAccordionIndex.Value = "6";
            }
            catch (Exception ex)
            {
                string _strErrorMessage = ex.Message;
                Response.Redirect("/frmErrorPage.aspx?ErrorMessage=" + _strErrorMessage);
            }

        }

        protected void btnSaveCommercial(DataTable business)
        {
            try
            {
                ArrayList ParamList7 = new ArrayList();
                Hashtable hsa = new Hashtable();
                ParamcolumnsBO paramobj;
                int cnt = business.Rows.Count;
                int i = 0;
                for (i = 0; i < cnt; i++)
                {
                    paramobj = new ParamcolumnsBO();
                    DataTable sveitems = business;
                    paramobj.Keyckientrequirement = sveitems.Rows[i].ItemArray[0].ToString();
                    paramobj.Impactingwhichpart = sveitems.Rows[i].ItemArray[1].ToString();
                    paramobj.Gapsimprovementarea = sveitems.Rows[i].ItemArray[4].ToString();
                    paramobj.Ownertoaddressgaps = sveitems.Rows[i].ItemArray[3].ToString();
                    paramobj.Leveltowhichimprovmrnt = sveitems.Rows[i].ItemArray[2].ToString();
                    paramobj.Reviewdate = Convert.ToDateTime(sveitems.Rows[i].ItemArray[5].ToString());
                    paramobj.OppId = (string)Session["Oppid"];
                    paramobj.Paramid = "8";
                    ParamList7.Add(paramobj);
                }
                if (ViewState["allrecords"] == null)
                {
                    htballparameters.Add(8, ParamList7);
                    ViewState["allrecords"] = htballparameters;

                }
                else
                {
                    htballparameters = (Hashtable)ViewState["allrecords"];
                    if (!htballparameters.ContainsKey(8))
                    {
                        htballparameters.Add(8, ParamList7);
                    }
                    else
                    {
                        htballparameters[8] = ParamList7;
                    }
                    ViewState["allrecords"] = htballparameters;
                }
                hidAccordionIndex.Value = "7";
            }
            catch (Exception ex)
            {
                string _strErrorMessage = ex.Message;
                Response.Redirect("/frmErrorPage.aspx?ErrorMessage=" + _strErrorMessage);
            }

        }

        protected void btnSaveIntegration(DataTable business)
        {
            try
            {
                ArrayList ParamList8 = new ArrayList();
                Hashtable hsa = new Hashtable();
                ParamcolumnsBO paramobj;
                int cnt = business.Rows.Count;
                int i = 0;
                for (i = 0; i < cnt; i++)
                {
                    paramobj = new ParamcolumnsBO();
                    DataTable sveitems = business;
                    paramobj.Keyckientrequirement = sveitems.Rows[i].ItemArray[0].ToString();
                    paramobj.Impactingwhichpart = sveitems.Rows[i].ItemArray[1].ToString();
                    paramobj.Gapsimprovementarea = sveitems.Rows[i].ItemArray[4].ToString();
                    paramobj.Ownertoaddressgaps = sveitems.Rows[i].ItemArray[3].ToString();
                    paramobj.Leveltowhichimprovmrnt = sveitems.Rows[i].ItemArray[2].ToString();
                    paramobj.Reviewdate = Convert.ToDateTime(sveitems.Rows[i].ItemArray[5].ToString());
                    paramobj.OppId = (string)Session["Oppid"];
                    paramobj.Paramid = "9";
                    ParamList8.Add(paramobj);
                }
                if (ViewState["allrecords"] == null)
                {
                    htballparameters.Add(9, ParamList8);
                    ViewState["allrecords"] = htballparameters;

                }
                else
                {
                    //htballparameters = (Hashtable)ViewState["allrecords"];
                    //if (!htballparameters.ContainsKey(9))
                    //{
                    //    htballparameters.Add(9, ParamList8);
                    //}
                    //else
                    //{
                    //    htballparameters[9] = ParamList8;

                    //}
                    hsa = (Hashtable)ViewState["allrecords"];
                    hsa.Remove(8);
                    hsa.Add(8, ParamList8);
                    ViewState["allrecords"] = hsa;
                   // ViewState["allrecords"] = htballparameters;
                }
                hidAccordionIndex.Value = "8";
            }
            catch (Exception ex)
            {
                string _strErrorMessage = ex.Message;
                Response.Redirect("/frmErrorPage.aspx?ErrorMessage=" + _strErrorMessage);
            }

        }

        protected void ddlrgytype_SelectedIndexChanged1(object sender, EventArgs e)
        {
            try
            {
                if (ddlrgytype.SelectedValue == "1")
                {
                    int iterationCount;
                    string Oppid = (string)Session["OppId"];
                    RGYBLL iterative = new RGYBLL();
                    iterationCount = (int)iterative.GetIterativeCount(Oppid);
                    ViewState["iterationcount"] = (iterationCount + 1);
                    lblIterativeCount.Text = "Iterative Checklist(" + (iterationCount + 1) + ")";
                    ddlrgytype.BackColor = System.Drawing.Color.White;
                }
                else if (ddlrgytype.SelectedValue == "2")
                {
                    lblIterativeCount.Text = "Final Checklist";
                    ddlrgytype.BackColor = System.Drawing.Color.White;
                    //ddlrgytype.Enabled = false;
                }
                else if (ddlrgytype.SelectedValue == "0")
                {
                    lblIterativeCount.Text = string.Empty;

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

        protected void getfinalscorepercent()
        {
            double finalscre = (Convert.ToDouble(lblBusinessSolutionAverageScore.Text.ToString()) * 20 +
                               Convert.ToDouble(lblTechnicalSolutionAverageScore.Text.ToString()) * 15 +
                               Convert.ToDouble(seravscore.Text.ToString()) * 5 +
                               Convert.ToDouble(tranavscore.Text.ToString()) * 5 +
                               Convert.ToDouble(govavscore.Text.ToString()) * 10 +
                               Convert.ToDouble(proavscore.Text.ToString()) * 5 +
                               Convert.ToDouble(hravscore.Text.ToString()) * 5 +
                               Convert.ToDouble(comavscore.Text.ToString()) * 0 +
                               Convert.ToDouble(intavscore.Text.ToString()) * 35) / 5;
            finallbl.Text = Math.Round(finalscre) + "%";
            givecolortofinalscore(finallbl.Text.ToString());
        }

        protected void givecolortofinalscore(string finalscore)
        {
            int finalscre = Convert.ToInt32(finalscore.Split('%')[0]);
            if (finalscre < 50)
            {
                finallbl.ForeColor = System.Drawing.Color.Red;
            }
            else if (finalscre >= 50 && finalscre <= 70)
            {
                finallbl.ForeColor = System.Drawing.Color.Yellow;
            }
            else
            {
                finallbl.ForeColor = System.Drawing.Color.Green;
            }
        }

        #region Save Submit Clear

        protected void btnLastSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlrgytype.SelectedItem.Value != "0")
                {
                    ddlrgytype.Enabled = false;
                    if (ViewState["allrecords"] != null)
                    {
                        Hashtable hs = (Hashtable)ViewState["allrecords"];
                        ArrayList finallist = new ArrayList();

                        //finallist = (ArrayList)hs[1];btn1save()
                        ParamcolumnsBO finalsenddelete = new ParamcolumnsBO();
                        finalsenddelete.OppId = (string)Session["oppid"];
                        new BLL.RGYBLL().DeleteRecords(finalsenddelete);
                        foreach (DictionaryEntry ss in hs)
                        {
                            finallist = (ArrayList)ss.Value;
                            // if (finallist.Count == 0)
                            // {

                            // }
                            foreach (Object obj in finallist)
                            {
                                ParamcolumnsBO finalsend = new ParamcolumnsBO();
                                finalsend = (ParamcolumnsBO)obj;
                                finalsend.OppId = (string)Session["OppID"];
                                new BLL.RGYBLL().Saverecords(finalsend);
                            }

                        }
                        ArrayList filist = new ArrayList();
                        filist.Add(lblBusinessSolutionAverageScore.Text.ToString());
                        filist.Add(lblTechnicalSolutionAverageScore.Text.ToString());
                        filist.Add(seravscore.Text.ToString());
                        filist.Add(tranavscore.Text.ToString());
                        filist.Add(proavscore.Text.ToString());
                        filist.Add(hravscore.Text.ToString());
                        filist.Add(govavscore.Text.ToString());
                        filist.Add(comavscore.Text.ToString());
                        filist.Add(intavscore.Text.ToString());
                        //filist.Add(finallbl.Text.ToString());
                        if (ViewState["iterationcount"] == null)
                        {
                            ViewState["iterationcount"] = 0;
                        }
                        string[] finallb = finallbl.Text.Split(new[] { '%' });
                        string number = finallb[0];
                        filist.Add(number);
                        int iterationcount = (int)ViewState["iterationcount"];
                        if (ddlrgytype.SelectedValue == "2")
                        {
                            iterationcount = 0;
                        }
                        filist.Add(iterationcount);
                        var oppid = (string)Session["oppid"];
                        filist.Add(oppid);
                        string _strwintheme = txtwinthemetext.Text.ToString();
                        filist.Add(_strwintheme);
                        new BLL.RGYBLL().Saverecs(filist);
                        if (hs.Keys.Count >= 8)
                        {
                            btnSubmit.Visible = true;
                            btnSubmit.Focus();
                        }
                        hidAccordionIndex.Value = "9";
                        lblSavedFillMandatoryMessages.ForeColor = System.Drawing.Color.Green;
                        lblSavedFillMandatoryMessages.Text = "Saved Successfully!!!";
                        lblSavedFillMandatoryMessages.Focus();
                    }
                    else
                    {
                        lblSavedFillMandatoryMessages.ForeColor = System.Drawing.Color.Red;
                        lblSavedFillMandatoryMessages.Text = "Please fill mandatory fields";
                        lblSavedFillMandatoryMessages.Focus();
                    }
                }
                else
                {
                    ddlrgytype.BackColor = System.Drawing.Color.Red;
                    lblIterativeCount.Focus();
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                lblSavedFillMandatoryMessages.Text = string.Empty;
                int desigid = (int)Session["Designation"];
                if (desigid != 7)
                {
                    if (ddlrgytype.SelectedItem.Value != "0")
                    {

                        Hashtable hs = (Hashtable)ViewState["allrecords"];
                        ArrayList finallist = new ArrayList();
                        ParamcolumnsBO finalsenddelete = new ParamcolumnsBO();
                        finalsenddelete.OppId = (string)Session["oppid"];
                        new BLL.RGYBLL().mainDeleteRecords(finalsenddelete);
                        foreach (DictionaryEntry ss in hs)
                        {
                            finallist = (ArrayList)ss.Value;

                            foreach (Object obj in finallist)
                            {
                                ParamcolumnsBO finalsend = new ParamcolumnsBO();
                                finalsend = (ParamcolumnsBO)obj;
                                finalsend.IterationNo = (int)ViewState["iterationcount"];
                                new BLL.RGYBLL().SaveParameters(finalsend);
                                //new BLL.RGYBLL().Saverecords(finalsend);
                            }
                        }
                        ArrayList filist = new ArrayList();
                        filist.Add(lblBusinessSolutionAverageScore.Text.ToString());
                        filist.Add(lblTechnicalSolutionAverageScore.Text.ToString());
                        filist.Add(seravscore.Text.ToString());
                        filist.Add(tranavscore.Text.ToString());
                        filist.Add(proavscore.Text.ToString());
                        filist.Add(hravscore.Text.ToString());
                        filist.Add(govavscore.Text.ToString());
                        filist.Add(comavscore.Text.ToString());
                        filist.Add(intavscore.Text.ToString());
                        //filist.Add(finallbl.Text.ToString());
                        if (ViewState["iterationcount"] == null)
                        {
                            ViewState["iterationcount"] = 0;
                        }
                        string[] finallb = finallbl.Text.Split(new[] { '%' });
                        string number = finallb[0];
                        filist.Add(number);

                        int iterationcount = (int)ViewState["iterationcount"];
                        if (ddlrgytype.SelectedValue == "2")
                        {
                            iterationcount = 0;
                        }
                        filist.Add(iterationcount);
                        var oppid = (string)Session["oppid"];
                        filist.Add(oppid);
                        string _strwintheme = txtwinthemetext.Text.ToString();
                        filist.Add(_strwintheme);
                        new BLL.RGYBLL().Submitrecs(filist);
                        disablecontrols();
                        //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Submitted Succesfully')");
                        lblSavedFillMandatoryMessages.ForeColor = System.Drawing.Color.Green;
                        lblSavedFillMandatoryMessages.Text = "Submitted Successfully!!!";
                        lblSavedFillMandatoryMessages.Focus();
                        ParamcolumnsBO finalsen = new ParamcolumnsBO();
                        finalsen.OppId = oppid;
                        string _dtsubmissionDate = new BLL.RGYBLL().GetSubmissionDate(finalsen); //new BLL.RGYBLL().GetSubmissionDate(filist);
                        if (!string.IsNullOrEmpty(_dtsubmissionDate))
                        {
                            SubDate.Text = _dtsubmissionDate;
                        }
                        lblApprovedResult.Text = "Submitted";
                    }
                    else
                    {
                        ddlrgytype.BackColor = System.Drawing.Color.Red;
                        lblIterativeCount.Focus();
                    }

                    //Automated email generation for RGYChecklist approval
                    GetStakeholderstoApproveRGYChecklist();
                }
                else
                {
                    if (ddlapproval.SelectedValue == "1")
                    {
                        string oppid = (string)Session["oppid"];
                        new BLL.RGYBLL().UpdateStatus(oppid);
                        lblApprovedResult.Text = "Approved";
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Approved Succesfully')");
                        lblSavedFillMandatoryMessages.ForeColor = System.Drawing.Color.Green;
                        lblSavedFillMandatoryMessages.Text = "Approved Successfully!!!";
                        lblSavedFillMandatoryMessages.Focus();
                        btnSubmit.Visible = false;
                        ddlapproval.Enabled = false;
                    }
                    else if (ddlapproval.SelectedValue == "2")
                    {
                        if (txtcomments.Text != string.Empty)
                        {
                            string oppid = (string)Session["oppid"];
                            lblApprovedResult.Text = "Not Approved";
                            string comments = txtcomments.Text.ToString();
                            new BLL.RGYBLL().UpdateStatusNonApproval(oppid, comments);
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Submitted Successfully')");
                            lblSavedFillMandatoryMessages.ForeColor = System.Drawing.Color.Green;
                            lblSavedFillMandatoryMessages.Text = "Submitted Successfully!!!";
                            lblSavedFillMandatoryMessages.Focus();
                            btnSubmit.Visible = false;
                            ddlapproval.Enabled = false;
                            txtcomments.Enabled = false;
                        }
                    }

                }
                hidAccordionIndex.Value = "9";
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

        protected void btnLastClear_Click(object sender, EventArgs e)
        {
            try
            {
                Server.Transfer("FrmRGYChecklistmain.aspx", false);
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

        #region Remove Records

        protected void gridbusiness_rowdeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)ViewState["keybusiness"];
                dt.Rows.RemoveAt(e.RowIndex);
                gridbusiness.DataSource = dt;
                gridbusiness.DataBind();
                ViewState["keybusiness"] = dt;
                double totalscore = 0;
                double average = 0;
                ////double finalpecent = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    totalscore += Convert.ToInt32(dr[2].ToString());
                    average = totalscore / Convert.ToDouble(dt.Rows.Count);
                    //ViewState["avgscore"] = average;
                }
                lblBusinessSolutionAverageScore.Text = average.ToString();
                btn1save();
                getfinalscorepercent();
                lblBusinessSolutionError.Text = string.Empty;
                hidAccordionIndex.Value = "0";
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

        protected void gridtechnical_rowdeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)ViewState["technical"];
                dt.Rows.RemoveAt(e.RowIndex);
                gridtechnical.DataSource = dt;
                gridtechnical.DataBind();
                ViewState["technical"] = dt;
                double totalscore = 0;
                double average = 0;
                ////double finalpecent = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    totalscore += Convert.ToInt32(dr[2].ToString());
                    average = totalscore / Convert.ToDouble(dt.Rows.Count);
                    //ViewState["avgscore"] = average;
                }
                lblTechnicalSolutionAverageScore.Text = average.ToString();
                btnSaveTech();
                getfinalscorepercent();
                lblTechnicalSolutionError.Text = string.Empty;
                hidAccordionIndex.Value = "1";
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

        protected void gridservice_rowdeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)ViewState["service"];
                dt.Rows.RemoveAt(e.RowIndex);
                gridservice.DataSource = dt;
                gridservice.DataBind();
                ViewState["service"] = dt;
                double totalscore = 0;
                double average = 0;
                ////double finalpecent = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    totalscore += Convert.ToInt32(dr[2].ToString());
                    average = totalscore / Convert.ToDouble(dt.Rows.Count);
                    //ViewState["avgscore"] = average;
                }
                seravscore.Text = average.ToString();
                btnSaveService();
                getfinalscorepercent();
                lblgridsererr.Text = string.Empty;
                hidAccordionIndex.Value = "2";
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

        protected void gridtransition_rowdeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)ViewState["transition"];
                dt.Rows.RemoveAt(e.RowIndex);
                gridtransition.DataSource = dt;
                gridtransition.DataBind();
                ViewState["transition"] = dt;
                double totalscore = 0;
                double average = 0;
                ////double finalpecent = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    totalscore += Convert.ToInt32(dr[2].ToString());
                    average = totalscore / Convert.ToDouble(dt.Rows.Count);
                    //ViewState["avgscore"] = average;
                }
                tranavscore.Text = average.ToString();
                btnSaveTrans();
                getfinalscorepercent();
                lblgridtransitionerror.Text = string.Empty;
                hidAccordionIndex.Value = "3";
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

        protected void gridgovern_rowdeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)ViewState["govern"];
                dt.Rows.RemoveAt(e.RowIndex);
                gridgovern.DataSource = dt;
                gridgovern.DataBind();
                ViewState["govern"] = dt;
                double totalscore = 0;
                double average = 0;
                ////double finalpecent = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    totalscore += Convert.ToInt32(dr[2].ToString());
                    average = totalscore / Convert.ToDouble(dt.Rows.Count);
                    //ViewState["avgscore"] = average;
                }
                govavscore.Text = average.ToString();
                btnSaveGov();
                getfinalscorepercent();
                lblgridgovernerror.Text = string.Empty;
                hidAccordionIndex.Value = "4";
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

        protected void gridprocess_rowdeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)ViewState["process"];
                dt.Rows.RemoveAt(e.RowIndex);
                gridprocess.DataSource = dt;
                gridprocess.DataBind();
                ViewState["process"] = dt;
                double totalscore = 0;
                double average = 0;
                ////double finalpecent = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    totalscore += Convert.ToInt32(dr[2].ToString());
                    average = totalscore / Convert.ToDouble(dt.Rows.Count);
                    //ViewState["avgscore"] = average;
                }
                proavscore.Text = average.ToString();
                btnSaveProc();
                getfinalscorepercent();
                lblgridprocesserror.Text = string.Empty;
                hidAccordionIndex.Value = "5";
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

        protected void gridhr_rowdeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)ViewState["HR"];
                dt.Rows.RemoveAt(e.RowIndex);
                gridhr.DataSource = dt;
                gridhr.DataBind();
                ViewState["HR"] = dt;
                double totalscore = 0;
                double average = 0;
                ////double finalpecent = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    totalscore += Convert.ToInt32(dr[2].ToString());
                    average = totalscore / Convert.ToDouble(dt.Rows.Count);
                    //ViewState["avgscore"] = average;
                }
                hravscore.Text = average.ToString();
                btnSaveHR();
                getfinalscorepercent();
                lblgridhrerror.Text = string.Empty;
                hidAccordionIndex.Value = "6";
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

        protected void gridcommercial_rowdeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)ViewState["commercial"];
                dt.Rows.RemoveAt(e.RowIndex);
                gridcommercial.DataSource = dt;
                gridcommercial.DataBind();
                ViewState["commercial"] = dt;
                double totalscore = 0;
                double average = 0;
                ////double finalpecent = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    totalscore += Convert.ToInt32(dr[2].ToString());
                    average = totalscore / Convert.ToDouble(dt.Rows.Count);
                    //ViewState["avgscore"] = average;
                }
                comavscore.Text = average.ToString();
                btnSaveCommercial();
                getfinalscorepercent();
                lblgridcommercialerror.Text = string.Empty;
                hidAccordionIndex.Value = "7";
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

        protected void gridintegration_rowdeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)ViewState["integration"];
                dt.Rows.RemoveAt(e.RowIndex);
                gridintegration.DataSource = dt;
                gridintegration.DataBind();
                ViewState["integration"] = dt;
                double totalscore = 0;
                double average = 0;
                ////double finalpecent = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    totalscore += Convert.ToInt32(dr[2].ToString());
                    average = totalscore / Convert.ToDouble(dt.Rows.Count);
                    //ViewState["avgscore"] = average;
                }
                intavscore.Text = average.ToString();
                btnSaveInt();
                getfinalscorepercent();
                lblgridintegrationerror.Text = string.Empty;
                hidAccordionIndex.Value = "8";
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

        #region Clear all Records
        protected void btnClearBusinessSolution_Click(object sender, EventArgs e)
        {
            clearTextBoxesBusinessSolutions();
             
        }

        protected void btnClearTechnicalSolution_Click(object sender, EventArgs e)
        {
            clearTextBoxes2();
        }

        protected void btnClearServiceDeliveryModel_Click(object sender, EventArgs e)
        {
            clearTextBoxes3();
        }

        protected void btnClearTransitionPlanning_Click(object sender, EventArgs e)
        {
            clearTextBoxes4();
        }

        protected void btnClearGovernance_Click(object sender, EventArgs e)
        {
            clearTextBoxes5();

        }

        protected void btnClearProcess_Click(object sender, EventArgs e)
        {
            clearTextBoxes6();
        }

        protected void btnClearHrChangeManagement_Click(object sender, EventArgs e)
        {
            clearTextBoxes7();
        }

        protected void btnClearCommercialsPricing_Click(object sender, EventArgs e)
        {
            clearTextBoxes8();
        }

        protected void btnClearIntegration_Click(object sender, EventArgs e)
        {
            clearTextBoxes9();
        }

        #endregion

        protected void disablecontrols()
        {
            bool status = false;
            HideDeleteandEdit(status);
            foreach (Control c in Form.Controls)
            {
                foreach(Control ctrl in c.Controls)
                {
                    if (ctrl is TextBox)
                    {
                        ((TextBox)(ctrl)).Visible = false;
                        if (ctrl.ID == "ddllevel")
                        { 
                            
                        }
                    }
                    if (ctrl is Button)
                    {
                        
                        ((Button)(ctrl)).Visible = false;
                       
                    }
                    if (ctrl is DropDownList)
                    {
                        ((DropDownList)(ctrl)).Visible = false;
                    }
                    if (ctrl is Label)
                    {
                        ((Label)(ctrl)).Enabled = false;
                    }
                    if (ctrl is Literal)
                    {
                        ((Literal)(ctrl)).Visible = false;
                    }
                    if (ctrl is Panel)
                    {
                        ((Panel)(ctrl)).Enabled = false;
                        
                    }
                    if (ctrl is GridView)
                    {
                        ((GridView)(ctrl)).Enabled = false;
                    }

                }
               
            }


        }

        protected void enablecontrols()
        {
            bool status = true;
            HideDeleteandEdit(status);
           foreach (Control c in Form.Controls) 
           { 
                foreach (Control ctrl in c.Controls) 
                { 
                    if (ctrl is TextBox) 
                    { 
                        ((TextBox)(ctrl)).Visible = true; 
                    } 
                    if (ctrl is Button) 
                    { 
                        ((Button)(ctrl)).Visible = true; 
                    } 
                    if (ctrl is DropDownList) 
                    { 
                        ((DropDownList)(ctrl)).Visible = true; 
                    }

                    if (ctrl is Label)
                    {
                        ((Label)(ctrl)).Enabled = true;
                    }
                    if (ctrl is Literal)
                    {
                        ((Literal)(ctrl)).Visible = true;
                    }
                    if (ctrl is Panel)
                    {
                        ((Panel)(ctrl)).Enabled = true;

                    }
                    if (ctrl is GridView)
                    {
                        ((GridView)(ctrl)).Enabled = true;
                    }

                }
               
            }
           // btnAddBusinessSolution.Visible = true;  
        }

        protected void HideDeleteandEdit(bool status)
        {
            gridbusiness.Columns[0].Visible = status;
            gridbusiness.Columns[1].Visible = status;
            gridtechnical.Columns[0].Visible = status;
            gridtechnical.Columns[1].Visible = status;
            gridservice.Columns[0].Visible = status;
            gridservice.Columns[1].Visible = status;
            gridtransition.Columns[0].Visible = status;
            gridtransition.Columns[1].Visible = status;
            gridgovern.Columns[0].Visible = status;
            gridgovern.Columns[1].Visible = status;
            gridprocess.Columns[0].Visible = status;
            gridprocess.Columns[1].Visible = status;
            gridhr.Columns[0].Visible = status;
            gridhr.Columns[1].Visible = status;
            gridcommercial.Columns[0].Visible = status;
            gridcommercial.Columns[1].Visible = status;
            gridintegration.Columns[0].Visible = status;
            gridintegration.Columns[1].Visible = status;
        }

        protected void ddlapproval_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlapproval.SelectedIndex == 2)
                {
                    lblcomments.Visible = true;
                    txtcomments.Visible = true;
                    btnSubmit.Enabled = true;
                }
                if (ddlapproval.SelectedIndex == 1)
                {
                    btnSubmit.Enabled = true;
                    lblcomments.Visible = false;
                    txtcomments.Visible = false;
                }
                if (ddlapproval.SelectedIndex == 0)
                {
                    btnSubmit.Enabled = false;
                    lblcomments.Visible = false;
                    txtcomments.Visible = false;
                }
                hidAccordionIndex.Value = "9";
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

        #region Edit Records

        protected void gridbusiness_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "UpdateRow")
                {
                    DataTable dt = (DataTable)ViewState["keybusiness"];
                    int RowIndex = Convert.ToInt32((e.CommandArgument));

                    GridViewRow row = gridbusiness.Rows[RowIndex];
                    dt.Rows[row.DataItemIndex]["keyclientrequirement"] = (row.FindControl("txtEditKey") as TextBox).Text;
                    dt.Rows[row.DataItemIndex]["impactonwhichpart"] = (row.FindControl("txtEditImpact") as TextBox).Text;
                    dt.Rows[row.DataItemIndex]["improvementarea"] = (row.FindControl("txtEditGaps") as TextBox).Text;
                    dt.Rows[row.DataItemIndex]["ownertoaddressarea"] = (row.FindControl("txtEditOwner") as TextBox).Text;
                    dt.Rows[row.DataItemIndex]["level"] = (row.FindControl("ddlEditBusinessLevel") as DropDownList).SelectedValue;
                    dt.Rows[row.DataItemIndex]["reviewdate"] = (row.FindControl("txtEditReview") as TextBox).Text;
                    gridbusiness.EditIndex = -1;
                    btnSaveBusiness(dt);
                    gridbusiness.DataSource = dt;
                    gridbusiness.DataBind();

                    for (int a = 0; a < gridbusiness.Rows.Count; a++)
                    {
                        //string val = coltable.Rows[i][2].ToString();
                        if (Convert.ToInt32(dt.Rows[a][2].ToString()) < 1)
                        {
                            gridbusiness.Rows[a].Cells[6].BackColor = System.Drawing.Color.Red;
                        }
                        else if (1 <= Convert.ToInt32(dt.Rows[a][2].ToString()) && Convert.ToInt32(dt.Rows[a][2].ToString()) < 4)
                        {
                            gridbusiness.Rows[a].Cells[6].BackColor = System.Drawing.Color.Yellow;
                        }
                        else
                        {
                            gridbusiness.Rows[a].Cells[6].BackColor = System.Drawing.Color.Green;
                        }
                    }
                    hidAccordionIndex.Value = "0";
                    btnLastSave.Enabled = true;
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
        protected void gridbusiness_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                DataTable coltable = (DataTable)ViewState["keybusiness"];
                gridbusiness.EditIndex = e.NewEditIndex;
                gridbusiness.DataSource = coltable;
                gridbusiness.DataBind();
                //btn1save();
                btnLastSave.Enabled = false;
                hidAccordionIndex.Value = "0";
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
        protected void gridbusiness_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                gridbusiness.EditIndex = -1;
                DataTable dt = (DataTable)ViewState["keybusiness"];
                gridbusiness.DataSource = dt;
                gridbusiness.DataBind();
                btn1save();
                btnLastSave.Enabled = true;
                hidAccordionIndex.Value = "0";
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

        protected void gridtechnical_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                DataTable coltable = (DataTable)ViewState["technical"];
                gridtechnical.EditIndex = e.NewEditIndex;
                gridtechnical.DataSource = coltable;
                gridtechnical.DataBind();
                //btnSaveTech();
                btnLastSave.Enabled = false;
                hidAccordionIndex.Value = "1";
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
        protected void gridtechnical_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                gridtechnical.EditIndex = -1;
                DataTable dt = (DataTable)ViewState["technical"];
                gridtechnical.DataSource = dt;
                gridtechnical.DataBind();
                btnSaveTech();
                btnLastSave.Enabled = true;
                hidAccordionIndex.Value = "1";
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
        protected void gridtechnical_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "UpdateRow")
                {
                    btnLastSave.Enabled = true;
                    DataTable dt = (DataTable)ViewState["technical"];
                    int RowIndex = Convert.ToInt32((e.CommandArgument));

                    GridViewRow row = gridtechnical.Rows[RowIndex];
                    dt.Rows[row.DataItemIndex]["keyclientrequirement"] = (row.FindControl("txtEditKey") as TextBox).Text;
                    dt.Rows[row.DataItemIndex]["impactonwhichpart"] = (row.FindControl("txtEditImpact") as TextBox).Text;
                    dt.Rows[row.DataItemIndex]["improvementarea"] = (row.FindControl("txtEditGaps") as TextBox).Text;
                    dt.Rows[row.DataItemIndex]["ownertoaddressarea"] = (row.FindControl("txtEditOwner") as TextBox).Text;
                    dt.Rows[row.DataItemIndex]["level"] = (row.FindControl("ddlEditTechnicalLevel") as DropDownList).SelectedValue;
                    dt.Rows[row.DataItemIndex]["reviewdate"] = (row.FindControl("txtEditReview") as TextBox).Text;

                    gridtechnical.EditIndex = -1;
                    btnSaveTechnical(dt);
                    gridtechnical.DataSource = dt;
                    gridtechnical.DataBind();

                    for (int it = 0; it < gridtechnical.Rows.Count; it++)
                    {
                        //string val = coltable.Rows[i][2].ToString();
                        if (Convert.ToInt32(dt.Rows[it][2].ToString()) < 1)
                        {
                            gridtechnical.Rows[it].Cells[6].BackColor = System.Drawing.Color.Red;
                        }
                        else if (1 <= Convert.ToInt32(dt.Rows[it][2].ToString()) && Convert.ToInt32(dt.Rows[it][2].ToString()) < 4)
                        {
                            gridtechnical.Rows[it].Cells[6].BackColor = System.Drawing.Color.Yellow;
                        }
                        else
                        {
                            gridtechnical.Rows[it].Cells[6].BackColor = System.Drawing.Color.Green;
                        }
                    }
                    hidAccordionIndex.Value = "1";
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

        protected void gridservice_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                DataTable coltable = (DataTable)ViewState["service"];
                gridservice.EditIndex = e.NewEditIndex;
                gridservice.DataSource = coltable;
                gridservice.DataBind();
                //btnSaveService();
                btnLastSave.Enabled = false;
                hidAccordionIndex.Value = "2";
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
        protected void gridservice_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                gridservice.EditIndex = -1;
                DataTable dt = (DataTable)ViewState["service"];
                gridservice.DataSource = dt;
                gridservice.DataBind();
                btnSaveService();
                btnLastSave.Enabled = true;
                hidAccordionIndex.Value = "2";
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
        protected void gridservice_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "UpdateRow")
                {
                    btnLastSave.Enabled = true;
                    DataTable dt = (DataTable)ViewState["service"];
                    int RowIndex = Convert.ToInt32((e.CommandArgument));

                    GridViewRow row = gridservice.Rows[RowIndex];
                    dt.Rows[row.DataItemIndex]["keyclientrequirement"] = (row.FindControl("txtEditKey") as TextBox).Text;
                    dt.Rows[row.DataItemIndex]["impactonwhichpart"] = (row.FindControl("txtEditImpact") as TextBox).Text;
                    dt.Rows[row.DataItemIndex]["improvementarea"] = (row.FindControl("txtEditGaps") as TextBox).Text;
                    dt.Rows[row.DataItemIndex]["ownertoaddressarea"] = (row.FindControl("txtEditOwner") as TextBox).Text;
                    dt.Rows[row.DataItemIndex]["level"] = (row.FindControl("ddlEditServiceLevel") as DropDownList).SelectedValue;
                    dt.Rows[row.DataItemIndex]["reviewdate"] = (row.FindControl("txtEditReview") as TextBox).Text;

                    gridservice.EditIndex = -1;
                    btnSaveService(dt);
                    gridservice.DataSource = dt;
                    gridservice.DataBind();

                    for (int it = 0; it < gridservice.Rows.Count; it++)
                    {
                        //string val = coltable.Rows[i][2].ToString();
                        if (Convert.ToInt32(dt.Rows[it][2].ToString()) < 1)
                        {
                            gridservice.Rows[it].Cells[6].BackColor = System.Drawing.Color.Red;
                        }
                        else if (1 <= Convert.ToInt32(dt.Rows[it][2].ToString()) && Convert.ToInt32(dt.Rows[it][2].ToString()) < 4)
                        {
                            gridservice.Rows[it].Cells[6].BackColor = System.Drawing.Color.Yellow;
                        }
                        else
                        {
                            gridservice.Rows[it].Cells[6].BackColor = System.Drawing.Color.Green;
                        }
                    }
                    hidAccordionIndex.Value = "2";
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

        protected void gridtransition_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "UpdateRow")
                {
                    btnLastSave.Enabled = true;
                    DataTable dt = (DataTable)ViewState["transition"];
                    int RowIndex = Convert.ToInt32((e.CommandArgument));

                    GridViewRow row = gridtransition.Rows[RowIndex];
                    dt.Rows[row.DataItemIndex]["keyclientrequirement"] = (row.FindControl("txtEditKey") as TextBox).Text;
                    dt.Rows[row.DataItemIndex]["impactonwhichpart"] = (row.FindControl("txtEditImpact") as TextBox).Text;
                    dt.Rows[row.DataItemIndex]["improvementarea"] = (row.FindControl("txtEditGaps") as TextBox).Text;
                    dt.Rows[row.DataItemIndex]["ownertoaddressarea"] = (row.FindControl("txtEditOwner") as TextBox).Text;
                    dt.Rows[row.DataItemIndex]["level"] = (row.FindControl("ddlEditTransitionLevel") as DropDownList).SelectedValue;
                    dt.Rows[row.DataItemIndex]["reviewdate"] = (row.FindControl("txtEditReview") as TextBox).Text;

                    gridtransition.EditIndex = -1;
                    btnSaveTransition(dt);
                    gridtransition.DataSource = dt;
                    gridtransition.DataBind();
                    hidAccordionIndex.Value = "3";

                    for (int it = 0; it < gridtransition.Rows.Count; it++)
                    {
                        //string val = coltable.Rows[i][2].ToString();
                        if (Convert.ToInt32(dt.Rows[it][2].ToString()) < 1)
                        {
                            gridtransition.Rows[it].Cells[6].BackColor = System.Drawing.Color.Red;
                        }
                        else if (1 <= Convert.ToInt32(dt.Rows[it][2].ToString()) && Convert.ToInt32(dt.Rows[it][2].ToString()) < 4)
                        {
                            gridtransition.Rows[it].Cells[6].BackColor = System.Drawing.Color.Yellow;
                        }
                        else
                        {
                            gridtransition.Rows[it].Cells[6].BackColor = System.Drawing.Color.Green;
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
        protected void gridtransition_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                gridtransition.EditIndex = -1;
                DataTable dt = (DataTable)ViewState["transition"];
                gridtransition.DataSource = dt;
                gridtransition.DataBind();
                btnSaveTrans();
                btnLastSave.Enabled = true;
                hidAccordionIndex.Value = "3";
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
        protected void gridtransition_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                DataTable coltable = (DataTable)ViewState["transition"];
                gridtransition.EditIndex = e.NewEditIndex;
                gridtransition.DataSource = coltable;
                gridtransition.DataBind();
                //btnSaveTrans();
                btnLastSave.Enabled = false;
                hidAccordionIndex.Value = "3";
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

        protected void gridgovern_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                DataTable coltable = (DataTable)ViewState["govern"];
                gridgovern.EditIndex = e.NewEditIndex;
                gridgovern.DataSource = coltable;
                gridgovern.DataBind();
                //btnSaveGov();
                btnLastSave.Enabled = false;
                hidAccordionIndex.Value = "4";
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
        protected void gridgovern_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "UpdateRow")
                {
                    btnLastSave.Enabled = true;
                    DataTable dt = (DataTable)ViewState["govern"];
                    int RowIndex = Convert.ToInt32((e.CommandArgument));

                    GridViewRow row = gridgovern.Rows[RowIndex];
                    dt.Rows[row.DataItemIndex]["keyclientrequirement"] = (row.FindControl("txtEditKey") as TextBox).Text;
                    dt.Rows[row.DataItemIndex]["impactonwhichpart"] = (row.FindControl("txtEditImpact") as TextBox).Text;
                    dt.Rows[row.DataItemIndex]["improvementarea"] = (row.FindControl("txtEditGaps") as TextBox).Text;
                    dt.Rows[row.DataItemIndex]["ownertoaddressarea"] = (row.FindControl("txtEditOwner") as TextBox).Text;
                    dt.Rows[row.DataItemIndex]["level"] = (row.FindControl("ddlEditGovernLevel") as DropDownList).SelectedValue;
                    dt.Rows[row.DataItemIndex]["reviewdate"] = (row.FindControl("txtEditReview") as TextBox).Text;

                    gridgovern.EditIndex = -1;
                    btnSaveGovernance(dt);
                    gridgovern.DataSource = dt;
                    gridgovern.DataBind();
                    hidAccordionIndex.Value = "4";

                    for (int it = 0; it < gridgovern.Rows.Count; it++)
                    {
                        //string val = coltable.Rows[i][2].ToString();
                        if (Convert.ToInt32(dt.Rows[it][2].ToString()) < 1)
                        {
                            gridgovern.Rows[it].Cells[6].BackColor = System.Drawing.Color.Red;
                        }
                        else if (1 <= Convert.ToInt32(dt.Rows[it][2].ToString()) && Convert.ToInt32(dt.Rows[it][2].ToString()) < 4)
                        {
                            gridgovern.Rows[it].Cells[6].BackColor = System.Drawing.Color.Yellow;
                        }
                        else
                        {
                            gridgovern.Rows[it].Cells[6].BackColor = System.Drawing.Color.Green;
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
        protected void gridgovern_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                gridgovern.EditIndex = -1;
                DataTable dt = (DataTable)ViewState["govern"];
                gridgovern.DataSource = dt;
                gridgovern.DataBind();
                btnLastSave.Enabled = true;
                hidAccordionIndex.Value = "4";
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

        protected void gridprocess_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                DataTable coltable = (DataTable)ViewState["process"];
                gridprocess.EditIndex = e.NewEditIndex;
                gridprocess.DataSource = coltable;
                gridprocess.DataBind();
                btnLastSave.Enabled = false;
                hidAccordionIndex.Value = "5";
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
        protected void gridprocess_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "UpdateRow")
                {
                    btnLastSave.Enabled = true;
                    DataTable dt = (DataTable)ViewState["process"];
                    int RowIndex = Convert.ToInt32((e.CommandArgument));

                    GridViewRow row = gridprocess.Rows[RowIndex];
                    dt.Rows[row.DataItemIndex]["keyclientrequirement"] = (row.FindControl("txtEditKey") as TextBox).Text;
                    dt.Rows[row.DataItemIndex]["impactonwhichpart"] = (row.FindControl("txtEditImpact") as TextBox).Text;
                    dt.Rows[row.DataItemIndex]["improvementarea"] = (row.FindControl("txtEditGaps") as TextBox).Text;
                    dt.Rows[row.DataItemIndex]["ownertoaddressarea"] = (row.FindControl("txtEditOwner") as TextBox).Text;
                    dt.Rows[row.DataItemIndex]["level"] = (row.FindControl("ddlEditProcessLevel") as DropDownList).SelectedValue;
                    dt.Rows[row.DataItemIndex]["reviewdate"] = (row.FindControl("txtEditReview") as TextBox).Text;

                    gridprocess.EditIndex = -1;
                    btnSaveProcess(dt);
                    gridprocess.DataSource = dt;
                    gridprocess.DataBind();
                    hidAccordionIndex.Value = "5";

                    for (int it = 0; it < gridprocess.Rows.Count; it++)
                    {
                        //string val = coltable.Rows[i][2].ToString();
                        if (Convert.ToInt32(dt.Rows[it][2].ToString()) < 1)
                        {
                            gridprocess.Rows[it].Cells[6].BackColor = System.Drawing.Color.Red;
                        }
                        else if (1 <= Convert.ToInt32(dt.Rows[it][2].ToString()) && Convert.ToInt32(dt.Rows[it][2].ToString()) < 4)
                        {
                            gridprocess.Rows[it].Cells[6].BackColor = System.Drawing.Color.Yellow;
                        }
                        else
                        {
                            gridprocess.Rows[it].Cells[6].BackColor = System.Drawing.Color.Green;
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
        protected void gridprocess_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                gridprocess.EditIndex = -1;
                DataTable dt = (DataTable)ViewState["process"];
                gridprocess.DataSource = dt;
                gridprocess.DataBind();
                btnLastSave.Enabled = true;
                hidAccordionIndex.Value = "5";
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

        protected void gridhr_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                DataTable coltable = (DataTable)ViewState["HR"];
                gridhr.EditIndex = e.NewEditIndex;
                gridhr.DataSource = coltable;
                gridhr.DataBind();
                btnLastSave.Enabled = false;
                hidAccordionIndex.Value = "6";
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
        protected void gridhr_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "UpdateRow")
                {
                    btnLastSave.Enabled = true;
                    DataTable dt = (DataTable)ViewState["HR"];
                    int RowIndex = Convert.ToInt32((e.CommandArgument));

                    GridViewRow row = gridhr.Rows[RowIndex];
                    dt.Rows[row.DataItemIndex]["keyclientrequirement"] = (row.FindControl("txtEditKey") as TextBox).Text;
                    dt.Rows[row.DataItemIndex]["impactonwhichpart"] = (row.FindControl("txtEditImpact") as TextBox).Text;
                    dt.Rows[row.DataItemIndex]["improvementarea"] = (row.FindControl("txtEditGaps") as TextBox).Text;
                    dt.Rows[row.DataItemIndex]["ownertoaddressarea"] = (row.FindControl("txtEditOwner") as TextBox).Text;
                    dt.Rows[row.DataItemIndex]["level"] = (row.FindControl("ddlEditHrLevel") as DropDownList).SelectedValue;
                    dt.Rows[row.DataItemIndex]["reviewdate"] = (row.FindControl("txtEditReview") as TextBox).Text;

                    gridhr.EditIndex = -1;
                    btnSaveHRChange(dt);
                    gridhr.DataSource = dt;
                    gridhr.DataBind();
                    hidAccordionIndex.Value = "6";

                    for (int it = 0; it < gridhr.Rows.Count; it++)
                    {
                        //string val = coltable.Rows[i][2].ToString();
                        if (Convert.ToInt32(dt.Rows[it][2].ToString()) < 1)
                        {
                            gridhr.Rows[it].Cells[6].BackColor = System.Drawing.Color.Red;
                        }
                        else if (1 <= Convert.ToInt32(dt.Rows[it][2].ToString()) && Convert.ToInt32(dt.Rows[it][2].ToString()) < 4)
                        {
                            gridhr.Rows[it].Cells[6].BackColor = System.Drawing.Color.Yellow;
                        }
                        else
                        {
                            gridhr.Rows[it].Cells[6].BackColor = System.Drawing.Color.Green;
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
        protected void gridhr_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                gridhr.EditIndex = -1;
                DataTable dt = (DataTable)ViewState["HR"];
                gridhr.DataSource = dt;
                gridhr.DataBind();
                btnLastSave.Enabled = true;
                hidAccordionIndex.Value = "6";
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

        protected void gridcommercial_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                DataTable coltable = (DataTable)ViewState["commercial"];
                gridcommercial.EditIndex = e.NewEditIndex;
                gridcommercial.DataSource = coltable;
                gridcommercial.DataBind();
                btnLastSave.Enabled = false;
                hidAccordionIndex.Value = "7";
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
        protected void gridcommercial_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "UpdateRow")
                {
                    btnLastSave.Enabled = true;
                    DataTable dt = (DataTable)ViewState["commercial"];
                    int RowIndex = Convert.ToInt32((e.CommandArgument));

                    GridViewRow row = gridcommercial.Rows[RowIndex];
                    dt.Rows[row.DataItemIndex]["keyclientrequirement"] = (row.FindControl("txtEditKey") as TextBox).Text;
                    dt.Rows[row.DataItemIndex]["impactonwhichpart"] = (row.FindControl("txtEditImpact") as TextBox).Text;
                    dt.Rows[row.DataItemIndex]["improvementarea"] = (row.FindControl("txtEditGaps") as TextBox).Text;
                    dt.Rows[row.DataItemIndex]["ownertoaddressarea"] = (row.FindControl("txtEditOwner") as TextBox).Text;
                    dt.Rows[row.DataItemIndex]["level"] = (row.FindControl("ddlEditCommercialLevel") as DropDownList).SelectedValue;
                    dt.Rows[row.DataItemIndex]["reviewdate"] = (row.FindControl("txtEditReview") as TextBox).Text;

                    gridcommercial.EditIndex = -1;
                    btnSaveCommercial(dt);
                    gridcommercial.DataSource = dt;
                    gridcommercial.DataBind();
                    hidAccordionIndex.Value = "7";

                    for (int it = 0; it < gridcommercial.Rows.Count; it++)
                    {
                        //string val = coltable.Rows[i][2].ToString();
                        if (Convert.ToInt32(dt.Rows[it][2].ToString()) < 1)
                        {
                            gridcommercial.Rows[it].Cells[6].BackColor = System.Drawing.Color.Red;
                        }
                        else if (1 <= Convert.ToInt32(dt.Rows[it][2].ToString()) && Convert.ToInt32(dt.Rows[it][2].ToString()) < 4)
                        {
                            gridcommercial.Rows[it].Cells[6].BackColor = System.Drawing.Color.Yellow;
                        }
                        else
                        {
                            gridcommercial.Rows[it].Cells[6].BackColor = System.Drawing.Color.Green;
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
        protected void gridcommercial_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                gridcommercial.EditIndex = -1;
                DataTable dt = (DataTable)ViewState["commercial"];
                gridcommercial.DataSource = dt;
                gridcommercial.DataBind();
                btnLastSave.Enabled = true;
                hidAccordionIndex.Value = "7";
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

        protected void gridintegration_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                DataTable coltable = (DataTable)ViewState["integration"];
                gridintegration.EditIndex = e.NewEditIndex;
                gridintegration.DataSource = coltable;
                gridintegration.DataBind();
                btnLastSave.Enabled = false;
                hidAccordionIndex.Value = "8";
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
        protected void gridintegration_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "UpdateRow")
                {
                    btnLastSave.Enabled = true;
                    DataTable dt = (DataTable)ViewState["integration"];
                    int RowIndex = Convert.ToInt32((e.CommandArgument));

                    GridViewRow row = gridintegration.Rows[RowIndex];
                    dt.Rows[row.DataItemIndex]["keyclientrequirement"] = (row.FindControl("txtEditKey") as TextBox).Text;
                    dt.Rows[row.DataItemIndex]["impactonwhichpart"] = (row.FindControl("txtEditImpact") as TextBox).Text;
                    dt.Rows[row.DataItemIndex]["improvementarea"] = (row.FindControl("txtEditGaps") as TextBox).Text;
                    dt.Rows[row.DataItemIndex]["ownertoaddressarea"] = (row.FindControl("txtEditOwner") as TextBox).Text;
                    dt.Rows[row.DataItemIndex]["level"] = (row.FindControl("ddlEditIntegrationLevel") as DropDownList).SelectedValue;
                    dt.Rows[row.DataItemIndex]["reviewdate"] = (row.FindControl("txtEditReview") as TextBox).Text;

                    gridintegration.EditIndex = -1;
                    btnSaveIntegration(dt);
                    gridintegration.DataSource = dt;
                    gridintegration.DataBind();
                    hidAccordionIndex.Value = "8";

                    for (int it = 0; it < gridintegration.Rows.Count; it++)
                    {
                        //string val = coltable.Rows[i][2].ToString();
                        if (Convert.ToInt32(dt.Rows[it][2].ToString()) < 1)
                        {
                            gridintegration.Rows[it].Cells[6].BackColor = System.Drawing.Color.Red;
                        }
                        else if (1 <= Convert.ToInt32(dt.Rows[it][2].ToString()) && Convert.ToInt32(dt.Rows[it][2].ToString()) < 4)
                        {
                            gridintegration.Rows[it].Cells[6].BackColor = System.Drawing.Color.Yellow;
                        }
                        else
                        {
                            gridintegration.Rows[it].Cells[6].BackColor = System.Drawing.Color.Green;
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
        protected void gridintegration_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                gridintegration.EditIndex = -1;
                DataTable dt = (DataTable)ViewState["integration"];
                gridintegration.DataSource = dt;
                gridintegration.DataBind();
                btnSaveInt();
                btnLastSave.Enabled = true;
                hidAccordionIndex.Value = "8";
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

        protected void gridbusiness_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow && gridbusiness.EditIndex == e.Row.RowIndex)
                {


                    DropDownList ddlEditBusinessLevel = (DropDownList)e.Row.FindControl("ddlEditBusinessLevel");
                    DataSet populateddlevel = new DataSet();
                    populateddlevel = new BLL.RGYBLL().populateddllevel();
                    ddlEditBusinessLevel.DataSource = populateddlevel;
                    ddlEditBusinessLevel.DataTextField = "ILevelVal";
                    ddlEditBusinessLevel.DataValueField = "ILevelVal";
                    ddlEditBusinessLevel.DataBind();
                    LinkButton lnkDeleteBusi = (LinkButton)e.Row.FindControl("lnkDeleteBusi");
                    lnkDeleteBusi.Enabled = false;
                    DataRowView dr = e.Row.DataItem as DataRowView;
                    //ddList.SelectedItem.Text = dr["category_name"].ToString();
                    ddlEditBusinessLevel.SelectedValue = dr["level"].ToString();
                }
                int _intdesinationid = (int)Session["Designation"];

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton btnupd = (LinkButton)e.Row.FindControl("lnkUpdate");//("lnkUpdate");
                    if (btnupd != null)
                    {
                        btnupd.Attributes.Add("onclick", "return gvBusinessValidate(" + e.Row.RowIndex.ToString() + ")");
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
        protected void gridtechnical_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow && gridtechnical.EditIndex == e.Row.RowIndex)
                {


                    DropDownList ddlEditTechnicalLevel = (DropDownList)e.Row.FindControl("ddlEditTechnicalLevel");
                    DataSet populateddlevel = new DataSet();
                    populateddlevel = new BLL.RGYBLL().populateddllevel();
                    ddlEditTechnicalLevel.DataSource = populateddlevel;
                    ddlEditTechnicalLevel.DataTextField = "ILevelVal";
                    ddlEditTechnicalLevel.DataValueField = "ILevelVal";
                    ddlEditTechnicalLevel.DataBind();
                    LinkButton lnkDeleteTech = (LinkButton)e.Row.FindControl("lnkDeleteTech");
                    lnkDeleteTech.Enabled = false;
                    DataRowView dr = e.Row.DataItem as DataRowView;
                    //ddList.SelectedItem.Text = dr["category_name"].ToString();
                    ddlEditTechnicalLevel.SelectedValue = dr["level"].ToString();
                }
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton btnupd = (LinkButton)e.Row.FindControl("lnkUpdate");//("lnkUpdate");
                    if (btnupd != null)
                    {
                        btnupd.Attributes.Add("onclick", "return gvtechnicalValidate(" + e.Row.RowIndex.ToString() + ")");
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
        protected void gridservice_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow && gridservice.EditIndex == e.Row.RowIndex)
                {


                    DropDownList ddlEditServiceLevel = (DropDownList)e.Row.FindControl("ddlEditServiceLevel");
                    DataSet populateddlevel = new DataSet();
                    populateddlevel = new BLL.RGYBLL().populateddllevel();
                    ddlEditServiceLevel.DataSource = populateddlevel;
                    ddlEditServiceLevel.DataTextField = "ILevelVal";
                    ddlEditServiceLevel.DataValueField = "ILevelVal";
                    ddlEditServiceLevel.DataBind();
                    LinkButton lnkDeleteServ = (LinkButton)e.Row.FindControl("lnkDeleteServ");
                    lnkDeleteServ.Enabled = false;
                    DataRowView dr = e.Row.DataItem as DataRowView;
                    //ddList.SelectedItem.Text = dr["category_name"].ToString();
                    ddlEditServiceLevel.SelectedValue = dr["level"].ToString();
                }
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton btnupd = (LinkButton)e.Row.FindControl("lnkUpdate");//("lnkUpdate");
                    if (btnupd != null)
                    {
                        btnupd.Attributes.Add("onclick", "return gvServiceValidate(" + e.Row.RowIndex.ToString() + ")");
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
        protected void gridtransition_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow && gridtransition.EditIndex == e.Row.RowIndex)
                {


                    DropDownList ddlEditTransitionLevel = (DropDownList)e.Row.FindControl("ddlEditTransitionLevel");
                    DataSet populateddlevel = new DataSet();
                    populateddlevel = new BLL.RGYBLL().populateddllevel();
                    ddlEditTransitionLevel.DataSource = populateddlevel;
                    ddlEditTransitionLevel.DataTextField = "ILevelVal";
                    ddlEditTransitionLevel.DataValueField = "ILevelVal";
                    ddlEditTransitionLevel.DataBind();
                    LinkButton lnkDeleteTrans = (LinkButton)e.Row.FindControl("lnkDeleteTrans");
                    lnkDeleteTrans.Enabled = false;
                    DataRowView dr = e.Row.DataItem as DataRowView;
                    //ddList.SelectedItem.Text = dr["category_name"].ToString();
                    ddlEditTransitionLevel.SelectedValue = dr["level"].ToString();
                }
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton btnupd = (LinkButton)e.Row.FindControl("lnkUpdate");//("lnkUpdate");
                    if (btnupd != null)
                    {
                        btnupd.Attributes.Add("onclick", "return gvtransValidate(" + e.Row.RowIndex.ToString() + ")");
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
        protected void gridgovern_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow && gridgovern.EditIndex == e.Row.RowIndex)
                {


                    DropDownList ddlEditGovernLevel = (DropDownList)e.Row.FindControl("ddlEditGovernLevel");
                    DataSet populateddlevel = new DataSet();
                    populateddlevel = new BLL.RGYBLL().populateddllevel();
                    ddlEditGovernLevel.DataSource = populateddlevel;
                    ddlEditGovernLevel.DataTextField = "ILevelVal";
                    ddlEditGovernLevel.DataValueField = "ILevelVal";
                    ddlEditGovernLevel.DataBind();
                    LinkButton lnkDeleteGovern = (LinkButton)e.Row.FindControl("lnkDeleteGovern");
                    lnkDeleteGovern.Enabled = false;
                    DataRowView dr = e.Row.DataItem as DataRowView;
                    //ddList.SelectedItem.Text = dr["category_name"].ToString();
                    ddlEditGovernLevel.SelectedValue = dr["level"].ToString();
                }
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton btnupd = (LinkButton)e.Row.FindControl("lnkUpdate");//("lnkUpdate");
                    if (btnupd != null)
                    {
                        btnupd.Attributes.Add("onclick", "return gvgovernValidate(" + e.Row.RowIndex.ToString() + ")");
                    }

                    //e.Row.Cells[0].Attributes.Add("style", "word-break:break-all;word-wrap:break-word;");
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
        protected void gridprocess_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow && gridprocess.EditIndex == e.Row.RowIndex)
                {


                    DropDownList ddlEditProcessLevel = (DropDownList)e.Row.FindControl("ddlEditProcessLevel");
                    DataSet populateddlevel = new DataSet();
                    populateddlevel = new BLL.RGYBLL().populateddllevel();
                    ddlEditProcessLevel.DataSource = populateddlevel;
                    ddlEditProcessLevel.DataTextField = "ILevelVal";
                    ddlEditProcessLevel.DataValueField = "ILevelVal";
                    ddlEditProcessLevel.DataBind();
                    LinkButton lnkDeleteProcess = (LinkButton)e.Row.FindControl("lnkDeleteProcess");
                    lnkDeleteProcess.Enabled = false;
                    DataRowView dr = e.Row.DataItem as DataRowView;
                    //ddList.SelectedItem.Text = dr["category_name"].ToString();
                    ddlEditProcessLevel.SelectedValue = dr["level"].ToString();
                }
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton btnupd = (LinkButton)e.Row.FindControl("lnkUpdate");//("lnkUpdate");
                    if (btnupd != null)
                    {
                        btnupd.Attributes.Add("onclick", "return gvprocessValidate(" + e.Row.RowIndex.ToString() + ")");
                    }

                    //e.Row.Cells[0].Attributes.Add("style", "word-break:break-all;word-wrap:break-word;");
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
        protected void gridhr_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow && gridhr.EditIndex == e.Row.RowIndex)
                {


                    DropDownList ddlEditHrLevel = (DropDownList)e.Row.FindControl("ddlEditHrLevel");
                    DataSet populateddlevel = new DataSet();
                    populateddlevel = new BLL.RGYBLL().populateddllevel();
                    ddlEditHrLevel.DataSource = populateddlevel;
                    ddlEditHrLevel.DataTextField = "ILevelVal";
                    ddlEditHrLevel.DataValueField = "ILevelVal";
                    ddlEditHrLevel.DataBind();
                    LinkButton lnkDeletehr = (LinkButton)e.Row.FindControl("lnkDeletehr");
                    lnkDeletehr.Enabled = false;
                    DataRowView dr = e.Row.DataItem as DataRowView;
                    //ddList.SelectedItem.Text = dr["category_name"].ToString();
                    ddlEditHrLevel.SelectedValue = dr["level"].ToString();
                }
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton btnupd = (LinkButton)e.Row.FindControl("lnkUpdate");//("lnkUpdate");
                    if (btnupd != null)
                    {
                        btnupd.Attributes.Add("onclick", "return gvHRValidate(" + e.Row.RowIndex.ToString() + ")");
                    }

                    //e.Row.Cells[0].Attributes.Add("style", "word-break:break-all;word-wrap:break-word;");
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
        protected void gridcommercial_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow && gridcommercial.EditIndex == e.Row.RowIndex)
                {


                    DropDownList ddlEditCommercialLevel = (DropDownList)e.Row.FindControl("ddlEditCommercialLevel");
                    DataSet populateddlevel = new DataSet();
                    populateddlevel = new BLL.RGYBLL().populateddllevel();
                    ddlEditCommercialLevel.DataSource = populateddlevel;
                    ddlEditCommercialLevel.DataTextField = "ILevelVal";
                    ddlEditCommercialLevel.DataValueField = "ILevelVal";
                    ddlEditCommercialLevel.DataBind();
                    LinkButton lnkDeleteCommer = (LinkButton)e.Row.FindControl("lnkDeleteCommer");
                    lnkDeleteCommer.Enabled = false;
                    DataRowView dr = e.Row.DataItem as DataRowView;
                    //ddList.SelectedItem.Text = dr["category_name"].ToString();
                    ddlEditCommercialLevel.SelectedValue = dr["level"].ToString();
                }
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton btnupd = (LinkButton)e.Row.FindControl("lnkUpdate");//("lnkUpdate");
                    if (btnupd != null)
                    {
                        btnupd.Attributes.Add("onclick", "return gvCommercialValidate(" + e.Row.RowIndex.ToString() + ")");
                    }

                    //e.Row.Cells[0].Attributes.Add("style", "word-break:break-all;word-wrap:break-word;");
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
        protected void gridintegration_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow && gridintegration.EditIndex == e.Row.RowIndex)
                {


                    DropDownList ddlEditIntegrationLevel = (DropDownList)e.Row.FindControl("ddlEditIntegrationLevel");
                    DataSet populateddlevel = new DataSet();
                    populateddlevel = new BLL.RGYBLL().populateddllevel();
                    ddlEditIntegrationLevel.DataSource = populateddlevel;
                    ddlEditIntegrationLevel.DataTextField = "ILevelVal";
                    ddlEditIntegrationLevel.DataValueField = "ILevelVal";
                    ddlEditIntegrationLevel.DataBind();
                    LinkButton lnkDeleteInteg = (LinkButton)e.Row.FindControl("lnkDeleteInteg");
                    lnkDeleteInteg.Enabled = false;
                    DataRowView dr = e.Row.DataItem as DataRowView;
                    //ddList.SelectedItem.Text = dr["category_name"].ToString();
                    ddlEditIntegrationLevel.SelectedValue = dr["level"].ToString();
                }
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton btnupd = (LinkButton)e.Row.FindControl("lnkUpdate");//("lnkUpdate");
                    if (btnupd != null)
                    {
                        btnupd.Attributes.Add("onclick", "return gvIntegrationValidate(" + e.Row.RowIndex.ToString() + ")");
                    }

                    //e.Row.Cells[0].Attributes.Add("style", "word-break:break-all;word-wrap:break-word;");
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

        protected void btnmodifychecklist_Click(object sender, EventArgs e)
        {
            try
            {
                enablecontrols();
                txtcomments.Visible = false;
                lblcomments.Visible = false;
                lblIterativeCount.Text = string.Empty;
                btnmodifychecklist.Visible = false;
                ddlapproval.Visible = false;
                ddlrgytype.SelectedIndex = 0;
                btnSubmit.Visible = false;
                SubDate.Text = string.Empty;
                //txtwinthemetext.Text = string.Empty;
                lblApprovedResult.Text = "Not Submitted";
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
        #endregion;

        protected void ifNotToBeSubmitted()
        {
            btnSubmit.Visible = false;
            txtcomments.Visible = false;
            lblcomments.Visible = false;
            lblapproval.Visible = false;
            ddlapproval.Visible = false;
        }

        protected void forBidManager(string _strOppid, DataSet dsretrieveparams)
        {
            dataonpageload();
            disablecontrols();
            btnLastSave.Visible = false;
            btnLastClear.Visible = false;
            btnSubmit.Enabled = false;
            ddlapproval.Visible = false;
            ddlrgytype.CausesValidation = false;
            lblapproval.Visible = false;
            lblcomments.Visible = false;
        }
    }
}

        
