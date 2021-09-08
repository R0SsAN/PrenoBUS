using System.Windows;

namespace prenoBUS_v1._0
{
    /// <summary>
    /// Logica di interazione per SceltaLinea.xaml
    /// </summary>
    public partial class SceltaLinea : Window
    {
        CMySQL_login mysql;
        int lineaBus;
        public SceltaLinea(CMySQL_login mysql)
        {
            InitializeComponent();
            this.mysql = mysql;
            lineaBus = 0;
        }

        private void avvioControllo()
        {
            ControlloBiglietti win = new ControlloBiglietti(lineaBus,mysql);
            win.Show();
            this.Close();
        }

        private void b40_Click(object sender, RoutedEventArgs e)
        {
            lineaBus = 40;
            avvioControllo();
        }

        private void b43_Click(object sender, RoutedEventArgs e)
        {
            lineaBus = 43;
            avvioControllo();
        }

        private void b45_Click(object sender, RoutedEventArgs e)
        {
            lineaBus = 45;
            avvioControllo();
        }

        private void b46_Click(object sender, RoutedEventArgs e)
        {
            lineaBus = 46;
            avvioControllo();
        }

        private void b47_Click(object sender, RoutedEventArgs e)
        {
            lineaBus = 47;
            avvioControllo();
        }

        private void b49_Click(object sender, RoutedEventArgs e)
        {
            lineaBus = 49;
            avvioControllo();
        }

        private void b50_Click(object sender, RoutedEventArgs e)
        {
            lineaBus = 50;
            avvioControllo();
        }

        private void b52_Click(object sender, RoutedEventArgs e)
        {
            lineaBus = 52;
            avvioControllo();
        }

        private void b60_Click(object sender, RoutedEventArgs e)
        {
            lineaBus = 60;
            avvioControllo();
        }

        private void b80_Click(object sender, RoutedEventArgs e)
        {
            lineaBus = 80;
            avvioControllo();
        }

        private void b82_Click(object sender, RoutedEventArgs e)
        {
            lineaBus = 82;
            avvioControllo();
        }

        private void b91_Click(object sender, RoutedEventArgs e)
        {
            lineaBus = 91;
            avvioControllo();
        }
        
    }
}
