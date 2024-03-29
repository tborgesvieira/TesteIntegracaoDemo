﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using WebApplication;

namespace XUnitTestProject.Core
{
    public class TestContext
    {
        public HttpClient Client { get; set; }

        private TestServer _server;

        public TestContext()
        {
            SetupClient();
        }

        private void SetupClient()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());

            Client = _server.CreateClient();

            Client.DefaultRequestHeaders.Add("Api-Key", "teste");
        }
    }
}
