using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Student_pannel
{
    public partial class EditFeesDetails : System.Web.UI.Page
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string studentID = Request.QueryString["StudentID"];
                if (!string.IsNullOrEmpty(studentID))
                {
                    LoadFeeDetails(studentID);
                }
            }
        }

        private void LoadFeeDetails(string studentID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM FeeDetails WHERE StudentID = @StudentID", con))
                {
                    cmd.Parameters.AddWithValue("@StudentID", studentID);
                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        Username.Text = reader["Username"].ToString();
                        StudentID.Text = reader["StudentID"].ToString();
                        TotalFee.Text = reader["TotalFee"].ToString();
                        AmountPaid.Text = reader["AmountPaid"].ToString();
                        PaymentDate.Text = Convert.ToDateTime(reader["PaymentDate"]).ToString("yyyy-MM-dd");
                        Status.Text = reader["Status"].ToString();
                    }
                    con.Close();
                }
            }
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE FeeDetails SET TotalFee = @TotalFee, AmountPaid = @AmountPaid, PaymentDate = @PaymentDate, Status = @Status WHERE StudentID = @StudentID", con))
                {
                    cmd.Parameters.AddWithValue("@TotalFee", TotalFee.Text);
                    cmd.Parameters.AddWithValue("@AmountPaid", AmountPaid.Text);
                    cmd.Parameters.AddWithValue("@PaymentDate", PaymentDate.Text);
                    cmd.Parameters.AddWithValue("@Status", Status.Text);
                    cmd.Parameters.AddWithValue("@StudentID", StudentID.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            // Redirect back to the main page after update
            Response.Redirect("FeesDetails.aspx");
        }
        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            // Redirect back to FeesDetails.aspx when Cancel is clicked
            Response.Redirect("FeesDetails.aspx");
        }
    }
}
