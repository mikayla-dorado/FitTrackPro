namespace FitTrackPro.Models.DTOs;

public class WorkoutDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<WorkoutTypeDTO> WorkoutTypes { get; set; }
    public List<PlanDTO> Plans { get; set; }
}