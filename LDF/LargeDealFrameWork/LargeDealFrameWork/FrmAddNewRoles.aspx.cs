using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LargeDealFrameWork
{
    public partial class FrmAddNewRoles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                btnAddDesignation.Attributes.Add("onclick", "return ValidateData(" + txtDesignation.ClientID + ",'Designation')");
                btnAddLocation.Attributes.Add("onclick", " return ValidateData(" + txtLocation.ClientID + ",'Location')");
                btnAddRole.Attributes.Add("onclick", "return ValidateData(" + txtRoleName.ClientID + ",'Role')");
                btnAddVertical.Attributes.Add("onclick", "return ValidateData(" + txtVertical.ClientID + ",'Vertical')");
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

        protected void btnAddRole_Click(object sender, EventArgs e)
        {
            BLL.AdminBLL objAdmin = new BLL.AdminBLL();

            try
            {
                bool isTrue = objAdmin.addNewRole(txtRoleName.Text);

                if (isTrue)
                {
                    lblErrMsg.Text = "Role added successfully.";
                    lblErrMsg.ForeColor = System.Drawing.Color.Green;
                }
            }
            catch (Exception ex)
            {
                lblErrMsg.Text = ex.Message;
                lblErrMsg.ForeColor = System.Drawing.Color.Red;
            }

        }

        protected void btnAddVertical_Click(object sender, EventArgs e)
        {
            BLL.AdminBLL objAdmin = new BLL.AdminBLL();

            try
            {
                bool isTrue = objAdmin.addNewVertical(txtVertical.Text);

                if (isTrue)
                {
                    lblErrMsg.Text = "Vertical added successfully.";
                    lblErrMsg.ForeColor = System.Drawing.Color.Green;
                }
            }
            catch (Exception ex)
            {
                lblErrMsg.Text = ex.Message;
                lblErrMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnAddLocation_Click(object sender, EventArgs e)
        {
            BLL.AdminBLL objAdmin = new BLL.AdminBLL();

            try
            {
                bool isTrue = objAdmin.addNewLocation(txtLocation.Text);

                if (isTrue)
                {
                    lblErrMsg.Text = "Location added successfully.";
                    lblErrMsg.ForeColor = System.Drawing.Color.Green;
                }
            }
            catch (Exception ex)
            {
                lblErrMsg.Text = ex.Message;
                lblErrMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnAddDesignation_Click(object sender, EventArgs e)
        {
            BLL.AdminBLL objAdmin = new BLL.AdminBLL();

            try
            {
                bool isTrue = objAdmin.addNewDesignation(txtDesignation.Text);

                if (isTrue)
                {
                    lblErrMsg.Text = "Designation added successfully.";
                    lblErrMsg.ForeColor = System.Drawing.Color.Green;
                }
            }
            catch (Exception ex)
            {
                lblErrMsg.Text = ex.Message;
                lblErrMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}