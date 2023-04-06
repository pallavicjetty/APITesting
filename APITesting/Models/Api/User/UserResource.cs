using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Net;

namespace APITesting.Models.Api.User
{
    public class UserResource
    {
        private static RestClient RestClient { get; set; }
        private static IRestResponse Reponse { get; set; }
        private static RestRequest RestRequest { get; set; }

        private void InitialiseEndpoint( string endURL, Method method)
        {
            RestClient = new RestClient();
            RestRequest = new RestRequest(endURL, method);
        }

        private void AddEndpoint()
        {
            var endpointUri = new Uri("https://localhost:44362/");
            RestClient.BaseUrl = endpointUri;
        }

        private void SendGetInfoRequest()
        {
            Reponse = RestClient.Execute(RestRequest);
            Console.WriteLine(JsonConvert.SerializeObject(Reponse.Content, Formatting.Indented));
        }

        private void ValidateResponse(HttpStatusCode httpStatusCode)
        {
            Assert.AreEqual(httpStatusCode, Reponse.StatusCode);
            
        }

        public void SendRequestAndValidateResponse()
        {
            InitialiseEndpoint("api/User?userId=2", Method.GET);
            AddEndpoint();
            SendGetInfoRequest();
            ValidateResponse(HttpStatusCode.OK);
        }

        public void SendNegativeRequestAndValidateResponse()
        {
            InitialiseEndpoint("api/User?userId=3", Method.GET);
            AddEndpoint();
            SendGetInfoRequest();
            ValidateResponse(HttpStatusCode.OK);
            Assert.AreEqual(2, Reponse.Content.Length);//
        }
    }
}
