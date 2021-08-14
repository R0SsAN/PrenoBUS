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
        int lineaBus;
        public ControlloBiglietti(int lineaBus)
        {
            InitializeComponent();
            this.lineaBus = lineaBus;
        }
    }
}
