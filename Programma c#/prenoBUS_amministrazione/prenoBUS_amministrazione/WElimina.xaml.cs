using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace prenoBUS_amministrazione
{
    /// <summary>
    /// Logica di interazione per WElimina.xaml
    /// </summary>
    public partial class WElimina : Window
    {
        CMySql_gestioneAccount mySql;
        public WElimina(CMySql_gestioneAccount mySql)
        {
            InitializeComponent();
            this.mySql = mySql;
        }
        private void btnElimina_Click(object sender, RoutedEventArgs e)
        {
            string login = username.Text;
            string pass = password.Text;
            if (login != "" && pass != "" && login != "Username" && pass != "Password")
            {
                if (mySql.eliminaUtente(login, pass))
                    MessageBox.Show("Utente eliminato con successo!");
                else
                    MessageBox.Show("Utente non presente / problema al database");
            }
            else
                MessageBox.Show("Dati mancanti!");
            

            username.Text = "Username";
            password.Text = "Password";
        }
        private void username_MouseEnter(object sender, MouseEventArgs e)
        {
            if(username.Text=="Username")
                username.Text = "";
        }

        private void password_MouseEnter(object sender, MouseEventArgs e)
        {
            if(password.Text=="Password")
                password.Text = "";
        }

        private void username_MouseLeave(object sender, MouseEventArgs e)
        {
            if (username.Text == "")
                username.Text = "Username";
        }

        private void password_MouseLeave(object sender, MouseEventArgs e)
        {
            if (password.Text == "")
                password.Text = "Password";
        }

        private void btnEsci_Click(object sender, RoutedEventArgs e)
        {
            MainWindow temp = new MainWindow();
            temp.Show();
            this.Close();
        }
    }
}
