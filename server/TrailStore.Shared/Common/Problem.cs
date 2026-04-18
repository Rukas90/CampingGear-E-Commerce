namespace TrailStore.Shared.Common;

public abstract record Problem(
    string Type,
    string Title, 
    int Status, 
    string Detail);

