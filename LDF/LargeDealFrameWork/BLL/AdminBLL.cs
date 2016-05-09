using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

namespace BLL
{
    public class AdminBLL
    {
        public DataTable getVerticals()
        {
            DataTable dt = new DAL.AdminDAL().getVerticals();
            return dt;
        }

        public DataTable getPasswordforNewUserId(string _strUserId)
        {
            DataTable dt = new DAL.AdminDAL().getPasswordforNewUserId(_strUserId);
            return dt;
        }

        public DataTable getDesignations()
        {
            DataTable dt = new DAL.AdminDAL().getDesignations();
            return dt;
        }

        public DataTable getLocations()
        {
            DataTable dt = new DAL.AdminDAL().getLocations();
            return dt;
        }

        public DataTable getRoles()
        {
            DataTable dt = new DAL.AdminDAL().getRoles();
            return dt;
        }

        public bool addNewUser(string FirstName, string MiddleName, string LastName, string EmployeeID, string EmailID, string VerticalID, int DesignationID, int LocationID)
        {
            bool pass = new DAL.AdminDAL().addNewUser(FirstName, MiddleName, LastName, EmployeeID, EmailID, VerticalID, DesignationID, LocationID);
            return pass;
        }

        public bool addNewRole(string RoleName)
        {
            bool pass = new DAL.AdminDAL().addNewRole(RoleName);
            return pass;
        }

        public bool addNewVertical(string VerticalName)
        {
            bool pass = new DAL.AdminDAL().addNewVertical(VerticalName);
            return pass;
        }

        public bool addNewDesignation(string DesignationName)
        {
            bool pass = new DAL.AdminDAL().addNewDesignation(DesignationName);
            return pass;
        }

        public bool addNewLocation(string LocationName)
        {
            bool pass = new DAL.AdminDAL().addNewLocation(LocationName);
            return pass;
        }

        public DataTable getUserDetails(string UserID)
        {
            DataTable dt = new DAL.AdminDAL().getUserDetails(UserID);
            return dt;
        }

        public bool updateUserDetails(string UserID, string FirstName, string MiddleName, string LastName, string EmployeeID, string EmailID, int VerticalID, int DesignationID)
        {
            bool pass = new DAL.AdminDAL().updateUserDetails(UserID, FirstName, MiddleName, LastName, EmployeeID, EmailID, VerticalID, DesignationID);
            return pass;
        }

        public bool deleteUser(string UserID)
        {
            bool pass = new DAL.AdminDAL().deleteUser(UserID);
            return pass;
        }

        public DataTable getAccountQualification()
        {
            DataTable dt = new DAL.AdminDAL().getAccountQualification();
            return dt;
        }

        public DataTable getClientDemandPresaleScore()
        {
            DataTable dt = new DAL.AdminDAL().getClientDemandPresaleScore();
            return dt;
        }

        public DataTable getSyntelBusinessPriorityScore()
        {
            DataTable dt = new DAL.AdminDAL().getSyntelBusinessPriorityScore();
            return dt;
        }

        public DataTable getClientUrgencyToBuyScore()
        {
            DataTable dt = new DAL.AdminDAL().getClientUrgencyToBuyScore();
            return dt;
        }

        public DataTable getSyntelCompetitiveAdvantageScore()
        {
            DataTable dt = new DAL.AdminDAL().getSyntelCompetitiveAdvantageScore();
            return dt;
        }

        public DataTable getClientDemandPresaleScale()
        {
            DataTable dt = new DAL.AdminDAL().getClientDemandPresaleScale();
            return dt;
        }

        public DataTable getSyntelBusinessScale()
        {
            DataTable dt = new DAL.AdminDAL().getSyntelBusinessScale();
            return dt;
        }

        public DataTable getClientUrgencyToBuyScale()
        {
            DataTable dt = new DAL.AdminDAL().getClientUrgencyToBuyScale();
            return dt;
        }

        public DataTable getSyntelCompetitiveAdvantageScale()
        {
            DataTable dt = new DAL.AdminDAL().getSyntelCompetitiveAdvantageScale();
            return dt;
        }

        public void updateAccountQualification(int WeightageID, string WeightageDesc, string MinValue, string MaxValue)
        {
            DAL.AdminDAL objAdmin = new DAL.AdminDAL();
            objAdmin.updateAccountQualification(WeightageID, WeightageDesc, MinValue, MaxValue);
        }

        public void updateClientDemandPresaleScore(int ScoreID, string MinValue, string MaxValue)
        {
            DAL.AdminDAL objAdmin = new DAL.AdminDAL();
            objAdmin.updateClientDemandPresaleScore(ScoreID, MinValue, MaxValue);
        }

        public void updateSyntelBusinessScore(int ScoreID, string MinValue, string MaxValue)
        {
            DAL.AdminDAL objAdmin = new DAL.AdminDAL();
            objAdmin.updateSyntelBusinessScore(ScoreID, MinValue, MaxValue);
        }

        public void updateClientUrgencyToBuyScore(int ScoreID, string MinValue, string MaxValue)
        {
            DAL.AdminDAL objAdmin = new DAL.AdminDAL();
            objAdmin.updateClientUrgencyToBuyScore(ScoreID, MinValue, MaxValue);
        }

        public void updateSyntelCompetitiveAdvantageScore(int ScoreID, string MinValue, string MaxValue)
        {
            DAL.AdminDAL objAdmin = new DAL.AdminDAL();
            objAdmin.updateSyntelCompetitiveAdvantageScore(ScoreID, MinValue, MaxValue);
        }

