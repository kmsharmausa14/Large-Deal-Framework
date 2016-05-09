using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
using System.Configuration;

namespace DAL
{
    public class AdminDAL
    {
        //Return Connection String 
        string _connStr = string.Empty;
        private string connString()
        {
            try
            {
                // byte[] byt = Convert.FromBase64String(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DAL.Properties.Settings.LDFSystem"].ConnectionString);

                string connString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DAL.Properties.Settings.LDFSystem"].ConnectionString;
                _connStr = connString;
            }
            catch (Exception ex)
            {
            }
            return _connStr;
        }

        public DataTable getVerticals()
        {
            DataSet ds1 = new DataSet();
            using (SqlConnection conn = new SqlConnection(connString()))
            {
                SqlDataAdapter DataAdapter1 = new SqlDataAdapter();

                conn.Open();

                DataAdapter1.SelectCommand = new SqlCommand("SELECT * FROM tblVerticals", conn);
                DataAdapter1.Fill(ds1, "tblVerticals");
            }
            return ds1.Tables["tblVerticals"];
        }

        public DataTable getPasswordforNewUserId(string _strUserId)
        {
            DataSet ds1 = new DataSet();
            using (SqlConnection conn = new SqlConnection(connString()))
            {
                SqlDataAdapter DataAdapter1 = new SqlDataAdapter();

                conn.Open();
                DataAdapter1.SelectCommand = new SqlCommand("SELECT vsnulPwd FROM tblUser where " + "vspkUsrId = '" + _strUserId + "'", conn);
                DataAdapter1.Fill(ds1, "tblUser");
            }
            return ds1.Tables["tblUser"];
        }

        public DataTable getDesignations()
        {
            DataSet ds1 = new DataSet();
            using (SqlConnection conn = new SqlConnection(connString()))
            {
                SqlDataAdapter DataAdapter1 = new SqlDataAdapter();

                conn.Open();

                DataAdapter1.SelectCommand = new SqlCommand("SELECT * FROM tblDesgn", conn);
                DataAdapter1.Fill(ds1, "tblDesgn");
            }
            return ds1.Tables["tblDesgn"];
        }

        public DataTable getLocations()
        {
            DataSet ds1 = new DataSet();
            using (SqlConnection conn = new SqlConnection(connString()))
            {
                SqlDataAdapter DataAdapter1 = new SqlDataAdapter();

                conn.Open();

                DataAdapter1.SelectCommand = new SqlCommand("SELECT * FROM tblLocationDtls", conn);
                DataAdapter1.Fill(ds1, "tblLocationDtls");
            }
            return ds1.Tables["tblLocationDtls"];
        }

