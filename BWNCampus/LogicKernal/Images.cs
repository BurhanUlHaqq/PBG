using System.Data;

namespace LogicKernal
{
	public class Images
	{
		public static DataTable GetAllImages()
		{
			try
			{
				DataKernal.Images objImages =  new DataKernal.Images();
				return objImages.SelectImages().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable GetImagesByID(int intImagesID)
		{
			try
			{
				DataKernal.Images objImages = new DataKernal.Images();
				return objImages.SelectImages(intImagesID).Tables[0];
			}
            catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static int InsertUpdateImages(BusinessEntities.Images objImages)
		{
			try
			{
				DataKernal.Images objDImages = new DataKernal.Images();
				return objDImages.InsertUpdateImages(objImages.ImagesID,objImages.ImagesTitle, objImages.ImageFilePath, objImages.ImagesDetails, objImages.ImagesNewsID,objImages.ImagesCreatedByUserID,objImages.ImagesCreateDateTime);
			}
            catch (System.Exception ex)
			{
				return 0;
			}
		}

		public static int DeleteImages(int intImagesID)
		{
			try
			{
				DataKernal.Images objImages = new DataKernal.Images();
				return objImages.DeleteImages(intImagesID);
			}
            catch (System.Exception ex)
			{
				return 0;
			}
		}

		public static int DeleteImages()
		{
			try
			{
				DataKernal.Images objImages = new DataKernal.Images();
				return objImages.DeleteImages();
			}
            catch (System.Exception ex)
			{
				return 0;
			}
		}
    
		public static int TruncateImages()
		{
			try
			{
				DataKernal.Images objImages = new DataKernal.Images();
				return objImages.ImagesTruncate();
			}
            catch (System.Exception ex)
			{
				return 0;
			}
		}

        public static DataTable GetImagesByNewsID(int intNewsID)
        {
            try
            {
                DataKernal.Images objImages = new DataKernal.Images();
                return objImages.SelectImagesByNewsID(intNewsID).Tables[0];
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
	}
}