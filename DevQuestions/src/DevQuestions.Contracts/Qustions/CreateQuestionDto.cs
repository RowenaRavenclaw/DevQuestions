namespace DevQuestions.Contracts.Qustions;

public record CreateQuestionDto(string Title, string Text, Guid UserId, Guid[] TagIds);
