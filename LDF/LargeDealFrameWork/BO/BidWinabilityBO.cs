using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO
{
    public class BidWinabilityBO
    {
        private string strOppID;
        private string strInnovationScore;
        private string strUniquenessScore;
        private bool strIsInnovationSubmit;
        private bool strIsUniquenessScore;
        private string strStatus;

        public string OppID
        {
            get {return strOppID;}
            set { strOppID = value; }
        }

        public string InnovationScore
        {
            get { return strInnovationScore; }
            set { strInnovationScore = value; }
        }

        public string UniquenessScore
        {
            get { return strUniquenessScore; }
            set { strUniquenessScore = value; }
        }

        public bool IsInnovationSubmit
        {
            get { return strIsInnovationSubmit; }
            set { strIsInnovationSubmit = value; }
        }

        public bool IsUniquenessScore
        {
            get { return strIsUniquenessScore; }
            set { strIsUniquenessScore = value; }
        }

        public string Status
        {
            get { return strStatus; }
            set { strStatus = value; }
        }
    }
}
