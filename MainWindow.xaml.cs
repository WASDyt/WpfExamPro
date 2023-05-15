using Microsoft.Win32;
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
using WpfExam.Classes;

namespace WpfExam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowAddProtohype windowAdd = new WindowAddProtohype();
            windowAdd.ShowDialog();
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
         DtgListPreparate.ItemsSource = null;
        }

        private void open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if ((bool)openFileDialog.ShowDialog())
            {
                // получаем выбранный файл
                ConnectHelper.fileName = openFileDialog.FileName;
                ConnectHelper.ReadListFromFile(ConnectHelper.fileName);
                //ConnectHelper.ReadListFromFile(@"ListPreparates.txt");
            }
            else
                return;
            DtgListPreparate.ItemsSource = ConnectHelper.performances.ToList();
        }
        private void save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if ((bool)saveFileDialog.ShowDialog())
            {
                string file = saveFileDialog.FileName;
                ConnectHelper.SaveListToFile(file);
            }
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var resMessage = MessageBox.Show("Удалить запись?", "Подтверждение",
                MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resMessage == MessageBoxResult.Yes)
            {
                int ind = DtgListPreparate.SelectedIndex;
                ConnectHelper.performances.RemoveAt(ind);
                DtgListPreparate.ItemsSource = ConnectHelper.performances.ToList();
                ConnectHelper.SaveListToFile(ConnectHelper.fileName);
            }

        }
    }
}
