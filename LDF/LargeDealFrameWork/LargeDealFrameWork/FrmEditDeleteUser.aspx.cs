using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace LargeDealFrameWork.AdminPages
{
    public partial class EditDeleteUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    initializeControls();
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

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                initializeControls();
                lblMessage.Text = "";
                lblMessage.Visible = false;
                txtUserID.Text = "";
                divSearchResult.Visible = false;
                disableControls();
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                lblMessage.Text = "";
                lblMessage.Visible = false;
                loadControls();
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

        void loadControls()
        {
            DataTable dtUser = new BLL.AdminBLL().getUserDetails(txtUserID.Text);

            if (dtUser != null && dtUser.Rows.Count > 0)
            {
                foreach (DataRow dr in dtUser.Rows)
                {
                    txtFirstName.Text = dr["vsFirstName"].ToString();
                    txtMiddleName.Text = dr["vsMiddleName"].ToString();
                    txtLastName.Text = dr["vsLastName"].ToString();
                    txtEmpID.Text = dr["vspkUsrId"].ToString();
                    txtEmailID.Text = dr["vsEmailId"].ToString();

                    txtDesignation.Text = dr["vsDesgn"].ToString();
                    txtVertical.Text = dr["vsVertDesc"].ToString();

                    ddlDesignation.SelectedIndex = (int)dr["IDesgnId"];
                    ddlVertical.SelectedIndex = Convert.ToInt32(dr["vspkVertId"].ToString());                                      

                    break;

                }
                divSearchResult.Visible = true;
            }
            else
            {
                divSearchResult.Visible = false;
                lblMessage.Visible = true;
                lblMessage.Text = "User not found";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            } 
        }

        void initializeControls()
        {

            BLL.AdminBLL objAdmin = new BLL.AdminBLL();
            DataTable dtVerticals = objAdmin.getVerticals();
            DataTable dtDesignations = objAdmin.getDesignations();
            DataTable dtRoles = objAdmin.getRoles();

            ddlVertical.DataSource = dtVerticals;
            ddlVertical.DataTextField = "vsVertDesc";
            ddlVertical.DataValueField = "vspkVertId";
            ddlVertical.DataBind();
            ddlVertical.Items.Insert(0, new ListItem("Select Vertical", "0"));

            ddlDesignation.DataSource = dtDesignations;
            ddlDesignation.DataTextField = "vsDesgn";
            ddlDesignation.DataValueField = "IDesgnId";
            ddlDesignation.DataBind();
            ddlDesignation.Items.Insert(0, new ListItem("Select Designation", "0"));            

            txtFirstName.Text = "";
            txtMiddleName.Text = "";
            txtLastName.Text = "";
            txtEmpID.Text = "";
            txtEmailID.Text = "";

            lblMessage.Visible = false; 
        }

        void enableControls()
        {
            txtFirstName.Enabled = true;
            txtMiddleName.Enabled = true;
            txtLastName.Enabled = true;
            //txtEmpID.Enabled = true;
            txtEmailID.Enabled = true;

            txtVertical.Visible = false;
            ddlVertical.Visible = true;

            txtDesignation.Visible = false;
            ddlDesignation.Visible = true;            

            btnSave.Visible = true;
            btnCancel.Visible = true;
            btnDelete.Visible = false;
            btnEdit.Visible = false;
        }

        void disableControls()
        {
            txtFirstName.Enabled = false;
            txtMiddleName.Enabled = false;
            txtLastName.Enabled = false;
            //txtEmpID.Enabled = false;
            txtEmailID.Enabled = false;

            txtVertical.Visible = true;
            ddlVertical.Visible = false;

            txtDesignation.Visible = true;
            ddlDesignation.Visible = false;            

            btnSave.Visible = false;
            btnCancel.Visible = false;
            btnDelete.Visible = true;
            btnEdit.Visible = true;
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                lblMessage.Text = "";
                lblMessage.Visible = false;
                enableControls();
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            lblMessage.Visible = false;
            BLL.AdminBLL objAdmin = new BLL.AdminBLL();

            try
            {
                bool isTrue = objAdmin.updateUserDetails(txtUserID.Text, txtFirstName.Text, txtMiddleName.Text, txtLastName.Text,
                                                    txtEmpID.Text, txtEmailID.Text, ddlVertical.SelectedIndex,
                                                    ddlDesignation.SelectedIndex);                

                if (isTrue)
                {
                    loadControls();
                    lblMessage.Visible = true;
                    lblMessage.Text = "User details updated successfully.";
                    lblMessage.ForeColor = System.Drawing.Color.Green;                    
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }

            disableControls();

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            lblMessage.Visible = false;
            BLL.AdminBLL objAdmin = new BLL.AdminBLL();

            try
            {
                bool isTrue = objAdmin.deleteUser(txtUserID.Text);

                if (isTrue)
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "User deleted successfully.";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    divSearchResult.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Visible = true;
                lblMessage.Text = ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                lblMessage.Text = "";
                lblMessage.Visible = false;
                loadControls();
                disableControls();
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