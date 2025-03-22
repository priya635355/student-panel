using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Student_pannel
{
    public partial class Assignment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string studentName = "Priya@1"; // Get student name from session or other means
                TextBoxStudentName.Text = studentName;

                if (!string.IsNullOrEmpty(studentName))
                {
                    BindUserDetails(studentName);
                    int teacherId = 13; // Replace with logic to get the teacher's ID
                    BindTeacherDetails(teacherId); // Pass the actual teacher ID
                    BindSubmissions(studentName); // Bind submissions on initial load
                }
                else
                {
                    LabelStatus.Text = "User not logged in.";
                }
            }
        }

        private void BindUserDetails(string studentName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT AssignmentTitle, AssignmentDescription FROM AssignmentExamInfo WHERE StudentName = @StudentName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentName", studentName);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            TextBoxStudentAssignmentTitle.Text = reader["AssignmentTitle"].ToString();
                            TextBoxStudentAssignmentDescription.Text = reader["AssignmentDescription"].ToString();
                        }
                    }
                }
            }
        }

        private void BindTeacherDetails(int id) // Pass the teacher ID
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT AssignmentTitle, AssignmentDescription, AssignmentDueDate FROM AssignmentExamInfo WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id); // Set the actual teacher ID
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            LabelAssignmentTitle.Text = reader["AssignmentTitle"].ToString();
                            LabelAssignmentDescription.Text = reader["AssignmentDescription"].ToString();
                            LabelAssignmentDueDate.Text = Convert.ToDateTime(reader["AssignmentDueDate"]).ToString("MM/dd/yyyy");
                        }
                        else
                        {
                            LabelStatus.Text = "No assignment details found for this teacher ID.";
                        }
                    }
                }
            }
        }

        protected void ButtonSubmitStudent_Click(object sender, EventArgs e)
        {
            if (FileUploadAssignment.HasFile)
            {
                try
                {
                    // Validate file type and size
                    string[] validFileTypes = { ".pdf", ".docx", ".pptx", ".jpeg", ".jpg", ".png" };
                    string fileExtension = Path.GetExtension(FileUploadAssignment.FileName).ToLower();

                    if (!Array.Exists(validFileTypes, element => element == fileExtension))
                    {
                        LabelStatus.Text = "Invalid file type. Please upload a valid file.";
                        return;
                    }

                    string folderPath = Server.MapPath("~/Submissions/");
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }
                    string fileName = Path.GetFileName(FileUploadAssignment.FileName);
                    string filePath = Path.Combine(folderPath, fileName);
                    FileUploadAssignment.SaveAs(filePath);

                    string serverPath = Path.Combine("/Submissions/", fileName);

                    string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "INSERT INTO AssignmentExamInfo (StudentName, AssignmentTitle, AssignmentDescription, AssignmentSubDate, FilePath) " +
                                       "VALUES (@StudentName, @AssignmentTitle, @AssignmentDescription, @AssignmentSubDate, @FilePath)";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@StudentName", TextBoxStudentName.Text);
                            command.Parameters.AddWithValue("@AssignmentTitle", TextBoxStudentAssignmentTitle.Text);
                            command.Parameters.AddWithValue("@AssignmentDescription", TextBoxStudentAssignmentDescription.Text);
                            command.Parameters.AddWithValue("@AssignmentSubDate", DateTime.Now);
                            command.Parameters.AddWithValue("@FilePath", serverPath);
                            connection.Open();
                            command.ExecuteNonQuery();
                        }
                    }

                    LabelStatus.Text = "Response submitted successfully!";
                    BindSubmissions(TextBoxStudentName.Text); // Display latest submissions
                }
                catch (Exception ex)
                {
                    LabelStatus.Text = "Error: " + ex.Message;
                }
            }
            else
            {
                LabelStatus.Text = "Please select a file to upload.";
            }
        }

        private void BindSubmissions(string studentName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT AssignmentTitle, AssignmentDescription, AssignmentSubDate, FilePath, " +
                               "CASE WHEN FilePath IS NOT NULL AND FilePath <> '' THEN 'Submitted' ELSE 'Not Submitted' END AS SubmissionStatus " +
                               "FROM AssignmentExamInfo WHERE StudentName = @StudentName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentName", studentName);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        GridViewSubmissions.DataSource = reader;
                        GridViewSubmissions.DataBind();
                    }
                }
            }
        }

        protected void ButtonDownload_Click(object sender, EventArgs e)
        {
            string filePath = GetFilePathForLatestSubmission(TextBoxStudentName.Text);

            string fullFilePath = Server.MapPath(filePath);

            if (!string.IsNullOrEmpty(filePath) && File.Exists(fullFilePath))
            {
                Response.Clear();
                Response.ContentType = GetContentType(fullFilePath);
                Response.AddHeader("Content-Disposition", $"attachment; filename={Path.GetFileName(fullFilePath)}");
                Response.WriteFile(fullFilePath);
                Response.Flush();
                Response.End();
            }
            else
            {
                LabelStatus.Text = "File not found or path is invalid.";
            }
        }

        private string GetFilePathForLatestSubmission(string studentName)
        {
            string filePath = string.Empty;
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT TOP 1 FilePath FROM AssignmentExamInfo WHERE StudentName = @StudentName ORDER BY AssignmentSubDate DESC";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentName", studentName);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            filePath = reader["FilePath"].ToString();
                        }
                    }
                }
            }
            return filePath;
        }

        private string GetContentType(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLower();
            switch (extension)
            {
                case ".pdf": return "application/pdf";
                case ".doc": return "application/msword";
                case ".docx": return "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                case ".ppt": return "application/vnd.ms-powerpoint";
                case ".pptx": return "application/vnd.openxmlformats-officedocument.presentationml.presentation";
                case ".jpeg":
                case ".jpg": return "image/jpeg";
                case ".png": return "image/png";
                default: return "application/octet-stream";
            }
        }

        protected void GridViewSubmissions_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int submissionID = Convert.ToInt32(GridViewSubmissions.DataKeys[e.RowIndex].Value);
            DeleteSubmission(submissionID);
            BindSubmissions(TextBoxStudentName.Text); // Rebind submissions after deletion
        }

        private void DeleteSubmission(int submissionID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM AssignmentExamInfo WHERE SubmissionID = @SubmissionID"; // Use the correct primary key
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SubmissionID", submissionID);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
