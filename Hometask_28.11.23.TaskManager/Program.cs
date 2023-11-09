using System;
using System.Collections.Generic;

public enum AccountType
{
    Project,
    Execution,
    Closed
}

public enum TaskStatus
{
    Assigned,
    InProgress,
    UnderReview,
    Completed
}

public class Project
{
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
    public string Initiator { get; set; }
    public string TeamLead { get; set; }
    public List<Task> Tasks { get; set; }
    public AccountType Status { get; set; }

    public Project()
    {
        Tasks = new List<Task>();
    }
}

public class Task
{
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
    public string Initiator { get; set; }
    public string Assignee { get; set; }
    public TaskStatus Status { get; set; }
    public List<Report> Reports { get; set; }

    public Task()
    {
        Reports = new List<Report>();
    }
}

public class Report
{
    public string Text { get; set; }
    public DateTime Date { get; set; }
    public string Assignee { get; set; }
}

class Program
{
    static void Main()
    {
        Project project = new Project
        {
            Description = "Проект Black Mesa",
            Deadline = DateTime.Now.AddDays(30),
            Initiator = "Government",
            TeamLead = "G-Man",
            Status = AccountType.Project
        };

        Task task = new Task
        {
            Description = "Решить проблему с ядром Лямбды",
            Deadline = DateTime.Now.AddDays(7),
            Initiator = "Scientists",
            Assignee = "Dr.Freeman",
            Status = TaskStatus.Assigned
        };

        project.Tasks.Add(task);

        Console.WriteLine($"Описание проекта: {project.Description}");
        Console.WriteLine($"Сроки проекта: {project.Deadline}");
        Console.WriteLine($"Инициатор проекта: {project.Initiator}");
        Console.WriteLine($"Тимлид проекта: {project.TeamLead}");
        Console.WriteLine($"Статус проекта: {project.Status}");

        Console.WriteLine($"Описание задачи: {task.Description}");
        Console.WriteLine($"Сроки задачи: {task.Deadline}");
        Console.WriteLine($"Инициатор задачи: {task.Initiator}");
        Console.WriteLine($"Исполнитель задачи: {task.Assignee}");
        Console.WriteLine($"Статус задачи: {task.Status}");
    }
}