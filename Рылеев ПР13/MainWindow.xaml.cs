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
using Рылеев_ПР13.Classes;

namespace Рылеев_ПР13
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ConnectHelper.workers.Add(new Worker("Иванов А.П.", "Сантехник", 2006));
            ConnectHelper.workers.Add(new Worker("Яковлев П.Л.", "Охранник", 2002));
            ConnectHelper.workers.Add(new Worker("Петров М.И.", "Бухгалтер", 2009));
            ConnectHelper.workers.Add(new Worker("Леонидов Д.Ю.", "Менеджер", 2017));
            ConnectHelper.workers.Add(new Worker("Сидоров С.С.", "Кассир", 2013));
            ConnectHelper.workers.Add(new Worker("Рылеев А.Ю.", "Программист", 2020));
            ConnectHelper.workers.Add(new Worker("Зайцева В.Л.", "Маркетолог", 2007));
            ConnectHelper.workers.Add(new Worker("Самойлова А.К.", "Повар", 2013));
            ConnectHelper.workers.Add(new Worker("Фадеев И.С.", "Дизайнер", 2015));
            ConnectHelper.workers.Add(new Worker("Потапов В.А.", "Слесарь", 1999));
            ConnectHelper.workers.Add(new Worker("Алёшина В.А.", "Юрист", 1997));
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            DtgListWorkers.ItemsSource = ConnectHelper.workers.ToList();
            txbSearch.Text = "";
            txbSearch.Text = "";
            rbUp.IsChecked = false;
            rbDown.IsChecked = false;
            cmbFilter.SelectedItem = null;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (DtgListWorkers.ItemsSource == null)
            {
                MessageBox.Show("Сперва выведите список!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                WindowAddWorker windowAdd = new WindowAddWorker();
                windowAdd.ShowDialog();
                if (ConnectHelper.workers.Count() > DtgListWorkers.Items.Count)
                    MessageBox.Show("Новый работник добавлен в список!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                DtgListWorkers.ItemsSource = ConnectHelper.workers.ToList();
            }
        }

        private void txbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (DtgListWorkers.ItemsSource != null)
            {
                DtgListWorkers.ItemsSource = ConnectHelper.workers.Where(x => x.FIO.ToLower().Contains(txbSearch.Text.ToLower())).ToList();
            }
        }

        private void btnClearAll_Click(object sender, RoutedEventArgs e)
        {
            DtgListWorkers.ItemsSource = null;
            txbSearch.Text = "";
            rbUp.IsChecked = false;
            rbDown.IsChecked = false;
            cmbFilter.SelectedItem = null;
        }

        private void rbUp_Checked(object sender, RoutedEventArgs e)
        {
            if (DtgListWorkers.ItemsSource == null)
            {
                MessageBox.Show("Сперва выведите список!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
                rbUp.IsChecked = false;
            }
            else DtgListWorkers.ItemsSource = ConnectHelper.workers.OrderBy(x => x.FIO).ToList();
        }

        private void rbDown_Checked(object sender, RoutedEventArgs e)
        {
            if (DtgListWorkers.ItemsSource == null)
            {
                MessageBox.Show("Сперва выведите список!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
                rbDown.IsChecked = false;
            }
            else DtgListWorkers.ItemsSource = ConnectHelper.workers.OrderByDescending(x => x.FIO).ToList();
        }

        private void cmbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbFilter.SelectedIndex == 0)
            {
                if (DtgListWorkers.ItemsSource != null)
                {
                    DtgListWorkers.ItemsSource = ConnectHelper.workers.Where(x => x.EXPERIENCE >= 0 && x.EXPERIENCE <= 10).ToList();
                    if (ConnectHelper.workers.Where(x => x.EXPERIENCE >= 0 && x.EXPERIENCE <= 10).Count() > 0)
                    {
                        MessageBox.Show("Выведен список работников со стажем от 0 до 10.", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Работников со стажем от 0 до 10 не обнаружено!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    cmbFilter.SelectedItem = null;
                    MessageBox.Show("Сперва выведите список!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            if (cmbFilter.SelectedIndex == 1)
            {
                if (DtgListWorkers.ItemsSource != null)
                {
                    DtgListWorkers.ItemsSource = ConnectHelper.workers.Where(x => x.EXPERIENCE >= 11 && x.EXPERIENCE <= 20).ToList();
                    if (ConnectHelper.workers.Where(x => x.EXPERIENCE >= 11 && x.EXPERIENCE <= 20).Count() > 0)
                    {
                        MessageBox.Show("Выведен список работников со стажем от 11 до 20.", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Работников со стажем от 11 до 20 не обнаружено!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    cmbFilter.SelectedItem = null;
                    MessageBox.Show("Сперва выведите список!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            if (cmbFilter.SelectedIndex == 2)
            {
                if (DtgListWorkers.ItemsSource != null)
                {
                    DtgListWorkers.ItemsSource = ConnectHelper.workers.Where(x => x.EXPERIENCE >= 21).ToList();
                    if (ConnectHelper.workers.Where(x => x.EXPERIENCE >= 21).Count() > 0)
                    {
                        MessageBox.Show("Выведен список работников со стажем от 21 и более.", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Работников со стажем от 21 и более не обнаружено!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    cmbFilter.SelectedItem = null;
                    MessageBox.Show("Сперва выведите список!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
    }
}
