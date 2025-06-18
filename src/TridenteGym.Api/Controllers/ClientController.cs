using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
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
        private readonly IUserService _userService;

        public ClientController(IClientService clientService, IUserService userService)
        {
            _clientService = clientService;
            _userService = userService;
        }

        [HttpGet("{clientId}/GetAllActivitiesEnrollments")]
        public async Task<ActionResult<List<ActivityDto>>> GetAllActivitiesEnrollments([FromRoute] int clientId)
        {
            // Validar que el usuario sea Client
            var user = await _userService.GetUserByIdAsync(clientId);
            if (user == null || user.Role != UserRole.Client)
                return BadRequest("El ID proporcionado no corresponde a un cliente.");

            try
            {
                var activities = await _clientService.GetClientActivities(clientId);
                Console.WriteLine($"Actividades encontradas: {activities.Count}");
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