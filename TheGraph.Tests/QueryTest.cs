using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TheGraph.Tests
{
    class GravatarResultModel
    {
        [JsonPropertyName("gravatars")]
        public List<GravatarModel> Gravatars { get; set; } = new List<GravatarModel>();
    }
    class GravatarModel
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("owner")]
        public string? Owner { get; set; }

        [JsonPropertyName("displayName")]
        public string? DisplayName { get; set; }

        [JsonPropertyName("imageUrl")]
        public string? ImageUrl { get; set; }

    }
    [TestClass]
    public class QueryTest
    {
        [TestMethod]
        public async Task GetDyanmic()
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
            Assert.IsTrue(result.Data.Gravatars.Any());
            Assert.IsTrue(!string.IsNullOrWhiteSpace(result.Data.Gravatars.First().Id));
        }
    }
}
