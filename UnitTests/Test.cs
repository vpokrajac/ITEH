using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using DbManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using Newtonsoft.Json;

namespace UnitTests
{
    [TestClass]
    public class TestSQL
    {
        private const string URL = "http://localhost:50970/";
        private string urlParameters = "api/Values";
        [TestMethod]
        public void TestServiceGet()
        {
            var client = new RestClient(URL + urlParameters);

            IRestResponse<List<Test>> response = client.Execute<List<Test>>(new RestRequest());
            List<Test> testListFromService = JsonConvert.DeserializeObject<List<Test>>(response.Content);
            Assert.AreNotEqual(0, testListFromService.Count);
        }

        [TestMethod]
        public void TestSQLSelect()
        {
            Manager manager = new Manager();
            List<Test> testList = manager.GetAllTests();
            Assert.AreNotEqual(0, testList.Count);
        }
    }
}
