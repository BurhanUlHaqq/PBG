using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System;

namespace DataKernal
{
	public class News
	{
		//Private Variables////////////////////////////////////////////////////////////////////////
		SqlConnection objConnection;
		SqlCommand objCommand;
		string strConnectionString  = string.Empty;
		SqlDataAdapter objDataApter;
		DataSet dsNews;
		int intRecords;
		///////////////////////////////////////////////////////////////////////////////////////////


		//Constructor//////////////////////////////////////////////////////////////////////////////
		public News(string strConnString)
        {
			strConnectionString = strConnString;
			objConnection = new SqlConnection(strConnectionString);
			objCommand = new SqlCommand();
			objDataApter = new SqlDataAdapter();
			dsNews = new DataSet();
		}//end constructor
    
		public News()
        {
			strConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
			objConnection = new SqlConnection(strConnectionString);
			objCommand = new SqlCommand();
			objDataApter = new SqlDataAdapter();
            dsNews = new DataSet();
		}
		///////////////////////////////////////////////////////////////////////////////////////////

		//Public Methods///////////////////////////////////////////////////////////////////////////

        public DataSet SelectTopNews(int intTop)
        {
            try
            {
                objConnection.Open();
                objCommand.Connection = objConnection;
                objCommand.CommandText = "SelectTopNews";
                SqlParameter objTop = new SqlParameter(); 
                objTop.ParameterName = "@Top";
                objTop.Value = intTop;
                objCommand.Parameters.Add(objTop);
                objCommand.CommandType = CommandType.StoredProcedure;
                objDataApter.SelectCommand = objCommand;
                objDataApter.Fill(dsNews);
                objConnection.Close();
                return dsNews;
            }
            catch (System.Exception ex)
            {
                return null;
            }//end try
        }
        public DataSet SelectNews()
		{
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "NewsSelectAll";
				objCommand.CommandType = CommandType.StoredProcedure;
				objDataApter.SelectCommand = objCommand;
				objDataApter.Fill(dsNews);
				objConnection.Close();
				return dsNews;
			}
			catch (System.Exception ex) 
			{
				return null;
			}//end try
		}//end function

		public DataSet SelectNews(int intNewsID)
		{
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "GetNewsByID";
				objCommand.Parameters.AddWithValue("@NewsID", intNewsID);
				objCommand.CommandType = CommandType.StoredProcedure;
				objDataApter.SelectCommand = objCommand;
				objDataApter.Fill(dsNews);
				objConnection.Close();
				return dsNews;
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
		
		public int InsertUpdateNews(Int64 intNewsID, string strNewsTitle, string strNewsDetails, Int64 intCreatedByUserID, System.DateTime datCreateDateTime)
		{
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "InsertUpdateNews";
				objCommand.Parameters.AddWithValue("@NewsID", intNewsID);
                objCommand.Parameters.AddWithValue("@NewsTitle", strNewsTitle);
                objCommand.Parameters.AddWithValue("@NewsDetails", strNewsDetails);
                objCommand.Parameters.AddWithValue("@CreatedByUserID", intCreatedByUserID);
                objCommand.Parameters.AddWithValue("@CreateDateTime", datCreateDateTime);

				objCommand.CommandType = CommandType.StoredProcedure;
                objDataApter.SelectCommand = objCommand;
                objDataApter.Fill(dsNews);
                objConnection.Close();
				return Convert.ToInt32(dsNews.Tables[0].Rows[0][0]);
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}

		public int DeleteNews(int intNewsID)
		{
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "NewsDeleteByID";
				objCommand.Parameters.AddWithValue("@NewsID", intNewsID);
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
    
		public int DeleteNews()
		{
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "NewsDeleteAll";
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
    
		public int NewsTruncate()
        {
			try
			{
				objConnection.Open();
				objCommand.Connection = objConnection;
				objCommand.CommandText = "NewsTruncate";
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
		
		//end function
		
		
		///////////////////////////////////////////////////////////////////////////////////////////
	}
}
