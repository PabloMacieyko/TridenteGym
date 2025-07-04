﻿using Application.DTOs;
using Application.Interfaces;
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
                //// Validar que el ID corresponde a un profesor existente
                //var professor = await _profesService.GetByIdAsync(professorId);
                //if (professor == null)
                //{
                //    return BadRequest("The ID provided does not correspond to a teacher.");
                //}

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
