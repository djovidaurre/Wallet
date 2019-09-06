using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;
using recurso = UnitTest.UrlApi;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void UnitTestRegisterCustomer()
        {
            var cust = new CustomerParam()
            {
                FirstName = "Josue",
                SurName = "Ortiz",
                Email = "djovidaurre@gmail.com",
                DateOfBirth = new DateTime(1990, 12, 18)
            };

            var customer = ConsultarApi(
                JsonConvert.SerializeObject(cust),
                recurso.RegistrarCliente
                );

            var result = JsonConvert.DeserializeObject<CustomerDto>(customer.Content);

            var expected = true;

            Assert.AreEqual(expected, result.Response);

        }

        [TestMethod]
        public void UnitTestRegisterCustomerWithOutSurName()
        {
            var cust = new CustomerParam()
            {
                FirstName = "Josue",
                SurName = "",
                Email = "djovidaurre@gmail.com",
                DateOfBirth = new DateTime(1990, 12, 18)
            };

            var customer = ConsultarApi(
             JsonConvert.SerializeObject(cust),
             recurso.RegistrarCliente
             );

            var result = JsonConvert.DeserializeObject<CustomerDto>(customer.Content);

            var expected = false;

            Assert.AreEqual(expected, result.Response);

        }


        [TestMethod]
        public void UnitTestRegisterCustomerWithOutEmail()
        {
            var cust = new CustomerParam()
            {
                FirstName = "Josue",
                SurName = "Ortiz",
                Email = "",
                DateOfBirth = new DateTime(1990, 12, 18)
            };

            var customer = ConsultarApi(
            JsonConvert.SerializeObject(cust),
            recurso.RegistrarCliente
            );

            var result = JsonConvert.DeserializeObject<CustomerDto>(customer.Content);

            var expected = false;

            Assert.AreEqual(expected, result.Response);

        }

        [TestMethod]
        public void UnitTestRegisterCustomerWithOutDateOfBirth()
        {
            var cust = new CustomerParam()
            {
                FirstName = "Josue",
                SurName = "Ortiz",
                Email = "djovidaurre@gmail.com"
            };

            var customer = ConsultarApi(
             JsonConvert.SerializeObject(cust),
             recurso.RegistrarCliente
             );

            var result = JsonConvert.DeserializeObject<CustomerDto>(customer.Content);

            var expected = true;

            Assert.AreEqual(expected, result.Response);

        }

        [TestMethod]
        public void UnitTestRegisterTransaction()
        {
            var trans = new TransactionParam()
            {
                IdBilletera = 1,
                IdTipoTransaccion = 1,
                Monto = 100
            };
            var transction = ConsultarApi(
                JsonConvert.SerializeObject(trans),
                recurso.RegistrarTransaccion
                );


            var result = JsonConvert.DeserializeObject<TransactionDto>(transction.Content);

            var expected = true;

            Assert.AreEqual(expected, result.Response);

        }

        [TestMethod]
        public void UnitTestRegisterTransactionWithZeroBalance()
        {
            var trans = new TransactionParam()
            {
                IdBilletera = 1,
                IdTipoTransaccion = 1,
                Monto = 0
            };
            var transction = ConsultarApi(
                JsonConvert.SerializeObject(trans),
                recurso.RegistrarTransaccion
                );


            var result = JsonConvert.DeserializeObject<TransactionDto>(transction.Content);

            var expected = false;

            Assert.AreEqual(expected, result.Response);

        }

        [TestMethod]
        public void UnitTestRegisterTransactionValidationofCountableIncome()
        {
            var trans = new TransactionParam()
            {
                IdBilletera = 1,
                IdTipoTransaccion = 2,
                Monto = 100
            };

            // Primero resetear lo anterior
            var transaction = ConsultarApi(
                JsonConvert.SerializeObject(trans),
                recurso.ResetBalanceWallet
                );

            var transction = ConsultarApi(
                JsonConvert.SerializeObject(trans),
                recurso.RegistrarTransaccion
                );


            var result = JsonConvert.DeserializeObject<TransactionDto>(transction.Content);

            var expected = 100;

            Assert.AreEqual(expected, result.Balance);

        }


        [TestMethod]
        public void UnitTestRegisterTransactionMultiples()
        {
            // Ingreso 100 
            var trans1 = new TransactionParam()
            {
                IdBilletera = 1,
                IdTipoTransaccion = 1,
                Monto = 100
            };


            // Ingreso 100 
            var trans2 = new TransactionParam()
            {
                IdBilletera = 1,
                IdTipoTransaccion = 1,
                Monto = 100
            };


            // Egreso 200 
            var trans3 = new TransactionParam()
            {
                IdBilletera = 1,
                IdTipoTransaccion = 2,
                Monto = -200
            };

            // Primero resetear lo anterior
            var transaction = ConsultarApi(
                JsonConvert.SerializeObject(trans1),
                recurso.ResetBalanceWallet
                );


            var transaction1 = ConsultarApi(
                JsonConvert.SerializeObject(trans1),
                recurso.RegistrarTransaccion
                );

            var transaction2 = ConsultarApi(
                JsonConvert.SerializeObject(trans2),
                recurso.RegistrarTransaccion
                );

            var transaction3 = ConsultarApi(
                JsonConvert.SerializeObject(trans3),
                recurso.RegistrarTransaccion
                );


            var result = JsonConvert.DeserializeObject<TransactionDto>(transaction3.Content);

            var expected = 0;

            Assert.AreEqual(expected, result.Balance);

        }

        [TestMethod]
        public void UnitTestConsultBalanceWallet()
        {

            var trans = new ConsultTransactionParam()
            {
                IdBilletera = 1
            };
            var transction = ConsultarApi(
                JsonConvert.SerializeObject(trans),
                recurso.ConsultarTransaccion
                );


            var result = JsonConvert.DeserializeObject<TransactionDto>(transction.Content);

            var expected = true;

            Assert.AreEqual(expected, result.Response);

        }

        [TestMethod]
        public void UnitTestResetBalanceWallet()
        {
            var trans = new ConsultTransactionParam()
            {
                IdBilletera = 1
            };
            var transction = ConsultarApi(
                JsonConvert.SerializeObject(trans),
                recurso.ResetBalanceWallet
                );


            var result = JsonConvert.DeserializeObject<TransactionDto>(transction.Content);

            var expected = true;

            Assert.AreEqual(expected, result.Response);

        }



        public IRestResponse ConsultarApi(string json, string urlApi)
        {
            var url = string.Format(recurso.UrlApiWallet, urlApi);
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", json, ParameterType.RequestBody);
            return client.Execute(request);

        }

    }
}
