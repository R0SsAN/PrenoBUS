using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace prenoBUS_v1._0
{
    /// <summary>
    /// Logica di interazione per ControlloBiglietti.xaml
    /// </summary>
    public partial class ControlloBiglietti : Window
    {
        CMySQL_login mysql;
        const int nPostiMax = 30;
        int lineaBus;
        int nPostiDisponibili;
        string ultimoqr;

        public ControlloBiglietti(int lineaBus,CMySQL_login mysql)
        {
            InitializeComponent();
            this.lineaBus = lineaBus;
            this.mysql = mysql;
            ultimoqr = "";
            nPostiDisponibili = nPostiMax;
            linea.Content = "LINEA C" + lineaBus.ToString();
        }
        private void camSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            webCam.CameraIndex = camSelect.SelectedIndex;
        }

        private void QrWebCamControl_QrDecoded(object sender, string e)
        {
            if (nPostiDisponibili > 0)
                controllaBiglietto(e);
            else
                MessageBox.Show("Tutti i posti disponibili sono stati occupati!");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            camSelect.ItemsSource = webCam.CameraNames;
        }
        private void controllaBiglietto(string qr)
        {
            if(qr!=ultimoqr)
            {
                CData dati = mysql.controllaBiglietto(qr);
                if (dati == null)
                    MessageBox.Show("Biglietto/Abbonamento non valido!");
                else
                {
                    if (dati.linea == lineaBus)
                    {
                        if (dati.inizioAbbonamento == null)
                        {
                            if (!mysql.eliminaBiglietto(qr))
                                MessageBox.Show("Problema con il biglietto, riprova!");
                            else
                                diminuisciContatore();
                        }
                        else
                        {
                            DateTime oggi = DateTime.Today;
                            if (!(oggi.Ticks >= dati.inizioAbbonamento.Value.Ticks && oggi.Ticks <= dati.fineAbbonamento.Value.Ticks))
                            {
                                MessageBox.Show("Abbonamento scaduto o non valido!");
                                mysql.eliminaBiglietto(qr);
                            }
                            else
                                diminuisciContatore();
                        }
                    }
                    else
                        MessageBox.Show("Biglietto/Abbonamento non corretto (Linea sbagliata)!");
                }
                ultimoqr = qr;
            }
        }
        private void diminuisciContatore()
        {
            nPostiDisponibili--;
            lPosti.Content = nPostiDisponibili.ToString();
            if (nPostiDisponibili < 10)
                lPosti.Foreground = Brushes.Orange;
            Thread th = new Thread(this.threadCheck);
            th.Start();
        }

        private void btnEsci_Click(object sender, RoutedEventArgs e)
        {
            SceltaLinea temp = new SceltaLinea(mysql);
            temp.Show();
            this.Close();
        }
        private void threadCheck()
        {
            Thread t = new Thread(this.accendi);
            t.Start();
            Thread.Sleep(1500);
            t = new Thread(this.spegni);
            t.Start();
        }
        private void accendi()
        {
            if (!CheckAccess())
                Dispatcher.Invoke(() => { accendi(); });
            else
                check.Visibility = Visibility.Visible;
        }
        private void spegni()
        {
            if (!CheckAccess())
                Dispatcher.Invoke(() => { spegni(); });
            else
                check.Visibility = Visibility.Hidden;
        }
    }
}
