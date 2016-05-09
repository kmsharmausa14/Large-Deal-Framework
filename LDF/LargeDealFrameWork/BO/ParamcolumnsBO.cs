using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO
{
    [Serializable]
     public class ParamcolumnsBO
    {
        #region Private Variables
        private string _keyckientrequirement;
        private string _impactingwhichpart;
        private string _leveltowhichimprovmrnt;
        private string _gapsimprovementarea;
        private string _ownertoaddressgaps;
        private DateTime _reviewdate;
        private int _totalscore;
        private string _oppid;
        private string _paramid;
        private int _iterationno;
        private int _mainid;
        private int _iterativeno;
        #endregion 

        #region Public Variables
        public string Keyckientrequirement
        {
            get { return _keyckientrequirement; }
            set { _keyckientrequirement = value; }
        }

        public string Impactingwhichpart
        {
            get { return _impactingwhichpart; }
            set { _impactingwhichpart = value; }
        }

        public string Leveltowhichimprovmrnt
        {
            get { return _leveltowhichimprovmrnt; }
            set { _leveltowhichimprovmrnt = value; }
        }

        public string Gapsimprovementarea
        {
            get { return _gapsimprovementarea; }
            set { _gapsimprovementarea = value; }
        }

        public string Ownertoaddressgaps
        {
            get { return _ownertoaddressgaps; }
            set { _ownertoaddressgaps = value; }
        }

        public DateTime Reviewdate
        {
            get { return _reviewdate; }
            set { _reviewdate = value; }
        }

        public int Totalscore
        {
            get { return _totalscore; }
            set { _totalscore = value; }
        }

        public string  OppId
        {
            get { return _oppid; }
            set { _oppid = value; }
        }

        public string Paramid
        {
            get { return _paramid; }
            set { _paramid = value; }
        }

        public int  Mainid
        {
            get { return _mainid; }
            set { _mainid = value; }
        }

        public int IterationNo
        {
            get { return _iterationno; }
            set { _iterationno = value; }
        }

        #endregion
    }
}
