using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGraph.Models.IndexNode
{


    public class IndexingStatusForCurrentVersionResponse
    {
        public SubgraphIndexingStatus? indexingStatusForCurrentVersion { get; set; }
    }

    public class IndexingStatusForPendingVersionResponse
    {
        public SubgraphIndexingStatus? indexingStatusForPendingVersion { get; set; }
    }
}
