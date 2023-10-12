using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.IO;
using System;

namespace dz5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("номер 1");
            string lines = File.ReadAllText(@"C:\Users\user\Desktop\text.txt");
            int vowelsCount = 0;
            int consonantsCount = 0;
            string vowels = "ёуеыаоэяию";
            string consonants = "йцкнгшщзхфвпрлджчсмтб";
            for (int i = 0; i < lines.Length; i++)
            {
                if (char.IsLetter(lines[i]))
                {
                    for (int v = 0; v < vowels.Length; v++)
                    {
                        if (lines[i] == vowels[v])
                        {
                            vowelsCount++;
                            break;
                        }
                    }

                    for (int c = 0; c < consonants.Length; c++)
                    {
                        if (lines[i] == consonants[c])
                        {
                            consonantsCount++;
                            break;
                        }
                    }
                }
            }

            Console.WriteLine($"гласных-{vowelsCount}, согласных-{consonantsCount}");

            Console.WriteLine("\nномер 2");
            int rowsA = 2, colsA = 3;
            int rowsB = 3, colsB = 4;

            int[,] matrixA = {
                {1, 2, 3},
                {4, 5, 6}
            };

            int[,] matrixB = {
                {7, 8, 9, 10},
                {11, 12, 13, 14},
                {15, 16, 17, 18}
            };
            int[,] resultMatrix = MultiplyMatrices(matrixA, matrixB, rowsA, colsA, rowsB, colsB);

            PrintMatrix(resultMatrix);

            Console.WriteLine("\nномер 3");
            int[,] temperature = GenerateRandomTemperatures();
            double[] averageTemperatures = CalculateAverageTemperatures(temperature);
            PrintMonthlyAverages(averageTemperatures);
            Array.Sort(averageTemperatures);
            foreach (var avgTemp in averageTemperatures)
                Console.WriteLine(avgTemp);

            Console.WriteLine("\nномер 6.1");
            string lines1 = File.ReadAllText(@"C:\Users\user\Desktop\text.txt");
            List<char> vowels1 = new List<char> { 'ё', 'у', 'е', 'ы', 'а', 'о', 'э', 'я', 'и', 'ю' };
            List<char> consonants1 = new List<char> { 'й', 'ц', 'к', 'н', 'г', 'ш', 'щ', 'з', 'х', 'ф', 'в', 'п', 'р', 'л', 'д', 'ж', 'ч', 'с', 'м', 'т', 'б' };

            int vowelsCount1 = 0;
            int consonantsCount1 = 0;

            for (int i = 0; i < lines1.Length; i++)
            {
                if (char.IsLetter(lines1[i]))
                {
                    if (vowels1.Contains(char.ToLower(lines1[i])))
                    {
                        vowelsCount1++;
                    }
                    else if (consonants1.Contains(char.ToLower(lines1[i])))
                    {
                        consonantsCount1++;
                    }
                }
            }

            Console.WriteLine($"гласных-{vowelsCount1}, согласных-{consonantsCount1}");


            Console.ReadKey();
        }
        static int[,] MultiplyMatrices(int[,] matrixA, int[,] matrixB, int rowsA, int colsA, int rowsB, int colsB)
        {
            if (colsA != rowsB)
            {
                throw new ArgumentException("невозможно умножить матрицы");
            }

            int[,] result = new int[rowsA, colsB];

            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsB; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < colsA; k++)
                    {
                        sum += matrixA[i, k] * matrixB[k, j];
                    }
                    result[i, j] = sum;
                }
            }

            return result;
        }
        static void PrintMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        static int[,] GenerateRandomTemperatures()
        {
            Random rand = new Random();
            int[,] temperature = new int[12, 30];

            for (int month = 0; month < 12; month++)
            {
                for (int day = 0; day < 30; day++)
                {
                    temperature[month, day] = rand.Next(-10, 31);
                }
            }
            return temperature;
        }
        static double[] CalculateAverageTemperatures(int[,] temperature)
        {
            double[] averageTemperatures = new double[12];

            for (int month = 0; month < 12; month++)
            {
                double sum = 0;
                for (int day = 0; day < 30; day++)
                {
                    sum += temperature[month, day];
                }
                averageTemperatures[month] = sum / 30.0;
            }

            return averageTemperatures;
        }
        static void PrintMonthlyAverages(double[] averageTemperatures)
        {
            Console.WriteLine("средние температуры для каждого месяца:");
            for (int month = 0; month < 12; month++)
            {
                Console.WriteLine($"месяц {month + 1}: {averageTemperatures[month]:F2} градусов Цельсия");
            }
        }
    }
}
