using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

namespace BLL
{
    public class AssignGPT
   {
        public DataSet Get_GPTDetails(string userid)
        {
            ArrayList lstParam = new System.Collections.ArrayList();
            SqlParameter param;


            param = new SqlParameter();
            param.ParameterName = "@vsUserID";
            param.DbType = DbType.String;
            param.Value = userid;
            lstParam.Add(param);


            DataSet GPT_details = new DataSet();
            bool abc = false;
            return GPT_details = (DataSet)new DAL.SqlHelper().SelectDataSet("[dbo].[spselUserGptDtls]", lstParam, abc);
        }
    }
}
