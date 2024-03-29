const { Given, When, Then } = require('cucumber')
const { expect } = require('chai')
require('chromedriver');
const { Builder, By, Key, until } = require('selenium-webdriver');

let chromeDriver = undefined;


Given('Dados datos de IDBILLETERA {string}  IDTRANSACCION {string} MONTO {string}', function (string, string2, string3) {
  // Write code here that turns the phrase above into concrete actions
  this.setToIdBilletera(string);
  this.setToIdTransaccion(string2);
  this.setToMonto(string3);
});

When('Navego a la pagina principal', async function () {
  // Write code here that turns the phrase above into concrete actions
  chromeDriver = await new Builder().forBrowser('chrome').build();
  await chromeDriver.get(this.getUrlRegisterTransaccion());
});


When('Llenar el campo de IdBilletera', async function () {
  // Write code here that turns the phrase above into concrete actions
  await chromeDriver.findElement(By.id('txt_IdWallet')).sendKeys(this.getToIdBilletera());
});

When('Llenar el campo de IdTransaccion', async function () {
  // Write code here that turns the phrase above into concrete actions
  await chromeDriver.findElement(By.id('txt_IdTransaction')).sendKeys(this.getToIdTransaccion());
});

When('Llenar el campo de Monto', async function () {
  // Write code here that turns the phrase above into concrete actions
  await chromeDriver.findElement(By.id('txt_Amount')).sendKeys(this.getToMonto());
});

When('Hacer click en el boton Registar', async function () {
  // Write code here that turns the phrase above into concrete actions
  await chromeDriver.findElement(By.id('bnt_Register')).click();
});


Then('Debe validar que el monto total es {string}', async function (expected) {
  // Write code here that turns the phrase above into concrete actions
  await chromeDriver.findElement(By.id('lbl_balance'))
  .getText().then(function (text) {
    showText = text;
  });

  expect(showText).to.eql(expected);
  await chromeDriver.quit();
});