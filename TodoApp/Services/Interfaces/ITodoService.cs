using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Models;

namespace TodoApp.Services.Interfaces
{
    public interface ITodoService
    {
        Task<ActionResult<List<Todo>>> GetAllTasks();
        Task<ActionResult<Todo>> GetTask(int id);
        Task<ActionResult<List<Todo>>> GetCompletedTasks();
        Task<bool> AddTask(Todo model);
        Task<bool> DeleteTask(int id);
        Task<bool> ModTask(Todo model);
    }
}
