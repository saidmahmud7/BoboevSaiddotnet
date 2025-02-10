using Domain.Entities;

namespace Domain.DTO_s;

public class BaseWorkoutDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int UserId { get; set; }
    public DateTime StartTime { get; set; }
    public TimeSpan Duration { get; set; }
    public int MaxParticipants { get; set; }
}

public class GetWorkoutDto : BaseWorkoutDto
{
    public int Id { get; set; }
}

public class CreateWorkoutDto : BaseWorkoutDto
{
    
}

public class UpdateWorkoutDto : BaseWorkoutDto
{
    public int Id { get; set; }
}

public class DeleteWorkoutDto : BaseWorkoutDto
{
    public int Id { get; set; }
}