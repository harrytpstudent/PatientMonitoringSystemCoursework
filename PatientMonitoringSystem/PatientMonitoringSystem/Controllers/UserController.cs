using System.Collections.Generic;
using PatientMonitoringSystem.Core.Models;

namespace PatientMonitoringSystem.Controllers
{
	public class UserController
	{
		public User GetCurrentUser()
		{
			return Program.CurrentUser;
		}

		public IEnumerable<Subscription> GetCurrentUserSubscriptions()
		{
			if (Program.CurrentUserSubscriptions != null)
			{
				return Program.CurrentUserSubscriptions;
			}

			// TODO: Call stored procedure (SELECT statement), map records to model classes, set Program.CurrentUserSubscriptions, and return.
		}

		public void SaveCurrentUserSubscriptions(IEnumerable<Subscription> subscriptions)
		{
			// TODO: Call stored procedure (MERGE statement with user-defined type (UDT) table-valued parameter (TVP)).
			// Because all SubscriptionIds will be 0, do not join by primary key, but by the alternate key (UserId + NotificationTypeId).
			// A MERGE statement allows you to do INSERTs, UPDATEs and DELETEs in a single atomic operation in the database.
			// You could generate a delta in the application logic, but using the DBMS ensures greater performance and integrity.

			Program.CurrentUserSubscriptions = subscriptions;
		}

		public void LogOut()
		{
			Program.CurrentUser = null;

			Program.CurrentUserSubscriptions = null;
		}
	}
}
