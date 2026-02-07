using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CustomerSupportTicketSystem.Desktop.UI;

/// <summary>
/// Modern text box with clean styling and focus effects
/// </summary>
public class ModernTextBox : TextBox
{
    private Color _borderColor = ModernColors.Border;
    private Color _focusBorderColor = ModernColors.Primary;
    private int _borderRadius = ModernBorders.Small;
    private bool _isFocused = false;
    private Panel _borderPanel;

    public ModernTextBox()
    {
        BorderStyle = BorderStyle.FixedSingle;
        Font = ModernFonts.Body;
        BackColor = ModernColors.CardBackground;
        ForeColor = ModernColors.TextPrimary;
        
        // Removed SetStyle(ControlStyles.UserPaint, true) as it prevents text rendering on standard TextBox
    }

    public Color BorderColor
    {
        get => _borderColor;
        set { _borderColor = value; Invalidate(); }
    }

    public Color FocusBorderColor
    {
        get => _focusBorderColor;
        set { _focusBorderColor = value; Invalidate(); }
    }

    public int BorderRadius
    {
        get => _borderRadius;
        set { _borderRadius = value; Invalidate(); }
    }

    protected override void OnGotFocus(EventArgs e)
    {
        base.OnGotFocus(e);
        _isFocused = true;
        Parent?.Invalidate(new Rectangle(Location.X - 2, Location.Y - 2, Width + 4, Height + 4), true);
    }

    protected override void OnLostFocus(EventArgs e)
    {
        base.OnLostFocus(e);
        _isFocused = false;
        Parent?.Invalidate(new Rectangle(Location.X - 2, Location.Y - 2, Width + 4, Height + 4), true);
    }
}

/// <summary>
/// Modern panel with shadow effect and rounded corners
/// </summary>
public class ModernPanel : Panel
{
    private int _borderRadius = ModernBorders.Medium;
    private bool _showShadow = true;
    private Color _shadowColor = Color.FromArgb(30, 0, 0, 0);

    public ModernPanel()
    {
        BackColor = ModernColors.CardBackground;
        Padding = new Padding(ModernSpacing.CardPadding);
        
        SetStyle(ControlStyles.UserPaint | 
                 ControlStyles.AllPaintingInWmPaint | 
                 ControlStyles.OptimizedDoubleBuffer, true);
    }

    public int BorderRadius
    {
        get => _borderRadius;
        set { _borderRadius = value; Invalidate(); }
    }

    public bool ShowShadow
    {
        get => _showShadow;
        set { _showShadow = value; Invalidate(); }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        
        Rectangle bounds = new Rectangle(0, 0, Width - 1, Height - 1);
        
        // Draw shadow if enabled
        if (_showShadow)
        {
            using (GraphicsPath shadowPath = GetRoundedRectangle(
                new Rectangle(bounds.X + 2, bounds.Y + 2, bounds.Width, bounds.Height), _borderRadius))
            {
                using (PathGradientBrush shadowBrush = new PathGradientBrush(shadowPath))
                {
                    shadowBrush.CenterColor = _shadowColor;
                    shadowBrush.SurroundColors = new[] { Color.Transparent };
                    e.Graphics.FillPath(shadowBrush, shadowPath);
                }
            }
        }
        
        // Draw panel background
        using (GraphicsPath path = GetRoundedRectangle(bounds, _borderRadius))
        {
            using (SolidBrush brush = new SolidBrush(BackColor))
            {
                e.Graphics.FillPath(brush, path);
            }
            
            // Draw border
            using (Pen pen = new Pen(ModernColors.Border, 1))
            {
                e.Graphics.DrawPath(pen, path);
            }
        }
        
        base.OnPaint(e);
    }

    private GraphicsPath GetRoundedRectangle(Rectangle bounds, int radius)
    {
        int diameter = radius * 2;
        Size size = new Size(diameter, diameter);
        Rectangle arc = new Rectangle(bounds.Location, size);
        GraphicsPath path = new GraphicsPath();

        if (radius == 0)
        {
            path.AddRectangle(bounds);
            return path;
        }

        path.AddArc(arc, 180, 90);
        arc.X = bounds.Right - diameter;
        path.AddArc(arc, 270, 90);
        arc.Y = bounds.Bottom - diameter;
        path.AddArc(arc, 0, 90);
        arc.X = bounds.Left;
        path.AddArc(arc, 90, 90);
        path.CloseFigure();
        
        return path;
    }
}

/// <summary>
/// Status badge with colored background
/// </summary>
public class StatusBadge : Label
{
    private string _status = "Open";
    
    public StatusBadge()
    {
        AutoSize = false;
        Size = new Size(80, 24);
        TextAlign = ContentAlignment.MiddleCenter;
        Font = ModernFonts.SmallBold;
        
        SetStyle(ControlStyles.UserPaint | 
                 ControlStyles.AllPaintingInWmPaint | 
                 ControlStyles.OptimizedDoubleBuffer, true);
        
        UpdateColors();
    }

    public string Status
    {
        get => _status;
        set 
        { 
            _status = value;
            Text = value;
            UpdateColors();
            Invalidate();
        }
    }

    private void UpdateColors()
    {
        switch (_status.ToLower())
        {
            case "open":
                BackColor = ModernColors.InfoLight;
                ForeColor = ModernColors.Info;
                break;
            case "in progress":
                BackColor = ModernColors.WarningLight;
                ForeColor = ModernColors.Warning;
                break;
            case "closed":
                BackColor = ModernColors.SuccessLight;
                ForeColor = ModernColors.Success;
                break;
            default:
                BackColor = ModernColors.Border;
                ForeColor = ModernColors.TextSecondary;
                break;
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        
        using (GraphicsPath path = GetRoundedRectangle(ClientRectangle, 12))
        {
            using (SolidBrush brush = new SolidBrush(BackColor))
            {
                e.Graphics.FillPath(brush, path);
            }
            
            TextRenderer.DrawText(e.Graphics, Text, Font, ClientRectangle,
                ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
    }

    private GraphicsPath GetRoundedRectangle(Rectangle bounds, int radius)
    {
        int diameter = radius * 2;
        Size size = new Size(diameter, diameter);
        Rectangle arc = new Rectangle(bounds.Location, size);
        GraphicsPath path = new GraphicsPath();

        if (radius == 0)
        {
            path.AddRectangle(bounds);
            return path;
        }

        path.AddArc(arc, 180, 90);
        arc.X = bounds.Right - diameter;
        path.AddArc(arc, 270, 90);
        arc.Y = bounds.Bottom - diameter;
        path.AddArc(arc, 0, 90);
        arc.X = bounds.Left;
        path.AddArc(arc, 90, 90);
        path.CloseFigure();
        
        return path;
    }
}
