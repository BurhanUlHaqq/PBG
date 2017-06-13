using System.Data;

namespace LogicKernal
{
	public class News
	{
        public static DataTable GetTopNews(int intTop)
        {
            try
            {
                DataKernal.News objNews = new DataKernal.News();
                return objNews.SelectTopNews(intTop).Tables[0];
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        public static DataTable GetAllNews()
		{
			try
			{
				DataKernal.News objNews =  new DataKernal.News();
				return objNews.SelectNews().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable GetNewsByID(int intNewsID)
		{
			try
			{
				DataKernal.News objNews = new DataKernal.News();
				return objNews.SelectNews(intNewsID).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static int InsertUpdateNews(BusinessEntities.News objNews)
		{
			try
			{
				DataKernal.News objDNews = new DataKernal.News();
				return objDNews.InsertUpdateNews(objNews.NewsID,objNews.NewsTitle,objNews.NewsDetails,objNews.CreatedByUserID,objNews.CreateDateTime);
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}

		public static int DeleteNews(int intNewsID)
		{
			try
			{
				DataKernal.News objNews = new DataKernal.News();
				return objNews.DeleteNews(intNewsID);
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}
		public static int DeleteNews()
		{
			try
			{
				DataKernal.News objNews = new DataKernal.News();
				return objNews.DeleteNews();
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}
    
		public static int TruncateNews()
		{
			try
			{
				DataKernal.News objNews = new DataKernal.News();
				return objNews.NewsTruncate();
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}

        public static int InsertUpdateImages(object objImages)
        {
            throw new System.NotImplementedException();
        }

        public static DataTable GetAllMessages()
        {
            throw new System.NotImplementedException();
        }
    }
}