
/* ---------------------------------------------------------------------------------------------------------------
 * Project Name : Large Deal Type
 * Module Name : Opportunity Qualification
 * Program Version : 1.0.0
 * Filename : SyntelCompetitiveAdvantage.aspx.cs
 * Purpose : This page allows Sales and Delivery persons to enter score and description for parameters. 
 * ----------------------------------------------------------------------------------------------------------------
 * MODIFICATION HISTORY:
 * ----------------------------------------------------------------------------------------------------------------
 * PHASE    AUTHOR                 DATE          MODIFICATION           DESCRIPTION
 *                              (MM/DD/YYYY)     DETAILS
 * ----------------------------------------------------------------------------------------------------------------
 *   1.    PRIYANKA DATIR        12/13/2013      CREATED                NONE  
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using BO;
using BLL;
using System.Net.Mail;
using System.Net;


namespace LargeDealFrameWork
{
    public partial class FrmSyntelsCompetitiveAdvantage : System.Web.UI.Page
    {
        #region Page load

        int _intDesignation = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Designation"] != null)
                {
                    _intDesignation = Convert.ToInt32(Session["Designation"]);
                }

                if (!IsPostBack)
                {
                    //To populate score and description in gridview
                    PopulateScaleScoreGridview();

                    //To display description on the basis of total score
                    PopulateScoreScaleDescription();

                    //To retain previously save data
                    PopulateSyntelCompetitive();

                    //Controls enabled-disabled for different users
                    EnableDisableControlsByDesignation();

                    //Submit button is enable when all four screen contains data
                    EnableSubmitbutton();

                    //Enable controls when status is not approved
                    EnableControlsforEditingNotApproved();

                    //Decription aceepting 250 characters
                    this.txtDescription1.Attributes.Add("onkeypress", "return ValidateDescription('" + this.txtDescription1.ClientID + "')");
                    this.txtDescription2.Attributes.Add("onkeypress", "return ValidateDescription('" + this.txtDescription2.ClientID + "')");
                    this.txtDescription3.Attributes.Add("onkeypress", "return ValidateDescription('" + this.txtDescription3.ClientID + "')");
                    this.txtDescription4.Attributes.Add("onkeypress", "return ValidateDescription('" + this.txtDescription4.ClientID + "')");
                    this.txtDescription5.Attributes.Add("onkeypress", "return ValidateDescription('" + this.txtDescription5.ClientID + "')");
                    this.txtDescription6.Attributes.Add("onkeypress", "return ValidateDescription('" + this.txtDescription6.ClientID + "')");
                    this.txtDecription7.Attributes.Add("onkeypress", "return ValidateDescription('" + this.txtDecription7.ClientID + "')");
                    this.txtDescription8.Attributes.Add("onkeypress", "return ValidateDescription('" + this.txtDescription8.ClientID + "')");

                    this.txtDescription1.Attributes.Add("onchange", "update()");
                    this.txtDescription2.Attributes.Add("onchange", "update()");
                    this.txtDescription3.Attributes.Add("onchange", "update()");
                    this.txtDescription4.Attributes.Add("onchange", "update()");
                    this.txtDescription5.Attributes.Add("onchange", "update()");
                    this.txtDescription6.Attributes.Add("onchange", "update()");
                    this.txtDecription7.Attributes.Add("onchange", "update()");
                    this.txtDescription8.Attributes.Add("onchange", "update()");

                    this.txtTotalScore.Attributes.Add("onchange", "update()");
                    this.hidUpdateValue.Value = "false";
                    this.HidCounter.Value = "1";
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

        #region private methods

        private void PopulateSyntelCompetitive()
        {
            try
            {
                QualificationDetailsBO clsQuaDetailsBO = new QualificationDetailsBO();
                clsQuaDetailsBO.OppNumber = (string)Session["Oppid"];
                clsQuaDetailsBO.ParaID = Constants._intSolutionAdvantageParaID;

                DataSet dsPopulateSyntelCompetitive = new BLL.ScoreOppQuaBLL().GetScoreDescriptionForParameterScreen1(clsQuaDetailsBO);
                if (dsPopulateSyntelCompetitive.Tables.Count > 0)
                {
                    if (dsPopulateSyntelCompetitive.Tables[0].Rows.Count > 0)
                    {
                        if (dsPopulateSyntelCompetitive.Tables[0].Rows.Count == 8)
                        {
                            hidSaveClickbyDD.Value = "false";
                            hidSaveClickbySale.Value = "false";

                            ddlscore1.SelectedValue = dsPopulateSyntelCompetitive.Tables[0].Rows[0][2].ToString();
                            txtDescription1.Text = dsPopulateSyntelCompetitive.Tables[0].Rows[0][3].ToString();

                            ddlscore2.SelectedValue = dsPopulateSyntelCompetitive.Tables[0].Rows[1][2].ToString();
                            txtDescription2.Text = dsPopulateSyntelCompetitive.Tables[0].Rows[1][3].ToString();

                            ddlScore3.SelectedValue = dsPopulateSyntelCompetitive.Tables[0].Rows[2][2].ToString();
                            txtDescription3.Text = dsPopulateSyntelCompetitive.Tables[0].Rows[2][3].ToString();

                            ddlScore4.SelectedValue = dsPopulateSyntelCompetitive.Tables[0].Rows[3][2].ToString();
                            txtDescription4.Text = dsPopulateSyntelCompetitive.Tables[0].Rows[3][3].ToString();


                            ddlScore5.SelectedValue = dsPopulateSyntelCompetitive.Tables[0].Rows[4][2].ToString();
                            txtDescription5.Text = dsPopulateSyntelCompetitive.Tables[0].Rows[4][3].ToString();

                            ddlScore6.SelectedValue = dsPopulateSyntelCompetitive.Tables[0].Rows[5][2].ToString();
                            txtDescription6.Text = dsPopulateSyntelCompetitive.Tables[0].Rows[5][3].ToString();

                            ddlScore7.SelectedValue = dsPopulateSyntelCompetitive.Tables[0].Rows[6][2].ToString();
                            txtDecription7.Text = dsPopulateSyntelCompetitive.Tables[0].Rows[6][3].ToString();

                            ddlScore8.SelectedValue = dsPopulateSyntelCompetitive.Tables[0].Rows[7][2].ToString();
                            txtDescription8.Text = dsPopulateSyntelCompetitive.Tables[0].Rows[7][3].ToString();
                        }

                        if (dsPopulateSyntelCompetitive.Tables[0].Rows.Count == 6)
                        {
                            hidSaveClickbySale.Value = "false";

                            ddlscore2.SelectedValue = dsPopulateSyntelCompetitive.Tables[0].Rows[0][2].ToString();
                            txtDescription2.Text = dsPopulateSyntelCompetitive.Tables[0].Rows[0][3].ToString();

                            ddlScore4.SelectedValue = dsPopulateSyntelCompetitive.Tables[0].Rows[1][2].ToString();
                            txtDescription4.Text = dsPopulateSyntelCompetitive.Tables[0].Rows[1][3].ToString();

                            ddlScore5.SelectedValue = dsPopulateSyntelCompetitive.Tables[0].Rows[2][2].ToString();
                            txtDescription5.Text = dsPopulateSyntelCompetitive.Tables[0].Rows[2][3].ToString();

                            ddlScore6.SelectedValue = dsPopulateSyntelCompetitive.Tables[0].Rows[3][2].ToString();
                            txtDescription6.Text = dsPopulateSyntelCompetitive.Tables[0].Rows[3][3].ToString();


                            ddlScore7.SelectedValue = dsPopulateSyntelCompetitive.Tables[0].Rows[4][2].ToString();
                            txtDecription7.Text = dsPopulateSyntelCompetitive.Tables[0].Rows[4][3].ToString();

                            ddlScore8.SelectedValue = dsPopulateSyntelCompetitive.Tables[0].Rows[5][2].ToString();
                            txtDescription8.Text = dsPopulateSyntelCompetitive.Tables[0].Rows[5][3].ToString();
                        }
                    }

                }
                hidScoreSyntelCompetitive.Value = (Convert.ToInt32(ddlscore1.SelectedValue) + Convert.ToInt32(ddlscore2.SelectedValue)
                                         + Convert.ToInt32(ddlScore3.SelectedValue) + Convert.ToInt32(ddlScore4.SelectedValue)
                                          + Convert.ToInt32(ddlScore5.SelectedValue) + Convert.ToInt32(ddlScore6.SelectedValue)
                                          + Convert.ToInt32(ddlScore7.SelectedValue) + Convert.ToInt32(ddlScore8.SelectedValue)).ToString();
                DisplayDescriptiononScore();
            }
            catch (Exception ex)
            {
                string _strErrorMessage = string.Format("{0}", ex.Message.ToString());

                var cleanChars = _strErrorMessage.Where(c => !"\n\r".Contains(c));
                string cleanText = new string(cleanChars.ToArray());

                Response.Redirect("/frmErrorPage.aspx?ErrorMessage=" + cleanText);
            }

        }

        private void PopulateScaleScoreGridview()
        {
            try
            {
                DataSet dsPopulateActiveScoreScaleGridview = new BLL.ScoreOppQuaBLL().GetScoreOppQuaByActiveScreen4();
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

        private void DisplayDescriptiononScore()
        {
            try
            {
                List<ScoreOppQuaBO> lstScoreOppQuaBO = new List<ScoreOppQuaBO>();
                DataSet dsPopulateActiveScoreScaleGridview = new BLL.ScoreOppQuaBLL().GetScoreOppQuaByActiveScreen4();
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
                foreach (ScoreOppQuaBO clsScoreOppQuaBO in lstScoreOppQuaBO)
                {
                    string[] _strArrnumber = clsScoreOppQuaBO.Scale.Split(new[] { '-' });

                    if (Convert.ToInt32(hidScoreSyntelCompetitive.Value) <= Convert.ToInt32(_strArrnumber[1]))
                    {
                        if (Convert.ToInt32(hidScoreSyntelCompetitive.Value) >= Convert.ToInt32(_strArrnumber[0]))
                        {
                            lblScoreDescription.Text = clsScoreOppQuaBO.Scale_Description;
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

        private DataSet EnableSubmitbutton()
        {
            DataSet dsGetAllScreenData = new DataSet();
            try
            {


                //Screen 1
                QualificationDetailsBO clsQuaDetailsClientsDemand = new QualificationDetailsBO();
                clsQuaDetailsClientsDemand.OppNumber = (string)Session["Oppid"];
                clsQuaDetailsClientsDemand.ParaID = Constants._intEmotionalParaID;

                DataSet dsPopulateClientsDemand = new BLL.ScoreOppQuaBLL().GetScoreDescriptionForParameterScreen1(clsQuaDetailsClientsDemand);

                //Screen2
                QualificationDetailsBO clsQuaDetailsSyntelBusiness = new QualificationDetailsBO();
                clsQuaDetailsSyntelBusiness.OppNumber = (string)Session["Oppid"];
                clsQuaDetailsSyntelBusiness.ParaID = Constants._intInitialRevenueParaID;

                DataSet dsPopulateSyntelBusiness = new BLL.ScoreOppQuaBLL().GetScoreDescriptionForParameterScreen1(clsQuaDetailsSyntelBusiness);

                //Screen3
                QualificationDetailsBO clsQuaDetailsClientUrgency = new QualificationDetailsBO();
                clsQuaDetailsClientUrgency.OppNumber = (string)Session["Oppid"];
                clsQuaDetailsClientUrgency.ParaID = Constants._intHowMuchParaID;

                DataSet dsPopulateClientUrgency = new BLL.ScoreOppQuaBLL().GetScoreDescriptionForParameterScreen1(clsQuaDetailsClientUrgency);

                //Screen4
                QualificationDetailsBO clsQuaDetailsSyntelCompetitive = new QualificationDetailsBO();
                clsQuaDetailsSyntelCompetitive.OppNumber = (string)Session["Oppid"];
                clsQuaDetailsSyntelCompetitive.ParaID = Constants._intSolutionAdvantageParaID;

                DataSet dsPopulateSyntelCompetitive = new BLL.ScoreOppQuaBLL().GetScoreDescriptionForParameterScreen1(clsQuaDetailsSyntelCompetitive);

                //Check if data exists in final table
                QualificationDetailsBO clsQuaDetailsBO = new QualificationDetailsBO();
                clsQuaDetailsBO.OppNumber = (string)Session["Oppid"];
                DataSet dsPopulateallScreens = new BLL.ScoreOppQuaBLL().GetScoreDescriptionParameterforAllScreens(clsQuaDetailsBO);
                if (dsPopulateallScreens.Tables[0].Rows.Count == 0)
                {
                    if (dsPopulateClientsDemand.Tables[0].Rows.Count == 2 && dsPopulateSyntelBusiness.Tables[0].Rows.Count == 7
                        && dsPopulateClientUrgency.Tables[0].Rows.Count == 4 && dsPopulateSyntelCompetitive.Tables[0].Rows.Count == 8)
                    {
                        
                        dsGetAllScreenData.Merge(dsPopulateClientsDemand, true);
                        dsGetAllScreenData.Merge(dsPopulateSyntelBusiness, true);
                        dsGetAllScreenData.Merge(dsPopulateClientUrgency, true);
                        dsGetAllScreenData.Merge(dsPopulateSyntelCompetitive, true);
                        //Enable submit button for Sales and DM
                        int Id = (int)Session["Designation"];
                        if ((Id == clsDesignationList.GetDesignationID(EnumDesignation.PrimarySalesSPoc)) || (Id == clsDesignationList.GetDesignationID(EnumDesignation.DeliveryManager) || (Id == clsDesignationList.GetDesignationID(EnumDesignation.DeliveryManagerSPoC))))
                        {
                            btnSubmit.Visible = true;
                        }
                    }

                }
                else
                {
                    DataSet dsGetStatusValue = new BLL.ScoreOppQuaBLL().GetOpportunityQualificationDetails((string)Session["Oppid"]);
                    if (dsGetStatusValue.Tables.Count > 0)
                    {
                        if (dsGetStatusValue.Tables[0].Rows.Count > 0)
                        {
                            if (dsGetStatusValue.Tables[0].Rows[0][4].ToString().Trim() == "Not Approved")
                            {
                                //btnSendNotification.Visible = true;
                                dsGetAllScreenData.Merge(dsPopulateClientsDemand, true);
                                dsGetAllScreenData.Merge(dsPopulateSyntelBusiness, true);
                                dsGetAllScreenData.Merge(dsPopulateClientUrgency, true);
                                dsGetAllScreenData.Merge(dsPopulateSyntelCompetitive, true);
                                btnSave.Visible = true;
                                if (_intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.PrimarySalesSPoc))
                                {
                                    ddlScore3.Enabled = true;
                                    ddlScore4.Enabled = true;
                                    ddlScore5.Enabled = true;
                                    ddlScore6.Enabled = true;
                                    ddlScore7.Enabled = true;
                                    ddlScore8.Enabled = true;
                                    txtDescription3.Enabled = true;
                                    txtDescription4.Enabled = true;
                                    txtDescription5.Enabled = true;
                                    txtDescription6.Enabled = true;
                                    txtDecription7.Enabled = true;
                                    txtDescription8.Enabled = true;
                                    txtDecription7.Enabled = true;
                                }

                                if (_intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.DeliveryDirector) || _intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.DeliveryManager) || _intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.DeliveryManagerSPoC))
                                {
                                    ddlscore1.Enabled = true;
                                    ddlScore3.Enabled = true;
                                    txtDescription1.Enabled = true;
                                    txtDescription3.Enabled = true;
                                }
                                
                            }
                            else if (dsGetStatusValue.Tables[0].Rows[0][4].ToString().Trim() == "Approved")
                            {
                                Disablecontrolsonsubmit();
                            }
                        }
                    }
                    else
                    {
                        lblMsg.Text = "Already submitted!!!";
                        Disablecontrolsonsubmit();
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
            return dsGetAllScreenData;
        }

        private void PopulateScoreScaleDescription()
        {
            try
            {
                DataSet dsPopulateScoreScaleRange = new BLL.ScoreOppQuaBLL().GetScoreScaleDescriptionScreen4();

                //Parameter 1
                txtScoringRange1.Text = dsPopulateScoreScaleRange.Tables[0].Rows[0][0].ToString() + "-" + dsPopulateScoreScaleRange.Tables[0].Rows[0][1].ToString();
                lblScoringRangeDescription1.Text = dsPopulateScoreScaleRange.Tables[0].Rows[0][2].ToString();


                for (int i = Convert.ToInt32(dsPopulateScoreScaleRange.Tables[0].Rows[0][0]); i <= Convert.ToInt32(dsPopulateScoreScaleRange.Tables[0].Rows[0][1]); i++)
                {
                    ListItem lstdd1 = new ListItem();
                    lstdd1.Text = i.ToString();
                    lstdd1.Value = i.ToString();
                    ddlscore1.Items.Add(lstdd1);
                }

                //Parameter 2
                txtScoringRange2.Text = dsPopulateScoreScaleRange.Tables[0].Rows[1][0].ToString() + "-" + dsPopulateScoreScaleRange.Tables[0].Rows[1][1].ToString();
                lblScoringRangeDescription2.Text = dsPopulateScoreScaleRange.Tables[0].Rows[1][2].ToString();

                for (int i = Convert.ToInt32(dsPopulateScoreScaleRange.Tables[0].Rows[1][0]); i <= Convert.ToInt32(dsPopulateScoreScaleRange.Tables[0].Rows[1][1]); i++)
                {
                    ListItem lstdd2 = new ListItem();
                    lstdd2.Text = i.ToString();
                    lstdd2.Value = i.ToString();
                    ddlscore2.Items.Add(lstdd2);
                }

                //Parameter 3
                txtScoringRange3.Text = dsPopulateScoreScaleRange.Tables[0].Rows[2][0].ToString() + "-" + dsPopulateScoreScaleRange.Tables[0].Rows[2][1].ToString();
                lblScoringRangeDescription3.Text = dsPopulateScoreScaleRange.Tables[0].Rows[2][2].ToString();

                for (int i = Convert.ToInt32(dsPopulateScoreScaleRange.Tables[0].Rows[2][0]); i <= Convert.ToInt32(dsPopulateScoreScaleRange.Tables[0].Rows[2][1]); i++)
                {
                    ListItem lstdd3 = new ListItem();
                    lstdd3.Text = i.ToString();
                    lstdd3.Value = i.ToString();
                    ddlScore3.Items.Add(lstdd3);
                }

                //Parameter 4
                txtScoringRange4.Text = dsPopulateScoreScaleRange.Tables[0].Rows[3][0].ToString() + "-" + dsPopulateScoreScaleRange.Tables[0].Rows[3][1].ToString();
                lblScoringRangeDescription4.Text = dsPopulateScoreScaleRange.Tables[0].Rows[3][2].ToString();

                for (int i = Convert.ToInt32(dsPopulateScoreScaleRange.Tables[0].Rows[3][0]); i <= Convert.ToInt32(dsPopulateScoreScaleRange.Tables[0].Rows[3][1]); i++)
                {
                    ListItem lstdd4 = new ListItem();
                    lstdd4.Text = i.ToString();
                    lstdd4.Value = i.ToString();
                    ddlScore4.Items.Add(lstdd4);
                }

                //Parameter 5
                txtScoringRange5.Text = dsPopulateScoreScaleRange.Tables[0].Rows[4][0].ToString() + "-" + dsPopulateScoreScaleRange.Tables[0].Rows[4][1].ToString();
                lblScoringRangeDescription5.Text = dsPopulateScoreScaleRange.Tables[0].Rows[4][2].ToString();

                for (int i = Convert.ToInt32(dsPopulateScoreScaleRange.Tables[0].Rows[4][0]); i <= Convert.ToInt32(dsPopulateScoreScaleRange.Tables[0].Rows[4][1]); i++)
                {
                    ListItem lstdd5 = new ListItem();
                    lstdd5.Text = i.ToString();
                    lstdd5.Value = i.ToString();
                    ddlScore5.Items.Add(lstdd5);
                }

                //Parameter 6
                txtScoringRange6.Text = dsPopulateScoreScaleRange.Tables[0].Rows[5][0].ToString() + "-" + dsPopulateScoreScaleRange.Tables[0].Rows[5][1].ToString();
                lblScoringRangeDescription6.Text = dsPopulateScoreScaleRange.Tables[0].Rows[5][2].ToString();

                for (int i = Convert.ToInt32(dsPopulateScoreScaleRange.Tables[0].Rows[4][0]); i <= Convert.ToInt32(dsPopulateScoreScaleRange.Tables[0].Rows[5][1]); i++)
                {
                    ListItem lstdd6 = new ListItem();
                    lstdd6.Text = i.ToString();
                    lstdd6.Value = i.ToString();
                    ddlScore6.Items.Add(lstdd6);
                }

                //Parameter 7
                txtScoringRange7.Text = dsPopulateScoreScaleRange.Tables[0].Rows[6][0].ToString() + "-" + dsPopulateScoreScaleRange.Tables[0].Rows[6][1].ToString();
                lblScoringRangeDecription7.Text = dsPopulateScoreScaleRange.Tables[0].Rows[6][2].ToString();

                for (int i = Convert.ToInt32(dsPopulateScoreScaleRange.Tables[0].Rows[6][0]); i <= Convert.ToInt32(dsPopulateScoreScaleRange.Tables[0].Rows[6][1]); i++)
                {
                    ListItem lstdd7 = new ListItem();
                    lstdd7.Text = i.ToString();
                    lstdd7.Value = i.ToString();
                    ddlScore7.Items.Add(lstdd7);
                }

                //Parameter 8
                txtScoringRange8.Text = dsPopulateScoreScaleRange.Tables[0].Rows[7][0].ToString() + "-" + dsPopulateScoreScaleRange.Tables[0].Rows[7][1].ToString();
                lblScoringRangeDecription8.Text = dsPopulateScoreScaleRange.Tables[0].Rows[6][2].ToString();

                for (int i = Convert.ToInt32(dsPopulateScoreScaleRange.Tables[0].Rows[7][0]); i <= Convert.ToInt32(dsPopulateScoreScaleRange.Tables[0].Rows[7][1]); i++)
                {
                    ListItem lstdd8 = new ListItem();
                    lstdd8.Text = i.ToString();
                    lstdd8.Value = i.ToString();
                    ddlScore8.Items.Add(lstdd8);
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

        private void EnableDisableControlsByDesignation()
        {
            if (_intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.DeliveryDirector) || _intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.DeliveryManager) || _intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.DeliveryManagerSPoC))
            {
                ddlscore1.Enabled = true;
                ddlScore3.Enabled = true;

                txtDescription1.Enabled = true;
                txtDescription3.Enabled = true;
                btnSave.Visible = true;
                btnSave.CausesValidation = false;

                if (txtDescription2.Text == string.Empty || txtDescription4.Text == string.Empty || txtDescription5.Text == string.Empty || txtDescription6.Text == string.Empty || txtDecription7.Text == string.Empty || txtDescription8.Text == string.Empty)
                {
                    ddlscore1.Enabled = false;
                    ddlScore3.Enabled = false;
                    txtDescription1.Enabled = false;
                    txtDescription3.Enabled = false;
                    lblHeaderMsg.Text = "Sales SPOC has not submitted yet";
                    btnSave.Visible = false;
                }

                string _strOppNumber = (string)Session["Oppid"];
                DataSet dsGetValueNotification = new BLL.AutomatedMailBLL().GetValueEmailNotificationSent(_strOppNumber);

                if (dsGetValueNotification.Tables.Count > 0)
                {
                    if (dsGetValueNotification.Tables[0].Rows.Count > 0)
                    {
                        if (dsGetValueNotification.Tables[0].Rows[0][1].ToString().Trim() == "False")
                        {

                            ddlscore1.Enabled = false;
                            ddlScore3.Enabled = false;
                            txtDescription1.Enabled = false;
                            txtDescription3.Enabled = false;
                            lblHeaderMsg.Text = "Sales SPOC has not submitted yet";
                            btnSave.Visible = false;

                        }

                        if (dsGetValueNotification.Tables[0].Rows[0][1].ToString().Trim() == "True")
                        {
                            ddlscore1.Enabled = true;
                            ddlScore3.Enabled = true;
                            txtDescription1.Enabled = true;
                            txtDescription3.Enabled = true;
                            btnSave.Visible = true;

                        }
                    }
                }

                GetValueCheckNotification();
            }

            else if (_intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.PrimarySalesSPoc))
            {
                ddlscore2.Enabled = true;
                ddlScore4.Enabled = true;
                ddlScore5.Enabled = true;
                ddlScore6.Enabled = true;
                ddlScore7.Enabled = true;
                ddlScore8.Enabled = true;

                txtDescription2.Enabled = true;
                txtDescription4.Enabled = true;
                txtDescription5.Enabled = true;
                txtDescription6.Enabled = true;
                txtDecription7.Enabled = true;
                txtDescription8.Enabled = true;
                btnSave.Visible = true;

                GetValueCheckNotification();


            }

            if (_intDesignation != clsDesignationList.GetDesignationID(EnumDesignation.PrimarySalesSPoc) && _intDesignation != clsDesignationList.GetDesignationID(EnumDesignation.DeliveryDirector) && _intDesignation != clsDesignationList.GetDesignationID(EnumDesignation.DeliveryManager) && _intDesignation != clsDesignationList.GetDesignationID(EnumDesignation.DeliveryManagerSPoC))
            {
                btnSave.Visible = false;
            }
        }

        private void Disablecontrolsonsubmit()
        {
            btnSave.Visible = false;
            ddlscore1.Enabled = false;
            ddlscore2.Enabled = false;
            ddlScore3.Enabled = false;
            ddlScore4.Enabled = false;
            ddlScore5.Enabled = false;
            ddlScore6.Enabled = false;
            ddlScore7.Enabled = false;
            ddlScore8.Enabled = false;
            txtDescription1.Enabled = false;
            txtDescription2.Enabled = false;
            txtDescription3.Enabled = false;
            txtDescription4.Enabled = false;
            txtDescription5.Enabled = false;
            txtDescription6.Enabled = false;
            txtDecription7.Enabled = false;
            txtDescription8.Enabled = false;
        }

        //Automated mail to Delivery to send scores and inputs.

        private void GetStakeholderstoNotifyDelivery()
        {
            try
            {
                string _strEmailSender = string.Empty;
                string _strDeliveryManagerName = string.Empty;
                string _strDeliveryManagerEmail = string.Empty;
                string _strBidManagerEmail = string.Empty;
                string _strDeliverySpocManagerName = string.Empty;
                string _strDeliverySpocManagerEmail = string.Empty;
                string _strDeliveryHeadName = string.Empty;
                string _strDeliveryHeadEmail = string.Empty;
                string _strEmailBody = string.Empty;

                DataSet dsetStakeholdersDetails = new BLL.AutomatedMailBLL().getStakeholdersbyOppNumberforDeliveryNotification((string)Session["Oppid"]);
                if (dsetStakeholdersDetails.Tables.Count > 0)
                {
                    if (dsetStakeholdersDetails.Tables[0].Rows.Count > 0)
                    {
                        _strEmailSender = dsetStakeholdersDetails.Tables[0].Rows[0][1].ToString();
                        if (dsetStakeholdersDetails.Tables[3].Rows.Count > 0)
                        {
                            _strDeliverySpocManagerName = dsetStakeholdersDetails.Tables[3].Rows[0][0].ToString();
                            _strDeliverySpocManagerEmail = dsetStakeholdersDetails.Tables[3].Rows[0][1].ToString();
                        }

                         if (dsetStakeholdersDetails.Tables[2].Rows.Count > 0)
                        {
                            _strDeliveryManagerName = dsetStakeholdersDetails.Tables[2].Rows[0][0].ToString();
                            _strDeliveryManagerEmail = dsetStakeholdersDetails.Tables[2].Rows[0][1].ToString();
                        }
                         if (dsetStakeholdersDetails.Tables[1].Rows.Count > 0)
                        {
                            _strDeliveryHeadName = dsetStakeholdersDetails.Tables[1].Rows[0][0].ToString();
                            _strDeliveryHeadEmail = dsetStakeholdersDetails.Tables[1].Rows[0][1].ToString();
                        }

                        if (dsetStakeholdersDetails.Tables[4].Rows.Count > 0)
                        {
                            _strBidManagerEmail = dsetStakeholdersDetails.Tables[4].Rows[0][1].ToString();
                        }
                    }
                }

                
                //string _strEmailServer = "cas2.syntelorg.com";
                if (_strDeliverySpocManagerName != string.Empty)
                {
                    _strEmailBody = "<html><body><div style='border:1px solid black;padding:10px;font-family:arial'> Dear " + _strDeliverySpocManagerName + " ";
                }
                else if (_strDeliveryManagerName != string.Empty)
                {
                    _strEmailBody = "<html><body><div style='border:1px solid black;padding:10px;font-family:arial'> Dear " + _strDeliveryManagerName + " ";
                }
                else
                {
                    _strEmailBody = "<html><body><div style='border:1px solid black;padding:10px;font-family:arial'> Dear " + _strDeliveryHeadName + " ";
                }
                _strEmailBody += "</br>";
                _strEmailBody += "</br>";
                _strEmailBody += "<p style='colr:red;'>Opportunity Qualification inputs and score is pending from your side.</p> ";
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

                MailMessage clsMailMessage;

                if (_strDeliverySpocManagerEmail != string.Empty)
                {
                     clsMailMessage = new MailMessage(fromAddress.ToString(), _strDeliverySpocManagerEmail, "Automated Mail for Delivery", _strEmailBody);
                     clsMailMessage.CC.Add(_strDeliveryManagerEmail);
                     clsMailMessage.CC.Add(_strDeliveryHeadEmail);
                }
                else if (_strDeliveryManagerEmail != string.Empty)
                {
                     clsMailMessage = new MailMessage(fromAddress.ToString(), _strDeliveryManagerEmail, "Automated Mail for Delivery", _strEmailBody);
                     clsMailMessage.CC.Add(_strDeliveryHeadEmail);
                }
                else
                {
                     clsMailMessage = new MailMessage(fromAddress.ToString(), _strDeliveryHeadEmail, "Automated Mail for Delivery", _strEmailBody);
                }

                

                clsMailMessage.IsBodyHtml = true;
                clsMailMessage.CC.Add(_strBidManagerEmail);
                clsMailMessage.CC.Add(_strEmailSender);

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
            catch (Exception ex)
            {
                string _strErrorMessage = string.Format("{0}", ex.Message.ToString());

                var cleanChars = _strErrorMessage.Where(c => !"\n\r".Contains(c));
                string cleanText = new string(cleanChars.ToArray());

                Response.Redirect("/frmErrorPage.aspx?ErrorMessage=" + cleanText);
            }
        }

        //Automated mail to BUHead approval

        private void GetStakeholderstoNotifyBUHeadApproval()
        {
            try
            {
                //Local variables for Email
                string _strEmailSender = string.Empty;
                string _strEmailRecipient = string.Empty;
                string _strBidMnagerEmail = string.Empty;
                string _strSaleEmail = string.Empty;
                string _strNameRecipient = string.Empty;
                string _strOppNumber = (string)Session["Oppid"];

                //Call method to execute Stored procedure
                DataSet dsetStakeHoldersDetails = new BLL.AutomatedMailBLL().getStakeholdersbyOppNumberforBUHeadApprovalNotification((string)Session["Oppid"]);

                if (dsetStakeHoldersDetails.Tables.Count > 0)
                {
                    if (dsetStakeHoldersDetails.Tables[2].Rows.Count > 0)
                    {
                        _strEmailSender = dsetStakeHoldersDetails.Tables[2].Rows[0][1].ToString();
                    }
                    else if (dsetStakeHoldersDetails.Tables[1].Rows.Count > 0)
                    {
                        _strEmailSender = dsetStakeHoldersDetails.Tables[1].Rows[0][1].ToString();
                    }
                    else if (dsetStakeHoldersDetails.Tables[0].Rows.Count > 0)
                    {
                        _strEmailSender = dsetStakeHoldersDetails.Tables[0].Rows[0][1].ToString();
                    }

                    if (dsetStakeHoldersDetails.Tables[3].Rows.Count > 0)
                    {
                        _strNameRecipient = dsetStakeHoldersDetails.Tables[3].Rows[0][0].ToString();
                        _strEmailRecipient = dsetStakeHoldersDetails.Tables[3].Rows[0][1].ToString();
                    }

                    if (dsetStakeHoldersDetails.Tables[4].Rows.Count > 0)
                    {
                        _strBidMnagerEmail = dsetStakeHoldersDetails.Tables[4].Rows[0][1].ToString();
                    }
                    if (dsetStakeHoldersDetails.Tables[5].Rows.Count > 0)
                    {
                        _strSaleEmail = dsetStakeHoldersDetails.Tables[5].Rows[0][1].ToString();
                    }
                }

                //string _strEmailServer = "cas2.syntelorg.com";
                string _strEmailBody = "<html><body><div style='border:1px solid black;padding:10px;font-family:arial'> Dear " + _strNameRecipient + " ";
                _strEmailBody += "</br>";
                _strEmailBody += "</br>";
                _strEmailBody += "<p style='colr:red;'>Opportunity Qualification inputs and score is completed for Opportunity number " + _strOppNumber + ". Please approve the Opportunity</p> ";
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


                // Attachment myAttachment = new Attachment(?C:\\Users\\\H007\\Desktop\\Test.txt?);

                var fromAddress = new MailAddress(System.Web.Configuration.WebConfigurationManager.AppSettings["EmailFrom"],
               "Large Deal Framework");

                MailMessage clsMailMessage = new MailMessage(fromAddress.ToString(), _strEmailRecipient, "Automated Mail for Delivery", _strEmailBody);
                clsMailMessage.IsBodyHtml = true;
                clsMailMessage.CC.Add(_strBidMnagerEmail);
                clsMailMessage.CC.Add(_strSaleEmail);
                clsMailMessage.CC.Add(_strEmailSender);

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
            catch (Exception ex)
            {
                string _strErrorMessage = string.Format("{0}", ex.Message.ToString());

                var cleanChars = _strErrorMessage.Where(c => !"\n\r".Contains(c));
                string cleanText = new string(cleanChars.ToArray());

                Response.Redirect("/frmErrorPage.aspx?ErrorMessage=" + cleanText);
            }


        }



        private void GetValueCheckNotification()
        {
            string _strOppNumber = (string)Session["Oppid"];
            DataSet dsGetValueNotification = new BLL.AutomatedMailBLL().GetValueEmailNotificationSent(_strOppNumber);

            QualificationDetailsBO clsQuaDetailsClientsDemand = new QualificationDetailsBO();
            clsQuaDetailsClientsDemand.OppNumber = (string)Session["Oppid"];
            clsQuaDetailsClientsDemand.ParaID = Constants._intEmotionalParaID;

            DataSet dsPopulateClientsDemand = new BLL.ScoreOppQuaBLL().GetScoreDescriptionForParameterScreen1(clsQuaDetailsClientsDemand);

            //Screen2
            QualificationDetailsBO clsQuaDetailsSyntelBusiness = new QualificationDetailsBO();
            clsQuaDetailsSyntelBusiness.OppNumber = (string)Session["Oppid"];
            clsQuaDetailsSyntelBusiness.ParaID = Constants._intInitialRevenueParaID;

            DataSet dsPopulateSyntelBusiness = new BLL.ScoreOppQuaBLL().GetScoreDescriptionForParameterScreen1(clsQuaDetailsSyntelBusiness);

            //Screen3
            QualificationDetailsBO clsQuaDetailsClientUrgency = new QualificationDetailsBO();
            clsQuaDetailsClientUrgency.OppNumber = (string)Session["Oppid"];
            clsQuaDetailsClientUrgency.ParaID = Constants._intHowMuchParaID;

            DataSet dsPopulateClientUrgency = new BLL.ScoreOppQuaBLL().GetScoreDescriptionForParameterScreen1(clsQuaDetailsClientUrgency);

            //Screen4
            QualificationDetailsBO clsQuaDetailsSyntelCompetitive = new QualificationDetailsBO();
            clsQuaDetailsSyntelCompetitive.OppNumber = (string)Session["Oppid"];
            clsQuaDetailsSyntelCompetitive.ParaID = Constants._intSolutionAdvantageParaID;

            DataSet dsPopulateSyntelCompetitive = new BLL.ScoreOppQuaBLL().GetScoreDescriptionForParameterScreen1(clsQuaDetailsSyntelCompetitive);

            if (_intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.PrimarySalesSPoc))
            {
                if (dsGetValueNotification.Tables.Count > 0 && dsGetValueNotification.Tables[0].Rows.Count > 0)
                {
                    if (dsGetValueNotification.Tables[0].Rows[0][1].ToString().Trim() == "False")
                    {
                        if (dsPopulateClientsDemand.Tables[0].Rows.Count == 2 &&
                            (dsPopulateSyntelBusiness.Tables[0].Rows.Count == 5 || dsPopulateSyntelBusiness.Tables[0].Rows.Count == 7) &&
                            dsPopulateClientUrgency.Tables[0].Rows.Count == 4 &&
                            (dsPopulateSyntelCompetitive.Tables[0].Rows.Count == 6 || dsPopulateSyntelCompetitive.Tables[0].Rows.Count == 8))
                        {
                            btnSendNotification.Visible = true;
                        }
                    }
                    else
                    {
                        if (dsPopulateClientsDemand.Tables[0].Rows.Count == 2 &&
                          (dsPopulateSyntelBusiness.Tables[0].Rows.Count == 5 || dsPopulateSyntelBusiness.Tables[0].Rows.Count == 7) &&
                          dsPopulateClientUrgency.Tables[0].Rows.Count == 4 &&
                          (dsPopulateSyntelCompetitive.Tables[0].Rows.Count == 6 || dsPopulateSyntelCompetitive.Tables[0].Rows.Count == 8))
                        {
                            btnSubmit.Visible = false;
                            btnSave.Visible = false;
                            Disablecontrolsonsubmit();
                        }

                    }
                }
                  QualificationDetailsBO clsQuaDetailsBO = new QualificationDetailsBO();
                    clsQuaDetailsBO.OppNumber = (string)Session["Oppid"];
                    DataSet dsPopulateallScreens = new BLL.ScoreOppQuaBLL().GetScoreDescriptionParameterforAllScreens(clsQuaDetailsBO);

                    if (dsPopulateallScreens.Tables.Count > 0 && dsPopulateallScreens.Tables[0].Rows.Count == 21)
                    {
                        btnSubmit.Visible = false;
                        btnSave.Visible = false;
                        Disablecontrolsonsubmit();
                    }

                  
            }

            else if (_intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.DeliveryDirector) || _intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.DeliveryManager) || _intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.DeliveryManagerSPoC))
            {
                btnSendNotification.Visible = false;
                if (dsGetValueNotification.Tables.Count > 0 && dsGetValueNotification.Tables[0].Rows[0][1].ToString().Trim() == "True")
                {
                    QualificationDetailsBO clsQuaDetailsBO = new QualificationDetailsBO();
                    clsQuaDetailsBO.OppNumber = (string)Session["Oppid"];
                    DataSet dsPopulateallScreens = new BLL.ScoreOppQuaBLL().GetScoreDescriptionParameterforAllScreens(clsQuaDetailsBO);

                    if (dsPopulateallScreens.Tables.Count > 0)
                    {
                        if (dsPopulateallScreens.Tables[0].Rows.Count == 0)
                        {
                            btnSave.Visible = true;
                        }
                        else
                        {
                            Disablecontrolsonsubmit();
                            btnSave.Visible = false;
                        }
                    }
                }

                    DataSet dsGetStatusValue = new BLL.ScoreOppQuaBLL().GetOpportunityQualificationDetails((string)Session["Oppid"]);
                    if (dsGetStatusValue.Tables.Count > 0)
                    {
                        if (dsGetStatusValue.Tables[0].Rows.Count > 0)
                        {
                            if (dsGetStatusValue.Tables[0].Rows[0][4].ToString().Trim() == "Not Approved")
                            {
                                ddlscore1.Enabled = true;
                                ddlScore3.Enabled = true;

                                txtDescription1.Enabled = true;
                                txtDescription3.Enabled = true;

                                btnSave.Visible = true;
                                btnSubmit.Visible = true;


                            }

                        }
                    }
                }
            

        }

        private void CheckNotificationSent(QualificationDetailsBO qualificationDetailsBO)
        {
            DataSet dsEmailNotification = new BLL.AutomatedMailBLL().AddEmailNotificationSent(qualificationDetailsBO);
        }

        private void EnableControlsforEditingNotApproved()
        {
            DataSet dsGetStatusValue = new BLL.ScoreOppQuaBLL().GetOpportunityQualificationDetails((string)Session["Oppid"]);
            DataSet dsGetValueNotification = new BLL.AutomatedMailBLL().GetValueEmailNotificationSent((string)Session["Oppid"]);
            if (dsGetStatusValue.Tables.Count > 0)
            {
                if (dsGetStatusValue.Tables[0].Rows.Count > 0)
                {
                    if (dsGetStatusValue.Tables[0].Rows[0][4].ToString().Trim() == "Not Approved" && dsGetValueNotification.Tables[0].Rows[0][1].ToString().Trim() == "True")
                    {
                        if (_intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.PrimarySalesSPoc))
                        {
                            btnSave.Visible = true;
                            ddlScore3.Enabled = true;
                            ddlScore4.Enabled = true;
                            ddlScore5.Enabled = true;
                            ddlScore6.Enabled = true;
                            ddlScore7.Enabled = true;
                            ddlScore8.Enabled = true;
                            txtDescription3.Enabled = true;
                            txtDescription4.Enabled = true;
                            txtDescription5.Enabled = true;
                            txtDescription6.Enabled = true;
                            txtDecription7.Enabled = true;
                            txtDescription8.Enabled = true;
                            txtDecription7.Enabled = true;
                        }

                        if (_intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.DeliveryDirector) || _intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.DeliveryManager) || _intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.DeliveryManagerSPoC))
                        {
                            btnSave.Visible = true;
                            ddlscore1.Enabled = true;
                            ddlScore3.Enabled = true;
                            txtDescription1.Enabled = true;
                            txtDescription3.Enabled = true;
                        }
                    }
                }
            }
        }

        #endregion

        #region events for control

        protected void btnAccountQualification_Click(object sender, EventArgs e)
        {
            if (Session["totalScoreScreen4"] != null)
            {
                Response.Redirect("FrmQualificationmain.aspx?TotalScoreScreen4=" + hidScoreSyntelCompetitive.Value);
            }
            else
            {
                Response.Redirect("FrmQualificationmain.aspx");
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmClientsUrgencytoBuy.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ScoreOppQuaBLL clsScoreOppQuaBLL = new ScoreOppQuaBLL();
                DisplayDescriptiononScore();
                txtTotalScore.Text = hidScoreSyntelCompetitive.Value;
                int _intTotalScoreScreen4 = Convert.ToInt32(hidScoreSyntelCompetitive.Value);
                Session["totalScoreScreen4"] = _intTotalScoreScreen4;

                string _strErrorMsg = null;
                //When Delivery director person is logged in 
                if ((_intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.DeliveryDirector) || _intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.DeliveryManager) || _intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.DeliveryManagerSPoC))
                    && (hidSaveClickbyDD.Value == "true" || hidSaveClickbyDD.Value == "false"))
                {
                    if (string.IsNullOrWhiteSpace(txtDescription3.Text) || string.IsNullOrWhiteSpace(txtDescription1.Text))
                    {
                        if (string.IsNullOrWhiteSpace(txtDescription3.Text))
                        {
                            _strErrorMsg = "Please enter description for Solution Advantage";

                        }
                        if (string.IsNullOrWhiteSpace(txtDescription1.Text))
                        {
                            if (_strErrorMsg != string.Empty)
                            {
                                _strErrorMsg = _strErrorMsg + "</br>" + "Please enter description for Value Proposition Advantge";
                            }
                            else
                                _strErrorMsg = "Please enter description for Value Proposition Advantge";

                        }
                        lblMsg.Text = _strErrorMsg;
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                        lblMsg.Font.Size = 10;

                    }
                    else
                    {
                        if ((_intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.DeliveryDirector) || _intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.DeliveryManager) || _intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.DeliveryManagerSPoC))
                            && hidSaveClickbyDD.Value == "true")
                        {
                            QualificationDetailsBO clsSolutionAdvantageBO = new QualificationDetailsBO();
                            clsSolutionAdvantageBO.Score = Convert.ToInt32(ddlscore1.SelectedValue);
                            clsSolutionAdvantageBO.ParaDescription = para1.Text;
                            clsSolutionAdvantageBO.ParaID = Constants._intSolutionAdvantageParaID;
                            clsSolutionAdvantageBO.Description = txtDescription1.Text;
                            clsSolutionAdvantageBO.OppNumber = (string)Session["Oppid"];

                            QualificationDetailsBO clsValuePropositionAdvantgeBO = new QualificationDetailsBO();
                            clsValuePropositionAdvantgeBO.Score = Convert.ToInt32(ddlScore3.SelectedValue);
                            clsValuePropositionAdvantgeBO.ParaDescription = para3.Text;
                            clsValuePropositionAdvantgeBO.ParaID = Constants._intValuePropositionAdvantgeParaID;
                            clsValuePropositionAdvantgeBO.Description = txtDescription3.Text;
                            clsValuePropositionAdvantgeBO.OppNumber = (string)Session["Oppid"];

                            clsScoreOppQuaBLL.AddScoreDescriptionOppQua(clsSolutionAdvantageBO);
                            clsScoreOppQuaBLL.AddScoreDescriptionOppQua(clsValuePropositionAdvantgeBO);

                            hidSaveClickbyDD.Value = "false";
                            lblMsg.Text = "Saved successfully!!!";
                            lblMsg.ForeColor = System.Drawing.Color.Green;
                            lblMsg.Font.Size = 10;
                        }


                        else if ((_intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.DeliveryDirector) || _intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.DeliveryManager) || _intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.DeliveryManagerSPoC))
                            && hidSaveClickbyDD.Value == "false")
                        {
                            QualificationDetailsBO clsSolutionAdvantageBO = new QualificationDetailsBO();
                            clsSolutionAdvantageBO.Score = Convert.ToInt32(ddlscore1.SelectedValue);
                            clsSolutionAdvantageBO.ParaDescription = para1.Text;
                            clsSolutionAdvantageBO.ParaID = Constants._intSolutionAdvantageParaID;
                            clsSolutionAdvantageBO.Description = txtDescription1.Text;
                            clsSolutionAdvantageBO.OppNumber = (string)Session["Oppid"];

                            QualificationDetailsBO clsValuePropositionAdvantgeBO = new QualificationDetailsBO();
                            clsValuePropositionAdvantgeBO.Score = Convert.ToInt32(ddlScore3.SelectedValue);
                            clsValuePropositionAdvantgeBO.ParaDescription = para3.Text;
                            clsValuePropositionAdvantgeBO.ParaID = Constants._intValuePropositionAdvantgeParaID;
                            clsValuePropositionAdvantgeBO.Description = txtDescription3.Text;
                            clsValuePropositionAdvantgeBO.OppNumber = (string)Session["Oppid"];

                            clsScoreOppQuaBLL.UpdateScoreDescriptionParameter(clsSolutionAdvantageBO);
                            clsScoreOppQuaBLL.UpdateScoreDescriptionParameter(clsValuePropositionAdvantgeBO);

                            GetValueCheckNotification();

                            lblMsg.Text = "Updated successfully!!!";
                            lblMsg.ForeColor = System.Drawing.Color.Green;
                            lblMsg.Font.Size = 10;
                        }
                    }
                }

                //When sales person is logged in 
                if (_intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.PrimarySalesSPoc) && hidSaveClickbySale.Value == "true")
                {

                    QualificationDetailsBO clsCompetitorAdvantageBO = new QualificationDetailsBO();
                    clsCompetitorAdvantageBO.Score = Convert.ToInt32(ddlscore2.SelectedValue);
                    clsCompetitorAdvantageBO.ParaDescription = para2.Text;
                    clsCompetitorAdvantageBO.ParaID = Constants._intCompetitorParaID;
                    clsCompetitorAdvantageBO.Description = txtDescription2.Text;
                    clsCompetitorAdvantageBO.OppNumber = (string)Session["Oppid"];

                    QualificationDetailsBO clsCompetitorValuePropositionAdvantgeBO = new QualificationDetailsBO();
                    clsCompetitorValuePropositionAdvantgeBO.Score = Convert.ToInt32(ddlScore4.SelectedValue);
                    clsCompetitorValuePropositionAdvantgeBO.ParaDescription = para4.Text;
                    clsCompetitorValuePropositionAdvantgeBO.ParaID = Constants._intCompetitorValuePropositionParaID;
                    clsCompetitorValuePropositionAdvantgeBO.Description = txtDescription4.Text;
                    clsCompetitorValuePropositionAdvantgeBO.OppNumber = (string)Session["Oppid"];

                    QualificationDetailsBO clsRelationshipStrengthBO = new QualificationDetailsBO();
                    clsRelationshipStrengthBO.Score = Convert.ToInt32(ddlScore5.SelectedValue);
                    clsRelationshipStrengthBO.ParaDescription = para5.Text;
                    clsRelationshipStrengthBO.ParaID = Constants._intRelationshipStrengthParaID;
                    clsRelationshipStrengthBO.Description = txtDescription5.Text;
                    clsRelationshipStrengthBO.OppNumber = (string)Session["Oppid"];

                    QualificationDetailsBO clsCompetitorRelationshipStrengthBO = new QualificationDetailsBO();
                    clsCompetitorRelationshipStrengthBO.Score = Convert.ToInt32(ddlScore6.SelectedValue);
                    clsCompetitorRelationshipStrengthBO.ParaDescription = para6.Text;
                    clsCompetitorRelationshipStrengthBO.ParaID = Constants._intCompetitorRelationshipStrengthParaID;
                    clsCompetitorRelationshipStrengthBO.Description = txtDescription6.Text;
                    clsCompetitorRelationshipStrengthBO.OppNumber = (string)Session["Oppid"];

                    QualificationDetailsBO ExtraAdvantageBO = new QualificationDetailsBO();
                    ExtraAdvantageBO.Score = Convert.ToInt32(ddlScore7.SelectedValue);
                    ExtraAdvantageBO.ParaDescription = para7.Text;
                    ExtraAdvantageBO.ParaID = Constants._intExtraAdvantageParaID;
                    ExtraAdvantageBO.Description = txtDecription7.Text;
                    ExtraAdvantageBO.OppNumber = (string)Session["Oppid"];

                    QualificationDetailsBO clsCompetitorExtraAdvantageBO = new QualificationDetailsBO();
                    clsCompetitorExtraAdvantageBO.Score = Convert.ToInt32(ddlScore8.SelectedValue);
                    clsCompetitorExtraAdvantageBO.ParaDescription = para8.Text;
                    clsCompetitorExtraAdvantageBO.ParaID = Constants._intCompetitorExtraAdvantageParaID;
                    clsCompetitorExtraAdvantageBO.Description = txtDescription8.Text;
                    clsCompetitorExtraAdvantageBO.OppNumber = (string)Session["Oppid"];

                    //Inserted in database
                    clsScoreOppQuaBLL.AddScoreDescriptionOppQua(clsCompetitorAdvantageBO);
                    clsScoreOppQuaBLL.AddScoreDescriptionOppQua(clsCompetitorValuePropositionAdvantgeBO);
                    clsScoreOppQuaBLL.AddScoreDescriptionOppQua(clsRelationshipStrengthBO);
                    clsScoreOppQuaBLL.AddScoreDescriptionOppQua(clsCompetitorRelationshipStrengthBO);
                    clsScoreOppQuaBLL.AddScoreDescriptionOppQua(ExtraAdvantageBO);
                    clsScoreOppQuaBLL.AddScoreDescriptionOppQua(clsCompetitorExtraAdvantageBO);

                    QualificationDetailsBO clsqualificationDetailsBO = new QualificationDetailsBO();
                    clsqualificationDetailsBO.OppNumber = (string)Session["Oppid"];
                    clsqualificationDetailsBO.IsNotify = false;
                    CheckNotificationSent(clsqualificationDetailsBO);
                    GetValueCheckNotification();

                    hidSaveClickbySale.Value = "false";
                    lblMsg.Text = "Saved successfully!!!";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    lblMsg.Font.Size = 10;

                }
                else if (_intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.PrimarySalesSPoc) && hidSaveClickbySale.Value == "false")
                {

                    QualificationDetailsBO clsCompetitorAdvantageBO = new QualificationDetailsBO();
                    clsCompetitorAdvantageBO.Score = Convert.ToInt32(ddlscore2.SelectedValue);
                    clsCompetitorAdvantageBO.ParaDescription = para2.Text;
                    clsCompetitorAdvantageBO.ParaID = Constants._intCompetitorParaID;
                    clsCompetitorAdvantageBO.Description = txtDescription2.Text;
                    clsCompetitorAdvantageBO.OppNumber = (string)Session["Oppid"];

                    QualificationDetailsBO clsCompetitorValuePropositionAdvantgeBO = new QualificationDetailsBO();
                    clsCompetitorValuePropositionAdvantgeBO.Score = Convert.ToInt32(ddlScore4.SelectedValue);
                    clsCompetitorValuePropositionAdvantgeBO.ParaDescription = para4.Text;
                    clsCompetitorValuePropositionAdvantgeBO.ParaID = Constants._intCompetitorValuePropositionParaID;
                    clsCompetitorValuePropositionAdvantgeBO.Description = txtDescription4.Text;
                    clsCompetitorValuePropositionAdvantgeBO.OppNumber = (string)Session["Oppid"];

                    QualificationDetailsBO clsRelationshipStrengthBO = new QualificationDetailsBO();
                    clsRelationshipStrengthBO.Score = Convert.ToInt32(ddlScore5.SelectedValue);
                    clsRelationshipStrengthBO.ParaDescription = para5.Text;
                    clsRelationshipStrengthBO.ParaID = Constants._intRelationshipStrengthParaID;
                    clsRelationshipStrengthBO.Description = txtDescription5.Text;
                    clsRelationshipStrengthBO.OppNumber = (string)Session["Oppid"];

                    QualificationDetailsBO clsCompetitorRelationshipStrengthBO = new QualificationDetailsBO();
                    clsCompetitorRelationshipStrengthBO.Score = Convert.ToInt32(ddlScore6.SelectedValue);
                    clsCompetitorRelationshipStrengthBO.ParaDescription = para6.Text;
                    clsCompetitorRelationshipStrengthBO.ParaID = Constants._intCompetitorRelationshipStrengthParaID;
                    clsCompetitorRelationshipStrengthBO.Description = txtDescription6.Text;
                    clsCompetitorRelationshipStrengthBO.OppNumber = (string)Session["Oppid"];

                    QualificationDetailsBO clsExtraAdvantageBO = new QualificationDetailsBO();
                    clsExtraAdvantageBO.Score = Convert.ToInt32(ddlScore7.SelectedValue);
                    clsExtraAdvantageBO.ParaDescription = para7.Text;
                    clsExtraAdvantageBO.ParaID = Constants._intExtraAdvantageParaID;
                    clsExtraAdvantageBO.Description = txtDecription7.Text;
                    clsExtraAdvantageBO.OppNumber = (string)Session["Oppid"];

                    QualificationDetailsBO clsCompetitorExtraAdvantageBO = new QualificationDetailsBO();
                    clsCompetitorExtraAdvantageBO.Score = Convert.ToInt32(ddlScore8.SelectedValue);
                    clsCompetitorExtraAdvantageBO.ParaDescription = para8.Text;
                    clsCompetitorExtraAdvantageBO.ParaID = Constants._intCompetitorExtraAdvantageParaID;
                    clsCompetitorExtraAdvantageBO.Description = txtDescription8.Text;
                    clsCompetitorExtraAdvantageBO.OppNumber = (string)Session["Oppid"];

                    //Updated in database
                    clsScoreOppQuaBLL.UpdateScoreDescriptionParameter(clsCompetitorAdvantageBO);
                    clsScoreOppQuaBLL.UpdateScoreDescriptionParameter(clsCompetitorValuePropositionAdvantgeBO);
                    clsScoreOppQuaBLL.UpdateScoreDescriptionParameter(clsRelationshipStrengthBO);
                    clsScoreOppQuaBLL.UpdateScoreDescriptionParameter(clsCompetitorRelationshipStrengthBO);
                    clsScoreOppQuaBLL.UpdateScoreDescriptionParameter(clsExtraAdvantageBO);
                    clsScoreOppQuaBLL.UpdateScoreDescriptionParameter(clsCompetitorExtraAdvantageBO);

                    QualificationDetailsBO clsQualificationDetailsBO = new QualificationDetailsBO();
                    clsQualificationDetailsBO.OppNumber = (string)Session["Oppid"];
                    clsQualificationDetailsBO.IsNotify = false;
                    CheckNotificationSent(clsQualificationDetailsBO);
                    GetValueCheckNotification();

                    lblMsg.Text = "Updated successfully!!!";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    lblMsg.Font.Size = 10;
                }

                //Enable submit button when data is saved in all screens
                DataSet dsEnableSubmit = new DataSet();
                dsEnableSubmit = EnableSubmitbutton();
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

            this.hidUpdateValue.Value = "false";
            this.HidCounter.Value = "1";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                ScoreOppQuaBLL clsScoreOppQuaBLL = new ScoreOppQuaBLL();

                DataSet dsEnableSubmit = new DataSet();
                dsEnableSubmit = EnableSubmitbutton();

                for (int i = 0; i < dsEnableSubmit.Tables[0].Rows.Count; i++)
                {
                    QualificationDetailsBO clsQualificationDetails = new QualificationDetailsBO();
                    clsQualificationDetails.OppNumber = (string)Session["Oppid"];
                    clsQualificationDetails.ParaID = Convert.ToInt32(dsEnableSubmit.Tables[0].Rows[i][0].ToString());
                    clsQualificationDetails.ParaDescription = dsEnableSubmit.Tables[0].Rows[i][1].ToString();
                    clsQualificationDetails.Score = Convert.ToInt32(dsEnableSubmit.Tables[0].Rows[i][2].ToString());
                    clsQualificationDetails.Description = dsEnableSubmit.Tables[0].Rows[i][3].ToString();

                    clsScoreOppQuaBLL.AddScoreDescriptionOppQuaforAllScreens(clsQualificationDetails);
                }
                lblMsg.Text = "Submitted Sucessfully!!!";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                lblMsg.Font.Size = 10;
                btnSubmit.Visible = false;
                btnSave.Visible = false;
                Disablecontrolsonsubmit();

                GetStakeholderstoNotifyBUHeadApproval();


                DataSet dsGetStatusValue = new BLL.ScoreOppQuaBLL().GetOpportunityQualificationDetails((string)Session["Oppid"]);
                if (dsGetStatusValue.Tables.Count > 0)
                {
                    if (dsGetStatusValue.Tables[0].Rows.Count > 0)
                    {
                        if (dsGetStatusValue.Tables[0].Rows[0][4].ToString().Trim() == "Not Approved")
                        {
                            string _strReSubmitByDD = "true";
                            Session["valReSubmitbyDD"] = _strReSubmitByDD.Trim();
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

        #endregion

        protected void btnSendNotification_Click(object sender, EventArgs e)
        {
            try
            {
                GetStakeholderstoNotifyDelivery();
                lblMsg.Text = "Submitted Sucessfully!!!";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                lblMsg.Font.Size = 10;
                btnSave.Visible = false;
                btnSendNotification.Visible = false;

                DataSet dsGetStatusValue = new BLL.ScoreOppQuaBLL().GetOpportunityQualificationDetails((string)Session["Oppid"]);
                if (dsGetStatusValue.Tables.Count > 0)
                {
                    if (dsGetStatusValue.Tables[0].Rows.Count > 0)
                    {
                        if (dsGetStatusValue.Tables[0].Rows[0][4].ToString().Trim() == "Not Approved")
                        {
                            string _strReSubmitBySales = "true";
                            Session["valReSubmitbySales"] = _strReSubmitBySales.Trim();
                        }
                    }
                }
                QualificationDetailsBO qualificationDetailsBO = new QualificationDetailsBO();
                qualificationDetailsBO.OppNumber = (string)Session["Oppid"];
                qualificationDetailsBO.IsNotify = true;
                CheckNotificationSent(qualificationDetailsBO);
                GetValueCheckNotification();
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
