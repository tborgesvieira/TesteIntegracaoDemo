using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using XUnitTestProject.Core;

namespace XUnitTestProject.Scenarios
{
    public class ValuesTests
    {
        private readonly TestContext _testContext;

        public ValuesTests()
        {
            _testContext = new TestContext();
        }

        [Fact]
        public async Task Values_Get_ReturnsOkResponse()
        {
            //Arrange            
            //Act
            var response = await _testContext.Client.GetAsync("/api/values");
            var retorno = JsonConvert.DeserializeObject<string[]>(response.Content.ReadAsStringAsync().Result);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotEmpty(retorno);
            Assert.True(retorno.Count().Equals(2));
        }
    }
}
