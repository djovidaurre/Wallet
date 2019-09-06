using CoreWallet.Param;
using CoreWallet.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using recurso = CoreWallet.Bussiness.Resource.ResourceTransaction;

namespace CoreWallet.Bussiness
{
    public class BTransaction
    {
        #region Atributos

        public decimal _balance;

        #endregion

        #region Constructor

        public BTransaction()
        {
            _balance = 0;
        }

        #endregion

        public TransactionDto RegisterTransaction(TransactionParam param)
        {
            var result = new TransactionDto();
            result.Response = false;

            try
            {
                #region Validaciones

                if (param.IdBilletera<0)
                {
                    result.Messages.Add(new Error() { Message = recurso.IdBilletera });
                }

                if (param.IdTipoTransaccion < 0)
                {
                    result.Messages.Add(new Error() { Message = recurso.IdTransaccion });
                }

                if (param.Monto== 0)
                {
                    result.Messages.Add(new Error() { Message = recurso.Monto });
                }

                if (result.Messages.Count == 0)
                {
                    result.Response = true;
                    _balance = _balance + param.Monto;
                    result.Balance = _balance;

                }


                #endregion
            }
            catch (Exception ex)
            {
                result.Messages.Add(new Error() { Message = ex.Message });

            }
            return result;

        }
    }
}
