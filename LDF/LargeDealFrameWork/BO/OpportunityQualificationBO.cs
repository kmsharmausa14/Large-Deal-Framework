using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO
{
    public class OpportunityQualificationBO
    {
        string oppNumber;
        int totalSummaryScore;
        int percentage;
        string descriptionScoreScale;
        string status;
        string dealType;
        string buHead;
        string comments;
        bool noGo;
        string oppDescription;
        DateTime startdate;
        DateTime enddate;
        

        public string OppDescription
        {
            get { return oppDescription; }
            set { oppDescription = value; }
        }

        public string OppNumber
        {
            get { return oppNumber; }
            set { oppNumber = value; }
        }

        public DateTime StartDate
        {
            get { return startdate; }
            set { startdate = value; }
        }

        public DateTime EndDate
        {
            get { return enddate; }
            set { enddate = value; }
        }

        public int TotalSummaryScore
        {
            get { return totalSummaryScore; }
            set { totalSummaryScore = value; }
        }

        public int Percentage
        {
            get { return percentage; }
            set { percentage = value; }
        }

        public string DescriptionScoreScale
        {
            get { return descriptionScoreScale; }
            set { descriptionScoreScale = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public string DealType
        {
            get { return dealType; }
            set { dealType = value; }
        }

        public string BuHead
        {
            get { return buHead; }
            set { buHead = value; }
        }
        public string Comments
        {
            get { return comments; }
            set { comments = value; }
        }
        public bool NoGo
        {
            get { return noGo; }
            set { noGo = value; }
        }

    }
}
