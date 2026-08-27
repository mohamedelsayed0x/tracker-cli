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



  private void SaveTasks(List<TaskItem> tasks)
  {
    try
    {
      string json = JsonSerializer.Serialize(tasks, _jsonOptions);

      File.WriteAllText(_filePath, json);
    }
    catch (IOException)
    {
      Console.WriteLine("Error: Could not save tasks.");
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

    SaveTasks(tasks);

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

    SaveTasks(tasks);

    return true;
  }
  public bool DeleteTask(int id)
  {
    List<TaskItem> tasks = LoadTasks();

    TaskItem? task = tasks.FirstOrDefault(task => task.Id == id);

    if (task is null)
    {
      return false;
    }

    tasks.Remove(task);

    // SaveTasks(tasks);

    return true;
  }
  public bool MarkInProgress(int id)
  {
    return ChangeStatus(id, TaskStatus.InProgress);
  }
  public bool MarkDone(int id)
  {
    return ChangeStatus(id, TaskStatus.Done);
  }
  private bool ChangeStatus(int id, TaskStatus status)
  {
    List<TaskItem> tasks = LoadTasks();

    TaskItem? task = tasks.FirstOrDefault(task => task.Id == id);

    if (task is null)
    {
      return false;
    }

    task.Status = status;
    task.UpdatedAt = DateTime.Now;

    SaveTasks(tasks);

    return true;
  }
  public List<TaskItem> GetAllTasks()
  {
    return LoadTasks();
  }
  public List<TaskItem> GetTasksByStatus(TaskStatus status)
  {
    return LoadTasks()
        .Where(task => task.Status == status)
        .ToList();
  }
}