using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
	public class Users
	{
		//Private Variables////////////////////////////////////////////////////////////////////////
		Int64 intUsersID;
        string strUsername;
        string strUserEmail;
        string strUserPassword;

		///////////////////////////////////////////////////////////////////////////////////////////
		
		//Public Properties////////////////////////////////////////////////////////////////////////
		
        public Int64 UsersID
        {
            get
            {
	            return intUsersID;
            }
            set
            {
	            intUsersID = value;
            }
        }
        public string Username
        {
            get
            {
	            return strUsername;
            }
            set
            {
	            strUsername = value;
            }
        }
        public string UserEmail
        {
            get
            {
	            return strUserEmail;
            }
            set
            {
	            strUserEmail = value;
            }
        }
        public string UserPassword
        {
            get
            {
	            return strUserPassword;
            }
            set
            {
	            strUserPassword = value;
            }
        }
		///////////////////////////////////////////////////////////////////////////////////////////
	}
}