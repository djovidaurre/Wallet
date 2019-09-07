const { Given, When, Then } = require('cucumber')
const { expect } = require('chai')
require('chromedriver');
const { Builder, By, Key, until } = require('selenium-webdriver');

let idBilletera = "";
let idTransaccion = "";
let monto = "";
let chromeDriver = undefined;


Given('Dados datos de IDBILLETERA {string}  IDTIPOTRANSACCION {string} MONTO {string}', function (string, string2, string3) {
  // Write code here that turns the phrase above into concrete actions
  idBilletera = string;
  idTransaccion = string2;
  monto = string3;
});

When('Llenar el campo de IdTransaccion', async function () {
  // Write code here that turns the phrase above into concrete actions
  await chromeDriver.findElement(By.id('txt_IdTransaction')).sendKeys(idTransaccion);
});

When('Llenar el campo de Monto', async function () {
  // Write code here that turns the phrase above into concrete actions
  await chromeDriver.findElement(By.id('txt_Amount')).sendKeys(monto);
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