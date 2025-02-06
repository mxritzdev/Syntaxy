using System.Text.RegularExpressions;
using Syntaxy.Interfaces;
using Syntaxy.Models.Parsing;

namespace Syntaxy.Models;

public class AdvancedProperty : IProperty 
{
    public required string Regex { get; set; }

    public required Func<Match, Token[]> ProcessMatch { get; set; }

    public RegexOptions GetRegexOptions() => RegexOptions.Multiline;
}