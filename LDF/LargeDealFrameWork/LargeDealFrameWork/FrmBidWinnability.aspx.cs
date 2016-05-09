using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LargeDealFrameWork.AdminPages
{
    public partial class BidWinnability : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindGVBidWinabilityScale();
                bindGVBidWinWeightage();
                bindGVBidWinUniqueness();
                bindGVBidWinInnovation();
            }
        }

        protected void bindGVBidWinabilityScale()
        {
            gvBidWinabilityScale.DataSource = new BLL.AdminBLL().getBidWinabilityScale();
            gvBidWinabilityScale.DataBind();
            lblBidWinability.Text = "";
        }

        protected void bindGVBidWinWeightage()
        {
            gvBidWinWeightage.DataSource = new BLL.AdminBLL().getBidWinWeightage();
            gvBidWinWeightage.DataBind();
            lblBidWinability.Text = "";
        }

        protected void bindGVBidWinUniqueness()
        {
            gvBidWinUniqueness.DataSource = new BLL.AdminBLL().getBidWinUniqueness();
            gvBidWinUniqueness.DataBind();
            lblBidWinability.Text = "";
        }

        protected void bindGVBidWinInnovation()
        {
            gvBidWinInnovation.DataSource = new BLL.AdminBLL().getBidWinInnovation();
            gvBidWinInnovation.DataBind();
            lblBidWinability.Text = "";
        }

        protected void gvBidWinabilityScale_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvBidWinabilityScale.EditIndex = -1;
            bindGVBidWinabilityScale();
        }

        protected void gvBidWinabilityScale_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvBidWinabilityScale.EditIndex = e.NewEditIndex;
            bindGVBidWinabilityScale();
        }

        protected void gvBidWinabilityScale_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int scaleID = Convert.ToInt32(gvBidWinabilityScale.DataKeys[e.RowIndex].Value.ToString());

            TextBox txtMinValue = (TextBox)gvBidWinabilityScale.Rows[e.RowIndex].FindControl("txtMinValueScale");
            TextBox txtMaxValue = (TextBox)gvBidWinabilityScale.Rows[e.RowIndex].FindControl("txtMaxValueScale");

            if (Convert.ToInt32(txtMinValue.Text) < Convert.ToInt32(txtMaxValue.Text))
            {
                new BLL.AdminBLL().updateBidWinabilityScale(scaleID, txtMinValue.Text, txtMaxValue.Text);

                gvBidWinabilityScale.EditIndex = -1;

                bindGVBidWinabilityScale();
            }
            else
            {
                lblBidWinability.Text = "Min Value should not be greater than or equal to Max Value.";
                e.Cancel = true;
            }
        }

        protected void gvBidWinWeightage_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvBidWinWeightage.EditIndex = -1;
            bindGVBidWinWeightage();
        }

        protected void gvBidWinWeightage_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvBidWinWeightage.EditIndex = e.NewEditIndex;
            bindGVBidWinWeightage();
        }

        protected void gvBidWinWeightage_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int ParamID = Convert.ToInt32(gvBidWinWeightage.DataKeys[e.RowIndex].Value.ToString());

            TextBox txtValue = (TextBox)gvBidWinWeightage.Rows[e.RowIndex].FindControl("txtValueWeightage");
            Label lblDescription = (Label)gvBidWinWeightage.Rows[e.RowIndex].FindControl("lblDescriptionWeightage");

            new BLL.AdminBLL().updateBidWinWeightage(ParamID, lblDescription.Text, Convert.ToDecimal(txtValue.Text));

            gvBidWinWeightage.EditIndex = -1;            

            bindGVBidWinWeightage();
        }

        protected void gvBidWinUniqueness_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvBidWinUniqueness.EditIndex = -1;
            bindGVBidWinUniqueness();
        }

        protected void gvBidWinUniqueness_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvBidWinUniqueness.EditIndex = e.NewEditIndex;
            bindGVBidWinUniqueness();
        }

        protected void gvBidWinUniqueness_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int ParamID = Convert.ToInt32(gvBidWinUniqueness.DataKeys[e.RowIndex].Value.ToString());

            TextBox txtValue = (TextBox)gvBidWinUniqueness.Rows[e.RowIndex].FindControl("txtValueUniqueness");

            new BLL.AdminBLL().updateBidWinUniqueness(ParamID, Convert.ToInt32(txtValue.Text));

            gvBidWinUniqueness.EditIndex = -1;

            bindGVBidWinUniqueness();
        }

        protected void gvBidWinInnovation_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvBidWinInnovation.EditIndex = -1;
            bindGVBidWinInnovation();
        }

        protected void gvBidWinInnovation_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvBidWinInnovation.EditIndex = e.NewEditIndex;
            bindGVBidWinInnovation();
        }

        protected void gvBidWinInnovation_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int ParamID = Convert.ToInt32(gvBidWinInnovation.DataKeys[e.RowIndex].Value.ToString());

            TextBox txtValue = (TextBox)gvBidWinInnovation.Rows[e.RowIndex].FindControl("txtValueInnovation");

            new BLL.AdminBLL().updateBidWinInnovation(ParamID, Convert.ToInt32(txtValue.Text));

            gvBidWinInnovation.EditIndex = -1;

            bindGVBidWinInnovation();
        }
    }
}