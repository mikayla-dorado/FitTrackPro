using FitTrackPro.Models.DTOs;

namespace FitTrackPro.Models;

public class WorkoutType 
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? WorkoutId { get; set; }
    public Workout? Workout { get; set; }
}