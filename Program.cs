using CLI_Application.Models;
using CLI_Application.Services;

TaskService taskService = new TaskService();

if (args.Length == 0)
{
  ShowHelp();
  return;
}
