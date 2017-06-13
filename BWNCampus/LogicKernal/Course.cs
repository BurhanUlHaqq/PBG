using System;
using System.Data;

namespace LogicKernal
{
	public class Course
	{
		public static DataTable GetAllCourse()
		{
			try
			{
				DataKernal.Course objCourse =  new DataKernal.Course();
				return objCourse.SelectCourse().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable GetCourseByID(int intCourseID)
		{
			try
			{
				DataKernal.Course objCourse = new DataKernal.Course();
				return objCourse.SelectCourse(intCourseID).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}

        public static DataTable GetCourseBySemesterNoProgramID(int intSemesterNo, int intProgramID)
        {
            try
            {
                DataKernal.Course objCourse = new DataKernal.Course();
                return objCourse.GetCourseBySemesterNoProgramID(intSemesterNo, intProgramID).Tables[0];
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
    
		public static int InsertUpdateCourse(BusinessEntities.Course objCourse)
		{
			try
			{
				DataKernal.Course objDCourse = new DataKernal.Course();
				return objDCourse.InsertUpdateCourse(objCourse.CourseID,objCourse.CourseName,objCourse.CourseCode, objCourse.CreditHours, objCourse.SemesterNO,objCourse.ProgramID,objCourse.CourseDescription,objCourse.CreatedDateTime,objCourse.CreatedUserID);
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}

		public static int DeleteCourse(int intCourseID)
		{
			try
			{
				DataKernal.Course objCourse = new DataKernal.Course();
				return objCourse.DeleteCourse(intCourseID);
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}

		public static int DeleteCourse()
		{
			try
			{
				DataKernal.Course objCourse = new DataKernal.Course();
				return objCourse.DeleteCourse();
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}
    
		public static int TruncateCourse()
		{
			try
			{
				DataKernal.Course objCourse = new DataKernal.Course();
				return objCourse.CourseTruncate();
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}
		
		

	}
}