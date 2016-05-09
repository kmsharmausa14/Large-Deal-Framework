using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using BO;

namespace BLL
{
    public class BidWinabilityBLL
    {
        public DataSet GetScoreUniquenessonButtonClick(string buttonName)
        {
            //Get score for particular button click
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            param = new SqlParameter();
            param.ParameterName = "@buttonName";
            param.DbType = DbType.String;
            param.Value = buttonName;
            lstParam.Add(param);

            DataSet ds;
            bool abc = false;
            return ds = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselUniqueness]", lstParam, abc);
        }

        public DataSet GetScoreInnovationButtonClick(string buttonName)
        {
            //Get score for particular button click
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            param = new SqlParameter();
            param.ParameterName = "@vsbuttonName";
            param.DbType = DbType.String;
            param.Value = buttonName;
            lstParam.Add(param);

            DataSet ds;
            bool abc = false;
            return ds = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselInnovation]", lstParam, abc);
        }

        public DataSet GetWeightageforFormula()
        {
            DataSet ds;
            bool abc = false;
            return ds = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselBidWinWt]", null, abc);
        }

        public bool AddUpdateBidWinabilityScoreStatus(BidWinabilityBO bidWinabilityBO)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            param = new SqlParameter();
            param.ParameterName = "@vsOppId";
            param.DbType = DbType.String;
            param.Value = bidWinabilityBO.OppID;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@vsinnovScore";
            param.DbType = DbType.String;
            param.Value = bidWinabilityBO.InnovationScore;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@vsunqScore";
            param.DbType = DbType.String;
            param.Value = bidWinabilityBO.UniquenessScore;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@bisInnovationSubmit";
            param.DbType = DbType.String;
            param.Value = bidWinabilityBO.IsInnovationSubmit;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@bisUniquenessSubmit";
            param.DbType = DbType.String;
            param.Value = bidWinabilityBO.IsUniquenessScore;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@vsstatus";
            param.DbType = DbType.String;
            param.Value = bidWinabilityBO.Status;
            lstParam.Add(param);

            bool val=false;
            bool abc = false;
            return val = (bool)new DAL.SqlHelper().UpdateData("[dbo].[spiuScoreStatusforBidwinability]", lstParam, abc);
          
        }

        public DataSet GetBidWinabilityScoreStatus(string strOppID)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            param = new SqlParameter();
            param.ParameterName = "@vspkOppid";
            param.DbType = DbType.String;
            param.Value = strOppID;
            lstParam.Add(param);

            DataSet ds;
            bool abc = false;
            return ds = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselScoreStatusBidWinability]", lstParam, abc);
        }

        public DataSet GetStakeHoldersBidWinability(string strOppID)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            param = new SqlParameter();
            param.ParameterName = "@vsOppId";
            param.DbType = DbType.String;
            param.Value = strOppID;
            lstParam.Add(param);

            DataSet ds;
            bool abc = false;
            return ds = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spsiuStakeholdersBidWinability]", lstParam, abc);
        }

        public DataSet GetOutofScoreKeyNameClientsDemand()
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            param = new SqlParameter();
            param.ParameterName = "@vsTableName";
            param.DbType = DbType.String;
            param.Value = "tblOppQuaClnDem";
            lstParam.Add(param);

            DataSet ds;
            bool abc = false;
            return ds = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spGetOutofScoreKeyname]", lstParam, abc);

        }

        public DataSet GetOutofScoreKeyNameClientsUrgency()
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            param = new SqlParameter();
            param.ParameterName = "@vsTableName";
            param.DbType = DbType.String;
            param.Value = "tblOppQuaClnUrg";
            lstParam.Add(param);

            DataSet ds;
            bool abc = false;
            return ds = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spGetOutofScoreKeyname]", lstParam, abc);

        }

        public DataSet GetOutofScoreKeyNameSyntelBusiness()
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            param = new SqlParameter();
            param.ParameterName = "@vsTableName";
            param.DbType = DbType.String;
            param.Value = "tblOppQuaSynBuss";
            lstParam.Add(param);

            DataSet ds;
            bool abc = false;
            return ds = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spGetOutofScoreKeyname]", lstParam, abc);

        }

        public DataSet GetOutofScoreKeyNameSyntelCom()
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            param = new SqlParameter();
            param.ParameterName = "@vsTableName";
            param.DbType = DbType.String;
            param.Value = "tblOppQuaSynCom";
            lstParam.Add(param);

            DataSet ds;
            bool abc = false;
            return ds = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spGetOutofScoreKeyname]", lstParam, abc);

        }


        public DataSet GetTopManagement()
        {
            DataSet ds = new DataSet();
            ds = new DAL.SqlHelper().GetTopManagement();
            return ds;
        }
    }
}
