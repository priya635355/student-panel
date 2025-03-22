using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI.WebControls;

namespace Student_pannel
{
    public partial class FeesDetails : System.Web.UI.Page
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadFeeDetails();
            }
        }

       
        private void LoadFeeDetails()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM FeeDetails", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        GridViewFeeDetails.DataSource = dt;
                        GridViewFeeDetails.DataBind();
                    }
                }
            }
        }

       
        protected void ButtonInsert_Click(object sender, EventArgs e)
        {
            string status = (Convert.ToDecimal(AmountPaid.Text) >= Convert.ToDecimal(TotalFee.Text)) ? "Paid" : "Unpaid";

           
            DateTime paymentDate = DateTime.ParseExact(PaymentDate.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO FeeDetails (Username, StudentID, TotalFee, AmountPaid, PaymentDate, Status) VALUES (@Username, @StudentID, @TotalFee, @AmountPaid, @PaymentDate, @Status)", con))
                {
                    cmd.Parameters.AddWithValue("@Username", Username.Text);
                    cmd.Parameters.AddWithValue("@StudentID", StudentID.Text);
                    cmd.Parameters.AddWithValue("@TotalFee", TotalFee.Text);
                    cmd.Parameters.AddWithValue("@AmountPaid", AmountPaid.Text);
                    cmd.Parameters.AddWithValue("@PaymentDate", paymentDate);
                    cmd.Parameters.AddWithValue("@Status", status);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            LoadFeeDetails(); 
        }

      
        protected void GridViewFeeDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string studentID = GridViewFeeDetails.DataKeys[e.RowIndex].Value.ToString();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM FeeDetails WHERE StudentID=@StudentID", con))
                {
                    cmd.Parameters.AddWithValue("@StudentID", studentID);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            LoadFeeDetails(); 
        }
    }
}
