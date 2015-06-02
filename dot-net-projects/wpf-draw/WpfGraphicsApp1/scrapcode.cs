using System.Drawing;

namespace WpfGraphicsApp1
{
    public class ScrapCode{

        public ScrapCode(){}

        private void DrawCircleImage()
        {
            /* Draw a circle and save to a png image file */
            using (Bitmap b = new Bitmap(40, 40))
            {
                using (Graphics g = Graphics.FromImage(b))
                {
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    g.Clear(System.Drawing.Color.White);
                    g.DrawEllipse(
                        new System.Drawing.Pen(System.Drawing.Brushes.Black, 2),
                        new System.Drawing.Rectangle(1, 1, 37, 37)
                    );
                    g.FillEllipse(System.Drawing.Brushes.Blue, new System.Drawing.Rectangle(1, 1, 37, 37));
                }
                b.Save(@"C:\temp\circleTool.png", System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        private void DrawSquareImage()
        {
            /* Draw a square and save to a png image file */
            using (Bitmap b = new Bitmap(40, 40))
            {
                using (Graphics g = Graphics.FromImage(b))
                {
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    g.Clear(System.Drawing.Color.White);
                    g.DrawRectangle(
                        new System.Drawing.Pen(System.Drawing.Brushes.Black, 2),
                        new System.Drawing.Rectangle(1, 1, 37, 37)
                    );
                    g.FillRectangle(System.Drawing.Brushes.Blue, new System.Drawing.Rectangle(1, 1, 37, 37));
                }
                b.Save(@"C:\temp\green5.png", System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        private void DrawLine()
        {
            /* Draw a line and save to a png image file */
            using (Bitmap b = new Bitmap(40, 40))
            {
                using (Graphics g = Graphics.FromImage(b))
                {
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    g.Clear(System.Drawing.Color.White);
                    g.DrawLine(new System.Drawing.Pen(System.Drawing.Brushes.Black, 2),1,1,37,37);
                }
                b.Save(@"C:\temp\line1.png", System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        private void DrawLines()
        {
            /* Draw multiple lines and save to a png image file */
            using (Bitmap b = new Bitmap(40, 40))
            {
                using (Graphics g = Graphics.FromImage(b))
                {
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    g.Clear(System.Drawing.Color.White);
                    g.DrawLine(new System.Drawing.Pen(System.Drawing.Brushes.Black, 2), 1, 1, 10, 26);
                    g.DrawLine(new System.Drawing.Pen(System.Drawing.Brushes.Black, 2), 10, 26, 30, 11);
                    g.DrawLine(new System.Drawing.Pen(System.Drawing.Brushes.Black, 2), 30, 11, 38, 38);
                }
                b.Save(@"C:\temp\polyline1.png", System.Drawing.Imaging.ImageFormat.Png);
            }
        }
    }

}