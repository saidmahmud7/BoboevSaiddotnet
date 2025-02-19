namespace Domain.DTOs.CommentDTOs;

public class UpdateCommentDTO : BaseCommentDTO
{
    public int UserId { get; set; }
    public int ArticleId { get; set; }
}
