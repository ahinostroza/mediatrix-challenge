namespace SB.TechnicalChallenge.Presentation.Controllers;

using System.Net;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SB.TechnicalChallenge.Application;

[AllowAnonymous]
public class LoginController : BaseApiController
{
    public LoginController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ApiError), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> SignIn(SignInCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}
