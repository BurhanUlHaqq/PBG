using System;
using System.Data;

namespace LogicKernal
{
	public class Department
	{
		public static DataTable GetAllDepartment()
		{
			try
			{
				DataKernal.Department objDepartment =  new DataKernal.Department();
				return objDepartment.SelectDepartment().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable GetDepartmentByID(int intDepartmentID)
		{
			try
			{
				DataKernal.Department objDepartment = new DataKernal.Department();
				return objDepartment.SelectDepartment(intDepartmentID).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static int InsertUpdateDepartment(BusinessEntities.Department objDepartment)
		{
			try
			{
				DataKernal.Department objDDepartment = new DataKernal.Department();
				return objDDepartment.InsertUpdateDepartment(objDepartment.DepartmentID,objDepartment.DepartmentName,objDepartment.DepartmentDescription,objDepartment.DepartmentLogoImagePath,objDepartment.CreatedByUserID,objDepartment.CreatedDateTime);
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}

		public static int DeleteDepartment(int intDepartmentID)
		{
			try
			{
				DataKernal.Department objDepartment = new DataKernal.Department();
				return objDepartment.DeleteDepartment(intDepartmentID);
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}

		public static int DeleteDepartment()
		{
			try
			{
				DataKernal.Department objDepartment = new DataKernal.Department();
				return objDepartment.DeleteDepartment();
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}
    
		public static int TruncateDepartment()
		{
			try
			{
				DataKernal.Department objDepartment = new DataKernal.Department();
				return objDepartment.DepartmentTruncate();
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}

        public static DataTable GenerateClassesList(string strSemester, int intDepartmentID)
        {
            int intClassID = 1;
            int intClassNo = 0;
            string strClassName = string.Empty;

            DataTable dtClasses = new DataTable("ClassesList");
            DataTable dtPrograms = new DataTable();
            DataColumn colClassID = new DataColumn("ClassID", System.Type.GetType("System.Int32"));
            DataColumn colClassName = new DataColumn("ClassName", System.Type.GetType("System.String"));
            dtClasses.Columns.Add(colClassID);
            dtClasses.Columns.Add(colClassName);
            dtPrograms = LogicKernal.Programs.GetProgramByDepartmentID(intDepartmentID);

            if (strSemester == "Spring")
            {
                
                for (int i = 0; i < dtPrograms.Rows.Count; i++)
                {
                    string strProgramName = dtPrograms.Rows[i]["ProgramName"].ToString();
                    string strSemesters = dtPrograms.Rows[i]["Duration"].ToString();
                    char[] c = { ':' };
                    int intSemesters = Convert.ToInt16(strSemesters.Split(c)[2]);
                    intClassNo = 2;
                    while (intClassNo <= intSemesters)
                    {
                        DataRow drClass = dtClasses.NewRow();
                        drClass["ClassID"] = intClassID;
                        drClass["ClassName"] = strProgramName + ":" + intClassNo.ToString();
                        dtClasses.Rows.Add(drClass);
                        intClassNo += 2;
                        intClassID++;
                    }
                }
            }

            if (strSemester == "Fall")
            {
                for (int i = 0; i < dtPrograms.Rows.Count; i++)
                {
                    string strProgramName = dtPrograms.Rows[i]["ProgramName"].ToString();
                    string strSemesters = dtPrograms.Rows[i]["Duration"].ToString();
                    char[] c = { ':' };
                    int intSemesters = Convert.ToInt16(strSemesters.Split(c)[2]);
                    intClassNo = 1;
                    while (intClassNo <= intSemesters)
                    {
                        DataRow drClass = dtClasses.NewRow();
                        drClass["ClassID"] = intClassID;
                        drClass["ClassName"] = strProgramName + ":" + intClassNo.ToString();
                        dtClasses.Rows.Add(drClass);
                        intClassNo += 2;
                        intClassID++;
                    }
                }
            }
            return dtClasses;

        }
	}
}