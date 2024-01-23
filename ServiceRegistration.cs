using Microsoft.Extensions.DependencyInjection;

namespace FmgLib.Localization;

public static class ServiceRegistration
{
    public static IServiceCollection AddFmgLibLocalization(this IServiceCollection services, string defaultLang = "", params string[] filePathes)
    {
        LocalizationService.Language = defaultLang;
        LocalizationService.ReadLocalizationFile(filePathes);

        return services;
    }

    public static void SetFmgLibLocalization(string defaultLang = "", params string[] filePathes)
    {
        LocalizationService.Language = defaultLang;
        LocalizationService.ReadLocalizationFile(filePathes);
    }
}
