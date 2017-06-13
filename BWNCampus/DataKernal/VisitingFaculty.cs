using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DataKernal
{
    public class VisitingFaculty
    {
        //Private Variables////////////////////////////////////////////////////////////////////////
		SqlConnection objConnection;
		SqlCommand objCommand;
		string strConnectionString  = string.Empty;
		SqlDataAdapter objDataApter;
		DataSet dsContacts;
		int intRecords;
		///////////////////////////////////////////////////////////////////////////////////////////


		//Constructor//////////////////////////////////////////////////////////////////////////////
		public VisitingFaculty(string strConnString)
        {
			strConnectionString = strConnString;
			objConnection = new SqlConnection(strConnectionString);
			objCommand = new SqlCommand();
			objDataApter = new SqlDataAdapter();
			dsContacts = new DataSet();
		}//end constructor

        public VisitingFaculty()
        {
			strConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
			objConnection = new SqlConnection(strConnectionString);
			objCommand = new SqlCommand();
			objDataApter = new SqlDataAdapter();
            dsContacts = new DataSet();
		}
		///////////////////////////////////////////////////////////////////////////////////////////

        //Public Methods///////////////////////////////////////////////////////////////////////////

        public DataSet SelectVisitingFaculty()
        {
            try
            {
                objConnection.Open();
                objCommand.Connection = objConnection;
                objCommand.CommandText = "getAllVisitingFaculty";
                objCommand.CommandType = CommandType.StoredProcedure;
                objDataApter.SelectCommand = objCommand;
                objDataApter.Fill(dsContacts);
                objConnection.Close();
                return dsContacts;
            }
            catch (System.Exception ex)
            {
                return null;
            }//end try
        }//end function

        public DataSet SelectVisitingFaculty(Int64 intVisitingFacultyID)
        {
            try
            {
                objConnection.Open();
                objCommand.Connection = objConnection;
                objCommand.CommandText = "getVisitingFacultyById";
                objCommand.Parameters.AddWithValue("@id", intVisitingFacultyID);
                objCommand.CommandType = CommandType.StoredProcedure;
                objDataApter.SelectCommand = objCommand;
                objDataApter.Fill(dsContacts);
                objConnection.Close();
                return dsContacts;
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public int InsertUpdateVisitingFaculty(Int64 intVisitingFacultyID, string strVisitingFacultyName, string strVisitingFacultyGander, string strVisitingFacultyCNIC, string  strVisitingFacultyQualification, string strVisitingFacultyCellNo, string strVisitingFacultyEmail, string strVisitingFacultyAddedBy)
        {
            try
            {
                objConnection.Open();
                objCommand.Connection = objConnection;
                objCommand.CommandText = "insertUpdateVisitingFaculty";
                objCommand.Parameters.AddWithValue("@VId", intVisitingFacultyID);
                objCommand.Parameters.AddWithValue("@VName", strVisitingFacultyName);
                objCommand.Parameters.AddWithValue("@VGander", strVisitingFacultyGander);
                objCommand.Parameters.AddWithValue("@VCNIC", strVisitingFacultyCNIC);
                objCommand.Parameters.AddWithValue("@VQualification", strVisitingFacultyQualification);
                objCommand.Parameters.AddWithValue("@VCellNo", strVisitingFacultyCellNo);
                objCommand.Parameters.AddWithValue("@VEmail", strVisitingFacultyEmail);
                objCommand.Parameters.AddWithValue("@AddedBy", strVisitingFacultyAddedBy);

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
        public int DeleteVisitingFaculty(int intVisitingFacultyID)
        {
            try
            {
                objConnection.Open();
                objCommand.Connection = objConnection;
                objCommand.CommandText = "deleteVisitingFacultyByID";
                objCommand.Parameters.AddWithValue("@id", intVisitingFacultyID);
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

        public int DeleteVisitingFaculty()
        {
            try
            {
                objConnection.Open();
                objCommand.Connection = objConnection;
                objCommand.CommandText = "deleteAllVisitingFaculty";
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
        public int visitingFacultyTruncate()
        {
            try
            {
                objConnection.Open();
                objCommand.Connection = objConnection;
                objCommand.CommandText = "truncateVisitingFaculty";
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
