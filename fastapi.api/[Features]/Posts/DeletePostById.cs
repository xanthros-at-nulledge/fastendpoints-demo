using fastapi.api._Features_.Posts.Models;

namespace fastapi.api._Features_.Posts;

public class DeletePostById : EndpointWithoutRequest
{
    private HttpClient _httpClient;
    public DeletePostById(IHttpClientFactory clientFactory)
    {
        this._httpClient = clientFactory.CreateClient();
    }

    public override void Configure()
    {
        Delete("/posts/{PostID}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        //http://localhost:5000/article/123
        int postId = Route<int>("PostID");
        var request = await this._httpClient.DeleteAsync($"https://jsonplaceholder.typicode.com/posts/{postId}");
        await SendNoContentAsync();
    }
}