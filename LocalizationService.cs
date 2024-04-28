using Newtonsoft.Json;

namespace FmgLib.Localization;

public static class LocalizationService
{
    private static Dictionary<string, Dictionary<string, string>> _languagePacks;
    public static string Language { get; set; }

    public static void ReadLocalizationFile(params string[] filePathes)
    {
        _languagePacks = new Dictionary<string, Dictionary<string, string>>();

        try
        {
            // Todo : new features will be added.
            List<string> pathesList = filePathes.ToList();

            if (pathesList.Count == 0)
                pathesList.Add("Localization.json");

            foreach (var filePath in pathesList)
            {
                var json = File.ReadAllText(filePath);
                var pack = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(json);

                foreach (var lang in pack)
                {
                    if (!_languagePacks.ContainsKey(lang.Key))
                    {
                        _languagePacks[lang.Key] = new Dictionary<string, string>();
                    }
                    if (lang.Value != null)
                    {
                        foreach (var kvp in lang.Value)
                        {
                            _languagePacks[lang.Key][kvp.Key] = kvp.Value;
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw new FileLoadException($"There is an error in your language file.\n{ex.Message} \n\n\n\n The proper json format is:\n \"{{\\n  \\\"wordKey\\\": {{\\n    \\\"langKey1\\\": \\\"1st language translation.\\\",\\n    \\\"langKey2\\\": \\\"2nd language translation.\\\"\\n  }},\\n  \\\"wordKey2\\\": {{\\n    \\\"langKey1\\\": \\\"1st language translation.\\\",\\n    \\\"langKey2\\\": \\\"2nd language translation.\\\"\\n  }}\\n}}\"");
        }
        
    }

    public static string Translate(string key)
    {
        if (string.IsNullOrEmpty(Language))
            Language = Thread.CurrentThread.CurrentUICulture.Name;

        var lang = _languagePacks.FirstOrDefault(x => x.Key == key).Value?.FirstOrDefault(y => y.Key == Language);
        var resultKey = lang?.Key;
        var resultValue = lang?.Value;
        if (resultKey == Language)
        {
            return resultValue ?? key;
        }

        if (_languagePacks.ContainsKey("en") && _languagePacks["en"].ContainsKey(key))
        {
            return _languagePacks["en"][key];
        }

        return key;
    }

    public static string Translate(string key, string langKey)
    {
        var lang = _languagePacks.FirstOrDefault(x => x.Key == key).Value?.FirstOrDefault(y => y.Key == langKey);
        var resultKey = lang?.Key;
        var resultValue = lang?.Value;
        if (resultKey == langKey)
        {
            return resultValue ?? key;
        }

        return key;
    }
}
