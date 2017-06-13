using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataKernal
{
	public class Course
	{
		//Private Variables////////////////////////////////////////////////////////////////////////
		SqlConnection objConnection;
		SqlCommand objCommand;
		string strConnectionString  = string.Empty;
		SqlDataAdapter objDataApter;
		DataSet dsCourse;
		int intRecords;
		///////////////////////////////////////////////////////////////////////////////////////////


		//Constructor//////////////////////////////////////////////////////////////////////////////
		public Course(string strConnString)
        {
			strConnectionString = strConnString;
			objConnection = new SqlConnection(strConnectionString);
			objCommand = new SqlCommand();
			objDataApter = new SqlDataAdapter();
			dsCourse = new DataSet();
		}//end constructor
    
		public Course()
        {
			strConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
			objConnection = new SqlConnection(strConnectionString);
			objCommand = new SqlCommand();
			objDataApter = new SqlDataAdapter();
			dsCourse = new DataSet();
		}
		///////////////////////////////////////////////////////////////////////////////////////////

		//Public Methods///////////////////////////////////////////////////////////////////////////

		public DataSet SelectCourse()
		{
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "CourseSelectAll";
				objCommand.CommandType = CommandType.StoredProcedure;
				objDataApter.SelectCommand = objCommand;
				objDataApter.Fill(dsCourse);
				objConnection.Close();
				return dsCourse;
			}
			catch (System.Exception ex) 
			{
				return null;
			}//end try
		}//end function

		public DataSet SelectCourse(int intCourseID)
		{
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "GetCourseByID";
				objCommand.Parameters.AddWithValue("@CourseID", intCourseID);
				objCommand.CommandType = CommandType.StoredProcedure;
				objDataApter.SelectCommand = objCommand;
				objDataApter.Fill(dsCourse);
				objConnection.Close();
				return dsCourse;
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}

        public DataSet GetCourseBySemesterNoProgramID(int intSemesterNo, int intProgramID)
        {
            try
            {
                objConnection.Open();
                objCommand.Connection = objConnection;
                objCommand.CommandText = "GetCourseBySemesterNoProgramID";
                objCommand.Parameters.AddWithValue("@SemesterNo", intSemesterNo);
                objCommand.Parameters.AddWithValue("@ProgramID", intProgramID);
                objCommand.CommandType = CommandType.StoredProcedure;
                objDataApter.SelectCommand = objCommand;
                objDataApter.Fill(dsCourse);
                objConnection.Close();
                return dsCourse;
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
		
		public int InsertUpdateCourse(Int64 intCourseID, string strCourseName, string strCourseCode, string strCreditHours, int intSemesterNO, Int64 intProgramID, string strCourseDescription, DateTime datCreatedDateTime, Int64 intCreatedUserID)
		{
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "InsertUpdateCourse";
				objCommand.Parameters.AddWithValue("@CourseID", intCourseID);
                objCommand.Parameters.AddWithValue("@CourseName", strCourseName);
                objCommand.Parameters.AddWithValue("@CourseCode", strCourseCode);
                objCommand.Parameters.AddWithValue("@CreditHours", strCreditHours);
                objCommand.Parameters.AddWithValue("@SemesterNO", intSemesterNO);
                objCommand.Parameters.AddWithValue("@ProgramID", intProgramID);
                objCommand.Parameters.AddWithValue("@CourseDescription", strCourseDescription);
                objCommand.Parameters.AddWithValue("@CreatedDateTime", datCreatedDateTime);
                objCommand.Parameters.AddWithValue("@CreatedUserID", intCreatedUserID);

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

		public int DeleteCourse(int intCourseID)
		{
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
                objCommand.CommandText = "CourseDeleteByID";
				objCommand.Parameters.AddWithValue("@CourseID", intCourseID);
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
    
		public int DeleteCourse()
		{
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "CourseSDeleteAll";
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
    
		public int CourseTruncate()
        {
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "CourseTruncate";
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
