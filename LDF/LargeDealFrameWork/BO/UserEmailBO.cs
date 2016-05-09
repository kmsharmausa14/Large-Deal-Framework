using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO
{
    public class UserEmailBO
    {
        string fromEmailId;
        string toEmailId;
        string subject;
        string body;
        string bidManagerEmailId;
        string oppNumber;
        string toFirstName;
        string fromFirstName;


        public string OppNumber
        {
            get { return oppNumber; }
            set { oppNumber = value; }
        }

        public string ToFirstName
        {
            get { return toFirstName; }
            set { toFirstName = value; }
        }


        public string FromFirstName
        {
            get { return fromFirstName; }
            set { fromFirstName = value; }
        }

        public string FromEmailId
        {
            get { return fromEmailId; }
            set { fromEmailId = value; }
        }


        public string ToEmailId
        {
            get { return toEmailId; }
            set { toEmailId = value; }
        }


        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }


        public string Body
        {
            get { return body; }
            set { body = value; }
        }
        public string BidManagerEmailId
        {
            get { return bidManagerEmailId; }
            set { bidManagerEmailId = value; }
        }
    }
}
