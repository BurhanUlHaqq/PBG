using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataKernal
{
	public class Faculty
	{
		//Private Variables////////////////////////////////////////////////////////////////////////
		SqlConnection objConnection;
		SqlCommand objCommand;
		string strConnectionString  = string.Empty;
		SqlDataAdapter objDataApter;
		DataSet dsFaculty;
		int intRecords;
		///////////////////////////////////////////////////////////////////////////////////////////


		//Constructor//////////////////////////////////////////////////////////////////////////////
		public Faculty(string strConnString)
        {
			strConnectionString = strConnString;
			objConnection = new SqlConnection(strConnectionString);
			objCommand = new SqlCommand();
			objDataApter = new SqlDataAdapter();
			dsFaculty = new DataSet();
		}//end constructor
    
		public Faculty()
        {
			strConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
			objConnection = new SqlConnection(strConnectionString);
			objCommand = new SqlCommand();
			objDataApter = new SqlDataAdapter();
            dsFaculty = new DataSet();
		}
		///////////////////////////////////////////////////////////////////////////////////////////

		//Public Methods///////////////////////////////////////////////////////////////////////////

		public DataSet SelectFaculty()
		{
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "FacultySelectAll";
				objCommand.CommandType = CommandType.StoredProcedure;
				objDataApter.SelectCommand = objCommand;
				objDataApter.Fill(dsFaculty);
				objConnection.Close();
				return dsFaculty;
			}
			catch (System.Exception ex) 
			{
				return null;
			}//end try
		}//end function

		public DataSet SelectFaculty(int intFacultyID)
		{
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "GetFacultyByID";
				objCommand.Parameters.AddWithValue("@FacultyID", intFacultyID);
				objCommand.CommandType = CommandType.StoredProcedure;
				objDataApter.SelectCommand = objCommand;
				objDataApter.Fill(dsFaculty);
				objConnection.Close();
				return dsFaculty;
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}

        public DataSet GetFacultyByDepartmentID(int intDepartmentID)
        {
            try
            {
                objConnection.Open();
                objCommand.Connection = objConnection;
                objCommand.CommandText = "GetFacultyByDepartmentID";
                objCommand.Parameters.AddWithValue("@DepartmentID", intDepartmentID);
                objCommand.CommandType = CommandType.StoredProcedure;
                objDataApter.SelectCommand = objCommand;
                objDataApter.Fill(dsFaculty);
                objConnection.Close();
                return dsFaculty;
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public DataSet LoginFaculty(string strUsername, string strPassword)
        {
            try
            {
                objConnection.Open();
                objCommand.Connection = objConnection;
                objCommand.CommandText = "FacultyLogin";
                objCommand.Parameters.AddWithValue("@FacultyUsername", strUsername);
                objCommand.Parameters.AddWithValue("@FacultyPassword", strPassword);
                objCommand.CommandType = CommandType.StoredProcedure;
                objDataApter.SelectCommand = objCommand;
                objDataApter.Fill(dsFaculty);
                objConnection.Close();
                return dsFaculty;
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public int InsertUpdateFaculty(int intFacultyID, string strFacultyName, int intDepartmentID, int intDesignationID, string strFacultyImage, bool blnGender, string strObjectives, string strQualification, string strSpecialization, string strFacultyUsername, string strFacultyPassword)
		{
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "InsertUpdateFaculty";
				objCommand.Parameters.AddWithValue("@FacultyID", intFacultyID);
                objCommand.Parameters.AddWithValue("@FacultyName", strFacultyName);
                objCommand.Parameters.AddWithValue("@DepartmentID", intDepartmentID);
                objCommand.Parameters.AddWithValue("@DesignationID", intDesignationID);
                objCommand.Parameters.AddWithValue("@FacultyImage", strFacultyImage);
                objCommand.Parameters.AddWithValue("@Gender", blnGender);
                objCommand.Parameters.AddWithValue("@Objectives", strObjectives);
                objCommand.Parameters.AddWithValue("@Qualification", strQualification);
                objCommand.Parameters.AddWithValue("@Specialization", strSpecialization);
                objCommand.Parameters.AddWithValue("@FacultyUsername", strFacultyUsername);
                objCommand.Parameters.AddWithValue("@FacultyPassword", strFacultyPassword);
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

		public int DeleteFaculty(int intFacultyID)
		{
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "FacultySDeleteByID";
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
    
		public int DeleteFaculty()
		{
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "FacultySDeleteAll";
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
    
		public int FacultyTruncate()
        {
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "FacultyTruncate";
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
		
		///////////////////////////////////////////////////////////////////////////////////////////
	}
}
