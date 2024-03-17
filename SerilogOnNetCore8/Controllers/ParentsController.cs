using Business.Interfaces;
using Entities.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace SerilogOnNetCore8.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ParentsController(IParentService parentService, ILogger<ParentsController> logger) : ControllerBase
{
	private readonly IParentService _parentService = parentService;
	private readonly ILogger<ParentsController> _logger = logger;

	[HttpGet()]
	public async Task<ActionResult<Parent>> GetParent(string parentId)
	{
		var guid = Guid.NewGuid().ToString();
		try
		{
			//This shows you the request payload before its touched.
			_logger.LogInformation($"Request: --{guid}-- {parentId}");
			Parent? parent = await _parentService.GetParent(parentId);
			//This shows you what you give back to them. The guid pairs the request with everything tied to it.
			//Don't forget to serialize from Object to string for the logger to be happy.
			_logger.LogInformation($"Response: --{guid}-- {JsonSerializer.Serialize(parent)}");

			return parent is null ? NoContent() : Ok(parent);
		}
		catch (ArgumentException aE)
		{
			//We want to atleast 400s and 500s.
			//400 means consumer is wrong. 500 means server or backend is wrong.
			_logger.LogError(aE, $"Error: --{guid}-- {aE.Message}");
			return BadRequest(aE.Message);
		}
		catch (Exception e)
		{
			//This bucket makes sure anything thrown is caught as long as your async maps down properly.
			//There are options to cover deeper in the code. Remember now that your logger is integrated with Net Core
			//The ILogger type can be injected everywhere.
			_logger.LogError(e, $"Error: --{guid}-- {e.Message}");
			return StatusCode(500, e.Message);
		}
	}
}
