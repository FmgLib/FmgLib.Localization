To access related services, simply add `using FmgLib.Localization;` statement.


In the Program.cs file,
```CSharp
builder.Services.AddFmgLibLocalization();
```
should be added.


In your main project you should have a language file of type json. The translation will be read from this file and imported.
If you do not specify the path to the file(s) in the parameter ( 
```CSharp
builder.Services.AddFmgLibLocalization();
```
), will look for a json file named `Localization.json` in the home directory.

if you give one or more parameters like 
```CSharp
builder.Services.AddFmgLibLocalization("Localization1.json", "Localization2.json", "/Languages/Temp1.json");
```
it will read json files in given file paths.



Proper json format:

```json
{
  "Hello": {
    "tr-TR": "Merhaba Dünya!",
    "en-US": "Hello World!"
  },
  "Msg": {
    "tr-TR": "Deneme amaçlı yapılmıştır.",
    "en-US": "It was made for testing purposes."
  }
}
```

Instead of 'keyWord' keywords, you can use any word or phrase(s) you want. You don't have any Regex limitations.

You can also change the 'tr-TR' and 'en-US' language keys with words or sentences as you wish. But it is recommended to use expressions such as 'en-US', 'tr-TR', 'fr-FR'.


You can simply use 
```CSharp
Console.WriteLine("keyWord 1".ToTranslate());
``` 
in the code.

If you do not specify a parameter, it will translate according to the language expression registered in Culture (language keys such as 'en-US', 'tr-TR' will appear).

You can easily obtain the translation by specifying the language key as 
```CSharp
Console.WriteLine("keyWord 1".ToTranslate("tr-TR"));
```
.
