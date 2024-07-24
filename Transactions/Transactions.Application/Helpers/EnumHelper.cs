namespace Transactions.Application.Helpers;

using Enum = System.Enum;
public static class EnumHelper
{
    public static T ParseEnum<T>(string value)
    {
        return (T) Enum.Parse(typeof(T), value, true);
    }
}
