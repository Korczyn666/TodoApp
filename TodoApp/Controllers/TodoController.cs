using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Models;
using TodoApp.Services;
using TodoApp.Services.Interfaces;

namespace TodoApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Todo>>> GetAllTasks()
        {
            return await _todoService.GetAllTasks();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Todo>> GetTask(int id)
        {
            return await _todoService.GetTask(id);
        }
        [HttpGet("/completed")]
        public async Task<ActionResult<List<Todo>>> GetCompletedTasks()
        {
           return await _todoService.GetCompletedTasks();
        }
        [HttpPost]
        public ActionResult AddTask(Todo model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("Model is not valid");
            }
            var result = _todoService.AddTask(model);
            if (result.Exception != null)
            {
                return BadRequest(result.Exception.InnerException.Message);
            }
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteTask(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = _todoService.DeleteTask(id);

            if (result.Exception != null)
            {
                return BadRequest(result.Exception.InnerException.Message);
            }
            return Ok();
        }
        [HttpPut]
        public ActionResult ModTask(Todo task)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result =  _todoService.ModTask(task);
            if (result.Exception != null)
            {
                return BadRequest(result.Exception.InnerException.Message);
            }
            return Ok();
        }

    }
}
