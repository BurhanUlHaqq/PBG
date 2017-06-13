using System.Data;

namespace LogicKernal
{
	public class Users
	{
		public static DataTable GetAllUsers()
		{
			try
			{
				DataKernal.Users objUsers =  new DataKernal.Users();
				return objUsers.SelectUsers().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable GetUsersByID(int intUsersID)
		{
			try
			{
				DataKernal.Users objUsers = new DataKernal.Users();
				return objUsers.SelectUsers(intUsersID).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}

        public static DataTable GetByUsernamePassword(string strUsername, string strPassword)
        {
            try
            {
                DataKernal.Users objUsers = new DataKernal.Users();
                return objUsers.SelectByUsernamePassword(strUsername, strPassword).Tables[0];
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
    
		public static int InsertUpdateUsers(BusinessEntities.Users objUsers)
		{
			try
			{
				DataKernal.Users objDUsers = new DataKernal.Users();
				return objDUsers.InsertUpdateUsers(objUsers.UsersID,objUsers.Username,objUsers.UserEmail,objUsers.UserPassword);
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}

		public static int DeleteUsers(int intUsersID)
		{
			try
			{
				DataKernal.Users objUsers = new DataKernal.Users();
				return objUsers.DeleteUsers(intUsersID);
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}

		public static int DeleteUsers()
		{
			try
			{
				DataKernal.Users objUsers = new DataKernal.Users();
				return objUsers.DeleteUsers();
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}
    
		public static int TruncateUsers()
		{
			try
			{
				DataKernal.Users objUsers = new DataKernal.Users();
				return objUsers.UsersTruncate();
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}
	}
}