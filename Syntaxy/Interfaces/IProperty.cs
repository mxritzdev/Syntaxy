using System.Text.RegularExpressions;

namespace Syntaxy.Interfaces;

public interface IProperty {


    public string Regex { get; set; }
    
    public RegexOptions GetRegexOptions();

}