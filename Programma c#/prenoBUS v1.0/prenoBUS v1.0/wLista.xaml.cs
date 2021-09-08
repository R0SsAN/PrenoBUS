using System.Collections.Generic;
using System.Windows;

namespace prenoBUS_v1._0
{
    /// <summary>
    /// Logica di interazione per wLista.xaml
    /// </summary>
    public partial class wLista : Window
    {
        public wLista(List<CData> lista)
        {
            InitializeComponent();
            grid.ItemsSource = lista;

        }
    }
}
