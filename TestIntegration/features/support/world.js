const { setWorldConstructor } = require("cucumber");

class TransactionWorld {
  constructor() {
    this.result = 0;
    this.idBilletera = "";
    this.idTransaccion = "";
    this.monto = "";
    this.urlTransaccion = 'http://localhost/WebWallet/RegisterTransaction.aspx';
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

  getToIdBilletera() {
    return this.idBilletera;
  }

  getToIdTransaccion() {
    return this.idTransaccion;
  }

  getToMonto() {
    return this.monto;
  }

  getUrlTransaccion()
  {
    return  this.urlTransaccion;
  }


}

setWorldConstructor(TransactionWorld);