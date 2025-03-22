using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace Student_pannel
{
    public partial class LoginPage : Page
    {
       

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

            string query = "SELECT COUNT(*) FROM Student WHERE username = @username AND Password = @password";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        conn.Open();
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count == 1)
                        {
                            string queryDetails = "SELECT Name, RollNumber, Course FROM Student WHERE username = @username";
                            using (SqlCommand cmdDetails = new SqlCommand(queryDetails, conn))
                            {
                                cmdDetails.Parameters.AddWithValue("@username", username);
                                SqlDataReader reader = cmdDetails.ExecuteReader();
                                if (reader.Read())
                                {
                                    Session["Username"] = username;
                                    Session["Name"] = reader["Name"].ToString();
                                    Session["RollNumber"] = reader["RollNumber"].ToString();
                                    Session["Course"] = reader["Course"].ToString();
                                }
                            }

                            Response.Redirect("HomePage.aspx");
                        }
                        else
                        {
                            Response.Write("<script>alert('Invalid username or password. Please try again.');</script>");
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                Response.Write("<script>alert('Database error: " + sqlEx.Message + "');</script>");
            }
        }

    }
}
