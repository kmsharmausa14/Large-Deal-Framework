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
    public class AutomatedMailBLL
    {
        public DataSet getStakeholdersbyOppNumberforDeliveryNotification(string strOppNumber)
        {
            //Get all score scale 
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            param = new SqlParameter();
            param.ParameterName = "@vsOppId";
            param.DbType = DbType.String;
            param.Value = strOppNumber;
            lstParam.Add(param);

            DataSet dsetStakeholdersID;
            bool abc = false;
            return dsetStakeholdersID = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spsiuStakeholdersbyOppforDeliveryNotification]", lstParam, abc);
        }
        public DataSet getOppNameForEmailAddresses(string vsOppid)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            param = new SqlParameter();
            param.ParameterName = "@vsOppid";
            param.DbType = DbType.String;
            param.Value = vsOppid;
            lstParam.Add(param);

            DataSet dsetStakeholdersID;
            bool abc = false;
            return dsetStakeholdersID = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spGetOppNameEmailAddresses]", lstParam, abc);

        }

        public DataSet getStakeholdersbyOppNumberforBUHeadApprovalNotification(string strOppNumber)
        {
            //Get all score scale 
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            param = new SqlParameter();
            param.ParameterName = "@vsOppId";
            param.DbType = DbType.String;
            param.Value = strOppNumber;
            lstParam.Add(param);

            DataSet dsetStakeholdersID;
            bool abc = false;
            return dsetStakeholdersID = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spsiuStakeholdersbyOppforBUHeadApp]", lstParam, abc);
        }

        public DataSet getStakeholdersOppStatusbyBUHead(string strOppNumber)
        {
            //Get all score scale 
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            param = new SqlParameter();
            param.ParameterName = "@vsOppId";
            param.DbType = DbType.String;
            param.Value = strOppNumber;
            lstParam.Add(param);

            DataSet dsetStakeholdersID;
            bool abc = false;
            return dsetStakeholdersID = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselStakeholdersStatusbyBUHead]", lstParam, abc);
        }

        public DataSet getStakeholderstoApproveRGYChecklist(string strOppNumber)
        {
            //Get all score scale 
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            param = new SqlParameter();
            param.ParameterName = "@vsOppId";
            param.DbType = DbType.String;
            param.Value = strOppNumber;
            lstParam.Add(param);

            DataSet dsetStakeholdersID;
            bool abc = false;
            return dsetStakeholdersID = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spsiuStakeHoldersAppbyBidMgr]", lstParam, abc);
        }

        public DataSet getEmailAddresses(string primaryId, string secondaryId)
        {
            //Get all score scale 
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            param = new SqlParameter();
            param.ParameterName = "@primaryId";
            param.DbType = DbType.String;
            param.Value = primaryId;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@secondaryId";
            param.DbType = DbType.String;
            param.Value = secondaryId;
            lstParam.Add(param);

            DataSet dsetStakeholdersID;
            bool abc = false;
            return dsetStakeholdersID = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spgetEmailAddresses]", lstParam, abc);
        }

        

        public DataSet AddEmailNotificationSent(QualificationDetailsBO qualificationDetailsBO)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            param = new SqlParameter();
            param.ParameterName = "@vsOppId";
            param.DbType = DbType.String;
            param.Value = qualificationDetailsBO.OppNumber;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@bIsNotify";
            param.DbType = DbType.Boolean;
            param.Value = qualificationDetailsBO.IsNotify;
            lstParam.Add(param);

            DataSet dsEmailNotification;
            bool abc = false;
            return dsEmailNotification = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spiuChkEmailNotificationSend]", lstParam, abc);
        }

        public DataSet GetValueEmailNotificationSent(string oppNumber)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            param = new SqlParameter();
            param.ParameterName = "@vsOppId";
            param.DbType = DbType.String;
            param.Value = oppNumber;
            lstParam.Add(param);

           
            DataSet dsEmailNotification;
            bool abc = false;
            return dsEmailNotification = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselChkEmailNotificationSend]", lstParam, abc);
        }
    }
}
