using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebWallet.Entity
{
    public class RegistroBilletera
    {
        public long IdWallet { get; set; }
        public byte IdTypeTransaction { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }


    }
}