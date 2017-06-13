using System;
using BusinessEntities;
using System.Data;
using System.Xml;
using System.Xml.Serialization;

namespace LogicKernal
{
    class RequestionFormHandler
    {
        public static void createNewTeacher(XmlDocument doc)
        {
            try
            {
                 XmlNode node = doc.SelectSingleNode("//IUBFacultyRequestionForm");
                 XmlElement TeacherElement= doc.CreateElement("Teacher");

                 XmlAttribute TeacherAttribute = doc.CreateAttribute("xx","abc");              

                 TeacherElement.Attributes.Append(TeacherAttribute);

                 node.InsertBefore(TeacherElement, node.FirstChild);
            }
            catch (System.Exception ex)
            {
               
            }
        }
    }
}
