﻿using JungleCafe.Server.DTOs;
using JungleCafe.Server.Models;
using JungleCafe.Server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JungleCafe.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(IUsersService usersService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        var users = await usersService.GetUsers();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        var user = await usersService.GetUser(id);
        if (user == null)
            return NotFound();

        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<User>> CreateUser(User user)
    {
        var created = await usersService.CreateUser(user);
        return CreatedAtAction(nameof(GetUser), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<User>> UpdateUser(int id, UserUpdateDto userUpdateDto)
    {
        if (id != userUpdateDto.id)
            return BadRequest("ID mismatch");

        var updated = await usersService.UpdateUser(id, userUpdateDto);
        if (updated == null)
            return NotFound();

        return Ok(updated);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var result = await usersService.DeleteUser(id);
        if (!result)
            return NotFound();

        return NoContent();
    }

    [HttpGet("caretakers")]
    public async Task<ActionResult<IEnumerable<User>>> GetCaretakers()
    {
        var caretakers = await usersService.GetCaretakers();
        return Ok(caretakers);
    }
}