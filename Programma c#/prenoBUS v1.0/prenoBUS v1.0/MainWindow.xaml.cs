using System;
using System.Windows;
using System.Windows.Input;

namespace prenoBUS_v1._0
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
        CMySQL_login database_login;
        public MainWindow()
        {
            InitializeComponent();
            database_login = new CMySQL_login();
            connettiDatabase();
        }

        private void username_MouseEnter(object sender, MouseEventArgs e)
        {
            username.Text = "";
        }

        private void password_MouseEnter(object sender, MouseEventArgs e)
        {
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
        private void connettiDatabase()
        {
            bool check = database_login.connettiDatabase();
            while(!check)
            {
                MessageBoxResult result = MessageBox.Show("Connessione con database non riuscita, riprova", "Errore connessioone", MessageBoxButton.OKCancel);
                switch (result)
                {
                    case MessageBoxResult.OK:
                        check = database_login.connettiDatabase();
                        break;
                    case MessageBoxResult.Cancel:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            string login = username.Text;
            string pass = password.Text;
            bool check = false;
            check = database_login.controllaCredenziali(login, pass);
            if (check)
            {
                MessageBox.Show("Utente verificato!");
                SceltaLinea win = new SceltaLinea(database_login);
                win.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Utente non presente, riprova!");
                username.Text = "Username";
                password.Text = "Password";
            }
                

        }
    }
}
