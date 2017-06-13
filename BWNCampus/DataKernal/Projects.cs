using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataKernal
{
	public class Projects
	{
		//Private Variables////////////////////////////////////////////////////////////////////////
		SqlConnection objConnection;
		SqlCommand objCommand;
		string strConnectionString  = string.Empty;
		SqlDataAdapter objDataApter;
		DataSet dsProjects;
		int intRecords;
		///////////////////////////////////////////////////////////////////////////////////////////


		//Constructor//////////////////////////////////////////////////////////////////////////////
		public Projects(string strConnString)
        {
			strConnectionString = strConnString;
			objConnection = new SqlConnection(strConnectionString);
			objCommand = new SqlCommand();
			objDataApter = new SqlDataAdapter();
			dsProjects = new DataSet();
		}//end constructor
    
		public Projects()
        {
			strConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
			objConnection = new SqlConnection(strConnectionString);
			objCommand = new SqlCommand();
			objDataApter = new SqlDataAdapter();
			dsProjects = new DataSet();
		}
		///////////////////////////////////////////////////////////////////////////////////////////

		//Public Methods///////////////////////////////////////////////////////////////////////////

		public DataSet SelectProjects()
		{
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "ProjectsSelectAll";
				objCommand.CommandType = CommandType.StoredProcedure;
				objDataApter.SelectCommand = objCommand;
				objDataApter.Fill(dsProjects);
				objConnection.Close();
				return dsProjects;
			}
			catch (System.Exception ex) 
			{
				return null;
			}//end try
		}//end function

        public DataSet GetProjectByFacultyID(int intFacultyID)
        {
            try
            {
                objConnection.Open();
                objCommand.Connection = objConnection;
                objCommand.CommandText = "GetProjectByFacultyID";
                objCommand.Parameters.AddWithValue("@FacultyID", intFacultyID);
                objCommand.CommandType = CommandType.StoredProcedure;
                objDataApter.SelectCommand = objCommand;
                objDataApter.Fill(dsProjects);
                objConnection.Close();
                return dsProjects;
            }
            catch (System.Exception ex)
            {
                return null;
            }//end try
        }

		public DataSet SelectProjects(int intProjectID)
		{
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "GetProjectsByID";
				objCommand.Parameters.AddWithValue("@ProjectID", intProjectID);
				objCommand.CommandType = CommandType.StoredProcedure;
				objDataApter.SelectCommand = objCommand;
				objDataApter.Fill(dsProjects);
				objConnection.Close();
				return dsProjects;
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
		
		public int InsertUpdateProjects(Int64 intProjectID, string strProjectTitle, string strProjectDetails, string strRollInProject, string strProjectUrl, Int64 intFacultyID)
		{
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "InsertUpdateProjects";
				objCommand.Parameters.AddWithValue("@ProjectID", intProjectID);
                objCommand.Parameters.AddWithValue("@ProjectTitle", strProjectTitle);
                objCommand.Parameters.AddWithValue("@ProjectDetails", strProjectDetails);
                objCommand.Parameters.AddWithValue("@RollInProject", strRollInProject);
                objCommand.Parameters.AddWithValue("@ProjectUrl", strProjectUrl);
                objCommand.Parameters.AddWithValue("@FacultyID", intFacultyID);

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

		public int DeleteProjects(int intProjectID)
		{
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
                objCommand.CommandText = "ProjectsDeleteByID";
				objCommand.Parameters.AddWithValue("@ProjectID", intProjectID);
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
    
		public int DeleteProjects()
		{
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "ProjectsSDeleteAll";
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
    
		public int ProjectsTruncate()
        {
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "ProjectsTruncate";
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
