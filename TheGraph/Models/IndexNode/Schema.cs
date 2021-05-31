using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TheGraph.Models.IndexNode
{
    //Schema based on: https://github.com/graphprotocol/graph-node/blob/master/server/index-node/src/schema.graphql

    public class Block
    {
        [JsonPropertyName("number")] 
        public string? Number { get; set; }

        [JsonPropertyName("hash")]
        public string? Hash { get; set; }
    }

    public class EthereumIndexingStatus
    {
        [JsonPropertyName("network")]
        public string? Network { get; set; }

        [JsonPropertyName("chainHeadBlock")]
        public Block? ChainHeadBlock { get; set; }

        [JsonPropertyName("earliestBlock")]
        public Block? EarliestBlock { get; set; }

        [JsonPropertyName("latestBlock")]
        public Block? LatestBlock { get; set; }

        [JsonPropertyName("lastHealthyBlock")]
        public Block? LastHealthyBlock { get; set; }
    }

    public class SubgraphError
    {
        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("block")]
        public Block? Block { get; set; }

        [JsonPropertyName("handler")]
        public string? Handler { get; set; }

        [JsonPropertyName("deterministic")]
        public bool? Deterministic { get; set; }

    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Health
    {
        healthy,
        unhealthy,
        failed
    }

    public class SubgraphIndexingStatus
    {
        [JsonPropertyName("chains")]
        public List<EthereumIndexingStatus> Chains { get; set; } = new List<EthereumIndexingStatus>();

        [JsonPropertyName("fatalError")]
        public SubgraphError? FatalError { get; set; }

        [JsonPropertyName("nonFatalErrors")]
        public List<SubgraphError> NonFatalErrors { get; set; } = new List<SubgraphError>();

        [JsonPropertyName("health")]
        public Health? Health { get; set; }

        [JsonPropertyName("synced")]
        public bool Synced { get; set; }

        [JsonPropertyName("subgraph")]
        public string? Subgraph { get; set; }

        [JsonPropertyName("entityCount")]
        public string? EntityCount { get; set; }

        [JsonPropertyName("node")]
        public string? Node { get; set; }
    }
}
