# Task Tracker CLI

A simple **Command-Line Interface (CLI)** application for managing and tracking tasks.

This project was built using **C#** as a solution to the [Task Tracker](https://roadmap.sh/projects/task-tracker) project from **roadmap.sh**.

The application allows you to create, update, delete, and organize tasks by their current status. Tasks are stored locally in a JSON file using the native file system APIs.

---

## Features

- Add new tasks
- Update existing tasks
- Delete tasks
- Mark tasks as `in-progress`
- Mark tasks as `done`
- List all tasks
- List completed tasks
- List pending tasks
- List tasks currently in progress
- Automatically create the JSON storage file if it doesn't exist
- Store task creation and update timestamps
- Handle invalid commands and task IDs gracefully
- Simple and lightweight CLI interface

---

## Technologies

- **C#**
- **.NET**
- **JSON**
- **File System**
- **Command-Line Interface (CLI)**

No external libraries or frameworks are required.

---

## Task Structure

Each task contains the following properties:

```json
{
  "id": 1,
  "description": "Learn C#",
  "status": "todo",
  "createdAt": "2026-08-13T10:00:00",
  "updatedAt": "2026-08-13T10:00:00"
}
```

### Properties

| Property      | Description                                  |
| ------------- | -------------------------------------------- |
| `id`          | Unique identifier for the task               |
| `description` | Short description of the task                |
| `status`      | Current task status                          |
| `createdAt`   | Date and time when the task was created      |
| `updatedAt`   | Date and time when the task was last updated |

### Available Statuses

- `todo`
- `in-progress`
- `done`

---

## Requirements

Before running the project, make sure you have:

- [.NET SDK](https://dotnet.microsoft.com/download) installed
- Git installed (optional, for cloning the repository)

You can verify your .NET installation with:

```bash
dotnet --version
```

---

## Installation

Clone the repository:

```bash
git clone <YOUR_REPOSITORY_URL>
```

Navigate to the project directory:

```bash
cd <PROJECT_DIRECTORY>
```

Build the project:

```bash
dotnet build
```

Run the application:

```bash
dotnet run
```

---

## Usage

The application accepts commands through positional command-line arguments.

### Add a Task

```bash
dotnet run -- add "Buy groceries"
```

Example output:

```text
Task added successfully (ID: 1)
```

---

### Update a Task

```bash
dotnet run -- update 1 "Buy groceries and cook dinner"
```

---

### Delete a Task

```bash
dotnet run -- delete 1
```

---

### Mark Task as In Progress

```bash
dotnet run -- mark-in-progress 1
```

---

### Mark Task as Done

```bash
dotnet run -- mark-done 1
```

---

## Listing Tasks

### List All Tasks

```bash
dotnet run -- list
```

---

### List Completed Tasks

```bash
dotnet run -- list done
```

---

### List Pending Tasks

```bash
dotnet run -- list todo
```

---

### List In-Progress Tasks

```bash
dotnet run -- list in-progress
```

---

## Command Reference

| Command                     | Description                |
| --------------------------- | -------------------------- |
| `add <description>`         | Add a new task             |
| `update <id> <description>` | Update an existing task    |
| `delete <id>`               | Delete a task              |
| `mark-in-progress <id>`     | Mark a task as in progress |
| `mark-done <id>`            | Mark a task as completed   |
| `list`                      | Display all tasks          |
| `list done`                 | Display completed tasks    |
| `list todo`                 | Display pending tasks      |
| `list in-progress`          | Display tasks in progress  |

---

## Data Storage

Tasks are stored locally in a JSON file in the project's current directory.

Example:

```text
tasks.json
```

The file is automatically created when it doesn't exist.

Example:

```json
[
  {
    "id": 1,
    "description": "Learn C#",
    "status": "todo",
    "createdAt": "2026-08-13T10:00:00",
    "updatedAt": "2026-08-13T10:00:00"
  },
  {
    "id": 2,
    "description": "Build a CLI project",
    "status": "done",
    "createdAt": "2026-08-13T10:05:00",
    "updatedAt": "2026-08-13T11:30:00"
  }
]
```

---

## Project Structure

```text
TaskTracker/
│
├── Program.cs
├── Models/
│   └── TaskItem.cs
│
├── Services/
│   └── TaskService.cs
│
├── tasks.json
├── TaskTracker.csproj
└── README.md
```

> The exact structure may vary depending on the implementation.

---

## Error Handling

The application handles common invalid inputs, including:

- Invalid commands
- Missing command arguments
- Invalid task IDs
- Trying to update a task that doesn't exist
- Trying to delete a task that doesn't exist
- Invalid task statuses
- Empty task descriptions

The goal is to provide clear feedback instead of allowing the application to crash unexpectedly.

---

## What I Practiced

This project helped me practice several fundamental C# and software development concepts:

- C# fundamentals
- Object-Oriented Programming
- Classes and objects
- Collections
- Enums
- File handling
- JSON serialization and deserialization
- Command-line arguments
- User input validation
- Exception handling
- Working with dates and timestamps
- CRUD operations
- Git and GitHub

---

## Project Requirements

This project was created as part of the **Task Tracker CLI challenge** from roadmap.sh.

The original challenge focuses on building a CLI application that can:

- Add, update, and delete tasks
- Track task status
- Store tasks in a JSON file
- Work with the native file system
- Handle command-line arguments
- Handle errors and edge cases
- Avoid external libraries and frameworks

---

## Future Improvements

Possible improvements for future versions:

- Add task priorities
- Add due dates
- Add task search
- Add colored CLI output
- Add sorting and filtering options
- Add automated unit tests
- Package the application as a standalone executable
- Add interactive CLI mode

---

## Author

**Mohamed Elsayed**

Backend Developer

---

## License

This project is open-source and available for learning and educational purposes.
