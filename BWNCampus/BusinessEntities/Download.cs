using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
	public class Download
	{
		//Private Variables////////////////////////////////////////////////////////////////////////
		Int64 intDownloadID;
        string strDownloadTitle;
        string strDownloadDetail;
        string strDownloadFilePath;
        Int64 intDownloadCreateByUserID;
        DateTime datDownloadCreateDateTime;

		///////////////////////////////////////////////////////////////////////////////////////////
		
		//Public Properties////////////////////////////////////////////////////////////////////////
		
        public Int64 DownloadID
        {
	        get
	        {
		        return intDownloadID;
	        }
	        set
	        {
		        intDownloadID = value;
	        }
        }
        public string DownloadTitle
        {
	        get
	        {
		        return strDownloadTitle;
	        }
	        set
	        {
		        strDownloadTitle = value;
	        }
        }
        public string DownloadDetail
        {
	        get
	        {
		        return strDownloadDetail;
	        }
	        set
	        {
		        strDownloadDetail = value;
	        }
        }
        public string DownloadFilePath
        {
	        get
	        {
		        return strDownloadFilePath;
	        }
	        set
	        {
		        strDownloadFilePath = value;
	        }
        }
        public Int64 DownloadCreateByUserID
        {
	        get
	        {
		        return intDownloadCreateByUserID;
	        }
	        set
	        {
		        intDownloadCreateByUserID = value;
	        }
        }
        public DateTime DownloadCreateDateTime
        {
	        get
	        {
		        return datDownloadCreateDateTime;
	        }
	        set
	        {
		        datDownloadCreateDateTime = value;
	        }
        }
		///////////////////////////////////////////////////////////////////////////////////////////
	}
}