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
    /// Logica di interazione per WCrea.xaml
    /// </summary>
    public partial class WCrea : Window
    {
        CMySql_gestioneAccount mySql;
        public WCrea(CMySql_gestioneAccount mySql)
        {
            InitializeComponent();
            this.mySql = mySql;
        }

        private void btnCrea_Click(object sender, RoutedEventArgs e)
        {
            string login = username.Text;
            string pass = password.Text;
            if (login != "" && pass != "" && login != "Username" && pass != "Password")
            {
                if (mySql.creaUtente(login, pass))
                    MessageBox.Show("Utente creato con successo!");
                else
                    MessageBox.Show("Utente già presente / problema al database");
            }
            else
                MessageBox.Show("Dati mancanti!");
            username.Text = "Username";
            password.Text = "Password";

        }

        private void btnEsci_Click(object sender, RoutedEventArgs e)
        {
            MainWindow temp = new MainWindow();
            temp.Show();
            this.Close();
        }
        private void username_MouseEnter(object sender, MouseEventArgs e)
        {
            if (username.Text == "Username")
                username.Text = "";
        }

        private void password_MouseEnter(object sender, MouseEventArgs e)
        {
            if (password.Text == "Password")
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
    }
}
