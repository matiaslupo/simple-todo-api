namespace SimpleTodo.Entities.Responses;

public class TodoTask
{
    private static int s_lastId = 0;
    public int Id { get; }
    public string Description { get; set; } = string.Empty;

    public TodoTask(string description)
    {
        Id = ++s_lastId;
        Description = description;
    }
}
