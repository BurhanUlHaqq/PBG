using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
	public class Contacts
	{
		//Private Variables////////////////////////////////////////////////////////////////////////
		Int64 intContactID;
        string strContactTitle;
        string strTelephone;
        string strEmail;

		///////////////////////////////////////////////////////////////////////////////////////////
		
		//Public Properties////////////////////////////////////////////////////////////////////////
		
        public Int64 ContactID
        {
	        get
	        {
		        return intContactID;
	        }
	        set
	        {
		        intContactID = value;
	        }
        }
        public string ContactTitle
        {
	        get
	        {
		        return strContactTitle;
	        }
	        set
	        {
		        strContactTitle = value;
	        }
        }
        public string Telephone
        {
	        get
	        {
		        return strTelephone;
	        }
	        set
	        {
		        strTelephone = value;
	        }
        }
        public string Email
        {
	        get
	        {
		        return strEmail;
	        }
	        set
	        {
		        strEmail = value;
	        }
        }
		///////////////////////////////////////////////////////////////////////////////////////////
	}
}