using Poc.Models;
using Poc.Models.Contracts;
using Poc.Models.Contracts.Requests;
using Refit;

namespace Poc.Maui.Services.Web.Api
{
    public interface INudgeApi
    {
        HttpClient Client { get; }

        [Post("/api/nudge/send")]
        Task<Result> SendAsync([Body(true)] NudgeSendRequestContract contract);

        [Get("/api/nudge/getAll")]
        Task<Result<List<NudgeContract>>> GetAllAsync();

    }
}
