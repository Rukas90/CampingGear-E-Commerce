using System.Reflection;

namespace TrailStore.Infrastructure;

public class InfrastructureAssembly
{
    public static Assembly Reference => typeof(InfrastructureAssembly).Assembly;
}