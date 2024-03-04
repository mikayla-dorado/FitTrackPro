using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FitTrackPro.Data;
using FitTrackPro.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using FitTrackPro.Models;

namespace FitTrackPro.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserProfileController : ControllerBase
{
    private FitTrackProDbContext _dbContext;

    public UserProfileController(FitTrackProDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        return Ok(_dbContext
            .UserProfiles
            .Include(up => up.IdentityUser)
            .Select(up => new UserProfileDTO
            {
                Id = up.Id,
                FirstName = up.FirstName,
                LastName = up.LastName,
                Address = up.Address,
                IdentityUserId = up.IdentityUserId,
                Email = up.Email,
                UserName = up.IdentityUser.UserName
            })
            .ToList());
    }

    [HttpGet("withroles")]
    [Authorize(Roles = "Admin")]
    public IActionResult GetWithRoles()
    {
        return Ok(_dbContext.UserProfiles
        .Include(up => up.IdentityUser)
        .Select(up => new UserProfileDTO
        {
            Id = up.Id,
            FirstName = up.FirstName,
            LastName = up.LastName,
            Address = up.Address,
            Email = up.IdentityUser.Email,
            UserName = up.IdentityUser.UserName,
            IdentityUserId = up.IdentityUserId,
            Roles = _dbContext.UserRoles
            .Where(ur => ur.UserId == up.IdentityUserId)
            .Select(ur => _dbContext.Roles.SingleOrDefault(r => r.Id == ur.RoleId).Name)
            .ToList()
        }));
    }

    [HttpPost("promote/{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Promote(string id)
    {
        IdentityRole role = _dbContext.Roles.SingleOrDefault(r => r.Name == "Admin");
        // This will create a new row in the many-to-many UserRoles table.
        _dbContext.UserRoles.Add(new IdentityUserRole<string>
        {
            RoleId = role.Id,
            UserId = id
        });
        _dbContext.SaveChanges();
        return NoContent();
    }

    [HttpPost("demote/{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Demote(string id)
    {
        IdentityRole role = _dbContext.Roles
            .SingleOrDefault(r => r.Name == "Admin");
        IdentityUserRole<string> userRole = _dbContext
            .UserRoles
            .SingleOrDefault(ur =>
                ur.RoleId == role.Id &&
                ur.UserId == id);

        _dbContext.UserRoles.Remove(userRole);
        _dbContext.SaveChanges();
        return NoContent();
    }

    //get user profiles by id
    // [HttpGet("{id}")]
    // [Authorize]
    // public IActionResult GetUserProfilesById(int id)
    // {
    //     UserProfile foundUserProfiles = _dbContext
    //     .UserProfiles
    //     .Include(p => p.IdentityUser)
    //     .Include(p => p.UserChores)
    //     .ThenInclude(uc => uc.Chore)
    //     .SingleOrDefault(up => up.Id == id);

    //     if (foundUserProfiles == null)
    //     {
    //         return NotFound();
    //     }
    //     return Ok(new UserProfileDTO
    //     {
    //         Id = foundUserProfiles.Id,
    //         FirstName = foundUserProfiles.FirstName,
    //         LastName = foundUserProfiles.LastName,
    //         Address = foundUserProfiles.Address,
    //         Email = foundUserProfiles.Email,
    //         UserChores = foundUserProfiles.UserChores.Select(uc => new UserChoresDTO
    //         {
    //             Id = uc.Id,
    //             RoomId = uc.RoomId,
    //             ChoreId = uc.ChoreId,
    //             Chore = new ChoreDTO
    //             {
    //                 Id = uc.Chore.Id,
    //                 Name = uc.Chore.Name,
    //                 Description = uc.Chore.Description,
    //                 DueDate = uc.Chore.DueDate,
    //                 Status = uc.Chore.Status
    //             }
    //         }).ToList()
    //     });
    // }


    //an admin can delete a user
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult DeleteUserProfile(int id)
    {
        UserProfile userProfileDelete = _dbContext.UserProfiles.FirstOrDefault(up => up.Id == id);
        if (userProfileDelete == null)
        {
            return NotFound();
        }

        _dbContext.UserProfiles.Remove(userProfileDelete);
        _dbContext.SaveChanges();

        return NoContent();
    }

    //create a user
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult PostUser(UserProfile userProfile)
    {
        _dbContext.UserProfiles.Add(userProfile);
        _dbContext.SaveChanges();
        return Created($"/userprofiles/{userProfile.Id}", userProfile);
    }

    //edit user
    [HttpPut("{id}")]
    //[Authorize(Roles = "Admin")]
    public IActionResult UpdateUserProfile(int id, UserProfile userProfile)
    {
        UserProfile? userProfileUpdate = _dbContext.UserProfiles.FirstOrDefault(up => up.Id == id);
        if (userProfileUpdate == null)
        {
            return NotFound();
        }
        userProfileUpdate.FirstName = userProfile.FirstName;
        userProfileUpdate.LastName = userProfile.LastName;
        userProfileUpdate.Email = userProfile.Email;
        userProfileUpdate.Address = userProfile.Address;

        _dbContext.SaveChanges();
        return NoContent();
    }
}