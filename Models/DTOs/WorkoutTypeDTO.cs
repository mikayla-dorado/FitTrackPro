namespace FitTrackPro.Models.DTOs;

public class WorkoutTypeDTO 
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<WorkoutDTO> Workouts { get; set; }
}