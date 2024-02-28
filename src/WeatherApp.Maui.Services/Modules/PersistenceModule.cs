using Poc.Domain.Persistence;
using Poc.Maui.Services.Persistence;

namespace Poc.Maui.Services.Modules;

public class PersistenceModule : IModule
{
    public void OnInitialized(IContainerProvider containerProvider)
    {

    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterSingleton<IAppDatabase, AppDatabase>();
        containerRegistry.RegisterSingleton<INudgeRepository, NudgeRepository>();
    }
}
