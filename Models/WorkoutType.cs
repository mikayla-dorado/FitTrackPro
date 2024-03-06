using System.ComponentModel.DataAnnotations.Schema;
using FitTrackPro.Models.DTOs;

namespace FitTrackPro.Models;

public class WorkoutType 
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? WorkoutId { get; set; }
    [ForeignKey("WorkoutId")]
    public Workout? Workout { get; set; }
}