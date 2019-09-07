Feature: Consultar Saldo final de una billetera de cliente
 Como un cliente de API WEB (no humano)
 Quiero consultar el saldo final de una billetera

 Scenario: Consultar Saldo final de una billetera de cliente
  Given El datos IdWallet 1
   When Preparo el JSON de los datos para consultar saldo final
     Then Hago un request POST hacia el url tran con el parametro
     Then Recibo una respuesta con el saldo final 