        public DataTable getRoles()
        {
            DataSet ds1 = new DataSet();
            using (SqlConnection conn = new SqlConnection(connString()))
            {
                SqlDataAdapter DataAdapter1 = new SqlDataAdapter();

                conn.Open();

                DataAdapter1.SelectCommand = new SqlCommand("SELECT * FROM tblRoles", conn);
                DataAdapter1.Fill(ds1, "tblRoles");
            }
            return ds1.Tables["tblRoles"];
        }
        public bool addNewRole(string RoleName)
        {

            SqlConnection con = new SqlConnection(connString());

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spinsRole";

            cmd.Parameters.Add("@vsRoleDesc", SqlDbType.VarChar).Value = RoleName;
            

            cmd.Connection = con;

            try
            {
                con.Open();
                int pass = cmd.ExecuteNonQuery();
                if (pass == -1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            catch (SqlException exc)
            {
                throw (exc);
            }

            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                con.Close();
                con.Dispose();
            }

        }

        public bool addNewLocation(string LocationName)
        {

            SqlConnection con = new SqlConnection(connString());

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spinsLocation";

            cmd.Parameters.Add("@vsLocationName", SqlDbType.VarChar).Value = LocationName;


            cmd.Connection = con;

            try
            {
                con.Open();
                int pass = cmd.ExecuteNonQuery();
                if (pass == -1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            catch (SqlException exc)
            {
                throw (exc);
            }

            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                con.Close();
                con.Dispose();
            }

        }

        public bool addNewVertical(string VerticalName)
        {

            SqlConnection con = new SqlConnection(connString());

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spinsVertical";

            cmd.Parameters.Add("@vsVertDesc", SqlDbType.VarChar).Value = VerticalName;


            cmd.Connection = con;

            try
            {
                con.Open();
                int pass = cmd.ExecuteNonQuery();
                if (pass == -1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            catch (SqlException exc)
            {
                throw (exc);
            }

            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                con.Close();
                con.Dispose();
            }

        }

        public bool addNewDesignation(string DesignationName)
        {

            SqlConnection con = new SqlConnection(connString());

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spinsDesgn";

            cmd.Parameters.Add("@vsDesgn", SqlDbType.VarChar).Value = DesignationName;


            cmd.Connection = con;

            try
            {
                con.Open();
                int pass = cmd.ExecuteNonQuery();
                if (pass == -1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            catch (SqlException exc)
            {
                throw (exc);
            }

            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                con.Close();
                con.Dispose();
            }

        }
        public bool addNewUser(string FirstName, string MiddleName, string LastName, string EmployeeID, string EmailID, string VerticalID, int DesignationID, int LocationID)
        {

            SqlConnection con = new SqlConnection(connString());

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spinsUser";

            cmd.Parameters.Add("@vsFirstName", SqlDbType.VarChar).Value = FirstName;
            cmd.Parameters.Add("@vsMiddleName", SqlDbType.VarChar).Value = MiddleName;
            cmd.Parameters.Add("@vsLastName", SqlDbType.VarChar).Value = LastName;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = EmployeeID;
            cmd.Parameters.Add("@vsEmailId", SqlDbType.VarChar).Value = EmailID;
            cmd.Parameters.Add("@IDesgnId", SqlDbType.Int).Value = DesignationID;
            cmd.Parameters.Add("@IVertId", SqlDbType.VarChar).Value = VerticalID;
            cmd.Parameters.Add("@ILocID", SqlDbType.Int).Value = LocationID;

            cmd.Connection = con;

            try
            {
                con.Open();
                int pass = cmd.ExecuteNonQuery();
                if (pass == -1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            catch (SqlException exc)
            {
                throw (exc);
            }

            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                con.Close();
                con.Dispose();
            }

        }

        public bool changePassword(string UserID, string NewPassword)
        {

            SqlConnection con = new SqlConnection(connString());

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spupdUserpwd";

            cmd.Parameters.Add("@vsUserID", SqlDbType.VarChar).Value = UserID;
            cmd.Parameters.Add("@vsNewPwd", SqlDbType.VarChar).Value = NewPassword;

            var isChanged = cmd.Parameters.Add("@bisChanged", SqlDbType.Bit);
            isChanged.Direction = ParameterDirection.Output;

            cmd.Connection = con;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return Convert.ToBoolean(isChanged.Value);
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                con.Close();
                con.Dispose();
            }

        }

        public DataTable validateUser(string UserName, string Password)
        {
            DataTable tb = new DataTable();
            string conStr = connString();
            SqlConnection con = new SqlConnection(conStr);

            if (conStr != string.Empty)
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spselValUser";

                cmd.Parameters.Add("@vsUserID", SqlDbType.VarChar).Value = UserName;
                cmd.Parameters.Add("@vsUserpwd", SqlDbType.VarChar).Value = Password;

                cmd.Connection = con;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                try
                {
                    con.Open();
                    da.Fill(tb);
                }
                catch (Exception err)
                {
                    throw err;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                }



            }
            if (tb.Rows.Count == 0)
                return null;
            else
                return tb;

        }

        public bool resetPassword(string UserName)
        {
            SqlConnection con = new SqlConnection(connString());

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sprstUserpwd";

            cmd.Parameters.Add("@vsUserID", SqlDbType.VarChar).Value = UserName;

            var isReset = cmd.Parameters.Add("@bisReset", SqlDbType.Bit);
            isReset.Direction = ParameterDirection.Output;

            cmd.Connection = con;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return Convert.ToBoolean(isReset.Value);
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
                con.Close();
                con.Dispose();
                cmd.Parameters.Clear();
                cmd.Dispose();
            }

        }

        public DataTable getUserDetails(string UserID)
        {
            DataTable tb = new DataTable();
            string conStr = connString();
            SqlConnection con = new SqlConnection(conStr);

            if (conStr != string.Empty)
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spselUserDetails";

                cmd.Parameters.Add("@vsUserID", SqlDbType.VarChar).Value = UserID;

                cmd.Connection = con;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                try
                {
                    con.Open();
                    da.Fill(tb);
                }
                catch (Exception err)
                {
                    throw err;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                }



            }
            if (tb.Rows.Count == 0)
                return null;
            else
                return tb;

        }

        public bool updateUserDetails(string UserID, string FirstName, string MiddleName, string LastName, string EmployeeID, string EmailID, int VerticalID, int DesignationID)
        {

            SqlConnection con = new SqlConnection(connString());

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spupdUserdtls";

            cmd.Parameters.Add("@vsUserID", SqlDbType.VarChar).Value = UserID;
            cmd.Parameters.Add("@vsFirstName", SqlDbType.VarChar).Value = FirstName;
            cmd.Parameters.Add("@vsMiddleName", SqlDbType.VarChar).Value = MiddleName;
            cmd.Parameters.Add("@vsLastName", SqlDbType.VarChar).Value = LastName;
            cmd.Parameters.Add("@vsEmailId", SqlDbType.VarChar).Value = EmailID;
            cmd.Parameters.Add("@IDesgnId", SqlDbType.Int).Value = DesignationID;
            cmd.Parameters.Add("@bIsActive", SqlDbType.Bit).Value = true;
            cmd.Parameters.Add("@IVertId", SqlDbType.Int).Value = VerticalID;



            cmd.Connection = con;

            try
            {
                con.Open();
                int pass = cmd.ExecuteNonQuery();
                if (pass == -1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            catch (SqlException exc)
            {
                throw (exc);
            }

            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                con.Close();
                con.Dispose();
            }

        }

        public bool deleteUser(string UserID)
        {
            SqlConnection con = new SqlConnection(connString());

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spdeluser";

            cmd.Parameters.Add("@vsUserID", SqlDbType.NVarChar).Value = UserID;

            cmd.Connection = con;

            try
            {
                con.Open();
                int pass = cmd.ExecuteNonQuery();
                if (pass == -1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            catch (SqlException exc)
            {
                throw (exc);
            }

            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                con.Close();
                con.Dispose();
            }

        }

        public DataTable getAccountQualification()
        {
            DataTable tb = new DataTable();
            string conStr = connString();
            SqlConnection con = new SqlConnection(conStr);

            if (conStr != string.Empty)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT [IpkScaleId] ,[vsDesc] ,[bIsActive] ,[IAppMinVal] ,[InulPendMinVal] ,[IAppMaxVal],[InulPendMaxVal] ,[dtnulPendDt] FROM [dbo].[tblOppQuaMainLegend]";
                cmd.Connection = con;

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                try
                {
                    con.Open();
                    da.Fill(tb);
                }
                catch (Exception err)
                {
                    throw err;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                }
            }
            if (tb.Rows.Count == 0)
                return null;
            else
                return tb;

        }

        public void updateAccountQualification(int WeightageID, string WeightageDesc, string MinValue, string MaxValue)
        {
            string conStr = connString();
            SqlConnection con = new SqlConnection(conStr);

            if (conStr != string.Empty)
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spudpOppQuaMainLegend";

                cmd.Parameters.Add("@IscaleId", SqlDbType.Int).Value = WeightageID;
                cmd.Parameters.Add("@vsDesc", SqlDbType.VarChar).Value = WeightageDesc;
                cmd.Parameters.Add("@chvnPendMinVal", SqlDbType.NVarChar).Value = MinValue;
                cmd.Parameters.Add("@chvnPendMaxVal", SqlDbType.NVarChar).Value = MaxValue;

                cmd.Connection = con;

                try
                {
                    con.Open();

                    cmd.ExecuteNonQuery();

                    con.Close();
                }
                catch (Exception err)
                {
                    throw err;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                }
            }
        }

        public DataTable getClientDemandPresaleScore()
        {
            DataTable tb = new DataTable();
            string conStr = connString();
            SqlConnection con = new SqlConnection(conStr);

            if (conStr != string.Empty)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT [IpkScoreId],[vsTitle] ,[IMinVal] ,[IMaxVal] FROM [dbo].[tblOppQuaClnDem]";
                cmd.Connection = con;

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                try
                {
                    con.Open();
                    da.Fill(tb);
                }
                catch (Exception err)
                {
                    throw err;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                }
            }
            if (tb.Rows.Count == 0)
                return null;
            else
                return tb;

        }

