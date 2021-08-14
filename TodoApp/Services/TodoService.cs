using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using TodoApp.Models;
using TodoApp.Services.Interfaces;

namespace TodoApp.Services
{
    public class TodoService : ITodoService
    {
        public readonly TodoContext _context;
        public TodoService(TodoContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<List<Todo>>> GetAllTasks()
        {
            try
            {
               var taskList = await _context.Todo.ToListAsync();
               if (taskList == null) throw new Exception("Task List does not have any items");
               return taskList; 
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error", ex);
            }
        }
        public async Task<ActionResult<Todo>> GetTask(int id)
        {
            try
            {
                var task = await _context.Todo.FirstOrDefaultAsync(x => x.Id == id);
                if (task == null) throw new Exception("Task does not exist");
                return task;
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error", ex);
            }
        }
        public async Task<ActionResult<List<Todo>>> GetCompletedTasks()
        {
            try
            {
                var completedTasks = await _context.Todo.Where(x => x.IsCompleted).ToListAsync();
                if (completedTasks == null) throw new Exception("No task has been completed yet");
                return completedTasks;
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error ", ex);
            }
        }
        public async Task<bool> AddTask(Todo model)
        {
            try
            {
                if(model != null)
                {
                    _context.Add(model);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error while adding a task", ex);
            }

        }
        public async Task<bool> DeleteTask(int id)
        {
            try
            {
                var taskToDelete = await _context.Todo.FirstOrDefaultAsync(x => x.Id == id);
                if(taskToDelete != null)
                {
                    _context.Remove(taskToDelete);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error while deleting a task", ex);
            }
        }
        public async Task<bool> ModTask(Todo task)
        {
            try
            {
                var taskToMod = await _context.Todo.FirstOrDefaultAsync(x => x.Id == task.Id);

                if(taskToMod != null)
                {
                    taskToMod.Title = task.Title;
                    taskToMod.Description = task.Description;
                    taskToMod.IsCompleted = task.IsCompleted;

                    await _context.SaveChangesAsync();

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error while updating a task", ex);
            }
        }
    }
}
