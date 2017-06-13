using System;
using BusinessEntities;
using System.Data;


namespace LogicKernal
{
   public  class Services
    {
        public static DataTable GetAllServices()
		{
			try
			{
                DataKernal.Services objServices = new DataKernal.Services();
                return objServices.SelectServices().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}

        public static DataTable GetServicesByID(int intServicesID)
		{
			try
			{
                DataKernal.Services objServices = new DataKernal.Services();
                return objServices.SelectServices(intServicesID).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}

        public static Int64 InsertUpdateServices(BusinessEntities.Services objServices)
		{
			try
			{
                DataKernal.Services objServicess = new DataKernal.Services();
                return objServicess.InsertUpdateServices(objServices.ServiceID, objServices.ServiceName, objServices.ServiceDetails, objServices.ServiceImagePath, objServices.ServiceCreatedByUserID, objServices.ServiceCreatedByDateTime);
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}

        public static Int64 DeleteServices(int intServiceID)
		{
			try
			{
                DataKernal.Services objServices = new DataKernal.Services();
                return objServices.DeleteServices(intServiceID);
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}

        public static Int64 DeleteServices()
		{
			try
			{
                DataKernal.Services objServices = new DataKernal.Services();
                return objServices.DeleteServices();
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}

        public static int TruncateServices()
		{
			try
			{
                DataKernal.Services objServices = new DataKernal.Services();
                return objServices.ServicesTruncate();
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}
	}
    }

