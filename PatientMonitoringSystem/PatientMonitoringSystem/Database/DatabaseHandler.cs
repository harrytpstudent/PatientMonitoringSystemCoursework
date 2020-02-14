using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace PatientMonitoringSystem.Database
{
	public class DatabaseHandler
	{

		private static DatabaseHandler db_instance = null;
		private static SqlConnection connection;
		private static readonly object _lock = new object();
		private static String connection_str;
		private DatabaseHandler()
		{
			string connection_str = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database\Database1.mdf;Integrated Security=True";
			connection = new SqlConnection(connection_str);
		}

		public static DatabaseHandler Instance
		{
			get
			{
				lock (_lock)
				{
					if (db_instance == null)
					{
						db_instance = new DatabaseHandler();
					}
				}

				return db_instance;
			}
		}

		public static void ExecuteStatement(SqlCommand command)
		{
			using (SqlConnection conn = new SqlConnection(connection_str))
			{
				conn.Open();
				command.ExecuteNonQuery();
			}
		}

		public static SqlDataReader ExecuteQuery(String commandText, CommandType type, params SqlParameter[] parameters)
		{
			SqlConnection connection = new SqlConnection(connection_str);
			using (SqlCommand command = new SqlCommand(commandText, connection)) {

				command.CommandType = type;
				command.Parameters.AddRange(parameters);

				connection.Open();

				SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
				return reader;
			}
		}
	}
}
