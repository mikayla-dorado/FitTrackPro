using FitTrackPro.Models.DTOs;

namespace FitTrackPro.Models;

public class Workout
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? WorkoutTypeId { get; set; }
    public WorkoutType? WorkoutType { get; set; }
    public int? PlanId { get; set; }
    public Plan? Plan { get; set; }
}