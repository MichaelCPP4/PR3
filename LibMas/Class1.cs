using System;
using Microsoft.Win32;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Windows;

namespace LibMas_1
{
    public static class ArrayMetod
    {

        /// <summary>
        /// Метод заполняет одномерный массив рандомными числами
        /// </summary>
        /// <param name="n">Колличество элементов</param>
        /// <param name="firsLimit">Минимальное число для генерации чисел</param>
        /// <param name="lastLimit">Максимальное число для генерации чисел</param>
        /// <returns>Одномерный целочисленный массив</returns>
        public static int[] RandomMas(int n, int firsLimit, int lastLimit)
        {
            int[] array = new int[n];
            Random random = new Random();
            lastLimit++;
            for (int i = 0; i < array.Length; i++)
                array[i] = random.Next(firsLimit, lastLimit);
            return array;
        }


        /// <summary>
        /// Метод заполняет двумерный массив рандомными числами
        /// </summary>
        /// <param name="m">Число строк</param>
        /// <param name="n">Число столбцов</param>
        /// <param name="firsLimit">Минимальное число для генерации чисел</param>
        /// <param name="lastLimit">Максимальное число для генерации чисел</param>
        /// <returns>Двумерный целочисленный массив</returns>
        public static int[,] RandomMas(int m,int n, int firsLimit, int lastLimit)
        {
            int[,] array = new int[m,n];
            Random random = new Random();
            lastLimit++;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    array[i,j] = random.Next(firsLimit, lastLimit);
                }
            }

            return array;
        }

        /// <summary>
        /// Метод заполняет двумерный массив рандомными числами
        /// </summary>
        /// <param name="m">Число строк</param>
        /// <param name="n">Число столбцов</param>
        /// <returns>Двумерный целочисленный массив</returns>
        public static int[,] RandomMas(int m, int n)
        {
            int[,] array = new int[m, n];
            Random random = new Random();

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    array[i, j] = random.Next(1, 101);
                }
            }

            return array;
        }

        /// <summary>
        ///  Метод заполняет одномерный массив рандомными числами
        /// </summary>
        /// <param name="n">Целое число</param>
        /// <returns>Целочисленный одномерный массив</returns>
        public static int[] RandomMas(int n)
        {
            int[] array = new int[n];
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
                array[i] = random.Next(1, 101);
            return array;
        }

        /// <summary>
        /// Метод очищает массив
        /// </summary>
        /// <param name="array">Целочисленный массив</param>
        public static void Clear(ref int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = 0;
            }
        }

        /// <summary>
        /// Метод сохраняет одномерный массив в файл .txt
        /// </summary>
        /// <param name="mas">Одномерный целочисленный массив</param>
        public static void SaveMas(int[] mas)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "Текстовые файлы(*.txt)|*.txt|Все файлы(*.*)|*.*";
            save.FilterIndex = 2;
            save.Title = "Сохранение таблицы";

            if (save.ShowDialog() == true)
            {
                StreamWriter file = new StreamWriter(save.FileName);

                file.WriteLine(mas.Length);

                for (int i = 0; i < mas.Length; i++)
                {
                    file.WriteLine(mas[i]);
                }

                file.Close();
            }
        }
        /// <summary>
        /// Метод сохраняет двумерынй массив в файл .txt
        /// </summary>
        /// <param name="mas">двумерный целочисленный массив</param>
        public static void SaveMas(int[,] mas)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "Текстовые файлы(*.txt)|*.txt|Все файлы(*.*)|*.*";
            save.FilterIndex = 2;
            save.Title = "Сохранение таблицы";

            if (save.ShowDialog() == true)
            {
                StreamWriter file = new StreamWriter(save.FileName);

                file.WriteLine(mas.GetLength(0));
                file.WriteLine(mas.GetLength(1));

                for (int i = 0; i < mas.GetLength(0); i++)
                {
                    for (int j = 0; j < mas.GetLength(1); j++)
                    {
                        file.WriteLine(mas[i,j]);
                    }
                }

                file.Close();
            }
        }

        /// <summary>
        /// Метод открывает файл .txt и записывает данные в одномерный массив
        /// </summary>
        /// <param name="mas">Одномерный целочисленный массив</param>
        public static bool OpenMas(ref int[] mas)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.DefaultExt = ".txt";
            open.Filter = "Текстовые файлы(*.txt)|*.txt|Все файлы(*.*)|*.*";
            open.FilterIndex = 2;
            open.Title = "Открытие таблицы";

            if (open.ShowDialog() == true)
            {
                StreamReader file = new StreamReader(open.FileName);

                int length = Convert.ToInt32(file.ReadLine());

                mas = new int[length];

                for (int i = 0; i < mas.Length; i++)
                {
                    mas[i] = Convert.ToInt32(file.ReadLine());
                }

                file.Close();

                return true;
            }
            return false;
        }


        /// <summary>
        /// Метод открывает файл .txt и записывает данные в двумерный массив
        /// </summary>
        /// <param name="mas">Двумерный массив</param>
        /// <returns>Возвращает буллевую переменую, результат которой зависит от того, открыли файл или нет</returns>
        public static bool OpenMas(ref int[,] mas)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.DefaultExt = ".txt";
            open.Filter = "Текстовые файлы(*.txt)|*.txt|Все файлы(*.*)|*.*";
            open.FilterIndex = 2;
            open.Title = "Открытие таблицы";

            if (open.ShowDialog() == true)
            {
                StreamReader file = new StreamReader(open.FileName);

                int columns = Convert.ToInt32(file.ReadLine());
                int rows = Convert.ToInt32(file.ReadLine());

                mas = new int[columns, rows];

                for (int i = 0; i < mas.GetLength(0); i++)
                {
                    for (int j = 0; j < mas.GetLength(1); j++)
                    {
                        mas[i,j] = Convert.ToInt32(file.ReadLine());
                    }
                    //mas[i] = Convert.ToInt32(file.ReadLine());
                }

                file.Close();

                return true;
            }
            return false;
        }
    }
}