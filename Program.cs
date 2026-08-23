using CLI_Application.Models;
using CLI_Application.Services;

TaskService taskService = new TaskService();

if (args.Length == 0)
{
  ShowHelp();
  return;
}
string command = args[0].ToLower();

switch (command)
{
  case "add":
    // AddTask();
    break;

  case "update":
    // UpdateTask();
    break;

  case "delete":
    // DeleteTask();
    break;

  case "mark-in-progress":
    // MarkInProgress();
    break;

  case "mark-done":
    // MarkDone();
    break;

  case "list":
    // ListTasks();
    break;

  case "help":
    // ShowHelp();
    break;

  default:
    Console.WriteLine($"Unknown command: '{args[0]}'.");
    Console.WriteLine();
    // ShowHelp();
    break;
}
void AddTask()
{
  if (args.Length < 2)
  {
    Console.WriteLine("Error: Task description is required.");
    Console.WriteLine("Usage: dotnet run -- add \"Task description\"");
    return;
  }

  string description = string.Join(" ", args.Skip(1)).Trim();

  if (string.IsNullOrWhiteSpace(description))
  {
    Console.WriteLine("Error: Task description cannot be empty.");
    return;
  }

  TaskItem task = taskService.AddTask(description);

  Console.WriteLine($"Task added successfully (ID: {task.Id})");
}

void UpdateTask()
{
  if (args.Length < 3)
  {
    Console.WriteLine("Error: Task ID and description are required.");
    Console.WriteLine("Usage: dotnet run -- update <id> \"Task description\"");
    return;
  }

  if (!int.TryParse(args[1], out int id))
  {
    Console.WriteLine("Error: Task ID must be a valid number.");
    return;
  }

  string description = string.Join(" ", args.Skip(2)).Trim();

  if (string.IsNullOrWhiteSpace(description))
  {
    Console.WriteLine("Error: Task description cannot be empty.");
    return;
  }

  bool updated = taskService.UpdateTask(id, description);

  if (!updated)
  {
    Console.WriteLine($"Error: Task with ID {id} was not found.");
    return;
  }

  Console.WriteLine($"Task {id} updated successfully.");
}
void DeleteTask()
{
  if (args.Length < 2)
  {
    Console.WriteLine("Error: Task ID is required.");
    Console.WriteLine("Usage: dotnet run -- delete <id>");
    return;
  }

  if (!int.TryParse(args[1], out int id))
  {
    Console.WriteLine("Error: Task ID must be a valid number.");
    return;
  }

  bool deleted = taskService.DeleteTask(id);

  if (!deleted)
  {
    Console.WriteLine($"Error: Task with ID {id} was not found.");
    return;
  }

  Console.WriteLine($"Task {id} deleted successfully.");
}
void MarkInProgress()
{
  if (args.Length < 2)
  {
    Console.WriteLine("Error: Task ID is required.");
    Console.WriteLine("Usage: dotnet run -- mark-in-progress <id>");
    return;
  }

  if (!int.TryParse(args[1], out int id))
  {
    Console.WriteLine("Error: Task ID must be a valid number.");
    return;
  }

  bool updated = taskService.MarkInProgress(id);

  if (!updated)
  {
    Console.WriteLine($"Error: Task with ID {id} was not found.");
    return;
  }

  Console.WriteLine($"Task {id} marked as in-progress.");
}
void MarkDone()
{
  if (args.Length < 2)
  {
    Console.WriteLine("Error: Task ID is required.");
    Console.WriteLine("Usage: dotnet run -- mark-done <id>");
    return;
  }

  if (!int.TryParse(args[1], out int id))
  {
    Console.WriteLine("Error: Task ID must be a valid number.");
    return;
  }

  bool updated = taskService.MarkDone(id);

  if (!updated)
  {
    Console.WriteLine($"Error: Task with ID {id} was not found.");
    return;
  }

  Console.WriteLine($"Task {id} marked as done.");
}

