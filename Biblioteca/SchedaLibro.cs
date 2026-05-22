using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Biblioteca
{
    public sealed class SchedaLibro : Panel
    {
        private readonly LibroCatalogo _libro;
        private static readonly Color[] Palette =
        {
            Color.FromArgb(86, 156, 214),
            Color.FromArgb(120, 190, 140),
            Color.FromArgb(245, 170, 90),
            Color.FromArgb(155, 120, 210),
            Color.FromArgb(90, 190, 200),
            Color.FromArgb(210, 130, 90),
            Color.FromArgb(110, 175, 95),
            Color.FromArgb(200, 150, 220)
        };

        public SchedaLibro(LibroCatalogo libro)
        {
            _libro = libro;
            DoubleBuffered = true;
            Width = 220;
            Height = 70;
            Margin = new Padding(8);
            BackColor = Color.White;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            var bookRect = new Rectangle(12, 12, 40, 56);
            var color = GetBookColor(_libro);
            using (var brush = new SolidBrush(color))
            {
                g.FillRectangle(brush, bookRect);
            }

            using (var spineBrush = new SolidBrush(Color.FromArgb(40, 0, 0, 0)))
            {
                g.FillRectangle(spineBrush, new Rectangle(bookRect.X + 4, bookRect.Y + 4, 6, bookRect.Height - 8));
            }

            using (var pen = new Pen(Color.FromArgb(80, 80, 80)))
            {
                g.DrawRectangle(pen, bookRect);
            }

            var titleRect = new Rectangle(65, 14, Width - 75, 36);
            TextRenderer.DrawText(g, _libro.Titolo, Font, titleRect, Color.FromArgb(30, 30, 30), TextFormatFlags.Left | TextFormatFlags.EndEllipsis);

            string availability = $"Disponibili: {_libro.Disponibili}/{_libro.Totale}";
            var availabilityRect = new Rectangle(65, 48, Width - 75, 20);
            var availabilityColor = _libro.Disponibili == 0 ? Color.FromArgb(190, 60, 60) : Color.FromArgb(70, 130, 90);
            TextRenderer.DrawText(g, availability, Font, availabilityRect, availabilityColor, TextFormatFlags.Left);
        }

        private static Color GetBookColor(LibroCatalogo libro)
        {
            if (IsDiarioDellaSchiappa(libro.Titolo))
            {
                return Color.FromArgb(220, 60, 60);
            }

            int index = Math.Abs(libro.Titolo.GetHashCode()) % Palette.Length;
            var baseColor = Palette[index];
            if (libro.Disponibili == 0)
            {
                return Blend(baseColor, Color.FromArgb(210, 70, 70), 0.55f);
            }
            if (libro.Disponibili <= libro.Totale / 2)
            {
                return Blend(baseColor, Color.FromArgb(245, 200, 80), 0.35f);
            }
            return baseColor;
        }

        private static bool IsDiarioDellaSchiappa(string titolo)
        {
            if (string.IsNullOrWhiteSpace(titolo))
            {
                return false;
            }

            return titolo.IndexOf("diario", StringComparison.OrdinalIgnoreCase) >= 0
                && titolo.IndexOf("schiappa", StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private static Color Blend(Color first, Color second, float amount)
        {
            amount = Math.Max(0f, Math.Min(1f, amount));
            int r = (int)(first.R + (second.R - first.R) * amount);
            int g = (int)(first.G + (second.G - first.G) * amount);
            int b = (int)(first.B + (second.B - first.B) * amount);
            return Color.FromArgb(r, g, b);
        }
    }
}
