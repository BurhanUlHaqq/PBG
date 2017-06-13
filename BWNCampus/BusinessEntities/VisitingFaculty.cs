using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    public class VisitingFaculty
    {
        //  Private Variables ///////////////////////////////////
        private Int64 intVisitingFacultyID;
        private string strVisitingFacultyName;
        private string strVisitingFacultyGander;
        private string strVisitingFacultyCNIC;
        private string strVisitingFacultyQualification;
        private string strVisitingFacultyCellNo;
        private string strVisitingFacultyEmail;
        private string strVisitingFacultyAddedBy;
        /////////////////////////////////////////////////////////

        //Public Properties/////////////////////////////////////
        public Int64 ID
        {
            get
            {
                return intVisitingFacultyID;
            }
            set
            {
                intVisitingFacultyID = value;
            }
        }
        public string Name
        {
            get
            {
                return strVisitingFacultyName;
            }
            set
            {
                strVisitingFacultyName = value;
            }
        }
        public string Gander
        {
            get
            {
                return strVisitingFacultyGander;
            }
            set
            {
                strVisitingFacultyGander = value;
            }
        }
        public string CNIC
        {
            get
            {
                return strVisitingFacultyCNIC;
            }
            set
            {
                strVisitingFacultyCNIC = value;
            }
        }
        public string Qualification
        {
            get
            {
                return strVisitingFacultyQualification;
            }
            set
            {
                strVisitingFacultyQualification = value;
            }
        }
        public string CellNo
        {
            get
            {
                return strVisitingFacultyCellNo;
            }
            set
            {
                strVisitingFacultyCellNo = value;
            }
        }
        public string Email
        {
            get
            {
                return strVisitingFacultyEmail;
            }
            set
            {
                strVisitingFacultyEmail = value;
            }
        }
        public string AddedBy
        {
            get
            {
                return strVisitingFacultyAddedBy;
            }
            set
            {
                strVisitingFacultyAddedBy = value;
            }
        }
        /////////////////////////////////////////////////////////
    }
}
