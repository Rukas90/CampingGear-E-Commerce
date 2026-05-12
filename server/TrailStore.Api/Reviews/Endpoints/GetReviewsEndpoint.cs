using FastEndpoints;
using TrailStore.Api.Reviews.Dto;
using TrailStore.Api.Reviews.Mapping;
using TrailStore.Domain.Reviews.Interfaces;

namespace TrailStore.Api.Reviews.Endpoints;

public class GetReviewsEndpoint(IReviewsRepository reviewsRepository)
    : Endpoint<ReviewsRequest, List<ReviewDto>>
{
    public override void Configure()
    {
        Get("/api/v1/products/{slug}/reviews");
        AllowAnonymous();
    }

    public override async Task<List<ReviewDto>> ExecuteAsync(ReviewsRequest req, CancellationToken ct)
    {
        return await reviewsRepository.ListAsync(req.ToQuery(), 
            ReviewMappingSelectors.ToDto(), ct);
    }
}