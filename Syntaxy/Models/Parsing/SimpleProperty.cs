using System.Text.RegularExpressions;
using Syntaxy.Interfaces;
using Syntaxy.Models.Enums;
using Syntaxy.Models.Parsing.Style;

namespace Syntaxy.Models;

public class SimpleProperty : IProperty
{
    public TokenType Type { get; set; } = TokenType.PlainText;
    public required string Regex { get; set; }

    public RegexOptions GetRegexOptions() => RegexOptions.Multiline;
    
    public Func<ColorPalette, TokenStyle> GetStyle { get; set; }
}