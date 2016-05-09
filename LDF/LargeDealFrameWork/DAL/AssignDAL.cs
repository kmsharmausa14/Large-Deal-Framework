using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class AssignDAL
    {
        string _connStr = string.Empty;
        private string connString()
        {
            try
            {
                //byte[] byt = Convert.FromBase64String(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DAL.Properties.Settings.LDFSystem"].ConnectionString);

                string connString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DAL.Properties.Settings.LDFSystem"].ConnectionString;
                _connStr = connString;
            }
            catch (Exception ex)
            {
            }
            return _connStr;
        }

        public bool Assign(string _stroppid, string _strprimaryDD, string _strsecondaryDD)
        {
            SqlConnection con = new SqlConnection(connString());

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spupdAssigndd";

            cmd.Parameters.Add("@vsOppid", SqlDbType.NVarChar).Value = _stroppid;
            cmd.Parameters.Add("@vsPrimaryDD", SqlDbType.NVarChar).Value = _strprimaryDD;
            cmd.Parameters.Add("@vsSecondaryDD", SqlDbType.NVarChar).Value = _strsecondaryDD;

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
        public bool AssignDMSpoc(string _stroppid, string _strbidmanagerprimary, string _strbidmanagersecondary)
        {
            SqlConnection con = new SqlConnection(connString());

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spupdAssignDMSpoc";

            cmd.Parameters.Add("@vsOppid", SqlDbType.NVarChar).Value = _stroppid;
            cmd.Parameters.Add("@vsPrimaryDD", SqlDbType.NVarChar).Value = _strbidmanagerprimary;
            cmd.Parameters.Add("@vsSecondaryDD", SqlDbType.NVarChar).Value = _strbidmanagersecondary;

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
        public bool AssignBM(string _stroppid, string _strbidmanagerprimary, string _strbidmanagersecondary)
        {
            SqlConnection con = new SqlConnection(connString());

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spupdAssignBM";

            cmd.Parameters.Add("@vsOppid", SqlDbType.NVarChar).Value = _stroppid;
            cmd.Parameters.Add("@vsPrimaryBM", SqlDbType.NVarChar).Value = _strbidmanagerprimary;
            cmd.Parameters.Add("@vsSecondaryBM", SqlDbType.NVarChar).Value = _strbidmanagersecondary;

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
        public bool AssignBC(string _stroppid, string _strbidcoordinatorprimary, string _strbidcoordinatorsecondary)
        {
            SqlConnection con = new SqlConnection(connString());

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spupdAssignBC";

            cmd.Parameters.Add("@vsOppId", SqlDbType.NVarChar).Value = _stroppid;
            cmd.Parameters.Add("@vsPrimaryBC", SqlDbType.NVarChar).Value = _strbidcoordinatorprimary;
            cmd.Parameters.Add("@vsSecondaryBC", SqlDbType.NVarChar).Value = _strbidcoordinatorsecondary;

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

        public bool AssigningGPT(string _stroppid, string _strprimaryGPT, string _strsecondaryGPT)
        {
            SqlConnection con = new SqlConnection(connString());

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spupdAssignGPT";

            cmd.Parameters.Add("@vsOppId", SqlDbType.NVarChar).Value = _stroppid;
            cmd.Parameters.Add("@vsprimaryGPT", SqlDbType.NVarChar).Value = _strprimaryGPT;
            cmd.Parameters.Add("@vssecondaryGPT", SqlDbType.NVarChar).Value = _strsecondaryGPT;

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
        public bool AssignDeliveryHead(string _stroppid, string _primaryContactid, string _secondaryContactid, string _deliveryManager)
        {
            SqlConnection con = new SqlConnection(connString());

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spupdAssignDeliveryHead";

            cmd.Parameters.Add("@vsOppId", SqlDbType.NVarChar).Value = _stroppid;
            cmd.Parameters.Add("@primaryContactid", SqlDbType.NVarChar).Value = _primaryContactid;
            cmd.Parameters.Add("@secondaryContactid", SqlDbType.NVarChar).Value = _secondaryContactid;
            cmd.Parameters.Add("@deliveryManagerspoc", SqlDbType.NVarChar).Value = _deliveryManager;
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

        public bool AssignVerticalPresalesHead(string _stroppid, string _strVPH)
        {
            SqlConnection con = new SqlConnection(connString());

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spupdAssignVerticalPshid";

            cmd.Parameters.Add("@vsOppId", SqlDbType.NVarChar).Value = _stroppid;
            cmd.Parameters.Add("@vsnulVerticalPSHId", SqlDbType.NVarChar).Value = _strVPH;
            

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

        public bool AssignBidCordinator(string _stroppid, string _strVPH)
        {
            SqlConnection con = new SqlConnection(connString());

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spupdAssignVerticalPshid";

            cmd.Parameters.Add("@vsOppId", SqlDbType.NVarChar).Value = _stroppid;
            cmd.Parameters.Add("@vsnulVerticalPSHId", SqlDbType.NVarChar).Value = _strVPH;


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
        public bool getlblPrimarySecondaryContact(string _stroppid, string _strVPH)
        {
            SqlConnection con = new SqlConnection(connString());

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spupdAssignVerticalPshid";

            cmd.Parameters.Add("@vsOppId", SqlDbType.NVarChar).Value = _stroppid;
            cmd.Parameters.Add("@vsnulVerticalPSHId", SqlDbType.NVarChar).Value = _strVPH;


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
        public DataTable getDMgrPrimarySecondaryContact(string _strOppId)
        {
            DataSet ds1 = new DataSet();
            using (SqlConnection conn = new SqlConnection(connString()))
            {
                SqlDataAdapter DataAdapter1 = new SqlDataAdapter();

                conn.Open();
                DataAdapter1.SelectCommand = new SqlCommand("SELECT [vsnulDeliveryMgrId], [vsnulSecDeliveryMgrId], [vsnulDeliveryMgrSpoc] FROM tblOppAssignDtls where " + "vsOppid = '" + _strOppId + "'", conn);
                DataAdapter1.Fill(ds1, "tblOppAssignDtls");
            }
            return ds1.Tables["tblOppAssignDtls"];
        }

        public DataTable getGPTPrimarySecondaryContact(string _strOppId)
        {
            DataSet ds1 = new DataSet();
            using (SqlConnection conn = new SqlConnection(connString()))
            {
                SqlDataAdapter DataAdapter1 = new SqlDataAdapter();

                conn.Open();
                DataAdapter1.SelectCommand = new SqlCommand("SELECT [vsnulBidCoOrdinatorId], [vsnulSecBidCoOrdinatorId] FROM tblOppAssignDtls where " + "vsOppid = '" + _strOppId + "'", conn);
                DataAdapter1.Fill(ds1, "tblOppAssignDtls");
            }
            return ds1.Tables["tblOppAssignDtls"];
        }

        public DataTable getVPPrimarySecondaryContact(string _strOppId)
        {
            DataSet ds1 = new DataSet();
            using (SqlConnection conn = new SqlConnection(connString()))
            {
                SqlDataAdapter DataAdapter1 = new SqlDataAdapter();

                conn.Open();
                DataAdapter1.SelectCommand = new SqlCommand("SELECT [vsnulBidMgrId], [vsnuSeclBidMgrId] FROM tblOppAssignDtls where " + "vsOppid = '" + _strOppId + "'", conn);
                DataAdapter1.Fill(ds1, "tblOppAssignDtls");
            }
            return ds1.Tables["tblOppAssignDtls"];
        }

        public DataTable getddlPrimarySecondaryContact(string _strOppId)
        {
            DataSet ds1 = new DataSet();
            using (SqlConnection conn = new SqlConnection(connString()))
            {
                SqlDataAdapter DataAdapter1 = new SqlDataAdapter();

                conn.Open();
                DataAdapter1.SelectCommand = new SqlCommand("SELECT vsnulBidMgrId, vsnuSeclBidMgrId FROM tblOppAssignDtls where " + "vsOppid = '" + _strOppId + "'", conn);
                DataAdapter1.Fill(ds1, "tblOppAssignDtls");
            }
            return ds1.Tables["tblOppAssignDtls"];
        }
        
        public DataTable getDHDMPrimarySecondaryContact(string _strOppId)
        {
            DataSet ds1 = new DataSet();
            using (SqlConnection conn = new SqlConnection(connString()))
            {
                SqlDataAdapter DataAdapter1 = new SqlDataAdapter();

                conn.Open();
                DataAdapter1.SelectCommand = new SqlCommand("SELECT [vsDH_DM] FROM tblAssignUnassign where " + "vsOppid = '" + _strOppId + "'", conn);
                DataAdapter1.Fill(ds1, "tblAssignUnassign");
            }
            return ds1.Tables["tblAssignUnassign"];
        }
        public DataTable getSalesPrimarySecondaryContact(string _strOppId)
        {
            DataSet ds1 = new DataSet();
            using (SqlConnection conn = new SqlConnection(connString()))
            {
                SqlDataAdapter DataAdapter1 = new SqlDataAdapter();

                conn.Open();
                DataAdapter1.SelectCommand = new SqlCommand("SELECT [vsSales_DH],[vsSales_VertPresale],[vsSales_GPT] FROM tblAssignUnassign where " + "vsOppid = '" + _strOppId + "'", conn);
                DataAdapter1.Fill(ds1, "tblAssignUnassign");
            }
            return ds1.Tables["tblAssignUnassign"];
        }
        public DataTable getSalePrimarySecondaryContact(string _strOppId)
        {
            DataSet ds1 = new DataSet();
            using (SqlConnection conn = new SqlConnection(connString()))
            {
                SqlDataAdapter DataAdapter1 = new SqlDataAdapter();

                conn.Open();
                DataAdapter1.SelectCommand = new SqlCommand("SELECT [vsnulDeliveryHeadId],[vsnuSeclDeliveryHeadId] FROM [tblOppAssignDtls] where " + "vsOppid = '" + _strOppId + "'", conn);
                DataAdapter1.Fill(ds1, "tblOppAssignDtls");
            }
            return ds1.Tables["tblOppAssignDtls"];
        }

        public DataTable getSales_VPSHPrimarySecondaryContact(string _strOppId)
        {
            DataSet ds1 = new DataSet();
            using (SqlConnection conn = new SqlConnection(connString()))
            {
                SqlDataAdapter DataAdapter1 = new SqlDataAdapter();

                conn.Open();
                DataAdapter1.SelectCommand = new SqlCommand("SELECT [vsnulVerticalPSHId] FROM [tblOppAssignDtls] where " + "vsOppid = '" + _strOppId + "'", conn);
                DataAdapter1.Fill(ds1, "tblOppAssignDtls");
            }
            return ds1.Tables["tblOppAssignDtls"];
        }
        public DataTable getSales_GPTMPrimarySecondaryContact(string _strOppId)
        {
            DataSet ds1 = new DataSet();
            using (SqlConnection conn = new SqlConnection(connString()))
            {
                SqlDataAdapter DataAdapter1 = new SqlDataAdapter();

                conn.Open();
                DataAdapter1.SelectCommand = new SqlCommand("SELECT [vsnulGptMgrId],[vsnulSecGptMgrId] FROM [tblOppAssignDtls] where " + "vsOppid = '" + _strOppId + "'", conn);
                DataAdapter1.Fill(ds1, "tblOppAssignDtls");
            }
            return ds1.Tables["tblOppAssignDtls"];
        }
        
        public DataTable getPrimarySecondaryContact(string _strOppId)
        {
            DataSet ds1 = new DataSet();
            using (SqlConnection conn = new SqlConnection(connString()))
            {
                SqlDataAdapter DataAdapter1 = new SqlDataAdapter();

                conn.Open();
                DataAdapter1.SelectCommand = new SqlCommand("SELECT [vsGPT_BidCoordinator] FROM tblAssignUnassign where " + "vsOppid = '" + _strOppId + "'", conn);
                DataAdapter1.Fill(ds1, "tblOppAssignDtls");
            }
            return ds1.Tables["tblOppAssignDtls"];
        }

        public DataTable getVPSHPrimarySecondaryContact(string _strOppId)
        {
            DataSet ds1 = new DataSet();
            using (SqlConnection conn = new SqlConnection(connString()))
            {
                SqlDataAdapter DataAdapter1 = new SqlDataAdapter();

                conn.Open();
                DataAdapter1.SelectCommand = new SqlCommand("SELECT [vsVertPresale_BidMgr] FROM tblAssignUnassign where " + "vsOppid = '" + _strOppId + "'", conn);
                DataAdapter1.Fill(ds1, "tblOppAssignDtls");
            }
            return ds1.Tables["tblOppAssignDtls"];
        }

        public DataTable getDMPrimarySecondaryContact(string _strOppId)
        {
            DataSet ds1 = new DataSet();
            using (SqlConnection conn = new SqlConnection(connString()))
            {
                SqlDataAdapter DataAdapter1 = new SqlDataAdapter();

                conn.Open();
                DataAdapter1.SelectCommand = new SqlCommand("SELECT [vsDM_SPOC] FROM tblAssignUnassign where " + "vsOppid = '" + _strOppId + "'", conn);
                DataAdapter1.Fill(ds1, "tblOppAssignDtls");
            }
            return ds1.Tables["tblOppAssignDtls"];
        }
        
        public DataTable getGPTBidPrimarySecondaryContact(string _strOppId)
        {
            DataSet ds1 = new DataSet();
            using (SqlConnection conn = new SqlConnection(connString()))
            {
                SqlDataAdapter DataAdapter1 = new SqlDataAdapter();

                conn.Open();
                DataAdapter1.SelectCommand = new SqlCommand("SELECT [vsVertPresale_BidMgr] FROM tblAssignUnassign where " + "vsOppid = '" + _strOppId + "'", conn);
                DataAdapter1.Fill(ds1, "tblAssignUnassign");
            }
            return ds1.Tables["tblAssignUnassign"];
        }

    }
}
