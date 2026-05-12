using System.Reflection;

namespace TrailStore.Shared.Utils;

public class ReflectionUtils
{
    public static IEnumerable<Type> GetGenericInterfaceArguments(Assembly assembly, Type openGenericInterface)
    {
        return assembly.GetTypes()
            .SelectMany(t => t.GetInterfaces()
                .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == openGenericInterface)
                .Select(i => i.GetGenericArguments()[0]));
    }

    public static MethodInfo GetPrivateMethod(Type type, string name)
    {
        return type.GetMethod(name, BindingFlags.NonPublic | BindingFlags.Static)!;
    }

    public static void InvokeGeneric(MethodInfo method, Type type, params object[] args)
    {
        method.MakeGenericMethod(type).Invoke(null, args);
    }
}