const { setWorldConstructor } = require("cucumber");

class TransactionWorld {
  constructor() {
    this.result = 0;
  }

  setTo(number) {
    this.result = number;
  }
}

setWorldConstructor(TransactionWorld);