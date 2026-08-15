using System.Text.Json;
using CLI_Application.Models;

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
}