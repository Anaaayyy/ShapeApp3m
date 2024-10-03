using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShapeApp
{
    public partial class MainWindow : Window
    {
        // Делегат для вычисления площади
        public delegate double CalculateAreaDelegate();

        // Базовый класс "Фигура"
        public abstract class Shape
        {
            public abstract double CalculateArea();
        }

        // Производный класс для круга
        public class Circle : Shape
        {
            public double Radius { get; set; }
            public Circle(double radius) => Radius = radius;
            public override double CalculateArea() => Math.PI * Radius * Radius;
        }

        // Производный класс для прямоугольника
        public class Rectangle : Shape
        {
            public double Width { get; set; }
            public double Height { get; set; }
            public Rectangle(double width, double height)
            {
                Width = width;
                Height = height;
            }
            public override double CalculateArea() => Width * Height;
        }

        // Производный класс для треугольника
        public class Triangle : Shape
        {
            public double Base { get; set; }
            public double Height { get; set; }
            public Triangle(double baseLength, double height)
            {
                Base = baseLength;
                Height = height;
            }
            public override double CalculateArea() => 0.5 * Base * Height;
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        // Обработчик для круга
        private void CircleButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(InputTextBox.Text, out double radius))
            {
                Shape circle = new Circle(radius);
                CalculateAreaDelegate areaDelegate = circle.CalculateArea;
                ResultTextBlock.Text = "Площадь круга: " + areaDelegate();
            }
            else
            {
                ResultTextBlock.Text = "Ошибка ввода. Введите правильное значение радиуса.";
            }
        }

        // Обработчик для прямоугольника
        private void RectangleButton_Click(object sender, RoutedEventArgs e)
        {
            string[] inputs = InputTextBox.Text.Split(',');
            if (inputs.Length == 2 && double.TryParse(inputs[0], out double width) && double.TryParse(inputs[1], out double height))
            {
                Shape rectangle = new Rectangle(width, height);
                CalculateAreaDelegate areaDelegate = rectangle.CalculateArea;
                ResultTextBlock.Text = "Площадь прямоугольника: " + areaDelegate();
            }
            else
            {
                ResultTextBlock.Text = "Ошибка ввода. Введите ширину и высоту через запятую.";
            }
        }

        // Обработчик для треугольника
        private void TriangleButton_Click(object sender, RoutedEventArgs e)
        {
            string[] inputs = InputTextBox.Text.Split(',');
            if (inputs.Length == 2 && double.TryParse(inputs[0], out double baseLength) && double.TryParse(inputs[1], out double height))
            {
                Shape triangle = new Triangle(baseLength, height);
                CalculateAreaDelegate areaDelegate = triangle.CalculateArea;
                ResultTextBlock.Text = "Площадь треугольника: " + areaDelegate();
            }
            else
            {
                ResultTextBlock.Text = "Ошибка ввода. Введите основание и высоту через запятую.";
            }
        }
    }
}