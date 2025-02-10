using Domain.DTO_s;
using Infrastructure.Response;
using Infrastructure.Service.WorkoutService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controller;

[ApiController]
[Route("[controller]")]
[Authorize(Roles = "Trainer,Admin")]
public class WorkoutController(IWorkoutService service)
{
    [HttpPut]
    public async Task<ApiResponse<string>> UpdateWorkout(UpdateWorkoutDto workout) =>
        await service.UpdateWorkout(workout);

    [HttpPost]
    public async Task<ApiResponse<string>> CreateWorkout(CreateWorkoutDto workout) =>
        await service.CreateWorkout(workout);

    [HttpDelete("{id}")]
    public async Task<ApiResponse<string>> DeleteWorkout(int id) => await service.DeleteWorkout(id);

    [HttpGet("{id}")]
    [Authorize(Roles = "Client,Trainer,Admin")]
    public async Task<ApiResponse<GetWorkoutDto?>> GetWorkoutById(int id) => await service.GetWorkoutById(id);

    [HttpGet]
    [Authorize(Roles = "Client,Trainer,Admin")]
    public async Task<ApiResponse<List<GetWorkoutDto>>> GetAllWorkouts() => await service.GetAllWorkouts();
}