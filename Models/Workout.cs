using FitTrackPro.Models.DTOs;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FitTrackPro.Models;

public class Workout
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    [ForeignKey("WorkoutType")]
    public int? WorkoutTypeId { get; set; }
    [InverseProperty("Workout")]
    public WorkoutType? WorkoutType { get; set; }
    public int? PlanId { get; set; }
    public Plan Plan { get; set; }
}

//The [ForeignKey] attribute is used to specify the foreign key property for the one-to-one relationship.
//The [InverseProperty] attribute is used to specify the navigation property that represents the inverse navigation of the relationship.

//after adding this and adjusting the WorkoutType model i am getting this error
//"The entity type 'IdentityUserLogin<string>' requires a primary key to be defined. If you intended to use a keyless entity type, 
//call 'HasNoKey' in 'OnModelCreating'. For more information on keyless entity types, see https://go.microsoft.com/fwlink/?linkid=2141943."