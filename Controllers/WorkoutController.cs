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
    //     var workout = _dbContext
    //     .Workouts
    //     .Include(w => w.WorkoutType)
    //     .Include(w => w.Plan)
    //     .Select(w => new WorkoutDTO
    //     {
    //         Id = w.Id,
    //         Name = w.Name,
    //         WorkoutTypes = w.WorkoutType.Select(wt => new WorkoutTypeDTO
    //         {
    //             Id = wt.Id,
    //             Name = wt.Name
    //         }) //! workout type also has a workoutId, how would this be reprentsented here?
    //     }) //! need to expand on 'Plan'
    // }
    //! not done, may not be correct format
}