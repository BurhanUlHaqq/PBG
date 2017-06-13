using System;
using System.Data;

namespace LogicKernal
{
	public class Programs
	{
		public static DataTable GetAllPrograms()
		{
			try
			{
				DataKernal.Programs objPrograms =  new DataKernal.Programs();
				return objPrograms.SelectPrograms().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable GetProgramsByID(int intProgramID)
		{
			try
			{
				DataKernal.Programs objPrograms = new DataKernal.Programs();
				return objPrograms.SelectPrograms(intProgramID).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}

        public static DataTable GetProgramByDepartmentID(int intDepartmentID)
        {
            try
            {
                DataKernal.Programs objPrograms = new DataKernal.Programs();
                return objPrograms.SelectProgramByDepartmentID(intDepartmentID).Tables[0];
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
    
		public static int InsertUpdatePrograms(BusinessEntities.Programs objPrograms)
		{
			try
			{
				DataKernal.Programs objDPrograms = new DataKernal.Programs();
				return objDPrograms.InsertUpdatePrograms(objPrograms.ProgramID,objPrograms.ProgramName,objPrograms.DepartmentID,objPrograms.Duration,objPrograms.Criteria,objPrograms.ProgramDescription,objPrograms.CreatedByUserID, objPrograms.Fee);
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}

		public static int DeletePrograms(int intProgramID)
		{
			try
			{
				DataKernal.Programs objPrograms = new DataKernal.Programs();
				return objPrograms.DeletePrograms(intProgramID);
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}
		public static int DeletePrograms()
		{
			try
			{
				DataKernal.Programs objPrograms = new DataKernal.Programs();
				return objPrograms.DeletePrograms();
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}
    
		public static int TruncatePrograms()
		{
			try
			{
				DataKernal.Programs objPrograms = new DataKernal.Programs();
				return objPrograms.ProgramsTruncate();
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}
		
		

	}
}