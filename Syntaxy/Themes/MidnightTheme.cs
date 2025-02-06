using System.Drawing;
using Syntaxy.Models;
using Syntaxy.Models.Enums;
using Syntaxy.Models.Parsing.Style;

namespace Syntaxy;

public class MidnightTheme : ITheme
{
    public ColorPalette ColorPalette { get; set; }

    public void ConfigureColorPalette()
    {
        ColorPalette = new ColorPalette
        {
            Base00 = new TokenStyle { Color = Color.FromArgb(0, 43, 54) },
            Base01 = new TokenStyle { Color = Color.FromArgb(7, 54, 66) },
            Base02 = new TokenStyle { Color = Color.FromArgb(88, 110, 117) },
            Base03 = new TokenStyle { Color = Color.FromArgb(101, 123, 131) },
            Base04 = new TokenStyle { Color = Color.FromArgb(131, 148, 150) },
            Base05 = new TokenStyle { Color = Color.FromArgb(147, 161, 161) },
            Base06 = new TokenStyle { Color = Color.FromArgb(238, 232, 213) },
            Base07 = new TokenStyle { Color = Color.FromArgb(253, 246, 227) },
            Yellow = new TokenStyle { Color = Color.FromArgb(181, 137, 0) },
            Orange = new TokenStyle { Color = Color.FromArgb(203, 75, 22) },
            Red = new TokenStyle { Color = Color.FromArgb(220, 50, 47) },
            Magenta = new TokenStyle { Color = Color.FromArgb(211, 54, 130) },
            Violet = new TokenStyle { Color = Color.FromArgb(108, 113, 196) },
            Blue = new TokenStyle { Color = Color.FromArgb(38, 139, 210) },
            Cyan = new TokenStyle { Color = Color.FromArgb(42, 161, 152) },
            Green = new TokenStyle { Color = Color.FromArgb(133, 153, 0) }
        };
    }

    public TokenStyle? GetAssociatedStyle(ColorPalette palette, TokenType type)
    {
        
        var tokenColors = new Dictionary<TokenType, TokenStyle?>
        {
            { TokenType.Keyword, ColorPalette.Yellow },
            { TokenType.Datatype, ColorPalette.Blue },
            { TokenType.String, ColorPalette.Green },
            { TokenType.Comment, ColorPalette.Base03 },
            { TokenType.Identifier, ColorPalette.Base05 },
            { TokenType.Number, ColorPalette.Red },
            { TokenType.Operator, ColorPalette.Orange },
            { TokenType.Whitespace, ColorPalette.Base00 },
            { TokenType.Annotation, ColorPalette.Magenta },
            { TokenType.PlainText, ColorPalette.Base07 },
        };

        return tokenColors.TryGetValue(type, out TokenStyle? color) ? color : ColorPalette.Base07;

    }
}