using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using recurso = WebWallet.Service.UrlApi;

namespace WebWallet.Service
{
    public static class AppServices
    {
        public static IRestResponse ConsultarApi(string json, string urlApi)
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