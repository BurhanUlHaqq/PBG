using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
	public class Programs
	{
		//Private Variables////////////////////////////////////////////////////////////////////////
		Int64 intProgramID;
        string strProgramName;
        Int64 intDepartmentID;
        string strDuration;
        string strCriteria;
        string strProgramDescription;
        Int64 intCreatedByUserID;
        int intFee;

		///////////////////////////////////////////////////////////////////////////////////////////
		
		//Public Properties////////////////////////////////////////////////////////////////////////
		
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

        public string ProgramName
        {
	        get
	        {
		        return strProgramName;
	        }
	        set
	        {
		        strProgramName = value;
	        }
        }

        public Int64 DepartmentID
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

        public string Duration
        {
	        get
	        {
		        return strDuration;
	        }
	        set
	        {
		        strDuration = value;
	        }
        }

        public string Criteria
        {
	        get
	        {
		        return strCriteria;
	        }
	        set
	        {
		        strCriteria = value;
	        }
        }

        public string ProgramDescription
        {
	        get
	        {
		        return strProgramDescription;
	        }
	        set
	        {
		        strProgramDescription = value;
	        }
        }

        public Int64 CreatedByUserID
        {
	        get
	        {
		        return intCreatedByUserID;
	        }
	        set
	        {
		        intCreatedByUserID = value;
	        }
        }

        public int Fee
        {
            get
            {
                return intFee;
            }
            set
            {
                intFee = value;
            }
        }
		        ///////////////////////////////////////////////////////////////////////////////////////////
	        }
}