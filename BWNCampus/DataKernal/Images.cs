using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System;

namespace DataKernal
{
	public class Images
	{
		//Private Variables////////////////////////////////////////////////////////////////////////
		SqlConnection objConnection;
		SqlCommand objCommand;
		string strConnectionString  = string.Empty;
		SqlDataAdapter objDataApter;
		DataSet dsImages;
		int intRecords;
		///////////////////////////////////////////////////////////////////////////////////////////


		//Constructor//////////////////////////////////////////////////////////////////////////////
		public Images(string strConnString)
        {
			strConnectionString = strConnString;
			objConnection = new SqlConnection(strConnectionString);
			objCommand = new SqlCommand();
			objDataApter = new SqlDataAdapter();
			dsImages = new DataSet();
		}//end constructor
    
		public Images()
        {
			strConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
			objConnection = new SqlConnection(strConnectionString);
			objCommand = new SqlCommand();
			objDataApter = new SqlDataAdapter();
			dsImages = new DataSet();
		}
		///////////////////////////////////////////////////////////////////////////////////////////

		//Public Methods///////////////////////////////////////////////////////////////////////////

		public DataSet SelectImages()
		{
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "ImagesSelectAll";
				objCommand.CommandType = CommandType.StoredProcedure;
				objDataApter.SelectCommand = objCommand;
				objDataApter.Fill(dsImages);
				objConnection.Close();
				return dsImages;
			}
			catch (System.Exception ex) 
			{
				return null;
			}//end try
		}//end function

		public DataSet SelectImages(int intImagesID)
		{
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "GetImagesByID";
				objCommand.Parameters.AddWithValue("@ImagesID", intImagesID);
				objCommand.CommandType = CommandType.StoredProcedure;
				objDataApter.SelectCommand = objCommand;
				objDataApter.Fill(dsImages);
				objConnection.Close();
				return dsImages;
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}

        public int InsertUpdateImages(Int64 intImagesID, string strImagesTitle, string strImageFilePath, string strImagesDetails, Int64 intImagesNewsID, Int64 intImagesCreatedByUserID, System.DateTime datImagesCreateDateTime)
		{
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "InsertUpdateImages";
				objCommand.Parameters.AddWithValue("@ImagesID", intImagesID);
                objCommand.Parameters.AddWithValue("@ImagesTitle", strImagesTitle);
                objCommand.Parameters.AddWithValue("@ImagesFilePath", strImageFilePath);
                objCommand.Parameters.AddWithValue("@ImagesDetails", strImagesDetails);
                objCommand.Parameters.AddWithValue("@ImagesNewsID", intImagesNewsID);
                objCommand.Parameters.AddWithValue("@ImagesCreatedByUserID", intImagesCreatedByUserID);
                objCommand.Parameters.AddWithValue("@ImagesCreateDateTime", datImagesCreateDateTime);

				objCommand.CommandType = CommandType.StoredProcedure;
				intRecords = objCommand.ExecuteNonQuery();
				objConnection.Close();
				return intRecords;
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}

		public int DeleteImages(int intImagesID)
		{
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "ImagesSDeleteByID";
				objCommand.Parameters.AddWithValue("@ImagesID", intImagesID);
				objCommand.CommandType = CommandType.StoredProcedure;
				intRecords = objCommand.ExecuteNonQuery();
				objConnection.Close();
				return intRecords;
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}
    
		public int DeleteImages()
		{
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "ImagesSDeleteAll";
				objCommand.CommandType = CommandType.StoredProcedure;
				intRecords = objCommand.ExecuteNonQuery();
				objConnection.Close();
				return intRecords;
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}
    
		public int ImagesTruncate()
        {
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "ImagesTruncate";
				objCommand.CommandType = CommandType.StoredProcedure;
				intRecords = objCommand.ExecuteNonQuery();
				objConnection.Close();
				return 1;
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}

        public DataSet SelectImagesByNewsID(int intNewsID)
        {
            try
            {
                objConnection.Open();
                objCommand.Connection = objConnection;
                objCommand.CommandText = "GetImagesByNewsID";
                objCommand.Parameters.AddWithValue("@NewsID", intNewsID);
                objCommand.CommandType = CommandType.StoredProcedure;
                objDataApter.SelectCommand = objCommand;
                objDataApter.Fill(dsImages);
                objConnection.Close();
                return dsImages;
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

		
		//end function
		
		
		///////////////////////////////////////////////////////////////////////////////////////////
	}
}
