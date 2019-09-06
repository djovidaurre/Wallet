using ApiWallet.Result;
using CoreWallet.Bussiness;
using CoreWallet.Param;
using CoreWallet.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ApiWallet.Models
{
    public class WalletModel
    {
        #region Atributos

        BCustomer _customer;

        #endregion

        #region Constructor 

        public WalletModel()
        {
            _customer = new BCustomer();
        }

        #endregion

        #region Procesos

        public CustomerDto RegisterCustomer(CustomerParam param)
        {

            var result = new CustomerDto();

            try
            {

                #region Proceso

                result = _customer.RegisterCustomer(param);

                #endregion

            }
            catch (Exception Ex)
            {
                result.Messages.Add(new Error() { Message = Ex.Message });
            }

            return result;
        }

        #endregion
    }
}