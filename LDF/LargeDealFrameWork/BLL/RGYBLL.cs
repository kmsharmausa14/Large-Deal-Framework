using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using BO;



namespace BLL
{
     public class RGYBLL
    {
        public int GetIterativeCount(string OppId)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;
            //Get iteration count
            param = new SqlParameter();
            param.ParameterName = "@vsOppId";
            param.DbType = DbType.String;
            param.Value = OppId;
            lstParam.Add(param);

            int i = 0;
            bool abc = false;

            string check =Convert.ToString( new DAL.SqlHelper().SelectValue("[dbo].[spselRgyTransaction]", lstParam, abc));
            bool nullcheck = String.IsNullOrEmpty(check);
            //i = new DAL.SqlHelper().SelectValue("[dbo].[sp_GetIterationCountOfTransaction]", lstParam, abc);
            if (nullcheck == true)
            {
                return 0;
            }
            else
            {
                return i = Convert.ToInt32(check);
            }

            
        }
        public string GetSubmissionDate(ParamcolumnsBO paramwisesend)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;
            //Get iteration count
            param = new SqlParameter();
            param.ParameterName = "@vsOppId";
            param.DbType = DbType.String;
            param.Value = paramwisesend.OppId;
            lstParam.Add(param);


            string check = Convert.ToString(new DAL.SqlHelper().GetSubmissionDate("[dbo].[spsetsubmissiondt]", lstParam));
            return check;
            //i = new DAL.SqlHelper().SelectValue("[dbo].[sp_GetIterationCountOfTransaction]", lstParam, abc);
           


        }
        public string GetBidId(ParamcolumnsBO paramwisesend)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;
            //Get iteration count
            param = new SqlParameter();
            param.ParameterName = "@vsOppId";
            param.DbType = DbType.String;
            param.Value = paramwisesend.OppId;
            lstParam.Add(param);


            string check = Convert.ToString(new DAL.SqlHelper().GetSupplierCode("[dbo].[spselBidCoOrdinatorIdForRgy]", lstParam));
            return check;
            //i = new DAL.SqlHelper().SelectValue("[dbo].[sp_GetIterationCountOfTransaction]", lstParam, abc);



        }

        public string retrieveoppname(ParamcolumnsBO paramwisesend)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;
            //Get iteration count
            param = new SqlParameter();
            param.ParameterName = "@vsOppId";
            param.DbType = DbType.String;
            param.Value = paramwisesend.OppId;
            lstParam.Add(param);


            string check = Convert.ToString(new DAL.SqlHelper().GetSupplierCode("[dbo].[spselOppNameForOppID]", lstParam));
            return check;
            //i = new DAL.SqlHelper().SelectValue("[dbo].[sp_GetIterationCountOfTransaction]", lstParam, abc);

        }

        public DataSet populateddllevel()
        {
            DataSet populateddlevel = new DataSet();
            bool abc = false;
            return populateddlevel = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselRgyProplevel]", null, abc);    
        }

        public DataSet getparamvalues()
        {
            DataSet paramvalues = new DataSet();
            bool abc = false;
            return paramvalues = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselRgyWt]", null, abc);
        }
        public void DeleteRecords(ParamcolumnsBO paramwisesend)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;


            param = new SqlParameter();
            param.ParameterName = "@vsnulOppid";
            param.DbType = DbType.String;
            param.Value = paramwisesend.OppId;
            lstParam.Add(param);

            new DAL.SqlHelper().Insert("[dbo].[spDeleteRGYParameters]", lstParam);
        }

        public void mainDeleteRecords(ParamcolumnsBO paramwisesend)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;


            param = new SqlParameter();
            param.ParameterName = "@vsnulOppid";
            param.DbType = DbType.String;
            param.Value = paramwisesend.OppId;
            lstParam.Add(param);

            new DAL.SqlHelper().Insert("[dbo].[spDeletemainRGYParameters]", lstParam);
        }
        public void Saverecords(ParamcolumnsBO paramwisesend)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;


            param = new SqlParameter();
            param.ParameterName = "@vsnulOppId";
            param.DbType = DbType.String;
            param.Value = paramwisesend.OppId;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@vsnulParamId";
            param.DbType = DbType.String;
            param.Value = paramwisesend.Paramid;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@vsnulKeyClnReq";
            param.DbType = DbType.String;
            param.Value = paramwisesend.Keyckientrequirement;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@vsnulImpProp";
            param.DbType = DbType.String;
            param.Value = paramwisesend.Impactingwhichpart;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@vsnulGapsImpArea";
            param.DbType = DbType.String;
            param.Value = paramwisesend.Gapsimprovementarea;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@vsnulOwnAddGaps";
            param.DbType = DbType.String;
            param.Value = paramwisesend.Ownertoaddressgaps;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@InulLevelProp";
            param.DbType = DbType.Int32;
            param.Value = paramwisesend.Leveltowhichimprovmrnt;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@dtnulRvwDt";
            param.DbType = DbType.Date;
            param.Value = paramwisesend.Reviewdate;
            lstParam.Add(param);

            new DAL.SqlHelper().Insert("[dbo].[spselinsRgyParamBckp]", lstParam);

        }

        public void Submitrecs(ArrayList paramwisesend)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;


            param = new SqlParameter();
            param.ParameterName = "@vsOppid";
            param.DbType = DbType.String;
            param.Value = paramwisesend[11].ToString();
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@iIter";
            param.DbType = DbType.Int32;
            param.Value = Convert.ToInt32(paramwisesend[10].ToString());
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@iBussSolnScore";
            param.DbType = DbType.Decimal;
            param.Value = Convert.ToDecimal(paramwisesend[0].ToString());
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@iTechSolnScore";
            param.DbType = DbType.Decimal;
            param.Value = Convert.ToDecimal(paramwisesend[1].ToString());
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@iSerDelModScore";
            param.DbType = DbType.Decimal;
            param.Value = Convert.ToDecimal(paramwisesend[2].ToString());
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@iTransPlanScore";
            param.DbType = DbType.Decimal;
            param.Value = Convert.ToDecimal(paramwisesend[3].ToString());
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@iGovEngModel";
            param.DbType = DbType.Decimal;
            param.Value = Convert.ToDecimal(paramwisesend[4].ToString());
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@iProMthScore";
            param.DbType = DbType.Decimal;
            param.Value = Convert.ToDecimal(paramwisesend[5].ToString());
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@iHraChnMangScore";
            param.DbType = DbType.Decimal;
            param.Value = Convert.ToDecimal(paramwisesend[6].ToString());
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@iCommAndPriceScore";
            param.DbType = DbType.Decimal;
            param.Value = Convert.ToDecimal(paramwisesend[7].ToString());
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@iIntScore";
            param.DbType = DbType.Decimal;
            param.Value = Convert.ToDecimal(paramwisesend[8].ToString());
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@iTotPercen";
            param.DbType = DbType.Decimal;
            param.Value = Convert.ToDecimal(paramwisesend[9].ToString());
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@vsWinTheme";
            param.DbType = DbType.String;
            param.Value = paramwisesend[12].ToString();
            lstParam.Add(param);

            //param = new SqlParameter();
            //param.ParameterName = "@dtSubmissionDate";
            //param.DbType = DbType.Date;
            //param.Value = paramwisesend[13].ToString();
            //lstParam.Add(param);

            new DAL.SqlHelper().Insert("[dbo].[spinsTotPercenByIter]", lstParam);

        }

        public void SaveParameters(ParamcolumnsBO paramwisesend)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;


            param = new SqlParameter();
            param.ParameterName = "@vsnulOppId";
            param.DbType = DbType.String;
            param.Value = paramwisesend.OppId;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@vsnulParamId";
            param.DbType = DbType.String;
            param.Value = paramwisesend.Paramid;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@vsnuliterationno";
            param.DbType = DbType.String;
            param.Value = paramwisesend.IterationNo;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@vsKeyClnReq";
            param.DbType = DbType.String;
            param.Value = paramwisesend.Keyckientrequirement;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@vsnulImpProp";
            param.DbType = DbType.String;
            param.Value = paramwisesend.Impactingwhichpart;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@vsnulGapsImpArea";
            param.DbType = DbType.String;
            param.Value = paramwisesend.Gapsimprovementarea;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@vsOwnAddGaps";
            param.DbType = DbType.String;
            param.Value = paramwisesend.Ownertoaddressgaps;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@ILevelProp";
            param.DbType = DbType.Int32;
            param.Value = Convert.ToInt32(paramwisesend.Leveltowhichimprovmrnt);
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@dtnulRvwDt";
            param.DbType = DbType.Date;
            param.Value = paramwisesend.Reviewdate;
            lstParam.Add(param);

            new DAL.SqlHelper().Insert("[dbo].[spdiRgyParam]", lstParam);

        }

        public void Saverecs(ArrayList paramwisesend)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;


            param = new SqlParameter();
            param.ParameterName = "@vsOppid";
            param.DbType = DbType.String;
            param.Value = paramwisesend[11].ToString();
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@iIter";
            param.DbType = DbType.Int32;
            param.Value = Convert.ToInt32(paramwisesend[10].ToString());
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@iBussSolnScore";
            param.DbType = DbType.Decimal;
            param.Value = Convert.ToDecimal(paramwisesend[0].ToString());
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@iTechSolnScore";
            param.DbType = DbType.Decimal;
            param.Value = Convert.ToDecimal(paramwisesend[1].ToString());
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@iSerDelModScore";
            param.DbType = DbType.Decimal;
            param.Value = Convert.ToDecimal(paramwisesend[2].ToString());
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@iTransPlanScore";
            param.DbType = DbType.Decimal;
            param.Value = Convert.ToDecimal(paramwisesend[3].ToString());
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@iGovEngModel";
            param.DbType = DbType.Decimal;
            param.Value = Convert.ToDecimal(paramwisesend[4].ToString());
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@iProMthScore";
            param.DbType = DbType.Decimal;
            param.Value = Convert.ToDecimal(paramwisesend[5].ToString());
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@iHraChnMangScore";
            param.DbType = DbType.Decimal;
            param.Value = Convert.ToDecimal(paramwisesend[6].ToString());
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@iCommAndPriceScore";
            param.DbType = DbType.Decimal;
            param.Value = Convert.ToDecimal(paramwisesend[7].ToString());
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@iIntScore";
            param.DbType = DbType.Decimal;
            param.Value = Convert.ToDecimal(paramwisesend[8].ToString());
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@iTotPercen";
            param.DbType = DbType.Decimal;
            param.Value = Convert.ToDecimal(paramwisesend[9].ToString());
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@vsWinTheme";
            param.DbType = DbType.String;
            param.Value = paramwisesend[12].ToString();
            lstParam.Add(param);


            new DAL.SqlHelper().Insert("[dbo].[spinsBckpTotPercenByIter]", lstParam);

        }

        public void UpdateStatus(string Oppid)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;


            param = new SqlParameter();
            param.ParameterName = "@vsOppId";
            param.DbType = DbType.String;
            param.Value = Oppid;
            lstParam.Add(param);
            
            bool abc = false;
            new DAL.SqlHelper().SelectValue("[dbo].[spudpRgyTransaction]", lstParam, abc);

        }

          public void UpdateStatusNonApproval(string Oppid , string comments)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;


            param = new SqlParameter();
            param.ParameterName = "@vsOppId";
            param.DbType = DbType.String;
            param.Value = Oppid;
            lstParam.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@vsComments";
            param.DbType = DbType.String;
            param.Value = comments;
            lstParam.Add(param);
            
            bool abc = false;
            new DAL.SqlHelper().SelectValue("[dbo].[spudpRgyTransactionNotApproved]", lstParam, abc);

        }
         
        public DataSet retrieveparams(string Oppid)
        {
            DataSet allrecs = new DataSet();
            try
            {
                ArrayList lstParam = new System.Collections.ArrayList();
                SqlParameter param;


                param = new SqlParameter();
                param.ParameterName = "@vsOppId";
                param.DbType = DbType.String;
                param.Value = Oppid;
                lstParam.Add(param);  
                bool abc = false;
                allrecs = new DAL.SqlHelper().SelectDataSet("[dbo].[spselRetreiveDataForRGYChk]", lstParam, abc);
            }
            catch
            {
            }
            return allrecs;
        }

        public DataSet retrievestatus(string Oppid)
        {
            DataSet allrecs = new DataSet();
            try
            {
                ArrayList lstParam = new System.Collections.ArrayList();
                SqlParameter param;


                param = new SqlParameter();
                param.ParameterName = "@vsnulOppId";
                param.DbType = DbType.String;
                param.Value = Oppid;
                lstParam.Add(param);
                bool abc = false;
                allrecs = new DAL.SqlHelper().SelectDataSet("[dbo].[spselRetreiveDataForRGYChkStat]", lstParam, abc);
            }
            catch
            {
            }
            return allrecs;
        }

        public DataSet retrieveparamsbckp(string Oppid)
        {
            DataSet allrecs = new DataSet();
            try
            {
                ArrayList lstParam = new System.Collections.ArrayList();
                SqlParameter param;


                param = new SqlParameter();
                param.ParameterName = "@vsOppId";
                param.DbType = DbType.String;
                param.Value = Oppid;
                lstParam.Add(param);
                bool abc = false;
                allrecs = new DAL.SqlHelper().SelectDataSet("[dbo].[spselRetreiveBkpDataForRGYChk]", lstParam, abc);
            }
            catch
            {
            }
            return allrecs;
        }

}
}
