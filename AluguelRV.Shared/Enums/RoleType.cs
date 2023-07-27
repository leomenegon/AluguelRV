namespace AluguelRV.Shared.Enums;
public enum RoleType
{
    Admin = 1,
    Manager = 2,
    User = 3,
}

public static class RoleTypeHelper
{
    public static string GetRole(RoleType role)
    {
        switch (role)
        {
            case RoleType.Admin:
                return "admin";
            case RoleType.Manager:
                return "manager";
            case RoleType.User:
                return "user";
            default:
                return string.Empty;
        }
    }

    public static bool ValidateManager(string role)
    {
        var admin = role != GetRole(RoleType.Admin);
        var manager = role != GetRole(RoleType.Manager);

        return admin || manager;
    }
}