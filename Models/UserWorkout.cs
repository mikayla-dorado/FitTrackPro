using FitTrackPro.Models.DTOs;

namespace FitTrackPro.Models;

public class UserWorkout
{
    public int Id { get; set; }
    public int? UserProfileId { get; set; }
    public UserProfile? UserProfile { get; set; }
    public int WorkoutId { get; set; }
    public Workout? Workout { get; set; }
}