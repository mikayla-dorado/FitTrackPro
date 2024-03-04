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
public class PlanController : ControllerBase
{
    private FitTrackProDbContext _dbContext;

    public PlanController(FitTrackProDbContext context)
    {
        _dbContext = context;
    }

    //get plans
    // [HttpGet]
    // [Authorize]
    // public IActionResult Get()
    // {

    // }
}