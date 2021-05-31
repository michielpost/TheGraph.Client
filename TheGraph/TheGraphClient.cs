using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using GraphQL.Client.Abstractions;
using System;
using System.Threading.Tasks;
using TheGraph.Models.IndexNode;

namespace TheGraph
{
    public class TheGraphClient
    {
        private readonly GraphQLHttpClient client;
        private readonly GraphQLHttpClient indexNodeClient;
        private readonly string subgraphName;

        public TheGraphClient(string subgraphName, string baseUrl = "https://api.thegraph.com")
        {
            string endpointUrl = $"{baseUrl}/subgraphs/name/{subgraphName}";
            string indexNodeUrl = $"{baseUrl}/index-node/graphql";

            client = new GraphQLHttpClient(endpointUrl, new SystemTextJsonSerializer());
            indexNodeClient = new GraphQLHttpClient(indexNodeUrl, new SystemTextJsonSerializer());
            this.subgraphName = subgraphName;
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

        private async Task<GraphQLResponse<T>> SendIndexNodeQueryAsync<T>(string query)
        {
            var request = new GraphQLRequest
            {
                Query = query
            };

            var graphQLResponse = await indexNodeClient.SendQueryAsync<T>(request);

            return graphQLResponse;
        }

        public Task<GraphQLResponse<IndexingStatusForCurrentVersionResponse>> IndexingStatusForCurrentVersion()
        {
            string query = @"
                        {
                           indexingStatusForCurrentVersion(subgraphName: """ + subgraphName + @""") {
                              synced
                              health
                              fatalError {
                                message
                                block {
                                  number
                                  hash
                                }
                                handler
                              }
                              chains {
                                network
                                chainHeadBlock {
                                  number
                                  hash
                                }
                                latestBlock {
                                  number
                                  hash
                                }
                              }
                              entityCount
                              node
                            }
                        }
                        ";

            return SendIndexNodeQueryAsync<IndexingStatusForCurrentVersionResponse>(query);
        }

        public Task<GraphQLResponse<IndexingStatusForPendingVersionResponse>> IndexingStatusForPendingVersion()
        {
            string query = @"
                        {
                           indexingStatusForPendingVersion(subgraphName: """ + subgraphName + @""") {
                              synced
                              health
                              fatalError {
                                message
                                block {
                                  number
                                  hash
                                }
                                handler
                              }
                              chains {
                                network
                                chainHeadBlock {
                                  number
                                  hash
                                }
                                latestBlock {
                                  number
                                  hash
                                }
                              }
                              entityCount
                              node
                            }
                        }
                        ";

            return SendIndexNodeQueryAsync<IndexingStatusForPendingVersionResponse>(query);
        }
    }
}
