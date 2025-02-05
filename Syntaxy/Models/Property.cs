using System.Text.RegularExpressions;
using Syntaxy.Models.Enums;

namespace Syntaxy.Models;

public class Property
{
    public TokenType Type { get; set; } = TokenType.PlainText;
    public required string Regex { get; set; }

    public RegexOptions RegexOptions { get; set; } = RegexOptions.Multiline;
}