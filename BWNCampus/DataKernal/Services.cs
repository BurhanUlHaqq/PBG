       using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System;

namespace DataKernal
{
    public class Services
    {

        //Private Variables////////////////////////////////////////////////////////////////////////
        SqlConnection objConnection;
        SqlCommand objCommand;
        string strConnectionString = string.Empty;
        SqlDataAdapter objDataApter;
        DataSet dsServices;
        int intRecords;
        ///////////////////////////////////////////////////////////////////////////////////////////


        //Constructor//////////////////////////////////////////////////////////////////////////////
        public Services(string strConnString)
        {
            strConnectionString = strConnString;
            objConnection = new SqlConnection(strConnectionString);
            objCommand = new SqlCommand();
            objDataApter = new SqlDataAdapter();
            dsServices = new DataSet();
        }//end constructor

        public Services()
        {
            strConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            objConnection = new SqlConnection(strConnectionString);
            objCommand = new SqlCommand();
            objDataApter = new SqlDataAdapter();
            dsServices = new DataSet();
        }
        ///////////////////////////////////////////////////////////////////////////////////////////

        //Public Methods///////////////////////////////////////////////////////////////////////////

        public DataSet SelectTopServices(int intTop)
        {
            try
            {
                objConnection.Open();
                objCommand.Connection = objConnection;
                objCommand.CommandText = "GetTopServices";
                SqlParameter objTop = new SqlParameter();
                objTop.ParameterName = "@Top";
                objTop.Value = intTop;
                objCommand.Parameters.Add(objTop);
                objCommand.CommandType = CommandType.StoredProcedure;
                objDataApter.SelectCommand = objCommand;
                objDataApter.Fill(dsServices);
                objConnection.Close();
                return dsServices;
            }
            catch (System.Exception ex)
            {
                return null;
            }//end try
        }
        public DataSet SelectServices()
        {
            try
            {
                objConnection.Open();
                objCommand.Connection = objConnection;
                objCommand.CommandText = "ServicesSelectAll";
                objCommand.CommandType = CommandType.StoredProcedure;
                objDataApter.SelectCommand = objCommand;
                objDataApter.Fill(dsServices);
                objConnection.Close();
                return dsServices;
            }
            catch (System.Exception ex)
            {
                return null;
            }//end try
        }//end function

        public DataSet SelectServices(int intServiceID)
        {
            try
            {
                objConnection.Open();
                objCommand.Connection = objConnection;
                objCommand.CommandText = "GetServicesByID";
                objCommand.Parameters.AddWithValue("@ServiceID", intServiceID);
                objCommand.CommandType = CommandType.StoredProcedure;
                objDataApter.SelectCommand = objCommand;
                objDataApter.Fill(dsServices);
                objConnection.Close();
                return dsServices;
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public int InsertUpdateServices(Int64 intServiceID, string strServiceName, string strServiceDetail, string strImageFilePath, Int64 intCreatedByUserID, System.DateTime datCreateDateTime)
        {
            try
            {
                objConnection.Open();
                objCommand.Connection = objConnection;
                objCommand.CommandText = "InsertUpdateServices";
                objCommand.Parameters.AddWithValue("@ServiceID", intServiceID);
                objCommand.Parameters.AddWithValue("@ServiceName", strServiceName);
                objCommand.Parameters.AddWithValue("@ServiceDetail", strServiceDetail);
                objCommand.Parameters.AddWithValue("@ServiceImageFilePath", strImageFilePath);
                objCommand.Parameters.AddWithValue("@ServiceCreatedByUserID", intCreatedByUserID);
                objCommand.Parameters.AddWithValue("@ServiceCreateDateTime", datCreateDateTime);

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

        public int DeleteServices(int intServiceID)
        {
            try
            {
                objConnection.Open();
                objCommand.Connection = objConnection;
                objCommand.CommandText = "ServicesDeleteByID";
                objCommand.Parameters.AddWithValue("@ServiceID", intServiceID);
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

        public int DeleteServices()
        {
            try
            {
                objConnection.Open();
                objCommand.Connection = objConnection;
                objCommand.CommandText = "ServicesDeleteAll";
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

        public int ServicesTruncate()
        {
            try
            {
                objConnection.Open();
                objCommand.Connection = objConnection;
                objCommand.CommandText = "ServicesTruncate";
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
    }
}

