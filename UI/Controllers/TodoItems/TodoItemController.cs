﻿using Application.TodoItems;
using Application.TodoItems.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers.TodoItems
{
    [Route("api/todoitems")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        private readonly ITodoItemAppService _todoItemAppService;
        public TodoItemController(ITodoItemAppService todoItemAppService)
        {
            _todoItemAppService = todoItemAppService;
        }
        [HttpGet("GetList")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _todoItemAppService.GetAllAsync();
            return Ok(result);
        }
        [HttpGet("Get")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _todoItemAppService.GetAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateTodoItemDto input)
        {
            if (input == null)
            {
                return BadRequest("Input cannot be null");
            }

            var result = await _todoItemAppService.AddAsync(input);

            if (result)
            {
                // 201 Created döner, body içine true konur.
                return CreatedAtAction(nameof(Add), true);
                // veya: return Created("", true);  // Lokasyon vermek istemiyorsan
            }

            return BadRequest("Failed to create Todo Item");
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(int id, [FromBody] TodoItemDto input)
        {
            if (input == null || id != input.Id)
            {
                return BadRequest("Input cannot be null or ID mismatch");
            }
            var result = await _todoItemAppService.UpdateAsync(input);
            if (result)
            {
                return Ok(true);
            }
            return NotFound("Todo Item not found");
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _todoItemAppService.Delete(id);
            if (result)
            {
                return Ok(true);
            }
            return NotFound("Todo Item not found");
        }

    }
}
