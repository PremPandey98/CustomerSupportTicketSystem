using System.Drawing;

namespace CustomerSupportTicketSystem.Desktop.UI;

/// <summary>
/// Modern color scheme for the application
/// </summary>
public static class ModernColors
{
    // Primary Colors
    public static readonly Color Primary = Color.FromArgb(79, 70, 229);        // Indigo-600
    public static readonly Color PrimaryHover = Color.FromArgb(67, 56, 202);   // Indigo-700
    public static readonly Color PrimaryLight = Color.FromArgb(129, 140, 248); // Indigo-400
    
    // Secondary Colors
    public static readonly Color Secondary = Color.FromArgb(100, 116, 139);    // Slate-500
    public static readonly Color SecondaryHover = Color.FromArgb(71, 85, 105); // Slate-600
    
    // Background Colors
    public static readonly Color BackgroundLight = Color.FromArgb(248, 250, 252); // Slate-50
    public static readonly Color CardBackground = Color.White;
    public static readonly Color DarkBackground = Color.FromArgb(30, 41, 59);     // Slate-800
    
    // Border & Divider
    public static readonly Color Border = Color.FromArgb(226, 232, 240);       // Slate-200
    public static readonly Color BorderDark = Color.FromArgb(203, 213, 225);   // Slate-300
    
    // Text Colors
    public static readonly Color TextPrimary = Color.FromArgb(30, 41, 59);     // Slate-800
    public static readonly Color TextSecondary = Color.FromArgb(100, 116, 139); // Slate-500
    public static readonly Color TextMuted = Color.FromArgb(148, 163, 184);    // Slate-400
    public static readonly Color TextLight = Color.White;
    
    // Status Colors
    public static readonly Color Success = Color.FromArgb(16, 185, 129);       // Green-500
    public static readonly Color SuccessLight = Color.FromArgb(209, 250, 229); // Green-100
    public static readonly Color Warning = Color.FromArgb(245, 158, 11);       // Amber-500
    public static readonly Color WarningLight = Color.FromArgb(254, 243, 199); // Amber-100
    public static readonly Color Error = Color.FromArgb(239, 68, 68);          // Red-500
    public static readonly Color ErrorLight = Color.FromArgb(254, 226, 226);   // Red-100
    public static readonly Color Info = Color.FromArgb(59, 130, 246);          // Blue-500
    public static readonly Color InfoLight = Color.FromArgb(219, 234, 254);    // Blue-100
    
    // Chart/Graph Colors
    public static readonly Color[] ChartColors = new[]
    {
        Color.FromArgb(79, 70, 229),   // Indigo
        Color.FromArgb(16, 185, 129),  // Green
        Color.FromArgb(245, 158, 11),  // Amber
        Color.FromArgb(239, 68, 68),   // Red
        Color.FromArgb(59, 130, 246),  // Blue
        Color.FromArgb(139, 92, 246)   // Purple
    };
}

/// <summary>
/// Modern font styles for the application
/// </summary>
public static class ModernFonts
{
    private const string FontFamily = "Segoe UI";
    
    // Headings
    public static readonly Font H1 = new Font(FontFamily, 24f, FontStyle.Bold);
    public static readonly Font H2 = new Font(FontFamily, 20f, FontStyle.Bold);
    public static readonly Font H3 = new Font(FontFamily, 16f, FontStyle.Bold);
    public static readonly Font H4 = new Font(FontFamily, 14f, FontStyle.Bold);
    public static readonly Font H5 = new Font(FontFamily, 12f, FontStyle.Bold);
    
    // Body Text
    public static readonly Font Body = new Font(FontFamily, 9f, FontStyle.Regular);
    public static readonly Font BodyLarge = new Font(FontFamily, 10f, FontStyle.Regular);
    public static readonly Font BodyBold = new Font(FontFamily, 9f, FontStyle.Bold);
    
    // Small Text
    public static readonly Font Small = new Font(FontFamily, 8f, FontStyle.Regular);
    public static readonly Font SmallBold = new Font(FontFamily, 8f, FontStyle.Bold);
    
    // Special
    public static readonly Font Caption = new Font(FontFamily, 7f, FontStyle.Regular);
    public static readonly Font Button = new Font(FontFamily, 9f, FontStyle.Bold);
}

/// <summary>
/// Modern spacing constants
/// </summary>
public static class ModernSpacing
{
    public const int ExtraSmall = 4;
    public const int Small = 8;
    public const int Medium = 12;
    public const int Large = 16;
    public const int ExtraLarge = 20;
    public const int XXLarge = 24;
    public const int XXXLarge = 32;
    
    // Specific use cases
    public const int FormPadding = 20;
    public const int ControlSpacing = 15;
    public const int SectionSpacing = 25;
    public const int CardPadding = 20;
}

/// <summary>
/// Modern border radius constants
/// </summary>
public static class ModernBorders
{
    public const int Small = 4;
    public const int Medium = 6;
    public const int Large = 8;
    public const int ExtraLarge = 12;
    public const int Round = 999; // For circular elements
}
