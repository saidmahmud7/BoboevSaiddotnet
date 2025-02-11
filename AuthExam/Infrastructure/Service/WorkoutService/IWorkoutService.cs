using Domain.DTO_s;
using Infrastructure.Response;

namespace Infrastructure.Service.WorkoutService;

public interface IWorkoutService
{
    Task<ApiResponse<List<GetWorkoutDto>>> GetAllWorkouts();
    Task<ApiResponse<GetWorkoutDto?>> GetWorkoutById(int id);
    Task<ApiResponse<string>> CreateWorkout(CreateWorkoutDto workout);
    Task<ApiResponse<string>> UpdateWorkout(UpdateWorkoutDto workout);
    Task<ApiResponse<string>> DeleteWorkout(int id);
}