namespace FmgLib.Localization;

public static class ToTranslateHelper
{
    public static string ToTranslate(this string key)
    {
        return LocalizationService.Translate(key);
    }
    public static string ToTranslate(this string key, string langKey)
    {
        return LocalizationService.Translate(key, langKey);
    }
}
