using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TheGraph.Models.ENS
{
    public class DomainsResponse
    {
        [JsonPropertyName("domains")]
        public List<Domain>? Domains { get; set; } = new List<Domain>();
    }

    public class AccountsResponse
    {
        [JsonPropertyName("Accounts")]
        public List<Account> Accounts { get; set; } = new List<Account>();
    }
}
