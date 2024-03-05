namespace FitTrackPro.Models.DTOs;

public class UserWorkoutDTO
{
    public int Id { get; set; }
    public List<WorkoutDTO> Workouts { get; set; }
     public List<UserProfileDTO> UserProfiles { get; set; }
}