namespace WheelWander.Consts;

public static class Status
{
    public const string Active = "Active";
    public const string Completed = "Completed";
    public const string Maintenance = "Maintenance";
    public const string Retired = "Retired";
    public const string UnAssigned = "UnAssigned";
    public static bool IsValidStatus(string status)
    {
        return status switch
        {
            Active => true,
            Completed => true,
            Maintenance => true,
            Retired => true,
            UnAssigned => true,
            _ => false
        };
    }
    // note should be as enum not class to be easy in check
}