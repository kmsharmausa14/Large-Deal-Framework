using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace LargeDealFrameWork.AdminPages
{
    public partial class OpportunityQualification : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    Tab0.CssClass = "Clicked";
                    Tab1.CssClass = "Initial";
                    Tab2.CssClass = "Initial";
                    Tab3.CssClass = "Initial";
                    Tab4.CssClass = "Initial";
                    MainView.ActiveViewIndex = 0;

                    bindGVAccountQualification();
                    bindGVClientDemandPresaleScore();
                    bindGVClientDemandPresaleScale();
                    bindGVSyntelBusinessScore();
                    bindGVSyntelBusinessScale();
                    bindGVClientUrgencyToBuyScore();
                    bindGVClientUrgencyToBuyScale();
                    bindGVSyntelCompetitiveAdvantageScore();
                    bindGVSyntelCompetitiveAdvantageScale();
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

        protected void bindGVAccountQualification()
        {
            lblAccountQualification.Text = "";
            gvAccountQualification.DataSource = new BLL.AdminBLL().getAccountQualification();
            gvAccountQualification.DataBind();
        }

        protected void bindGVClientDemandPresaleScale()
        {
            lblClientDemandPresale.Text = "";
            gvClientDemandPresaleScale.DataSource = new BLL.AdminBLL().getClientDemandPresaleScale();
            gvClientDemandPresaleScale.DataBind();
        }

        protected void bindGVClientDemandPresaleScore()
        {
            lblClientDemandPresale.Text = "";
            gvClientDemandPresale.DataSource = new BLL.AdminBLL().getClientDemandPresaleScore();
            gvClientDemandPresale.DataBind();
        }

        protected void bindGVSyntelBusinessScale()
        {
            lblSyntelBusiness.Text = "";
            gvSyntelBusinessScale.DataSource = new BLL.AdminBLL().getSyntelBusinessScale();
            gvSyntelBusinessScale.DataBind(); 
        }

        protected void bindGVSyntelBusinessScore()
        {
            lblSyntelBusiness.Text = "";
            gvSyntelBusinessScore.DataSource = new BLL.AdminBLL().getSyntelBusinessPriorityScore();
            gvSyntelBusinessScore.DataBind();
        }

        protected void bindGVClientUrgencyToBuyScore()
        {
            lblClientUrgencyToBuy.Text = "";
            gvClientUrgencyToBuyScore.DataSource = new BLL.AdminBLL().getClientUrgencyToBuyScore();
            gvClientUrgencyToBuyScore.DataBind();
        }

        protected void bindGVClientUrgencyToBuyScale()
        {
            lblClientUrgencyToBuy.Text = "";
            gvClientUrgencyToBuyScale.DataSource = new BLL.AdminBLL().getClientUrgencyToBuyScale();
            gvClientUrgencyToBuyScale.DataBind();
        }

        protected void bindGVSyntelCompetitiveAdvantageScore()
        {
            lblSyntelCompetitiveAdvantage.Text = "";
            gvSyntelCompetitiveAdvantageScore.DataSource = new BLL.AdminBLL().getSyntelCompetitiveAdvantageScore();
            gvSyntelCompetitiveAdvantageScore.DataBind();
        }

        protected void bindGVSyntelCompetitiveAdvantageScale()
        {
            lblSyntelCompetitiveAdvantage.Text = "";
            gvSyntelCompetitiveAdvantageScale.DataSource = new BLL.AdminBLL().getSyntelCompetitiveAdvantageScale();
            gvSyntelCompetitiveAdvantageScale.DataBind();
        }

        protected void Tab0_Click(object sender, EventArgs e)
        {
            try
            {
                Tab0.CssClass = "Clicked";
                Tab1.CssClass = "Initial";
                Tab2.CssClass = "Initial";
                Tab3.CssClass = "Initial";
                Tab4.CssClass = "Initial";
                MainView.ActiveViewIndex = 0;
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

        protected void Tab1_Click(object sender, EventArgs e)
        {
            try
            {
                Tab0.CssClass = "Initial";
                Tab1.CssClass = "Clicked";
                Tab2.CssClass = "Initial";
                Tab3.CssClass = "Initial";
                Tab4.CssClass = "Initial";
                MainView.ActiveViewIndex = 1;
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

        protected void Tab2_Click(object sender, EventArgs e)
        {
            try
            {
                Tab0.CssClass = "Initial";
                Tab1.CssClass = "Initial";
                Tab2.CssClass = "Clicked";
                Tab3.CssClass = "Initial";
                Tab4.CssClass = "Initial";
                MainView.ActiveViewIndex = 2;
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

        protected void Tab3_Click(object sender, EventArgs e)
        {
            try
            {
                Tab0.CssClass = "Initial";
                Tab1.CssClass = "Initial";
                Tab2.CssClass = "Initial";
                Tab3.CssClass = "Clicked";
                Tab4.CssClass = "Initial";
                MainView.ActiveViewIndex = 3;
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

        protected void Tab4_Click(object sender, EventArgs e)
        {
            try
            {
                Tab0.CssClass = "Initial";
                Tab1.CssClass = "Initial";
                Tab2.CssClass = "Initial";
                Tab3.CssClass = "Initial";
                Tab4.CssClass = "Clicked";

                MainView.ActiveViewIndex = 4;
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

        protected void gvClientDemandPresale_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                gvClientDemandPresale.EditIndex = -1;
                bindGVClientDemandPresaleScore();
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

        protected void gvClientDemandPresale_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                gvClientDemandPresale.EditIndex = e.NewEditIndex;
                bindGVClientDemandPresaleScore();
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

        protected void gvClientDemandPresale_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int scoreID = Convert.ToInt32(gvClientDemandPresale.DataKeys[e.RowIndex].Value.ToString());

                TextBox txtMinValue = (TextBox)gvClientDemandPresale.Rows[e.RowIndex].FindControl("txtMinValueScore");
                TextBox txtMaxValue = (TextBox)gvClientDemandPresale.Rows[e.RowIndex].FindControl("txtMaxValueScore");

                if (Convert.ToInt32(txtMinValue.Text) < Convert.ToInt32(txtMaxValue.Text))
                {
                    new BLL.AdminBLL().updateClientDemandPresaleScore(scoreID, txtMinValue.Text, txtMaxValue.Text);

                    gvClientDemandPresale.EditIndex = -1;

                    bindGVClientDemandPresaleScore();
                }
                else
                {
                    lblClientDemandPresale.Text = "Min Value should not be greater than or equal to Max Value.";
                    e.Cancel = true;
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

        protected void gvSyntelBusinessScore_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                gvSyntelBusinessScore.EditIndex = -1;
                bindGVSyntelBusinessScore();
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

        protected void gvSyntelBusinessScore_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                gvSyntelBusinessScore.EditIndex = e.NewEditIndex;
                bindGVSyntelBusinessScore();
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

        protected void gvSyntelBusinessScore_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int scoreID = Convert.ToInt32(gvSyntelBusinessScore.DataKeys[e.RowIndex].Value.ToString());

                TextBox txtMinValue = (TextBox)gvSyntelBusinessScore.Rows[e.RowIndex].FindControl("txtMinValueScore");
                TextBox txtMaxValue = (TextBox)gvSyntelBusinessScore.Rows[e.RowIndex].FindControl("txtMaxValueScore");

                if (Convert.ToInt32(txtMinValue.Text) < Convert.ToInt32(txtMaxValue.Text))
                {
                    new BLL.AdminBLL().updateSyntelBusinessScore(scoreID, txtMinValue.Text, txtMaxValue.Text);

                    gvSyntelBusinessScore.EditIndex = -1;

                    bindGVSyntelBusinessScore();
                }
                else
                {
                    lblSyntelBusiness.Text = "Min Value should not be greater than or equal to Max Value.";
                    e.Cancel = true;
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

        protected void gvClientUrgencyToBuyScore_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                gvClientUrgencyToBuyScore.EditIndex = -1;
                bindGVClientUrgencyToBuyScore();
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

        protected void gvClientUrgencyToBuyScore_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                gvClientUrgencyToBuyScore.EditIndex = e.NewEditIndex;
                bindGVClientUrgencyToBuyScore();
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

        protected void gvClientUrgencyToBuyScore_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int scoreID = Convert.ToInt32(gvClientUrgencyToBuyScore.DataKeys[e.RowIndex].Value.ToString());

                TextBox txtMinValue = (TextBox)gvClientUrgencyToBuyScore.Rows[e.RowIndex].FindControl("txtMinValueScore");
                TextBox txtMaxValue = (TextBox)gvClientUrgencyToBuyScore.Rows[e.RowIndex].FindControl("txtMaxValueScore");

                if (Convert.ToInt32(txtMinValue.Text) < Convert.ToInt32(txtMaxValue.Text))
                {
                    new BLL.AdminBLL().updateClientUrgencyToBuyScore(scoreID, txtMinValue.Text, txtMaxValue.Text);

                    gvClientUrgencyToBuyScore.EditIndex = -1;

                    bindGVClientUrgencyToBuyScore();
                }
                else
                {
                    lblClientUrgencyToBuy.Text = "Min Value should not be greater than or equal to Max Value.";
                    e.Cancel = true;
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

        protected void gvSyntelCompetitiveAdvantageScore_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                gvSyntelCompetitiveAdvantageScore.EditIndex = -1;
                bindGVSyntelCompetitiveAdvantageScore();
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

        protected void gvSyntelCompetitiveAdvantageScore_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                gvSyntelCompetitiveAdvantageScore.EditIndex = e.NewEditIndex;
                bindGVSyntelCompetitiveAdvantageScore();
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

        protected void gvSyntelCompetitiveAdvantageScore_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int scoreID = Convert.ToInt32(gvSyntelCompetitiveAdvantageScore.DataKeys[e.RowIndex].Value.ToString());

                TextBox txtMinValue = (TextBox)gvSyntelCompetitiveAdvantageScore.Rows[e.RowIndex].FindControl("txtMinValueScore");
                TextBox txtMaxValue = (TextBox)gvSyntelCompetitiveAdvantageScore.Rows[e.RowIndex].FindControl("txtMaxValueScore");

                if (Convert.ToInt32(txtMinValue.Text) < Convert.ToInt32(txtMaxValue.Text))
                {
                    new BLL.AdminBLL().updateSyntelCompetitiveAdvantageScore(scoreID, txtMinValue.Text, txtMaxValue.Text);

                    gvSyntelCompetitiveAdvantageScore.EditIndex = -1;

                    bindGVSyntelCompetitiveAdvantageScore();
                }
                else
                {
                    lblSyntelCompetitiveAdvantage.Text = "Min Value should not be greater than or equal to Max Value.";
                    e.Cancel = true;
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

        protected void gvClientDemandPresaleScale_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                gvClientDemandPresaleScale.EditIndex = -1;
                bindGVClientDemandPresaleScale();
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

        protected void gvClientDemandPresaleScale_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                gvClientDemandPresaleScale.EditIndex = e.NewEditIndex;
                bindGVClientDemandPresaleScale();
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

        protected void gvClientDemandPresaleScale_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int scaleID = Convert.ToInt32(gvClientDemandPresaleScale.DataKeys[e.RowIndex].Value.ToString());

                TextBox txtMinValue = (TextBox)gvClientDemandPresaleScale.Rows[e.RowIndex].FindControl("txtMinValueScale");
                TextBox txtMaxValue = (TextBox)gvClientDemandPresaleScale.Rows[e.RowIndex].FindControl("txtMaxValueScale");

                if (Convert.ToInt32(txtMinValue.Text) < Convert.ToInt32(txtMaxValue.Text))
                {
                    new BLL.AdminBLL().updateClientDemandPresaleScale(scaleID, txtMinValue.Text, txtMaxValue.Text);

                    gvClientDemandPresaleScale.EditIndex = -1;

                    bindGVClientDemandPresaleScale();
                }
                else
                {
                    lblClientDemandPresale.Text = "Min Value should not be greater than or equal to Max Value.";
                    e.Cancel = true;
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

        protected void gvSyntelBusinessScale_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                gvSyntelBusinessScale.EditIndex = -1;
                bindGVSyntelBusinessScale();
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

        protected void gvSyntelBusinessScale_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                gvSyntelBusinessScale.EditIndex = e.NewEditIndex;
                bindGVSyntelBusinessScale();
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

        protected void gvSyntelBusinessScale_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int scaleID = Convert.ToInt32(gvSyntelBusinessScale.DataKeys[e.RowIndex].Value.ToString());

                TextBox txtMinValue = (TextBox)gvSyntelBusinessScale.Rows[e.RowIndex].FindControl("txtMinValueScale");
                TextBox txtMaxValue = (TextBox)gvSyntelBusinessScale.Rows[e.RowIndex].FindControl("txtMaxValueScale");

                if (Convert.ToInt32(txtMinValue.Text) < Convert.ToInt32(txtMaxValue.Text))
                {
                    new BLL.AdminBLL().updateSyntelBusinessScale(scaleID, txtMinValue.Text, txtMaxValue.Text);

                    gvSyntelBusinessScale.EditIndex = -1;

                    bindGVSyntelBusinessScale();
                }
                else
                {
                    lblSyntelBusiness.Text = "Min Value should not be greater than or equal to Max Value.";
                    e.Cancel = true;
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

        protected void gvSyntelCompetitiveAdvantageScale_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                gvSyntelCompetitiveAdvantageScale.EditIndex = -1;
                bindGVSyntelCompetitiveAdvantageScale();
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

        protected void gvSyntelCompetitiveAdvantageScale_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                gvSyntelCompetitiveAdvantageScale.EditIndex = e.NewEditIndex;
                bindGVSyntelCompetitiveAdvantageScale();
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

        protected void gvSyntelCompetitiveAdvantageScale_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int scaleID = Convert.ToInt32(gvSyntelCompetitiveAdvantageScale.DataKeys[e.RowIndex].Value.ToString());

                TextBox txtMinValue = (TextBox)gvSyntelCompetitiveAdvantageScale.Rows[e.RowIndex].FindControl("txtMinValueScale");
                TextBox txtMaxValue = (TextBox)gvSyntelCompetitiveAdvantageScale.Rows[e.RowIndex].FindControl("txtMaxValueScale");

                if (Convert.ToInt32(txtMinValue.Text) < Convert.ToInt32(txtMaxValue.Text))
                {
                    new BLL.AdminBLL().updateSyntelCompetitiveAdvantageScale(scaleID, txtMinValue.Text, txtMaxValue.Text);

                    gvSyntelCompetitiveAdvantageScale.EditIndex = -1;

                    bindGVSyntelCompetitiveAdvantageScale();
                }
                else
                {
                    lblSyntelCompetitiveAdvantage.Text = "Min Value should not be greater than or equal to Max Value.";
                    e.Cancel = true;
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

        protected void gvClientUrgencyToBuyScale_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                gvClientUrgencyToBuyScale.EditIndex = -1;
                bindGVClientUrgencyToBuyScale();
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

        protected void gvClientUrgencyToBuyScale_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                gvClientUrgencyToBuyScale.EditIndex = e.NewEditIndex;
                bindGVClientUrgencyToBuyScale();
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

        protected void gvClientUrgencyToBuyScale_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int scaleID = Convert.ToInt32(gvClientUrgencyToBuyScale.DataKeys[e.RowIndex].Value.ToString());

                TextBox txtMinValue = (TextBox)gvClientUrgencyToBuyScale.Rows[e.RowIndex].FindControl("txtMinValueScale");
                TextBox txtMaxValue = (TextBox)gvClientUrgencyToBuyScale.Rows[e.RowIndex].FindControl("txtMaxValueScale");

                if (Convert.ToInt32(txtMinValue.Text) < Convert.ToInt32(txtMaxValue.Text))
                {

                    new BLL.AdminBLL().updateClientUrgencyToBuyScale(scaleID, txtMinValue.Text, txtMaxValue.Text);

                    gvClientUrgencyToBuyScale.EditIndex = -1;

                    bindGVClientUrgencyToBuyScale();
                }
                else
                {
                    lblClientUrgencyToBuy.Text = "Min Value should not be greater than or equal to Max Value.";
                    e.Cancel = true;
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

        protected void gvAccountQualification_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                gvAccountQualification.EditIndex = -1;
                bindGVAccountQualification();
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

        protected void gvAccountQualification_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                gvAccountQualification.EditIndex = e.NewEditIndex;
                bindGVAccountQualification();
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

        protected void gvAccountQualification_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int scaleID = Convert.ToInt32(gvAccountQualification.DataKeys[e.RowIndex].Value.ToString());

                TextBox txtMinValue = (TextBox)gvAccountQualification.Rows[e.RowIndex].FindControl("txtMinValueScale");
                TextBox txtMaxValue = (TextBox)gvAccountQualification.Rows[e.RowIndex].FindControl("txtMaxValueScale");
                Label lblDescription = (Label)gvAccountQualification.Rows[e.RowIndex].FindControl("lblDescription");

                if (!string.IsNullOrEmpty(txtMinValue.Text) && !string.IsNullOrEmpty(txtMaxValue.Text))
                {
                    if (Convert.ToInt32(txtMinValue.Text) < Convert.ToInt32(txtMaxValue.Text))
                    {

                        new BLL.AdminBLL().updateAccountQualification(scaleID, lblDescription.Text, txtMinValue.Text, txtMaxValue.Text);

                        gvAccountQualification.EditIndex = -1;

                        bindGVAccountQualification();
                    }
                    else
                    {
                        lblAccountQualification.Text = "Min Value should not be greater than or equal to Max Value.";
                        e.Cancel = true;
                    }
                }
                else if (!string.IsNullOrEmpty(txtMinValue.Text) || !string.IsNullOrEmpty(txtMaxValue.Text))
                {
                    new BLL.AdminBLL().updateAccountQualification(scaleID, lblDescription.Text, txtMinValue.Text, txtMaxValue.Text);

                    gvAccountQualification.EditIndex = -1;

                    bindGVAccountQualification();
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


    }
    
}