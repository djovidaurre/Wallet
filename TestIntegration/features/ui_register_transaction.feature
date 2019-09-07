Feature: Registrar transaccion en billetera de cliente
 Como Usuario Final (humano)
 Quiero registrar una transaccion en una billetera

 Scenario: Se tiene datos validos y se muestran correctamente
  Given Dados datos de IDBILLETERA "1"  IDTRANSACCION "1" MONTO "500"
   When Navego a la pagina principal 
   And Llenar el campo de IdBilletera
   And Llenar el campo de IdTransaccion
   And Llenar el campo de Monto
   And Hacer click en el boton Registar
Then Debe validar que el monto total es "500,0"