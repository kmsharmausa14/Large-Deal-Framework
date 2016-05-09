using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace BO
{
    public static class clsDesignationList
    {
       public static Hashtable hsDesignationList=null;
        

        public static void PopulateDesignationList(DataSet ds)
        {
            hsDesignationList = new Hashtable();

            if (ds != null)
            {
                if (ds.Tables[0] != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            hsDesignationList.Add(dr[0], dr[1]);
                        }

                    }
                }
            }
            

        }
        public static int GetDesignationID(EnumDesignation val)
        {
            
            int desigId = 0;
            string designationdesc = string.Empty;

            NameValueCollection appSettings = ConfigurationManager.AppSettings;
            designationdesc = appSettings[val.ToString()].ToString();
            
            foreach (DictionaryEntry de in hsDesignationList)
            {
                if (de.Value.ToString().ToLower() == designationdesc.ToLower().ToString())
                {
                    desigId = Convert.ToInt32(de.Key);
                    return desigId;
                }
            }
            
            return desigId;
        }
       

    }
   public  enum EnumDesignation
    {
        Admin,
    PrimarySalesSPoc,
    SecondarySalesSPoc,
    DMSales,
    DeliveryDirector,
    VerticalPreSalesHead,
    BidManager,
    BidCoordinator,
    DeliveryManager,
    DeliveryManagerSPoC,
    GPTMember,
    TopManagement,
    BUHead,
    GPTHead,
    GeographyHead
    }
}
