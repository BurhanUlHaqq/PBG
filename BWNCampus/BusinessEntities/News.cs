
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    public class News
    {
        //Private Variables////////////////////////////////////////////////////////////////////////
        Int64 intNewsID;
        string strNewsTitle;
        string strNewsDetails;
        Int64 intCreatedByUserID;
        DateTime datCreateDateTime;

        ///////////////////////////////////////////////////////////////////////////////////////////

        //Public Properties////////////////////////////////////////////////////////////////////////

        public Int64 NewsID
        {
            get
            {
                return intNewsID;
            }
            set
            {
                intNewsID = value;
            }
        }
        public string NewsTitle
        {
            get
            {
                return strNewsTitle;
            }
            set
            {
                strNewsTitle = value;
            }
        }
        public string NewsDetails
        {
            get
            {
                return strNewsDetails;
            }
            set
            {
                strNewsDetails = value;
            }
        }
        public Int64 CreatedByUserID
        {
            get
            {
                return intCreatedByUserID;
            }
            set
            {
                intCreatedByUserID = value;
            }
        }
        public DateTime CreateDateTime
        {
            get
            {
                return datCreateDateTime;
            }
            set
            {
                datCreateDateTime = value;
            }
        }

       
    }
}