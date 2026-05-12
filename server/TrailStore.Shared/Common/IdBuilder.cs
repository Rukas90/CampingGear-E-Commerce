using System.Security.Cryptography;
using System.Text;

namespace TrailStore.Shared.Common;

public class IdBuilder<TType>
{
    private readonly StringBuilder builder
        = new(typeof(TType).Name);

    public IdBuilder<TType> With<T>()
    {
        Append(typeof(T).Name);
        return this;
    }

    public IdBuilder<TType> Parts(params string[] parts)
    {
        foreach (var part in parts) Append(part);
        return this;
    }

    public IdBuilder<TType> Part(string value)
    {
        Append(value);
        return this;
    }

    public IdBuilder<TType> Part<T>(Id<T> other)
    {
        Append(other.Value.ToString());
        return this;
    }

    private void Append(string value)
    {
        builder.Append('_');
        builder.Append(value);
    }

    public Id<TType> Build()
    {
        var hash = SHA256.HashData(Encoding.UTF8.GetBytes(builder.ToString()));
        return new Id<TType>(new Guid(hash[..16]));
    }
}