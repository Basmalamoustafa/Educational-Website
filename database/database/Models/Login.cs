using System;
using System.Data.SqlClient;

namespace database.Models
{
	public class Login
	{
		public SqlConnection con { get; set; }

		public Login()
		{
			string conStr = "Data Source=DESKTOP-59CGVDH;Initial Catalog=Student;Integrated Security=True;Encrypt=False";
			con = new SqlConnection(conStr);
		}

		public bool CheckLogin(string username, string password)
		{
			try
			{
				con.Open();
				SqlCommand command = new SqlCommand("SELECT * FROM Users WHERE Username=@Username AND Pass=@Pass", con);
				command.Parameters.AddWithValue("@Username", username);
				command.Parameters.AddWithValue("@Pass", password);

				// Log the SQL command being executed
				Console.WriteLine("SQL Command: " + command.CommandText);

				SqlDataReader reader = command.ExecuteReader();

				if (reader.HasRows)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			catch (Exception ex)
			{
				// Handle the exception (log or throw, depending on your needs)
				Console.WriteLine("Exception: " + ex.Message);
				return false;
			}
			finally
			{
				con.Close();
			}
		}
	}
}
