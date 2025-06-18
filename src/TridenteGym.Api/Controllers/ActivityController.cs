using Application.DTOs.Requests;
using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace TridenteGym.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "OwnerPolicy")]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService _activityService;
        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        [HttpPost("CreateActivity")]
        public async Task<ActionResult<ActivityDto>> CreateActivity([FromBody] ActivityCreateRequest request)
        {
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRole != "Owner")
                return Forbid();

            return Ok(await _activityService.CreateAsync(request));
        }

        [HttpGet("GetActivity/{id}")]
        public async Task<ActionResult> GetActivity([FromRoute] int id)
        {
            try
            {
                return Ok(await _activityService.GetActivityAsync(id));
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpGet("GetAllActivities")]
        [AllowAnonymous]
        public async Task<ActionResult<List<ActivityDto>>> GetAllActivities()
        {
            return Ok(await _activityService.GetAllAsync());
        }

        [HttpPut("UpdateActivity/{id}")]
        public async Task<ActionResult<ActivityDto>> UpdateActivity([FromBody] UpdateActivityRequest request, int id)
        {
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRole != "Owner")
                return Forbid();

            try
            { 
                var activityDto = new ActivityDto
                {
                    ActivityId = id, // El id viene por la ruta
                    Title = request.Title,
                    Description = request.Description,
                    ProfessorId = request.ProfessorId,
                    Price = request.Price,
                    AvailableSlots = request.AvailableSlots
                };

                return Ok(await _activityService.UpdateAsync(activityDto, id));
            }
            catch (Exception ex)
            {
                return NotFound($"{ex.Message}");
            }
        }

        [HttpDelete("DeleteActivity/{id}")]
        public async Task<ActionResult> DeleteActivity([FromRoute] int id)
        {
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRole != "Owner")
                return Forbid();

            try
            {
                await _activityService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound($"{ex.Message}");
            }
        }
    }
}
