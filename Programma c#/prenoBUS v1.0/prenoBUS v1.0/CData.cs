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
        public string qrcode;
        public int linea;
        public DateTime? inizioAbbonamento;
        public DateTime? fineAbbonamento;
        public CData(string qrcode, int linea, string inizioAbbonamento, string fineAbbonamento)
        {
            this.qrcode = qrcode;
            this.linea = linea;
            try
            {
                this.inizioAbbonamento = DateTime.ParseExact(inizioAbbonamento, "d/M/yyyy", CultureInfo.InvariantCulture);
                this.fineAbbonamento = DateTime.ParseExact(fineAbbonamento, "d/M/yyyy", CultureInfo.InvariantCulture);
            }
            catch(Exception)
            {
                this.inizioAbbonamento = null;
                this.fineAbbonamento = null;
            }
            
            
        }
    }
}
