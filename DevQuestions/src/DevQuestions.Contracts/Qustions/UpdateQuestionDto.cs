namespace DevQuestions.Contracts.Qustions;

public record UpdateQuestionDto(string Title, string Body, Guid[] TagIds);
