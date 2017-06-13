using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataKernal
{
	public class Download
	{
		//Private Variables////////////////////////////////////////////////////////////////////////
		SqlConnection objConnection;
		SqlCommand objCommand;
		string strConnectionString  = string.Empty;
		SqlDataAdapter objDataApter;
		DataSet dsDownload;
		Int64 intRecords;
		///////////////////////////////////////////////////////////////////////////////////////////


		//Constructor//////////////////////////////////////////////////////////////////////////////
		public Download(string strConnString)
        {
			strConnectionString = strConnString;
			objConnection = new SqlConnection(strConnectionString);
			objCommand = new SqlCommand();
			objDataApter = new SqlDataAdapter();
			dsDownload = new DataSet();
		}//end constructor
    
		public Download()
        {
			strConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
			objConnection = new SqlConnection(strConnectionString);
			objCommand = new SqlCommand();
			objDataApter = new SqlDataAdapter();
			dsDownload = new DataSet();
		}
		///////////////////////////////////////////////////////////////////////////////////////////

		//Public Methods///////////////////////////////////////////////////////////////////////////

		public DataSet SelectDownload()
		{
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "DownloadSelectAll";
				objCommand.CommandType = CommandType.StoredProcedure;
				objDataApter.SelectCommand = objCommand;
				objDataApter.Fill(dsDownload);
				objConnection.Close();
				return dsDownload;
			}
			catch (System.Exception ex) 
			{
				return null;
			}//end try
		}//end function

		public DataSet SelectDownload(int intDownloadID)
		{
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "GetDownloadByID";
				objCommand.Parameters.AddWithValue("@DownloadID", intDownloadID);
				objCommand.CommandType = CommandType.StoredProcedure;
				objDataApter.SelectCommand = objCommand;
				objDataApter.Fill(dsDownload);
				objConnection.Close();
				return dsDownload;
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
		
		public Int64 InsertUpdateDownload(Int64 intDownloadID, string strDownloadTitle, string strDownloadDetail, string strDownloadFilePath, Int64 intDownloadCreateByUserID, System.DateTime datDownloadCreateDateTime)
		{
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "InsertUpdateDownload";
				objCommand.Parameters.AddWithValue("@DownloadID", intDownloadID);
                objCommand.Parameters.AddWithValue("@DownloadTitle", strDownloadTitle);
                objCommand.Parameters.AddWithValue("@DownloadDetail", strDownloadDetail);
                objCommand.Parameters.AddWithValue("@DownloadFilePath", strDownloadFilePath);
                objCommand.Parameters.AddWithValue("@DownloadCreateByUserID", intDownloadCreateByUserID);
                objCommand.Parameters.AddWithValue("@DownloadCreateDateTime", datDownloadCreateDateTime);

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

		public Int64 DeleteDownload(int intDownloadID)
		{
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "DownloadDeleteByID";
				objCommand.Parameters.AddWithValue("@DownloadID", intDownloadID);
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
    
		public Int64 DeleteDownload()
		{
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "DownloadSDeleteAll";
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
    
		public int DownloadTruncate()
        {
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "DownloadTruncate";
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
