using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO
{
    public class QualificationDetailsBO
    {
        string oppNumber;
        string paraDescription;
        int score;
        string description;
        int paraid;
        bool isNotify;

        public string OppNumber
        {
            get { return oppNumber; }
            set { oppNumber = value; }
        }

        public string ParaDescription
        {
            get { return paraDescription; }
            set { paraDescription = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public int Score
        {
            get { return score; }
            set { score = value; }
        }
        public int ParaID
        {
            get { return paraid; }
            set { paraid = value; }
        }

        public bool IsNotify
        {
            get { return isNotify; }
            set { isNotify = value; }
        }
    }
}
