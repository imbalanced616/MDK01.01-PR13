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
using System.Windows.Shapes;
using Рылеев_ПР13.Classes;

namespace Рылеев_ПР13
{
    /// <summary>
    /// Логика взаимодействия для WindowAddWorker.xaml
    /// </summary>
    public partial class WindowAddWorker : Window
    {
        public WindowAddWorker()
        {
            InitializeComponent();
        }

        private void txbENTRANCE_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                txtEXPERIENCE.Text = (DateTime.Today.Year - int.Parse(txbENTRANCE.Text)).ToString();
            }
            catch
            {
                MessageBox.Show("Заполните поля!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnADD_Click(object sender, RoutedEventArgs e)
        {
            Worker worker = new Worker()
            {
                FIO = txbFIO.Text,
                POST = txbPOST.Text,
                ENTRANCE = int.Parse(txbENTRANCE.Text),
                EXPERIENCE = DateTime.Today.Year - int.Parse(txbENTRANCE.Text)
            };
            ConnectHelper.workers.Add(worker);
            this.Close();
        }
    }
}
