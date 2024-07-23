using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TridenteGym.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "ClientPolicy")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet("{clientId}/GetAllActivitiesEnrollments")]
        public async Task<ActionResult<List<ActivityDto>>> GetAllActivitiesEnrollments([FromRoute] int clientId)
        {
            try
            {
                var activities = await _clientService.GetClientActivities(clientId);
                if (activities == null || !activities.Any())
                {
                    return NotFound($"No activities found for client with ID {clientId}.");
                }
                return Ok(activities);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}