using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataKernal
{
	public class Programs
	{
		//Private Variables////////////////////////////////////////////////////////////////////////
		SqlConnection objConnection;
		SqlCommand objCommand;
		string strConnectionString  = string.Empty;
		SqlDataAdapter objDataApter;
		DataSet dsPrograms;
		int intRecords;
		///////////////////////////////////////////////////////////////////////////////////////////


		//Constructor//////////////////////////////////////////////////////////////////////////////
		public Programs(string strConnString)
        {
			strConnectionString = strConnString;
			objConnection = new SqlConnection(strConnectionString);
			objCommand = new SqlCommand();
			objDataApter = new SqlDataAdapter();
			dsPrograms = new DataSet();
		}//end constructor
    
		public Programs()
        {
			strConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
			objConnection = new SqlConnection(strConnectionString);
			objCommand = new SqlCommand();
			objDataApter = new SqlDataAdapter();
			dsPrograms = new DataSet();
		}
		///////////////////////////////////////////////////////////////////////////////////////////

		//Public Methods///////////////////////////////////////////////////////////////////////////

		public DataSet SelectPrograms()
		{
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "ProgramsSelectAll";
				objCommand.CommandType = CommandType.StoredProcedure;
				objDataApter.SelectCommand = objCommand;
				objDataApter.Fill(dsPrograms);
				objConnection.Close();
				return dsPrograms;
			}
			catch (System.Exception ex) 
			{
				return null;
			}//end try
		}//end function

		public DataSet SelectPrograms(int intProgramID)
		{
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
                objCommand.CommandText = "GetProgramByID";
				objCommand.Parameters.AddWithValue("@ProgramID", intProgramID);
				objCommand.CommandType = CommandType.StoredProcedure;
				objDataApter.SelectCommand = objCommand;
				objDataApter.Fill(dsPrograms);
				objConnection.Close();
				return dsPrograms;
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}

        public DataSet SelectProgramByDepartmentID(int intDepartmentID)
        {
            try
            {
                objConnection.Open();
                objCommand.Connection = objConnection;
                objCommand.CommandText = "GetProgramByDepartment";
                objCommand.Parameters.AddWithValue("@DepartmentID", intDepartmentID);
                objCommand.CommandType = CommandType.StoredProcedure;
                objDataApter.SelectCommand = objCommand;
                objDataApter.Fill(dsPrograms);
                objConnection.Close();
                return dsPrograms;
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
		
		public int InsertUpdatePrograms(Int64 intProgramID, string strProgramName, Int64 intDepartmentID, string strDuration, string strCriteria, string strProgramDescription, Int64 intCreatedByUserID, int intFee)
		{
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
                objCommand.CommandText = "InsertUpdateProgram";
				objCommand.Parameters.AddWithValue("@ProgramID", intProgramID);
                objCommand.Parameters.AddWithValue("@ProgramName", strProgramName);
                objCommand.Parameters.AddWithValue("@DepartmentID", intDepartmentID);
                objCommand.Parameters.AddWithValue("@Duration", strDuration);
                objCommand.Parameters.AddWithValue("@Criteria", strCriteria);
                objCommand.Parameters.AddWithValue("@Description", strProgramDescription);
                objCommand.Parameters.AddWithValue("@CreatedByUserID", intCreatedByUserID);
                objCommand.Parameters.AddWithValue("@Fee", intFee);

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

		public int DeletePrograms(int intProgramID)
		{
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
                objCommand.CommandText = "DeleteProgramByProgramID";
                objCommand.Parameters.AddWithValue("@ProgramID", intProgramID);
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
    
		public int DeletePrograms()
		{
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
                objCommand.CommandText = "DeleteAllPrograms";
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
    
		public int ProgramsTruncate()
        {
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "ProgramsTruncate";
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
