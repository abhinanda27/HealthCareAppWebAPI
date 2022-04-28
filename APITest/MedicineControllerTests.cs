using FakeItEasy;
using HealthCareAppWebAPI.Controllers;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net.Http;
using System.Configuration;
using System.Net;
using System.Net.Http.Headers;
using System;

namespace APITest
{
     public class HttpResponseTests
  {
 private HttpClient client;
   private HttpResponseMessage response;
  [SetUp]
 public void SetUP()
     {
   client = new HttpClient();
  client.BaseAddress = new Uri(ConfigurationManager.AppSettings["http://localhost:5000/api/Medicine"]);
  response = client.GetAsync("Medicine/get").Result;
}
 [Test]
 public void GetResponseIsSuccess()
  {
       Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
   }
  
          

        
    }
}