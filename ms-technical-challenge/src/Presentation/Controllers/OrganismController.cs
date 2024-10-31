namespace SB.TechnicalChallenge.Presentation.Controllers;

using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SB.TechnicalChallenge.Application;

public class OrganismController : BaseApiController
{
    public OrganismController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    [ProducesResponseType((typeof(IEnumerable<OrganismViewModel>)), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ApiError), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Get()
    {
        var request = new GetAllOrganismQuery();
        var result = await _mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("id")]
    [ProducesResponseType((typeof(IEnumerable<OrganismViewModel>)), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ApiError), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetById([FromQuery] Guid id)
    {
        var request = new GetOrganismByIdQuery(id);
        var result = await _mediator.Send(request);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    [ProducesResponseType(typeof(ApiError), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Create(RegisterOrganismCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(Create), result);
    }

    [HttpPut]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ApiError), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Update(UpdateOrganismCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ApiError), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Delete(DeleteOrganismCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}
