using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiProduct.Service.Interface;
using ApiProduct.Dto.User;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsers()
    {
        return Ok(await _userService.GetAllUsersAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDTO>> GetUserById(int id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        return user != null ? Ok(user) : NotFound("Usuário não encontrado");
    }

    [HttpPost]
    public async Task<ActionResult<UserDTO>> CreateUser(CreateUserDTO createUserDto)
    {
        var user = await _userService.CreateUserAsync(createUserDto);
        return CreatedAtAction(nameof(GetUserById), new { id = user.UserId }, user);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, UpdateUserDTO updateUserDto)
    {
        if (await _userService.UpdateUserAsync(id, updateUserDto))
            return NoContent();
        return NotFound("Usuário não encontrado");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        if (await _userService.DeleteUserAsync(id))
            return NoContent();
        return NotFound("Usuário não encontrado");
    }
}
