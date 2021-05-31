# TheGraph.Client
C# client to interact with [The Graph](https://thegraph.com/) APIs 

## Install
Install the latest version from [NuGet](https://www.nuget.org/packages/TheGraph/)  
NuGet package name: `TheGraph`


## How to use

Create a `TheGraphClient`
```cs
var client = new TheGraphClient("ACCOUNTNAME/SubgraphName");
```

Create a query and send the query to the client
```cs
 string query = @"
    {
        gravatars(first: 5) {
        id
        owner
        displayName
        imageUrl
        }
    }
    ";

var result = await client.SendQueryAsync<GravatarResultModel>(query);
```

You will need to create your own ResultModel, for example:
```cs
class GravatarResultModel
{
    [JsonPropertyName("gravatars")]
    public List<GravatarModel> Gravatars { get; set; } = new List<GravatarModel>();
}
class GravatarModel
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("owner")]
    public string? Owner { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("imageUrl")]
    public string? ImageUrl { get; set; }
}
```

### Index Status endpoint
There is build in support to query the index status of your subgraph:

```cs
var result = await client.IndexingStatusForCurrentVersion();

//Get the last index block:
var blockNumber = result.Data.IndexingStatusForCurrentVersion?.Chains.First().ChainHeadBlock?.Number;
```

### ENS
This library supports all subgraphs. But to make development even easier, there is build in support for some ENS subgraph queries:

```cs
var ensClient = new EnsClient();
var owner = await ensClient.GetDomainOwner("concord");
var domains = await ensClient.GetDomainsForAddress("0xbcbd4885ee8b2b74249c5ad9b8b668fb256a51b1");
```

### Contribue
This library is open to contributions. It would really help to be able to access more subgraphs in a typed way. Please send a PR!

## Open source credits
[GraphQL.Client](https://github.com/graphql-dotnet/graphql-client)

## Acknowledgements
Development has been made possible with a grant from [The Graph](https://thegraph.com/blog/wave-one-funding).
