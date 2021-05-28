using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace TheGraph.Tests
{
    [TestClass]
    public class QueryTest
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            var client = new TheGraphClient("https://api.thegraph.com/subgraphs/name/michielpost/graph-bookstore");

            string query = @"
                        {
                          gravatars(first: 5) {
                            id
                            owner
                            displayName
                            imageUrl
                          }
                        }
                        ";

            var result = await client.SendQueryAsync<dynamic>(query);

            Assert.IsTrue(result.Errors == null);
        }
    }
}
