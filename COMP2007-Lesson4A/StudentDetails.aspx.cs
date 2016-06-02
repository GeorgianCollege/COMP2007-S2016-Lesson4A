using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// connect to EF db
using COMP2007_Lesson4A.Models;
using System.Web.ModelBinding;

namespace COMP2007_Lesson4A
{
    public partial class StudentDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Students.aspx");
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            // Use EF to connect to the Server
            using (DefaultConnection db = new DefaultConnection())
            {
                // use the student model to save a new record
                Student newStudent = new Student();

                newStudent.LastName = LastNameTextBox.Text;
                newStudent.FirstMidName = FirstNameTextBox.Text;
                newStudent.EnrollmentDate = Convert.ToDateTime(EnrollmentDateTextBox.Text);

                // adding the new student to the collection
                db.Students.Add(newStudent);

                // run an insert command
                db.SaveChanges();

                // redirect back to the updated students page
                Response.Redirect("~/Students.aspx");
            }
        }
    }
}