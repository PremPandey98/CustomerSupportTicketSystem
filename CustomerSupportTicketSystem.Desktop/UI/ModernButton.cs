using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CustomerSupportTicketSystem.Desktop.UI;

/// <summary>
/// Modern flat button with rounded corners and hover effects
/// </summary>
public class ModernButton : Button
{
    private Color _normalColor = ModernColors.Primary;
    private Color _hoverColor = ModernColors.PrimaryHover;
    private Color _textColor = ModernColors.TextLight;
    private int _borderRadius = ModernBorders.Medium;
    private bool _isHovering = false;

    public ModernButton()
    {
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        BackColor = _normalColor;
        ForeColor = _textColor;
        Font = ModernFonts.Button;
        Cursor = Cursors.Hand;
        Size = new Size(120, 40);
        
        // Enable double buffering to reduce flicker
        SetStyle(ControlStyles.UserPaint | 
                 ControlStyles.AllPaintingInWmPaint | 
                 ControlStyles.OptimizedDoubleBuffer, true);
    }

    public Color NormalColor
    {
        get => _normalColor;
        set { _normalColor = value; BackColor = value; Invalidate(); }
    }

    public Color HoverColor
    {
        get => _hoverColor;
        set { _hoverColor = value; Invalidate(); }
    }

    public Color TextColor
    {
        get => _textColor;
        set { _textColor = value; ForeColor = value; Invalidate(); }
    }

    public int BorderRadius
    {
        get => _borderRadius;
        set { _borderRadius = value; Invalidate(); }
    }

    protected override void OnMouseEnter(EventArgs e)
    {
        base.OnMouseEnter(e);
        _isHovering = true;
        Invalidate();
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseLeave(e);
        _isHovering = false;
        Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        
        // Determine current color
        Color currentColor = _isHovering ? _hoverColor : _normalColor;
        
        // Create rounded rectangle path
        using (GraphicsPath path = GetRoundedRectangle(ClientRectangle, _borderRadius))
        {
            // Fill background
            using (SolidBrush brush = new SolidBrush(currentColor))
            {
                e.Graphics.FillPath(brush, path);
            }
            
            // Draw text
            TextRenderer.DrawText(e.Graphics, Text, Font, ClientRectangle, 
                _textColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
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

        // Top left arc
        path.AddArc(arc, 180, 90);

        // Top right arc
        arc.X = bounds.Right - diameter;
        path.AddArc(arc, 270, 90);

        // Bottom right arc
        arc.Y = bounds.Bottom - diameter;
        path.AddArc(arc, 0, 90);

        // Bottom left arc
        arc.X = bounds.Left;
        path.AddArc(arc, 90, 90);

        path.CloseFigure();
        return path;
    }
}
