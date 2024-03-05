using FitTrackPro.Models.DTOs;

namespace FitTrackPro.Models;

public class Plan
{
    public int Id { get; set; }
    public int? UserProfileId { get; set; }
    public UserProfile? UserProfile { get; set; }
    public int WorkoutTypeId { get; set; }
    public WorkoutType? WorkoutType { get; set; }
     public List<DayPlan> DayPlans { get; set; }
}