namespace Domain.DTOs.CommentDTOs;

public class GetCommentDTO : BaseCommentDTO
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ArticleId { get; set; }
}
