
/* ---------------------------------------------------------------------------------------------------------------
 * Project Name : Large Deal Type
 * Module Name : Bid Winability
 * Program Version : 1.0.0
 * Filename : FrmBidWinability.aspx.cs
 * Purpose : This page allows to enter Uniqueness score and Innovation score. This page displays graph for all scores
 *           and calculate Bid Win Score.
 * ----------------------------------------------------------------------------------------------------------------
 * MODIFICATION HISTORY:
 * ----------------------------------------------------------------------------------------------------------------
 * PHASE    AUTHOR                 DATE          MODIFICATION           DESCRIPTION
 *                              (MM/DD/YYYY)     DETAILS
 * ----------------------------------------------------------------------------------------------------------------
 *   1.    PRIYANKA DATIR        01/27/2014      CREATED                NONE  
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BO;
using System.Data;
using System.Web.UI.DataVisualization.Charting;
using System.Net.Mail;
using System.Net;
using BLL;

namespace LargeDealFrameWork
{
    public partial class BidWinability : System.Web.UI.Page
    {
        int _intDesignation = 0;
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Request.QueryString["OppID"] != null)
            {
                Session["Oppid"] = Request.QueryString["OppID"];
               
            }

            if (Session["Designation"] != null)
            {
                _intDesignation = Convert.ToInt32(Session["Designation"]);
            }
            if (!IsPostBack)
            {
                try
                {
                    string _stroppid = (string)Session["Oppid"];
                    txtOppID.Text = _stroppid;
                    ParamcolumnsBO finalsend = new ParamcolumnsBO();
                    finalsend.OppId = _stroppid;
                    txtOppDesc.Text = new BLL.RGYBLL().retrieveoppname(finalsend);
                    DisableControlsbyDesignation();
                    PopulateOppQuaGrid();
                    PopulateRGYChecklistGridview();
                    PopulateInnovationUniquenessScore();
                    CalculatePercentOpportunityQualification();
                    PopulateActiveScoreScaleGridview();
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

        #region Private method

        private void PopulateInnovationUniquenessScore()
        {
            string _strOppID = (string)Session["Oppid"];
            DataSet dsPopulateScore = new BLL.BidWinabilityBLL().GetBidWinabilityScoreStatus(_strOppID);

            if (dsPopulateScore.Tables.Count > 0)
            {
                if (dsPopulateScore.Tables[0].Rows.Count > 0)
                {
                    if (dsPopulateScore.Tables[0].Rows[0][1].ToString().Trim() != "Null")
                        lblScore3.Text = dsPopulateScore.Tables[0].Rows[0][1].ToString();

                    if (dsPopulateScore.Tables[0].Rows[0][2].ToString().Trim() != "Null")
                        lblScore4.Text = dsPopulateScore.Tables[0].Rows[0][2].ToString();

                    if (dsPopulateScore.Tables[0].Rows[0][3].ToString().Trim() == "True")
                    {
                        btnLowA.Enabled = false;
                        btnLowC.Enabled = false;
                        btnHighB.Enabled = false;
                        btnHighD.Enabled = false;
                    }

                    if (dsPopulateScore.Tables[0].Rows[0][4].ToString().Trim() == "True")
                    {

                        btnLowOppQuaC.Enabled = false;
                        btnLowOppQuaA.Enabled = false;
                        btnHighOppQuaB.Enabled = false;
                        btnHighOppQuaD.Enabled = false;
                    }

                    if ((dsPopulateScore.Tables[0].Rows[0][3].ToString().Trim() == "True") && (dsPopulateScore.Tables[0].Rows[0][4].ToString().Trim() == "True"))
                    {
                        btnSubmit.Visible = false;
                    }

                    if (dsPopulateScore.Tables[0].Rows[0][5].ToString().Trim() == "Approved")
                    {
                        btnApprove.Visible = false;
                        btnReject.Visible = false;
                    }
                    else if (dsPopulateScore.Tables[0].Rows[0][5].ToString().Trim() == "Rejected" || dsPopulateScore.Tables[0].Rows[0][5].ToString().Trim() == "Pending")
                    {
                        DisableControlsbyDesignation();
                    }
                }
            }

            //string[] _strArrDesignation = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13" };

            //if (_strArrDesignation.Contains(Convert.ToString(_intDesignation)))
            //{
            //    if (!string.IsNullOrEmpty(lblScore3.Text) && !string.IsNullOrEmpty(lblScore4.Text))
            //    {
            //        btnShow.Visible = true;
            //    }
            //}


        }

        private void DisableControlsbyDesignation()
        {
            string strOppID = (string)Session["Oppid"];
            DataSet dsPopulateScore = new BLL.BidWinabilityBLL().GetBidWinabilityScoreStatus(strOppID);

            if (dsPopulateScore.Tables.Count > 0)
            {
                if (dsPopulateScore.Tables[0].Rows.Count > 0)
                {
                    if (dsPopulateScore.Tables[0].Rows[0][5].ToString().Trim() == "Pending")
                    {
                        if (_intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.BidManager))
                        {
                            btnLowOppQuaC.Enabled = true;
                            btnLowOppQuaA.Enabled = true;
                            btnHighOppQuaB.Enabled = true;
                            btnHighOppQuaD.Enabled = true;
                            btnSubmit.Visible = true;
                            if (dsPopulateScore.Tables[0].Rows[0][4].ToString().Trim() == "True")
                            {
                                btnLowOppQuaC.Enabled = false;
                                btnLowOppQuaA.Enabled = false;
                                btnHighOppQuaB.Enabled = false;
                                btnHighOppQuaD.Enabled = false;
                                btnSubmit.Visible = false;
                            }

                        }

                        if (_intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.BUHead))
                        {
                            btnLowA.Enabled = true;
                            btnLowC.Enabled = true;
                            btnHighB.Enabled = true;
                            btnHighD.Enabled = true;
                            btnSubmit.Visible = true;
                            if (dsPopulateScore.Tables[0].Rows[0][3].ToString().Trim() == "True")
                            {
                                btnLowA.Enabled = false;
                                btnLowC.Enabled = false;
                                btnHighB.Enabled = false;
                                btnHighD.Enabled = false;
                                btnSubmit.Visible = false;
                            }

                        }

                    }

                    if (dsPopulateScore.Tables[0].Rows[0][5].ToString().Trim() == "Rejected")
                    {
                        if (_intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.BidManager))
                        {
                            btnLowOppQuaC.Enabled = true;
                            btnLowOppQuaA.Enabled = true;
                            btnHighOppQuaB.Enabled = true;
                            btnHighOppQuaD.Enabled = true;
                            btnSubmit.Visible = true;
                            if (dsPopulateScore.Tables[0].Rows[0][4].ToString().Trim() == "True")
                            {
                                btnLowOppQuaC.Enabled = false;
                                btnLowOppQuaA.Enabled = false;
                                btnHighOppQuaB.Enabled = false;
                                btnHighOppQuaD.Enabled = false;
                                btnSubmit.Visible = false;
                            }
                        }

                        if (_intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.BUHead))
                        {
                            btnLowA.Enabled = true;
                            btnLowC.Enabled = true;
                            btnHighB.Enabled = true;
                            btnHighD.Enabled = true;
                            btnSubmit.Visible = true;
                            if (dsPopulateScore.Tables[0].Rows[0][3].ToString().Trim() == "True")
                            {
                                btnLowOppQuaC.Enabled = false;
                                btnLowOppQuaA.Enabled = false;
                                btnHighOppQuaB.Enabled = false;
                                btnHighOppQuaD.Enabled = false;
                                btnSubmit.Visible = false;
                            }
                        }
                    }

                    if ((dsPopulateScore.Tables[0].Rows[0][3].ToString().Trim() == "True") && (dsPopulateScore.Tables[0].Rows[0][4].ToString().Trim() == "True"))
                    {
                        btnSubmit.Visible = false;

                        if (_intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.GPTHead) || _intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.GPTMember))
                        {
                            btnApprove.Visible = true;
                            btnReject.Visible = true;
                            btnShow.Visible = true;
                        }
                    }

                    if (dsPopulateScore.Tables[0].Rows[0][5].ToString().Trim() == "Approved")
                    {
                        btnShow.Visible = true;
                    }
                }

            }
            else
            {
                BidWinabilityBO clsBidWinabilityBO = new BidWinabilityBO();
                clsBidWinabilityBO.OppID = strOppID;
                clsBidWinabilityBO.Status = "Pending";
                bool val = new BLL.BidWinabilityBLL().AddUpdateBidWinabilityScoreStatus(clsBidWinabilityBO);
                if (_intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.BidManager))
                {
                    btnLowOppQuaC.Enabled = true;
                    btnLowOppQuaA.Enabled = true;
                    btnHighOppQuaB.Enabled = true;
                    btnHighOppQuaD.Enabled = true;
                    btnSubmit.Visible = true;
                }
                if (_intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.BUHead))
                {
                    btnLowA.Enabled = true;
                    btnLowC.Enabled = true;
                    btnHighB.Enabled = true;
                    btnHighD.Enabled = true;
                    btnSubmit.Visible = true;
                }
            }
        }

        private void PopulateOppQuaGrid()
        {
            if (Session["OppQuaAllScreenScores"] != null)
            {
                List<OpportunityQualificationScoresBO> lstOppQuaScore = new List<OpportunityQualificationScoresBO>();
                lstOppQuaScore = (List<OpportunityQualificationScoresBO>)Session["OppQuaAllScreenScores"];

                OpportunityQualificationScoresBO opportunityQualificationScoresBO = new OpportunityQualificationScoresBO();
                opportunityQualificationScoresBO = lstOppQuaScore[0];

                lblCrit1.Text = opportunityQualificationScoresBO.ScreensName;
                lblPer1.Text = opportunityQualificationScoresBO.OppQuaScore.ToString();
                lblOut1.Text = opportunityQualificationScoresBO.Outof.ToString();

                int _intLblOutA = Convert.ToInt32(lblOut1.Text);
                double _dblPercentageA = Math.Ceiling(Convert.ToDouble((_intLblOutA) * (0.6)));
                if (Convert.ToInt32(lblPer1.Text) < _dblPercentageA)
                {
                    lblPer1.BackColor = System.Drawing.Color.Red;
                }

                OpportunityQualificationScoresBO opportunityQualificationScoresBO1 = new OpportunityQualificationScoresBO();
                opportunityQualificationScoresBO1 = lstOppQuaScore[1];

                lblCrit2.Text = opportunityQualificationScoresBO1.ScreensName;
                lblPer2.Text = opportunityQualificationScoresBO1.OppQuaScore.ToString();
                lblOut2.Text = opportunityQualificationScoresBO1.Outof.ToString();

                int _intLblOutB = Convert.ToInt32(lblOut2.Text);
                double _dblPercentageB = Math.Ceiling(Convert.ToDouble((_intLblOutB) * (0.6)));
                if (Convert.ToInt32(lblPer2.Text) < _dblPercentageB)
                {
                    lblPer2.BackColor = System.Drawing.Color.Red;
                }

                OpportunityQualificationScoresBO opportunityQualificationScoresBO2 = new OpportunityQualificationScoresBO();
                opportunityQualificationScoresBO2 = lstOppQuaScore[2];

                lblCrit3.Text = opportunityQualificationScoresBO2.ScreensName;
                lblPer3.Text = opportunityQualificationScoresBO2.OppQuaScore.ToString();
                lblOut3.Text = opportunityQualificationScoresBO2.Outof.ToString();

                int _intLblOutC = Convert.ToInt32(lblOut3.Text);
                double _dblPercentageC = Math.Ceiling(Convert.ToDouble((_intLblOutC) * (0.6)));
                if (Convert.ToInt32(lblPer3.Text) < _dblPercentageC)
                {
                    lblPer3.BackColor = System.Drawing.Color.Red;
                }

                OpportunityQualificationScoresBO opportunityQualificationScoresBO3 = new OpportunityQualificationScoresBO();
                opportunityQualificationScoresBO3 = lstOppQuaScore[3];

                lblCrit4.Text = opportunityQualificationScoresBO3.ScreensName;
                lblPer4.Text = opportunityQualificationScoresBO3.OppQuaScore.ToString();
                lblOut4.Text = opportunityQualificationScoresBO3.Outof.ToString();

                int _intLblOutD = Convert.ToInt32(lblOut4.Text);
                double _dblPercentageD = Math.Ceiling(Convert.ToDouble((_intLblOutD) * (0.6)));
                if (Convert.ToInt32(lblPer4.Text) < _dblPercentageD)
                {
                    lblPer4.BackColor = System.Drawing.Color.Red;
                }

                OpportunityQualificationScoresBO opportunityQualificationScoresBO4 = new OpportunityQualificationScoresBO();
                opportunityQualificationScoresBO4 = lstOppQuaScore[4];

                lblCrit5.Text = opportunityQualificationScoresBO4.ScreensName;
                lblPer5.Text = opportunityQualificationScoresBO4.OppQuaScore.ToString();
                lblOut5.Text = opportunityQualificationScoresBO4.Outof.ToString();
            }
            else
            {
                DataSet dsGetStatus = new BLL.ScoreOppQuaBLL().GetOpportunityQualificationDetails((string)Session["Oppid"]);
                if (dsGetStatus.Tables.Count > 0 && dsGetStatus.Tables[0].Rows.Count > 0)
                {
                    PopulateScoreforAllScreens();
                }

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
                            lblPer1.Text = score.ToString();

                           
                        }
                        else
                            lblPer1.Text = "0";
                        
                    }
                    else
                        lblPer1.Text = "0";
                   

                }
                else
                    lblPer1.Text = "0";
             

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
                            lblPer2.Text = score.ToString();

                            
                        }
                        else
                            lblPer2.Text = "0";
                       
                    }
                    else
                        lblPer2.Text = "0";
                    

                }
                else
                    lblPer2.Text = "0";

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
                            lblPer3.Text = score.ToString();

                           
                        }
                        else
                            lblPer3.Text = "0";
                       
                    }
                    else
                        lblPer3.Text = "0";
                  

                }
                else
                    lblPer3.Text = "0";

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
                            lblPer4.Text = score.ToString();

                          
                        }
                        else
                            lblPer4.Text = "0";
                       
                    }
                    else
                        lblPer4.Text = "0";

                }
                else
                    lblPer4.Text = "0";

                DataSet dsGetOutofScoreClientsDemand = new BLL.BidWinabilityBLL().GetOutofScoreKeyNameClientsDemand();
                if (dsGetOutofScoreClientsDemand.Tables.Count > 0 && dsGetOutofScoreClientsDemand.Tables[0].Rows.Count > 0)
                {
                    lblOut1.Text = dsGetOutofScoreClientsDemand.Tables[0].Rows[0][0].ToString();
                    lblCrit1.Text = dsGetOutofScoreClientsDemand.Tables[0].Rows[0][1].ToString();
                }
                DataSet dsGetOutofScoreClientsUrgency = new BLL.BidWinabilityBLL().GetOutofScoreKeyNameClientsUrgency();
                if (dsGetOutofScoreClientsUrgency.Tables.Count > 0 && dsGetOutofScoreClientsUrgency.Tables[0].Rows.Count > 0)
                {
                    lblOut3.Text = dsGetOutofScoreClientsUrgency.Tables[0].Rows[0][0].ToString();
                    lblCrit3.Text = dsGetOutofScoreClientsUrgency.Tables[0].Rows[0][1].ToString();
                }

                DataSet dsGetOutofScoreSyntelBus = new BLL.BidWinabilityBLL().GetOutofScoreKeyNameSyntelBusiness();
                if (dsGetOutofScoreSyntelBus.Tables.Count > 0 && dsGetOutofScoreSyntelBus.Tables[0].Rows.Count > 0)
                {
                    lblOut2.Text = dsGetOutofScoreSyntelBus.Tables[0].Rows[0][0].ToString();
                    lblCrit2.Text = dsGetOutofScoreSyntelBus.Tables[0].Rows[0][1].ToString();
                }
                DataSet dsGetOutofScoreSyntelCom = new BLL.BidWinabilityBLL().GetOutofScoreKeyNameSyntelCom();

                if (dsGetOutofScoreSyntelCom.Tables.Count > 0 && dsGetOutofScoreSyntelCom.Tables[0].Rows.Count > 0)
                {
                    lblOut4.Text = dsGetOutofScoreSyntelCom.Tables[0].Rows[0][0].ToString();
                    lblCrit4.Text = dsGetOutofScoreSyntelCom.Tables[0].Rows[0][1].ToString();
                }

                int _intLblOutA = Convert.ToInt32(lblOut1.Text);
                double _dblPercentageA = Math.Ceiling(Convert.ToDouble((_intLblOutA) * (0.6)));
                if (Convert.ToInt32(lblPer1.Text) < _dblPercentageA)
                {
                    lblPer1.BackColor = System.Drawing.Color.Red;
                }

                int _intLblOutB = Convert.ToInt32(lblOut2.Text);
                double _dblPercentageB = Math.Ceiling(Convert.ToDouble((_intLblOutB) * (0.6)));
                if (Convert.ToInt32(lblPer2.Text) < _dblPercentageB)
                {
                    lblPer2.BackColor = System.Drawing.Color.Red;
                }

                int _intLblOutC = Convert.ToInt32(lblOut3.Text);
                double _dblPercentageC = Math.Ceiling(Convert.ToDouble((_intLblOutC) * (0.6)));
                if (Convert.ToInt32(lblPer3.Text) < _dblPercentageC)
                {
                    lblPer3.BackColor = System.Drawing.Color.Red;
                }

                int _intLblOutD = Convert.ToInt32(lblOut4.Text);
                double _dblPercentageD = Math.Ceiling(Convert.ToDouble((_intLblOutD) * (0.6)));
                if (Convert.ToInt32(lblPer4.Text) < _dblPercentageD)
                {
                    lblPer4.BackColor = System.Drawing.Color.Red;
                }

                string totalSummary = (Convert.ToInt32(lblPer1.Text) + Convert.ToInt32(lblPer2.Text)
                                         + Convert.ToInt32(lblPer3.Text) + Convert.ToInt32(lblPer4.Text)).ToString();

                lblOut5.Text = (Convert.ToInt32(lblOut1.Text) + Convert.ToInt32(lblOut2.Text)
                                         + Convert.ToInt32(lblOut3.Text) + Convert.ToInt32(lblOut4.Text)).ToString();
                lblPer5.Text = totalSummary;

                lblCrit5.Text = "Total Summary Score";

            }
            catch (Exception ex)
            {
                string _strErrorMessage = string.Format("{0}", ex.Message.ToString());

                var cleanChars = _strErrorMessage.Where(c => !"\n\r".Contains(c));
                string cleanText = new string(cleanChars.ToArray());

                Response.Redirect("/frmErrorPage.aspx?ErrorMessage=" + cleanText);
            }
        }

        private void PopulateRGYChecklistGridview()
        {
            string _strOppid = (string)Session["Oppid"];
            DataSet dsGetRGYScores = (DataSet)new BLL.RGYBLL().retrieveparams(_strOppid);
            if (dsGetRGYScores.Tables.Count > 0)
            {
                if (dsGetRGYScores.Tables[0].Rows.Count > 0)
                {
                    lbl1.Text = dsGetRGYScores.Tables[0].Rows[0][3].ToString();

                    if (Convert.ToInt32(lbl1.Text) < 3)
                    {
                        lbl1.BackColor = System.Drawing.Color.Red;
                    }

                    lbl2.Text = dsGetRGYScores.Tables[0].Rows[0][4].ToString();

                    if (Convert.ToInt32(lbl2.Text) < 3)
                    {
                        lbl2.BackColor = System.Drawing.Color.Red;
                    }

                    lbl3.Text = dsGetRGYScores.Tables[0].Rows[0][5].ToString();

                    if (Convert.ToInt32(lbl3.Text) < 3)
                    {
                        lbl3.BackColor = System.Drawing.Color.Red;
                    }

                    lbl4.Text = dsGetRGYScores.Tables[0].Rows[0][6].ToString();
                    if (Convert.ToInt32(lbl4.Text) < 3)
                    {
                        lbl4.BackColor = System.Drawing.Color.Red;
                    }

                    lbl5.Text = dsGetRGYScores.Tables[0].Rows[0][7].ToString();

                    if (Convert.ToInt32(lbl5.Text) < 3)
                    {
                        lbl5.BackColor = System.Drawing.Color.Red;
                    }

                    lbl6.Text = dsGetRGYScores.Tables[0].Rows[0][8].ToString();

                    if (Convert.ToInt32(lbl6.Text) < 3)
                    {
                        lbl6.BackColor = System.Drawing.Color.Red;
                    }

                    lbl7.Text = dsGetRGYScores.Tables[0].Rows[0][9].ToString();

                    if (Convert.ToInt32(lbl7.Text) < 3)
                    {
                        lbl7.BackColor = System.Drawing.Color.Red;
                    }

                    lbl8.Text = dsGetRGYScores.Tables[0].Rows[0][10].ToString();

                    if (Convert.ToInt32(lbl8.Text) < 3)
                    {
                        lbl8.BackColor = System.Drawing.Color.Red;
                    }

                    lbl9.Text = dsGetRGYScores.Tables[0].Rows[0][11].ToString();

                    if (Convert.ToInt32(lbl9.Text) < 3)
                    {
                        lbl9.BackColor = System.Drawing.Color.Red;
                    }
                    //commented on 21 March 2014
                    lblTotalScore.Text = dsGetRGYScores.Tables[0].Rows[0][2].ToString() + "%";
                    //lblTotalScore.Text = dsGetRGYScores.Tables[0].Rows[0][2].ToString();
                }
            }


        }

        private void CalculatePercentOpportunityQualification()
        {
            int _intPercentOppQua = 0;

            if (!string.IsNullOrEmpty(lblPer5.Text) && !string.IsNullOrEmpty(lblOut5.Text))
            {
                _intPercentOppQua = Convert.ToInt32((Math.Round(((100 * Convert.ToDecimal(lblPer5.Text)) / (Convert.ToDecimal(lblOut5.Text))))));

                if (_intPercentOppQua < 60)
                {
                    btnHighOppQuaB.Enabled = false;
                    btnHighOppQuaD.Enabled = false;
                }
                else if (_intPercentOppQua >= 60)
                {
                    btnLowOppQuaA.Enabled = false;
                    btnLowOppQuaC.Enabled = false;
                }
            }
        }

        private void PopulateScoresforPanel()
        {
            //Opportunity Qualification Score
            lblOpportunityScore.Text = (Math.Round(((100 * Convert.ToDecimal(lblPer5.Text)) / (Convert.ToDecimal(lblOut5.Text))))).ToString();
            //lblOpportunityScore.Text = lblPer5.Text;
            //RGYChecklist score
            string score = lblTotalScore.Text.ToString().Split('%')[0];
            lblRGYScore.Text = score;

            //Uniqueness score
            DataSet dsUniqueness = new DataSet();
            dsUniqueness = new BLL.BidWinabilityBLL().GetScoreUniquenessonButtonClick(lblScore4.Text);

            if (dsUniqueness.Tables.Count > 0)
            {
                if (dsUniqueness.Tables[0].Rows.Count > 0)
                {
                    lblUniqueness.Text = dsUniqueness.Tables[0].Rows[0][1].ToString();
                }
            }

            //Innovation score
            DataSet dsInnovation = new DataSet();
            dsInnovation = new BLL.BidWinabilityBLL().GetScoreInnovationButtonClick(lblScore3.Text);

            if (dsInnovation.Tables.Count > 0)
            {
                if (dsInnovation.Tables[0].Rows.Count > 0)
                {
                    lblInnovation.Text = dsInnovation.Tables[0].Rows[0][1].ToString();
                }
            }

            //Bid Win Score
            DataSet dsGetWeightageforFormula = new DataSet();
            dsGetWeightageforFormula = new BLL.BidWinabilityBLL().GetWeightageforFormula();

            if (dsGetWeightageforFormula.Tables.Count > 0)
            {
                if (dsGetWeightageforFormula.Tables[0].Rows.Count > 0)
                {
                    double W1 = Convert.ToDouble(dsGetWeightageforFormula.Tables[0].Rows[0][1]);
                    double W2 = Convert.ToDouble(dsGetWeightageforFormula.Tables[0].Rows[1][1]);
                    double W3 = Convert.ToDouble(dsGetWeightageforFormula.Tables[0].Rows[2][1]);
                    double W4 = Convert.ToDouble(dsGetWeightageforFormula.Tables[0].Rows[3][1]);
                    string rgyscore = lblTotalScore.Text.ToString().Split('%')[0];
                    lblBidWinScore.Text = Math.Round((W1 * Convert.ToInt32(lblOpportunityScore.Text)) + (W2 * Convert.ToInt32(rgyscore)) + (W3 * Convert.ToInt32(lblUniqueness.Text)) + (W4 * Convert.ToInt32(lblInnovation.Text))).ToString();
                }
            }
        }

        private void SendAutomatedMailtoTopManagement()
        {

            //Local variables for Email
            string _strGPTManagerEmail = string.Empty;
            string _strBUHeadEmail = string.Empty;
            string _strBidMnagerEmail = string.Empty;
            string _strTopManagementEmail = string.Empty;
            string _strGPTManagerName = string.Empty;
            string _strOppNumber = (string)Session["Oppid"];



            DataSet dsetStakeholdersDetails = new BLL.BidWinabilityBLL().GetStakeHoldersBidWinability(_strOppNumber);
            if (dsetStakeholdersDetails.Tables.Count > 0)
            {
                if (dsetStakeholdersDetails.Tables[0].Rows.Count > 0)
                {
                    _strBUHeadEmail = dsetStakeholdersDetails.Tables[0].Rows[0][1].ToString();

                }
                if (dsetStakeholdersDetails.Tables[1].Rows.Count > 0)
                {
                    _strBidMnagerEmail = dsetStakeholdersDetails.Tables[1].Rows[0][1].ToString();
                }
                if (dsetStakeholdersDetails.Tables[2].Rows.Count > 0)
                {
                    _strGPTManagerName = dsetStakeholdersDetails.Tables[2].Rows[0][0].ToString();
                    _strGPTManagerEmail = dsetStakeholdersDetails.Tables[2].Rows[0][1].ToString();
                }
            }

            // string _strEmailServer = "cas2.syntelorg.com";
            string _strEmailBody = "<html><body><div style='border:1px solid black;padding:10px;font-family:arial'> Dear " + _strGPTManagerName + " ";
            _strEmailBody += "</br>";
            _strEmailBody += "</br>";
            _strEmailBody += "<p style='colr:red;'>Uniqueness and Innovation score in Bidwinability is submitted for Opportunity ID " + _strOppNumber + ". Please approve the Opportunity</p> ";
            _strEmailBody += "</br>";
            _strEmailBody += "To Access the LDF Application Please Click on Link below";
            _strEmailBody += "</br>";
            _strEmailBody += "</br>";
            _strEmailBody += "</br>";
            _strEmailBody += "Thanks,";
            _strEmailBody += "</br>";
            _strEmailBody += "LDF Team";
            _strEmailBody += "</br>";
            _strEmailBody += "</br>";
            _strEmailBody += "[Note: This is an system generated email. Please do not reply]";
            _strEmailBody += "</br>";
            _strEmailBody += "-------------------------------------------------------------- </div></body></html>";

            var fromAddress = new MailAddress(System.Web.Configuration.WebConfigurationManager.AppSettings["EmailFrom"],
                           "Large Deal Framework");

            MailMessage clsMailMessage = new MailMessage(fromAddress.ToString(), _strGPTManagerEmail, "Automated Mail for GPT manager Approval", _strEmailBody);
            clsMailMessage.IsBodyHtml = true;
            clsMailMessage.CC.Add(_strBidMnagerEmail);
            clsMailMessage.CC.Add(_strBUHeadEmail);
            //myhtmlMessage.CC.Add(strTopManagementEmail);

            string username = System.Web.Configuration.WebConfigurationManager.AppSettings["username"].ToString();
            string Password = System.Web.Configuration.WebConfigurationManager.AppSettings["Password"];

            string Host = System.Web.Configuration.WebConfigurationManager.AppSettings["SMTPSERVER"];
            int Port = Convert.ToInt32(System.Web.Configuration.WebConfigurationManager.AppSettings["Port"]);

            SmtpClient clsSMTPClient = new SmtpClient(Host, Port);
            clsSMTPClient.EnableSsl = true;
            System.Net.NetworkCredential crediantials = new NetworkCredential(username, Password);
            clsSMTPClient.UseDefaultCredentials = false;
            clsSMTPClient.Credentials = crediantials;
            //myhtmlMessage.Attachments.Add(myAttachment);
            clsSMTPClient.Send(clsMailMessage);

        }


        private void SendAutomatedMailOpportunityRejection()
        {
            //Local variables for Email
            string _strGPTManagerEmail = string.Empty;
            string _strBUHeadEmail = string.Empty;
            string _strBidMnagerEmail = string.Empty;
            string _strGPTManagerName = string.Empty;
            string _strOppNumber = (string)Session["Oppid"];

            DataSet dsetStakeholdersDetails = new BLL.BidWinabilityBLL().GetStakeHoldersBidWinability(_strOppNumber);
            if (dsetStakeholdersDetails.Tables.Count > 0)
            {
                if (dsetStakeholdersDetails.Tables[0].Rows.Count > 0)
                {
                    _strBUHeadEmail = dsetStakeholdersDetails.Tables[0].Rows[0][1].ToString();

                }
                if (dsetStakeholdersDetails.Tables[1].Rows.Count > 0)
                {
                    _strBidMnagerEmail = dsetStakeholdersDetails.Tables[1].Rows[0][1].ToString();
                }
                if (dsetStakeholdersDetails.Tables[2].Rows.Count > 0)
                {
                    _strGPTManagerName = dsetStakeholdersDetails.Tables[2].Rows[0][0].ToString();
                    _strGPTManagerEmail = dsetStakeholdersDetails.Tables[2].Rows[0][1].ToString();
                }
            }

            string _strEmailBody = "<html><body><div style='border:1px solid black;padding:10px;font-family:arial'> Dear ";
            _strEmailBody += "</br>";
            _strEmailBody += "</br>";
            _strEmailBody += "<p style='colr:red;'>Bid Win Score is rejected for Opportunity ID " + _strOppNumber + ".</p> ";
            _strEmailBody += "</br>";
            _strEmailBody += "To Access the LDF Application Please Click on Link below";
            _strEmailBody += "</br>";
            _strEmailBody += "</br>";
            _strEmailBody += "</br>";
            _strEmailBody += "Thanks,";
            _strEmailBody += "</br>";
            _strEmailBody += "LDF Team";
            _strEmailBody += "</br>";
            _strEmailBody += "</br>";
            _strEmailBody += "[Note: This is an system generated email. Please do not reply]";
            _strEmailBody += "</br>";
            _strEmailBody += "-------------------------------------------------------------- </div></body></html>";

            var fromAddress = new MailAddress(System.Web.Configuration.WebConfigurationManager.AppSettings["EmailFrom"],
                           "Large Deal Framework");

            MailMessage clsMailMessage = new MailMessage(fromAddress.ToString(), _strBUHeadEmail, "Automated Mail for GPT manager Rejection", _strEmailBody);
            clsMailMessage.IsBodyHtml = true;
            if (!string.IsNullOrEmpty(_strBidMnagerEmail))
            {
                clsMailMessage.To.Add(_strBidMnagerEmail);
            }
            clsMailMessage.CC.Add(_strGPTManagerEmail);

            string username = System.Web.Configuration.WebConfigurationManager.AppSettings["username"].ToString();
            string Password = System.Web.Configuration.WebConfigurationManager.AppSettings["Password"];

            string Host = System.Web.Configuration.WebConfigurationManager.AppSettings["SMTPSERVER"];
            int Port = Convert.ToInt32(System.Web.Configuration.WebConfigurationManager.AppSettings["Port"]);

            SmtpClient clsSMTPClient = new SmtpClient(Host, Port);
            clsSMTPClient.EnableSsl = true;
            System.Net.NetworkCredential crediantials = new NetworkCredential(username, Password);
            clsSMTPClient.UseDefaultCredentials = false;
            clsSMTPClient.Credentials = crediantials;
            //myhtmlMessage.Attachments.Add(myAttachment);
            clsSMTPClient.Send(clsMailMessage);


        }

        private void SendAutomatedMailTopManagement()
        {
            //Local variables for Email
            string _strGPTManagerEmail = string.Empty;
            string _strBUHeadEmail = string.Empty;
            string _strBidMnagerEmail = string.Empty;
            string _strTopManagementEmail = string.Empty;
            string _strGPTManagerName = string.Empty;
            string _strOppNumber = (string)Session["Oppid"];
            string topmanagement = string.Empty;


            DataSet dsTopManagemnt = new BLL.BidWinabilityBLL().GetTopManagement();
            if (dsTopManagemnt.Tables.Count > 0)
            {
                if (dsTopManagemnt.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsTopManagemnt.Tables[0].Rows.Count; i++)
                    {
                        topmanagement += dsTopManagemnt.Tables[0].Rows[i][2].ToString().Trim() + ",";
                    }
                }
            }

            topmanagement = topmanagement.Remove(topmanagement.Length - 1);
            DataSet dsetStakeholdersDetails = new BLL.BidWinabilityBLL().GetStakeHoldersBidWinability(_strOppNumber);
            if (dsetStakeholdersDetails.Tables.Count > 0)
            {
                if (dsetStakeholdersDetails.Tables[0].Rows.Count > 0)
                {
                    _strBUHeadEmail = dsetStakeholdersDetails.Tables[0].Rows[0][1].ToString();

                }
                if (dsetStakeholdersDetails.Tables[1].Rows.Count > 0)
                {
                    _strBidMnagerEmail = dsetStakeholdersDetails.Tables[1].Rows[0][1].ToString();
                }
                if (dsetStakeholdersDetails.Tables[2].Rows.Count > 0)
                {
                    _strGPTManagerName = dsetStakeholdersDetails.Tables[2].Rows[0][0].ToString();
                    _strGPTManagerEmail = dsetStakeholdersDetails.Tables[2].Rows[0][1].ToString();
                }
            }

            string _strEmailBody = "<html><body><div style='border:1px solid black;padding:10px;font-family:arial'> Dear ";
            _strEmailBody += "</br>";
            _strEmailBody += "</br>";
            _strEmailBody += "<p style='colr:red;'>Bid Win Score is submitted for Opportunity ID " + _strOppNumber + ".</p> ";
            _strEmailBody += "</br>";
            _strEmailBody += "To Access the LDF Application Please Click on Link below";
            _strEmailBody += "</br>";
            _strEmailBody += "</br>";
            _strEmailBody += "</br>";
            _strEmailBody += "Thanks,";
            _strEmailBody += "</br>";
            _strEmailBody += "LDF Team";
            _strEmailBody += "</br>";
            _strEmailBody += "</br>";
            _strEmailBody += "[Note: This is an system generated email. Please do not reply]";
            _strEmailBody += "</br>";
            _strEmailBody += "-------------------------------------------------------------- </div></body></html>";

            var fromAddress = new MailAddress(System.Web.Configuration.WebConfigurationManager.AppSettings["EmailFrom"],
                           "Large Deal Framework");

            MailMessage clsMailMessage = new MailMessage(fromAddress.ToString(), topmanagement, "Automated Mail for GPT manager Approval", _strEmailBody);
            clsMailMessage.IsBodyHtml = true;
            clsMailMessage.CC.Add(_strBidMnagerEmail);
            clsMailMessage.CC.Add(_strBUHeadEmail);
            clsMailMessage.CC.Add(_strGPTManagerEmail);
            //myhtmlMessage.CC.Add(strTopManagementEmail);

            string username = System.Web.Configuration.WebConfigurationManager.AppSettings["username"].ToString();
            string Password = System.Web.Configuration.WebConfigurationManager.AppSettings["Password"];

            string Host = System.Web.Configuration.WebConfigurationManager.AppSettings["SMTPSERVER"];
            int Port = Convert.ToInt32(System.Web.Configuration.WebConfigurationManager.AppSettings["Port"]);

            SmtpClient clsSMTPClient = new SmtpClient(Host, Port);
            clsSMTPClient.EnableSsl = true;
            System.Net.NetworkCredential crediantials = new NetworkCredential(username, Password);
            clsSMTPClient.UseDefaultCredentials = false;
            clsSMTPClient.Credentials = crediantials;
            //myhtmlMessage.Attachments.Add(myAttachment);
            clsSMTPClient.Send(clsMailMessage);


        }

        //private void AddOpportunitytoClosed(OpportunityQualificationBO opportunityQualificationBO)
        //{
        //    DataSet dsAddOpp = new BLL.ScoreOppQuaBLL().InsertDeleteOpportunity(opportunityQualificationBO);
        //}

        private void PopulateActiveScoreScaleGridview()
        {


            DataSet dsPopulateActiveScoreScaleGridview = new BLL.ScoreOppQuaBLL().GetScoreScaleBidWinScore();
            if (dsPopulateActiveScoreScaleGridview.Tables.Count > 0)
            {
                if (dsPopulateActiveScoreScaleGridview.Tables[0].Rows.Count > 0)
                {
                    gvBidWinScaleScore.DataSource = dsPopulateActiveScoreScaleGridview;
                    gvBidWinScaleScore.DataBind();
                }
            }

        }


        #endregion

        #region Events for control
        protected void btnLowOppQuaA_Click(object sender, EventArgs e)
        {
            lblScore4.Text = string.Empty;
            lblScore4.Text = btnLowOppQuaA.Text;
        }

        protected void btnLowOppQuaC_Click(object sender, EventArgs e)
        {
            lblScore4.Text = string.Empty;
            lblScore4.Text = btnLowOppQuaC.Text;
        }

        protected void btnHighOppQuaD_Click(object sender, EventArgs e)
        {
            lblScore4.Text = string.Empty;
            lblScore4.Text = btnHighOppQuaD.Text;
        }

        protected void btnHighOppQuaB_Click(object sender, EventArgs e)
        {
            lblScore4.Text = string.Empty;
            lblScore4.Text = btnHighOppQuaB.Text;
        }

        protected void btnLowC_Click(object sender, EventArgs e)
        {
            lblScore3.Text = string.Empty;
            lblScore3.Text = btnLowC.Text;
        }

        protected void btnLowA_Click(object sender, EventArgs e)
        {
            lblScore3.Text = string.Empty;
            lblScore3.Text = btnLowA.Text;
        }

        protected void btnHighD_Click(object sender, EventArgs e)
        {
            lblScore3.Text = string.Empty;
            lblScore3.Text = btnHighD.Text;
        }

        protected void btnHighB_Click(object sender, EventArgs e)
        {
            lblScore3.Text = string.Empty;
            lblScore3.Text = btnHighB.Text;
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            modalPopupGraph.Show();
            PopulateScoresforPanel();
        }

        #endregion

        protected void ChartBidWinability_DataBinding(object sender, EventArgs e)
        {
            try
            {
                double _dblOpportunityQualification = 0.0;
                double _dblRGYChecklist = 0.0;
                double _dblUniqueness = 0.0;
                double _dblInnovation = 0.0;
                string rgyscore = lblRGYScore.Text;
                if (lblOpportunityScore.Text != string.Empty && rgyscore != string.Empty && lblUniqueness.Text != string.Empty && lblInnovation.Text != string.Empty)
                {
                    _dblOpportunityQualification = Convert.ToDouble(lblOpportunityScore.Text);
                    _dblRGYChecklist = Convert.ToDouble(lblRGYScore.Text.ToString().Split('%')[0]);
                    //_dblRGYChecklist = Convert.ToDouble(lblRGYScore.Text.ToString());
                    _dblUniqueness = Convert.ToDouble(lblUniqueness.Text);
                    _dblInnovation = Convert.ToDouble(lblInnovation.Text);
                }

                this.ChartBidWinability.Series.Add("Opportunity Qualification");
                this.ChartBidWinability.Series["Opportunity Qualification"].Color = System.Drawing.Color.Blue;
                this.ChartBidWinability.Series["Opportunity Qualification"].Points.AddXY(4.08, _dblOpportunityQualification);
                this.ChartBidWinability.Series["Opportunity Qualification"]["PixelPointWidth"] = "150";

                this.ChartBidWinability.Series.Add("RGYChecklist");
                this.ChartBidWinability.Series["RGYChecklist"].Color = System.Drawing.Color.Red;
                this.ChartBidWinability.Series["RGYChecklist"].Points.AddXY(10, _dblRGYChecklist);
                this.ChartBidWinability.Series["RGYChecklist"]["PixelPointWidth"] = "150";

                this.ChartBidWinability.Series.Add("Innovation");
                this.ChartBidWinability.Series["Innovation"].Color = System.Drawing.Color.Yellow;
                this.ChartBidWinability.Series["Innovation"].Points.AddXY(16.5, _dblInnovation);
                this.ChartBidWinability.Series["Innovation"]["PixelPointWidth"] = "150";

                this.ChartBidWinability.Series.Add("Uniqueness");
                this.ChartBidWinability.Series["Uniqueness"].Color = System.Drawing.Color.Green;
                this.ChartBidWinability.Series["Uniqueness"].Points.AddXY(23, _dblUniqueness);
                this.ChartBidWinability.Series["Uniqueness"]["PixelPointWidth"] = "150";

                // Create a new legend called "Legend2".
                ChartBidWinability.Legends.Add(new Legend("LegendBidWinability"));

                // Set Docking of the Legend chart to the Default Chart Area.
                ChartBidWinability.Legends["LegendBidWinability"].DockedToChartArea = "ChartAreaBidWinability";
                //ChartBidWinability.Legends["LegendBidWinability"].Position = new ElementPosition(30, 5, 100, 20);
                ChartBidWinability.Legends["LegendBidWinability"].Position = new ElementPosition(85, 0, 20, 60);

                // Assign the legend to Series1.
                ChartBidWinability.Series["Opportunity Qualification"].Legend = "LegendBidWinability";
                ChartBidWinability.Series["Opportunity Qualification"].IsVisibleInLegend = true;
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
                string strOppID = (string)Session["Oppid"];
                DataSet dsPopulateScore = new BLL.BidWinabilityBLL().GetBidWinabilityScoreStatus(strOppID);
                if (_intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.BUHead))
                {
                    BidWinabilityBO clsBidWinabilityBO = new BidWinabilityBO();
                    clsBidWinabilityBO.OppID = (string)Session["Oppid"];
                    clsBidWinabilityBO.InnovationScore = lblScore3.Text;
                    clsBidWinabilityBO.IsInnovationSubmit = true;
                    if (string.IsNullOrEmpty(lblScore4.Text))
                    {
                        clsBidWinabilityBO.UniquenessScore = "Null";
                        clsBidWinabilityBO.IsUniquenessScore = false;
                    }
                    else
                    {
                        if (dsPopulateScore.Tables[0].Rows[0][4].ToString().Trim() == "False")
                        {
                            clsBidWinabilityBO.UniquenessScore = lblScore4.Text;
                            clsBidWinabilityBO.IsUniquenessScore = false;
                        }
                        else
                        {
                            clsBidWinabilityBO.UniquenessScore = lblScore4.Text;
                            clsBidWinabilityBO.IsUniquenessScore = true;
                        }
                    }

                    clsBidWinabilityBO.Status = "Pending";
                    bool _blnVal = new BLL.BidWinabilityBLL().AddUpdateBidWinabilityScoreStatus(clsBidWinabilityBO);

                    lblMessage.Text = "Innovation score added successfully";
                    btnSubmit.Visible = false;
                    btnLowA.Enabled = false;
                    btnLowC.Enabled = false;
                    btnHighB.Enabled = false;
                    btnHighD.Enabled = false;
                }

                if (_intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.BidManager))
                {
                    BidWinabilityBO clsBidWinabilityBO = new BidWinabilityBO();
                    clsBidWinabilityBO.OppID = (string)Session["Oppid"];
                    clsBidWinabilityBO.UniquenessScore = lblScore4.Text;
                    clsBidWinabilityBO.IsUniquenessScore = true;
                    if (string.IsNullOrEmpty(lblScore3.Text))
                    {
                        clsBidWinabilityBO.InnovationScore = "Null";
                        clsBidWinabilityBO.IsInnovationSubmit = false;
                    }
                    else
                    {
                        if (dsPopulateScore.Tables[0].Rows[0][3].ToString().Trim() == "False")
                        {
                            clsBidWinabilityBO.InnovationScore = lblScore3.Text;
                            clsBidWinabilityBO.IsInnovationSubmit = false;
                        }
                        else
                        {
                            clsBidWinabilityBO.InnovationScore = lblScore3.Text;
                            clsBidWinabilityBO.IsInnovationSubmit = true;
                        }
                    }

                    clsBidWinabilityBO.Status = "Pending";
                    bool _blnVal = new BLL.BidWinabilityBLL().AddUpdateBidWinabilityScoreStatus(clsBidWinabilityBO);

                    lblMessage.Text = "Uniqueness score added successfully";
                    btnSubmit.Visible = false;
                    btnLowOppQuaC.Enabled = false;
                    btnLowOppQuaA.Enabled = false;
                    btnHighOppQuaB.Enabled = false;
                    btnHighOppQuaD.Enabled = false;

                }

              

                if (dsPopulateScore.Tables.Count > 0)
                {
                    if (dsPopulateScore.Tables[0].Rows.Count > 0)
                    {
                        if ((dsPopulateScore.Tables[0].Rows[0][3].ToString().Trim() == "True") && (dsPopulateScore.Tables[0].Rows[0][4].ToString().Trim() == "True"))
                        {
                            SendAutomatedMailtoTopManagement();
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

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            BidWinabilityBO clsBidWinabilityBO = new BidWinabilityBO();
            clsBidWinabilityBO.OppID = (string)Session["Oppid"];
            clsBidWinabilityBO.UniquenessScore = lblScore4.Text;
            clsBidWinabilityBO.InnovationScore = lblScore3.Text;
            clsBidWinabilityBO.IsInnovationSubmit = true;
            clsBidWinabilityBO.IsUniquenessScore = true;
            clsBidWinabilityBO.Status = "Approved";

            try
            {
                bool _blnVal = new BLL.BidWinabilityBLL().AddUpdateBidWinabilityScoreStatus(clsBidWinabilityBO);
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Opportunity " + clsBidWinabilityBO.OppID + " is approved.";
                btnApprove.Visible = false;
                btnReject.Visible = false;

                //OpportunityQualificationBO opportunityQualificationBO = new OpportunityQualificationBO();
                //opportunityQualificationBO.OppNumber = (string)Session["Oppid"];
                //opportunityQualificationBO.Status = "Approved";
                //opportunityQualificationBO.Comments = string.Empty;
                //opportunityQualificationBO.OppDescription = string.Empty;
                //AddOpportunitytoClosed(opportunityQualificationBO);
                SendAutomatedMailTopManagement();
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

        protected void btnReject_Click(object sender, EventArgs e)
        {
            BidWinabilityBO clsBidWinabilityBO = new BidWinabilityBO();
            clsBidWinabilityBO.OppID = (string)Session["Oppid"];
            clsBidWinabilityBO.UniquenessScore = lblScore4.Text;
            clsBidWinabilityBO.InnovationScore = lblScore3.Text;
            clsBidWinabilityBO.IsInnovationSubmit = false;
            clsBidWinabilityBO.IsUniquenessScore = false;
            clsBidWinabilityBO.Status = "Rejected";

            try
            {
                bool _blnVal = new BLL.BidWinabilityBLL().AddUpdateBidWinabilityScoreStatus(clsBidWinabilityBO);

                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Opportunity " + clsBidWinabilityBO.OppID + " is rejected.";
                btnApprove.Visible = false;
                btnReject.Visible = false;

                SendAutomatedMailOpportunityRejection();
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
