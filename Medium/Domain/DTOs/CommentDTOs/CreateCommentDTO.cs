namespace Domain.DTOs.CommentDTOs;

public class CreateCommentDTO : BaseCommentDTO{
    public int UserId { get; set; }
    public int ArticleId { get; set; }
}
