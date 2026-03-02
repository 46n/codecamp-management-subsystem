using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AsTest1
{
    public static class RippleEffect
    {
        private class Ripple
        {
            public Point Center;
            public float Radius;
            public float MaxRadius;
            public int Alpha;
        }

        public static void Attach(Control c, Color rippleColor,
            int startAlpha = 70, int durationMs = 450)
        {
            var ripples = new List<Ripple>();
            var timer = new System.Windows.Forms.Timer { Interval = 15 };

            timer.Tick += (s, e) =>
            {
                int ticks = Math.Max(1, durationMs / timer.Interval);
                float maxR = Math.Max(c.Width, c.Height) * 0.30f;
                float radiusStep = maxR / ticks;
                int alphaStep = Math.Max(1, startAlpha / ticks);

                for (int i = ripples.Count - 1; i >= 0; i--)
                {
                    var r = ripples[i];
                    r.Radius += radiusStep;
                    r.Alpha -= alphaStep;

                    if (r.Radius >= r.MaxRadius || r.Alpha <= 0)
                        ripples.RemoveAt(i);
                }

                c.Invalidate();
                if (ripples.Count == 0) timer.Stop();
            };

            c.MouseDown += (s, e) =>
            {
                float maxR = (float)Math.Sqrt(c.Width * c.Width + c.Height * c.Height);

                ripples.Add(new Ripple
                {
                    Center = e.Location,
                    Radius = 0,
                    MaxRadius = maxR,
                    Alpha = startAlpha
                });

                timer.Start();
                c.Invalidate();
            };

            c.Paint += (s, e) =>
            {
                if (ripples.Count == 0) return;

                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                foreach (var r in ripples)
                {
                    using var brush = new SolidBrush(Color.FromArgb(r.Alpha, rippleColor));
                    float d = r.Radius * 2f;

                    e.Graphics.FillEllipse(
                        brush,
                        r.Center.X - r.Radius,
                        r.Center.Y - r.Radius,
                        d,
                        d);
                }
            };
        }
    }
}