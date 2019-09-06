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
            var customer = ConsultarApi(
                new CustomerParam()
                {
                    FirstName = "Josue",
                    SurName = "Ortiz",
                    Email = "djovidaurre@gmail.com",
                    DateOfBirth = new DateTime(1990, 12, 18)
                }, recurso.RegistrarCliente
                );

            var expected = true;

            Assert.AreEqual(expected, customer.Response);

        }



        public CustomerDto ConsultarApi(CustomerParam param, string urlApi)
        {
            var valorJson = JsonConvert.SerializeObject(param);

            var url =  string.Format(recurso.UrlApiWallet, urlApi);

            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", valorJson, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<CustomerDto>(response.Content);

        }





    }
}
