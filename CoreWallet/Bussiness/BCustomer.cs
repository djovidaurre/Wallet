using CoreWallet.Param;
using CoreWallet.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using recurso = CoreWallet.Bussiness.Resource.ResourceCustomer;

namespace CoreWallet.Bussiness
{
    public class BCustomer
    {
        public CustomerDto RegisterCustomer(CustomerParam param)
        {
            var result = new CustomerDto();
            result.Response = false;

            try
            {
                #region Validaciones

                if (String.IsNullOrEmpty(param.FirstName))
                {
                    result.Messages.Add(new Error() { Message = recurso.FirstName });
                }

                if (String.IsNullOrEmpty(param.SurName))
                {
                    result.Messages.Add(new Error() { Message = recurso.SurName });
                }

                if (String.IsNullOrEmpty(param.Email))
                {
                    result.Messages.Add(new Error() { Message = recurso.Email });
                }

                if (result.Messages.Count == 0)
                {
                    result.Response = true;
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
