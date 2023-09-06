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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            cbKapacitas.SelectedIndex = 0;
            cbAtviteliSeb.SelectedIndex = 0;
        }

        private void slAtviteliSeb_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbSliderValue.Content = Convert.ToInt32(slAtviteliSeb.Value);
        }

        private void btnSzamol_Click(object sender, RoutedEventArgs e)
        {

            if (Int32.TryParse(tbKapacitas.Text, out int kapacitas))
            {
                int atviteliSeb = Convert.ToInt32(slAtviteliSeb.Value);
                for (int i = 0; i < cbKapacitas.SelectedIndex; i++)
                {
                    kapacitas *= 1000;
                }
            
                for (int i = 0; i < cbAtviteliSeb.SelectedIndex; i++)
                {
                    atviteliSeb *= 1000;
                }

                int szamitas = kapacitas / atviteliSeb;

                TimeSpan t = TimeSpan.FromSeconds(szamitas);

                string eredmeny = string.Format("{0:D2}d:{1:D2}h:{2:D2}m:{3:D2}s",
                t.Days,
                t.Hours,
                t.Minutes,
                t.Seconds);
                lbEredmeny.Content = eredmeny;
            }
            else
            {
                MessageBox.Show("Adj megfelelő értékeket!");
            }
            

        }
    }
}
