using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.Models
{
    public class Seed
    {
        public static async Task SeedData(TodoContext context)
        {
            if (context.Todo.Any()) return;

            var tasks = new List<Todo>
            {
                new Todo
                {
                    Title = "Task 1",
                    Description = "Do something",
                    IsCompleted = true,
                },
                new Todo
                {
                    Title = "Task 2",
                    Description = "Do something else",
                    IsCompleted = false,
                },
                new Todo
                {
                    Title = "Task 3",
                    Description = "Code an app",
                    IsCompleted = false,
                },
                new Todo
                {
                    Title = "Task 4",
                    Description = "code some more",
                    IsCompleted = false,
                },
                new Todo
                {
                    Title = "Task 5",
                    Description = "get something to eat",
                    IsCompleted = true,
                }
            };

            context.Todo.AddRange(tasks);
            await context.SaveChangesAsync();
        }
    }
}

