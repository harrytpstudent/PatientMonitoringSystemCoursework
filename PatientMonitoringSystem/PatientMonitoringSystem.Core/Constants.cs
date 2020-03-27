namespace PatientMonitoringSystem.Core
{
	public static class Constants
	{
		public static class PermissionNames
		{
			public const string ReceivePagerNotifications = "ReceivePagerNotifications";

			public const string ReceiveSmsNotifications = "ReceiveSmsNotifications";

			public const string ReceiveEmailNotifications = "ReceiveEmailNotifications";
		}

		public static class SqlCommands
		{
			public const string GetUser = @"
DECLARE @UserId BIGINT;

SELECT
	UserId = user.[UserId],
	user.[UserId] AS UserId,
	user.[RoleId] AS RoleId,
FROM [dbo].[Role] AS role WITH (NOLOCK)
WHERE
	Username = @Username AND
	PasswordHash = @PasswordHash;

IF UserId IS NULL
	RETURN;

DECLARE @RoleId BIGINT;

SELECT
	RoleId = role.[RoleId],
	role.[RoleId] AS Role,
	role.[Name] AS Name
FROM [dbo].[UserRole] AS userRole WITH (NOLOCK)
	ON userRole.UserId = @UserId
INNER JOIN [dbo].[Role] AS role WITH (NOLOCK)
	ON role.RoleId = userRole.RoleId
WHERE
	userRole.UserId = @UserId

SELECT
	permission.[PermissionId] AS PermissionId,
	permission.[Name] AS Name,
FROM [dbo].[RolePermission] AS rolePermission WITH (NOLOCK)
INNER JOIN [dbo].[Permission] AS permission WITH (NOLOCK)
	ON permission.PermissionId = rolePermission.PermissionId
WHERE
	rolePermission.RoleId = @RoleId
";
		}
	}
}
