using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLL
{
    public class Assign
    {
        public Boolean AssigtnDD(string _stroppid, string _strDDprimary, string _strDDsecondaty)
        {
            bool _boolinsertstatus = new DAL.AssignDAL().Assign(_stroppid, _strDDprimary, _strDDsecondaty);
            return _boolinsertstatus;
        }
        public DataTable getSalesPrimarySecondaryContact(string _strOppId)
        {
            DataTable dt = new DAL.AssignDAL().getSalesPrimarySecondaryContact(_strOppId);
            return dt;
        }
        public DataTable getSalePrimarySecondaryContact(string _strOppId)
        {
            DataTable dt = new DAL.AssignDAL().getSalePrimarySecondaryContact(_strOppId);
            return dt;
        }
        public DataTable getSales_VPSHPrimarySecondaryContact(string _strOppId)
        {
            DataTable dt = new DAL.AssignDAL().getSales_VPSHPrimarySecondaryContact(_strOppId);
            return dt;
        }
        public DataTable getSales_GPTMPrimarySecondaryContact(string _strOppId)
        {
            DataTable dt = new DAL.AssignDAL().getSales_GPTMPrimarySecondaryContact(_strOppId);
            return dt;
        }
        
        public DataTable getDHDMPrimarySecondaryContact(string _strOppId)
        {
            DataTable dt = new DAL.AssignDAL().getDHDMPrimarySecondaryContact(_strOppId);
            return dt;
        }
        public DataTable getddlPrimarySecondaryContact(string _strOppId)
        {
            DataTable dt = new DAL.AssignDAL().getddlPrimarySecondaryContact(_strOppId);
            return dt;
        }
        public DataTable getDMgrPrimarySecondaryContact(string _strOppId)
        {
            DataTable dt = new DAL.AssignDAL().getDMgrPrimarySecondaryContact(_strOppId);
            return dt;
        }
        public DataTable getGPTPrimarySecondaryContact(string _strOppId)
        {
            DataTable dt = new DAL.AssignDAL().getGPTPrimarySecondaryContact(_strOppId);
            return dt;
        }
        public DataTable getVPPrimarySecondaryContact(string _strOppId)
        {
            DataTable dt = new DAL.AssignDAL().getVPPrimarySecondaryContact(_strOppId);
            return dt;
        }
        public DataTable getPrimarySecondaryContact(string _strOppId)
        {
            DataTable dt = new DAL.AssignDAL().getPrimarySecondaryContact(_strOppId);
            return dt;
        }
        public DataTable getVPSHPrimarySecondaryContact(string _strOppId)
        {
            DataTable dt = new DAL.AssignDAL().getVPSHPrimarySecondaryContact(_strOppId);
            return dt;
        }
        public DataTable getDMPrimarySecondaryContact(string _strOppId)
        {
            DataTable dt = new DAL.AssignDAL().getDMPrimarySecondaryContact(_strOppId);
            return dt;
        }
        public Boolean AssigtnGPT(string _stroppid, string _strGPTprimary, string _strGPTsecondaty)
        {
            bool _boolinsertstatus = new DAL.AssignDAL().AssigningGPT(_stroppid, _strGPTprimary, _strGPTsecondaty);
            return _boolinsertstatus;
        }

        public Boolean AssigtnverticalPresalesHead(string _stroppid, string _strVPH)
        {
            bool _boolinsertstatus = new DAL.AssignDAL().AssignVerticalPresalesHead(_stroppid, _strVPH);
            return _boolinsertstatus;
        }
        public Boolean AssignDH(string _stroppid, string _primaryContactid, string _secondaryContactid, string _deliveryManager)
        {
            bool _boolinsertstatus = new DAL.AssignDAL().AssignDeliveryHead(_stroppid, _primaryContactid, _secondaryContactid, _deliveryManager);
            return _boolinsertstatus;
        }
        
        public Boolean AssignBidcoordinator( string _strBCprimary)
        {
            bool abc= false;
            return abc; 
        }

        public Boolean AssignBC(string _stroppid, string _strbidcoordinatorprimary, string _strbidcoordinatorsecondary)
        {
            bool _boolinsertstatus = new DAL.AssignDAL().AssignBC(_stroppid, _strbidcoordinatorprimary, _strbidcoordinatorsecondary);
            return _boolinsertstatus;
        }
        public Boolean AssignBM(string _stroppid, string _strbidmanagerprimary, string _strbidmanagersecondary)
        {
            bool _boolinsertstatus = new DAL.AssignDAL().AssignBM(_stroppid, _strbidmanagerprimary, _strbidmanagersecondary);
            return _boolinsertstatus;
        }
        public Boolean AssignDMSpoc(string _stroppid, string _strbidmanagerprimary, string _strbidmanagersecondary)
        {
            bool _boolinsertstatus = new DAL.AssignDAL().AssignDMSpoc(_stroppid, _strbidmanagerprimary, _strbidmanagersecondary);
            return _boolinsertstatus;
        }
      
    }
}
