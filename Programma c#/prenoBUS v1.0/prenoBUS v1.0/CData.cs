using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prenoBUS_v1._0
{
    public class CData
    {
        public string qrcode { get; set; }
        public int linea { get; set; }
        public DateTime inizioAbbonamento { get; set; }
        public DateTime fineAbbonamento { get; set; }
        public CData(string qrcode, int linea, string inizioAbbonamento, string fineAbbonamento)
        {
            this.qrcode = qrcode;
            this.linea = linea;
            try
            {
                this.inizioAbbonamento = DateTime.ParseExact(inizioAbbonamento, "yyyy-M-d", CultureInfo.InvariantCulture);
                this.fineAbbonamento = DateTime.ParseExact(fineAbbonamento, "yyyy-M-d", CultureInfo.InvariantCulture);
            }
            catch(Exception)
            {
                this.inizioAbbonamento = DateTime.ParseExact("1980-1-1", "yyyy-M-d", CultureInfo.InvariantCulture);
                this.fineAbbonamento = DateTime.ParseExact("1980-1-1", "yyyy-M-d", CultureInfo.InvariantCulture);
            }
        }
    }
}
