using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace PatientMonitoringSystem.Core.Database
{
	public class DatabaseHandler
	{

		private static DatabaseHandler db_instance = null;
		private static readonly object _lock = new object();
		private static String connection_str;
		private DatabaseHandler()
		{
			connection_str = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Database\PatientMonitoringSystemDatabase.mdf;Integrated Security=True";
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

		public void ExecuteStatement(String cmdText, SqlParameter[] parameters)
		{
			using (SqlConnection conn = new SqlConnection(connection_str))
			{
				using (SqlCommand cmd = new SqlCommand(cmdText, conn)) {
					cmd.Parameters.AddRange(parameters);
					conn.Open();
					cmd.ExecuteNonQuery();
				}
				conn.Close();
			}
		}

		public SqlDataReader ExecuteQuery(String commandText, CommandType type, params SqlParameter[] parameters)
		{
			SqlConnection connection = new SqlConnection(connection_str);
			using (SqlCommand command = new SqlCommand(commandText, connection))
			{

				command.CommandType = type;
				command.Parameters.AddRange(parameters);

				connection.Open();

				SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
				return reader;
			}
		}
	}
}

