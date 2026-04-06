using System.Reflection;

namespace TrailStore.Domain;

public static class DomainAssembly
{
    public static Assembly Reference => typeof(DomainAssembly).Assembly;
}