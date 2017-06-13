using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Xml;

public partial class PaymentBill : System.Web.UI.Page
{
    int GtotalLectures = 0;
    int GtotalAmount = 0;
    int Gtax;
    string taxrate = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["PaymentBill"] != null)
        {
            lblDepartment.Text = (Session["PaymentBill"].ToString()).Split(':')[0];
            lblbBillType.Text = (Session["PaymentBill"].ToString()).Split(':')[1];
            lblSpringOrFall.Text = (Session["PaymentBill"].ToString()).Split(':')[2];
            lblYear.Text = (Session["PaymentBill"].ToString()).Split(':')[3];
            lblTeacherName.Text = (Session["PaymentBill"].ToString()).Split(':')[4];
            lblTeacherDesignatin.Text = (Session["PaymentBill"].ToString()).Split(':')[5];
            createMainTable();
        }
        else
        {
            lblBodyTable.Text = "" +
       "<table align='center' width='100%' border='2' style='border-style: solid; border-width: 2px; font-weight: bold; font-size: Small; font-family: Arial, Helvetica, sans-serif'>" +
          " <tr align='Center'  style='font-weight: bold;'>" +
               "<td>You are not Loged In<br/><a href='DepartmentList.aspx'>Login</a></td>" +
           "</tr>" +
       "</table> ";
        }
    }

    private void createMainTable()
    {
        string path = Server.MapPath("XMLStorage/IUBFacultyPaymentBills/" + lblDepartment.Text + "/");
        string year = lblYear.Text;
        string smsterName = lblSpringOrFall.Text;
        if (File.Exists(path + smsterName + "_" + year + ".xml"))
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path + smsterName + "_" + year + ".xml");
            XmlNode selectedTeacher = doc.SelectSingleNode("IUBFacultyPaymentBills/Teacher[@Name='" + lblTeacherName.Text + "']");
            lblTeacherAcountNo.Text = selectedTeacher.Attributes["HBLBankAcountNo"].Value;
            XmlNode taxNode = selectedTeacher.ParentNode;
            taxrate = taxNode.Attributes["IncomeTaxRate"].Value;
        }
        lblBodyTable.Text = "" +
        "<table align='center' width='100%' border='2' style='border-style: solid; border-width: 2px; font-weight: bold; font-size: Small; font-family: Arial, Helvetica, sans-serif'>" +
           " <tr align='Center'  style='font-weight: bold;'>" +
                "<td>Program/<br/>Semester</td>" +
                "<td>Subject/Course Code</td>" +
                "<td>Credit<br/>Hour</td>" +
                "<td>For the Month of</td>" +
                "<td colspan='10'>Dates of Lecture Delivered</td>" +
                "<td>Total<br/>Lectures<br/>Delivered</td>" +
                "<td>Rate Per<br/>Lectures</td>" +
                "<td>Total<br/>Amount</td>" +
                "<td>Income<br/>Tax @" + taxrate + "%</td>" +
                "<td>Net Amount<br/>Payable</td>" +
                "<td>ECR P.#<br/>(Official<br/>Use)</td>" +
            "</tr>" + createCoursesRows() + "<tr align='Center'  style='font-weight: bold;'>" +
                "<td colspan='14'>Grand Total (All Courses) </td>" +
                "<td>" + GtotalLectures + "</td>" +
                "<td></td>" +
                "<td>" + GtotalAmount + "</td>" +
                "<td>" + Gtax + "</td>" +
                "<td>" + (GtotalAmount - Gtax) + "</td>" +
                "<td></td>" +
                "</tr>"+
        "</table> ";
    }
    private string createCoursesRows()
    {
        string returnVar = "";
        string path = Server.MapPath("XMLStorage/IUBFacultyPaymentBills/" + lblDepartment.Text + "/");
        string year = lblYear.Text;
        string smsterName = lblSpringOrFall.Text;
        if (File.Exists(path + smsterName + "_" + year + ".xml"))
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path + smsterName + "_" + year + ".xml");
            XmlNode selectedTeacher = doc.SelectSingleNode("IUBFacultyPaymentBills/Teacher[@Name='" + lblTeacherName.Text + "']");
            XmlNode selectedSemester = selectedTeacher.FirstChild;
            XmlNodeList courseNode = selectedSemester.SelectNodes("Course");
            int i = 0;
            while (i < courseNode.Count)
            {
                XmlNodeList monthNode = courseNode.Item(i).SelectNodes("Month");
                returnVar = returnVar + " <tr align='Center'  style='font-weight: 200;'>" +
                  "<td rowspan=" + monthNode.Count + ">" + courseNode.Item(i).Attributes["SemesterName"].Value + "<br/>Semester No:" + courseNode.Item(i).Attributes["SemesterNo"].Value + "</td>" +
                  "<td rowspan=" + monthNode.Count + ">" + courseNode.Item(i).Attributes["TitleOfCourse"].Value + "<br/>" + courseNode.Item(i).Attributes["CourseCode"].Value + "</td>" +
                  "<td rowspan=" + monthNode.Count + ">" + courseNode.Item(i).Attributes["CourseCreditHrs"].Value + "</td>" + creatingMonthAndDates(i) +
            "</tr>"+createSubjectTotal(i);
              i++;
            }
            returnVar=returnVar+"";
        }
        return returnVar;
    }
    private string creatingMonthAndDates(int CourseNo)
    {
        string returnVar = "";
        string path = Server.MapPath("XMLStorage/IUBFacultyPaymentBills/" + lblDepartment.Text + "/");
        string year = lblYear.Text;
        string smsterName = lblSpringOrFall.Text;
        if (File.Exists(path + smsterName + "_" + year + ".xml"))
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path + smsterName + "_" + year + ".xml");
            XmlNode selectedTeacher = doc.SelectSingleNode("IUBFacultyPaymentBills/Teacher[@Name='" + lblTeacherName.Text + "']");
            XmlNode selectedSemester = selectedTeacher.FirstChild;
            XmlNodeList courseNode = selectedSemester.SelectNodes("Course");
            XmlNodeList monthNode = courseNode.Item(CourseNo).SelectNodes("Month");
            int i = 0;
            while (i < monthNode.Count)
            {
                if (i == 0)
                {
                    returnVar = returnVar + "<td>" + changeMonthNoToMonthName(Convert.ToInt32(monthNode.Item(i).Attributes["Name"].Value)) + "</td>" + creatingDates(i, CourseNo) + "<td rowspan=" + monthNode.Count + ">" + selectedTeacher.Attributes["RatePerLecture"].Value + "</td>" + createTotalAmmount(i, CourseNo) + createTaxAmmount(i, CourseNo) + createPayableAmmount(i, CourseNo) + "<td></td>";
                }
                else
                {
                    returnVar = returnVar + " <tr align='Center'  style='font-weight: 200;'>" +
                      "<td>" + changeMonthNoToMonthName(Convert.ToInt32(monthNode.Item(i).Attributes["Name"].Value)) + "</td>" + creatingDates(i, CourseNo) +createTotalAmmount(i, CourseNo)+createTaxAmmount(i,CourseNo)+createPayableAmmount(i, CourseNo)+"<td></td>"+
                      "</tr>";
                }
                i++;
            }
        }
        return returnVar;
    }
    private string creatingDates(int MonthNo, int CourseNo)
    {
        string returnVar = "";
        string path = Server.MapPath("XMLStorage/IUBFacultyPaymentBills/" + lblDepartment.Text + "/");
        string year = lblYear.Text;
        string smsterName = lblSpringOrFall.Text;
        if (File.Exists(path + smsterName + "_" + year + ".xml"))
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path + smsterName + "_" + year + ".xml");
            XmlNode selectedTeacher = doc.SelectSingleNode("IUBFacultyPaymentBills/Teacher[@Name='" + lblTeacherName.Text + "']");
            XmlNode selectedSemester = selectedTeacher.FirstChild;
            XmlNodeList courseNode = selectedSemester.SelectNodes("Course");
            XmlNodeList monthNode = courseNode.Item(CourseNo).SelectNodes("Month");
            XmlNodeList DateNode = monthNode.Item(MonthNo).SelectNodes("Date");
            int i = 0;
            while (i < 10)
            {
                XmlNode node=DateNode .Item (i);
                if (node != null)
                {
                    returnVar = returnVar + "<td>"+node.InnerText+
                        "</d>";
                }
                else
                {
                    returnVar = returnVar + "<td colspan='"+(10-i)+"'>" +
                        "</d>";
                    i = 10;
                }
                i++;
            }
            returnVar = returnVar + "<td>" + DateNode.Count+
            "</td>";
        }
        return returnVar ;
    }
    private string createTotalAmmount(int MonthNo, int CourseNo)
    {
        string TotalAmount = "";
        string path = Server.MapPath("XMLStorage/IUBFacultyPaymentBills/" + lblDepartment.Text + "/");
        string year = lblYear.Text;
        string smsterName = lblSpringOrFall.Text;
        if (File.Exists(path + smsterName + "_" + year + ".xml"))
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path + smsterName + "_" + year + ".xml");
            XmlNode selectedTeacher = doc.SelectSingleNode("IUBFacultyPaymentBills/Teacher[@Name='" + lblTeacherName.Text + "']");
            XmlNode selectedSemester = selectedTeacher.FirstChild;
            XmlNodeList courseNode = selectedSemester.SelectNodes("Course");
            XmlNodeList monthNode = courseNode.Item(CourseNo).SelectNodes("Month");
            XmlNodeList DateNode = monthNode.Item(MonthNo).SelectNodes("Date");
            int totalLectures=Convert .ToInt32(DateNode.Count);
            int lectureRate = Convert.ToInt32(selectedTeacher.Attributes["RatePerLecture"].Value);
            TotalAmount = "<td>" + (totalLectures * lectureRate) + "</td>";
        }
        return TotalAmount;
    }
    private string createTaxAmmount(int MonthNo, int CourseNo)
    {
        string TaxAmount = "";
        string path = Server.MapPath("XMLStorage/IUBFacultyPaymentBills/" + lblDepartment.Text + "/");
        string year = lblYear.Text;
        string smsterName = lblSpringOrFall.Text;
        if (File.Exists(path + smsterName + "_" + year + ".xml"))
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path + smsterName + "_" + year + ".xml");
            XmlNode selectedTeacher = doc.SelectSingleNode("IUBFacultyPaymentBills/Teacher[@Name='" + lblTeacherName.Text + "']");
            XmlNode selectedSemester = selectedTeacher.FirstChild;
            XmlNodeList courseNode = selectedSemester.SelectNodes("Course");
            XmlNodeList monthNode = courseNode.Item(CourseNo).SelectNodes("Month");
            XmlNodeList DateNode = monthNode.Item(MonthNo).SelectNodes("Date");
            int totalLectures = Convert.ToInt32(DateNode.Count);
            int lectureRate = Convert.ToInt32(selectedTeacher.Attributes["RatePerLecture"].Value);
            int totalAmount = totalLectures * lectureRate;
            int TaxRate = Convert.ToInt32(taxrate);
            int tax = (totalAmount * TaxRate) / 100;
            TaxAmount = "<td>" + (tax) + "</td>";
        }
        return TaxAmount;
    }

    private string createPayableAmmount(int MonthNo, int CourseNo)
    {
        string PayableAmount = "";
        string path = Server.MapPath("XMLStorage/IUBFacultyPaymentBills/" + lblDepartment.Text + "/");
        string year = lblYear.Text;
        string smsterName = lblSpringOrFall.Text;
        if (File.Exists(path + smsterName + "_" + year + ".xml"))
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path + smsterName + "_" + year + ".xml");
            XmlNode selectedTeacher = doc.SelectSingleNode("IUBFacultyPaymentBills/Teacher[@Name='" + lblTeacherName.Text + "']");
            XmlNode selectedSemester = selectedTeacher.FirstChild;
            XmlNodeList courseNode = selectedSemester.SelectNodes("Course");
            XmlNodeList monthNode = courseNode.Item(CourseNo).SelectNodes("Month");
            XmlNodeList DateNode = monthNode.Item(MonthNo).SelectNodes("Date");
            int totalLectures = Convert.ToInt32(DateNode.Count);
            int lectureRate = Convert.ToInt32(selectedTeacher.Attributes["RatePerLecture"].Value);
            int totalAmount = totalLectures * lectureRate;
            int TaxRate = Convert.ToInt32(taxrate);
            int tax = (totalAmount * TaxRate) / 100;
            PayableAmount = "<td>" + (totalAmount - tax) + "</td>";
        }
        return PayableAmount;
    }

    private string  createSubjectTotal(int CourseNo)
    {
        string returnVar = "";
        string path = Server.MapPath("XMLStorage/IUBFacultyPaymentBills/" + lblDepartment.Text + "/");
        string year = lblYear.Text;
        string smsterName = lblSpringOrFall.Text;
        if (File.Exists(path + smsterName + "_" + year + ".xml"))
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path + smsterName + "_" + year + ".xml");
            XmlNode selectedTeacher = doc.SelectSingleNode("IUBFacultyPaymentBills/Teacher[@Name='" + lblTeacherName.Text + "']");
            XmlNode selectedSemester = selectedTeacher.FirstChild;
            XmlNodeList courseNode = selectedSemester.SelectNodes("Course");
            XmlNodeList monthNode = courseNode.Item(CourseNo).SelectNodes("Month");
            int totalLectures=0;
            int lectureRate = Convert.ToInt32(selectedTeacher.Attributes["RatePerLecture"].Value); 
            int totalAmount=0;
            int TaxRate = Convert.ToInt32(taxrate);
            int tax;
            int i=0;
            while(i<monthNode .Count )
            {
                int amount = 0;
                XmlNodeList date=monthNode .Item (i).SelectNodes ("Date");
                totalLectures = totalLectures+date.Count;
                amount = date.Count * lectureRate;
                totalAmount = totalAmount + amount;
                i++;
            }
            tax = (totalAmount * TaxRate) / 100;
            returnVar = "<tr align='Center'  style='font-weight: bold;'>"+
                "<td colspan='14'>Total= " + (CourseNo+1) + "</td>" +
                "<td>" + totalLectures + "</td>" +
                "<td></td>" +
                "<td>" + totalAmount + "</td>" +
                "<td>" + tax + "</td>" +
                "<td>" + (totalAmount - tax) + "</td>" +
                "<td></td>" +
                "</tr>";
            GtotalLectures = GtotalLectures + totalLectures;
            GtotalAmount = GtotalAmount + totalAmount;
            Gtax = Gtax + tax;
        }
        return returnVar;
    }
    private string changeMonthNoToMonthName(int MonthNo)
    {
        string monthName = "";
        if (MonthNo == 1)
        {
            monthName = "January";
        }
        else if (MonthNo == 2)
        {
            monthName = "February";
        }
        else if (MonthNo == 3)
        {
            monthName = "March";
        }
        else if (MonthNo == 4)
        {
            monthName = "April";
        }
        else if (MonthNo == 5)
        {
            monthName = "May";
        }
        else if (MonthNo == 6)
        {
            monthName = "June";
        }
        else if (MonthNo == 7)
        {
            monthName = "July";
        }
        else if (MonthNo == 8)
        {
            monthName = "August";
        }
        else if (MonthNo == 9)
        {
            monthName = "September";
        }
        else if (MonthNo == 10)
        {
            monthName = "October";
        }
        else if (MonthNo == 11)
        {
            monthName = "November";
        }
        else if (MonthNo == 12)
        {
            monthName = "December";
        }
        return monthName;
    }
}