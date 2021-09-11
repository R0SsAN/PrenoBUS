using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace prenoBUS_v1._0
{
    /// <summary>
    /// Logica di interazione per ControlloBiglietti.xaml
    /// </summary>
    public partial class ControlloBiglietti : Window
    {
        CMySQL_login mysql;
        List<CData> listaPasseggeri;
        const int nPostiMax = 50;
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
            listaPasseggeri = new List<CData>();
            sld.Minimum = 10;
        }
        private void camSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            webCam.CameraIndex = camSelect.SelectedIndex;
        }

        private void QrWebCamControl_QrDecoded(object sender, string e)
        {
            btnEdit.Visibility = Visibility.Hidden;
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
                        if (dati.inizioAbbonamento.ToString("yyyy-M-d") == "1980-1-1")
                        {
                            if (!mysql.eliminaBiglietto(qr))
                                MessageBox.Show("Problema con il biglietto, riprova!");
                            else
                            {
                                listaPasseggeri.Add(dati);
                                diminuisciContatore();
                            }
                        }
                        else
                        {
                            DateTime oggi = DateTime.Today;
                            if (!(oggi.Ticks >= dati.inizioAbbonamento.Ticks && oggi.Ticks <= dati.fineAbbonamento.Ticks))
                            {
                                MessageBox.Show("Abbonamento scaduto o non valido!");
                                mysql.eliminaBiglietto(qr);
                            }
                            else
                            {
                                listaPasseggeri.Add(dati);
                                diminuisciContatore();
                            }
                                
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

        private void btnObliterati_Click(object sender, RoutedEventArgs e)
        {
            wLista temp = new wLista(listaPasseggeri);
            temp.Show();
        }


        private void sld_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lblNum.Content = (int)sld.Value;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            btnEdit.Visibility = Visibility.Hidden;
            lbln.Visibility = Visibility.Visible;
            lblNum.Visibility = Visibility.Visible;
            btnConf.Visibility = Visibility.Visible;
            sld.Visibility = Visibility.Visible;
        }

        private void btnConf_Click(object sender, RoutedEventArgs e)
        {
            nPostiDisponibili = (int)sld.Value;
            lPosti.Content = nPostiDisponibili.ToString();
            btnEdit.Visibility = Visibility.Visible;
            lbln.Visibility = Visibility.Hidden;
            lblNum.Visibility = Visibility.Hidden;
            btnConf.Visibility = Visibility.Hidden;
            sld.Visibility = Visibility.Hidden;
        }
    }
}
