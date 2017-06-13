using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace LogicKernal
{
    public class VisitingFaculty
    {
        public static DataTable GetAllFaculty()
        {
            try
            {
                DataKernal.VisitingFaculty ObjVisitingFaculty = new DataKernal.VisitingFaculty();
                return ObjVisitingFaculty.SelectVisitingFaculty().Tables [0];
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public static DataTable GetFacultyByID(Int64 intFacultyID)
        {
            try
            {
                DataKernal.VisitingFaculty ObjVisitingFaculty = new DataKernal.VisitingFaculty();
                return ObjVisitingFaculty.SelectVisitingFaculty(intFacultyID).Tables[0];
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public static int InsertUpdateFaculty(BusinessEntities.VisitingFaculty ObjFaculty)
        {
            try
            {
                DataKernal.VisitingFaculty ObjVisitingFaculty = new DataKernal.VisitingFaculty();
                return ObjVisitingFaculty.InsertUpdateVisitingFaculty(ObjFaculty.ID, ObjFaculty.Name, ObjFaculty.Gander, ObjFaculty .CNIC , ObjFaculty.Qualification, ObjFaculty.CellNo, ObjFaculty.Email, ObjFaculty.AddedBy);
            }
            catch (Exception e) { return 0; }
        }
        public static int DeleteFacultyByID(int intFacultyId)
        {
            try
            {
                DataKernal.VisitingFaculty ObjVisitingFaculty = new DataKernal.VisitingFaculty();
                return ObjVisitingFaculty.DeleteVisitingFaculty(intFacultyId);
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public static int DeleteAllFaculty()
        {
            try
            {
                DataKernal.VisitingFaculty ObjVisitingFaculty = new DataKernal.VisitingFaculty();
                return ObjVisitingFaculty.DeleteVisitingFaculty();
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public static int TruncateFaculty()
        {
            try
            {
                DataKernal.VisitingFaculty ObjVisitingFaculty = new DataKernal.VisitingFaculty();
                return ObjVisitingFaculty.visitingFacultyTruncate();
            }
            catch (Exception e)
            {
                return 0;
            }
        }
    }
}
