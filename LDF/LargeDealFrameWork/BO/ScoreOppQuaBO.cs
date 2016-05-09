using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO
{
    public class ScoreOppQuaBO
    {
        int scaleId;
        string scale;
        string description;
        string tableName;

        public int ScaleID
        {
            get { return scaleId; }
            set { scaleId = value; }
        }

        public string Scale
        {
            get { return scale; }
            set { scale = value; }
        }

        public string Scale_Description
        {
            get { return description; }
            set { description = value; }
        }

        public string TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }
    }
}
