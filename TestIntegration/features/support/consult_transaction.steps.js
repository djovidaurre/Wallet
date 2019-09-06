const { Given, When, Then } = require('cucumber')
const { expect } = require('chai')
require('chromedriver');
const { Builder, By, Key, until } = require('selenium-webdriver');

let idBilletera = "";
let chromeDriver = undefined;

  Given('Dados datos de IDBILLETERA {string}', function (string) {
    // Write code here that turns the phrase above into concrete actions
    idBilletera = string;
  });

  When('Navego a la pagina principal', async function () {
    // Write code here that turns the phrase above into concrete actions
    chromeDriver = await new Builder().forBrowser('chrome').build();
    await chromeDriver.get('http://localhost/WebWallet/RegisterTransaction.aspx');
  });

  When('Llenar el campo de IdBilletera', async function () {
    // Write code here that turns the phrase above into concrete actions
    await chromeDriver.findElement(By.id('txt_IdWallet')).sendKeys(idBilletera);
  });

  
  When('Hacer click en el boton Consultar', async function () {
    // Write code here that turns the phrase above into concrete actions
    await chromeDriver.findElement(By.id('btn_Consultar')).click();
    
  });

  Then('Se debe mostrar la cadena {string}', async function (expected) {
    // Write code here that turns the phrase above into concrete actions
    await chromeDriver.findElement(By.id('lbl_balance'))
    .getText().then(function (text) {
      showText = text;
    });

    expect(showText).to.eql(expected);
    await chromeDriver.quit();
  });