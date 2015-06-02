using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Collections.Generic;

namespace WpfGraphicsApp1
{
    static class RDCanvasUtils
    {
        public static System.Windows.Shapes.Line createLine(
            double strokeThickness, Brush strokeColor, double x1, double y1, double x2, double y2)
        {
            return new Line
            {
                Stroke = strokeColor,
                StrokeThickness = strokeThickness,
                X1 = x1,
                Y1 = y1,
                X2 = x2,
                Y2 = y2
            };
        }

        public static System.Windows.Shapes.Polyline createPolyline(
            double strokeThickness, Brush strokeColor, double x1, double y1, double x2, double y2)
        {
            return new Polyline()
            {
                Stroke = Brushes.Black,
                StrokeThickness = strokeThickness,
                Points = new PointCollection(
                    new List<System.Windows.Point> {
                            new System.Windows.Point(x1, y1), 
                            new System.Windows.Point(x2, y2)})
            };
        }

        public static System.Windows.Shapes.Ellipse createEllipse(
            double strokeThickness, Brush strokeColor, Brush fillColor, double canvasXPos, double canvasYPos){

            Ellipse ellipse = new Ellipse
            {
                Stroke = strokeColor,
                StrokeThickness = strokeThickness,
                Fill = fillColor
            };
            Canvas.SetLeft(ellipse, canvasXPos);
            Canvas.SetTop(ellipse, canvasYPos);
            return ellipse;
        }

        public static System.Windows.Shapes.Rectangle createRectangle(
           double strokeThickness, Brush strokeColor, Brush fillColor, double canvasXPos, double canvasYPos)
        {
            Rectangle rect = new Rectangle
            {
                Stroke = strokeColor,
                StrokeThickness = strokeThickness,
                Fill = fillColor
            };
            Canvas.SetLeft(rect, canvasXPos);
            Canvas.SetTop(rect, canvasYPos);
            return rect;
        }

        public static void SaveCanvas(Window window, Canvas canvas, int dpi, string filename, string fileFormat)
        { 
            /* Measure and arrange the canvas, this is important to make sure
             * the image file shows the canvas at the correct size in the correct position */
            Size size = new Size(canvas.Width, canvas.Height);
            canvas.Measure(size);
            canvas.Arrange(new Rect(size));

            var rtb = new RenderTargetBitmap( (int)size.Width, (int)size.Height, dpi, dpi, PixelFormats.Pbgra32 );
            rtb.Render(canvas);
            BitmapEncoder encoder;

            switch (fileFormat)
            {
                case "jpeg": encoder = new JpegBitmapEncoder(); break;
                case "png": encoder = new PngBitmapEncoder(); break;
                case "bmp": encoder = new BmpBitmapEncoder(); break;
                case "tiff": encoder = new TiffBitmapEncoder(); break;
                case "gif": encoder = new GifBitmapEncoder(); break;
                default: encoder = new PngBitmapEncoder(); break;
            }

            encoder.Frames.Add(BitmapFrame.Create(rtb));
            using (var stm = System.IO.File.Create(filename)){ encoder.Save(stm); }
        }

    }
}
