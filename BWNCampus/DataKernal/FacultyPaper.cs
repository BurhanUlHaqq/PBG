using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataKernal
{
	public class FacultyPaper
	{
		//Private Variables////////////////////////////////////////////////////////////////////////
		SqlConnection objConnection;
		SqlCommand objCommand;
		string strConnectionString  = string.Empty;
		SqlDataAdapter objDataApter;
		DataSet dsFacultyPaper;
		int intRecords;
		///////////////////////////////////////////////////////////////////////////////////////////


		//Constructor//////////////////////////////////////////////////////////////////////////////
		public FacultyPaper(string strConnString)
        {
			strConnectionString = strConnString;
			objConnection = new SqlConnection(strConnectionString);
			objCommand = new SqlCommand();
			objDataApter = new SqlDataAdapter();
			dsFacultyPaper = new DataSet();
		}//end constructor
    
		public FacultyPaper()
        {
			strConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
			objConnection = new SqlConnection(strConnectionString);
			objCommand = new SqlCommand();
			objDataApter = new SqlDataAdapter();
			dsFacultyPaper = new DataSet();
		}
		///////////////////////////////////////////////////////////////////////////////////////////

		//Public Methods///////////////////////////////////////////////////////////////////////////

		public DataSet SelectFacultyPaper()
		{
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "FacultyPaperSelectAll";
				objCommand.CommandType = CommandType.StoredProcedure;
				objDataApter.SelectCommand = objCommand;
				objDataApter.Fill(dsFacultyPaper);
				objConnection.Close();
				return dsFacultyPaper;
			}
			catch (System.Exception ex) 
			{
				return null;
			}//end try
		}//end function

		public DataSet SelectFacultyPaper(int intPaperID)
		{
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "GetFacultyPaperByID";
				objCommand.Parameters.AddWithValue("@PaperID", intPaperID);
				objCommand.CommandType = CommandType.StoredProcedure;
				objDataApter.SelectCommand = objCommand;
				objDataApter.Fill(dsFacultyPaper);
				objConnection.Close();
				return dsFacultyPaper;
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}

        public DataSet GetPaperByFacultyID(int intFacultyID)
        {
            try
            {
                objConnection.Open();
                objCommand.Connection = objConnection;
                objCommand.CommandText = "GetPaperByFacultyID";
                objCommand.Parameters.AddWithValue("@FacultyID", intFacultyID);
                objCommand.CommandType = CommandType.StoredProcedure;
                objDataApter.SelectCommand = objCommand;
                objDataApter.Fill(dsFacultyPaper);
                objConnection.Close();
                return dsFacultyPaper;
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public int InsertUpdateFacultyPaper(Int64 intPaperID, string strPaperTitle, string strPaperAbstract, bool blnJournal, string strPaperUrl, DateTime datDatePublish, string strJournalConferenceName, Int64 intFacultyID, string strCoAurthors)
		{
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "InsertUpdateFacultyPaper";
				objCommand.Parameters.AddWithValue("@PaperID", intPaperID);
                objCommand.Parameters.AddWithValue("@PaperTitle", strPaperTitle);
                objCommand.Parameters.AddWithValue("@PaperAbstract", strPaperAbstract);
                objCommand.Parameters.AddWithValue("@Journal", blnJournal);
                objCommand.Parameters.AddWithValue("@PaperUrl", strPaperUrl);
                objCommand.Parameters.AddWithValue("@DatePublish", datDatePublish);
                objCommand.Parameters.AddWithValue("@JournalConferenceName", strJournalConferenceName);
                objCommand.Parameters.AddWithValue("@FacultyID", intFacultyID);
                objCommand.Parameters.AddWithValue("@CoAurthors", strCoAurthors);

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

		public int DeleteFacultyPaper(int intPaperID)
		{
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
                objCommand.CommandText = "FacultyPaperDeleteByID";
				objCommand.Parameters.AddWithValue("@PaperID", intPaperID);
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
    
		public int DeleteFacultyPaper()
		{
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "FacultyPaperSDeleteAll";
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
    
		public int FacultyPaperTruncate()
        {
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "FacultyPaperTruncate";
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
