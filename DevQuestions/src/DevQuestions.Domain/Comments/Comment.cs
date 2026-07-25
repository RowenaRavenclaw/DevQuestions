namespace DevQuestions.Domain.Comments;

public class Comment
{
    public Guid Id { get; set; }
    
    public required Guid UserId { get; set; }
    
    public Comment? parent{get; set;}

    public required Guid EntityId { get; set; }
    
    public List<Comment> Children { get; set; } = [];
}