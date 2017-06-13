using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
	public class FacultyPaper
	{
		//Private Variables////////////////////////////////////////////////////////////////////////
		Int64 intPaperID;
        string strPaperTitle;
        string strPaperAbstract;
        bool blnJournal;
        string strPaperUrl;
        DateTime datDatePublish;
        string strJournalConferenceName;
        Int64 intFacultyID;
        string strCoAurthors;

		///////////////////////////////////////////////////////////////////////////////////////////
		
		//Public Properties////////////////////////////////////////////////////////////////////////
		
        public Int64 PaperID
        {
	        get
	        {
		        return intPaperID;
	        }
	        set
	        {
		        intPaperID = value;
	        }
        }

        public string PaperTitle
        {
	        get
	        {
		        return strPaperTitle;
	        }
	        set
	        {
		        strPaperTitle = value;
	        }
        }

        public string PaperAbstract
        {
	        get
	        {
		        return strPaperAbstract;
	        }
	        set
	        {
		        strPaperAbstract = value;
	        }
        }

        public bool Journal
        {
	        get
	        {
		        return blnJournal;
	        }
	        set
	        {
		        blnJournal = value;
	        }
        }

        public string PaperUrl
        {
	        get
	        {
		        return strPaperUrl;
	        }
	        set
	        {
		        strPaperUrl = value;
	        }
        }

        public DateTime DatePublish
        {
	        get
	        {
		        return datDatePublish;
	        }
	        set
	        {
		        datDatePublish = value;
	        }
        }

        public string JournalConferenceName
        {
	        get
	        {
		        return strJournalConferenceName;
	        }
	        set
	        {
		        strJournalConferenceName = value;
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

        public string CoAurthors
        {
            get
            {
                return strCoAurthors;
            }
            set
            {
                strCoAurthors = value;
            }
        }
		///////////////////////////////////////////////////////////////////////////////////////////
	}
}