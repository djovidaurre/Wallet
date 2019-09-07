const { Given, When, Then } = require('cucumber')
const { expect } = require('chai')
const httpClient = require('request-promise')


let httpOptions = {};
let TransctionResponse = undefined;

Given('Los siguientes datos IdWallet {int}  IdtypeTransaction {int} Amount {int}', function (int, int2, int3) {
    // Write code here that turns the phrase above into concrete actions
    this.setToRegTrans(int,int2,int3);
  });

  When('Preparo el JSON de los datos', function () {
    // Write code here that turns the phrase above into concrete actions
    console.log('DONE');

    var json =JSON.stringify(this.getToRegTrans());
    httpOptions = {
      method: 'POST',
      uri: this.getUrlApiRegisterTransaccion(),
      json: true,
      body: json,
      resolveWithFullResponse: true
    };
  });

  Then('Hago un request POST hacia el url tran con los datos', async function () {
    // Write code here that turns the phrase above into concrete actions
    await httpClient(httpOptions)
    .then(function(response) {
        TransctionResponse = response;
    })
    .catch(function(error) {
        TransctionResponse = error;
    });
  });

  Then('Recibo una respuesta con http status {int}', function (httpStatus) {
    // Write code here that turns the phrase above into concrete actions
    expect(TransctionResponse.statusCode).to.eql(httpStatus);
  });

  