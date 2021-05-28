using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using GraphQL.Client.Abstractions;
using System;
using System.Threading.Tasks;

namespace TheGraph
{
    public class TheGraphClient
    {
        private readonly GraphQLHttpClient client;

        public TheGraphClient(string baseUrl)
        {
            client = new GraphQLHttpClient(baseUrl, new SystemTextJsonSerializer());

        }

        public async Task<GraphQLResponse<T>> SendQueryAsync<T>(string query)
        {
            var request = new GraphQLRequest
            {
                Query = query
            };

            var graphQLResponse = await client.SendQueryAsync<T>(request);

            return graphQLResponse;
        }
    }
}
