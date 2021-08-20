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

        public ControlloBiglietti(int lineaBus,CMySQL_login mysql)
        {
            InitializeComponent();
            this.lineaBus = lineaBus;
            this.mysql = mysql;
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
            CData dati= mysql.controllaBiglietto(qr);
            if(dati==null)
                MessageBox.Show("Biglietto/Abbonamento non valido!");
            else
            {
                if (dati.inizioAbbonamento == null)
                {
                    if (!mysql.eliminaBiglietto(qr))
                        MessageBox.Show("Problema con il biglietto, riprova!");
                }
                else
                {
                    DateTime oggi = DateTime.Today;
                    if (!(oggi.Ticks > dati.inizioAbbonamento.Value.Ticks && oggi.Ticks < dati.fineAbbonamento.Value.Ticks))
                    {
                        MessageBox.Show("Abbonamento scaduto o non valido!");
                        mysql.eliminaBiglietto(qr)
                    }
                        
                }
            }
            

        }
    }
}
