using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prenoBUS_v1._0
{
    public class CData
    {
        string qrcode;
        int linea;
        public DateTime? inizioAbbonamento;
        public DateTime? fineAbbonamento;
        public CData(string qrcode, int linea, string inizioAbbonamento, string fineAbbonamento)
        {
            this.qrcode = qrcode;
            this.linea = linea;
            try
            {
                this.inizioAbbonamento = DateTime.ParseExact("inizioAbbonamento", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                this.fineAbbonamento = DateTime.ParseExact("fineAbbonamento", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            }
            catch(Exception)
            {
                this.inizioAbbonamento = null;
                this.fineAbbonamento = null;
            }
            
            
        }
    }
}
