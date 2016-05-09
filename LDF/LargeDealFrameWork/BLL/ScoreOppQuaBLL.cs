using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using BO;
using System.Data;
using DAL;

namespace BLL
{
    public class ScoreOppQuaBLL
    {
        public void AddScoreOppQua(ScoreOppQuaBO scoreOppQuaBO)
        {
            //Add score scale by admin
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            param = new SqlParameter();
            param.ParameterName = "@vsScale";
            param.DbType = DbType.String;
            param.Value = scoreOppQuaBO.Scale;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@vsDesc";
            param.DbType = DbType.String;
            param.Value = scoreOppQuaBO.Scale_Description;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@vstablename";
            param.DbType = DbType.String;
            param.Value = scoreOppQuaBO.TableName;
            lstParam.Add(param);

            new DAL.SqlHelper().Insert("[dbo].[spinsOppQuaScore]", lstParam);
        }

        public void UpdateScoreOppQua(ScoreOppQuaBO scoreOppQuaBO)
        {
            //Update score scale by admin
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            param = new SqlParameter();
            param.ParameterName = "@Iscaleid";
            param.DbType = DbType.Int32;
            param.Value = scoreOppQuaBO.ScaleID;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@vsScale";
            param.DbType = DbType.String;
            param.Value = scoreOppQuaBO.Scale;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@vsDesc";
            param.DbType = DbType.String;
            param.Value = scoreOppQuaBO.Scale_Description;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@vstablename";
            param.DbType = DbType.String;
            param.Value = scoreOppQuaBO.TableName;
            lstParam.Add(param);

            bool bool_val = false;
            bool_val = new DAL.SqlHelper().UpdateData("[dbo].[spupdScoreOppQua]", lstParam, bool_val);
        }

        public DataSet GetScoreOppQua(ScoreOppQuaBO scoreOppQuaBO)
        {
            //Get all score scale 
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            param = new SqlParameter();
            param.ParameterName = "@vstablename";
            param.DbType = DbType.String;
            param.Value = scoreOppQuaBO.TableName;
            lstParam.Add(param);

            DataSet ds;
            bool abc = false;
            return ds = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselScaleDtls]", lstParam, abc);
        }

