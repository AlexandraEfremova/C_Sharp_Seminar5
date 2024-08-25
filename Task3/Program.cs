// Задание 3. Задайте двумерный массив из целых чисел. 
// Сформируйте новый одномерный массив, состоящий из средних
// арифметических значений по строкам двумерного массива.
// Пример
// 2 3 4 3
// 4 3 4 1   ⇒ [ 3 3 5]
// 2 9 5 4

void Main()
{
    int row = ReadInt("Введите количество строк: ");
    int col = ReadInt("Введите количество колонок: ");
    int[,] matrix = GenereateMatrix(row, col, 0, 99);
    PrintMatrix(matrix);
    // можно сохранить массив в отдельную переменную
    // double[] answer = FindAverages(matrix);
    // PrintArray(answer);
    // а можно сделать вызов функции в функции
    PrintArray(FindAverages(matrix));

}

//напишем функцию, которая будет выводить нам массив
void PrintArray(double[] array)
{
    System.Console.WriteLine(string.Join(", ", array));
}  

// напишем функцию для возврата нового массива со среднеарифметическими
// значениями от каждой строки двумерного массива
double[] FindAverages(int [,] matrix)
{
    // объявляем новый массив, длина которого равна количеству строк в двумерном массиве
    double[] averages = new double[matrix.GetLength(0)];
    // далее проходимся по двумерному массиву
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            // в i-тый индекс нового массива прибавляем все элементв по порядку
            averages[i] += matrix[i, j];
        }
        // делим сумму всех элементов на количество столбцов, то есть на количество 
        // элементов, которое получется на i-том индексе
        // для округления возможного дробного среднего значения воспользуемся 
        // методом Math.Round(), который на вход принимает 2 элемента: 1 - это значение, 
        // которое нужно округлить, а 2 - это до которого числа после "," мы будем округлять
        averages[i] = Math.Round(averages[i] / matrix.GetLength(1), 2);
    }
    return averages;
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