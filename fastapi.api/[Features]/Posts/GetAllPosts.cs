using System.Dynamic;
using System.Text.Json.Nodes;
using fastapi.api._Features_.Posts.Models;

namespace fastapi.api._Features_.Posts;

public class GetAllPosts : EndpointWithoutRequest
{
    private HttpClient _httpClient;
    public GetAllPosts(IHttpClientFactory clientFactory)
    {
        this._httpClient = clientFactory.CreateClient();
    }

    public override void Configure()
    {
        Get("/posts");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(CancellationToken ct)
    {
        var request = await this._httpClient.GetFromJsonAsync<IList<Post>>("https://jsonplaceholder.typicode.com/posts");

        //dynamic body = await request.Content.ReadFromJsonAsync<ExpandoObject>();
        await SendAsync(request);
    }
}