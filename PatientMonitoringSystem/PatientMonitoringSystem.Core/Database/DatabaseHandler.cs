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

		/* There is no need to use the singleton pattern here,
		 * since we are always spinning up new instances of all our dependencies,
		 * as opposed to sharing the same instances between different calls.
		 * Also, there is no need to use thread synchronization here,
		 * since this is a stateless class (ignoring the fields set during construction, which is a thread-safe operation).
		 * The only reason I could imagine employing a singleton is for caching,
		 * but dependency injection, IoC containers, and automated lifecycle management do a much better job and allow for unit testing
		 * (see Castle Windsor, and the 'D' in the SOLID principle).
		 */
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
			SqlConnection connection = new SqlConnection(connection_str); // This needs disposing.
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

