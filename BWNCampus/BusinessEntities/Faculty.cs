using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
	public class Faculty
	{
		//Private Variables////////////////////////////////////////////////////////////////////////
		int intFacultyID;
        string strFacultyName;
        int intDepartmentID;
        int intDesignationID;
        string strFacultyImage;
        bool blnGender;
        string strObjectives;
        string strQualification;
        string strSpecialization;
        string strFacultyUsername;
        string strFacultyPassword;
		///////////////////////////////////////////////////////////////////////////////////////////
		
		//Public Properties////////////////////////////////////////////////////////////////////////
		
        public int FacultyID
        {
	        get
	        {
		        return intFacultyID;
	        }
	        set
	        {
		        intFacultyID = value;
	        }
        }

        public string FacultyName
        {
	        get
	        {
		        return strFacultyName;
	        }
	        set
	        {
		        strFacultyName = value;
	        }
        }

        public int DepartmentID
        {
	        get
	        {
		        return intDepartmentID;
	        }
	        set
	        {
		        intDepartmentID = value;
	        }
        }

        public int DesignationID
        {
	        get
	        {
		        return intDesignationID;
	        }
	        set
	        {
		        intDesignationID = value;
	        }
        }

        public string FacultyImage
        {
            get
            {
                return strFacultyImage;
            }
            set
            {
                strFacultyImage = value;
            }
        }

        public bool Gender
        {
            get
            {
                return blnGender;
            }
            set
            {
                blnGender = value;
            }
        }

        public string Objectives
        {
            get
            {
                return strObjectives;
            }
            set
            {
                strObjectives = value;
            }
        }

        public string Qualification
        {
            get
            {
                return strQualification;
            }
            set
            {
                strQualification = value;
            }
        }

        public string Specialization
        {
            get
            {
                return strSpecialization;
            }
            set
            {
                strSpecialization = value;
            }
        }

        public string FacultyUsername
        {
            get
            {
                return strFacultyUsername;
            }
            set
            {
                strFacultyUsername = value;
            }
        }

        public string FacultyPassword
        {
            get
            {
                return strFacultyPassword;
            }
            set
            {
                strFacultyPassword = value;
            }
        }
        ///////////////////////////////////////////////////////////////////////////////////////////
    }
}