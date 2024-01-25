using HHD.API.Controllers.Common;
using HHD.Domain.Configurations;
using HHD.Service.DTOs.Users;
using HHD.Service.Interfaces.Users;
using Microsoft.AspNetCore.Mvc;

namespace HHD.API.Controllers;

public class UsersController(IUserService userService) : BaseController
{
    [HttpGet]
    public async ValueTask<IActionResult> Get([FromQuery] PaginationParams @params, CancellationToken cancellationToken)
    {
        var result = await userService.GetAllAsync(@params, cancellationToken: cancellationToken);

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async ValueTask<IActionResult> GetById([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var result = await userService.GetByIdAsync(id, cancellationToken: cancellationToken);

        return Ok(result);
    }

    [HttpPost]
    public async ValueTask<IActionResult> Create([FromBody] UserForCreationDto userForCreationDto, CancellationToken cancellationToken)
    {
        var result = await userService.CreateAsync(userForCreationDto, cancellationToken: cancellationToken);

        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    public async ValueTask<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UserForUpdateDto userForUpdateDto, CancellationToken cancellationToken)
    {
        var result = await userService.UpdateAsync(userForUpdateDto, id, cancellationToken: cancellationToken); 

        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async ValueTask<IActionResult> DeleteAsync([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var result = await userService.DeleteAsync(id, cancellationToken: cancellationToken);

        return Ok(result);
    }
}
