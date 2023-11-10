using System;

class TSMATRIX
{
    public int[,] matrix;
    public int rows;
    public int columns;

    public TSMATRIX()
    {
        rows = 0;
        columns = 0;
        matrix = new int[rows, columns];
    }

    public TSMATRIX(int[,] elements)
    {
        rows = elements.GetLength(0);
        columns = elements.GetLength(1);
        matrix = elements;
    }

    public TSMATRIX(TSMATRIX other)
    {
        rows = other.rows;
        columns = other.columns;
        matrix = other.matrix;
    }

    public void InputData()
    {
        Console.WriteLine("Введіть розмірність матриці:");
        Console.Write("Рядки: ");
        rows = Convert.ToInt32(Console.ReadLine());

        Console.Write("Стовпці: ");
        columns = Convert.ToInt32(Console.ReadLine());

        matrix = new int[rows, columns];

        Console.WriteLine("Введіть елементи матриці:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write($"Елемент [{i},{j}]: ");
                matrix[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }
    }

    public void Display()
    {
        Console.WriteLine("Матриця:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    public int FindMaxElement()
    {
        int max = matrix[0, 0];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                }
            }
        }
        return max;
    }

    public int FindMinElement()
    {
        int min = matrix[0, 0];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if (matrix[i, j] < min)
                {
                    min = matrix[i, j];
                }
            }
        }
        return min;
    }

    public int CalculateSumOfElements()
    {
        int sum = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                sum += matrix[i, j];
            }
        }
        return sum;
    }

    public static TSMATRIX operator +(TSMATRIX matrix1, TSMATRIX matrix2)
    {
        int[,] result = new int[matrix1.rows, matrix1.columns];

        for (int i = 0; i < matrix1.rows; i++)
        {
            for (int j = 0; j < matrix1.columns; j++)
            {
                result[i, j] = matrix1.matrix[i, j] + matrix2.matrix[i, j];
            }
        }

        return new TSMATRIX(result);
    }

    public static TSMATRIX operator -(TSMATRIX matrix1, TSMATRIX matrix2)
    {
        int[,] result = new int[matrix1.rows, matrix1.columns];

        for (int i = 0; i < matrix1.rows; i++)
        {
            for (int j = 0; j < matrix1.columns; j++)
            {
                result[i, j] = matrix1.matrix[i, j] - matrix2.matrix[i, j];
            }
        }

        return new TSMATRIX(result);
    }
}

class TDeterminant2 : TSMATRIX
{
    public TDeterminant2(int[,] elements) : base(elements) { }

    public int CalculateDeterminant()
    {
        // Перевірка розмірності матриці, яка має бути 2x2
        if (rows != 2 || columns != 2)
        {
            Console.WriteLine("Для знаходження визначника потрібна матриця розмірності 2x2.");
            return 0;
        }

        return (matrix[0, 0] * matrix[1, 1]) - (matrix[0, 1] * matrix[1, 0]);
    }
}

class Program
{
    static void Main()
    {
        TSMATRIX matrix1 = new TSMATRIX();
        matrix1.InputData();
        matrix1.Display();

        Console.WriteLine($"Найбільший елемент: {matrix1.FindMaxElement()}");
        Console.WriteLine($"Найменший елемент: {matrix1.FindMinElement()}");
        Console.WriteLine($"Сума елементів: {matrix1.CalculateSumOfElements()}");

        TSMATRIX matrix2 = new TSMATRIX();
        matrix2.InputData();
        matrix2.Display();

        TSMATRIX sum = matrix1 + matrix2;
        Console.WriteLine("Результат додавання матриць:");
        sum.Display();

        TSMATRIX difference = matrix1 - matrix2;
        Console.WriteLine("Результат віднімання матриць:");
        difference.Display();

        TDeterminant2 determinant = new TDeterminant2(new int[,] { { 2, 3 }, { 1, 4 } });
        int result = determinant.CalculateDeterminant();
        Console.WriteLine($"Визначник матриці 2x2: {result}");
    }
}
