﻿using Application.DTOs;
using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TridenteGym.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "ProfessorPolicy")]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorService _profesService;
        public ProfessorController(IProfessorService professorService)
        {
            _profesService = professorService;
        }

        [HttpGet("{professorId}/clients")]
        public async Task<ActionResult<List<ClientDto>>> GetClientsEnrolledInMyActivities([FromRoute] int professorId)
        {
            try
            {
                var clients = await _profesService.GetClientsEnrolledInMyActivities(professorId);
                if (clients == null || !clients.Any())
                {
                    return NotFound($"No clients found for professor with ID {professorId}.");
                }
                return Ok(clients);
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
