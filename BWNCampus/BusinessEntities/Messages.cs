using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    public class Messages
    {
        //Private Variables////////////////////////////////////////////////////////////////////////
        Int64 intMessagesID;
        string strMessageTitle;
        string strMessagesDetails;
        string strMessageSenderName;
        string strMessageSenderEmail;
        string strMessageSenderPhone;
        DateTime datCreatedDate;
        bool blnIsRead;
        Int64 intReplierID;
        public string objMessageSenderPhone;

        ///////////////////////////////////////////////////////////////////////////////////////////

        //Public Properties////////////////////////////////////////////////////////////////////////

        public Int64 MessagesID
        {
            get
            {
                return intMessagesID;
            }
            set
            {
                intMessagesID = value;
            }
        }
        public string MessageTitle
        {
            get
            {
                return strMessageTitle;
            }
            set
            {
                strMessageTitle = value;
            }
        }
        public string MessagesDetails
        {
            get
            {
                return strMessagesDetails;
            }
            set
            {
                strMessagesDetails = value;
            }
        }
        public string MessageSenderName
        {
            get
            {
                return strMessageSenderName;
            }
            set
            {
                strMessageSenderName = value;
            }
        }
        public string MessageSenderEmail
        {
            get
            {
                return strMessageSenderEmail;
            }
            set
            {
                strMessageSenderEmail = value;
            }
        }
        public string MessageSenderPhone
        {
            get
            {
                return strMessageSenderPhone;
            }
            set
            {
                strMessageSenderPhone = value;
            }
        }
        public DateTime CreatedDate
        {
            get
            {
                return datCreatedDate;
            }
            set
            {
                datCreatedDate = value;
            }
        }
        public bool IsRead
        {
            get
            {
                return blnIsRead;
            }
            set
            {
                blnIsRead = value;
            }
        }
        public Int64 ReplierID
        {
            get
            {
                return intReplierID;
            }
            set
            {
                intReplierID = value;
            }
        }
        ///////////////////////////////////////////////////////////////////////////////////////////
    }
}