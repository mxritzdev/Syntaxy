using System.Drawing;
using Syntaxy.Models;

namespace Syntaxy;

public class MidnightTheme : ITheme
{
    public ColorPalette GetColorPalette()
    {
        var palette = new ColorPalette();

        palette.Primary = Color.FromArgb(0, 0, 255); // Keywords
        palette.Glow = Color.FromArgb(196, 137, 10); // Strings
        palette.Tone = Color.FromArgb(9, 158, 27); // Comments
        palette.Harmony = Color.FromArgb(12, 170, 176); // Identifiers
        palette.Accent = Color.FromArgb(94, 12, 176); // Numbers
        palette.Highlight = Color.FromArgb(153, 235, 240); // Operators
        palette.Base = Color.FromArgb(240, 247, 247); // Plain Text

        return palette;
    }
}