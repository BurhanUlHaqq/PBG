using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
   public class Services
    {
		//Private Variables////////////////////////////////////////////////////////////////////////
		Int64 intServiceID;
        string strServiceName;
        string strServiceDetails;
        string strServiceImagePath;
        Int64 intServiceCreatedByUserID;
        DateTime datServiceCreatedByDateTime;

		///////////////////////////////////////////////////////////////////////////////////////////
		
		//Public Properties////////////////////////////////////////////////////////////////////////
		
        public Int64 ServiceID
        {
	        get
	        {
		        return intServiceID;
	        }
	        set
	        {
		        intServiceID = value;
	        }
        }
        public string ServiceName
        {
	        get
	        {
		        return strServiceName;
	        }
	        set
	        {
		        strServiceName = value;
	        }
        }
        public string ServiceDetails
        {
	        get
	        {
		        return strServiceDetails;
	        }
	        set
	        {
		        strServiceDetails = value;
	        }
        }
        public string ServiceImagePath
        {
	        get
	        {
		        return strServiceImagePath;
	        }
	        set
	        {
		        strServiceImagePath = value;
	        }
        }
        public Int64 ServiceCreatedByUserID
        {
	        get
	        {
		        return intServiceCreatedByUserID;
	        }
	        set
	        {
		        intServiceCreatedByUserID = value;
	        }
        }
        public DateTime ServiceCreatedByDateTime
        {
	        get
	        {
		        return datServiceCreatedByDateTime;
	        }
	        set
	        {
		        datServiceCreatedByDateTime = value;
	        }
        }
		///////////////////////////////////////////////////////////////////////////////////////////
	}
}
   