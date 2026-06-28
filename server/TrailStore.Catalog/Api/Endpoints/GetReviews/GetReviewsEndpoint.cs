using FastEndpoints;
using TrailStore.Catalog.Application.Queries.GetReviews;
using TrailStore.Catalog.Domain.Reviews.Enums;
using TrailStore.Shared.Api.Mappers;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Catalog.Api.Endpoints.GetReviews;

public class GetReviewsEndpoint(GetReviewsQueryHandler query) 
    : Endpoint<GetReviewsRequest, ReviewResponse[]>
{
    public override void Configure()
    {
        Get("/api/v1/products/{slug}/reviews");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetReviewsRequest req, CancellationToken ct)
    {
        var result = await query.Handle(new GetReviewsQuery(
            Slug.Create(req.Slug),
            req.StarFilter ?? StarFilter.AllStars,
            req.SortBy ?? ReviewsSortBy.MostHelpful,
            req.Page.HasValue,
            req.Page ?? 0,
            req.PageSize ?? 15), ct);

        if (!result.IsSuccess)
        {
            await this.SendProblemAsync(result.Problem);

            return;
        }

        var reviews = result.Value;

        await Send.OkAsync(reviews.ToResponses(), ct);
    }
}