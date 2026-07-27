namespace DevQuestions.Contracts.Qustions;

public record GetQuestionDto(string Search, Guid[] TagIds, int Page, int PageSize);