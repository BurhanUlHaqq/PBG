using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
	public class Projects
	{
		//Private Variables////////////////////////////////////////////////////////////////////////
		Int64 intProjectID;
        string strProjectTitle;
        string strProjectDetails;
        string strRollInProject;
        string strProjectUrl;
        Int64 intFacultyID;

		///////////////////////////////////////////////////////////////////////////////////////////
		
		//Public Properties////////////////////////////////////////////////////////////////////////
		
        public Int64 ProjectID
        {
	        get
	        {
		        return intProjectID;
	        }
	        set
	        {
		        intProjectID = value;
	        }
        }
        public string ProjectTitle
        {
	        get
	        {
		        return strProjectTitle;
	        }
	        set
	        {
		        strProjectTitle = value;
	        }
        }
        public string ProjectDetails
        {
	        get
	        {
		        return strProjectDetails;
	        }
	        set
	        {
		        strProjectDetails = value;
	        }
        }
        public string RollInProject
        {
	        get
	        {
		        return strRollInProject;
	        }
	        set
	        {
		        strRollInProject = value;
	        }
        }
        public string ProjectUrl
        {
	        get
	        {
		        return strProjectUrl;
	        }
	        set
	        {
		        strProjectUrl = value;
	        }
        }
        public Int64 FacultyID
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
		///////////////////////////////////////////////////////////////////////////////////////////
	}
}