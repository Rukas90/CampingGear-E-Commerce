using FastEndpoints;
using TrailStore.Api.Reviews.Dto;

namespace TrailStore.Api.Reviews.Endpoints;

public class GetReviewsEndpoint : Endpoint<ReviewsRequest, ReviewDto[]>
{
    public override void Configure()
    {
        Get("/api/v1/products/{slug}/reviews");
        AllowAnonymous();
    }

    public override async Task<ReviewDto[]> ExecuteAsync(ReviewsRequest req, CancellationToken ct)
    {
        return [];
    }
}