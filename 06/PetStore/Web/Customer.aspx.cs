using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Web
{
    public partial class Customer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string Constring = ConfigurationManager.ConnectionStrings["PetDbConnectionString"].ConnectionString;
                Customer_Registration(Constring);
                Customer_Login(Constring);
            }

        }

        protected void Customer_Registration(string conString)
        {
            string Namee = TextBox1.Text;
            string Email = TextBox2.Text;
            string Zipcode = TextBox3.Text;
            string query = "CustomerRegistration";
            using (SqlConnection cons = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cons))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter parameter;
                    parameter = cmd.Parameters.Add("Namee", SqlDbType.VarChar);
                    parameter.Value = Namee;
                    parameter = cmd.Parameters.Add("@Email", SqlDbType.VarChar);
                    parameter.Value = Email;
                    parameter = cmd.Parameters.Add("@Zipcode", SqlDbType.VarChar);
                    parameter.Value = Zipcode;
                    cmd.Connection = cons;
                    cons.Open();
                    cmd.ExecuteNonQuery();
                    cons.Close();
                }
            }
        }
        protected void Customer_Login(string conString)
        {
            string Namee = TextBox1.Text;
            string Email = TextBox2.Text;
            string Zipcode = TextBox3.Text;
            string userName = TextBox4.Text;
            string Password = TextBox5.Text;
            string CustomerId = "";

            DataSet ds = new DataSet();
            string query = "CustomerLogin";
            string query1 = $"select * from Customer where Name={Namee}";
            SqlDataAdapter da = new SqlDataAdapter(query1, conString);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            da.Fill(ds, "Customer");
            var data = ds.Tables["Customer"].Rows;
            foreach (DataRow row in data)
            {
                if (row[Namee].ToString() == Namee && row[Zipcode].ToString() == Zipcode)
                {
                    CustomerId = row["id"].ToString();
                }
            }
            using (SqlConnection cons = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cons))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter parameter;
                    parameter = cmd.Parameters.Add("CustomerId", SqlDbType.Int);
                    parameter.Value = Namee;
                    parameter = cmd.Parameters.Add("@UserName", SqlDbType.VarChar);
                    parameter.Value = Email;
                    parameter = cmd.Parameters.Add("@Password", SqlDbType.VarChar);
                    parameter.Value = Zipcode;
                    cmd.Connection = cons;
                    cons.Open();
                    cmd.ExecuteNonQuery();
                    cons.Close();
                }
            }
        }

    }
}