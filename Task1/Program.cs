// создаём основную функцию main с которой будет запускаться вся программа
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

void Main()
{
    int row = ReadInt("Введите количество строк: ");
    int col = ReadInt("Введите количество колонок: ");
    int[,] matrix = GenereateMatrix(row, col, 0, 99);
    PrintMatrix(matrix);
    ChangeMatrix(matrix);
    // массив изменяется без создания новых переменных, так как мы используем ссылочные типы данных
    // при создании методов, то есть ссылаемся на одну и ту же матрицу через разные ссылки
    PrintMatrix(matrix);
}

// Создаём метод, который пройдётся по матрице и заменит нужные элементы на их квадрат
void ChangeMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i += 2)
    {
        for (int j = 0; j < matrix.GetLength(1); j += 2)
        {
            matrix[i, j] *= matrix[i, j];
        }
    }
}

// напишем метод для вывода матрицы
void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            System.Console.Write(matrix[i, j] + "\t");
        }
        // делаем отступ пустой строкой для более презентабельного вывода двумерной матрицы
        System.Console.WriteLine();
    }
    System.Console.WriteLine();
}

// напишем метод для генерации двумерного массива, в качестве аргумента передалим
// количество строк, количество столбцов, максимальное и минимальное
// значения для генерации мсассива
int[,] GenereateMatrix(int rowSize, int colSize, int minValue, int maxValue)
{
    int[,] tempMatrix = new int[rowSize, colSize];
    // объявляем экзкмпляр класса для экономии оперативной памяти
    Random rand = new Random();

    // задаём цикл для прохода по элементам массива
    // tempMatrix.GetLength(0) - отвечает за количество строк
    for (int i = 0; i < tempMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < tempMatrix.GetLength(1); j++)
        {
            // обращаемся к элементу массива i и j, задаём им рандомное
            // значение rand.Next в диапазоне от minValue до maxValue
            tempMatrix[i, j] = rand.Next(minValue, maxValue + 1);
        }
    }
    return tempMatrix;
}

// напишем функцию, которая принимает от пользователя размер массива и возвращает его
int ReadInt(string msg)
{
    // принимает сообщение для пользователя
    System.Console.Write(msg);
    // возвращает число, введённое пользователем
    return Convert.ToInt32(Console.ReadLine());
}

Main();