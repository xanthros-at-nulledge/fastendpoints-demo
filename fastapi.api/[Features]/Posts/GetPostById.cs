using fastapi.api._Features_.Posts.Models;

namespace fastapi.api._Features_.Posts;

public class GetPostById : EndpointWithoutRequest
{
    private HttpClient _httpClient;
    public GetPostById(IHttpClientFactory clientFactory)
    {
        this._httpClient = clientFactory.CreateClient();
    }

    public override void Configure()
    {
        Get("/posts/{PostID}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        //http://localhost:5000/article/123
        int postId = Route<int>("PostID");
        var request = await this._httpClient.GetFromJsonAsync<Post>($"https://jsonplaceholder.typicode.com/posts/{postId}");
        await SendAsync(request);
    }
}