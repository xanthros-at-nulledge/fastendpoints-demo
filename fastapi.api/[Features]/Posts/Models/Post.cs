namespace fastapi.api._Features_.Posts.Models;

public class Post
{
    public int id { get; set; }
    public string title { get; set; }
    public string body { get; set; }
    public int userId { get; set; }
}