using System.Data;

namespace LogicKernal
{
	public class Contacts
	{
		public static DataTable GetAllContacts()
		{
			try
			{
				DataKernal.Contacts objContacts =  new DataKernal.Contacts();
				return objContacts.SelectContacts().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable GetContactsByID(int intContactID)
		{
			try
			{
				DataKernal.Contacts objContacts = new DataKernal.Contacts();
				return objContacts.SelectContacts(intContactID).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static int InsertUpdateContacts(BusinessEntities.Contacts objContacts)
		{
			try
			{
				DataKernal.Contacts objDContacts = new DataKernal.Contacts();
				return objDContacts.InsertUpdateContacts(objContacts.ContactID,objContacts.ContactTitle,objContacts.Telephone,objContacts.Email);
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}

		public static int DeleteContacts(int intContactID)
		{
			try
			{
				DataKernal.Contacts objContacts = new DataKernal.Contacts();
				return objContacts.DeleteContacts(intContactID);
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}
		public static int DeleteContacts()
		{
			try
			{
				DataKernal.Contacts objContacts = new DataKernal.Contacts();
				return objContacts.DeleteContacts();
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}
    
		public static int TruncateContacts()
		{
			try
			{
				DataKernal.Contacts objContacts = new DataKernal.Contacts();
				return objContacts.ContactsTruncate();
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}
	}
}