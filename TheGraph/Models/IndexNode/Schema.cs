using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGraph.Models.IndexNode
{
    public class Block
    {
        public string? number { get; set; }
        public string? hash { get; set; }
    }

    public class EthereumIndexingStatus
    {
        public string? network { get; set; }
        public Block? chainHeadBlock { get; set; }
        public Block? earliestBlock { get; set; }
        public Block? latestBlock { get; set; }
        public Block? lastHealthyBlock { get; set; }
    }

    public class SubgraphError
    {
        public string? message { get; set; }
        public Block? block { get; set; }
        public string? handler { get; set; }
        public bool? deterministic { get; set; }

    }

    public enum Health
    {
        healthy,
        unhealthy,
        failed
    }

    public class SubgraphIndexingStatus
    {
        public List<EthereumIndexingStatus> chains { get; set; } = new List<EthereumIndexingStatus>();
        public SubgraphError? fatalError { get; set; }
        public List<SubgraphError> nonFatalErrors { get; set; } = new List<SubgraphError>();
        public Health? health { get; set; }
        public bool synced { get; set; }
        public string? subgraph { get; set; }
        public string? entityCount { get; set; }
        public string? node { get; set; }
    }
}
