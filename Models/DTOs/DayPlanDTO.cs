namespace FitTrackPro.Models.DTOs;

public class DayPlanDTO
{
    public int Id { get; set; }
    public List<WorkoutDTO> Workout { get; set; }
    public List<PlanDTO> Plan { get; set; }
}