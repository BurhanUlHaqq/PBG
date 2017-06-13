using System.Data;
using BusinessEntities;
using System;

namespace LogicKernal
{
	public class Download
	{
		public static DataTable GetAllDownload()
		{
			try
			{
				DataKernal.Download objDownload =  new DataKernal.Download();
				return objDownload.SelectDownload().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable GetDownloadByID(int intDownloadID)
		{
			try
			{
				DataKernal.Download objDownload = new DataKernal.Download();
				return objDownload.SelectDownload(intDownloadID).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static Int64 InsertUpdateDownload(BusinessEntities.Download objDownload)
		{
			try
			{
				DataKernal.Download objDDownload = new DataKernal.Download();
				return objDDownload.InsertUpdateDownload(objDownload.DownloadID,objDownload.DownloadTitle,objDownload.DownloadDetail,objDownload.DownloadFilePath,objDownload.DownloadCreateByUserID,objDownload.DownloadCreateDateTime);
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}

		public static Int64 DeleteDownload(int intDownloadID)
		{
			try
			{
				DataKernal.Download objDownload = new DataKernal.Download();
				return objDownload.DeleteDownload(intDownloadID);
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}

		public static Int64 DeleteDownload()
		{
			try
			{
				DataKernal.Download objDownload = new DataKernal.Download();
				return objDownload.DeleteDownload();
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}
    
		public static int TruncateDownload()
		{
			try
			{
				DataKernal.Download objDownload = new DataKernal.Download();
				return objDownload.DownloadTruncate();
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}
	}
}