        public void updateClientDemandPresaleScale(int ScaleID, string MinValue, string MaxValue)
        {
            DAL.AdminDAL objAdmin = new DAL.AdminDAL();
            objAdmin.updateClientDemandPresaleScale(ScaleID, MinValue, MaxValue); 
        }

        public void updateSyntelBusinessScale(int ScaleID, string MinValue, string MaxValue)
        {
            DAL.AdminDAL objAdmin = new DAL.AdminDAL();
            objAdmin.updateSyntelBusinessScale(ScaleID, MinValue, MaxValue);
        }

        public void updateClientUrgencyToBuyScale(int ScaleID, string MinValue, string MaxValue)
        {
            DAL.AdminDAL objAdmin = new DAL.AdminDAL();
            objAdmin.updateClientUrgencyToBuyScale(ScaleID, MinValue, MaxValue);
        }

        public void updateSyntelCompetitiveAdvantageScale(int ScaleID, string MinValue, string MaxValue)
        {
            DAL.AdminDAL objAdmin = new DAL.AdminDAL();
            objAdmin.updateSyntelCompetitiveAdvantageScale(ScaleID, MinValue, MaxValue);
        }

        public DataTable getRGYCheckListScale()
        {
            DataTable dt = new DAL.AdminDAL().getRGYCheckListScale();
            return dt;
        }

        public void updateRGYCheckListScale(int ScaleID, string MinValue, string MaxValue)
        {
            DAL.AdminDAL objAdmin = new DAL.AdminDAL();
            objAdmin.updateRGYCheckListScale(ScaleID, MinValue, MaxValue);
        }

        public DataTable getRGYWeightage()
        {
            DataTable dt = new DAL.AdminDAL().getRGYWeightage();
            return dt;
        }

        public void updateRGYWeightage(int busweight,int techweight, int serweight, int transweight, int govweight, int proweight, int hrweight, int comweight, int intweight)
        {
            //DAL.AdminDAL objAdmin = new DAL.AdminDAL();
            //objAdmin.updateRGYWeightage(ParamID, Value);
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;
            //Get iteration count
            param = new SqlParameter();
            param.ParameterName = "@Business";
            param.DbType = DbType.Int32;
            param.Value = busweight;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@Technical";
            param.DbType = DbType.Int32;
            param.Value = techweight;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@Service";
            param.DbType = DbType.Int32;
            param.Value = serweight;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@Transition";
            param.DbType = DbType.Int32;
            param.Value = transweight;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@Governance";
            param.DbType = DbType.Int32;
            param.Value = govweight;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@Process";
            param.DbType = DbType.Int32;
            param.Value = proweight;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@HR";
            param.DbType = DbType.Int32;
            param.Value = hrweight;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@Commercial";
            param.DbType = DbType.Int32;
            param.Value = comweight;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@Integration";
            param.DbType = DbType.Int32;
            param.Value = intweight;
            lstParam.Add(param);

            int i = 0;
            bool abc = false;
            bool success = new DAL.SqlHelper().UpdateData("[dbo].[spupdRGYWeightage]", lstParam,abc);
            //string check =Convert.ToString( new DAL.SqlHelper().SelectValue("[dbo].[spselRgyTransaction]", lstParam, abc));
        }

        public DataTable getBidWinabilityScale()
        {
            DataTable dt = new DAL.AdminDAL().getBidWinabilityScale();
            return dt;
        }

        public void updateBidWinabilityScale(int ScaleID, string MinValue, string MaxValue)
        {
            DAL.AdminDAL objAdmin = new DAL.AdminDAL();
            objAdmin.updateBidWinabilityScale(ScaleID, MinValue, MaxValue);
        }

        public DataTable getBidWinWeightage()
        {
            DataTable dt = new DAL.AdminDAL().getBidWinWeightage();
            return dt;
        }

        public void updateBidWinWeightage(int WeightageID, string WeightageDesc, decimal Value)
        {
            DAL.AdminDAL objAdmin = new DAL.AdminDAL();
            objAdmin.updateBidWinWeightage(WeightageID, WeightageDesc, Value);
        }

        public DataTable getQualityOfResponse()
        {
            DataTable dt = new DAL.AdminDAL().getQualityOfResponse();
            return dt; 
        }

        public void updateQualityOfResponse(int WeightageID, string WeightageDesc, string MinValue, string MaxValue)
        {
            DAL.AdminDAL objAdmin = new DAL.AdminDAL();
            objAdmin.updateQualityOfResponse(WeightageID, WeightageDesc, MinValue, MaxValue);
        }

        public DataTable getBidWinUniqueness()
        {
            DataTable dt = new DAL.AdminDAL().getBidWinUniqueness();
            return dt;  
        }

        public void updateBidWinUniqueness(int ScoreID, int Value)
        {
            DAL.AdminDAL objAdmin = new DAL.AdminDAL();
            objAdmin.updateBidWinUniqueness(ScoreID, Value); 
        }

        public DataTable getBidWinInnovation()
        {
            DataTable dt = new DAL.AdminDAL().getBidWinInnovation();
            return dt;
        }

        public void updateBidWinInnovation(int ScoreID, int Value)
        {
            DAL.AdminDAL objAdmin = new DAL.AdminDAL();
            objAdmin.updateBidWinInnovation(ScoreID, Value);
        }

    }
}
