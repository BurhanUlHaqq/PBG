using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataKernal
{
	public class Messages
	{
		//Private Variables////////////////////////////////////////////////////////////////////////
		SqlConnection objConnection;
		SqlCommand objCommand;
		string strConnectionString  = string.Empty;
		SqlDataAdapter objDataApter;
		DataSet dsMessages;
		int intRecords=0;
       
		///////////////////////////////////////////////////////////////////////////////////////////


		//Constructor//////////////////////////////////////////////////////////////////////////////
		public Messages(string strConnString)
        {
			strConnectionString = strConnString;
			objConnection = new SqlConnection(strConnectionString);
			objCommand = new SqlCommand();
			objDataApter = new SqlDataAdapter();
			dsMessages = new DataSet();
		}//end constructor
    
		public Messages()
        {
			strConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
			objConnection = new SqlConnection(strConnectionString);
			objCommand = new SqlCommand();
			objDataApter = new SqlDataAdapter();
			dsMessages = new DataSet();
		}
		///////////////////////////////////////////////////////////////////////////////////////////

		//Public Methods///////////////////////////////////////////////////////////////////////////

		public DataSet SelectMessages()
		{
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "MessagesSelectAll";
				objCommand.CommandType = CommandType.StoredProcedure;
				objDataApter.SelectCommand = objCommand;
				objDataApter.Fill(dsMessages);
				objConnection.Close();
				return dsMessages;
			}
			catch (System.Exception ex) 
			{
				return null;
			}//end try
		}//end function

		public DataSet SelectMessages(int intMessagesID)
		{
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "GetMessagesByID";
				objCommand.Parameters.AddWithValue("@MessagesID", intMessagesID);
				objCommand.CommandType = CommandType.StoredProcedure;
				objDataApter.SelectCommand = objCommand;
				objDataApter.Fill(dsMessages);
				objConnection.Close();
				return dsMessages;
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
		
		public int InsertUpdateMessages(Int64 intMessagesID, 
            string strMessageTitle, 
            string strMessagesDetails, 
            string strMessageSenderName, 
            string strMessageSenderEmail,
            string strMessageSenderPhone, 
            DateTime datCreatedDate, 
            bool blnIsRead, 
            Int64 intReplierID)
		{
			try
			{
				objConnection.Open();
				
				objCommand.CommandText = "InsertUpdateMessages";
                objCommand.CommandType = CommandType.StoredProcedure;
				objCommand.Parameters.AddWithValue("@MessagesID", intMessagesID);
                objCommand.Parameters.AddWithValue("@MessageTitle", strMessageTitle);
                objCommand.Parameters.AddWithValue("@MessagesDetails", strMessagesDetails);
                objCommand.Parameters.AddWithValue("@MessageSenderName", strMessageSenderName);
                objCommand.Parameters.AddWithValue("@MessageSenderEmail", strMessageSenderEmail);
                objCommand.Parameters.AddWithValue("@MessageSenderPhone", strMessageSenderPhone);
                objCommand.Parameters.AddWithValue("@CreatedDate", datCreatedDate);
                objCommand.Parameters.AddWithValue("@IsRead", blnIsRead);
                objCommand.Parameters.AddWithValue("@ReplierID", intReplierID);
                objCommand.Connection = objConnection;

                intRecords = objCommand.ExecuteNonQuery();
				objConnection.Close();
				return intRecords;
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}

		public int DeleteMessages(int intMessagesID)
		{
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "MessagesSDeleteByID";
				objCommand.Parameters.AddWithValue("@MessagesID", intMessagesID);
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
    
		public int DeleteMessages()
		{
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "MessagesSDeleteAll";
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
    
		public int MessagesTruncate()
        {
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "MessagesTruncate";
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

        public int InsertUpdateMessages(long p, string p_2, string p_3, string p_4, string p_5, DateTime dateTime, bool p_6, long p_7)
        {
            throw new NotImplementedException();
        }
    }
}
