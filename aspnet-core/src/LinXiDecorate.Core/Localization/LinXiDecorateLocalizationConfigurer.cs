using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace LinXiDecorate.Localization
{
    public static class LinXiDecorateLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(LinXiDecorateConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(LinXiDecorateLocalizationConfigurer).GetAssembly(),
                        "LinXiDecorate.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
