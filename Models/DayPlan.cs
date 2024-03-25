using FitTrackPro.Models.DTOs;

namespace FitTrackPro.Models;

public class DayPlan
{
    public int Id { get; set; }
    public int PlanId { get; set; }
    public Plan Plans {get; set; }
    public int DayId { get; set; }
    public Day Day { get; set; }
    public int WorkoutId { get; set; }
    public Workout Workout { get; set; }
}