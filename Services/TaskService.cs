using System.Text.Json;
using CLI_Application.Models;
using TaskStatus = CLI_Application.Models.TaskStatus;

namespace CLI_Application.Services;

public class TaskService
{
  private readonly string _filePath;
  private readonly JsonSerializerOptions _jsonOptions;
  public TaskService()
  {
    _filePath = Path.Combine(Directory.GetCurrentDirectory(), "tasks.json");

    _jsonOptions = new JsonSerializerOptions
    {
      WriteIndented = true
    };

  }
  private List<TaskItem> LoadTasks()
  {
    try
    {
      string json = File.ReadAllText(_filePath);

      return JsonSerializer.Deserialize<List<TaskItem>>(json)
             ?? new List<TaskItem>();
    }
    catch (JsonException)
    {
      Console.WriteLine("Error: tasks.json contains invalid JSON.");
      return new List<TaskItem>();
    }
    catch (IOException)
    {
      Console.WriteLine("Error: Could not read tasks.json.");
      return new List<TaskItem>();
    }
  }
  public TaskItem AddTask(string description)
  {
    List<TaskItem> tasks = LoadTasks();

    int newId = tasks.Count == 0
        ? 1
        : tasks.Max(task => task.Id) + 1;

    DateTime now = DateTime.Now;

    TaskItem task = new TaskItem
    {
      Id = newId,
      Description = description,
      Status = TaskStatus.Todo,
      CreatedAt = now,
      UpdatedAt = now
    };

    tasks.Add(task);


    return task;
  }
  public bool UpdateTask(int id, string description)
  {
    List<TaskItem> tasks = LoadTasks();

    TaskItem? task = tasks.FirstOrDefault(task => task.Id == id);

    if (task is null)
    {
      return false;
    }

    task.Description = description;
    task.UpdatedAt = DateTime.Now;

    // SaveTasks(tasks);

    return true;
  }
}