using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Student_pannel
{
    public partial class StudentDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadStudentDetails();
            }
        }

        private void LoadStudentDetails()
        {
            String Username = "Priya@1";
           string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = " SELECT Name, RollNumber, Course, Username,  ParentsName, ParentsContact, Email, Gender, Address from Student WHERE Username = @Username";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", Username);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtName.Text = reader["Name"].ToString();
                            txtCourse.Text = reader["Course"].ToString();
                            txtRollNumber.Text = reader["RollNumber"].ToString();
                            txtUsername.Text = reader["Username"].ToString();
                           
                            txtEmail.Text = reader["Email"].ToString();
                            txtGender.Text = reader["Gender"].ToString();
                            txtAddress.Text = reader["Address"].ToString();
                            txtParentsName.Text = reader["ParentsName"].ToString();
                            txtParentsContact.Text = reader["ParentsContact"].ToString();
                        }
                    }
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Student SET Name = @Name, Course = @Course, RollNumber = @RollNumber, Username = @Username,  Email = @Email, Gender = @Gender, Address = @Address, ParentsName = @ParentsName, ParentsContact = @ParentsContact WHERE Username = @Username";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", txtName.Text);
                    cmd.Parameters.AddWithValue("@Course", txtCourse.Text);
                    cmd.Parameters.AddWithValue("@RollNumber", txtRollNumber.Text);
                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                    
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Gender", txtGender.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@ParentsName", txtParentsName.Text);
                    cmd.Parameters.AddWithValue("@ParentsContact", txtParentsContact.Text);
                    

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        // Display success message (you can use a Label or other control)
                    }
                    else
                    {
                        // Display error message
                    }
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            // Redirect to another page or perform another action
            Response.Redirect("StudentDetails.aspx");
        }
    }
}
