using System;
using System.Data;

namespace LogicKernal
{
	public class Projects
	{
		public static DataTable GetAllProjects()
		{
			try
			{
				DataKernal.Projects objProjects =  new DataKernal.Projects();
				return objProjects.SelectProjects().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable GetProjectsByID(int intProjectID)
		{
			try
			{
				DataKernal.Projects objProjects = new DataKernal.Projects();
				return objProjects.SelectProjects(intProjectID).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}

        public static DataTable GetProjectsByFacultyID(int intFacultyID)
        {
            try
            {
                DataKernal.Projects objProjects = new DataKernal.Projects();
                return objProjects.GetProjectByFacultyID(intFacultyID).Tables[0];
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
		public static int InsertUpdateProjects(BusinessEntities.Projects objProjects)
		{
			try
			{
				DataKernal.Projects objDProjects = new DataKernal.Projects();
				return objDProjects.InsertUpdateProjects(objProjects.ProjectID,objProjects.ProjectTitle,objProjects.ProjectDetails,objProjects.RollInProject,objProjects.ProjectUrl,objProjects.FacultyID);
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}

		public static int DeleteProjects(int intProjectID)
		{
			try
			{
				DataKernal.Projects objProjects = new DataKernal.Projects();
				return objProjects.DeleteProjects(intProjectID);
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}

		public static int DeleteProjects()
		{
			try
			{
				DataKernal.Projects objProjects = new DataKernal.Projects();
				return objProjects.DeleteProjects();
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}
    
		public static int TruncateProjects()
		{
			try
			{
				DataKernal.Projects objProjects = new DataKernal.Projects();
				return objProjects.ProjectsTruncate();
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}
		
		

	}
}