using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace Student_pannel
{
    public partial class EditAssignment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["SubmissionID"] != null)
                {
                    int submissionId = Convert.ToInt32(Request.QueryString["SubmissionID"]);
                    BindAssignmentDetails(submissionId);
                }
                else
                {
                    LabelStatus.Text = "No Submission ID provided.";
                }
            }
        }

        private void BindAssignmentDetails(int submissionId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT AssignmentTitle, AssignmentDescription FROM AssignmentExamInfo WHERE SubmissionID = @SubmissionID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SubmissionID", submissionId);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            TextBoxAssignmentTitle.Text = reader["AssignmentTitle"].ToString();
                            TextBoxAssignmentDescription.Text = reader["AssignmentDescription"].ToString();
                        }
                        else
                        {
                            LabelStatus.Text = "No assignment details found for this ID.";
                        }
                    }
                }
            }
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["SubmissionID"] != null)
            {
                int submissionId = Convert.ToInt32(Request.QueryString["SubmissionID"]);
                UpdateAssignmentDetails(submissionId);
            }
            else
            {
                LabelStatus.Text = "No Submission ID provided.";
            }
        }

        private void UpdateAssignmentDetails(int submissionId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE AssignmentExamInfo SET AssignmentTitle = @AssignmentTitle, AssignmentDescription = @AssignmentDescription WHERE SubmissionID = @SubmissionID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AssignmentTitle", TextBoxAssignmentTitle.Text);
                    command.Parameters.AddWithValue("@AssignmentDescription", TextBoxAssignmentDescription.Text);
                    command.Parameters.AddWithValue("@SubmissionID", submissionId);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        LabelStatus.Text = "Assignment updated successfully!";
                    }
                    else
                    {
                        LabelStatus.Text = "Error updating assignment.";
                    }
                }
            }
        }
    }
}
