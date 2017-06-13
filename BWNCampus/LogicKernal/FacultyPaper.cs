using System;
using System.Data;

namespace LogicKernal
{
	public class FacultyPaper
	{
		public static DataTable GetAllFacultyPaper()
		{
			try
			{
				DataKernal.FacultyPaper objFacultyPaper =  new DataKernal.FacultyPaper();
				return objFacultyPaper.SelectFacultyPaper().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable GetFacultyPaperByID(int intPaperID)
		{
			try
			{
				DataKernal.FacultyPaper objFacultyPaper = new DataKernal.FacultyPaper();
				return objFacultyPaper.SelectFacultyPaper(intPaperID).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}

        public static DataTable GetPaperByFacultyID(int intFacultyID)
        {
            try
            {
                DataKernal.FacultyPaper objFacultyPaper = new DataKernal.FacultyPaper();
                return objFacultyPaper.GetPaperByFacultyID(intFacultyID).Tables[0];
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
    
		public static int InsertUpdateFacultyPaper(BusinessEntities.FacultyPaper objFacultyPaper)
		{
			try
			{
				DataKernal.FacultyPaper objDFacultyPaper = new DataKernal.FacultyPaper();
				return objDFacultyPaper.InsertUpdateFacultyPaper(objFacultyPaper.PaperID,objFacultyPaper.PaperTitle,objFacultyPaper.PaperAbstract,objFacultyPaper.Journal,objFacultyPaper.PaperUrl,objFacultyPaper.DatePublish,objFacultyPaper.JournalConferenceName,objFacultyPaper.FacultyID, objFacultyPaper.CoAurthors);
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}

		public static int DeleteFacultyPaper(int intPaperID)
		{
			try
			{
				DataKernal.FacultyPaper objFacultyPaper = new DataKernal.FacultyPaper();
				return objFacultyPaper.DeleteFacultyPaper(intPaperID);
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}

		public static int DeleteFacultyPaper()
		{
			try
			{
				DataKernal.FacultyPaper objFacultyPaper = new DataKernal.FacultyPaper();
				return objFacultyPaper.DeleteFacultyPaper();
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}
    
		public static int TruncateFacultyPaper()
		{
			try
			{
				DataKernal.FacultyPaper objFacultyPaper = new DataKernal.FacultyPaper();
				return objFacultyPaper.FacultyPaperTruncate();
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}
		
		

	}
}