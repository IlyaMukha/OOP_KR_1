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

namespace KR
{
    public partial class MainWindow : Window
    {
        Color? selectidColor = null;

        Picture picture = new Picture();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void cp_SelectedColorChanged_1(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            if (EllipseColor.SelectedColor.HasValue)
            {
                Color C = EllipseColor.SelectedColor.Value;
                selectidColor = C;
            }           
        }

        private void Create_Cirkle(object sender, RoutedEventArgs e)
        {
            try
            {
                Circle circle = new Circle(Convert.ToDouble(EllipseR.Text));
                picture.figures.Add(circle);
                Ellipse myElips = new Ellipse();
                SolidColorBrush brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(selectidColor.ToString()));

                myElips.Fill = brush;
                myElips.Width = circle.Radius * 2;
                myElips.Height = circle.Radius * 2;

                perimetr.Content = String.Format("{0:00.00}", circle.Perimeter());
                square.Content = String.Format("{0:00.00}", circle.Square());
                myGrid.Children.Clear();
                myGrid.Children.Add(myElips);
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void Create_Rectangle(object sender, RoutedEventArgs e)
        {
            try
            {
                
                My_Rectangle my_Rectangle = new My_Rectangle(Convert.ToDouble(RW.Text), Convert.ToDouble(RH.Text));
                picture.figures.Add(my_Rectangle);


                Rectangle rectangle = new Rectangle();
                SolidColorBrush brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(selectidColor.ToString()));

                rectangle.Fill = brush;
                rectangle.Width = my_Rectangle.Width;
                rectangle.Height = my_Rectangle.Height;

                myGrid.Children.Clear();
                myGrid.Children.Add(rectangle);
                perimetr.Content = String.Format("{0:00.00}", my_Rectangle.Perimeter());
                square.Content = String.Format("{0:00.00}", my_Rectangle.Square());
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Create_T(object sender, RoutedEventArgs e)
        {
            try
            {
                Trapezium trapezium = new Trapezium(Convert.ToDouble(T1.Text), Convert.ToDouble(T2.Text), Convert.ToDouble(T3.Text));
                picture.figures.Add(trapezium);

                Path path = new Path();
                SolidColorBrush brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(selectidColor.ToString()));
                path.Fill = brush;

                PathFigure pathFigure = new PathFigure();
                pathFigure.StartPoint = new Point(((trapezium.Bottom - trapezium.Top) / 2) + 75, 0 + 75);


                LineSegment line1 = new LineSegment();
                line1.Point = new Point(trapezium.Top + 75, 0 + 75);

                LineSegment line2 = new LineSegment();
                line2.Point = new Point(trapezium.Top + ((trapezium.Bottom - trapezium.Top) / 2)+75, trapezium.Height + 75);

                LineSegment line3 = new LineSegment();
                line3.Point = new Point(0 + 75, trapezium.Height + 75);

                LineSegment line4 = new LineSegment();
                line4.Point = new Point(((trapezium.Bottom - trapezium.Top) / 2)+75, 0 + 75);

                PathSegmentCollection pathSegments = new PathSegmentCollection();
                pathSegments.Add(line1);
                pathSegments.Add(line2);
                pathSegments.Add(line3);
                pathSegments.Add(line4);

                pathFigure.Segments = pathSegments;

                PathFigureCollection pathFigures = new PathFigureCollection();
                pathFigures.Add(pathFigure);

                PathGeometry pathGeometry = new PathGeometry();
                pathGeometry.Figures = pathFigures;

                path.Data = pathGeometry;

                myGrid.Children.Clear();
                myGrid.Children.Add(path);
                perimetr.Content = String.Format("{0:00.00}", trapezium.Perimeter());
                square.Content = String.Format("{0:00.00}", trapezium.Square());
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetPerimeters(object sender, RoutedEventArgs e)
        {
            picture.GetPerimeters();
        }

        private void GetSquares(object sender, RoutedEventArgs e)
        {
            picture.GetSquares();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            picture.Save();
        }
    }
}
