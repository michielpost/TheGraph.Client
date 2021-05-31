using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TheGraph.Models.ENS
{
    public class Domain
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("labelName")]
        public string? LabelName { get; set; }

        [JsonPropertyName("parent")]
        public Domain? Parent { get; set; }

        [JsonPropertyName("subdomains")]
        public List<Domain> Subdomains { get; set; } = new List<Domain>();

        [JsonPropertyName("resolvedAddress")]
        public Account? ResolvedAddress { get; set; }

        [JsonPropertyName("owner")]
        public Account? Owner { get; set; }
    }

    public class Account
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("domains")]
        public List<Domain> Domains { get; set; } = new List<Domain>();

    }
}
