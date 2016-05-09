using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO
{
    public class OpportunityQualificationScoresBO
    {
        string screensName;
        int oppQuaScore;
        int outof;

        public string ScreensName
        {
            get { return screensName; }
            set { screensName = value; }
        }

        public int OppQuaScore
        {
            get { return oppQuaScore; }
            set { oppQuaScore = value; }
        }

        public int Outof
        {
            get { return outof; }
            set { outof = value; }
        }
    }
}
