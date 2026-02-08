using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CustomerSupportTicketSystem.API.DTOs;
using CustomerSupportTicketSystem.API.Services;
using System.Security.Claims;

namespace CustomerSupportTicketSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TicketsController : ControllerBase
{
    private readonly ITicketService _ticketService;

    public TicketsController(ITicketService ticketService)
    {
        _ticketService = ticketService;
    }

    // Create New Ticket
    [HttpPost]
    public async Task<IActionResult> CreateTicket([FromBody] CreateTicketDto createDto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = GetUserId();
            var ticket = await _ticketService.CreateTicketAsync(createDto, userId);

            return CreatedAtAction(nameof(GetTicketDetails), new { id = ticket.TicketId }, ticket);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    // Get All Tickets by User Role
    [HttpGet]
    public async Task<IActionResult> GetTickets()
    {
        try
        {
            var userId = GetUserId();
            var userRole = GetUserRole();

            var tickets = await _ticketService.GetTicketListAsync(userId, userRole);
            return Ok(tickets);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    // Get Ticket Details by ID

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTicketDetails(int id)
    {
        try
        {
            var userId = GetUserId();
            var userRole = GetUserRole();

            var ticket = await _ticketService.GetTicketDetailsAsync(id, userId, userRole);

            if (ticket == null)
                return NotFound(new { message = "Ticket not found or access denied" });

            return Ok(ticket);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    // Assign Ticket to Admin (Admin role required)

    [HttpPut("{id}/assign")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AssignTicket(int id, [FromBody] AssignTicketDto assignDto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var adminUserId = GetUserId();
            var result = await _ticketService.AssignTicketAsync(id, assignDto, adminUserId);

            return Ok(new { message = "Ticket assigned successfully" });
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    // Update ticket status (Admin role required)

    [HttpPut("{id}/status")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateStatus(int id, [FromBody] UpdateStatusDto statusDto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var adminUserId = GetUserId();
            var result = await _ticketService.UpdateTicketStatusAsync(id, statusDto, adminUserId);

            return Ok(new { message = "Status updated successfully" });
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    // Add comment to a ticket
    
    [HttpPost("{id}/comments")]
    public async Task<IActionResult> AddComment(int id, [FromBody] AddCommentDto commentDto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = GetUserId();
            var userRole = GetUserRole();

            var result = await _ticketService.AddCommentAsync(id, commentDto, userId, userRole);

            return Ok(new { message = "Comment added successfully" });
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (UnauthorizedAccessException ex)
        {
            return Forbid(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    // Get list of admin users (Admin role required)

    [HttpGet("admins")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAdmins()
    {
        try
        {
            var admins = await _ticketService.GetAdminUsersAsync();
            return Ok(admins);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    // Helper methods to get user info from JWT claims
    
    private int GetUserId()
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return int.Parse(userIdClaim ?? "0");
    }

    private string GetUserRole()
    {
        return User.FindFirst(ClaimTypes.Role)?.Value ?? "User";
    }
}
