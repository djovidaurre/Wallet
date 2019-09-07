Feature: Validar registro de transaccion en billetera de cliente
 Como un cliente de API WEB (no humano)
 Quiero validar el registrar una transaccion en una billetera

 Scenario: Validar registro de transaccion en billetera de cliente
  Given Los siguientes datos IdWallet 1  IdtypeTransaction 1 Amount 500
   When Preparo el JSON de los datos
     Then Hago un request POST hacia el url tran con los datos
     Then Recibo una respuesta con http status 200