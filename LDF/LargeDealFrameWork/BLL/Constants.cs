using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

namespace BLL
{
    public class Constants
    {
        //Designation names and their ids
        public const int _intSalesDesignation = 2;
        public const int _intDeliveryDirectorDesignation = 5;
        public const int _intBidManagerDesignation = 7;
        public const int _intBidCoordinatorDesignation = 8;
        public const int _intDeliveryManagerDesignation = 9;
        public const int _intDeliveryManagerSpocDesignation = 10;
        public const int _intGPTManagerDesignation = 14;
        public const int _intGPTMemberDesignation = 11;
        public const int _intTopManagementDesignation = 12;
        public const int _intBUHeadDesignation = 13;

        //Parameter name and ids 1 3 10 14
        public const int _intEmotionalParaID = 1;
        public const int _intBusinessParaID = 2;
        public const int _intInitialRevenueParaID = 3;
        public const int _intPotentialRevenueParaID = 4;
        public const int _intRiskParaID = 5;
        public const int _intProfitabilityParaID = 6;
        public const int _intMarketPenetrationParaID = 7;
        public const int _intMarketAdvantagesParaID = 8;
        public const int _intNewSolutionParaID = 9;
        public const int _intHowMuchParaID = 10;
        public const int _intHowSoonParaID = 11;
        public const int _intHowSureParaID = 12;
        public const int _intHowReadyParaID = 13;
        public const int _intSolutionAdvantageParaID = 14;
        public const int _intCompetitorParaID = 15;
        public const int _intValuePropositionAdvantgeParaID = 16;
        public const int _intCompetitorValuePropositionParaID = 17;
        public const int _intRelationshipStrengthParaID = 18;
        public const int _intCompetitorRelationshipStrengthParaID = 19;
        public const int _intExtraAdvantageParaID = 20;
        public const int _intCompetitorExtraAdvantageParaID = 21;

        //fetching constant Designations for designation based work flow
        public void  getdesignationid()
        {
            DataSet _dsdesignations = new DataSet();
           
                ArrayList lstParam = new System.Collections.ArrayList();
                SqlParameter param;

                bool abc = false;
                _dsdesignations = new DAL.SqlHelper().SelectDataSet("[dbo].[spselDesignations]", lstParam, abc);
           
            
            //return _dsdesignations;
        }


        //DataSet dsdesignationid = new BLL.Constants().getdesignationid();
        
        

    }
}
