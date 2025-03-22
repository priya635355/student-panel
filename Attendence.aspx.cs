using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;
using System.Configuration;

namespace Student_pannel
{
    public partial class Attendence : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindAttendanceGrid();
                UpdateAttendanceStatistics();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string studentName = txtStudentName.Text.Trim();
            string attendanceDate = AttendanceDate.Text.Trim();
            string status = ddlStatus.SelectedValue;

            
            lblError.Visible = false;
            lblSuccess.Visible = false;

            
            if (string.IsNullOrEmpty(studentName) || string.IsNullOrEmpty(attendanceDate))
            {
                lblError.Text = "Please fill in all fields.";
                lblError.Visible = true;
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Attendance (StudentName, AttendanceDate, Status) VALUES (@StudentName, @AttendanceDate, @Status)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentName", studentName);
                    cmd.Parameters.AddWithValue("@AttendanceDate", attendanceDate);
                    cmd.Parameters.AddWithValue("@Status", status);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

           
            txtStudentName.Text = "";
            AttendanceDate.Text = "";
            ddlStatus.SelectedIndex = 0;

           
            lblSuccess.Text = "Attendance marked successfully.";
            lblSuccess.Visible = true;

           
            BindAttendanceGrid();
            UpdateAttendanceStatistics();
        }

        private void BindAttendanceGrid()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT    s.Name AS StudentName,   a.AttendanceDate,  a.Status FROM    Attendance  a INNER JOIN     Student s ON a.StudentName = s.Name";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    gvAttendance.DataSource = dt;
                    gvAttendance.DataBind();
                }
            }
        }

        private void UpdateAttendanceStatistics()
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

                    Session["TotalClasses"] = totalClasses;

                    
                    string presentClassesQuery = "SELECT COUNT(*) FROM Attendance WHERE Status = 'Present'";
                    using (SqlCommand cmdPresent = new SqlCommand(presentClassesQuery, conn))
                    {
                        int presentClasses = (int)cmdPresent.ExecuteScalar();
                        lblPresentClasses.Text = $"Present Classes: {presentClasses}";

                        Session["PresentClasses"] = presentClasses;

                        
                        double attendancePercentage = totalClasses > 0 ? (double)presentClasses / totalClasses * 100 : 0;
                        lblAttendancePercentage.Text = $"Attendance Percentage: {attendancePercentage:0.00}%";

                        Session["AttendancePercentage"] = attendancePercentage;
                    }
                }
            }
        }
    }
}
