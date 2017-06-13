using System;
using System.Data;

namespace LogicKernal
{
	public class Messages
	{
		public static DataTable GetAllMessages()
		{
			try
			{
				DataKernal.Messages objMessages =  new DataKernal.Messages();
				return objMessages.SelectMessages().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable GetMessagesByID(int intMessagesID)
		{
			try
			{
				DataKernal.Messages objMessages = new DataKernal.Messages();
				return objMessages.SelectMessages(intMessagesID).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static int InsertUpdateMessages(BusinessEntities.Messages objMessages)
		{
			try
			{
				DataKernal.Messages objDMessages = new DataKernal.Messages();
				return objDMessages.InsertUpdateMessages(objMessages.MessagesID,
                    objMessages.MessageTitle,
                    objMessages.MessagesDetails,
                    objMessages.MessageSenderName,
                    objMessages.MessageSenderEmail,
                objMessages.MessageSenderPhone,
                objMessages.CreatedDate,
                objMessages.IsRead,
                objMessages.ReplierID);
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}

		public static int DeleteMessages(int intMessagesID)
		{
			try
			{
				DataKernal.Messages objMessages = new DataKernal.Messages();
				return objMessages.DeleteMessages(intMessagesID);
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}
		public static int DeleteMessages()
		{
			try
			{
				DataKernal.Messages objMessages = new DataKernal.Messages();
				return objMessages.DeleteMessages();
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}
    
		public static int TruncateMessages()
		{
			try
			{
				DataKernal.Messages objMessages = new DataKernal.Messages();
				return objMessages.MessagesTruncate();
			}
			catch (System.Exception ex)
			{
				return 0;
			}
		}




        public static object InsertUpdaetMessages(BusinessEntities.Messages objMessages)
        {
            throw new NotImplementedException();
        }
    }
}