using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheGraph.Tests
{
    class GravatarResultModel
    {
        public List<GravatarModel> gravatars { get; set; } = new List<GravatarModel>();
    }
    class GravatarModel
    {
        public string? id { get; set; }
        public string? owner { get; set; }
        public string? displayName { get; set; }
        public string? imageUrl { get; set; }

    }
    [TestClass]
    public class QueryTest
    {
        [TestMethod]
        public async Task GetDyanmic()
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

        [TestMethod]
        public async Task GetTyped()
        {
            var client = new TheGraphClient("michielpost/graph-bookstore");

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

            var result = await client.SendQueryAsync<GravatarResultModel>(query);

            Assert.IsTrue(result.Errors == null);
            Assert.IsTrue(result.Data.gravatars.Any());
            Assert.IsTrue(!string.IsNullOrWhiteSpace(result.Data.gravatars.First().id));
        }
    }
}
