using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
	public class Course
	{
		//Private Variables////////////////////////////////////////////////////////////////////////
		Int64 intCourseID;
        string strCourseName;
        string strCourseCode;
        string strCreditHours;
        int intSemesterNO;
        Int64 intProgramID;
        string strCourseDescription;
        DateTime datCreatedDateTime;
        Int64 intCreatedUserID;

		///////////////////////////////////////////////////////////////////////////////////////////
		
		//Public Properties////////////////////////////////////////////////////////////////////////
		
        public Int64 CourseID
        {
            get
            {
	            return intCourseID;
            }
            set
            {
	            intCourseID = value;
            }
        }
        public string CourseName
        {
            get
            {
	            return strCourseName;
            }
            set
            {
	            strCourseName = value;
            }
        }
        public string CourseCode
        {
            get
            {
	            return strCourseCode;
            }
            set
            {
	            strCourseCode = value;
            }
        }
        public string CreditHours
        {
            get
            {
                return strCreditHours;
            }
            set
            {
                strCreditHours = value;
            }
        }
        public int SemesterNO
        {
            get
            {
	            return intSemesterNO;
            }
            set
            {
	            intSemesterNO = value;
            }
        }
        public Int64 ProgramID
        {
            get
            {
	            return intProgramID;
            }
            set
            {
	            intProgramID = value;
            }
        }
        public string CourseDescription
        {
            get
            {
	            return strCourseDescription;
            }
            set
            {
	            strCourseDescription = value;
            }
        }
        public DateTime CreatedDateTime
        {
            get
            {
	            return datCreatedDateTime;
            }
            set
            {
	            datCreatedDateTime = value;
            }
        }
        public Int64 CreatedUserID
        {
            get
            {
	            return intCreatedUserID;
            }
            set
            {
	            intCreatedUserID = value;
            }
        }
		///////////////////////////////////////////////////////////////////////////////////////////
	}
}