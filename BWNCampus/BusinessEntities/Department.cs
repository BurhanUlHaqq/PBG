using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
	public class Department
	{
		//Private Variables////////////////////////////////////////////////////////////////////////
		Int64 intDepartmentID;
string strDepartmentName;
string strDepartmentDescription;
string strDepartmentLogoImagePath;
Int64 intCreatedByUserID;
DateTime datCreatedDateTime;

		///////////////////////////////////////////////////////////////////////////////////////////
		
		//Public Properties////////////////////////////////////////////////////////////////////////
		
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
public string DepartmentName
{
	get
	{
		return strDepartmentName;
	}
	set
	{
		strDepartmentName = value;
	}
}
public string DepartmentDescription
{
	get
	{
		return strDepartmentDescription;
	}
	set
	{
		strDepartmentDescription = value;
	}
}
public string DepartmentLogoImagePath
{
	get
	{
		return strDepartmentLogoImagePath;
	}
	set
	{
		strDepartmentLogoImagePath = value;
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
		///////////////////////////////////////////////////////////////////////////////////////////
	}
}