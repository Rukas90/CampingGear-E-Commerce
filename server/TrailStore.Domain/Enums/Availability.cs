namespace TrailStore.Domain.Enums;

[Flags]
public enum Availability
{
    OutOfStock = 1 << 0,
    InStock = 1 << 1,
    All = OutOfStock | InStock
}