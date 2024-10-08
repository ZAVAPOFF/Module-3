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

namespace Figure
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateCircleArea(object sender, RoutedEventArgs e)
        {
            double radius = double.Parse(tbRadius.Text);
            Circle circle = new Circle(radius);
            double area = AreaCalculator.CalculateArea(circle);
            MessageBox.Show($"Circle Area: {area}");
        }

        private void CalculateRectangleArea(object sender, RoutedEventArgs e)
        {
            double width = double.Parse(tbWidth.Text);
            double height = double.Parse(tbHeightRect.Text);
            Rectangle rectangle = new Rectangle(width, height);
            double area = AreaCalculator.CalculateArea(rectangle);
            MessageBox.Show($"Rectangle Area: {area}");
        }

        private void CalculateTriangleArea(object sender, RoutedEventArgs e)
        {
            double Side = double.Parse(tbSide.Text);
            double height = double.Parse(tbHeightTriangle.Text);
            Triangle triangle = new Triangle(Side, height);
            double area = AreaCalculator.CalculateArea(triangle);
            MessageBox.Show($"Triangle Area: {area}");
        }


    }


}
