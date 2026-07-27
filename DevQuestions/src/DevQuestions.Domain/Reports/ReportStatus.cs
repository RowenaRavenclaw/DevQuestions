namespace DevQuestions.Domain.Reports;

public class ReportStatus
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid ReportedUserId { get; set; }

    public required string Reason { get; set; }

    public QuestionStatus QuestionStatus { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public Guid? ResolvedByUserId { get; set; }
}