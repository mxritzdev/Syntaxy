using System.Text.RegularExpressions;
using Syntaxy.Models.Enums;

namespace Syntaxy.Models;

public class SimpleProperty : IProperty
{
    public TokenType Type { get; set; } = TokenType.PlainText;
    public required string Regex { get; set; }

    public RegexOptions RegexOptions() => RegexOptions.Multiline;
}