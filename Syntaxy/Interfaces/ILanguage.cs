namespace Syntaxy.Models;

public interface ILanguage
{
    public string[] GetNames();

    public List<Property> GetProperties();
}