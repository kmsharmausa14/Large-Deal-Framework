

/* ---------------------------------------------------------------------------------------------------------------
 * Project Name : Large Deal Type
 * Module Name : Opportunity Qualification
 * Program Version : 1.0.0
 * Filename : ClientsDemandPresenceScale.aspx.cs
 * Purpose : This page allows Sales person to enter score and description for parameters. 
 * ----------------------------------------------------------------------------------------------------------------
 * MODIFICATION HISTORY:
 * ----------------------------------------------------------------------------------------------------------------
 * PHASE    AUTHOR                 DATE          MODIFICATION           DESCRIPTION
 *                              (MM/DD/YYYY)     DETAILS
 * ----------------------------------------------------------------------------------------------------------------
 *   1.    PRIYANKA DATIR        12/10/2013      CREATED                NONE  
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BO;
using System.Collections;
using BLL;

namespace LargeDealFrameWork
{

    public partial class ClientDemandPressenceScale : System.Web.UI.Page
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
                    PopulateClientsDemand();

                    //Save button is disabled once submitted
                    DisableSaveButton();

                    //Controls enabled-disabled for different users
                    EnableDisableControlsByDesignation();

                    //Allow 250 characters for multiline textbox
                    this.txtDescription1.Attributes.Add("onkeypress", "return ValidateDescription('" + this.txtDescription1.ClientID + "')");
                    this.txtDescription2.Attributes.Add("onkeypress", "return ValidateDescription('" + this.txtDescription2.ClientID + "')");
                    this.txtDescription1.Attributes.Add("onchange", "update()");
                    this.txtDescription2.Attributes.Add("onchange", "update()");
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

        #region Private methods

        //Disable save button once finally submitted
        private void DisableSaveButton()
        {
            QualificationDetailsBO clsQuaDetailsBO = new QualificationDetailsBO();
            clsQuaDetailsBO.OppNumber = (string)Session["Oppid"];
            DataSet dsPopulateallScreen = new BLL.ScoreOppQuaBLL().GetScoreDescriptionParameterforAllScreens(clsQuaDetailsBO);

            if (dsPopulateallScreen.Tables.Count > 0)
            {
                if (dsPopulateallScreen.Tables[0].Rows.Count > 0)
                {
                    btnSave.Visible = false;
                    ddlscore1.Enabled = false;
                    ddlscore2.Enabled = false;
                    txtDescription1.Enabled = false;
                    txtDescription2.Enabled = false;
                }
            }
           
        }

        //Populate score and description if already exists
        private void PopulateClientsDemand()
        {
            try
            {
                QualificationDetailsBO clsQuaDetailsBO = new QualificationDetailsBO();
                clsQuaDetailsBO.OppNumber = (string)Session["Oppid"];
                clsQuaDetailsBO.ParaID = Constants._intEmotionalParaID;
                DataSet dsPopulateClientsDemand = new BLL.ScoreOppQuaBLL().GetScoreDescriptionForParameterScreen1(clsQuaDetailsBO);
                if (dsPopulateClientsDemand.Tables.Count > 0)
                {
                    if (dsPopulateClientsDemand.Tables[0].Rows.Count > 0)
                    {
                        hidSaveClick.Value = "false";
                        ddlscore1.SelectedValue = dsPopulateClientsDemand.Tables[0].Rows[0][2].ToString();
                        txtDescription1.Text = dsPopulateClientsDemand.Tables[0].Rows[0][3].ToString();

                        ddlscore2.SelectedValue = dsPopulateClientsDemand.Tables[0].Rows[1][2].ToString();
                        txtDescription2.Text = dsPopulateClientsDemand.Tables[0].Rows[1][3].ToString();
                    }
                }
                hidScoreClientsDemand.Value = (Convert.ToInt32(ddlscore1.SelectedValue) + Convert.ToInt32(ddlscore2.SelectedValue)).ToString();
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
                DataSet dsPopulateActiveScoreScaleGridview = new BLL.ScoreOppQuaBLL().GetScoreOppQuaByActiveScreen1();
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
                DataSet dsPopulateActiveScoreScaleGridview = new BLL.ScoreOppQuaBLL().GetScoreOppQuaByActiveScreen1();
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
                    int _intMinvalue = Convert.ToInt32(strArrNumber[0]);
                    int _intMaxvalue = Convert.ToInt32(strArrNumber[1]);
                    int _intCurrentvalue = Convert.ToInt32(hidScoreClientsDemand.Value);

                    if (_intCurrentvalue <= _intMaxvalue)
                    {
                        if (_intCurrentvalue >= _intMinvalue)
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
                DataSet dsPopulateScoreScaleRange = new BLL.ScoreOppQuaBLL().GetScoreScaleDescriptionScreen1();
                txtScoringRange1.Text = dsPopulateScoreScaleRange.Tables[0].Rows[0][0].ToString() + "-" + dsPopulateScoreScaleRange.Tables[0].Rows[0][1].ToString();
                lblScoringRangeDescription1.Text = dsPopulateScoreScaleRange.Tables[0].Rows[0][2].ToString();

                for (int i = Convert.ToInt32(dsPopulateScoreScaleRange.Tables[0].Rows[0][0]); i <= Convert.ToInt32(dsPopulateScoreScaleRange.Tables[0].Rows[0][1]); i++)
                {
                    ListItem lstdd1 = new ListItem();
                    lstdd1.Text = i.ToString();
                    lstdd1.Value = i.ToString();
                    ddlscore1.Items.Add(lstdd1);
                }

                txtScoringRange2.Text = dsPopulateScoreScaleRange.Tables[0].Rows[1][0].ToString() + "-" + dsPopulateScoreScaleRange.Tables[0].Rows[1][1].ToString();
                lblScoringRangeDescription2.Text = dsPopulateScoreScaleRange.Tables[0].Rows[1][2].ToString();

                for (int i = Convert.ToInt32(dsPopulateScoreScaleRange.Tables[0].Rows[1][0]); i <= Convert.ToInt32(dsPopulateScoreScaleRange.Tables[0].Rows[1][1]); i++)
                {
                    ListItem lstdd2 = new ListItem();
                    lstdd2.Text = i.ToString();
                    lstdd2.Value = i.ToString();
                    ddlscore2.Items.Add(lstdd2);
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

            string _strReSubmitBySales=string.Empty;
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
            ddlscore1.Enabled = false;
            ddlscore2.Enabled = false;
            txtDescription1.Enabled = false;
            txtDescription2.Enabled = false;
            btnSave.Visible = false;
        }

        private void EnableControls()
        {
            ddlscore1.Enabled = true;
            ddlscore2.Enabled = true;
            txtDescription1.Enabled = true;
            txtDescription2.Enabled = true;
            btnSave.Visible = true;
        }

        #endregion

        #region Events for controls

        protected void btnAccountQualification_Click(object sender, EventArgs e)
        {
            if (Session["totalScoreScreen1"] != null)
            {
                Response.Redirect("FrmQualificationmain.aspx?TotalScoreScreen1=" + hidScoreClientsDemand.Value);
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
                //Save to DB
                ScoreOppQuaBLL clsScoreOppQuaBLL = new ScoreOppQuaBLL();

                DisplayDescriptiononScore();
                txtTotalScore.Text = hidScoreClientsDemand.Value;
                int _intTotalScoreClientsDemand = Convert.ToInt32(hidScoreClientsDemand.Value);
                Session["totalScoreScreen1"] = _intTotalScoreClientsDemand;

                //if data is inserted
                if (hidSaveClick.Value == "true")
                {
                    QualificationDetailsBO clsEmotionalNeedBO = new QualificationDetailsBO();
                    clsEmotionalNeedBO.Score = Convert.ToInt32(ddlscore1.SelectedValue);
                    clsEmotionalNeedBO.ParaDescription = para1.Text;
                    clsEmotionalNeedBO.Description = txtDescription1.Text;
                    clsEmotionalNeedBO.ParaID = Constants._intEmotionalParaID;
                    clsEmotionalNeedBO.OppNumber = (string)Session["Oppid"];


                    QualificationDetailsBO clsBusinessBo = new QualificationDetailsBO();
                    clsBusinessBo.Score = Convert.ToInt32(ddlscore2.SelectedValue);
                    clsBusinessBo.ParaDescription = para2.Text;
                    clsBusinessBo.Description = txtDescription2.Text;
                    clsBusinessBo.ParaID = Constants._intBusinessParaID;
                    clsBusinessBo.OppNumber = (string)Session["Oppid"];

                    clsScoreOppQuaBLL.AddScoreDescriptionOppQua(clsEmotionalNeedBO);
                    clsScoreOppQuaBLL.AddScoreDescriptionOppQua(clsBusinessBo);

                    //once inserted set to false
                    hidSaveClick.Value = "false";

                    lblmsg.Text = "Saved successfully!!!";
                    ViewState["hidSaveClick"] = hidSaveClick.Value;

                }
                //record exists we need to update it
                else if (hidSaveClick.Value == "false")
                {
                    QualificationDetailsBO clsEmotionalNeedBO = new QualificationDetailsBO();
                    clsEmotionalNeedBO.Score = Convert.ToInt32(ddlscore1.SelectedValue);
                    clsEmotionalNeedBO.ParaDescription = para1.Text;
                    clsEmotionalNeedBO.Description = txtDescription1.Text;
                    clsEmotionalNeedBO.ParaID = Constants._intEmotionalParaID;
                    clsEmotionalNeedBO.OppNumber = (string)Session["Oppid"];
                    clsScoreOppQuaBLL.UpdateScoreDescriptionParameter(clsEmotionalNeedBO);

                    QualificationDetailsBO clsBusinessBo = new QualificationDetailsBO();
                    clsBusinessBo.Score = Convert.ToInt32(ddlscore2.SelectedValue);
                    clsBusinessBo.ParaDescription = para2.Text;
                    clsBusinessBo.Description = txtDescription2.Text;
                    clsBusinessBo.ParaID = Constants._intBusinessParaID; ;
                    clsBusinessBo.OppNumber = (string)Session["Oppid"];
                    clsScoreOppQuaBLL.UpdateScoreDescriptionParameter(clsBusinessBo);

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

        protected void btnNext_Click(object sender, EventArgs e)
        {
          
            Response.Redirect("FrmSyntelBusinessPriorityScale.aspx");

        }

        #endregion
    }
}
