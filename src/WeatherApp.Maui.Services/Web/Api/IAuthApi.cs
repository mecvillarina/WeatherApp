using Poc.Models;
using Poc.Models.Contracts;
using Poc.Models.Contracts.Requests;
using Refit;

namespace Poc.Maui.Services.Web.Api;

public interface IAuthApi
{
    HttpClient Client { get; }

    [Post("/api/auth/login")]
    Task<Result<AuthTokenHandlerContract>> LoginAsync([Body(true)] AuthLoginRequestContract contract);

    [Post("/api/auth/register")]
    Task<Result> RegisterAsync([Body(true)] AuthRegisterRequestContract contract);
}
