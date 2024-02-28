using Refit;
using Poc.Models;
using Poc.Models.Contracts;
using Poc.Models.Contracts.Requests;

namespace Poc.Maui.Services.Web.Api;

public interface IAccountApi
{
    HttpClient Client { get; }

    [Get("/api/account/profile")]
    Task<Result<UserProfileContract>> GetUserProfileAsync();

    [Post("/api/account/profile")]
    Task<Result<UserProfileContract>> UpdateProfileAsync([Body(true)] UpdateProfileRequestContract contract);
}
