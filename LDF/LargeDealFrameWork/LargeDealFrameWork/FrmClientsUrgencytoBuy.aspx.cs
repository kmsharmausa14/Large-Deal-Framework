
/* ---------------------------------------------------------------------------------------------------------------
 * Project Name : Large Deal Type
 * Module Name : Opportunity Qualification
 * Program Version : 1.0.0
 * Filename : ClientsUrgencyToBuy.aspx.cs
 * Purpose : This page allows Sales person to enter score and description for parameters. 
 * ----------------------------------------------------------------------------------------------------------------
 * MODIFICATION HISTORY:
 * ----------------------------------------------------------------------------------------------------------------
 * PHASE    AUTHOR                 DATE          MODIFICATION           DESCRIPTION
 *                              (MM/DD/YYYY)     DETAILS
 * ----------------------------------------------------------------------------------------------------------------
 *   1.    PRIYANKA DATIR        12/18/2013      CREATED                NONE  
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
    public partial class ClientsUrgencytoBuy : System.Web.UI.Page
    {
        int _intDesignation = 0;

        #region page load

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
                    PopulateClientsUrgency();

                    //Save button is disabled once submitted
                    DisableSaveButton();

                    //Controls enabled-disabled for different users
                    EnableDisableControlsByDesignation();

                    //Decription aceepting 250 characters
                    this.txtDescription1.Attributes.Add("onkeypress", "return ValidateDescription('" + this.txtDescription1.ClientID + "')");
                    this.txtDescription2.Attributes.Add("onkeypress", "return ValidateDescription('" + this.txtDescription2.ClientID + "')");
                    this.txtDescription3.Attributes.Add("onkeypress", "return ValidateDescription('" + this.txtDescription3.ClientID + "')");
                    this.txtDescription4.Attributes.Add("onkeypress", "return ValidateDescription('" + this.txtDescription4.ClientID + "')");

                    this.txtDescription1.Attributes.Add("onchange", "update()");
                    this.txtDescription2.Attributes.Add("onchange", "update()");
                    this.txtDescription3.Attributes.Add("onchange", "update()");
                    this.txtDescription4.Attributes.Add("onchange", "update()");
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
        //Disable save button once finally submitted
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
                            btnSave.Visible = false;
                            ddlscore1.Enabled = false;
                            ddlscore2.Enabled = false;
                            ddlScore3.Enabled = false;
                            ddlScore4.Enabled = false;
                            txtDescription1.Enabled = false;
                            txtDescription2.Enabled = false;
                            txtDescription3.Enabled = false;
                            txtDescription4.Enabled = false;
                        }
                    }
            }
            catch (Exception ex)
            {
                string _strErrorMessage = ex.Message;
                Response.Redirect("/frmErrorPage.aspx?ErrorMessage=" + _strErrorMessage);
            }

        }

        //Populate score and description if already exists
        private void PopulateClientsUrgency()
        {
            try
            {
                QualificationDetailsBO clsQuaDetailsBO = new QualificationDetailsBO();
                clsQuaDetailsBO.OppNumber = (string)Session["Oppid"];
                clsQuaDetailsBO.ParaID = Constants._intHowMuchParaID;

                DataSet dsPopulateClientsUrgency = new BLL.ScoreOppQuaBLL().GetScoreDescriptionForParameterScreen1(clsQuaDetailsBO);
                if (dsPopulateClientsUrgency.Tables.Count > 0)
                {
                    if (dsPopulateClientsUrgency.Tables[0].Rows.Count > 0)
                    {
                        hidInsertOpportunity.Value = "false";
                        ddlscore1.SelectedValue = dsPopulateClientsUrgency.Tables[0].Rows[0][2].ToString();
                        txtDescription1.Text = dsPopulateClientsUrgency.Tables[0].Rows[0][3].ToString();

                        ddlscore2.SelectedValue = dsPopulateClientsUrgency.Tables[0].Rows[1][2].ToString();
                        txtDescription2.Text = dsPopulateClientsUrgency.Tables[0].Rows[1][3].ToString();

                        ddlScore3.SelectedValue = dsPopulateClientsUrgency.Tables[0].Rows[2][2].ToString();
                        txtDescription3.Text = dsPopulateClientsUrgency.Tables[0].Rows[2][3].ToString();

                        ddlScore4.SelectedValue = dsPopulateClientsUrgency.Tables[0].Rows[3][2].ToString();
                        txtDescription4.Text = dsPopulateClientsUrgency.Tables[0].Rows[3][3].ToString();
                    }

                }
                hidscoreClientsUrgency.Value = (Convert.ToInt32(ddlscore1.SelectedValue) + Convert.ToInt32(ddlscore2.SelectedValue) + Convert.ToInt32(ddlScore3.SelectedValue) + Convert.ToInt32(ddlScore4.SelectedValue)).ToString();
                DisplayDescriptiononScore();
            }
            catch (Exception ex)
            {
                string _strErrorMessage = ex.Message;
                Response.Redirect("/frmErrorPage.aspx?ErrorMessage=" + _strErrorMessage);
            }

        }

        public void PopulateScaleScoreGridview()
        {
            try
            {
                DataSet dsPopulateActiveScoreScaleGridview = new BLL.ScoreOppQuaBLL().GetScoreOppQuaByActiveScreen3();
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

        //Display description on the basis of score
        private void DisplayDescriptiononScore()
        {
            try
            {
                List<ScoreOppQuaBO> lstScoreOppQuaBO = new List<ScoreOppQuaBO>();
                DataSet dsPopulateActiveScoreScaleGridview = new BLL.ScoreOppQuaBLL().GetScoreOppQuaByActiveScreen3();
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
                    string[] strArrNumber = clsScoreOppQuaBO.Scale.Split(new[] { '-' });

                    if (Convert.ToInt32(hidscoreClientsUrgency.Value) <= Convert.ToInt32(strArrNumber[1]))
                    {
                        if (Convert.ToInt32(hidscoreClientsUrgency.Value) >= Convert.ToInt32(strArrNumber[0]))
                        {
                            lblScoreDescription.Text = clsScoreOppQuaBO.Scale_Description;
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
                DataSet dsPopulateScoreScaleRange = new BLL.ScoreOppQuaBLL().GetScoreScaleDescriptionScreen3();

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

               
            }
            catch (Exception ex)
            {
                string _strErrorMessage = ex.Message;
                Response.Redirect("/frmErrorPage.aspx?ErrorMessage=" + _strErrorMessage);
            }
        }

        private void EnableDisableControlsByDesignation()
        {
            
            if (_intDesignation != clsDesignationList.GetDesignationID(EnumDesignation.PrimarySalesSPoc))
            {
                Disablecontrols();
            }

            else if (_intDesignation == clsDesignationList.GetDesignationID(EnumDesignation.PrimarySalesSPoc))
            {
                EnableControls();
                GetValueCheckNotification();
            }

           
        }

        private void GetValueCheckNotification()
        {
            string _strOppNumber = (string)Session["Oppid"];
            DataSet dsGetValueNotification = new BLL.AutomatedMailBLL().GetValueEmailNotificationSent(_strOppNumber);
            DataSet dsGetStatusValue = new BLL.ScoreOppQuaBLL().GetOpportunityQualificationDetails((string)Session["Oppid"]);

            if (dsGetValueNotification.Tables.Count > 0)
            {
                if (dsGetValueNotification.Tables[0].Rows.Count > 0)
                {

                    if (dsGetValueNotification.Tables[0].Rows[0][1].ToString().Trim() == "True")
                    {
                        Disablecontrols();
                    }

                    else if (dsGetValueNotification.Tables[0].Rows[0][1].ToString().Trim() == "False")
                    {
                        EnableControls();
                    }
                }
            }

            string _strReSubmitBySales = string.Empty;
            if (Session["valReSubmitbySales"] != null)
            {
                _strReSubmitBySales = (string)Session["valReSubmitbySales"];
            }
            else
                _strReSubmitBySales = "false";

            if (dsGetStatusValue.Tables.Count > 0)
            {
                if (dsGetStatusValue.Tables[0].Rows.Count > 0)
                {
                    if (dsGetStatusValue.Tables[0].Rows[0][4].ToString().Trim() == "Not Approved")
                    {
                        if (_strReSubmitBySales.Trim() == "false")
                        {
                            EnableControls();
                        }
                        else
                        {
                            Disablecontrols();
                        }
                    }
                    else 
                    {
                        Disablecontrols();
                    }
                    
                }
            }
        }

        private void Disablecontrols()
        {
            btnSave.Visible = false;
            ddlscore1.Enabled = false;
            ddlscore2.Enabled = false;
            ddlScore3.Enabled = false;
            ddlScore4.Enabled = false;
            txtDescription1.Enabled = false;
            txtDescription2.Enabled = false;
            txtDescription3.Enabled = false;
            txtDescription4.Enabled = false;
        }

        private void EnableControls()
        {

            btnSave.Visible = true;
            ddlscore1.Enabled = true;
            ddlscore2.Enabled = true;
            ddlScore3.Enabled = true;
            ddlScore4.Enabled = true;
            txtDescription1.Enabled = true;
            txtDescription2.Enabled = true;
            txtDescription3.Enabled = true;
            txtDescription4.Enabled = true;
        }
    

        #endregion

        #region Events for controls

        protected void btnAccountQualification_Click(object sender, EventArgs e)
        {
            if (Session["totalScoreScreen3"] != null)
            {
                Response.Redirect("FrmQualificationmain.aspx?TotalScoreScreen3=" + hidscoreClientsUrgency.Value);
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
                txtTotalScore.Text = hidscoreClientsUrgency.Value;
                int totalScoreScreen3 = Convert.ToInt32(hidscoreClientsUrgency.Value);
                Session["totalScoreScreen3"] = totalScoreScreen3;

                if (hidInsertOpportunity.Value == "true")
                {
                    QualificationDetailsBO clsHowMuchBO = new QualificationDetailsBO();
                    clsHowMuchBO.Score = Convert.ToInt32(ddlscore1.SelectedValue);
                    clsHowMuchBO.ParaDescription = para1.Text;
                    clsHowMuchBO.ParaID = Constants._intHowMuchParaID;
                    clsHowMuchBO.Description = txtDescription1.Text;
                    clsHowMuchBO.OppNumber = (string)Session["Oppid"];

                    QualificationDetailsBO clsHowSoonBO = new QualificationDetailsBO();
                    clsHowSoonBO.Score = Convert.ToInt32(ddlscore2.SelectedValue);
                    clsHowSoonBO.ParaDescription = para2.Text;
                    clsHowSoonBO.ParaID = Constants._intHowSoonParaID;
                    clsHowSoonBO.Description = txtDescription2.Text;
                    clsHowSoonBO.OppNumber = (string)Session["Oppid"];

                    QualificationDetailsBO clsHowSureBO = new QualificationDetailsBO();
                    clsHowSureBO.Score = Convert.ToInt32(ddlScore3.SelectedValue);
                    clsHowSureBO.ParaDescription = para3.Text;
                    clsHowSureBO.ParaID = Constants._intHowSureParaID;
                    clsHowSureBO.Description = txtDescription3.Text;
                    clsHowSureBO.OppNumber = (string)Session["Oppid"];

                    QualificationDetailsBO clsHowReadyBO = new QualificationDetailsBO();
                    clsHowReadyBO.Score = Convert.ToInt32(ddlScore4.SelectedValue);
                    clsHowReadyBO.ParaDescription = para4.Text;
                    clsHowReadyBO.ParaID = Constants._intHowReadyParaID;
                    clsHowReadyBO.Description = txtDescription4.Text;
                    clsHowReadyBO.OppNumber = (string)Session["Oppid"];

                    //Inserted in database
                    clsScoreOppQuaBLL.AddScoreDescriptionOppQua(clsHowMuchBO);
                    clsScoreOppQuaBLL.AddScoreDescriptionOppQua(clsHowSoonBO);
                    clsScoreOppQuaBLL.AddScoreDescriptionOppQua(clsHowSureBO);
                    clsScoreOppQuaBLL.AddScoreDescriptionOppQua(clsHowReadyBO);

                    hidInsertOpportunity.Value = "false";
                    lblmsg.Text = "Saved successfully!!!";
                }
                else if (hidInsertOpportunity.Value == "false")
                {

                    QualificationDetailsBO clsHowMuchBO = new QualificationDetailsBO();
                    clsHowMuchBO.Score = Convert.ToInt32(ddlscore1.SelectedValue);
                    clsHowMuchBO.ParaDescription = para1.Text;
                    clsHowMuchBO.ParaID = Constants._intHowMuchParaID;
                    clsHowMuchBO.Description = txtDescription1.Text;
                    clsHowMuchBO.OppNumber = (string)Session["Oppid"];

                    QualificationDetailsBO clsHowSoonBO = new QualificationDetailsBO();
                    clsHowSoonBO.Score = Convert.ToInt32(ddlscore2.SelectedValue);
                    clsHowSoonBO.ParaDescription = para2.Text;
                    clsHowSoonBO.ParaID = Constants._intHowSoonParaID;
                    clsHowSoonBO.Description = txtDescription2.Text;
                    clsHowSoonBO.OppNumber = (string)Session["Oppid"];

                    QualificationDetailsBO clsHowSureBO = new QualificationDetailsBO();
                    clsHowSureBO.Score = Convert.ToInt32(ddlScore3.SelectedValue);
                    clsHowSureBO.ParaDescription = para3.Text;
                    clsHowSureBO.ParaID = Constants._intHowSureParaID;
                    clsHowSureBO.Description = txtDescription3.Text;
                    clsHowSureBO.OppNumber = (string)Session["Oppid"];

                    QualificationDetailsBO clsHowReadyBO = new QualificationDetailsBO();
                    clsHowReadyBO.Score = Convert.ToInt32(ddlScore4.SelectedValue);
                    clsHowReadyBO.ParaDescription = para4.Text;
                    clsHowReadyBO.ParaID = Constants._intHowReadyParaID;
                    clsHowReadyBO.Description = txtDescription4.Text;
                    clsHowReadyBO.OppNumber = (string)Session["Oppid"];

                    //Update
                    clsScoreOppQuaBLL.UpdateScoreDescriptionParameter(clsHowMuchBO);
                    clsScoreOppQuaBLL.UpdateScoreDescriptionParameter(clsHowSoonBO);
                    clsScoreOppQuaBLL.UpdateScoreDescriptionParameter(clsHowSureBO);
                    clsScoreOppQuaBLL.UpdateScoreDescriptionParameter(clsHowReadyBO);

                    lblmsg.Text = "Updated successfully!!!";
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

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmSyntelBusinessPriorityScale.aspx");
           
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmSyntelsCompetitiveAdvantage.aspx");
         
        }

        #endregion
    }
}
