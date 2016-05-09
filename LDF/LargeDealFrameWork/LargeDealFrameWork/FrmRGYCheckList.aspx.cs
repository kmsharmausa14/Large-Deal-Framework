using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LargeDealFrameWork.AdminPages
{
    public partial class RGYCheckList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    bindGVRGYCheckListScale();
                    bindGVRGYWeightage();
                    bindGVQualityOfResponse();
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

        protected void bindGVRGYCheckListScale()
        {
            gvRGYCheckListScale.DataSource = new BLL.AdminBLL().getRGYCheckListScale();
            gvRGYCheckListScale.DataBind();
            lblRGYCheckList.Text = "";
        }
        
        protected void bindGVRGYWeightage()
        {
            gvRGYWeightage.DataSource = new BLL.AdminBLL().getRGYWeightage();
            gvRGYWeightage.DataBind();
            lblRGYCheckList.Text = "";
        }

        protected void bindGVQualityOfResponse()
        {
            lblRGYCheckList.Text = "";
            gvQualityOfResponse.DataSource = new BLL.AdminBLL().getQualityOfResponse();
            gvQualityOfResponse.DataBind();
        }

        protected void gvRGYCheckListScale_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                gvRGYCheckListScale.EditIndex = -1;
                bindGVRGYCheckListScale();
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

        protected void gvRGYCheckListScale_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                gvRGYCheckListScale.EditIndex = e.NewEditIndex;
                bindGVRGYCheckListScale();
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

        protected void gvRGYCheckListScale_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int scaleID = Convert.ToInt32(gvRGYCheckListScale.DataKeys[e.RowIndex].Value.ToString());

                TextBox txtMinValue = (TextBox)gvRGYCheckListScale.Rows[e.RowIndex].FindControl("txtMinValueScale");
                TextBox txtMaxValue = (TextBox)gvRGYCheckListScale.Rows[e.RowIndex].FindControl("txtMaxValueScale");

                if (Convert.ToInt32(txtMinValue.Text) < Convert.ToInt32(txtMaxValue.Text))
                {
                    new BLL.AdminBLL().updateRGYCheckListScale(scaleID, txtMinValue.Text, txtMaxValue.Text);

                    gvRGYCheckListScale.EditIndex = -1;

                    bindGVRGYCheckListScale();
                }
                else
                {
                    lblRGYCheckList.Text = "Min Value should not be greater than or equal to Max Value.";
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

        protected void gvRGYWeightage_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                gvRGYWeightage.EditIndex = -1;
                bindGVRGYWeightage();
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

        protected void gvRGYWeightage_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                gvRGYWeightage.EditIndex = e.NewEditIndex;
                bindGVRGYWeightage();
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

        protected void gvRGYWeightage_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                //int ParamID = Convert.ToInt32(gvRGYWeightage.DataKeys[e.RowIndex].Value.ToString());

                TextBox txtValueBus = (TextBox)gvRGYWeightage.Rows[e.RowIndex].FindControl("txtValuebus");
                TextBox txtValueTech = (TextBox)gvRGYWeightage.Rows[e.RowIndex].FindControl("txtValuetech");
                TextBox txtValueSer = (TextBox)gvRGYWeightage.Rows[e.RowIndex].FindControl("txtValueser");
                TextBox txtValueTrans = (TextBox)gvRGYWeightage.Rows[e.RowIndex].FindControl("txtValuetrans");
                TextBox txtValueGov = (TextBox)gvRGYWeightage.Rows[e.RowIndex].FindControl("txtValuegov");
                TextBox txtValuePro = (TextBox)gvRGYWeightage.Rows[e.RowIndex].FindControl("txtValuepro");
                TextBox txtValueHR = (TextBox)gvRGYWeightage.Rows[e.RowIndex].FindControl("txtValuehr");
                TextBox txtValueCom = (TextBox)gvRGYWeightage.Rows[e.RowIndex].FindControl("txtValuecom");
                TextBox txtValueInt = (TextBox)gvRGYWeightage.Rows[e.RowIndex].FindControl("txtValueint");

                int busweight = Convert.ToInt32(txtValueBus.Text.ToString());
                int techweight = Convert.ToInt32(txtValueTech.Text.ToString());
                int serweight = Convert.ToInt32(txtValueSer.Text.ToString());
                int transweight = Convert.ToInt32(txtValueTrans.Text.ToString());
                int govweight = Convert.ToInt32(txtValueGov.Text.ToString());
                int proweight = Convert.ToInt32(txtValuePro.Text.ToString());
                int hrweight = Convert.ToInt32(txtValueHR.Text.ToString());
                int comweight = Convert.ToInt32(txtValueCom.Text.ToString());
                int intweight = Convert.ToInt32(txtValueInt.Text.ToString());
                new BLL.AdminBLL().updateRGYWeightage(busweight, techweight, serweight, transweight, govweight, proweight, hrweight, comweight, intweight);
                //new BLL.AdminBLL().updateRGYWeightage(ParamID, txtValue.Text);

                gvRGYWeightage.EditIndex = -1;

                bindGVRGYWeightage();
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

        protected void gvQualityOfResponse_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                gvQualityOfResponse.EditIndex = -1;
                bindGVQualityOfResponse();
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

        protected void gvQualityOfResponse_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                gvQualityOfResponse.EditIndex = e.NewEditIndex;
                bindGVQualityOfResponse();
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

        protected void gvQualityOfResponse_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int scaleID = Convert.ToInt32(gvQualityOfResponse.DataKeys[e.RowIndex].Value.ToString());

                TextBox txtMinValue = (TextBox)gvQualityOfResponse.Rows[e.RowIndex].FindControl("txtMinValueScale");
                TextBox txtMaxValue = (TextBox)gvQualityOfResponse.Rows[e.RowIndex].FindControl("txtMaxValueScale");
                Label lblDescription = (Label)gvQualityOfResponse.Rows[e.RowIndex].FindControl("lblDescription");

                if (!string.IsNullOrEmpty(txtMinValue.Text) && !string.IsNullOrEmpty(txtMaxValue.Text))
                {
                    if (Convert.ToInt32(txtMinValue.Text) < Convert.ToInt32(txtMaxValue.Text))
                    {

                        new BLL.AdminBLL().updateQualityOfResponse(scaleID, lblDescription.Text, txtMinValue.Text, txtMaxValue.Text);

                        gvQualityOfResponse.EditIndex = -1;

                        bindGVQualityOfResponse();
                    }
                    else
                    {
                        lblRGYCheckList.Text = "Min Value should not be greater than or equal to Max Value.";
                        e.Cancel = true;
                    }
                }
                else if (!string.IsNullOrEmpty(txtMinValue.Text) || !string.IsNullOrEmpty(txtMaxValue.Text))
                {
                    new BLL.AdminBLL().updateQualityOfResponse(scaleID, lblDescription.Text, txtMinValue.Text, txtMaxValue.Text);

                    gvQualityOfResponse.EditIndex = -1;

                    bindGVQualityOfResponse();
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