        public DataTable getSyntelBusinessPriorityScore()
        {
            DataTable tb = new DataTable();
            string conStr = connString();
            SqlConnection con = new SqlConnection(conStr);

            if (conStr != string.Empty)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT [IpkScoreId],[vsTitle] ,[IMinVal] ,[IMaxVal] FROM [dbo].[tblOppQuaSynBuss]";
                cmd.Connection = con;

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                try
                {
                    con.Open();
                    da.Fill(tb);
                }
                catch (Exception err)
                {
                    throw err;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                }
            }
            if (tb.Rows.Count == 0)
                return null;
            else
                return tb;

        }

        public DataTable getClientUrgencyToBuyScore()
        {
            DataTable tb = new DataTable();
            string conStr = connString();
            SqlConnection con = new SqlConnection(conStr);

            if (conStr != string.Empty)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT [IpkScoreId],[vsTitle] ,[IMinVal] ,[IMaxVal] FROM [dbo].[tblOppQuaClnUrg]";
                cmd.Connection = con;

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                try
                {
                    con.Open();
                    da.Fill(tb);
                }
                catch (Exception err)
                {
                    throw err;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                }
            }
            if (tb.Rows.Count == 0)
                return null;
            else
                return tb;

        }

        public DataTable getSyntelCompetitiveAdvantageScore()
        {
            DataTable tb = new DataTable();
            string conStr = connString();
            SqlConnection con = new SqlConnection(conStr);

            if (conStr != string.Empty)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT [IpkScoreId],[vsTitle] ,[IMinVal] ,[IMaxVal] FROM [dbo].[tblOppQuaSynCom]";
                cmd.Connection = con;

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                try
                {
                    con.Open();
                    da.Fill(tb);
                }
                catch (Exception err)
                {
                    throw err;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                }
            }
            if (tb.Rows.Count == 0)
                return null;
            else
                return tb;

        }

        public DataTable getClientDemandPresaleScale()
        {
            DataTable tb = new DataTable();
            string conStr = connString();
            SqlConnection con = new SqlConnection(conStr);

            if (conStr != string.Empty)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT [IpkScaleId] ,[vsDesc], [IMinVal], [IMaxVal] FROM [dbo].[tblOppQuaClnDemLegend]";
                cmd.Connection = con;

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                try
                {
                    con.Open();
                    da.Fill(tb);
                }
                catch (Exception err)
                {
                    throw err;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                }
            }
            if (tb.Rows.Count == 0)
                return null;
            else
                return tb;

        }

        public DataTable getSyntelBusinessScale()
        {
            DataTable tb = new DataTable();
            string conStr = connString();
            SqlConnection con = new SqlConnection(conStr);

            if (conStr != string.Empty)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT [IpkScaleId] ,[vsDesc], [IMinVal], [IMaxVal] FROM [dbo].[tblOppQuaSynBussLegend]";
                cmd.Connection = con;

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                try
                {
                    con.Open();
                    da.Fill(tb);
                }
                catch (Exception err)
                {
                    throw err;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                }
            }
            if (tb.Rows.Count == 0)
                return null;
            else
                return tb;

        }

        public DataTable getClientUrgencyToBuyScale()
        {
            DataTable tb = new DataTable();
            string conStr = connString();
            SqlConnection con = new SqlConnection(conStr);

            if (conStr != string.Empty)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT [IpkScaleId] ,[vsDesc], [IMinVal], [IMaxVal] FROM [dbo].[tblOppQuaClnUrgLegend]";
                cmd.Connection = con;

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                try
                {
                    con.Open();
                    da.Fill(tb);
                }
                catch (Exception err)
                {
                    throw err;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                }
            }
            if (tb.Rows.Count == 0)
                return null;
            else
                return tb;

        }

        public DataTable getSyntelCompetitiveAdvantageScale()
        {
            DataTable tb = new DataTable();
            string conStr = connString();
            SqlConnection con = new SqlConnection(conStr);

            if (conStr != string.Empty)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT [IpkScaleId] ,[vsDesc], [IMinVal], [IMaxVal] FROM [dbo].[tblOppQuaSynComLegend]";
                cmd.Connection = con;

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                try
                {
                    con.Open();
                    da.Fill(tb);
                }
                catch (Exception err)
                {
                    throw err;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                }
            }
            if (tb.Rows.Count == 0)
                return null;
            else
                return tb;

        }

        public void updateClientDemandPresaleScore(int ScoreID, string MinValue, string MaxValue)
        {
            string conStr = connString();
            SqlConnection con = new SqlConnection(conStr);

            if (conStr != string.Empty)
            {
                string cmdText = "UPDATE [dbo].[tblOppQuaClnDem] SET [IMinVal] = '" + MinValue +
                        "',[IMaxVal] = '" + MaxValue + "' WHERE IpkScoreId = " + ScoreID;

                SqlCommand cmd = new SqlCommand(cmdText, con);

                try
                {
                    con.Open();

                    cmd.ExecuteNonQuery();

                    con.Close();
                }
                catch (Exception err)
                {
                    throw err;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                }
            }
        }

        public void updateSyntelBusinessScore(int ScoreID, string MinValue, string MaxValue)
        {
            string conStr = connString();
            SqlConnection con = new SqlConnection(conStr);

            if (conStr != string.Empty)
            {
                string cmdText = "UPDATE [dbo].[tblOppQuaSynBuss] SET [IMinVal] = '" + MinValue +
                        "',[IMaxVal] = '" + MaxValue + "' WHERE IpkScoreId = " + ScoreID;

                SqlCommand cmd = new SqlCommand(cmdText, con);

                try
                {
                    con.Open();

                    cmd.ExecuteNonQuery();

                    con.Close();
                }
                catch (Exception err)
                {
                    throw err;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                }
            }
        }

        public void updateClientUrgencyToBuyScore(int ScoreID, string MinValue, string MaxValue)
        {
            string conStr = connString();
            SqlConnection con = new SqlConnection(conStr);

            if (conStr != string.Empty)
            {
                string cmdText = "UPDATE [dbo].[tblOppQuaClnUrg] SET [IMinVal] = '" + MinValue +
                        "',[IMaxVal] = '" + MaxValue + "' WHERE IpkScoreId = " + ScoreID;

                SqlCommand cmd = new SqlCommand(cmdText, con);

                try
                {
                    con.Open();

                    cmd.ExecuteNonQuery();

                    con.Close();
                }
                catch (Exception err)
                {
                    throw err;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                }
            }
        }

        public void updateSyntelCompetitiveAdvantageScore(int ScoreID, string MinValue, string MaxValue)
        {
            string conStr = connString();
            SqlConnection con = new SqlConnection(conStr);

            if (conStr != string.Empty)
            {
                string cmdText = "UPDATE [dbo].[tblOppQuaSynCom] SET [IMinVal] = '" + MinValue +
                        "',[IMaxVal] = '" + MaxValue + "' WHERE IpkScoreId = " + ScoreID;

                SqlCommand cmd = new SqlCommand(cmdText, con);

                try
                {
                    con.Open();

                    cmd.ExecuteNonQuery();

                    con.Close();
                }
                catch (Exception err)
                {
                    throw err;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                }
            }
        }

        public void updateClientDemandPresaleScale(int ScaleID, string MinValue, string MaxValue)
        {
            string conStr = connString();
            SqlConnection con = new SqlConnection(conStr);

            if (conStr != string.Empty)
            {
                string cmdText = "UPDATE [dbo].[tblOppQuaClnDemLegend] SET [IMinVal] = '" + MinValue +
                        "',[IMaxVal] = '" + MaxValue + "' WHERE IpkScaleId = " + ScaleID;

                SqlCommand cmd = new SqlCommand(cmdText, con);

                try
                {
                    con.Open();

                    cmd.ExecuteNonQuery();

                    con.Close();
                }
                catch (Exception err)
                {
                    throw err;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                }
            }
        }

        public void updateSyntelBusinessScale(int ScaleID, string MinValue, string MaxValue)
        {
            string conStr = connString();
            SqlConnection con = new SqlConnection(conStr);

            if (conStr != string.Empty)
            {
                string cmdText = "UPDATE [dbo].[tblOppQuaSynBussLegend] SET [IMinVal] = '" + MinValue +
                        "',[IMaxVal] = '" + MaxValue + "' WHERE IpkScaleId = " + ScaleID;

                SqlCommand cmd = new SqlCommand(cmdText, con);

                try
                {
                    con.Open();

                    cmd.ExecuteNonQuery();

                    con.Close();
                }
                catch (Exception err)
                {
                    throw err;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                }
            }
        }

        public void updateClientUrgencyToBuyScale(int ScaleID, string MinValue, string MaxValue)
        {
            string conStr = connString();
            SqlConnection con = new SqlConnection(conStr);

            if (conStr != string.Empty)
            {
                string cmdText = "UPDATE [dbo].[tblOppQuaClnUrgLegend] SET [IMinVal] = '" + MinValue +
                        "',[IMaxVal] = '" + MaxValue + "' WHERE IpkScaleId = " + ScaleID;

                SqlCommand cmd = new SqlCommand(cmdText, con);

                try
                {
                    con.Open();

                    cmd.ExecuteNonQuery();

                    con.Close();
                }
                catch (Exception err)
                {
                    throw err;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                }
            }
        }

        public void updateSyntelCompetitiveAdvantageScale(int ScaleID, string MinValue, string MaxValue)
        {
            string conStr = connString();
            SqlConnection con = new SqlConnection(conStr);

            if (conStr != string.Empty)
            {
                string cmdText = "UPDATE [dbo].[tblOppQuaSynComLegend] SET [IMinVal] = '" + MinValue +
                        "',[IMaxVal] = '" + MaxValue + "' WHERE IpkScaleId = " + ScaleID;

                SqlCommand cmd = new SqlCommand(cmdText, con);

                try
                {
                    con.Open();

                    cmd.ExecuteNonQuery();

                    con.Close();
                }
                catch (Exception err)
                {
                    throw err;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                }
            }
        }

        public DataTable getRGYCheckListScale()
        {
            DataTable tb = new DataTable();
            string conStr = connString();
            SqlConnection con = new SqlConnection(conStr);

            if (conStr != string.Empty)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT [IpkScaleId] ,[vsDesc], [IMinVal], [IMaxVal] FROM [dbo].[tblRGYChecklist]";
                cmd.Connection = con;

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                try
                {
                    con.Open();
                    da.Fill(tb);
                }
                catch (Exception err)
                {
                    throw err;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                }
            }
            if (tb.Rows.Count == 0)
                return null;
            else
                return tb;

        }

        public void updateRGYCheckListScale(int ScaleID, string MinValue, string MaxValue)
        {
            string conStr = connString();
            SqlConnection con = new SqlConnection(conStr);

            if (conStr != string.Empty)
            {
                string cmdText = "UPDATE [dbo].[tblRGYChecklist] SET [IMinVal] = '" + MinValue +
                        "',[IMaxVal] = '" + MaxValue + "' WHERE IpkScaleId = " + ScaleID;

                SqlCommand cmd = new SqlCommand(cmdText, con);

                try
                {
                    con.Open();

                    cmd.ExecuteNonQuery();

                    con.Close();
                }
                catch (Exception err)
                {
                    throw err;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                }
            }
        }

        public DataTable getRGYWeightage()
        {
            DataTable tb = new DataTable();
            string conStr = connString();
            SqlConnection con = new SqlConnection(conStr);

            if (conStr != string.Empty)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT [Business Solution] ,[Technical Solution],[Service Delivery Model],[Transition Planning],[Governance Engagement Model],[Process Methodologies],[HR and Change Management],[Commercilas and Pricing(including business Case)] as [Commercilas and Pricing],[Integration(with respect to all the above categories)] as [Integration],Total FROM [dbo].[tblRgyWt]";
                cmd.Connection = con;

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                try
                {
                    con.Open();
                    da.Fill(tb);
                }
                catch (Exception err)
                {
                    throw err;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                }
            }
            if (tb.Rows.Count == 0)
                return null;
            else
                return tb;

        }

        public void updateRGYWeightage(int ParamID, string Value)
        {
            string conStr = connString();
            SqlConnection con = new SqlConnection(conStr);

            if (conStr != string.Empty)
            {
                string cmdText = "UPDATE [dbo].[tblRgyWt] SET [Ivalue] = '" + Value + "'";

                SqlCommand cmd = new SqlCommand(cmdText, con);

                try
                {
                    con.Open();

                    cmd.ExecuteNonQuery();

                    con.Close();
                }
                catch (Exception err)
                {
                    throw err;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                }
            }
        }

        public DataTable getBidWinabilityScale()
        {
            DataTable tb = new DataTable();
            string conStr = connString();
            SqlConnection con = new SqlConnection(conStr);

            if (conStr != string.Empty)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT [IpkScaleId] ,[vsDesc], [IMinVal], [IMaxVal] FROM [dbo].[tblScaleBidWinability]";
                cmd.Connection = con;

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                try
                {
                    con.Open();
                    da.Fill(tb);
                }
                catch (Exception err)
                {
                    throw err;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                }
            }
            if (tb.Rows.Count == 0)
                return null;
            else
                return tb;

        }

        public void updateBidWinabilityScale(int ScaleID, string MinValue, string MaxValue)
        {
            string conStr = connString();
            SqlConnection con = new SqlConnection(conStr);

            if (conStr != string.Empty)
            {
                string cmdText = "UPDATE [dbo].[tblScaleBidWinability] SET [IMinVal] = '" + MinValue +
                        "',[IMaxVal] = '" + MaxValue + "' WHERE IpkScaleId = " + ScaleID;

                SqlCommand cmd = new SqlCommand(cmdText, con);

                try
                {
                    con.Open();

                    cmd.ExecuteNonQuery();

                    con.Close();
                }
                catch (Exception err)
                {
                    throw err;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                }
            }
        }

        public DataTable getBidWinWeightage()
        {
            DataTable tb = new DataTable();
            string conStr = connString();
            SqlConnection con = new SqlConnection(conStr);

            if (conStr != string.Empty)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT [IpkWtId] ,[vsWtDesc],[dAppWt],[dnulPendWt],[dtnulPendDt] FROM [dbo].[tblBidWinWt]";
                cmd.Connection = con;

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                try
                {
                    con.Open();
                    da.Fill(tb);
                }
                catch (Exception err)
                {
                    throw err;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                }
            }
            if (tb.Rows.Count == 0)
                return null;
            else
                return tb;

        }

        public void updateBidWinWeightage(int WeightageID, string WeightageDesc, decimal Value)
        {
            string conStr = connString();
            SqlConnection con = new SqlConnection(conStr);

            if (conStr != string.Empty)
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spupdBidWinWt";

                cmd.Parameters.Add("@IwtId", SqlDbType.Int).Value = WeightageID;
                cmd.Parameters.Add("@vswtdesc", SqlDbType.VarChar).Value = WeightageDesc;
                cmd.Parameters.Add("@dpendwt", SqlDbType.Decimal).Value = Value;

                cmd.Connection = con;

                try
                {
                    con.Open();

                    cmd.ExecuteNonQuery();

                    con.Close();
                }
                catch (Exception err)
                {
                    throw err;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                }
            }
        }

        public DataTable getQualityOfResponse()
        {
            DataTable tb = new DataTable();
            string conStr = connString();
            SqlConnection con = new SqlConnection(conStr);

            if (conStr != string.Empty)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT [IpkScaleId] ,[vsDesc] ,[bIsActive] ,[IAppMinVal] ,[InulPendMinVal] ,[IAppMaxVal],[InulPendMaxVal] ,[dtnulPendDt] FROM [dbo].[tblRgyQtyResp]";
                cmd.Connection = con;

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                try
                {
                    con.Open();
                    da.Fill(tb);
                }
                catch (Exception err)
                {
                    throw err;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                }
            }
            if (tb.Rows.Count == 0)
                return null;
            else
                return tb;

        }

        public void updateQualityOfResponse(int WeightageID, string WeightageDesc, string MinValue, string MaxValue)
        {
            string conStr = connString();
            SqlConnection con = new SqlConnection(conStr);

            if (conStr != string.Empty)
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spupdRgyQtyResp";

                cmd.Parameters.Add("@IscaleId", SqlDbType.Int).Value = WeightageID;
                cmd.Parameters.Add("@vsDesc", SqlDbType.VarChar).Value = WeightageDesc;
                cmd.Parameters.Add("@chvnPendMinVal", SqlDbType.NVarChar).Value = MinValue;
                cmd.Parameters.Add("@chvnPendMaxVal", SqlDbType.NVarChar).Value = MaxValue;

                cmd.Connection = con;

                try
                {
                    con.Open();

                    cmd.ExecuteNonQuery();

                    con.Close();
                }
                catch (Exception err)
                {
                    throw err;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                }
            }
        }

        public DataTable getBidWinUniqueness()
        {
            DataTable tb = new DataTable();
            string conStr = connString();
            SqlConnection con = new SqlConnection(conStr);

            if (conStr != string.Empty)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT TOP 1000 [IpkScoreID] ,[IAppScore]  ,[InulPendScore] ,[dtnulPendDt] FROM [dbo].[tblBidWinUni]";
                cmd.Connection = con;

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                try
                {
                    con.Open();
                    da.Fill(tb);
                }
                catch (Exception err)
                {
                    throw err;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                }
            }
            if (tb.Rows.Count == 0)
                return null;
            else
                return tb;

        }

        public void updateBidWinUniqueness(int ScoreID, int Value)
        {
            string conStr = connString();
            SqlConnection con = new SqlConnection(conStr);

            if (conStr != string.Empty)
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spupdBidWinUniqueness";

                cmd.Parameters.Add("@IscoreId", SqlDbType.Int).Value = ScoreID;
                cmd.Parameters.Add("@IpendScore", SqlDbType.Int).Value = Value;

                cmd.Connection = con;

                try
                {
                    con.Open();

                    cmd.ExecuteNonQuery();

                    con.Close();
                }
                catch (Exception err)
                {
                    throw err;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                }
            }
        }

        public DataTable getBidWinInnovation()
        {
            DataTable tb = new DataTable();
            string conStr = connString();
            SqlConnection con = new SqlConnection(conStr);

            if (conStr != string.Empty)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT TOP 1000 [IpkScoreID] ,[IAppScore]  ,[InulPendScore] ,[dtnulPendDt] FROM [dbo].[tblBidWinIno]";
                cmd.Connection = con;

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                try
                {
                    con.Open();
                    da.Fill(tb);
                }
                catch (Exception err)
                {
                    throw err;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                }
            }
            if (tb.Rows.Count == 0)
                return null;
            else
                return tb;

        }

        public void updateBidWinInnovation(int WeightageID, int Value)
        {
            string conStr = connString();
            SqlConnection con = new SqlConnection(conStr);

            if (conStr != string.Empty)
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spupdBidWinInnovation";

                cmd.Parameters.Add("@IscoreId", SqlDbType.Int).Value = WeightageID;
                cmd.Parameters.Add("@IpendScore", SqlDbType.Int).Value = Value;

                cmd.Connection = con;

                try
                {
                    con.Open();

                    cmd.ExecuteNonQuery();

                    con.Close();
                }
                catch (Exception err)
                {
                    throw err;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                }
            }
        }

        public DataTable userExist(string UserName)
        {
            DataTable tb = new DataTable();
            string conStr = connString();
            SqlConnection con = new SqlConnection(conStr);

            if (conStr != string.Empty)
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spselUserExist";

                cmd.Parameters.Add("@vsUserID", SqlDbType.VarChar).Value = UserName;

                cmd.Connection = con;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                try
                {
                    con.Open();
                    da.Fill(tb);
                }
                catch (Exception err)
                {
                    throw err;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                }



            }
            if (tb.Rows.Count == 0)
                return null;
            else
                return tb;

        }
    }
}
