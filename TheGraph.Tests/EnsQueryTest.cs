using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TheGraph.Tests
{

    [TestClass]
    public class EnsQueryTest
    {
        [TestMethod]
        public async Task GetDomainOwner()
        {
            var client = new EnsClient();
            var result = await client.GetDomainOwner("concord");

            Assert.AreEqual("0xbcbd4885ee8b2b74249c5ad9b8b668fb256a51b1", result);
        }

        [TestMethod]
        public async Task GetDomainOwnerWithExtension()
        {
            var client = new EnsClient();

            var result = await client.GetDomainOwner("concord.eth");

            Assert.AreEqual("0xbcbd4885ee8b2b74249c5ad9b8b668fb256a51b1", result);
        }

        [TestMethod]
        public async Task GetDomainsForAccount()
        {
            var client = new EnsClient();

            var result = await client.GetDomainsForAddress("0xbcbd4885ee8b2b74249c5ad9b8b668fb256a51b1");

            Assert.IsTrue(result.Any());
            Assert.IsTrue(result.Where(x => x == "concord").Any());
        }


    }
}
