namespace TrailStore.Api.Reviews.Dto;

public class ReviewDto
{
    public required string CustomerFirstName { get; init; }
    public required string CustomerLastName { get; init; }
    public required int Rating { get; init; }
    public required DateTime CreatedAt { get; init; }
    public required string Headline { get; init; }
    public required string Text { get; init; }
    public required bool Recommended { get; init; }
    public required int Likes { get; init; }
    public required int Dislikes { get; init; }
}