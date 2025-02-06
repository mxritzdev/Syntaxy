using Syntaxy.Models.Enums;
using Syntaxy.Models.Parsing.Style;

namespace Syntaxy.Models;

public interface ITheme
{
    public ColorPalette ColorPalette { get; set; }
    
    public void ConfigureColorPalette();

    public Func<ColorPalette, TokenStyle> GetAssociatedStyle(TokenType type);

}