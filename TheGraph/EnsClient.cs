using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGraph.Models.ENS;

namespace TheGraph
{
    public class EnsClient : TheGraphClient
    {
        public EnsClient(string baseUrl = "https://api.thegraph.com") : base("ensdomains/ens", baseUrl)
        {
        }

        public async Task<string?> GetDomainOwner(string domain)
        {
            domain = domain.Replace(".eth", string.Empty).ToLowerInvariant();

            string query = @"{
                domains(first: 1, where: { labelName: """+ domain + @"""}) {
                name
                labelName
                owner {
                    id
                }
                }
                }";

            var result = await SendQueryAsync<DomainsResponse>(query);

            return result.Data.Domains?.FirstOrDefault()?.Owner?.Id;
        }

        public async Task<List<string?>> GetDomainsForAddress(string address)
        {
            string query = @"{
                 accounts(first:1, where: { id: """ + address + @"""} ) {
                    id
                    domains
                    {
                        labelName
                    }
                    }
    }";

            var result = await SendQueryAsync<AccountsResponse>(query);

            return result.Data.Accounts.FirstOrDefault()?.Domains.Select(x => x.LabelName).ToList() ?? new List<string?>();
        }

    }
}
