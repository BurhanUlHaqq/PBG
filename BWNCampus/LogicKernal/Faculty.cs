using System.Data;

namespace LogicKernal
{
	public class Faculty
	{
		public static DataTable GetAllFaculty()
		{
			try
			{
				DataKernal.Faculty objFaculty =  new DataKernal.Faculty();
				return objFaculty.SelectFaculty().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable GetFacultyByID(int intFacultyID)
		{
			try
			{
				DataKernal.Faculty objFaculty = new DataKernal.Faculty();
				return objFaculty.SelectFaculty(intFacultyID).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}

        public static DataTable GetFacultyByDepartmentID(int intDepartmentID)
        {
            try
			{
				DataKernal.Faculty objFaculty = new DataKernal.Faculty();
                return objFaculty.GetFacultyByDepartmentID(intDepartmentID).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
        }

        public static DataTable FacultyLogin(string strUsername, string strPassword)
        {
            try
			{
				DataKernal.Faculty objFaculty = new DataKernal.Faculty();
                return objFaculty.LoginFaculty(strUsername, strPassword).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
        }
    
		public static int InsertUpdateFaculty(BusinessEntities.Faculty objFaculty)
		{
			try
			{
				DataKernal.Faculty objDFaculty = new DataKernal.Faculty();
				return objDFaculty.InsertUpdateFaculty(objFaculty.FacultyID,objFaculty.FacultyName,objFaculty.DepartmentID,objFaculty.DesignationID, objFaculty.FacultyImage, objFaculty.Gender, objFaculty.Objectives, objFaculty.Qualification, objFaculty.Specialization, objFaculty.FacultyUsername, objFaculty.FacultyPassword);
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}

		public static int DeleteFaculty(int intFacultyID)
		{
			try
			{
				DataKernal.Faculty objFaculty = new DataKernal.Faculty();
				return objFaculty.DeleteFaculty(intFacultyID);
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}

		public static int DeleteFaculty()
		{
			try
			{
				DataKernal.Faculty objFaculty = new DataKernal.Faculty();
				return objFaculty.DeleteFaculty();
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}
    
		public static int TruncateFaculty()
		{
			try
			{
				DataKernal.Faculty objFaculty = new DataKernal.Faculty();
				return objFaculty.FacultyTruncate();
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}
	}
}