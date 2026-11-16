
using System.Reflection.Metadata;

class Program
{
    static async Task Main()
    {
        string connectionString = """
        Server=localhost;
        Database=TaskManagementDb;
        Integrated Security=True;
        TrustServerCertificate=True;
        """;
        var connectionFactory = new SqlConnectionFactory(connectionString);
        var taskRepository = new TaskRepository(connectionFactory);
        var taskService = new TaskService(taskRepository);
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nSelect one of the following actions(Enter a number):");
            Console.WriteLine("1. Add task");
            Console.WriteLine("2. Show all tasks");
            Console.WriteLine("3. Find task by ID");
            Console.WriteLine("4. Update task");
            Console.WriteLine("5. Complete task");
            Console.WriteLine("6. Delete task");
            Console.WriteLine("7. Show completed tasks");
            Console.WriteLine("8. Show incompleted tasks");
            Console.WriteLine("9. Search tasks by title");
            Console.WriteLine("10. Display newest tasks first.");
            Console.WriteLine("11. Display oldest tasks first.");
            Console.WriteLine("12. Replace Task.");
            Console.WriteLine("13. Task search.");
            Console.WriteLine("14. Exit");
            Console.Write("Input: ");
            int choice = Validation.GetValidInputForNumber();
            switch (choice)
            {
                case 1:
                    await taskService.CreateTask();
                    break;
                case 2:
                    await taskService.ShowTasks("all");
                    break;
                case 3:
                    await taskService.FindTaskBy("id");
                    break;
                case 4:
                    await taskService.UpdateTask();
                    break;
                case 5:
                    await taskService.CompleteTask();
                    break;
                case 6:
                    await taskService.DeleteTask();
                    break;
                case 7:
                    await taskService.ShowTasks("completed");
                    break;
                case 8:
                    await taskService.ShowTasks("incompleted");
                    break;
                case 9:
                    await taskService.FindTaskBy("title");
                    break;
                case 10:
                    await taskService.ShowTasks("old");
                    break;
                case 11:
                    await taskService.ShowTasks("new");
                    break;
                case 12:
                    await taskService.ReplaceTask();
                    break;
                case 13:
                    await taskService.Search();
                    break;
                case 14:
                    exit = true;
                    Console.WriteLine("Program completion");
                    break;
                default:
                    Console.WriteLine("Invalid data entered. Please try again. ");
                    break;
            }
        }
    }
}