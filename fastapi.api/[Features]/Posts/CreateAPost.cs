using fastapi.api._Features_.Posts.Models;

namespace fastapi.api._Features_.Posts;

public class CreateAPost : Endpoint<Post, Post>
{
    private HttpClient _httpClient;
    
    public CreateAPost(IHttpClientFactory clientFactory)
    {
        this._httpClient = clientFactory.CreateClient();
    }
    
    public override void Configure()
    {
        Post("/post");
        AllowAnonymous();
    }

    public override  async Task HandleAsync(Post req, CancellationToken ct)
    {
        var request = await this._httpClient.PostAsJsonAsync<Post> ("https://jsonplaceholder.typicode.com/posts", req);

        var result = await request.Content.ReadFromJsonAsync<Post>();

        await SendAsync(result);
    }
    
}