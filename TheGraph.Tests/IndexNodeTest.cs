using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheGraph.Tests
{
  
    [TestClass]
    public class IndexNodeTest
    {
        [TestMethod]
        public async Task IndexingStatusForCurrentVersion()
        {
            var client = new TheGraphClient("michielpost/graph-bookstore");

            var result = await client.IndexingStatusForCurrentVersion();

            Assert.IsTrue(result.Errors == null);
            Assert.IsTrue(result.Data.indexingStatusForCurrentVersion?.chains.Any() ?? false);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(result.Data.indexingStatusForCurrentVersion?.chains.First().chainHeadBlock?.number));
        }

        [TestMethod]
        public async Task IndexingStatusForPendingVersion()
        {
            var client = new TheGraphClient("michielpost/graph-bookstore");

            var result = await client.IndexingStatusForPendingVersion();

            Assert.IsTrue(result.Errors == null);
            Assert.IsNull(result.Data.indexingStatusForPendingVersion);
        }


    }
}
