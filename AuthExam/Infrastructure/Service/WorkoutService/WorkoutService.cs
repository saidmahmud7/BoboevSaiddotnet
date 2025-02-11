using System.Net;
using AutoMapper;
using Domain.DTO_s;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Response;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Service.WorkoutService;

public class WorkoutService(DataContext context,IMapper mapper) : IWorkoutService
{
    public async Task<ApiResponse<List<GetWorkoutDto?>>> GetAllWorkouts()
    {
        var workouts = await context.Workouts.ToListAsync();
        var workoutDto = mapper.Map<List<GetWorkoutDto>>(workouts);
        return new ApiResponse<List<GetWorkoutDto>>(workoutDto);
    }

    public async Task<ApiResponse<GetWorkoutDto?>> GetWorkoutById(int id)
    {
        var workout = await context.Workouts.FirstOrDefaultAsync(x => x.Id == id);
        var workoutDto = mapper.Map<GetWorkoutDto>(workout);
        return new ApiResponse<GetWorkoutDto>(workoutDto);
    }

    public async Task<ApiResponse<string>> CreateWorkout(CreateWorkoutDto workout)
    {
        var workouts = mapper.Map<Workout>(workout);
        await context.Workouts.AddAsync(workouts);
        var res = await context.SaveChangesAsync();
        return res == 0
            ? new ApiResponse<string>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new ApiResponse<string>(HttpStatusCode.OK, "Workout created");
    }

    public async Task<ApiResponse<string>> UpdateWorkout(UpdateWorkoutDto workout)
    {
        var existing = await context.Workouts.FirstOrDefaultAsync(x => x.Id == workout.Id);
        if (existing == null)
        {
            return new ApiResponse<string>(HttpStatusCode.NotFound, "Workout not found");
        }
        existing.Id = workout.Id;
        existing.Title = workout.Title;
        existing.Description = workout.Description;
        existing.StartTime = workout.StartTime;
        existing.UserId = workout.UserId;
        existing.Duration = workout.Duration;
        existing.MaxParticipants = workout.MaxParticipants;
        var res = await context.SaveChangesAsync();
        return res == 0
            ? new ApiResponse<string>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new ApiResponse<string>(HttpStatusCode.OK, "Workout updated");
    }

    public async Task<ApiResponse<string>> DeleteWorkout(int id)
    {

        var existing = await context.Workouts.FirstOrDefaultAsync(x => x.Id == id);
        if (existing == null)
        {
            return new ApiResponse<string>(HttpStatusCode.NotFound, "Workout not found");
        }    
        context.Remove(existing);
        var res = await context.SaveChangesAsync();
        return res == 0
            ? new ApiResponse<string>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new ApiResponse<string>(HttpStatusCode.OK, "Workout deleted");
    }
}