        public DataSet GetScoreOppQuaByActiveMainScreen()
        {
            //Get active score scale 

            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            param = new SqlParameter();
            param.ParameterName = "@vstablename";
            param.DbType = DbType.String;
            param.Value = "tblOppQuaMainLegend";
            lstParam.Add(param);

            DataSet ds;
            bool abc = false;
            return ds = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselOppQuaScaleDtlsByActive]", lstParam, abc);
        }

        public DataSet GetScoreOppQuaByActiveScreen1()
        {
            //Get active score scale 

            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            param = new SqlParameter();
            param.ParameterName = "@vstablename";
            param.DbType = DbType.String;
            param.Value = "tblOppQuaClnDemLegend";
            lstParam.Add(param);
            DataSet ds;
            bool abc = false;
            return ds = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselOppQuaScaleDtlsByActive]", lstParam, abc);
        }

        public DataSet GetScoreOppQuaByActiveScreen2()
        {
            //Get active score scale 

            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            param = new SqlParameter();
            param.ParameterName = "@vstablename";
            param.DbType = DbType.String;
            param.Value = "tblOppQuaSynBussLegend";
            lstParam.Add(param);

            DataSet ds;
            bool abc = false;
            return ds = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselOppQuaScaleDtlsByActive]", lstParam, abc);
        }

        public DataSet GetScoreOppQuaByActiveScreen3()
        {
            //Get active score scale 

            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            param = new SqlParameter();
            param.ParameterName = "@vstablename";
            param.DbType = DbType.String;
            param.Value = "tblOppQuaClnUrgLegend";
            lstParam.Add(param);

            DataSet ds;
            bool abc = false;
            return ds = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselOppQuaScaleDtlsByActive]", lstParam, abc);
        }

        public DataSet GetScoreOppQuaByActiveScreen4()
        {
            //Get active score scale 

            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            param = new SqlParameter();
            param.ParameterName = "@vstablename";
            param.DbType = DbType.String;
            param.Value = "tblOppQuaSynComLegend";
            lstParam.Add(param);

            DataSet ds;
            bool abc = false;
            return ds = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselOppQuaScaleDtlsByActive]", lstParam, abc);
        }

        public DataSet GetScoreScaleBidWinScore()
        {
            //Get active score scale 

            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            param = new SqlParameter();
            param.ParameterName = "@vstablename";
            param.DbType = DbType.String;
            param.Value = "tblBidWinScoreLegend";
            lstParam.Add(param);

            DataSet ds;
            bool abc = false;
            return ds = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselOppQuaScaleDtlsByActive]", lstParam, abc);
        }

        public bool DeleteScoreOppQua(ScoreOppQuaBO scoreOppQuaBO)
        {
            //Delete score scale
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            param = new SqlParameter();
            param.ParameterName = "@IscaleId";
            param.DbType = DbType.String;
            param.Value = scoreOppQuaBO.ScaleID;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@vstablename";
            param.DbType = DbType.String;
            param.Value = scoreOppQuaBO.TableName;
            lstParam.Add(param);

            
            bool abc = false;
            return abc = new DAL.SqlHelper().DeleteData("[dbo].[spdelOppQuaScore]", lstParam, abc);
        }

        public DataSet GetScoreScaleDescriptionScreen1()
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            param = new SqlParameter();
            param.ParameterName = "@vstablename";
            param.DbType = DbType.String;
            param.Value = "tblOppQuaClnDem";
            lstParam.Add(param);

            DataSet ds;
            bool abc = false;
            return ds = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselScoreScaleDescrip]", lstParam, abc);

        }

        public DataSet GetScoreScaleDescriptionScreen2()
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            param = new SqlParameter();
            param.ParameterName = "@vstablename";
            param.DbType = DbType.String;
            param.Value = "tblOppQuaSynBuss";
            lstParam.Add(param);

            DataSet ds;
            bool abc = false;
            return ds = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselScoreScaleDescrip]", lstParam, abc);

        }

        public DataSet GetScoreScaleDescriptionScreen3()
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            param = new SqlParameter();
            param.ParameterName = "@vstablename";
            param.DbType = DbType.String;
            param.Value = "tblOppQuaClnUrg";
            lstParam.Add(param);

            DataSet ds;
            bool abc = false;
            return ds = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselScoreScaleDescrip]", lstParam, abc);

        }

        public DataSet GetScoreScaleDescriptionScreen4()
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            param = new SqlParameter();
            param.ParameterName = "@vstablename";
            param.DbType = DbType.String;
            param.Value = "tblOppQuaSynCom";
            lstParam.Add(param);

            DataSet ds;
            bool abc = false;
            return ds = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselScoreScaleDescrip]", lstParam, abc);

        }

        public void AddScoreDescriptionOppQua(QualificationDetailsBO qualificationDetailsBO)
        {
            //Add score scale by admin
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            param = new SqlParameter();
            param.ParameterName = "@vsOppId";
            param.DbType = DbType.String;
            param.Value = qualificationDetailsBO.OppNumber;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@IParamId";
            param.DbType = DbType.Int32;
            param.Value = qualificationDetailsBO.ParaID;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@vsParameter";
            param.DbType = DbType.String;
            param.Value = qualificationDetailsBO.ParaDescription;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@Iscore";
            param.DbType = DbType.Int32;
            param.Value = qualificationDetailsBO.Score;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@vsDescription";
            param.DbType = DbType.String;
            param.Value = qualificationDetailsBO.Description;
            lstParam.Add(param);



            new DAL.SqlHelper().Insert("[dbo].[spinsOppQuaParamDtlsBackup]", lstParam);
        }

        public DataSet GetScoreDescriptionForParameterScreen1(QualificationDetailsBO qualificationDetailsBO)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            param = new SqlParameter();
            param.ParameterName = "@vsOppId";
            param.DbType = DbType.String;
            param.Value = qualificationDetailsBO.OppNumber;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@IParamId";
            param.DbType = DbType.Int32;
            param.Value = qualificationDetailsBO.ParaID;
            lstParam.Add(param);

            DataSet ds;
            bool abc = false;
            return ds = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselOppQuaScoreDescripParambkp]", lstParam, abc);

        }

        public void UpdateScoreDescriptionParameter(QualificationDetailsBO qualificationDetailsBO)
        {
            //Update score scale by admin
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            param = new SqlParameter();
            param.ParameterName = "@vsOppId";
            param.DbType = DbType.String;
            param.Value = qualificationDetailsBO.OppNumber;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@IParamId";
            param.DbType = DbType.Int32;
            param.Value = qualificationDetailsBO.ParaID;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@Iscore";
            param.DbType = DbType.Int32;
            param.Value = qualificationDetailsBO.Score;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@vsDescription";
            param.DbType = DbType.String;
            param.Value = qualificationDetailsBO.Description;
            lstParam.Add(param);

            bool bool_val = false;
            bool_val = new DAL.SqlHelper().UpdateData("[dbo].[spudpOppQuaParamDtlsBackup]", lstParam, bool_val);
        }

        public int GetIterativeCount()
        {
            //Get iteration count
            int i = 0;
            bool abc = false;
            return i = (int)new DAL.SqlHelper().SelectValue("[dbo].[spselRgyTransaction]", null, abc);
        }

        public void AddScoreDescriptionOppQuaforAllScreens(QualificationDetailsBO qualificationDetailsBO)
        {
            //Add score scale by admin
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            param = new SqlParameter();
            param.ParameterName = "@vsOppId";
            param.DbType = DbType.String;
            param.Value = qualificationDetailsBO.OppNumber;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@IParamId";
            param.DbType = DbType.String;
            param.Value = qualificationDetailsBO.ParaID;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@vsParameter";
            param.DbType = DbType.String;
            param.Value = qualificationDetailsBO.ParaDescription;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@Iscore";
            param.DbType = DbType.String;
            param.Value = qualificationDetailsBO.Score;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@vsDescription";
            param.DbType = DbType.String;
            param.Value = qualificationDetailsBO.Description;
            lstParam.Add(param);



            new DAL.SqlHelper().Insert("[dbo].[spinsOppQuaParamDtls]", lstParam);
        }

        public DataSet GetScoreDescriptionParameterforAllScreens(QualificationDetailsBO qualificationDetailsBO)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            param = new SqlParameter();
            param.ParameterName = "@vsOppId";
            param.DbType = DbType.String;
            param.Value = qualificationDetailsBO.OppNumber;
            lstParam.Add(param);

            DataSet ds;
            bool abc = false;
            return ds = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselOppQuaParamDtls]", lstParam, abc);

        }

        public DataSet GetStatusForOppQua()
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            param = new SqlParameter();
            param.ParameterName = "@vstablename";
            param.DbType = DbType.String;
            param.Value = "tblOppQuaStatus";
            lstParam.Add(param);

            DataSet ds;
            bool abc = false;
            return ds = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselDealTypeStatusForOppQua]", lstParam, abc);

        }

        public DataSet GetDealTypeForOppQua()
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            param = new SqlParameter();
            param.ParameterName = "@vstablename";
            param.DbType = DbType.String;
            param.Value = "tblOppQuaDealType";
            lstParam.Add(param);

            DataSet ds;
            bool abc = false;
            return ds = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselDealTypeStatusForOppQua]", lstParam, abc);

        }

        public void AddOpportunityQualificationDetails(OpportunityQualificationBO opportunityQualificationBO)
        {
            //Add score scale by admin
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            param = new SqlParameter();
            param.ParameterName = "@vsOppId";
            param.DbType = DbType.String;
            param.Value = opportunityQualificationBO.OppNumber;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@ITotSumScore";
            param.DbType = DbType.Int32;
            param.Value = opportunityQualificationBO.TotalSummaryScore;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@IOppPer";
            param.DbType = DbType.Int32;
            param.Value = opportunityQualificationBO.Percentage;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@vsDescripScale";
            param.DbType = DbType.String;
            param.Value = opportunityQualificationBO.DescriptionScoreScale;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@vsnulStatus";
            param.DbType = DbType.String;
            param.Value = opportunityQualificationBO.Status;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@vsnulDealType";
            param.DbType = DbType.String;
            param.Value = opportunityQualificationBO.DealType;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@vsBUHead";
            param.DbType = DbType.String;
            param.Value = opportunityQualificationBO.BuHead;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@vsnulComments";
            param.DbType = DbType.String;
            param.Value = opportunityQualificationBO.Comments;
            lstParam.Add(param);

            new DAL.SqlHelper().Insert("[dbo].[spinsOppQualScnDtls]", lstParam);
        }

        public DataSet GetOpportunityQualificationDetails(string OppNumber)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            param = new SqlParameter();
            param.ParameterName = "@vsOppId";
            param.DbType = DbType.String;
            param.Value = OppNumber;
            lstParam.Add(param);

            DataSet ds;
            bool abc = false;
            return ds = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselOppQualScnDtls]", lstParam, abc);

        }

        public DataSet GetOpportunityQualificationDetailsAll(string OppNumber)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            param = new SqlParameter();
            param.ParameterName = "@vsOppId";
            param.DbType = DbType.String;
            param.Value = OppNumber;
            lstParam.Add(param);

            DataSet ds;
            bool abc = false;
            return ds = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselOppQualScnDtlsAll]", lstParam, abc);

        }

        public DataSet InsertDeleteOpportunity(OpportunityQualificationBO opportunityQualificationBO)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            param = new SqlParameter();
            param.ParameterName = "@vsOppId";
            param.DbType = DbType.String;
            param.Value = opportunityQualificationBO.OppNumber;
            lstParam.Add(param);


            param = new SqlParameter();
            param.ParameterName = "@vsStatus";
            param.DbType = DbType.String;
            param.Value = opportunityQualificationBO.Status;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@vsComments";
            param.DbType = DbType.String;
            param.Value = opportunityQualificationBO.Comments;
            lstParam.Add(param);


            param = new SqlParameter();
            param.ParameterName = "@vsOppDescrp";
            param.DbType = DbType.String;
            param.Value = opportunityQualificationBO.OppDescription;
            lstParam.Add(param);

            DataSet ds;
            bool abc = false;
            return ds = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spinsdelOpportunityGPT]", lstParam, abc);
        }

        public void InsertUpdateOpportunitytoClose(string oppID)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            param = new SqlParameter();
            param.ParameterName = "@vsOppId";
            param.DbType = DbType.String;
            param.Value = oppID;
            lstParam.Add(param);

            new DAL.SqlHelper().Insert("[dbo].[spCloseOpportunityNoGoBUhead]", lstParam);
        }



        public DataSet InsertDates(OpportunityQualificationBO opportunityQualificationBO)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;

            param = new SqlParameter();
            param.ParameterName = "@vsOppId";
            param.DbType = DbType.String;
            param.Value = opportunityQualificationBO.OppNumber;
            lstParam.Add(param);


            param = new SqlParameter();
            param.ParameterName = "@vsStartDate";
            param.DbType = DbType.String;
            param.Value = opportunityQualificationBO.StartDate;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@vsEndDate";
            param.DbType = DbType.String;
            param.Value = opportunityQualificationBO.EndDate;
            lstParam.Add(param);            

            DataSet ds;
            bool abc = false;
            return ds = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spinsStartEndDate]", lstParam, abc);
        }

    }
}

