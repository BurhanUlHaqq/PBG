using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
	public class Images
	{
		//Private Variables////////////////////////////////////////////////////////////////////////
		Int64 intImagesID;
        string strImagesTitle;
        string strImageFilePath;
        string strImagesDetails;
        Int64 intImagesNewsID;
        Int64 intImagesCreatedByUserID;
        DateTime datImagesCreateDateTime;

		///////////////////////////////////////////////////////////////////////////////////////////
		
		//Public Properties////////////////////////////////////////////////////////////////////////
		
        public Int64 ImagesID
        {
	        get
	        {
		        return intImagesID;
	        }
	        set
	        {
		        intImagesID = value;
	        }
        }
        public string ImagesTitle
        {
	        get
	        {
		        return strImagesTitle;
	        }
	        set
	        {
		        strImagesTitle = value;
	        }
        }
        public string ImageFilePath
        {
            get
            {
                return strImageFilePath;
            }
            set 
            {
                strImageFilePath = value;
            }
        }
        public string ImagesDetails
        {
            get
            {
                return strImagesDetails;
            }
            set
            {
                strImagesDetails = value;
            }
        }
        public Int64 ImagesNewsID
        {
	        get
	        {
		        return intImagesNewsID;
	        }
	        set
	        {
		        intImagesNewsID = value;
	        }
        }
        public Int64 ImagesCreatedByUserID
        {
	        get
	        {
		        return intImagesCreatedByUserID;
	        }
	        set
	        {
		        intImagesCreatedByUserID = value;
	        }
        }
        public DateTime ImagesCreateDateTime
        {
	        get
	        {
		        return datImagesCreateDateTime;
	        }
	        set
	        {
		        datImagesCreateDateTime = value;
	        }
        }
		///////////////////////////////////////////////////////////////////////////////////////////
	}
}