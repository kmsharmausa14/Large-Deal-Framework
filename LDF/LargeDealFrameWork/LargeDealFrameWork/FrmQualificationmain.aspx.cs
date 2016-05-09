
/* ---------------------------------------------------------------------------------------------------------------
 * Project Name : Large Deal Type
 * Module Name : Opportunity Qualification
 * Program Version : 1.0.0
 * Filename : FrmQualificationmain.aspx.cs
 * Purpose : This page contains scores filled in Clients demand screen, Syntel Business screen, Clients Urgency screen 
             and Syntel Competitive. The page calculate scores, percentage for all screen 
 * ----------------------------------------------------------------------------------------------------------------
 * MODIFICATION HISTORY:
 * ----------------------------------------------------------------------------------------------------------------
 * PHASE    AUTHOR                 DATE          MODIFICATION           DESCRIPTION
 *                              (MM/DD/YYYY)     DETAILS
 * ----------------------------------------------------------------------------------------------------------------
 *   1.    PRIYANKA DATIR        12/05/2013      CREATED                NONE  
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using BO;
using BLL;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace LargeDealFrameWork
{
    public partial class Qualificationmain : System.Web.UI.Page
    {
        int _intDesignation = 0;

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Designation"] != null)
                {
                    _intDesignation = Convert.ToInt32(Session["Designation"]);
                }
                string _strOppid = string.Empty;
                if (Request.QueryString["OppID"] != null)
                {
                    _strOppid = Request.QueryString["OppID"].ToString();
                    Session["Oppid"] = _strOppid;

                }
                else
                {
                    if (Session["Oppid"] != null)
                    {
                        _strOppid = (string)Session["Oppid"];
                    }
                }
                Label6.Text = _strOppid;
                ParamcolumnsBO finalsend = new ParamcolumnsBO();
                finalsend.OppId = _strOppid;
                Label8.Text = new BLL.RGYBLL().retrieveoppname(finalsend);

                if (!IsPostBack)
                {
                    
                    //Populate Score and its description in Gridview
                    PopulateActiveScoreScaleGridview();

                    //Populate Score for all screens on main page
                    PopulateScoreforAllScreens();

                    //Displays description for calculated percentage
                    DisplayDescriptiononScore();

                    //Get scores and their description for all screen
                    GetScoreDescription();

                    //Populate Status and Deal Type dropdownlist
                    PopulateDropDownList();
                }
          
                DisplaySubmit();
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

        #region Private methods
        private void DisplaySubmit()
        {
            try
            {
                string _strStatus = string.Empty;
                QualificationDetailsBO clsQuaDetailsBO = new QualificationDetailsBO();
                clsQuaDetailsBO.OppNumber = (string)Session["Oppid"];
                DataSet dsPopulateallScreen = new BLL.ScoreOppQuaBLL().GetScoreDescriptionParameterforAllScreens(clsQuaDetailsBO);
                DataSet dsGetStatusValue = new BLL.ScoreOppQuaBLL().GetOpportunityQualificationDetails((string)Session["Oppid"]);
                if (dsGetStatusValue.Tables.Count > 0)
                {
                    if (dsGetStatusValue.Tables[0].Rows.Count > 0)
                    {
                        if(dsGetStatusValue.Tables[0].Rows[0][4].ToString() !=string.Empty)
                             _strStatus = dsGetStatusValue.Tables[0].Rows[0][4].ToString();
                    }
                }

                if (_intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.BUHead) && (dsPopulateallScreen.Tables[0].Rows.Count == 21 || _strStatus.Trim() == "Not Approved"))
                {
                    btnSubmit.Visible = true;
                    tblStatus.Visible = true;
                }

                ScoreOppQuaBLL clsScoreOppQuaBLL = new ScoreOppQuaBLL();
                DataSet dsScoreStatusOppQua = new DataSet();
                string _strOppNumber = (string)Session["Oppid"];
                dsScoreStatusOppQua = clsScoreOppQuaBLL.GetOpportunityQualificationDetails(_strOppNumber);

                if (dsScoreStatusOppQua.Tables.Count > 0)
                {
                    if (dsScoreStatusOppQua.Tables[0].Rows.Count > 0)
                    {
                        tblStatusDealType.Visible = true;
                        lblBUHead.Text = dsScoreStatusOppQua.Tables[0].Rows[0][6].ToString();
                        lblStatusbyBUHead.Text = dsScoreStatusOppQua.Tables[0].Rows[0][4].ToString();
                        lblDealTypebyBUHead.Text = dsScoreStatusOppQua.Tables[0].Rows[0][5].ToString();
                        if (_strStatus.Trim() != "Not Approved")
                        {
                            tblStatus.Visible = false;
                            btnSubmit.Visible = false;
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

        private void PopulateScoreforAllScreens()
        {
            try
            {
                //Clients Demands Presence scale score
                QualificationDetailsBO clsQuaDetailsClientsDemandBO = new QualificationDetailsBO();
                clsQuaDetailsClientsDemandBO.OppNumber = (string)Session["Oppid"];
                clsQuaDetailsClientsDemandBO.ParaID = Constants._intEmotionalParaID;
                DataSet dsPopulateClientsDemand = new BLL.ScoreOppQuaBLL().GetScoreDescriptionForParameterScreen1(clsQuaDetailsClientsDemandBO);

                if (dsPopulateClientsDemand != null)
                {
                    if (dsPopulateClientsDemand.Tables.Count > 0)
                    {
                        if (dsPopulateClientsDemand.Tables[0].Rows.Count > 0)
                        {
                            int score = 0;

                            for (int i = 0; i < dsPopulateClientsDemand.Tables[0].Rows.Count; i++)
                            {
                                score += Convert.ToInt32(dsPopulateClientsDemand.Tables[0].Rows[i][2]);
                            }
                            txtClientPresenceScale.Text = score.ToString();
                        }
                        else
                            txtClientPresenceScale.Text = "0";
                    }
                    else
                        txtClientPresenceScale.Text = "0";

                }
                else
                    txtClientPresenceScale.Text = "0";

                //Syntel Business Priority scale score
                QualificationDetailsBO clsQuaDetailsSyntelBusinessBO = new QualificationDetailsBO();
                clsQuaDetailsSyntelBusinessBO.OppNumber = (string)Session["Oppid"];
                clsQuaDetailsSyntelBusinessBO.ParaID = Constants._intInitialRevenueParaID;
                DataSet dsPopulateSyntelBusiness = new BLL.ScoreOppQuaBLL().GetScoreDescriptionForParameterScreen1(clsQuaDetailsSyntelBusinessBO);

                if (dsPopulateSyntelBusiness != null)
                {
                    if (dsPopulateSyntelBusiness.Tables.Count > 0)
                    {
                        if (dsPopulateSyntelBusiness.Tables[0].Rows.Count > 0)
                        {
                            int score = 0;

                            for (int i = 0; i < dsPopulateSyntelBusiness.Tables[0].Rows.Count; i++)
                            {
                                score += Convert.ToInt32(dsPopulateSyntelBusiness.Tables[0].Rows[i][2]);
                            }
                            txtBusinessPriority.Text = score.ToString();
                        }
                        else
                            txtBusinessPriority.Text = "0";
                    }
                    else
                        txtBusinessPriority.Text = "0";

                }
                else
                    txtBusinessPriority.Text = "0";

                //Clients urgency score
                QualificationDetailsBO clsQuaDetailsClientUrgencyBO = new QualificationDetailsBO();
                clsQuaDetailsClientUrgencyBO.OppNumber = (string)Session["Oppid"];
                clsQuaDetailsClientUrgencyBO.ParaID = Constants._intHowMuchParaID;
                DataSet dsPopulateClientsUrgency = new BLL.ScoreOppQuaBLL().GetScoreDescriptionForParameterScreen1(clsQuaDetailsClientUrgencyBO);

                if (dsPopulateClientsUrgency != null)
                {
                    if (dsPopulateClientsUrgency.Tables.Count > 0)
                    {
                        if (dsPopulateClientsUrgency.Tables[0].Rows.Count > 0)
                        {
                            int score = 0;

                            for (int i = 0; i < dsPopulateClientsUrgency.Tables[0].Rows.Count; i++)
                            {
                                score += Convert.ToInt32(dsPopulateClientsUrgency.Tables[0].Rows[i][2]);
                            }
                            txtUrgencybuy.Text = score.ToString();
                        }
                        else
                            txtUrgencybuy.Text = "0";
                    }
                    else
                        txtUrgencybuy.Text = "0";

                }
                else
                    txtUrgencybuy.Text = "0";

                //Syntel Competitive score
                QualificationDetailsBO clsQuaDetailsSyntelsCompetitiveBO = new QualificationDetailsBO();
                clsQuaDetailsSyntelsCompetitiveBO.OppNumber = (string)Session["Oppid"];
                clsQuaDetailsSyntelsCompetitiveBO.ParaID = Constants._intSolutionAdvantageParaID;
                DataSet dsPopulateSyntelCompetitive = new BLL.ScoreOppQuaBLL().GetScoreDescriptionForParameterScreen1(clsQuaDetailsSyntelsCompetitiveBO);

                if (dsPopulateSyntelCompetitive != null)
                {
                    if (dsPopulateSyntelCompetitive.Tables.Count > 0)
                    {
                        if (dsPopulateSyntelCompetitive.Tables[0].Rows.Count > 0)
                        {
                            int score = 0;

                            for (int i = 0; i < dsPopulateSyntelCompetitive.Tables[0].Rows.Count; i++)
                            {
                                score += Convert.ToInt32(dsPopulateSyntelCompetitive.Tables[0].Rows[i][2]);
                            }
                            txtCompetiiveAdvantage.Text = score.ToString();
                        }
                        else
                            txtCompetiiveAdvantage.Text = "0";
                    }
                    else
                        txtCompetiiveAdvantage.Text = "0";

                }
                else
                    txtCompetiiveAdvantage.Text = "0";

                txttotalSummary.Text = (Convert.ToInt32(txtClientPresenceScale.Text) + Convert.ToInt32(txtBusinessPriority.Text)
                                         + Convert.ToInt32(txtUrgencybuy.Text) + Convert.ToInt32(txtCompetiiveAdvantage.Text)).ToString();

                lblOpportunityScalePercenatge.Text = (Math.Round(((100 * Convert.ToDecimal(txttotalSummary.Text)) / (Convert.ToDecimal(lbltotal.Text))))).ToString();

               
            }
            catch (Exception ex)
            {
                string _strErrorMessage = string.Format("{0}", ex.Message.ToString());

                var cleanChars = _strErrorMessage.Where(c => !"\n\r".Contains(c));
                string cleanText = new string(cleanChars.ToArray());

                Response.Redirect("/frmErrorPage.aspx?ErrorMessage=" + cleanText);
            }
        }

        private void DisplayDescriptiononScore()
        {
            try
            {
                List<ScoreOppQuaBO> lstScoreOppQuaBO = new List<ScoreOppQuaBO>();
                DataSet dsPopulateActiveScoreScaleGridview = new BLL.ScoreOppQuaBLL().GetScoreOppQuaByActiveMainScreen();
                if (dsPopulateActiveScoreScaleGridview.Tables.Count > 0)
                {
                    if (dsPopulateActiveScoreScaleGridview.Tables[0].Rows.Count > 0)
                    {
                        int _intRowCount = dsPopulateActiveScoreScaleGridview.Tables[0].Rows.Count;
                        for (int i = 0; i < _intRowCount; i++)
                        {
                            ScoreOppQuaBO clsScoreOppQuaBO = new ScoreOppQuaBO();
                            clsScoreOppQuaBO.Scale = dsPopulateActiveScoreScaleGridview.Tables[0].Rows[i][0].ToString();
                            clsScoreOppQuaBO.Scale_Description = dsPopulateActiveScoreScaleGridview.Tables[0].Rows[i][1].ToString();
                            lstScoreOppQuaBO.Add(clsScoreOppQuaBO);
                        }
                    }
                }

                int _intCurrentPercent = Convert.ToInt32(lblOpportunityScalePercenatge.Text);
                foreach (ScoreOppQuaBO clsScoreOppQuaBO in lstScoreOppQuaBO)
                {
                    if (clsScoreOppQuaBO.Scale.Contains(">="))
                    {
                        string[] _strArrNumber = clsScoreOppQuaBO.Scale.Split(new[] { '>','=','%' });
                        int _intMaxPercent = Convert.ToInt32(_strArrNumber[2]);
                        if (_intCurrentPercent >= _intMaxPercent)
                        {
                            lblProbability.Text = clsScoreOppQuaBO.Scale_Description;
                            lblProbability.ForeColor = Color.Green;
                        }
                    }

                    if (clsScoreOppQuaBO.Scale.Contains("-"))
                    {
                        string[] _strArrNumber = clsScoreOppQuaBO.Scale.Split(new[] { '-', '%' });
                        int _intMinPercent = Convert.ToInt32(_strArrNumber[0]);
                        int _intMaxPercent = Convert.ToInt32(_strArrNumber[1]);
                        if (_intCurrentPercent <= _intMaxPercent)
                        {
                            if (_intCurrentPercent >= _intMinPercent)
                            {
                                lblProbability.Text = clsScoreOppQuaBO.Scale_Description;
                                lblProbability.ForeColor = Color.Orange;
                            }
                        }
                    }

                    if (clsScoreOppQuaBO.Scale.Contains("<="))
                    {
                        string[] _strArrNumber = clsScoreOppQuaBO.Scale.Split(new[] { '<','=','%' });
                        int _intMinPercent = Convert.ToInt32(_strArrNumber[2]);
                        if (_intCurrentPercent <= _intMinPercent)
                        {
                            lblProbability.Text = clsScoreOppQuaBO.Scale_Description;
                            lblProbability.ForeColor = Color.Red;
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
       
        private void PopulateActiveScoreScaleGridview()
        {

            try
            {
                DataSet dsPopulateActiveScoreScaleGridview = new BLL.ScoreOppQuaBLL().GetScoreOppQuaByActiveMainScreen();
                if (dsPopulateActiveScoreScaleGridview.Tables.Count > 0)
                {
                    if (dsPopulateActiveScoreScaleGridview.Tables[0].Rows.Count > 0)
                    {
                        gvScaleScore.DataSource = dsPopulateActiveScoreScaleGridview;
                        gvScaleScore.DataBind();
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

        private void PopulateDropDownList()
        {
            try
            {
                ScoreOppQuaBLL clsScoreOppQuaBll = new ScoreOppQuaBLL();
                DataSet dsPopulateStatusDropDownList = new DataSet();
                dsPopulateStatusDropDownList = (DataSet)clsScoreOppQuaBll.GetStatusForOppQua();

                if (dsPopulateStatusDropDownList.Tables.Count > 0)
                {
                    if (dsPopulateStatusDropDownList.Tables[0].Rows.Count > 0)
                    {
                        ddlApproveReject.DataSource = dsPopulateStatusDropDownList.Tables[0];
                        ddlApproveReject.DataTextField = "vsStatus";
                        ddlApproveReject.DataValueField = "IpkStatusId";
                        ddlApproveReject.DataBind();
                    }

                }

                DataSet dsPopulateDealTypeDropDownList = new DataSet();
                dsPopulateDealTypeDropDownList = (DataSet)clsScoreOppQuaBll.GetDealTypeForOppQua();
                if (dsPopulateDealTypeDropDownList.Tables.Count > 0)
                {
                    if (dsPopulateDealTypeDropDownList.Tables[0].Rows.Count > 0)
                    {
                        ddlLargeDeal.DataSource = dsPopulateDealTypeDropDownList.Tables[0];
                        ddlLargeDeal.DataTextField = "vsDealType";
                        ddlLargeDeal.DataValueField = "lpkDealId";
                        ddlLargeDeal.DataBind();
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

        private void GetScoreDescription()
        {
            OpportunityQualificationScoresBO clsOpportunityQualificationClientDemandsScoresBO = new OpportunityQualificationScoresBO();
            clsOpportunityQualificationClientDemandsScoresBO.ScreensName = lnkClientPresenceScale.Text;
            clsOpportunityQualificationClientDemandsScoresBO.OppQuaScore = Convert.ToInt32(txtClientPresenceScale.Text);
            clsOpportunityQualificationClientDemandsScoresBO.Outof = Convert.ToInt32(lblClientPresenceScale.Text);
          
            OpportunityQualificationScoresBO clsOpportunityQualificationScoresSyntelBusinessBO = new OpportunityQualificationScoresBO();
            clsOpportunityQualificationScoresSyntelBusinessBO.ScreensName = lnkBusinessPriority.Text;
            clsOpportunityQualificationScoresSyntelBusinessBO.OppQuaScore = Convert.ToInt32(txtBusinessPriority.Text);
            clsOpportunityQualificationScoresSyntelBusinessBO.Outof = Convert.ToInt32(lblBusinessPriority.Text);
          
            OpportunityQualificationScoresBO clsOpportunityQualificationClientsUrgencyScoresBO = new OpportunityQualificationScoresBO();
            clsOpportunityQualificationClientsUrgencyScoresBO.ScreensName = lnkUrgencyBuy.Text;
            clsOpportunityQualificationClientsUrgencyScoresBO.OppQuaScore = Convert.ToInt32(txtUrgencybuy.Text);
            clsOpportunityQualificationClientsUrgencyScoresBO.Outof = Convert.ToInt32(lblUrgencyBuyTotalScore.Text);
          
            OpportunityQualificationScoresBO clsOpportunityQualificationSyntelCompetitiveScoresBO = new OpportunityQualificationScoresBO();
            clsOpportunityQualificationSyntelCompetitiveScoresBO.ScreensName = lnkCompetitiveAdvantage.Text;
            clsOpportunityQualificationSyntelCompetitiveScoresBO.OppQuaScore = Convert.ToInt32(txtCompetiiveAdvantage.Text);
            clsOpportunityQualificationSyntelCompetitiveScoresBO.Outof = Convert.ToInt32(lblCompAdvanTotalScore.Text);
          
            OpportunityQualificationScoresBO clsOpportunityQualificationSummaryScoresBO = new OpportunityQualificationScoresBO();
            clsOpportunityQualificationSummaryScoresBO.ScreensName = "Total Summary Score:";
            clsOpportunityQualificationSummaryScoresBO.OppQuaScore = Convert.ToInt32(txttotalSummary.Text);
            clsOpportunityQualificationSummaryScoresBO.Outof = Convert.ToInt32(lbltotal.Text);
          
            List<OpportunityQualificationScoresBO> lstOppQuaScores = new List<OpportunityQualificationScoresBO>();
            lstOppQuaScores.Add(clsOpportunityQualificationClientDemandsScoresBO);
            lstOppQuaScores.Add(clsOpportunityQualificationScoresSyntelBusinessBO);
            lstOppQuaScores.Add(clsOpportunityQualificationClientsUrgencyScoresBO);
            lstOppQuaScores.Add(clsOpportunityQualificationSyntelCompetitiveScoresBO);
            lstOppQuaScores.Add(clsOpportunityQualificationSummaryScoresBO);
          
            Session["OppQuaAllScreenScores"] = lstOppQuaScores;
        }

        private void GetStakeholdertoNotifyStatusbyBUHead()
        {
            try
            {
               
            string _strBUHeadEmail = string.Empty;
            string _strSaleEmail = string.Empty;
            string _strDeliveryEmail = string.Empty;
            string _strBidMnagerEmail = string.Empty;
            string _strSaleName = string.Empty;
            string _strDeliveryName = string.Empty;
            string _strBUHeadName = string.Empty;
            string _strStatus = string.Empty;
            string _strComments = string.Empty;
            string _strBidCoordinator = string.Empty;
            string _strOppNumber = (string)Session["Oppid"];

            //Call method to execute Stored procedure
           
                DataSet dsetStakeHoldersDetails = new BLL.AutomatedMailBLL().getStakeholdersOppStatusbyBUHead((string)Session["Oppid"]);

                if (dsetStakeHoldersDetails.Tables.Count > 0)
                {
                    if (dsetStakeHoldersDetails.Tables[2].Rows.Count > 0)
                    {
                        _strDeliveryName = dsetStakeHoldersDetails.Tables[2].Rows[0][0].ToString();
                        _strDeliveryEmail = dsetStakeHoldersDetails.Tables[2].Rows[0][1].ToString();
                    }
                    else if (dsetStakeHoldersDetails.Tables[1].Rows.Count > 0)
                    {
                        _strDeliveryName = dsetStakeHoldersDetails.Tables[1].Rows[0][0].ToString();
                        _strDeliveryEmail = dsetStakeHoldersDetails.Tables[1].Rows[0][1].ToString();
                    }
                    else if (dsetStakeHoldersDetails.Tables[0].Rows.Count > 0)
                    {
                        _strDeliveryName = dsetStakeHoldersDetails.Tables[0].Rows[0][0].ToString();
                        _strDeliveryEmail = dsetStakeHoldersDetails.Tables[0].Rows[0][1].ToString();
                    }

                    if (dsetStakeHoldersDetails.Tables[3].Rows.Count > 0)
                    {
                        _strBUHeadEmail = dsetStakeHoldersDetails.Tables[3].Rows[0][1].ToString();
                        _strBUHeadName = dsetStakeHoldersDetails.Tables[3].Rows[0][0].ToString();
                    }

                    if (dsetStakeHoldersDetails.Tables[4].Rows.Count > 0)
                    {
                        _strBidMnagerEmail = dsetStakeHoldersDetails.Tables[4].Rows[0][1].ToString();
                    }
                    if (dsetStakeHoldersDetails.Tables[5].Rows.Count > 0)
                    {
                        _strSaleName = dsetStakeHoldersDetails.Tables[5].Rows[0][0].ToString();
                        _strSaleEmail = dsetStakeHoldersDetails.Tables[5].Rows[0][1].ToString();
                    }
                    if (dsetStakeHoldersDetails.Tables[6].Rows.Count > 0)
                    {
                        _strStatus = dsetStakeHoldersDetails.Tables[6].Rows[0][0].ToString();

                        if (string.IsNullOrEmpty(dsetStakeHoldersDetails.Tables[6].Rows[0][1].ToString()))
                        {
                            _strComments = "-";
                        }
                        else
                        {
                            _strComments = dsetStakeHoldersDetails.Tables[6].Rows[0][1].ToString();
                        }
                    }
                    if (dsetStakeHoldersDetails.Tables[7].Rows.Count > 0)
                    {
                        _strBidCoordinator = dsetStakeHoldersDetails.Tables[7].Rows[0][1].ToString();
                    }
                }

              
                string EmailBody = "<html><body><div style='border:1px solid black;padding:10px;font-family:arial'> Team, ";
                EmailBody += "</br>";
                EmailBody += "</br>";
                if (_strStatus == "Approved")
                {
                    EmailBody += "<p>Opportunity number " + _strOppNumber + " is approved by " + _strBUHeadName + ".</br>Comments : " + _strComments + " </p> ";
                }
                else if (_strStatus == "Not Approved")
                {
                    EmailBody += "<p>Opportunity number " + _strOppNumber + " is not approved by " + _strBUHeadName + ".Comments : " + _strComments + " </p> ";
                }
                else if (_strStatus == "No Go")
                {
                    EmailBody += "<p>Opportunity number " + _strOppNumber + " is No Go by " + _strBUHeadName + ".</br>Comments : " + _strComments + " </p> ";
                }
                EmailBody += "</br>";
                EmailBody += "To Access the LDF Application Please Click on Link below";
                EmailBody += "</br>";
                EmailBody += "</br>";
                EmailBody += "</br>";
                EmailBody += "Thanks,";
                EmailBody += "</br>";
                EmailBody += "LDF Team";
                EmailBody += "</br>";
                EmailBody += "</br>";
                EmailBody += "[Note: This is an system generated email. Please do not reply]";
                EmailBody += "</br>";
                EmailBody += "-------------------------------------------------------------- </div></body></html>";

                var fromAddress = new MailAddress(System.Web.Configuration.WebConfigurationManager.AppSettings["EmailFrom"],
                "Large Deal Framework");
                MailMessage myhtmlMessage = new MailMessage(fromAddress.ToString(), _strSaleEmail, "Automated Mail for Status of Opportunity", EmailBody);
                myhtmlMessage.IsBodyHtml = true;
                myhtmlMessage.To.Add(_strDeliveryEmail);
                myhtmlMessage.CC.Add(_strBidMnagerEmail);
                myhtmlMessage.CC.Add(_strBidCoordinator);
                myhtmlMessage.CC.Add(_strBUHeadEmail);
                //string _strEmailServer = "cas2.syntelorg.com";

                string username = System.Web.Configuration.WebConfigurationManager.AppSettings["username"].ToString();
                string Password = System.Web.Configuration.WebConfigurationManager.AppSettings["Password"];

                 string Host = System.Web.Configuration.WebConfigurationManager.AppSettings["SMTPSERVER"];
                 int Port = Convert.ToInt32(System.Web.Configuration.WebConfigurationManager.AppSettings["Port"]);

                 SmtpClient mysmtpclient = new SmtpClient(Host, Port);
                mysmtpclient.EnableSsl = true;
                System.Net.NetworkCredential crediantials = new NetworkCredential(username, Password);
                mysmtpclient.UseDefaultCredentials = false;
                mysmtpclient.Credentials = crediantials;
                mysmtpclient.Send(myhtmlMessage);

            }

            catch (Exception ex)
            {
                string _strErrorMessage = string.Format("{0}", ex.Message.ToString());

                var cleanChars = _strErrorMessage.Where(c => !"\n\r".Contains(c));
                string cleanText = new string(cleanChars.ToArray());

                Response.Redirect("/frmErrorPage.aspx?ErrorMessage=" + cleanText);
            }
        }


        private void AddOpportunitytoClosed(OpportunityQualificationBO opportunityQualificationBO)
        {
            DataSet dsAddOpp = new BLL.ScoreOppQuaBLL().InsertDeleteOpportunity(opportunityQualificationBO);
            ScoreOppQuaBLL scoreOppQuaBLL = new ScoreOppQuaBLL();
            scoreOppQuaBLL.InsertUpdateOpportunitytoClose(opportunityQualificationBO.OppNumber);
        }

        #endregion

        #region Events for controls
        protected void lnkClientPresenceScale_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmClientsDemandPresenceScale.aspx");
        }

        protected void lnkBusinessPriority_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmSyntelBusinessPriorityScale.aspx");
        }

        protected void lnkUrgencyBuy_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmClientsUrgencytoBuy.aspx");
        }

        protected void lnkCompetitiveAdvantage_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmSyntelsCompetitiveAdvantage.aspx");
        }

       
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                lblmsg.Text = string.Empty;
                if (ddlApproveReject.SelectedItem.Text == "Select" || ddlLargeDeal.SelectedItem.Text == "Select" || txtComments.Text == string.Empty)
                {

                    if (ddlApproveReject.SelectedItem.Text == "Select")
                    {
                        lblmsg.Text = "Please select Status";
                    }
                    if (ddlLargeDeal.SelectedItem.Text == "Select")
                    {
                        if (lblmsg.Text != string.Empty)
                        {
                            lblmsg.Text = lblmsg.Text + "</br>" + "Please select Deal Type";
                        }
                        else
                            lblmsg.Text = "Please select Deal Type";
                    }
                    if ((ddlApproveReject.SelectedItem.Text == "No Go" || ddlApproveReject.SelectedItem.Text == "Not Approved") && txtComments.Text == string.Empty)
                    {
                        if (lblmsg.Text != string.Empty)
                        {
                            lblmsg.Text = lblmsg.Text + "</br>" + "Please enter Comments";
                        }
                        else
                            lblmsg.Text = "Please enter Comments";

                    }
                }
                else
                {
                    try
                    {
                        ScoreOppQuaBLL clsScoreOppQuaBLL = new ScoreOppQuaBLL();
                        OpportunityQualificationBO clsOpportunityQualificationBO = new OpportunityQualificationBO();
                        clsOpportunityQualificationBO.OppNumber = (string)Session["Oppid"];
                        clsOpportunityQualificationBO.TotalSummaryScore = Convert.ToInt32(txttotalSummary.Text);
                        clsOpportunityQualificationBO.Percentage = Convert.ToInt32(lblOpportunityScalePercenatge.Text);
                        clsOpportunityQualificationBO.Status = ddlApproveReject.SelectedItem.Text;
                        clsOpportunityQualificationBO.DealType = ddlLargeDeal.SelectedItem.Text;
                        clsOpportunityQualificationBO.DescriptionScoreScale = lblProbability.Text;
                        clsOpportunityQualificationBO.BuHead = Session["FirstName"].ToString();
                        clsOpportunityQualificationBO.Comments = txtComments.Text;
                        clsScoreOppQuaBLL.AddOpportunityQualificationDetails(clsOpportunityQualificationBO);
                        lblmsg.Text = "Submitted Sucessfully!!!";
                        lblmsg.ForeColor = System.Drawing.Color.Green;

                        tblStatusDealType.Visible = true;

                        DataSet dsGetOppDetails = new DataSet();
                        string _strOppNumber = (string)Session["Oppid"];
                        dsGetOppDetails = clsScoreOppQuaBLL.GetOpportunityQualificationDetails(_strOppNumber);

                        if (dsGetOppDetails.Tables.Count > 0)
                        {
                            if (dsGetOppDetails.Tables[0].Rows.Count > 0)
                            {
                                lblBUHead.Text = dsGetOppDetails.Tables[0].Rows[0][6].ToString();
                                lblStatusbyBUHead.Text = dsGetOppDetails.Tables[0].Rows[0][4].ToString();
                                lblDealTypebyBUHead.Text = dsGetOppDetails.Tables[0].Rows[0][5].ToString();

                            }
                        }

                        //Status NO GO move opportunity to close opportunity
                        if (ddlApproveReject.SelectedItem.Text.Trim() == "No Go")
                        {
                            OpportunityQualificationBO opportunityQualificationBO = new OpportunityQualificationBO();
                            opportunityQualificationBO.OppNumber = (string)Session["Oppid"];
                            opportunityQualificationBO.Status = ddlApproveReject.SelectedItem.Text;
                            opportunityQualificationBO.Comments = txtComments.Text;
                            opportunityQualificationBO.OppDescription = string.Empty;
                            AddOpportunitytoClosed(opportunityQualificationBO);
                        }
                        tblStatus.Visible = false;
                        btnSubmit.Visible = false;

                        GetStakeholdertoNotifyStatusbyBUHead();
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
