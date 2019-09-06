﻿using ApiWallet.Models;
using ApiWallet.Result;
using CoreWallet.Param;
using CoreWallet.Result;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace ApiWallet.Controllers
{
    [RoutePrefix("api/v1.0/wallet")]
    public class WalletController : ApiController
    {

        #region Atributos

        private WalletModel _model;

        #endregion


        #region Constructor

        public WalletController()
        {
            _model = new WalletModel();
        }

        #endregion

        /// <summary>
        /// Service to register customer
        /// </summary>
        /// <returns>Register Customer</returns>
        /// <remarks>
        /// Register customer
        /// </remarks>
        /// <response code="200">Operación Exitosa.</response>
        /// <response code="400">Solicitud Incorrecta.</response>        
        /// <response code="404">No Encontrado.</response>
        /// <response code="500">Error Interno de Servidor.</response>
        [AllowAnonymous]
        [ResponseType(typeof(OperationResult))]
        [HttpPost]
        [Route("register/customer")]
        public CustomerDto RegisterCustomer(CustomerParam param)
        {

            #region Proceso

            var result =  _model.RegisterCustomer(param);

            return result;

            #endregion

        }

        /// <summary>
        /// Service to register transaction
        /// </summary>
        /// <returns>Register transaction</returns>
        /// <remarks>
        /// Register transaction
        /// </remarks>
        /// <response code="200">Operación Exitosa.</response>
        /// <response code="400">Solicitud Incorrecta.</response>        
        /// <response code="404">No Encontrado.</response>
        /// <response code="500">Error Interno de Servidor.</response>
        [AllowAnonymous]
        [ResponseType(typeof(OperationResult))]
        [HttpPost]
        [Route("register/transaction")]
        public TransactionDto RegisterTransaction(TransactionParam param)
        {

            #region Proceso

            return _model.RegisterTransaction(param);

            #endregion

        }

        /// <summary>
        /// Service to consult transaction
        /// </summary>
        /// <returns>Consult transaction</returns>
        /// <remarks>
        /// Consult transaction
        /// </remarks>
        /// <response code="200">Operación Exitosa.</response>
        /// <response code="400">Solicitud Incorrecta.</response>        
        /// <response code="404">No Encontrado.</response>
        /// <response code="500">Error Interno de Servidor.</response>
        [AllowAnonymous]
        [ResponseType(typeof(OperationResult))]
        [HttpPost]
        [Route("consult/transaction")]
        public TransactionDto ConsultTransaction(ConsultTransactionParam param)
        {

            #region Proceso

            return  _model.ConsultTransaction(param);

            #endregion

        }

        /// <summary>
        /// Service to reset balance transaction
        /// </summary>
        /// <returns>Reset balance transaction</returns>
        /// <remarks>
        /// Reset balance transaction
        /// </remarks>
        /// <response code="200">Operación Exitosa.</response>
        /// <response code="400">Solicitud Incorrecta.</response>        
        /// <response code="404">No Encontrado.</response>
        /// <response code="500">Error Interno de Servidor.</response>
        [AllowAnonymous]
        [ResponseType(typeof(OperationResult))]
        [HttpPost]
        [Route("reset/balanceTransaction")]
        public TransactionDto ResetBalanceTransaction(ConsultTransactionParam param)
        {

            #region Proceso

            return _model.ResetBalanceTransaccion(param);

            #endregion

        }

    }
}
