using Mapster;
using MapsterMapper;
using Poc.Domain.Logging;
using Poc.Domain.Mappers;
using Poc.Maui.Domain.Services;
using Poc.Maui.Services.Logging;
using Poc.Maui.Services.Web;

namespace Poc.Maui.Services.Modules;

public class ServicesModule : IModule
{
    public void OnInitialized(IContainerProvider containerProvider)
    {

    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterSingleton<IDebugLogger, DebugLogger>();
        containerRegistry.RegisterSingleton<IAppCenterLogger, AppCenterLogger>();
        containerRegistry.RegisterSingleton<ILogger, Logging.Logger>();
        containerRegistry.RegisterInstance(TypeAdapterConfig.GlobalSettings);
        containerRegistry.RegisterScoped<IMapper, ServiceMapper>();
        containerRegistry.RegisterSingleton<IServiceMapper, JTI.Tera.Maui.Services.Mappers.ServiceMapper>();
        //containerRegistry.RegisterSingleton<IPopupService, PopupService>();

        containerRegistry.RegisterSingleton<IAppDialogService, AppDialogService>();

        containerRegistry.RegisterSingleton<IGeneralApiService, GeneralApiService>();
        containerRegistry.RegisterSingleton<IAuthService, AuthService>();
        containerRegistry.RegisterSingleton<IAccountService, AccountService>();
        containerRegistry.RegisterSingleton<INudgeService, NudgeService>();

        //containerRegistry.RegisterSingleton<ISyncService, SyncService>();


        //containerRegistry.RegisterSingleton<IDateTimeService, DateTimeService>();
        //containerRegistry.RegisterSingleton<IFileService, FileService>();

        //containerRegistry.RegisterSingleton<IAppDataService, AppDataService>();
        //containerRegistry.RegisterSingleton<IConfigService, ConfigService>();

        //containerRegistry.RegisterSingleton<IStationService, StationService>();

        //containerRegistry.RegisterSingleton<IFeedbackService, FeedbackService>();
    }
}