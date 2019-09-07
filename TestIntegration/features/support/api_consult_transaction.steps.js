const { Given, When, Then } = require('cucumber')
const { expect } = require('chai')
const httpClient = require('request-promise')

let newtrans = {};
let httpOptions = {};
let TransctionResponse = undefined;


Given('El datos IdWallet {int}', function (int) {
    // Write code here that turns the phrase above into concrete actions
    newtrans = {
        IdBilletera: int
      };
  });

  When('Preparo el JSON de los datos para consultar saldo final', function () {
    // Write code here that turns the phrase above into concrete actions
    console.log('DONE');

    var json =JSON.stringify(newtrans);
    httpOptions = {
      method: 'POST',
      uri: 'http://localhost/ApiWallet/api/v1.0/wallet/consult/transaction',
      json: true,
      body: json,
      resolveWithFullResponse: true
    };
  });

  Then('Hago un request POST hacia el url tran con el parametro', async function () {
    // Write code here that turns the phrase above into concrete actions
    await httpClient(httpOptions)
    .then(function(response) {
        TransctionResponse = response;
    })
    .catch(function(error) {
        TransctionResponse = error;
    });
  });

  Then('Recibo una respuesta con el saldo final', function () {
    // Write code here that turns the phrase above into concrete actions
    expect(TransctionResponse.statusCode).to.eql(200);
  });