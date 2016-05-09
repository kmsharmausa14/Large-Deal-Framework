
/* ---------------------------------------------------------------------------------------------------------------
 * Project Name : Large Deal Type
 * Module Name : Opportunity Qualification
 * Program Version : 1.0.0
 * Filename : FrmSyntelBusinessPriorityScale.aspx.cs
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

namespace LargeDealFrameWork
{
    public partial class SyntelBusinessPriorityScale : System.Web.UI.Page
    {
        #region page load

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
                    //Populate score and description gridview
                    PopulateScaleScoreGridview();

                    //Populate description on the basis of description
                    PopulateScoreScaleDescription();

                    //Populate score and description if already exists
                    PopulateSyntelBusiness();

                    //Save button is disabled once submitted
                    DisableSaveButton();

                    //Controls enabled-disabled for different users
                    EnableDisableControlsByDesignation();

                    //Decription aceepting 250 characters
                    this.txtDescription1.Attributes.Add("onkeypress", "return ValidateDescription('" + this.txtDescription1.ClientID + "')");
                    this.txtDescription2.Attributes.Add("onkeypress", "return ValidateDescription('" + this.txtDescription2.ClientID + "')");
                    this.txtDescription3.Attributes.Add("onkeypress", "return ValidateDescription('" + this.txtDescription3.ClientID + "')");
                    this.txtDescription4.Attributes.Add("onkeypress", "return ValidateDescription('" + this.txtDescription4.ClientID + "')");
                    this.txtDescription5.Attributes.Add("onkeypress", "return ValidateDescription('" + this.txtDescription5.ClientID + "')");
                    this.txtDescription6.Attributes.Add("onkeypress", "return ValidateDescription('" + this.txtDescription6.ClientID + "')");
                    this.txtDecription7.Attributes.Add("onkeypress", "return ValidateDescription('" + this.txtDecription7.ClientID + "')");

                    this.txtDescription1.Attributes.Add("onchange", "update()");
                    this.txtDescription2.Attributes.Add("onchange", "update()");
                    this.txtDescription3.Attributes.Add("onchange", "update()");
                    this.txtDescription4.Attributes.Add("onchange", "update()");
                    this.txtDescription5.Attributes.Add("onchange", "update()");
                    this.txtDescription6.Attributes.Add("onchange", "update()");
                    this.txtDecription7.Attributes.Add("onchange", "update()");

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

        private void DisableSaveButton()
        {
            try
            {
                QualificationDetailsBO clsQuaDetailsBO = new QualificationDetailsBO();
                clsQuaDetailsBO.OppNumber = (string)Session["Oppid"];
                DataSet dsPopulateallScreens = new BLL.ScoreOppQuaBLL().GetScoreDescriptionParameterforAllScreens(clsQuaDetailsBO);

                if (dsPopulateallScreens.Tables.Count > 0)
                {
                    if (dsPopulateallScreens.Tables[0].Rows.Count > 0)
                    {

                        hidDisablecontrolsOnSubmit.Value = "false";
                        Disablecontrolsonsubmit();
                    }
                }
            }
            catch (Exception ex)
            {
                string _strErrorMessage = ex.Message;
                Response.Redirect("/frmErrorPage.aspx?ErrorMessage=" + _strErrorMessage);
            }

        }

        private void PopulateSyntelBusiness()
        {
            try
            {
                QualificationDetailsBO clsQuaDetailsBO = new QualificationDetailsBO();
                clsQuaDetailsBO.OppNumber = (string)Session["Oppid"];
                clsQuaDetailsBO.ParaID = Constants._intInitialRevenueParaID;

                DataSet dsPopulateSyntelBusinessScreen = new BLL.ScoreOppQuaBLL().GetScoreDescriptionForParameterScreen1(clsQuaDetailsBO);
                if (dsPopulateSyntelBusinessScreen.Tables.Count > 0)
                {
                    if (dsPopulateSyntelBusinessScreen.Tables[0].Rows.Count > 0)
                    {
                        if (dsPopulateSyntelBusinessScreen.Tables[0].Rows.Count == 7)
                        {
                            hidSaveClickbyDD.Value = "false";
                            hidSaveClickbySale.Value = "false";
                            ddlscore1.SelectedValue = dsPopulateSyntelBusinessScreen.Tables[0].Rows[0][2].ToString();
                            txtDescription1.Text = dsPopulateSyntelBusinessScreen.Tables[0].Rows[0][3].ToString();

                            ddlscore2.SelectedValue = dsPopulateSyntelBusinessScreen.Tables[0].Rows[1][2].ToString();
                            txtDescription2.Text = dsPopulateSyntelBusinessScreen.Tables[0].Rows[1][3].ToString();

                            ddlScore3.SelectedValue = dsPopulateSyntelBusinessScreen.Tables[0].Rows[2][2].ToString();
                            txtDescription3.Text = dsPopulateSyntelBusinessScreen.Tables[0].Rows[2][3].ToString();

                            ddlScore4.SelectedValue = dsPopulateSyntelBusinessScreen.Tables[0].Rows[3][2].ToString();
                            txtDescription4.Text = dsPopulateSyntelBusinessScreen.Tables[0].Rows[3][3].ToString();


                            ddlScore5.SelectedValue = dsPopulateSyntelBusinessScreen.Tables[0].Rows[4][2].ToString();
                            txtDescription5.Text = dsPopulateSyntelBusinessScreen.Tables[0].Rows[4][3].ToString();

                            ddlScore6.SelectedValue = dsPopulateSyntelBusinessScreen.Tables[0].Rows[5][2].ToString();
                            txtDescription6.Text = dsPopulateSyntelBusinessScreen.Tables[0].Rows[5][3].ToString();

                            ddlScore7.SelectedValue = dsPopulateSyntelBusinessScreen.Tables[0].Rows[6][2].ToString();
                            txtDecription7.Text = dsPopulateSyntelBusinessScreen.Tables[0].Rows[6][3].ToString();
                        }
                        if (dsPopulateSyntelBusinessScreen.Tables[0].Rows.Count == 5)
                        {
                            hidSaveClickbySale.Value = "false";

                            ddlscore1.SelectedValue = dsPopulateSyntelBusinessScreen.Tables[0].Rows[0][2].ToString();
                            txtDescription1.Text = dsPopulateSyntelBusinessScreen.Tables[0].Rows[0][3].ToString();

                            ddlscore2.SelectedValue = dsPopulateSyntelBusinessScreen.Tables[0].Rows[1][2].ToString();
                            txtDescription2.Text = dsPopulateSyntelBusinessScreen.Tables[0].Rows[1][3].ToString();

                            ddlScore5.SelectedValue = dsPopulateSyntelBusinessScreen.Tables[0].Rows[2][2].ToString();
                            txtDescription5.Text = dsPopulateSyntelBusinessScreen.Tables[0].Rows[2][3].ToString();

                            ddlScore6.SelectedValue = dsPopulateSyntelBusinessScreen.Tables[0].Rows[3][2].ToString();
                            txtDescription6.Text = dsPopulateSyntelBusinessScreen.Tables[0].Rows[3][3].ToString();

                            ddlScore7.SelectedValue = dsPopulateSyntelBusinessScreen.Tables[0].Rows[4][2].ToString();
                            txtDecription7.Text = dsPopulateSyntelBusinessScreen.Tables[0].Rows[4][3].ToString();
                        }
                    }

                }
                hidScoreSyntelBusiness.Value = (Convert.ToInt32(ddlscore1.SelectedValue) + Convert.ToInt32(ddlscore2.SelectedValue)
                                         + Convert.ToInt32(ddlScore3.SelectedValue) + Convert.ToInt32(ddlScore4.SelectedValue)
                                          + Convert.ToInt32(ddlScore5.SelectedValue) + Convert.ToInt32(ddlScore6.SelectedValue)
                                          + Convert.ToInt32(ddlScore7.SelectedValue)).ToString();
                DisplayDescriptiononScore();
            }
            catch (Exception ex)
            {
                string _strErrorMessage = ex.Message;
                Response.Redirect("/frmErrorPage.aspx?ErrorMessage=" + _strErrorMessage);
            }

        }

        private void PopulateScaleScoreGridview()
        {
            try
            {
                DataSet dsPopulateActiveScoreScaleGridview = new BLL.ScoreOppQuaBLL().GetScoreOppQuaByActiveScreen2();
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
                string _strErrorMessage = ex.Message;
                Response.Redirect("/frmErrorPage.aspx?ErrorMessage=" + _strErrorMessage);
            }
        }

        private void DisplayDescriptiononScore()
        {
            try
            {
                List<ScoreOppQuaBO> lstScoreOppQuaBO = new List<ScoreOppQuaBO>();
                DataSet dsPopulateActiveScoreScaleGridview = new BLL.ScoreOppQuaBLL().GetScoreOppQuaByActiveScreen2();
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
                foreach (ScoreOppQuaBO scoreOppQuaBO in lstScoreOppQuaBO)
                {
                    string[] _strArrNumber = scoreOppQuaBO.Scale.Split(new[] { '-' });

                    if (Convert.ToInt32(hidScoreSyntelBusiness.Value) <= Convert.ToInt32(_strArrNumber[1]))
                    {
                        if (Convert.ToInt32(hidScoreSyntelBusiness.Value) >= Convert.ToInt32(_strArrNumber[0]))
                        {
                            lblScoreDescription.Text = scoreOppQuaBO.Scale_Description;
                        }
                    }

                }
            }

            catch (Exception ex)
            {
                string _strErrorMessage = ex.Message;
                Response.Redirect("/frmErrorPage.aspx?ErrorMessage=" + _strErrorMessage);
            }
        }

        private void PopulateScoreScaleDescription()
        {
            try
            {
                DataSet dsPopulateScoreScaleRange = new BLL.ScoreOppQuaBLL().GetScoreScaleDescriptionScreen2();

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
            }
            catch (Exception ex)
            {
                string _strErrorMessage = ex.Message;
                Response.Redirect("/frmErrorPage.aspx?ErrorMessage=" + _strErrorMessage);
            }
        }

        private void EnableDisableControlsByDesignation()
        {
            if (hidDisablecontrolsOnSubmit.Value == "true")
            {
                string _strNotify = string.Empty;
                string _strOppNumber = (string)Session["Oppid"];
                DataSet dsGetValueNotification = new BLL.AutomatedMailBLL().GetValueEmailNotificationSent(_strOppNumber);

                if (dsGetValueNotification.Tables.Count > 0)
                {
                    if (dsGetValueNotification.Tables[0].Rows.Count > 0)
                    {
                        if (dsGetValueNotification.Tables[0].Rows[0][1].ToString() != string.Empty)
                        {
                            _strNotify = dsGetValueNotification.Tables[0].Rows[0][1].ToString();
                        }
                        
                    }
                    else
                        _strNotify = "False";
                }
                else
                    _strNotify = "False";

                if (_intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.DeliveryDirector) || _intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.DeliveryManager) || _intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.DeliveryManagerSPoC))
                {
                    ddlScore3.Enabled = true;
                    ddlScore4.Enabled = true;
                    txtDescription3.Enabled = true;
                    txtDescription4.Enabled = true;
                    btnSave.CausesValidation = false;

                    if (txtDescription1.Text == string.Empty || txtDescription2.Text == string.Empty || txtDescription2.Text == string.Empty || txtDescription2.Text == string.Empty)
                    {
                        ddlScore3.Enabled = false;
                        ddlScore4.Enabled = false;
                        txtDescription3.Enabled = false;
                        txtDescription4.Enabled = false;
                        lblHeaderMsg.Text = "Sales SPOC has not submitted yet";
                        btnSave.Visible = false;
                    }



                    if (_strNotify.Trim() == "False")
                    {
                        ddlScore3.Enabled = false;
                        ddlScore4.Enabled = false;
                        txtDescription3.Enabled = false;
                        txtDescription4.Enabled = false;
                        lblHeaderMsg.Text = "Sales SPOC has not submitted yet";
                        btnSave.Visible = false;

                    }

                    else if (_strNotify.Trim() == "True")
                    {
                        ddlScore3.Enabled = true;
                        ddlScore4.Enabled = true;
                        txtDescription3.Enabled = true;
                        txtDescription4.Enabled = true;
                        btnSave.Visible = true;
                        btnSave.CausesValidation = false;
                    }
                }

                else if (_intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.PrimarySalesSPoc))
                {
                    if (_strNotify.Trim() == "False")
                    {
                        ddlscore1.Enabled = true;
                        ddlscore2.Enabled = true;
                        ddlScore5.Enabled = true;
                        ddlScore6.Enabled = true;
                        ddlScore7.Enabled = true;

                        txtDescription1.Enabled = true;
                        txtDescription2.Enabled = true;
                        txtDescription5.Enabled = true;
                        txtDescription6.Enabled = true;
                        txtDecription7.Enabled = true;
                    }
                    else
                    {
                        Disablecontrolsonsubmit();
                    }
                }
            }

            GetValueCheckNotification();
            if (_intDesignation != clsDesignationList.GetDesignationID(EnumDesignation.PrimarySalesSPoc) && _intDesignation != clsDesignationList.GetDesignationID(EnumDesignation.DeliveryDirector) 
                && _intDesignation != clsDesignationList.GetDesignationID(EnumDesignation.DeliveryManager) && _intDesignation != clsDesignationList.GetDesignationID(EnumDesignation.DeliveryManagerSPoC))
            {
                btnSave.Visible = false;
            }

        }

        private void GetValueCheckNotification()
        {
            try
            {

                string _strOppNumber = (string)Session["Oppid"];
                DataSet dsGetValueNotification = new BLL.AutomatedMailBLL().GetValueEmailNotificationSent(_strOppNumber);
                DataSet dsGetStatusValue = new BLL.ScoreOppQuaBLL().GetOpportunityQualificationDetails((string)Session["Oppid"]);

                string _strReSubmitBySales = string.Empty;
                if (Session["valReSubmitbySales"] != null)
                {
                    _strReSubmitBySales = (string)Session["valReSubmitbySales"];
                }
                else
                    _strReSubmitBySales = "false";

                string _strReSubmitByDD = string.Empty;
                if (Session["valReSubmitbyDD"] != null)
                {
                    _strReSubmitByDD = (string)Session["valReSubmitbyDD"];
                }
                else
                    _strReSubmitByDD = "false";


                if (dsGetStatusValue.Tables.Count > 0)
                {
                    if (dsGetStatusValue.Tables[0].Rows.Count > 0)
                    {
                        if (dsGetStatusValue.Tables[0].Rows[0][4].ToString().Trim() == "Not Approved")
                        {
                            if (_strReSubmitBySales.Trim() == "false" && _strReSubmitByDD.Trim() == "false")
                            {
                                EnableControls();
                            }

                            else if (_strReSubmitBySales.Trim() == "true" && _strReSubmitByDD.Trim() == "true")
                            {
                                Disablecontrolsonsubmit();
                            }
                            else if (_strReSubmitBySales.Trim() == "true" && _strReSubmitByDD.Trim() == "false")
                            {
                                //Disablecontrolsonsubmit();
                                if (_intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.PrimarySalesSPoc))
                                {
                                    btnSave.Visible = false;
                                    ddlscore1.Enabled = false;
                                    ddlscore2.Enabled = false;
                                    ddlScore5.Enabled = false;
                                    ddlScore6.Enabled = false;
                                    ddlScore7.Enabled = false;
                                    txtDescription1.Enabled = false;
                                    txtDescription2.Enabled = false;
                                    txtDescription5.Enabled = false;
                                    txtDescription6.Enabled = false;
                                    txtDecription7.Enabled = false;
                                }

                                if (_intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.DeliveryDirector) || _intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.DeliveryManager) || _intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.DeliveryManagerSPoC))
                                {
                                    btnSave.Visible = true;
                                    ddlScore3.Enabled = true;
                                    ddlScore4.Enabled = true;
                                    txtDescription3.Enabled = true;
                                    txtDescription4.Enabled = true;
                                    btnSave.CausesValidation = false;
                                }
                            }
                            else if (_strReSubmitBySales.Trim() == "false" && _strReSubmitByDD.Trim() == "true")
                            {
                                if (_intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.PrimarySalesSPoc))
                                {
                                    btnSave.Visible = true;
                                    ddlscore1.Enabled = true;
                                    ddlscore2.Enabled = true;
                                    ddlScore5.Enabled = true;
                                    ddlScore6.Enabled = true;
                                    ddlScore7.Enabled = true;
                                    txtDescription1.Enabled = true;
                                    txtDescription2.Enabled = true;
                                    txtDescription5.Enabled = true;
                                    txtDescription6.Enabled = true;
                                    txtDecription7.Enabled = true;
                                    btnSave.CausesValidation = false;
                                }

                                if (_intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.DeliveryDirector) || _intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.DeliveryManager) || _intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.DeliveryManagerSPoC))
                                {
                                    btnSave.Visible = false;
                                    ddlScore3.Enabled = false;
                                    ddlScore4.Enabled = false;
                                    txtDescription3.Enabled = false;
                                    txtDescription4.Enabled = false;
                                   
                                }
                            }

                        }
                        else if (dsGetStatusValue.Tables[0].Rows[0][4].ToString().Trim() == "Approved" || dsGetStatusValue.Tables[0].Rows[0][4].ToString().Trim() == "No Go")
                        {
                            Disablecontrolsonsubmit();
                        }
                        
                        else
                        {
                            EnableControls();
                        }
                        // if (dsGetStatusValue.Tables[0].Rows[0][4].ToString().Trim() == "Not Approved" &&
                        //    (_strReSubmitBySales.Trim() == "false" && _strReSubmitByDD.Trim() == "false"))
                        //{
                        //    EnableControls();
                        //}
                        //else
                        //{
                        //    if (dsGetStatusValue.Tables[0].Rows[0][4].ToString().Trim() == "Not Approved" &&
                        //       (_strReSubmitBySales.Trim() == "true" && _strReSubmitByDD.Trim() == "true"))
                        //    {
                        //        Disablecontrolsonsubmit();
                        //    }
                        //    if (dsGetStatusValue.Tables[0].Rows[0][4].ToString().Trim() == "Not Approved" &&
                        //      (_strReSubmitBySales.Trim() == "true" || _strReSubmitByDD.Trim() == "false"))
                        //    {
                        //        Disablecontrolsonsubmit();
                        //    }
                        //    if (dsGetStatusValue.Tables[0].Rows[0][4].ToString().Trim() == "Not Approved" &&
                        //      (_strReSubmitBySales.Trim() == "false" || _strReSubmitByDD.Trim() == "true"))
                        //    {
                        //        Disablecontrolsonsubmit();
                        //    }
                        //}

                    }
                }
            }
            catch (Exception ex)
            {
                string _strErrorMessage = ex.Message;
                Response.Redirect("/frmErrorPage.aspx?ErrorMessage=" + _strErrorMessage);
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
            txtDescription1.Enabled = false;
            txtDescription2.Enabled = false;
            txtDescription3.Enabled = false;
            txtDescription4.Enabled = false;
            txtDescription5.Enabled = false;
            txtDescription6.Enabled = false;
            txtDecription7.Enabled = false;
        }

        private void EnableControls()
        {
            if (_intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.PrimarySalesSPoc))
            {
                btnSave.Visible = true;
                ddlscore1.Enabled = true;
                ddlscore2.Enabled = true;
                ddlScore5.Enabled = true;
                ddlScore6.Enabled = true;
                ddlScore7.Enabled = true;
                txtDescription1.Enabled = true;
                txtDescription2.Enabled = true;
                txtDescription5.Enabled = true;
                txtDescription6.Enabled = true;
                txtDecription7.Enabled = true;
            }

            if (_intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.DeliveryDirector) || _intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.DeliveryManager) || _intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.DeliveryManagerSPoC))
            {
                btnSave.Visible = true;
                ddlScore3.Enabled = true;
                ddlScore4.Enabled = true;
                txtDescription3.Enabled = true;
                txtDescription4.Enabled = true;
                btnSave.CausesValidation = false;
            }
        }





        #endregion

        #region Events for control

        protected void btnAccountQualification_Click(object sender, EventArgs e)
        {
            if (Session["totalScoreScreen2"] != null)
            {
                Response.Redirect("FrmQualificationmain.aspx?TotalScoreScreen2=" + hidScoreSyntelBusiness.Value);
            }
            else
            {
                Response.Redirect("FrmQualificationmain.aspx");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ScoreOppQuaBLL clsScoreOppQuaBLL = new ScoreOppQuaBLL();
                DisplayDescriptiononScore();
                txtTotalScore.Text = hidScoreSyntelBusiness.Value;
                int totalScoreScreen2 = Convert.ToInt32(hidScoreSyntelBusiness.Value);
                Session["totalScoreScreen2"] = totalScoreScreen2;
                string _strErrorMsg = string.Empty;

                if ((_intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.DeliveryDirector) || _intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.DeliveryManager) || _intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.DeliveryManagerSPoC))
                    && (hidSaveClickbyDD.Value == "true" || hidSaveClickbyDD.Value == "false"))
                {
                    if (string.IsNullOrWhiteSpace(txtDescription3.Text) || string.IsNullOrWhiteSpace(txtDescription4.Text))
                    {
                        if (string.IsNullOrWhiteSpace(txtDescription3.Text))
                        {
                            _strErrorMsg = "Please enter description for Risk";

                        }
                        if (string.IsNullOrWhiteSpace(txtDescription4.Text))
                        {
                            if (_strErrorMsg != string.Empty)
                            {
                                _strErrorMsg = _strErrorMsg + "</br>" + "Please enter description for Profitability";
                            }
                            else
                                _strErrorMsg = "Please enter description for Profitability";
                            lblMsg.Text = _strErrorMsg;
                            lblMsg.ForeColor = System.Drawing.Color.Red;
                            lblMsg.Font.Size = 10;
                        }

                    }
                    else
                    {
                        if ((_intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.DeliveryDirector) || _intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.DeliveryManager) || _intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.DeliveryManagerSPoC))
                            && hidSaveClickbyDD.Value == "true")
                        {
                            QualificationDetailsBO clsRiskBO = new QualificationDetailsBO();
                            clsRiskBO.Score = Convert.ToInt32(ddlScore3.SelectedValue);
                            clsRiskBO.ParaDescription = para3.Text;
                            clsRiskBO.ParaID = Constants._intRiskParaID;
                            clsRiskBO.Description = txtDescription3.Text;
                            clsRiskBO.OppNumber = (string)Session["Oppid"];

                            QualificationDetailsBO clsProfitabilityBO = new QualificationDetailsBO();
                            clsProfitabilityBO.Score = Convert.ToInt32(ddlScore4.SelectedValue);
                            clsProfitabilityBO.ParaDescription = para4.Text;
                            clsProfitabilityBO.ParaID = Constants._intProfitabilityParaID;
                            clsProfitabilityBO.Description = txtDescription4.Text;
                            clsProfitabilityBO.OppNumber = (string)Session["Oppid"];

                            clsScoreOppQuaBLL.AddScoreDescriptionOppQua(clsRiskBO);
                            clsScoreOppQuaBLL.AddScoreDescriptionOppQua(clsProfitabilityBO);

                            hidSaveClickbyDD.Value = "false";
                            lblMsg.Text = "Saved successfully!!!";
                            lblMsg.ForeColor = System.Drawing.Color.Green;
                            lblMsg.Font.Size = 10;
                        }

                        else if ((_intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.DeliveryDirector) || _intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.DeliveryManager) || _intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.DeliveryManagerSPoC))
                            && hidSaveClickbyDD.Value == "false")
                        {
                            QualificationDetailsBO clsRiskBO = new QualificationDetailsBO();
                            clsRiskBO.Score = Convert.ToInt32(ddlScore3.SelectedValue);
                            clsRiskBO.ParaDescription = para3.Text;
                            clsRiskBO.ParaID = Constants._intRiskParaID;
                            clsRiskBO.Description = txtDescription3.Text;
                            clsRiskBO.OppNumber = (string)Session["Oppid"];

                            QualificationDetailsBO clsProfitabilityBO = new QualificationDetailsBO();
                            clsProfitabilityBO.Score = Convert.ToInt32(ddlScore4.SelectedValue);
                            clsProfitabilityBO.ParaDescription = para4.Text;
                            clsProfitabilityBO.ParaID = Constants._intProfitabilityParaID;
                            clsProfitabilityBO.Description = txtDescription4.Text;
                            clsProfitabilityBO.OppNumber = (string)Session["Oppid"];

                            clsScoreOppQuaBLL.UpdateScoreDescriptionParameter(clsRiskBO);
                            clsScoreOppQuaBLL.UpdateScoreDescriptionParameter(clsProfitabilityBO);

                            lblMsg.Text = "Updated successfully!!!";
                            lblMsg.ForeColor = System.Drawing.Color.Green;
                            lblMsg.Font.Size = 10;
                        }
                    }
                }

                if (_intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.PrimarySalesSPoc) && hidSaveClickbySale.Value == "true")
                {
                    try
                    {

                        QualificationDetailsBO clsInitialRevenueBO = new QualificationDetailsBO();
                        clsInitialRevenueBO.Score = Convert.ToInt32(ddlscore1.SelectedValue);
                        clsInitialRevenueBO.ParaDescription = para1.Text;
                        clsInitialRevenueBO.ParaID = Constants._intInitialRevenueParaID;
                        clsInitialRevenueBO.Description = txtDescription1.Text;
                        clsInitialRevenueBO.OppNumber = (string)Session["Oppid"];

                        QualificationDetailsBO clsPotentialRevenueBO = new QualificationDetailsBO();
                        clsPotentialRevenueBO.Score = Convert.ToInt32(ddlscore2.SelectedValue);
                        clsPotentialRevenueBO.ParaDescription = para2.Text;
                        clsPotentialRevenueBO.ParaID = Constants._intPotentialRevenueParaID;
                        clsPotentialRevenueBO.Description = txtDescription2.Text;
                        clsPotentialRevenueBO.OppNumber = (string)Session["Oppid"];


                        QualificationDetailsBO clsMarketPenetrationBO = new QualificationDetailsBO();
                        clsMarketPenetrationBO.Score = Convert.ToInt32(ddlScore5.SelectedValue);
                        clsMarketPenetrationBO.ParaDescription = para5.Text;
                        clsMarketPenetrationBO.ParaID = Constants._intMarketPenetrationParaID;
                        clsMarketPenetrationBO.Description = txtDescription5.Text;
                        clsMarketPenetrationBO.OppNumber = (string)Session["Oppid"];

                        QualificationDetailsBO clsMarketAdvantagesBO = new QualificationDetailsBO();
                        clsMarketAdvantagesBO.Score = Convert.ToInt32(ddlScore6.SelectedValue);
                        clsMarketAdvantagesBO.ParaDescription = para6.Text;
                        clsMarketAdvantagesBO.ParaID = Constants._intMarketAdvantagesParaID;
                        clsMarketAdvantagesBO.Description = txtDescription6.Text;
                        clsMarketAdvantagesBO.OppNumber = (string)Session["Oppid"];

                        QualificationDetailsBO clsNewSolutionBO = new QualificationDetailsBO();
                        clsNewSolutionBO.Score = Convert.ToInt32(ddlScore7.SelectedValue);
                        clsNewSolutionBO.ParaDescription = para7.Text;
                        clsNewSolutionBO.ParaID = Constants._intNewSolutionParaID;
                        clsNewSolutionBO.Description = txtDecription7.Text;
                        clsNewSolutionBO.OppNumber = (string)Session["Oppid"];

                        //Inserted in database
                        clsScoreOppQuaBLL.AddScoreDescriptionOppQua(clsInitialRevenueBO);
                        clsScoreOppQuaBLL.AddScoreDescriptionOppQua(clsPotentialRevenueBO);
                        clsScoreOppQuaBLL.AddScoreDescriptionOppQua(clsMarketPenetrationBO);
                        clsScoreOppQuaBLL.AddScoreDescriptionOppQua(clsMarketAdvantagesBO);
                        clsScoreOppQuaBLL.AddScoreDescriptionOppQua(clsNewSolutionBO);

                        hidSaveClickbySale.Value = "false";
                        lblMsg.Text = "Saved successfully!!!";
                        lblMsg.ForeColor = System.Drawing.Color.Green;
                        lblMsg.Font.Size = 10;
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
                else if (_intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.PrimarySalesSPoc) && hidSaveClickbySale.Value == "false")
                {
                    try
                    {
                        QualificationDetailsBO clsInitialRevenueBO = new QualificationDetailsBO();
                        clsInitialRevenueBO.Score = Convert.ToInt32(ddlscore1.SelectedValue);
                        clsInitialRevenueBO.ParaDescription = para1.Text;
                        clsInitialRevenueBO.ParaID = Constants._intInitialRevenueParaID;
                        clsInitialRevenueBO.Description = txtDescription1.Text;
                        clsInitialRevenueBO.OppNumber = (string)Session["Oppid"];

                        QualificationDetailsBO clsPotentialRevenueBO = new QualificationDetailsBO();
                        clsPotentialRevenueBO.Score = Convert.ToInt32(ddlscore2.SelectedValue);
                        clsPotentialRevenueBO.ParaDescription = para2.Text;
                        clsPotentialRevenueBO.ParaID = Constants._intPotentialRevenueParaID;
                        clsPotentialRevenueBO.Description = txtDescription2.Text;
                        clsPotentialRevenueBO.OppNumber = (string)Session["Oppid"];

                        QualificationDetailsBO clsMarketPenetrationBO = new QualificationDetailsBO();
                        clsMarketPenetrationBO.Score = Convert.ToInt32(ddlScore5.SelectedValue);
                        clsMarketPenetrationBO.ParaDescription = para5.Text;
                        clsMarketPenetrationBO.ParaID = Constants._intMarketPenetrationParaID;
                        clsMarketPenetrationBO.Description = txtDescription5.Text;
                        clsMarketPenetrationBO.OppNumber = (string)Session["Oppid"];

                        QualificationDetailsBO clsMarketAdvantagesBO = new QualificationDetailsBO();
                        clsMarketAdvantagesBO.Score = Convert.ToInt32(ddlScore6.SelectedValue);
                        clsMarketAdvantagesBO.ParaDescription = para6.Text;
                        clsMarketPenetrationBO.ParaID = Constants._intMarketAdvantagesParaID;
                        clsMarketAdvantagesBO.Description = txtDescription6.Text;
                        clsMarketAdvantagesBO.OppNumber = (string)Session["Oppid"];

                        QualificationDetailsBO clsNewSolutionBO = new QualificationDetailsBO();
                        clsNewSolutionBO.Score = Convert.ToInt32(ddlScore7.SelectedValue);
                        clsNewSolutionBO.ParaDescription = para7.Text;
                        clsNewSolutionBO.ParaID = Constants._intNewSolutionParaID;
                        clsNewSolutionBO.Description = txtDecription7.Text;
                        clsNewSolutionBO.OppNumber = (string)Session["Oppid"];

                        //Update in database
                        clsScoreOppQuaBLL.UpdateScoreDescriptionParameter(clsInitialRevenueBO);
                        clsScoreOppQuaBLL.UpdateScoreDescriptionParameter(clsPotentialRevenueBO);
                        clsScoreOppQuaBLL.UpdateScoreDescriptionParameter(clsMarketPenetrationBO);
                        clsScoreOppQuaBLL.UpdateScoreDescriptionParameter(clsMarketAdvantagesBO);
                        clsScoreOppQuaBLL.UpdateScoreDescriptionParameter(clsNewSolutionBO);


                        lblMsg.Text = "Updated successfully!!!";
                        lblMsg.ForeColor = System.Drawing.Color.Green;
                        lblMsg.Font.Size = 10;
                    }
                    catch (Exception ex)
                    {
                        string _strErrorMessage = ex.Message;
                        Response.Redirect("/frmErrorPage.aspx?ErrorMessage=" + _strErrorMessage);
                    }
                }
                this.hidUpdateValue.Value = "false";
                this.HidCounter.Value = "1";
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


        protected void btnNext_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmClientsUrgencytoBuy.aspx");

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmClientsDemandPresenceScale.aspx");
        }

        #endregion
    }
}
