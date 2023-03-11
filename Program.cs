// Задача 54: Задайте двумерный массив. Напишите программу, 
// которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

Console.Write("Введите количество строк массива:");
int R = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите количество столбцов массива:");
int C = Convert.ToInt32(Console.ReadLine());

// 1. Создать массив
int[,] resultMatrix = GetMatrix(R, C, 0, 100);

// 2. Посмотрим на нашу матрицу
PrintMatrix(resultMatrix);

// 3. Упорядочивание по убыванию элементов в каждой строке двумерного массива
SortMaxToMin(resultMatrix);
Console.WriteLine($"Массив с упорядоченными по убываюнию элементами \nв каждой строке:");
PrintMatrix(resultMatrix);

/// <summary>
/// Метод, заполняющий двумерный массив рандомными числами
/// </summary>
/// <param name="rows">количество строк</param>
/// <param name="cols">количество столбцов</param>
/// <param name="minValue">минимальное число диапазона случайных чисел</param>
/// <param name="maxValue">максимальное число диапазона случайных чисел</param>
/// <returns></returns>
int[,] GetMatrix(int rows, int cols, int minValue, int maxValue)
{
    int[,] matrix = new int[rows, cols]; 
    for (int i = 0; i < matrix.GetLength(0); i++)  
    {
        for (int j = 0; j < matrix.GetLength(1); j++) 
        {
            matrix[i, j] = new Random().Next(minValue, maxValue + 1);
        }
    }
    return matrix; 
}

/// <summary>
/// Метод, который упорядочивает по убыванию элементы 
/// в каждой строке двумерного массива
/// </summary>
/// <param name="matrix">имя массива</param>
void SortMaxToMin(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            for (int k = 0; k < matrix.GetLength(1) - 1; k++)
            {
                if (matrix[i, k] < matrix[i, k + 1])
                {
                    int temp = matrix[i, k + 1];
                    matrix[i, k + 1] = matrix[i, k];
                    matrix[i, k] = temp;
                }
            }
        }
    }
}

/// <summary>
/// Метод, который выводит двумерный массив на экран
/// </summary>
/// <param name="matr">имя массива</param>
void PrintMatrix(int[,] matr)
{
    for (int i = 0; i < matr.GetLength(0); i++) 
    {
        for (int m = 0; m < matr.GetLength(1); m++) 
        {
            Console.Write(matr[i, m] + "\t"); 
        }
        Console.WriteLine();
    }
}



// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, 
// которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке 
// и выдаёт номер строки с наименьшей суммой элементов: 1 строка

Console.Write("Введите количество строк массива:");
int R = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите количество столбцов массива:");
int C = Convert.ToInt32(Console.ReadLine());

int[,] resultMatrix = GetMatrix(R, C, 0, 100);

PrintMatrix(resultMatrix);
Console.WriteLine();
GetMinSumRow(resultMatrix);

int[,] GetMatrix(int rows, int cols, int minValue, int maxValue)
{
    int[,] matrix = new int[rows, cols]; 
    for (int i = 0; i < matrix.GetLength(0); i++)  
    {
        for (int j = 0; j < matrix.GetLength(1); j++) 
        {
            matrix[i, j] = new Random().Next(minValue, maxValue + 1);
        }
    }
    return matrix; 
}

void PrintMatrix(int[,] matr)
{
    for (int i = 0; i < matr.GetLength(0); i++) 
    {
        for (int m = 0; m < matr.GetLength(1); m++) 
        {
            Console.Write(matr[i, m] + "\t"); 
        }
        Console.WriteLine();
    }
}

/ <summary>
/ Метод поиска суммы элементов в строке и вывода строки с наименьшей суммой
/ </summary>
/ <param name="matrix">имя массива</param>
void GetMinSumRow (int[,] matrix)
{
    int minRow = 0;
    int minSumRow = 0;
    int sumRow = 0;
    for (int i = 0; i < matrix.GetLength(1); i++)
    {
        minRow += matrix[0, i];
    }
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++) sumRow += matrix[i, j];
        if (sumRow < minRow)
        {
            minRow = sumRow;
            minSumRow = i;
        }
        sumRow = 0;
    }
    Console.Write($"Наименьшая сумма элементов в {minSumRow + 1} строке");
}


// Задача 58: Задайте две матрицы. Напишите программу, 
// которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

Console.Write("Введите количество строк массива:");
int rows = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите количество столбцов массива:");
int columns = Convert.ToInt32(Console.ReadLine());

int[,] array = new int[rows, columns];
int[,] secondArray = new int[rows, columns];
int[,] resultArray = new int[rows, columns];

FillArray(array);
PrintArray(array);

Console.WriteLine();

FillArray(secondArray);
PrintArray(secondArray);

Console.WriteLine();

if (array.GetLength(0) != secondArray.GetLength(1))
{
    Console.WriteLine("Нельзя перемножить эти две матрицы");
    return;
}
for (int i = 0; i < array.GetLength(0); i++)
{
    for (int j = 0; j < secondArray.GetLength(1); j++)
    {
        resultArray[i, j] = 0;
        for (int k = 0; k < array.GetLength(1); k++)
        {
            resultArray[i, j] += array[i, k] * secondArray[k, j];
        }
    }
}

PrintArray(resultArray);

void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++) 
    {
        for (int m = 0; m < array.GetLength(1); m++) 
        {
            Console.Write(array[i, m] + "\t"); 
        }
        Console.WriteLine();
    }
}


void FillArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = new Random().Next(1, 100);
        }
    }
}


// Задача 60. Сформируйте трёхмерный массив из неповторяющихся 
// двузначных чисел. Напишите программу, которая будет построчно 
// выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

int[,,] array3D = new int[2, 2, 2];
FillArray(array3D);
PrintIndex(array3D);

/// <summary>
/// Метод заполнения ьрехмерного массива неповторяющимися числами
/// </summary>
/// <param name="array">имя массива</param>
void FillArray(int[,,] array)
{
    int count = 10;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                array[k, i, j] += count;
                count += 3;
            }
        }
    }
}

/// <summary>
/// Метод вывода элементов трехмерного массива и их индексов
/// </summary>
/// <param name="matrix">имя массива</param>
void PrintIndex(int[,,] matrix)
{
    for (int i = 0; i < array3D.GetLength(0); i++)
    {
        for (int j = 0; j < array3D.GetLength(1); j++)
        {
            Console.WriteLine();
            for (int k = 0; k < array3D.GetLength(2); k++)
            {
                Console.Write($"{array3D[i, j, k]}({i},{j},{k}) ");
            }
        }
    }
}