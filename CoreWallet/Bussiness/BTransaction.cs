﻿using CoreWallet.Helper;
using CoreWallet.Param;
using CoreWallet.Result;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using recurso = CoreWallet.Bussiness.Resource.ResourceTransaction;
using recursoBD = CoreWallet.Bussiness.Resource.ResourceUtil;

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
                    var register =  BDFile.LeeArchivo(recursoBD.UrlFile);
                    decimal balance = 0;
                    if (!String.IsNullOrWhiteSpace(register))
                    {
                        balance = Convert.ToDecimal(register);
                    }

                    result.Amount = param.Monto;
                    _balance = balance + param.Monto;
                    BDFile.EscribeEnArchivo(_balance.ToString(), recursoBD.UrlFile);
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

        public TransactionDto ConsultTransaction(ConsultTransactionParam param)
        {
            var result = new TransactionDto();
            result.Response = false;

            try
            {
                #region Validaciones

                if (param.IdBilletera < 0)
                {
                    result.Messages.Add(new Error() { Message = recurso.IdBilletera });
                }

                if (result.Messages.Count == 0)
                {
                    result.Response = true;
                    var register = BDFile.LeeArchivo(recursoBD.UrlFile);
                    decimal balance = 0;
                    if (!String.IsNullOrWhiteSpace(register))
                    {
                        balance = Convert.ToDecimal(register);
                    }
                    _balance = balance;
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

        public TransactionDto ResetBalanceTransaction(ConsultTransactionParam param)
        {
            var result = new TransactionDto();
            result.Response = false;

            try
            {
                #region Validaciones

                if (param.IdBilletera < 0)
                {
                    result.Messages.Add(new Error() { Message = recurso.IdBilletera });
                }

                if (result.Messages.Count == 0)
                {
                    result.Response = true;
                    BDFile.EscribeEnArchivo("", recursoBD.UrlFile);
                    result.Balance = 0;

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
