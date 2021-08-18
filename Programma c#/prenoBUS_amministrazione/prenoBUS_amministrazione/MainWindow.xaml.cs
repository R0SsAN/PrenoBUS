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

namespace prenoBUS_amministrazione
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CMySql_gestioneAccount mysql;
        public MainWindow()
        {
            InitializeComponent();
            mysql = new CMySql_gestioneAccount();
            connettiDatabase();
        }


        private void btnCrea_Click(object sender, RoutedEventArgs e)
        {
            WCrea temp = new WCrea(mysql);
            temp.Show();
            this.Close();
        }

        private void btnElimina_Click(object sender, RoutedEventArgs e)
        {
            WElimina temp = new WElimina(mysql);
            temp.Show();
            this.Close();
        }
        private void connettiDatabase()
        {
            bool check = mysql.connettiDatabase();
            while (!check)
            {
                MessageBoxResult result = MessageBox.Show("Connessione con database non riuscita, riprova", "Errore connessioone", MessageBoxButton.OKCancel);
                switch (result)
                {
                    case MessageBoxResult.OK:
                        check = mysql.connettiDatabase();
                        break;
                    case MessageBoxResult.Cancel:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
