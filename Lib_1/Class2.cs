using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_1
{
    public static class Matematik
    {
        /// <summary>
        /// Складывает числа, которые больше 5
        /// </summary>
        /// <param name="mas">Одномерный целочисленный массив</param>
        /// <returns>Целочисленное число, содержащие сумму</returns>
        public static int Sum(int[] mas)
        {
            int sum = 0;
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] > 5)
                {
                    sum += mas[i];
                }
            }
            return sum;
        }

        /// <summary>
        /// Вычесляет сумму целых чисел элементов строки
        /// </summary>
        /// <param name="mas">Двумерный целочисленный массив</param>
        /// <param name="k">Номер строки двумерного целочисленного массива</param>
        /// <returns>Целочисленное число, содержащие сумму</returns>
        public static int SumRow(int[,] mas, int k)
        {
            int sum = 0;
            k--;
            for (int i = 0; i < mas.GetLength(1); i++)
            {
                sum += mas[k, i];
            }
            return sum;
        }
    }
    public static class VisualArray
    {
        /// <summary>
        /// Метод создаёт элементы таблицы для одномерного массива
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <returns>Элементы таблицы</returns>
        public static DataTable ToDataTable<T>(this T[] arr)
        {
            var res = new DataTable();
            for (int i = 0; i < arr.Length; i++)
            {
                res.Columns.Add("col" + (i + 1), typeof(T));
            }
            var row = res.NewRow();
            for (int i = 0; i < arr.Length; i++)
            {
                row[i] = arr[i];
            }
            res.Rows.Add(row);
            return res;
        }

        /// <summary>
        /// Метод создаёт элементы таблицы для двумерного массива
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="matrix"></param>
        /// <returns>Элементы таблицы</returns>
        public static DataTable ToDataTable<T>(this T[,] matrix)
        {
            var res = new DataTable();
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                res.Columns.Add("col" + (i + 1), typeof(T));
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var row = res.NewRow();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    row[j] = matrix[i, j];
                }

                res.Rows.Add(row);
            }

            return res;
        }
    }
}
