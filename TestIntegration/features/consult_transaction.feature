Feature: Consultar  informacion de billetera de cliente
 Como Usuario Final (humano)
 Quiero ver el saldo final de una billetera

 Scenario: Se tiene datos validos y se muestran correctamente
  Given Dados datos de IDBILLETERA "1" 
   When Navego a la pagina principal 
     And Llenar el campo de IdBilletera
     And Hacer click en el boton Consultar
     Then Se debe mostrar la cadena "0,0"

     