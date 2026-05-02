using System.Reflection;

namespace TrailStore.Api;

public class ApiAssembly
{
    public static Assembly Reference => typeof(ApiAssembly).Assembly;
}