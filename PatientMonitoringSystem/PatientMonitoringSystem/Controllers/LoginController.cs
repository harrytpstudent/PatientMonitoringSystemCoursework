using System;
using PatientMonitoringSystem.Core.Database;
using PatientMonitoringSystem.Core.Models;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace PatientMonitoringSystem.Controllers
{
	public class LoginController
	{
		public void LogIn(string username, string password)
		{
			var passwordHash = SHA256.Create().ComputeHash(Encoding.Default.GetBytes(password))
				.Aggregate(new StringBuilder(), (builder, nextByte) => builder.Append(nextByte.ToString("X2"))).ToString().ToLower();

			var sqlCommand = new SqlCommand("[dbo].[GetUser]")
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@Username", username);
			sqlCommand.Parameters.AddWithValue("@PasswordHash", passwordHash);

			var dataSet = DatabaseHandler.Instance.Execute(sqlCommand);

			if (dataSet.Tables.Count == 0)
			{
				throw new ArgumentException("Username and/or password are unrecognized.");
			}

			var userRow = dataSet.Tables[0].Rows[0];
			var roleRow = dataSet.Tables[1].Rows[0];
			var permissionRows = dataSet.Tables[2].Rows.Cast<DataRow>();

			var user = new User
			{
				UserId = (long)userRow["UserId"],
				Role = new Role
				{
					RoleId = (long)roleRow["RoleId"],
					Name = (string)roleRow["Name"],
					Permissions = permissionRows.Select(permissionRow => new Permission
					{
						PermissionId = (long)permissionRow["PermissionId"],
						Name = (string)permissionRow["Name"]
					})
				},
				Name = (string)userRow["Name"]
			};

			Program.CurrentUser = user;
		}
	}
}
