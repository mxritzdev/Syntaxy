namespace Syntaxy.Interfaces;

public interface IProperty {

    public required Regex Regex {get; set; }
    
    public RegexOptions GetRegexOptions();

}