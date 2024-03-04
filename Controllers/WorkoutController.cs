using System.Text.Json;
using System.Xml.Linq;
using FitTrackPro.Data;
using FitTrackPro.Models;
using FitTrackPro.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[ApiController]
[Route("/api/[controller]")]
public class WorkoutController : ControllerBase
{
    private FitTrackProDbContext _dbContext;

    public WorkoutController(FitTrackProDbContext context)
    {
        _dbContext = context;
    }

    //?get workouts
    // [HttpGet]
    // [Authorize]
    // public IActionResult Get()
    // {

    // }
}