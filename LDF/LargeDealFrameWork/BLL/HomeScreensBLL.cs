using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace BLL
{
    public class HomeScreensBLL
    {
        public DataSet Get_OpportunityDetails(string UserID, int designationid)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;


            param = new SqlParameter();
            param.ParameterName = "@vsUserID";
            param.DbType = DbType.String;
            param.Value = UserID;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@IDesgnId";
            param.DbType = DbType.Int32;
            param.Value = designationid;
            lstParam.Add(param);

            //param = new SqlParameter();
            //param.ParameterName = "@VerticalID";
            //param.DbType = DbType.Int32;
            //param.Value = designationid;
            //lstParam.Add(param);

            DataSet Opp_details = new DataSet();
            bool abc = false;
            return Opp_details = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselOppAssignDtls]", lstParam, abc);
        }

        public DataSet GetOpportunityDetailsDeliveryHeadbySales(string salesID, string deliveryHeadID)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;


            param = new SqlParameter();
            param.ParameterName = "@vsSales";
            param.DbType = DbType.String;
            param.Value = salesID;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@vsDeliveryHead";
            param.DbType = DbType.String;
            param.Value = deliveryHeadID;
            lstParam.Add(param);

            DataSet Opp_details = new DataSet();
            bool abc = false;
            return Opp_details = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[GetOpportunityDeliveryHeadbySales]", lstParam, abc);
        }



        public DataSet Get_VerticalPreSalesOpenOpprDetails(string UserID, int designationid, string VerticalID)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;


            param = new SqlParameter();
            param.ParameterName = "@vsUserID";
            param.DbType = DbType.String;
            param.Value = UserID;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@IDesgnId";
            param.DbType = DbType.Int32;
            param.Value = designationid;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@VerticalID";
            param.DbType = DbType.Int32;
            param.Value = VerticalID;
            lstParam.Add(param);

            DataSet Opp_details = new DataSet();
            bool abc = false;
            return Opp_details = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselVertPresalesOppAssignDtls]", lstParam, abc);
        }


        public DataSet Get_OpenOpportunityDetails(string UserID1, int designationid, int VerticalId)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;


            param = new SqlParameter();
            param.ParameterName = "@vsUserID";
            param.DbType = DbType.String;
            param.Value = UserID1;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@IDesgnId";
            param.DbType = DbType.Int32;
            param.Value = designationid;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@VerticalId";
            param.DbType = DbType.Int32;
            param.Value = VerticalId;
            lstParam.Add(param);

            DataSet Opp_details = new DataSet();
            bool abc = false;
            return Opp_details = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselOpenOppAssignDtls]", lstParam, abc);
        }

        public DataSet Get_ClosedOpportunityDetails(string UserID, int designationid, int VerticalId)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;


            param = new SqlParameter();
            param.ParameterName = "@vsUserID";
            param.DbType = DbType.Int32;
            param.Value = UserID;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@IDesgnId";
            param.DbType = DbType.Int32;
            param.Value = designationid;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@VerticalId";
            param.DbType = DbType.Int32;
            param.Value = VerticalId;
            lstParam.Add(param);

            DataSet Opp_details = new DataSet();
            bool abc = false;
            return Opp_details = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselGPTMClosedOppAssignDtls]", lstParam, abc);
        }

        public DataSet getlblPrimarySecondaryContact(string UserID, string secUserID, string spocID)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;


            param = new SqlParameter();
            param.ParameterName = "@vsUserID";
            param.DbType = DbType.String;
            param.Value = UserID;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@vssecUserID";
            param.DbType = DbType.String;
            param.Value = secUserID;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@vsspocID";
            param.DbType = DbType.String;
            param.Value = spocID;
            lstParam.Add(param);


            DataSet Opp_details = new DataSet();
            bool abc = false;
            return Opp_details = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselNameUser]", lstParam, abc);
        }

        public DataSet getStatusAssign(string oppid)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            param = new SqlParameter();
            param.ParameterName = "@oppid";
            param.DbType = DbType.String;
            param.Value = oppid;
            lstParam.Add(param);

            DataSet Opp_details = new DataSet();
            bool abc = false;
            return Opp_details = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselAssignDtls]", lstParam, abc);
        }

        //added by sachin 20 Feb 2014
        public DataSet Get_TopMangmtClosedOpportunityDetails(string SalesUserId, int DesignationId)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;


            param = new SqlParameter();
            param.ParameterName = "@vsUserID";
            param.DbType = DbType.String;
            param.Value = SalesUserId;
            lstParam.Add(param);
            param = new SqlParameter();
            param.ParameterName = "@IDesgnId";
            param.DbType = DbType.String;
            param.Value = DesignationId;
            lstParam.Add(param);

            DataSet Opp_details = new DataSet();
            bool abc = false;
            return Opp_details = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselBMClosedOppAssignDtls]", lstParam, abc);
        }
        public DataSet Get_BCClosedOpportunityDetails(string SalesUserId, int DesignationId)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;


            param = new SqlParameter();
            param.ParameterName = "@vsUserID";
            param.DbType = DbType.String;
            param.Value = SalesUserId;
            lstParam.Add(param);
            param = new SqlParameter();
            param.ParameterName = "@IDesgnId";
            param.DbType = DbType.String;
            param.Value = DesignationId;
            lstParam.Add(param);

            DataSet Opp_details = new DataSet();
            bool abc = false;
            return Opp_details = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselBCClosedOppAssignDtls]", lstParam, abc);
        }
        public DataSet Get_SaleClosedOpportunityDetails(string SalesUserId, int DesignationId)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;


            param = new SqlParameter();
            param.ParameterName = "@vsUserID";
            param.DbType = DbType.String;
            param.Value = SalesUserId;
            lstParam.Add(param);
            param = new SqlParameter();
            param.ParameterName = "@IDesgnId";
            param.DbType = DbType.String;
            param.Value = DesignationId;
            lstParam.Add(param);

            DataSet Opp_details = new DataSet();
            bool abc = false;
            return Opp_details = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselSaleClosedOppAssignDtls]", lstParam, abc);
        }
        
        public DataSet GetFlag(string strSaleID)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;


            param = new SqlParameter();
            param.ParameterName = "@vsSalesId";
            param.DbType = DbType.String;
            param.Value = strSaleID;
            lstParam.Add(param);

            DataSet Opp_details = new DataSet();
            bool abc = false;
            return Opp_details = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselClosedOppId]", lstParam, abc);
        }
        public DataSet GetOppFlag(string strSaleID)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;


            param = new SqlParameter();
            param.ParameterName = "@vsSalesId";
            param.DbType = DbType.String;
            param.Value = strSaleID;
            lstParam.Add(param);

            DataSet Opp_details = new DataSet();
            bool abc = false;
            return Opp_details = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselNoGoClosedOppId]", lstParam, abc);
        }
        public DataSet GetTopOppFlag(string SalesUserId,int DesignationId,int VerticalId)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;


            param = new SqlParameter();
            param.ParameterName = "@vsUserID";
            param.DbType = DbType.Int32;
            param.Value = SalesUserId;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@IDesgnId";
            param.DbType = DbType.Int32;
            param.Value = DesignationId;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@VerticalId";
            param.DbType = DbType.Int32;
            param.Value = VerticalId;
            lstParam.Add(param);

            DataSet Opp_details = new DataSet();
            bool abc = false;
            return Opp_details = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spTopMgmtNoGoClosedOppId]", lstParam, abc);
        }
        
        //Added by sachin to show closedn opp detalis For Delivery Director
        public DataSet Get_DDClosedOpportunityDetails(string UserID, string Salesid)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            param = new SqlParameter();
            param.ParameterName = "@vsSalesUserID";
            param.DbType = DbType.Int32;
            param.Value = Salesid;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@vsUserID";
            param.DbType = DbType.String;
            param.Value = UserID;
            lstParam.Add(param);



            DataSet ClosedOpp_details = new DataSet();
            bool abc = false;
            ClosedOpp_details = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselDDClosedOppAssignDtls]", lstParam, abc);
            return ClosedOpp_details;
        }

        public DataSet Get_VerticalPresalesClosedOpportunityDetails(string UserID, string verticalID)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            param = new SqlParameter();
            param.ParameterName = "@vsUserID";
            param.DbType = DbType.Int32;
            param.Value = UserID;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@VerticalId";
            param.DbType = DbType.String;
            param.Value = verticalID;
            lstParam.Add(param);



            DataSet ClosedOpp_details = new DataSet();
            bool abc = false;
            ClosedOpp_details = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselVertPreSalesClosedOppAssignDtls]", lstParam, abc);
            return ClosedOpp_details;
        }


        public DataSet Get_BuHeadClosedOpportunityDetails(string UserID, string Salesid)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            param = new SqlParameter();
            param.ParameterName = "@vsSalesUserID";
            param.DbType = DbType.Int32;
            param.Value = Salesid;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@vsUserID";
            param.DbType = DbType.String;
            param.Value = UserID;
            lstParam.Add(param);



            DataSet ClosedOpp_details = new DataSet();
            bool abc = false;
            ClosedOpp_details = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselBUHeadClosedOppAssignDtls]", lstParam, abc);
            return ClosedOpp_details;
        }

        public DataSet Get_SalesGPTClosedOpportunityDetails(int Id)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;
            param = new SqlParameter();
            param.ParameterName = "@VertId";
            param.DbType = DbType.String;
            param.Value = Id;
            lstParam.Add(param);
            DataSet ClosedOpp_details = new DataSet();
            bool abc = false;
            ClosedOpp_details = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselClosedOppAssignDtlsVertical]", lstParam, abc);
            return ClosedOpp_details;
        }

        public DataSet GPTClosedloadGridviewSalesVertical(int Id)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            param = new SqlParameter();
            param.ParameterName = "@VertId";
            param.DbType = DbType.String;
            param.Value = Id;
            lstParam.Add(param);

            DataSet ClosedOpp_details = new DataSet();
            bool abc = false;
            ClosedOpp_details = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselClosedOppAssignDtlsVertical]", lstParam, abc);
            return ClosedOpp_details;
        }

        public DataSet loadGridviewSalesVertical(string verticalId)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;


            param = new SqlParameter();
            param.ParameterName = "@VertId";
            param.DbType = DbType.String;
            param.Value = verticalId;
            lstParam.Add(param);



            DataSet Opp_details = new DataSet();
            bool abc = false;
            return Opp_details = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselOppAssignDtlsVertical]", lstParam, abc);
        }
        /// <summary>
        /// Get the Salesperson Details
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="DesignationID"></param>
        /// <returns></returns>
        public DataSet Get_SalesPerson(string UserID, int DesignationID)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;
            DataSet SalesPerson_Details = new DataSet();
            bool isQuery = false;

            param = new SqlParameter();
            param.ParameterName = "@vsUserID";
            param.DbType = DbType.String;
            param.Value = UserID;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@IDesgnId";
            param.DbType = DbType.Int32;
            param.Value = DesignationID;
            lstParam.Add(param);

            return SalesPerson_Details = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselSalesUserDtls]", lstParam, isQuery);
        }
        /// <summary>
        /// get the designationID based on the UserID
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public int Get_DesignationByUserId(string UserID)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;
            param = new SqlParameter();

            param.ParameterName = "@vsUserID";
            param.DbType = DbType.String;
            param.Value = UserID;
            lstParam.Add(param);
            bool isQuery = false;

            int DesignationID = 0;

            return DesignationID = (int)new DAL.SqlHelper().SelectValue("[dbo].[spselIDesgnidtbluser]", lstParam, isQuery);
        }
        public DataSet AssignStatus(string oppId, string status, int AssignorDesg, int AssigneeDesg)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;


            param = new SqlParameter();
            param.ParameterName = "@vsOppID";
            param.DbType = DbType.String;
            param.Value = oppId;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@status";
            param.DbType = DbType.String;
            param.Value = status;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@Assignor";
            param.DbType = DbType.Int32;
            param.Value = AssignorDesg;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@Assignee";
            param.DbType = DbType.Int32;
            param.Value = AssigneeDesg;
            lstParam.Add(param);



            DataSet Opp_details = new DataSet();
            bool abc = false;
            return Opp_details = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spinsPrimarySecondary]", lstParam, abc);
        }
        public string GetVerticalId(string UserID)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;
            param = new SqlParameter();

            param.ParameterName = "@vsUserID";
            param.DbType = DbType.String;
            param.Value = UserID;
            lstParam.Add(param);
            bool isQuery = false;

            string DesignationID = string.Empty;

            return DesignationID = (string)new DAL.SqlHelper().SelectValue("[dbo].[spselOppVerticalId]", lstParam, isQuery);
        }
        /// <summary>
        /// Get Vertical Details with opportunity
        /// </summary>
        /// <returns></returns>
        public DataSet Get_VerticalWithOpportunityDetails(string UserId)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            bool isQuery = false;
            SqlParameter param;
            param = new SqlParameter();

            param.ParameterName = "@vsUserId";
            param.DbType = DbType.String;
            param.Value = UserId;
            lstParam.Add(param);
            DataSet VerticalOpportunity_Details = new DataSet();
            return VerticalOpportunity_Details = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselVertOppAssignDtls]", null, isQuery);
        }
        /// <summary>
        /// Get SalesPerson etails with opportunity
        /// </summary>
        /// <param name="VerticalID"></param>
        /// <returns></returns>

        public DataSet Get_SalesPersonWithOpportunityDetails(string Id)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            bool isQuery = false;
            SqlParameter param;
            DataSet SalesPersonOpportunity_Details = new DataSet();




            param = new SqlParameter();
            param.ParameterName = "@vsverticalId";
            param.DbType = DbType.String;
            param.Value = Id;
            lstParam.Add(param);

            return SalesPersonOpportunity_Details = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselOppQuaScaleDtls]", lstParam, isQuery);
        }

        public DataSet Get_SalesPersonWithOpportunityDetails1(string Id2)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            bool isQuery = false;
            SqlParameter param;
            DataSet SalesPersonOpportunity_Details = new DataSet();




            param = new SqlParameter();
            param.ParameterName = "@vsverticalId";
            param.DbType = DbType.Int32;
            param.Value = Id2;
            lstParam.Add(param);

            return SalesPersonOpportunity_Details = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselOppQuaScaleDtls]", lstParam, isQuery);
        }


        public DataTable getUserName(int _intdesignation, string verticalID)
        {
            DataTable usertable = new DataTable();
            try
            {
                ArrayList lstParam = new System.Collections.ArrayList();
                SqlParameter param;


                param = new SqlParameter();
                param.ParameterName = "@vsDesignation";
                param.DbType = DbType.Int32;
                param.Value = _intdesignation;
                lstParam.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@verticalID";
                param.DbType = DbType.String;
                param.Value = verticalID;
                lstParam.Add(param);

                

                usertable = new DAL.SqlHelper().SelectData("[dbo].[spselUser]", lstParam, false);
            }
            catch
            {

            }
            return usertable;
        }

        public DataSet getClosedOpportunity(string strSalesID)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            bool isQuery = false;
            SqlParameter param;
            DataSet dsClosedOpportunity = new DataSet();

            param = new SqlParameter();
            param.ParameterName = "@salesID";
            param.DbType = DbType.String;
            param.Value = strSalesID;
            lstParam.Add(param);

            return dsClosedOpportunity = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselSaleClosedOppAssignDtls]", lstParam, isQuery);
        }

        public DataSet getClosedOpportunityForDeliveryManager(string strSDeliverMgrID)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            bool isQuery = false;
            SqlParameter param;
            DataSet dsClosedOpportunity = new DataSet();

            param = new SqlParameter();
            param.ParameterName = "@vsuserId";
            param.DbType = DbType.String;
            param.Value = strSDeliverMgrID;
            lstParam.Add(param);

            return dsClosedOpportunity = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselClosedOpportunityForDeilverMgrId]", lstParam, isQuery);
        }
