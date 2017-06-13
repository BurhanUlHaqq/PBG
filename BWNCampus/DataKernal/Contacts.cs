using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataKernal
{
	public class Contacts
	{
		//Private Variables////////////////////////////////////////////////////////////////////////
		SqlConnection objConnection;
		SqlCommand objCommand;
		string strConnectionString  = string.Empty;
		SqlDataAdapter objDataApter;
		DataSet dsContacts;
		int intRecords;
		///////////////////////////////////////////////////////////////////////////////////////////


		//Constructor//////////////////////////////////////////////////////////////////////////////
		public Contacts(string strConnString)
        {
			strConnectionString = strConnString;
			objConnection = new SqlConnection(strConnectionString);
			objCommand = new SqlCommand();
			objDataApter = new SqlDataAdapter();
			dsContacts = new DataSet();
		}//end constructor
    
		public Contacts()
        {
			strConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
			objConnection = new SqlConnection(strConnectionString);
			objCommand = new SqlCommand();
			objDataApter = new SqlDataAdapter();
            dsContacts = new DataSet();
		}
		///////////////////////////////////////////////////////////////////////////////////////////

		//Public Methods///////////////////////////////////////////////////////////////////////////

		public DataSet SelectContacts()
		{
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "ContactsSelectAll";
				objCommand.CommandType = CommandType.StoredProcedure;
				objDataApter.SelectCommand = objCommand;
				objDataApter.Fill(dsContacts);
				objConnection.Close();
				return dsContacts;
			}
			catch (System.Exception ex) 
			{
				return null;
			}//end try
		}//end function

		public DataSet SelectContacts(int intContactID)
		{
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "GetContactsByID";
				objCommand.Parameters.AddWithValue("@ContactID", intContactID);
				objCommand.CommandType = CommandType.StoredProcedure;
				objDataApter.SelectCommand = objCommand;
				objDataApter.Fill(dsContacts);
				objConnection.Close();
				return dsContacts;
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
		
		public int InsertUpdateContacts(Int64 intContactID, string strContactTitle, string strTelephone, string strEmail)
		{
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "InsertUpdateContacts";
				objCommand.Parameters.AddWithValue("@ContactID", intContactID);
                objCommand.Parameters.AddWithValue("@ContactTitle", strContactTitle);
                objCommand.Parameters.AddWithValue("@Telephone", strTelephone);
                objCommand.Parameters.AddWithValue("@Email", strEmail);

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

		public int DeleteContacts(int intContactID)
		{
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "ContactsDeleteByID";
				objCommand.Parameters.AddWithValue("@ContactID", intContactID);
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
    
		public int DeleteContacts()
		{
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "ContactsDeleteAll";
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
    
		public int ContactsTruncate()
        {
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "ContactsTruncate";
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
		
		
		///////////////////////////////////////////////////////////////////////////////////////////
	}
}
