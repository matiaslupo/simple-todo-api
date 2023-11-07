using SimpleTodo.Entities.Requests;
using SimpleTodo.Entities.Responses;

namespace SimpleTodo.Persistence;

public static class TasksList
{
    private static readonly List<TodoTask> _tasks = new();
    
    public static bool Any() => _tasks.Any();
    public static void Add(TodoTask task) => _tasks.Add(task);
    public static List<TodoTask> GetAll() => _tasks;
    public static TodoTask? GetTask(int id) => _tasks.FirstOrDefault(t => t.Id == id);
    public static TodoTask? Edit(int id, SaveTask values)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task != null) {
            task.Description = values.Description;
            return task;
        }
        return null;
    }
    public static bool Delete(int id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task != null) {
            _tasks.Remove(task);
            return true;
        }
        return false;
    }
}
