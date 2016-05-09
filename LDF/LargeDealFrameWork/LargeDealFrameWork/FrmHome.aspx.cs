using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BO;
using System.Data;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace LargeDealFrameWork
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string strURLData = "";
            //string strReq = "";
            //strURLData = Request.QueryString["Employeeid"].ToString().Replace(" ", "+");
            //strReq = Decrypt<AesManaged>(strURLData);
            //string[] arrMsgs = strReq.Split('=');
            //string userid = arrMsgs[1].ToString();
            //// Session["UserID"] = userid.ToString().Trim();

            string commaSeperatedRoles = string.Empty;

            DataTable dtUser = new BLL.LoginBLL().userExist(Session["UserID"].ToString());

            if (dtUser != null && dtUser.Rows.Count > 0)
            {
                foreach (DataRow dr in dtUser.Rows)
                {
                    if (string.IsNullOrEmpty(commaSeperatedRoles))
                    {
                        commaSeperatedRoles = dr["IRoleID"].ToString();
                    }
                    else
                    {
                        commaSeperatedRoles = commaSeperatedRoles + "," + dr["IRoleId"].ToString();
                    }

                    //commaSeperatedRoles = commaSeperatedRoles + ",";

                    Session["Designation"] = dr["IDesgnId"];
                    Session["FirstName"] = dr["vsFirstName"];
                    Session["UserID"] = dr["vspkUsrId"];
                    Session["RoleID"] = commaSeperatedRoles;
                    Session["DesignationName"] = dr["vsDesgn"];
                    Session["VertId"] = dr["vsVertId"];
                }

                if (clsDesignationList.hsDesignationList == null)
                {
                    DataSet dsDesignationDetails = new DataSet();
                    dsDesignationDetails = new BLL.HomeScreensBLL().GetDesignationDetails();
                    clsDesignationList.PopulateDesignationList(dsDesignationDetails);
                }


                //int _introleid = (int)Session["RoleID"];            
                if (Convert.ToInt32(Session["Designation"]) == clsDesignationList.GetDesignationID(EnumDesignation.Admin))
                {
                    Response.Redirect("FrmAddNewUser.aspx");
                }
                // else if (User.IsInRole("5"))
                else if (Convert.ToInt32(Session["Designation"]) == clsDesignationList.GetDesignationID(EnumDesignation.DeliveryDirector))
                {
                    Response.Redirect("FrmHomeScreenForDeliveryHead.aspx");
                }
                //else if (User.IsInRole("13"))
                else if (Convert.ToInt32(Session["Designation"]) == clsDesignationList.GetDesignationID(EnumDesignation.BUHead))
                {
                    Response.Redirect("FrmHomeScreenForBUHead.aspx");
                }
                //else if (User.IsInRole("14") || User.IsInRole("6") || User.IsInRole("11"))
                else if (Convert.ToInt32(Session["Designation"]) == clsDesignationList.GetDesignationID(EnumDesignation.GPTHead) ||
                    Convert.ToInt32(Session["Designation"]) == clsDesignationList.GetDesignationID(EnumDesignation.VerticalPreSalesHead))
                {
                    Response.Redirect("FrmHomeScreenForGPTManager.aspx");
                }
                //else if(User.IsInRole("9"))
                else if (Convert.ToInt32(Session["Designation"]) == clsDesignationList.GetDesignationID(EnumDesignation.DeliveryManager))
                {
                    Response.Redirect("FrmHomeScreenforDeliveryMgr.aspx");
                }
                //else if (User.IsInRole("7") || User.IsInRole("10"))
                else if (Convert.ToInt32(Session["Designation"]) == clsDesignationList.GetDesignationID(EnumDesignation.BidManager) ||
                    Convert.ToInt32(Session["Designation"]) == clsDesignationList.GetDesignationID(EnumDesignation.DeliveryManagerSPoC))
                {
                    Response.Redirect("FrmHomeScreenForBidMgr.aspx");
                }
                // else if (User.IsInRole("8"))
                else if (Convert.ToInt32(Session["Designation"]) == clsDesignationList.GetDesignationID(EnumDesignation.BidCoordinator))
                {
                    Response.Redirect("FrmHomeScreenForBidCord.aspx");
                }
                //else if (User.IsInRole("12"))
                else if (Convert.ToInt32(Session["Designation"]) == clsDesignationList.GetDesignationID(EnumDesignation.TopManagement) ||
                    Convert.ToInt32(Session["Designation"]) == clsDesignationList.GetDesignationID(EnumDesignation.GPTMember))
                {
                    Response.Redirect("FrmHomeScreenTopMgmt.aspx");
                }
                //else if (User.IsInRole("6"))
                else if (Convert.ToInt32(Session["Designation"]) == clsDesignationList.GetDesignationID(EnumDesignation.VerticalPreSalesHead))
                {
                    Response.Redirect("FrmHomeScreenForGPTManager.aspx");
                }
                //else if (User.IsInRole("2"))
                else if (Convert.ToInt32(Session["Designation"]) == clsDesignationList.GetDesignationID(EnumDesignation.PrimarySalesSPoc))
                {
                    Response.Redirect("FrmHomeScreenforSale.aspx");
                }
                else
                {
                    Response.Redirect("FrmAuthorizationStatus.aspx");
                }
            }
            else
            {
                Response.Redirect("FrmAuthorizationStatus.aspx");
            }
        }


        public static string Decrypt<T>(string text)
                where T : SymmetricAlgorithm, new()
        {
            DeriveBytes rgb = new Rfc2898DeriveBytes("syntelap", Encoding.Unicode.GetBytes("mobile"));

            SymmetricAlgorithm algorithm = new T();

            byte[] rgbKey = rgb.GetBytes(algorithm.KeySize >> 3);
            byte[] rgbIV = rgb.GetBytes(algorithm.BlockSize >> 3);

            ICryptoTransform transform = algorithm.CreateDecryptor(rgbKey, rgbIV);

            using (MemoryStream buffer = new MemoryStream(Convert.FromBase64String(text)))
            {
                using (CryptoStream stream = new CryptoStream(buffer, transform, CryptoStreamMode.Read))
                {
                    using (StreamReader reader = new StreamReader(stream, Encoding.Unicode))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
        }
    }
}
