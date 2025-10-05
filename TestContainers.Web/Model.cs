namespace TestContainers.Web;

public class Todo
{
    public int Id { get; set; }          // PK
    public string Title { get; set; } = "";
    public bool IsDone { get; set; }
    public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;
}