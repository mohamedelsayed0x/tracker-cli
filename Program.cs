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

