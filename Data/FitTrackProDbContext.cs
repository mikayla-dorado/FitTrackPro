using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using FitTrackPro.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace FitTrackPro.Data;
public class FitTrackProDbContext : IdentityDbContext<IdentityUser>
{
    private readonly IConfiguration _configuration;
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Workout> Workouts { get; set; }
    public DbSet<UserWorkout> UserWorkouts { get; set; }
    public DbSet<Plan> Plans { get; set; }
    public DbSet<WorkoutType> WorkoutTypes { get; set; }
    public DbSet<DayPlan> DayPlans { get; set; }
    public DbSet<Day> Days{ get; set; }


    public FitTrackProDbContext(DbContextOptions<FitTrackProDbContext> context, IConfiguration config) : base(context)
    {
        _configuration = config;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            Name = "Admin",
            NormalizedName = "admin"
        });

        modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
        {
            Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            UserName = "Administrator",
            Email = "admina@strator.comx",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
        });

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f"
        });
        modelBuilder.Entity<UserProfile>().HasData(new UserProfile
        {
            Id = 1,
            IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            FirstName = "Mikayla",
            LastName = "Dorado",
            Email = "admina@strator.comx",
            Address = "444 Main Street",
        });
        modelBuilder.Entity<Workout>().HasData(new Workout []
        {
            new Workout {Id = 1, Name = "Bicep Curls", WorkoutTypeId = 1, PlanId = null},
            new Workout {Id = 2, Name = "Hammer Curls", WorkoutTypeId = 1, PlanId = null},
            new Workout {Id = 3, Name = "Dead Lifts", WorkoutTypeId = 2, PlanId = null},
            new Workout {Id = 4, Name = "Sumo Squats", WorkoutTypeId = 2, PlanId = null},
            new Workout {Id = 5, Name = "Burpees", WorkoutTypeId = 3, PlanId = null},
            new Workout {Id = 6, Name = "Bicycle Crunches", WorkoutTypeId = 4, PlanId = null},
            new Workout {Id = 7, Name = "Plank", WorkoutTypeId = 4, PlanId = null},
            new Workout {Id = 8, Name = "Jumping Jacks", WorkoutTypeId = 3, PlanId = null}
        });
         modelBuilder.Entity<UserWorkout>().HasData(new UserWorkout []
        {
            new UserWorkout {Id = 1, UserProfileId = 1, WorkoutId = 1},
            new UserWorkout {Id = 2, UserProfileId = 1, WorkoutId = 2},
            new UserWorkout {Id = 3, UserProfileId = 1, WorkoutId = 7},
            new UserWorkout {Id = 4, UserProfileId = 1, WorkoutId = 1}
        });
         modelBuilder.Entity<Plan>().HasData(new Plan []
        {
            new Plan {Id = 1, UserProfileId = 1, WorkoutTypeId = 1},
            new Plan {Id = 2, UserProfileId = 1, WorkoutTypeId = 3},
        });
          modelBuilder.Entity<WorkoutType>().HasData(new WorkoutType []
        {
            new WorkoutType {Id = 1, Name = "Upper Body", WorkoutId = 1},
            new WorkoutType {Id = 2, Name = "Lower Body", WorkoutId = 1},
            new WorkoutType {Id = 3, Name = "Cardio", WorkoutId = 1},
            new WorkoutType {Id = 4, Name = "Abdominal", WorkoutId = null},
            new WorkoutType {Id = 5, Name = "Full-Body", WorkoutId = null}
        });
         modelBuilder.Entity<DayPlan>().HasData(new DayPlan []
        {
            new DayPlan {Id = 1, PlanId = 1, DayId = 2, WorkoutId = 1},
            new DayPlan {Id = 2, PlanId = 1, DayId = 2, WorkoutId = 2}
        });
         modelBuilder.Entity<Day>().HasData(new Day []
        {
            new Day {Id = 1, Name = "Sunday"},
            new Day {Id = 2,  Name = "Monday"},
            new Day {Id = 3,  Name = "Tuesday"},
            new Day {Id = 4,  Name = "Wednesday"},
            new Day {Id = 5,  Name = "Thursday"},
            new Day {Id = 6,  Name = "Friday"},
            new Day {Id = 7,  Name = "Saturday"}
        });
    }
}

//added "Day" to my DB, but still have errors in the console
//this is the error when trying to run the migrations:

// The entity type 'IdentityUserLogin<string>' requires a primary key to be defined. 
// If you intended to use a keyless entity type, call 'HasNoKey' in 'OnModelCreating'. 
// For more information on keyless entity types, see https://go.microsoft.com/fwlink/?linkid=2141943.

//can't figure out the errors still, no migrations