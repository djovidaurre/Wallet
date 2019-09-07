const { setWorldConstructor } = require("cucumber");

class TransactionWorld {
  constructor() {
    this.result = 0;
    this.idBilletera = "";
    this.idTransaccion = "";
    this.monto = "";
    this.urlRegisterTransaccion = 'http://localhost/WebWallet/RegisterTransaction.aspx';
    this.newtrans = {};
    this.urlApiConsulTransaccion ='http://localhost/ApiWallet/api/v1.0/wallet/consult/transaction';
    this.regtrans = {};
    this.urlApiRegisterTransaccion ='http://localhost/ApiWallet/api/v1.0/wallet/register/transaction';
    
  }


  setToIdBilletera(string) {
    this.idBilletera = string;
  }

  setToIdTransaccion(string) {
    this.idTransaccion = string;
  }

  setToMonto(string) {
    this.monto = string;
  }

  setToNewTrans(int)
  {
    this.newtrans = {
      IdBilletera: int
    };
  }

  setToRegTrans(int,int2,int3)
  {
    this.regtrans = {
      IdBilletera: int,
      IdTipoTransaccion: int2,
      Monto: int3
    };
  }

  getToIdBilletera() {
    return this.idBilletera;
  }

  getToIdTransaccion() {
    return this.idTransaccion;
  }

  getToMonto() {
    return this.monto;
  }

  getUrlRegisterTransaccion()
  {
    return  this.urlRegisterTransaccion;
  }

  getUrlApiConsultTransaccion()
  {
    return  this.urlApiConsulTransaccion;
  }

  getUrlApiRegisterTransaccion()
  {
    return  this.urlApiRegisterTransaccion;
  }

  getToNewTrans(){
    return this.newtrans;
  }
  
  getToRegTrans()
  {
    return this.regTrans;
  }

}

setWorldConstructor(TransactionWorld);