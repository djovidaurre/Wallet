using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public class TransactionParam
    {
        public long IdBilletera { get; set; }
        public byte IdTipoTransaccion { get; set; }
        public decimal Monto { get; set; }
    }
}
