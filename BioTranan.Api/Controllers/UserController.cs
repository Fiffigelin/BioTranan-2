using BioTranan.Core.Entities;
using BioTranan.Core.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BioTranan.Api.Controllers;

[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpPost]
    public async Task<ActionResult<User>> PostUser(string email)
    {
        var result = await this._userRepository.CreateUser(email);

        if (result == null) return NoContent();

        return Ok(result);
    }
}