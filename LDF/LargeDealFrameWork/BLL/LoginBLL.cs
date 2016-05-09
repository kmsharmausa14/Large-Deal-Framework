using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class LoginBLL
    {
        public DataTable validateUser(string UserName, string Password)
        {
            DataTable dt = new DAL.AdminDAL().validateUser(UserName,Password);
            return dt;
        }

        public bool resetPassword(string UserName)
        {
            bool pass = new DAL.AdminDAL().resetPassword(UserName);
            return pass;
        }

        public bool changePassword(string UserID, string NewPassword)
        {
            bool pass = new DAL.AdminDAL().changePassword(UserID, NewPassword);
            return pass;
        }
        public DataTable userExist(string UserName)
        {
            DataTable dt = new DAL.AdminDAL().userExist(UserName);
            return dt;
        }
    }
}
