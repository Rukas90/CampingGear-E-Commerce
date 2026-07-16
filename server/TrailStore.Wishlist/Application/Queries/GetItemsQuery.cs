using TrailStore.Identity.Contracts.Users;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;
using TrailStore.Wishlist.Application.Results;

namespace TrailStore.Wishlist.Application.Queries;

public sealed record GetItemsQuery(Id<UserRef> UserId) : IQuery<WishlistItemResult[]>;