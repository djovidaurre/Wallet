using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreWallet.Param
{
    public class TransactionParam
    {
        public long IdBilletera { get; set; }
        public byte IdTipoTransaccion { get; set; }
        public decimal Monto { get; set; }

      
    }
}
