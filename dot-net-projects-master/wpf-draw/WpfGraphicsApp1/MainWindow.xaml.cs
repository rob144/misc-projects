using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using WpfGraphicsApp1;

using System.Drawing;

namespace WpfGraphicsApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private System.Windows.Controls.Image selectedTool;
        private System.Windows.Point startPoint;
        private System.Windows.Shapes.Rectangle rect;
        private System.Windows.Shapes.Rectangle rectFilled;
        private System.Windows.Shapes.Ellipse circle;
        private System.Windows.Shapes.Ellipse circleFilled;
        private System.Windows.Shapes.Line line;
        private System.Windows.Shapes.Polyline polyLine;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NewCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //Clear the canvas and remove children.
            
            MessageBoxResult res = MessageBox.Show("Would you like to save the current drawing?",
                "New File", MessageBoxButton.YesNoCancel);
            if (res == MessageBoxResult.Yes)
            {
                SaveDrawing();
                CanvasMain.Children.Clear();
            }
            else if (res == MessageBoxResult.No)
            {
                CanvasMain.Children.Clear();
            }
           
        }

        private void OpenCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void OpenCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("OPEN!");
        }

        private void SaveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveDrawing();
        }

        private void SaveDrawing()
        {
            //TODO: if filename chosen previously use that one else show dialog to choose file name.
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "drawing"; // Default file name
            dlg.DefaultExt = ".png";
            dlg.Filter = "Bitmap Image (.bmp)|*.bmp"
                + "|Gif Image (.gif)|*.gif"
                + "|JPEG Image (.jpeg)|*.jpeg"
                + "|Png Image (.png)|*.png"
                + "|Tiff Image (.tiff)|*.tiff";

            Nullable<bool> result = dlg.ShowDialog();

            //Save file
            if (result == true)
            {
                string ext = System.IO.Path.GetExtension(dlg.FileName);
                RDCanvasUtils.SaveCanvas(this, CanvasMain, 96, dlg.FileName, ext);
            }
        }

        private void ExitCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ExitCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Canvas c = (Canvas)sender;
            startPoint = e.GetPosition(c);
            double strokeThickness = Double.Parse(comboStrokeThickness.SelectionBoxItem.ToString());

            if (this.selectedTool == toolPencil)
            {
                polyLine = RDCanvasUtils.createPolyline(
                    strokeThickness, System.Windows.Media.Brushes.Black, 
                    startPoint.X, startPoint.Y, startPoint.X, startPoint.Y);
                 c.Children.Add(polyLine);
            }
            else if (this.selectedTool == toolSquare)
            {
                rect = RDCanvasUtils.createRectangle(
                    strokeThickness,
                    System.Windows.Media.Brushes.Black,
                    System.Windows.Media.Brushes.Transparent,
                    startPoint.X,
                    startPoint.Y);
                c.Children.Add(rect);
            }
            else if (this.selectedTool == toolSquareFilled)
            {
                rectFilled = RDCanvasUtils.createRectangle(
                    strokeThickness,
                    System.Windows.Media.Brushes.Black,
                    System.Windows.Media.Brushes.Blue,
                    startPoint.X,
                    startPoint.Y);
                c.Children.Add(rectFilled);
            }
            else if (this.selectedTool == toolCircle)
            {
                circle = RDCanvasUtils.createEllipse(
                    strokeThickness, 
                    System.Windows.Media.Brushes.Black,
                    System.Windows.Media.Brushes.Transparent,
                    startPoint.X, startPoint.Y);
                c.Children.Add(circle);
            }
            else if (this.selectedTool == toolCircleFilled)
            {
                circleFilled = RDCanvasUtils.createEllipse(
                    strokeThickness,
                    System.Windows.Media.Brushes.Black,
                    System.Windows.Media.Brushes.Blue,
                    startPoint.X, startPoint.Y);
                c.Children.Add(circleFilled);
            }
            else if (this.selectedTool == toolLine)
            {
                line = RDCanvasUtils.createLine(
                    strokeThickness, 
                    System.Windows.Media.Brushes.Black, 
                    startPoint.X, startPoint.Y, 
                    startPoint.X, startPoint.Y);
                c.Children.Add(line);
            }
            else if (this.selectedTool == toolPolyline)
            {
                if (e.ClickCount == 1)
                {
                    if (polyLine == null)
                    {
                        polyLine = RDCanvasUtils.createPolyline(
                        strokeThickness, System.Windows.Media.Brushes.Black,
                        startPoint.X, startPoint.Y, startPoint.X, startPoint.Y);
                        c.Children.Add(polyLine);
                    }
                    else
                    {
                        polyLine.Points.Add(new System.Windows.Point(startPoint.X, startPoint.Y));
                    }

                }
                else if (e.ClickCount == 2)
                {
                    //End the polyline.
                    polyLine = null;
                }
            }
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            Canvas c = (Canvas)sender;
            var pos = e.GetPosition(c);
            var x = Math.Min(pos.X, startPoint.X);
            var y = Math.Min(pos.Y, startPoint.Y);
            var w = Math.Max(pos.X, startPoint.X) - x;
            var h = Math.Max(pos.Y, startPoint.Y) - y;

            if (this.selectedTool == toolPencil
                && e.LeftButton != MouseButtonState.Released && polyLine != null)
            {
                polyLine.Points.Add(new System.Windows.Point(pos.X, pos.Y));
            }
            else if (this.selectedTool == toolSquare
                && e.LeftButton != MouseButtonState.Released && rect != null)
            {
                rect.Width = w;
                rect.Height = h;
                Canvas.SetLeft(rect, x);
                Canvas.SetTop(rect, y);
            }
            else if (this.selectedTool == toolSquareFilled
                && e.LeftButton != MouseButtonState.Released && rectFilled != null)
            {
                rectFilled.Width = w;
                rectFilled.Height = h;
                Canvas.SetLeft(rectFilled, x);
                Canvas.SetTop(rectFilled, y);
            }
            else if (this.selectedTool == toolCircle
                && e.LeftButton != MouseButtonState.Released && circle != null)
            {
                circle.Width = w;
                circle.Height = h;
                Canvas.SetLeft(circle, x);
                Canvas.SetTop(circle, y);
            }
            else if (this.selectedTool == toolCircleFilled
               && e.LeftButton != MouseButtonState.Released && circleFilled != null)
            {
                circleFilled.Width = w;
                circleFilled.Height = h;
                Canvas.SetLeft(circleFilled, x);
                Canvas.SetTop(circleFilled, y);
            }
            else if (this.selectedTool == toolLine
               && e.LeftButton != MouseButtonState.Released && line != null)
            {
                line.X2 = pos.X;
                line.Y2 = pos.Y;
            }
            else if (this.selectedTool == toolPolyline && polyLine != null)
            {
                polyLine.Points[polyLine.Points.Count() - 1] = new System.Windows.Point(pos.X, pos.Y);
            }

            lblXCoord.Content = "X: " + Math.Round(pos.X);
            lblYCoord.Content = "Y: " + Math.Round(pos.X);
        }

        private void Canvas_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            rect = null;
            rectFilled = null;
            circle = null;
            circleFilled = null;
            line = null;
            if (this.selectedTool == toolPencil) polyLine = null;
        }

        private void SelectTool(System.Windows.Controls.Image chosenTool)
        {
            List<System.Windows.Controls.Image> tools = new List<System.Windows.Controls.Image>();
            tools.AddRange(new System.Windows.Controls.Image[] { 
                toolPencil, 
                toolSquare, 
                toolSquareFilled, 
                toolCircle,
                toolCircleFilled, 
                toolLine, 
                toolPolyline });

            foreach (System.Windows.Controls.Image t in tools) 
                (t.Parent as Border).BorderBrush = System.Windows.Media.Brushes.Transparent;
            (chosenTool.Parent as Border).BorderBrush = System.Windows.Media.Brushes.Blue;
            this.selectedTool = chosenTool;
        }

        private void Tool_MouseUp(object sender, MouseButtonEventArgs e)
        {
            SelectTool(sender as System.Windows.Controls.Image);
        }

        private void btnDecreaseStroke_Click(object sender, EventArgs e)
        {
            Double strokeThickness = Double.Parse(comboStrokeThickness.SelectionBoxItem.ToString());
            if(strokeThickness >= 2) comboStrokeThickness.SelectedValue =  "" + (strokeThickness - 1);
        }

        private void btnIncreaseStroke_Click(object sender, EventArgs e)
        {
            Double strokeThickness = Double.Parse(comboStrokeThickness.SelectionBoxItem.ToString());
            Double max = 0;

            foreach (ComboBoxItem item in comboStrokeThickness.Items)
            {
                Double temp = Double.Parse(item.Content.ToString());
                if (temp > max) max = temp;
            }

            if (strokeThickness + 1 <= max)
                comboStrokeThickness.SelectedValue = "" + (strokeThickness + 1);
        }


    }
}
