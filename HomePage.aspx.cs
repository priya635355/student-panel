using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Web.UI;

namespace Student_pannel
{
    public partial class HomePage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }
            else
            {

                lblName.Text = Session["Name"] != null ? Session["Name"].ToString() : "N/A";
                lblRollNumber.Text = Session["RollNumber"] != null ? Session["RollNumber"].ToString() : "N/A";
                lblCourse.Text = Session["Course"] != null ? Session["Course"].ToString() : "N/A";

            }
            string StudentName = "Priya@1";
            BindUserDetails(StudentName);
            BindStudentAssignment(StudentName);
            StoreFeesInSession();
            LoadAttendanceStatistics();
        }
        private void LoadAttendanceStatistics()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();


                string totalClassesQuery = "SELECT COUNT(*) FROM Attendance";
                using (SqlCommand cmd = new SqlCommand(totalClassesQuery, conn))
                {
                    int totalClasses = (int)cmd.ExecuteScalar();
                    lblTotalClasses.Text = $"Total Classes: {totalClasses}";

                    Label1.Text = $"Total Classes: {totalClasses}";

                    Session["TotalClasses"] = totalClasses;


                    string presentClassesQuery = "SELECT COUNT(*) FROM Attendance WHERE Status = 'Present'";
                    using (SqlCommand cmdPresent = new SqlCommand(presentClassesQuery, conn))
                    {
                        int presentClasses = (int)cmdPresent.ExecuteScalar();
                        lblPresentClasses.Text = $"Present Classes: {presentClasses}";

                        Label2.Text = $"Present Classes: {presentClasses}";

                        Session["PresentClasses"] = presentClasses;


                        double attendancePercentage = totalClasses > 0 ? (double)presentClasses / totalClasses * 100 : 0;
                        lblAttendancePercentage.Text = $"Attendance Percentage: {attendancePercentage:0.00}%";

                        Label3.Text = $"Attendance Percentage: {attendancePercentage:0.00}%";

                        Session["AttendancePercentage"] = attendancePercentage;
                    }
                }
                string feesStatusQuery = "SELECT  TOP 1   FeeDetails.Status   From Student right outer join FeeDetails\r\nON Student.Id = FeeDetails.ID  Where Student.Username = @Username";
                using (SqlCommand cmdFees = new SqlCommand(feesStatusQuery, conn))
                {
                   
                    cmdFees.Parameters.AddWithValue("@Username", Session["Username"].ToString());
                    object feesStatusObj = cmdFees.ExecuteScalar();

                    if (feesStatusObj != null)
                    {
                        string feesStatus = feesStatusObj.ToString();
                        lblFeesStatus.Text = $"Fees Status: {feesStatus}";
                    }
                    else
                    {
                        lblFeesStatus.Text = "Fees Status: Not Available";
                    }
                }
            }
        }
        private void StoreFeesInSession()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string feesQuery = "SELECT     FeeDetails.TotalFee AS TotalFees,  FeeDetails.AmountPaid AS TotalPaid   From Student right outer join FeeDetails\r\nON Student.Id = FeeDetails.ID  Where Student.Username = @Username";

                using (SqlCommand cmdFees = new SqlCommand(feesQuery, con))
                {
                    cmdFees.Parameters.AddWithValue("@Username", Session["Username"].ToString());

                    using (SqlDataReader reader = cmdFees.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            decimal totalFees = reader.IsDBNull(0) ? 0 : reader.GetDecimal(0);
                            decimal totalPaid = reader.IsDBNull(1) ? 0 : reader.GetDecimal(1);
                            decimal dueAmount = totalFees - totalPaid;

                            lblTotalFees.Text = $"{totalFees:C}"; 
                            lblAmountPaid.Text = $"{totalPaid:C}"; 
                            lblDueAmount.Text = $"{dueAmount:C}";
                        }
                    }
                }
            }

        }
        private void BindUserDetails(string StudentName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString; 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                
                string query = "SELECT StudentName, AssignmentTitle, AssignmentDescription, AssignmentDueDate, AssignmentSubmissionMethod, AssignmentMarks, " +
                               "ExamTitle, ExamDateTime, ExamLocation, ExamFormat, ExamTotalMarks, ExamPassingCriteria, ExamSyllabus, ExamInstructions " +
                               "FROM [Student].[dbo].[AssignmentExamInfo] WHERE StudentName = @StudentName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentName", StudentName); 
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                           

                            lblAssignmentTitle.Text = reader["AssignmentTitle"].ToString();

                            lblDueDate.Text = reader["AssignmentDueDate"].ToString();
                            lblSubmissionMethod.Text = reader["AssignmentSubmissionMethod"].ToString();
                           
                        }
                        else
                        {
                            
                        }
                    }
                }
            }
        }
        private void BindStudentAssignment(string StudentName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string query = "SELECT TOP 1 AssignmentTitle, AssignmentDueDate, AssignmentSubmissionMethod, " +
                               "ISNULL(FilePath, '') AS FilePath " +
                               "FROM [Student].[dbo].[AssignmentExamInfo] WHERE StudentName = @StudentName ORDER BY AssignmentDueDate DESC";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentName", StudentName);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {



                            string filePath = reader["FilePath"].ToString();
                            lblAssignment.Text = string.IsNullOrEmpty(filePath) ? "Assignment Status: Not Submitted" : "Assignment Status: Submitted";
                        }
                        else
                        {
                            lblAssignment.Text = "Assignment Status: Not Available"; // No records found
                        }
                    }
                }
            }
        }
    }


}
