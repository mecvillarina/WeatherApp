using Poc.Maui.Domain.Services;
using Poc.Maui.Services.Web.Api;
using Poc.Maui.Services.Web.Helpers;

namespace Poc.Maui.Services.Web;

public class GeneralApiService : IGeneralApiService
{
    private readonly IAccountApi _accountApi;
    private readonly INudgeApi _nudgeApi;

    public GeneralApiService(IAccountApi accountApi, INudgeApi nudgeApi)
    {
        _accountApi = accountApi;
        _nudgeApi = nudgeApi;
    }

    public void Init(string token)
    {
        _accountApi.Client.SetAuthToken(token);
        _nudgeApi.Client.SetAuthToken(token);
    }
}
