using System;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace PatientMonitoringSystem.Core.Database
{
	public class DatabaseHandler
	{

		private static DatabaseHandler db_instance = null;
		private static readonly object _lock = new object();
		private static String connection_str;
		private DatabaseHandler()
		{
			var mdfFileLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Database\PatientMonitoringSystemDatabase.mdf");
			connection_str = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={mdfFileLocation};Integrated Security=True";
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

		public DataSet Execute(SqlCommand sqlCommand)
		{
			var dataSet = new DataSet();

			using (var connection = new SqlConnection(connection_str))
			{
				sqlCommand.Connection = connection;

				using (var adapter = new SqlDataAdapter(sqlCommand))
				{
					adapter.Fill(dataSet);
				}
			}

			return dataSet;
		}
	}
}