//Added on 21 March 2014
        public DataSet getClosedOpportunityForDeliveryManagerSpoc(string strSDeliverMgrID)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            bool isQuery = false;
            SqlParameter param;
            DataSet dsClosedOpportunity = new DataSet();

            param = new SqlParameter();
            param.ParameterName = "@vsuserId";
            param.DbType = DbType.String;
            param.Value = strSDeliverMgrID;
            lstParam.Add(param);

            return dsClosedOpportunity = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselClosedOpportunityForDeilverMgrSpoc]", lstParam, isQuery);
        }


        public DataSet Get_BUHeadClosedOpportunityDetails(string SalesUserId)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            DataSet ClosedOpp_details = new DataSet();
            bool abc = false;
            ClosedOpp_details = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[SelProcClosedOppforGPT]", null, abc);
            return ClosedOpp_details;
        }


        public DataSet GetCountOpenLargeNonLargeDealOpportunity(string UserId1, string designationID)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            param = new SqlParameter();
            param.ParameterName = "@vsuserId";
            param.DbType = DbType.String;
            param.Value = UserId1;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@vsdesigId";
            param.DbType = DbType.String;
            param.Value = designationID;
            lstParam.Add(param);

            //param = new SqlParameter();
            //param.ParameterName = "@verticalId";
            //param.DbType = DbType.String;
            //param.Value = verticalID;
            //lstParam.Add(param);
           

            DataSet dsGetCount = new DataSet();
            bool abc = false;
            dsGetCount = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselOpenClosedOppId]", lstParam, abc);
            return dsGetCount;

        }

        public DataSet GetCountDDOpenLargeNonLargeDealOpportunity(string verticalID)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            
            param = new SqlParameter();
            param.ParameterName = "@verticalId";
            param.DbType = DbType.String;
            param.Value = verticalID;
            lstParam.Add(param);


            DataSet dsGetCount = new DataSet();
            bool abc = false;
            dsGetCount = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselDDOpenClosedOppId]", lstParam, abc);
            return dsGetCount;

        }

        public int GetDesignationIdByDesgDesc(string designationdesc)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;


            param = new SqlParameter();
            param.ParameterName = "@vsDesignationDesc";
            param.DbType = DbType.String;
            param.Value = designationdesc;
            lstParam.Add(param);

            DataSet dsGetCount = new DataSet();
            bool abc = false;
            dsGetCount = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselDesignationIdByDesc]", lstParam, abc);
            int desgid=Convert.ToInt32(dsGetCount.Tables[0].Rows[0][0].ToString());
            return desgid;

        }

        //public string Get_VerticalPresales(string PresalesVerticalId)
        //{
        //    ArrayList lstParam = new System.Collections.ArrayList();
        //    SqlParameter param;


        //    param = new SqlParameter();
        //    param.ParameterName = "@vsVerticalId";
        //    param.DbType = DbType.String;
        //    param.Value = PresalesVerticalId;
        //    lstParam.Add(param);

        //    DataSet dsGetCount = new DataSet();
        //    bool abc = false;
        //    dsGetCount = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselPresaleverticalID]", lstParam, abc);
        //    string desgid = dsGetCount.Tables[0].Rows[0][0].ToString();
        //    return desgid;

        //}
        public DataSet GetDesignationDetails()
        {
            //ArrayList lstParam = new System.Collections.ArrayList();
            //SqlParameter param;


            //param = new SqlParameter();
            //param.ParameterName = "@vsVerticalId";
            //param.DbType = DbType.String;
            //param.Value = PresalesVerticalId;
            //lstParam.Add(param);

            DataSet dsGetCount = new DataSet();
            bool abc = false;
            dsGetCount = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselDesgn]", null, abc);
           // string desgid = dsGetCount.Tables[0].Rows[0][0].ToString();
            return dsGetCount;

        }
    }

}
