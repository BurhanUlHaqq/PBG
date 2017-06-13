using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System;

namespace DataKernal
{
	public class Users
	{
		//Private Variables////////////////////////////////////////////////////////////////////////
		SqlConnection objConnection;
		SqlCommand objCommand;
		string strConnectionString  = string.Empty;
		SqlDataAdapter objDataApter;
		DataSet dsUsers;
		int intRecords;
		///////////////////////////////////////////////////////////////////////////////////////////


		//Constructor//////////////////////////////////////////////////////////////////////////////
		public Users(string strConnString)
        {
			strConnectionString = strConnString;
			objConnection = new SqlConnection(strConnectionString);
			objCommand = new SqlCommand();
			objDataApter = new SqlDataAdapter();
			dsUsers = new DataSet();
		}//end constructor
    
		public Users()
        {
			strConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
			objConnection = new SqlConnection(strConnectionString);
			objCommand = new SqlCommand();
			objDataApter = new SqlDataAdapter();
			dsUsers = new DataSet();
		}
		///////////////////////////////////////////////////////////////////////////////////////////

		//Public Methods///////////////////////////////////////////////////////////////////////////

		public DataSet SelectUsers()
		{
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "UsersSelectAll";
				objCommand.CommandType = CommandType.StoredProcedure;
				objDataApter.SelectCommand = objCommand;
				objDataApter.Fill(dsUsers);
				objConnection.Close();
				return dsUsers;
			}
			catch (System.Exception ex) 
			{
				return null;
			}//end try
		}//end function

		public DataSet SelectUsers(int intUsersID)
		{
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "GetUsersByID";
				objCommand.Parameters.AddWithValue("@UsersID", intUsersID);
				objCommand.CommandType = CommandType.StoredProcedure;
				objDataApter.SelectCommand = objCommand;
				objDataApter.Fill(dsUsers);
				objConnection.Close();
				return dsUsers;
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
		
		public int InsertUpdateUsers(Int64 intUsersID, string strUsername, string strUserEmail, string strUserPassword)
		{
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "InsertUpdateUsers";
				objCommand.Parameters.AddWithValue("@UsersID", intUsersID);
                objCommand.Parameters.AddWithValue("@Username", strUsername);
                objCommand.Parameters.AddWithValue("@UserEmail", strUserEmail);
                objCommand.Parameters.AddWithValue("@UserPassword", strUserPassword);

				objCommand.CommandType = CommandType.StoredProcedure;
				intRecords = objCommand.ExecuteNonQuery();
				objConnection.Close();
				return intRecords;
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}

		public int DeleteUsers(int intUsersID)
		{
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "UsersSDeleteByID";
				objCommand.Parameters.AddWithValue("@UsersID", intUsersID);
				objCommand.CommandType = CommandType.StoredProcedure;
				intRecords = objCommand.ExecuteNonQuery();
				objConnection.Close();
				return intRecords;
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}
    
		public int DeleteUsers()
		{
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "UsersSDeleteAll";
				objCommand.CommandType = CommandType.StoredProcedure;
				intRecords = objCommand.ExecuteNonQuery();
				objConnection.Close();
				return intRecords;
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}
    
		public int UsersTruncate()
        {
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "UsersTruncate";
				objCommand.CommandType = CommandType.StoredProcedure;
				intRecords = objCommand.ExecuteNonQuery();
				objConnection.Close();
				return 1;
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}
		
		//end function
        public DataSet SelectByUsernamePassword(string strUsername, string strPassword)
        {
            try
            {
                objConnection.Open();
                objCommand.Connection = objConnection;
                objCommand.CommandText = "SelectByUsernamePassword";
                objCommand.Parameters.AddWithValue("@Username", strUsername);
                objCommand.Parameters.AddWithValue("@UserPassword", strPassword);
                objCommand.CommandType = CommandType.StoredProcedure;
                objDataApter.SelectCommand = objCommand;
                objDataApter.Fill(dsUsers);
                objConnection.Close();
                return dsUsers;
            }
            catch (System.Exception ex)
            {
                return null;
            }//end try
        }
		
		
		///////////////////////////////////////////////////////////////////////////////////////////
	}
}
