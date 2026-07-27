namespace DevQuestions.Domain.Reports;

public enum QuestionStatus
{
    /// <summary>
    /// სტატუსი ღიაა
    /// </summary>
    OPEN,

    /// <summary>
    /// სამუშაო პროცესში
    /// </summary>
    IN_PROGRESS,

    /// <summary>
    /// გადაწყვეტილი
    /// </summary>
    RESOLVED,

    /// <summary>
    /// დაუსრულებელი
    /// </summary>
    DISMISSED
}