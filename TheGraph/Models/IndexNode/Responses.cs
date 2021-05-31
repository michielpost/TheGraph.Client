using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TheGraph.Models.IndexNode
{


    public class IndexingStatusForCurrentVersionResponse
    {
        [JsonPropertyName("indexingStatusForCurrentVersion")]
        public SubgraphIndexingStatus? IndexingStatusForCurrentVersion { get; set; }
    }

    public class IndexingStatusForPendingVersionResponse
    {
        [JsonPropertyName("indexingStatusForPendingVersion")]
        public SubgraphIndexingStatus? IndexingStatusForPendingVersion { get; set; }
    }
}
