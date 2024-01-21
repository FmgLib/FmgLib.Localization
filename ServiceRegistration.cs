using Microsoft.Extensions.DependencyInjection;

namespace FmgLib.Localization;

public static class ServiceRegistration
{
    public static IServiceCollection AddFmgLibLocalization(this IServiceCollection services, params string[] filePathes)
    {
        LocalizationService.ReadLocalizationFile(filePathes);

        return services;
    }

    public static void SetFmgLibLocalization(params string[] filePathes)
    {
        LocalizationService.ReadLocalizationFile(filePathes);
    }
}
