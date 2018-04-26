using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CourseRegistration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
     
            int index = 0;
            List<Course> availableCourses = new List<Course>();
            availableCourses = Helper.GetCourses();

            for (index = 0; index < availableCourses.Count; index++)
            {
                chklst.Items.Add(availableCourses[index].ToString());
            }
            lblError.Visible = false;
     
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Student student;
        int studentType;
        int selectedIndex;
        bool isRegistrationSuccess = false;
        List<Course> availableCourses = new List<Course>();
        List<Course> enrolledCourses = new List<Course>();
        availableCourses = Helper.GetCourses();

        studentType = radioBtnStudentType.Items.IndexOf(radioBtnStudentType.SelectedItem);

        if (studentType == (int)StudentType.FULL_TIME)
        {
            student = new FullTimeStudent(txtBoxName.Text);
        }
        else if (studentType == (int)StudentType.PART_TIME)
        {
            student = new PartTimeStudent(txtBoxName.Text);
        }
        else
        {
            student = new CoopStudent(txtBoxName.Text);
        }

        foreach (ListItem lstItem in chklst.Items)
        {
            if (lstItem.Selected == true)
            {
                try
                {
                    selectedIndex = chklst.Items.IndexOf(lstItem);
                    student.addCourse(availableCourses[selectedIndex]);
                    isRegistrationSuccess = true;
                }
                catch (Exception ex)
                {
                    lblError.Text = ex.Message;
                    lblError.Visible = true;
                    isRegistrationSuccess = false;
                    break;
                }
            }
        }

        if (isRegistrationSuccess == true)
        {
            lblError.Visible = false;
            registrationPanel.Visible = false;
            registeredPanel.Visible = true;

            lblShowName.Text = student.Name.ToString();
            lblShowStudentType.Text = student.ToString();

            enrolledCourses = student.getEnrolledCourses().Cast<Course>().ToList();

            // Remove all the current rows and cells.
            // This is not necessary if EnableViewState is set to false.
            tblList.Controls.Clear();

            // Create a TableHeaderRow.
            TableHeaderRow headerRow = new TableHeaderRow();
            TableHeaderCell headerTableCell1 = new TableHeaderCell();
            TableHeaderCell headerTableCell2 = new TableHeaderCell();
            TableHeaderCell headerTableCell3 = new TableHeaderCell();
            TableHeaderCell headerTableCell4 = new TableHeaderCell();
            headerTableCell1.Text = "Course Code";
            headerTableCell2.Text = "Course Title";
            headerTableCell3.Text = "Weekly Hours";
            headerTableCell4.Text = "Fee Payable";
            headerRow.Cells.Add(headerTableCell1);
            headerRow.Cells.Add(headerTableCell2);
            headerRow.Cells.Add(headerTableCell3);
            headerRow.Cells.Add(headerTableCell4);
            tblList.Controls.Add(headerRow);

            for (int i = 0; i < enrolledCourses.Count; i++)
            {
                // Create a new TableRow object.
                TableRow rowNew = new TableRow();

                // Create a new TableCell object.
                TableCell cellNew1 = new TableCell();
                TableCell cellNew2 = new TableCell();
                TableCell cellNew3 = new TableCell();
                TableCell cellNew4 = new TableCell();
                cellNew1.Text = enrolledCourses[i].Code;
                cellNew2.Text = enrolledCourses[i].Title;
                cellNew3.Text = enrolledCourses[i].WeeklyHours.ToString();
                //totalHours += enrolledCourses[i].WeeklyHours;
                cellNew4.Text = enrolledCourses[i].Fee.ToString();
                //totalFee += enrolledCourses[i].Fee;
                rowNew.Controls.Add(cellNew1);
                rowNew.Controls.Add(cellNew2);
                rowNew.Controls.Add(cellNew3);
                rowNew.Controls.Add(cellNew4);

                // Put the TableRow in the Table.
                tblList.Controls.Add(rowNew);
            }

            // Create a TableFooterRow.
            TableFooterRow footerRow = new TableFooterRow();
            TableCell footerTableCell1 = new TableCell();
            TableCell footerTableCell2 = new TableCell();
            TableCell footerTableCell3 = new TableCell();
            TableCell footerTableCell4 = new TableCell();
            footerTableCell2.Text = "Total";
            footerTableCell3.Text = student.totalWeeklyHours().ToString();
            footerTableCell4.Text = student.feePayable().ToString();
            footerRow.Cells.Add(footerTableCell1);
            footerRow.Cells.Add(footerTableCell2);
            footerRow.Cells.Add(footerTableCell3);
            footerRow.Cells.Add(footerTableCell4);
            tblList.Rows.Add(footerRow);
        }
    }
}