using TrailStore.Catalog.Contracts.Skus;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Wishlist.Application.Commands;

public sealed record RemoveFromWishlistCommand(Id<UserRef> UserId, Id<SkuRef> SkuId) : ICommand;