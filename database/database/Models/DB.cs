using System.Data.SqlClient;

namespace database.Models
{
	public class DB
	{
		public SqlConnection con { get; set; }

		public DB()
		{
			string conStr = "Data Source=DESKTOP-59CGVDH;Initial Catalog=Student;Integrated Security=True;Encrypt=False";
			con = new SqlConnection(conStr);

		}
		public void InsertUser(string username, string email, string password)
		{
			con.Open();

			SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Users (Username, Email, Pass) VALUES (@Username, @Email, @Pass)", con);
			cmd.Parameters.AddWithValue("@Username", username);
			cmd.Parameters.AddWithValue("@Email", email);
			cmd.Parameters.AddWithValue("@Pass", password); // Use @Password instead of @Passw

			cmd.ExecuteNonQuery();

			con.Close();
		}




	}
}
