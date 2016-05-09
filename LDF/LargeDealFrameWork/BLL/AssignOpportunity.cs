using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using System.Collections;
using System.Data.SqlClient;

namespace BLL
{
   public class AssignOpportunity
    {
        public DataSet Get_ContactDetails(string userid)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            param = new SqlParameter();
            param.ParameterName = "@vsUserID";
            param.DbType = DbType.String;
            param.Value = userid;
            lstParam.Add(param);           

            DataSet Con_details = new DataSet();
            bool abc = false;
            return Con_details = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselUserContactDtls]", lstParam, abc);
        }

        public DataSet GetVerticalPresalesHead(string userid)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            param = new SqlParameter();
            param.ParameterName = "@vsID";
            param.DbType = DbType.String;
            param.Value = userid;
            lstParam.Add(param);

            DataSet dsVPH_details = new DataSet();
            bool _boolabc = false;
            return dsVPH_details = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselVerticalPresalesHead]", lstParam, _boolabc);
        }
        public DataSet DMSpoc(string userid)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            param = new SqlParameter();
            param.ParameterName = "@vsID";
            param.DbType = DbType.String;
            param.Value = userid;
            lstParam.Add(param);

            DataSet dsbidcoordinators_details = new DataSet();
            bool _boolabc = false;
            return dsbidcoordinators_details = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselDMSpocs]", lstParam, _boolabc);
        }

        public DataSet GetBidCoordinators(string VerticalID)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            //param = new SqlParameter();
            //param.ParameterName = "@vsID";
            //param.DbType = DbType.String;
            //param.Value = userid;
            //lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@VerticalID";
            param.DbType = DbType.Int32;
            param.Value = VerticalID;
            lstParam.Add(param);

            DataSet dsbidcoordinators_details = new DataSet();
            bool _boolabc = false;
            return dsbidcoordinators_details = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselBidCoordinators]", lstParam, _boolabc);
        }

        public DataSet GetBidManagers(string userid, string VerticalID)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            param = new SqlParameter();
            param.ParameterName = "@vsID";
            param.DbType = DbType.String;
            param.Value = userid;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@VerticalID";
            param.DbType = DbType.Int32;
            param.Value = VerticalID;
            lstParam.Add(param);

            DataSet dsbidmanagers_details = new DataSet();
            bool _boolabc = false;
            return dsbidmanagers_details = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselBidManagers]", lstParam, _boolabc);
        }

        public DataSet GetAssignmentDetails(string _strOppId)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            param = new SqlParameter();
            param.ParameterName = "@vsOppid";
            param.DbType = DbType.String;
            param.Value = _strOppId;
            lstParam.Add(param);

            DataSet dsassignmentDetails = new DataSet();
            bool _boolisquery = false;
            return dsassignmentDetails = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselOppAssignDetails]", lstParam, _boolisquery);
        }
    }
}
