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
using LibMas_1;
using Lib_1;

namespace WPF_A2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[,] mas;

        public MainWindow()
        {
            InitializeComponent();
        }

        // Заполнение таблицы рандомными числами
        private void Create_Click(object sender, RoutedEventArgs e)
        {
            int n;
            int m;
            int min;
            int max;

            if (int.TryParse(textBoxM.Text, out m) && int.TryParse(textBoxN.Text, out n) && int.TryParse(textBoxMin.Text, out min) && int.TryParse(textBoxMax.Text, out max))
            {
                if (min<max)
                {
                    mas = ArrayMetod.RandomMas(m, n, min, max);
                    dataGrid.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;
                }
                else
                {
                    MessageBox.Show("минимальное число не может быть больше максимального!", "Error!!!");
                }
            }
            else if(int.TryParse(textBoxM.Text, out m) && int.TryParse(textBoxN.Text, out n))
            {
                mas = ArrayMetod.RandomMas(m, n);
                dataGrid.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;
            }
            else
            {
                MessageBox.Show("Введите данные!", "Error!!!");
            }

        }

        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            mas[e.Row.GetIndex(), e.Column.DisplayIndex] = Convert.ToInt32(((TextBox)e.EditingElement).Text);
        }

        // Событие которое производит вычисление выбранной пользователем строки 
        private void Calculate_ButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                textBoxResult.Text = Matematik.SumRow(mas, Convert.ToInt32(textBoxK.Text)).ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Вы не ввели данные или сделали это неправильно!", "Error!!!");
                return;
            }
        }

        // Очистить поля ввода, вывода и таблицу
        private void Clear_ButtonClick(object sender, RoutedEventArgs e)
        {

            if (mas != null)
            {
                textBoxM.Clear();
                textBoxN.Clear();
                textBoxResult.Clear();
                textBoxMin.Clear();
                textBoxMax.Clear();
                dataGrid.ItemsSource = null;
            }
        }

        // Выход из программы
        private void Exit_ButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        // Информация о программе
        private void Info_ClickButton(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Практическая работа №3 \n Выполнил Иванов Михаил ИСП-31  \n" + "Задание:" + "Дана матрица размера M × N и целое число K (1 ≤ K ≤ M)." +
                "Найти сумму и\r\nпроизведение элементов K-й строки данной матрицы.\n", "О программе");
        }

        // Сохранить массив в файл
        private void Save_ButtonClick(object sender, RoutedEventArgs e)
        {
            if (mas != null)
            {
                ArrayMetod.SaveMas( mas);
            }
        }

        // Открыть массив
        private void Open_ButtonClick(object sender, RoutedEventArgs e)
        {
            if (ArrayMetod.OpenMas(ref mas))
            {
                dataGrid.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;
            }
        }
    }
}