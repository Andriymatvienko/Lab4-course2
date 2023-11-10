using System;

class TCIRCLE
{
    public double radius;
    public Tuple<double, double> center;

    public TCIRCLE()
    {
        radius = 0;
        center = new Tuple<double, double>(0, 0);
    }

    public TCIRCLE(double radius, Tuple<double, double> center)
    {
        this.radius = radius;
        this.center = center;
    }

    // Конструктор копіювання
    public TCIRCLE(TCIRCLE circle)
    {
        this.radius = circle.radius;
        this.center = circle.center;
    }

    // Введення даних
    public void InputData()
    {
        Console.Write("Введіть радіус круга: ");
        radius = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введіть координату X центру кола: ");
        double x = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введіть координату Y центру кола: ");
        double y = Convert.ToDouble(Console.ReadLine());

        center = new Tuple<double, double>(x, y);
    }

    // Виведення даних
    public void Display()
    {
        Console.WriteLine($"Радіус: {radius}, Центр: {center}");
    }

    // Перевірка належності точки колу
    public bool IsPointInside(Tuple<double, double> point)
    {
        double distance = Math.Sqrt(Math.Pow(point.Item1 - center.Item1, 2) + Math.Pow(point.Item2 - center.Item2, 2));
        return distance <= radius;
    }

    // Перевантаження операторів
    public static double operator +(TCIRCLE circle1, TCIRCLE circle2)
    {
        return circle1.radius + circle2.radius;
    }

    public static double operator -(TCIRCLE circle1, TCIRCLE circle2)
    {
        return circle1.radius - circle2.radius;
    }

    public static double operator *(TCIRCLE circle, double num)
    {
        return circle.radius * num;
    }
}

class TBALL : TCIRCLE
{
    public TBALL(double radius, Tuple<double, double> center) : base(radius, center) { }

    public double Volume()
    {
        return (4 / 3) * 3.14159 * (Math.Pow(radius, 3));
    }
}

// Програма клієнт для тестування
class Program
{
    static void Main()
    {
        TCIRCLE circle = new TCIRCLE(5, new Tuple<double, double>(0, 0));
        circle.Display(); // Виведення даних
        Console.WriteLine("Точка (1, 2) належить кругу: " + circle.IsPointInside(new Tuple<double, double>(1, 2))); // Перевірка належності точки колу
        Console.WriteLine("Додавання радіусів: " + (circle + new TCIRCLE(3, new Tuple<double, double>(0, 0)))); // Перевантаження оператора +
        Console.WriteLine("Множення радіуса на число: " + circle * 2); // Перевантаження оператора *

        TBALL ball = new TBALL(5, new Tuple<double, double>(0, 0));
        Console.WriteLine("Об'єм кулі: " + ball.Volume()); // Метод для знаходження об'єму кулі
    }
}
