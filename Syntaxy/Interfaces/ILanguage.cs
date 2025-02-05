namespace Syntaxy.Models;

public interface ILanguage
{
    public LanguageOptions GetConfig(LanguageOptions options);

    public List<Property> GetProperties();
}