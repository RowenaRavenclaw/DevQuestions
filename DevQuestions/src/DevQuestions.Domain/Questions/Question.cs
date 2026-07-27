using DevQuestions.Domain.Reports;

namespace DevQuestions.Domain.Questions;

public class Question
{
    public Question(Guid id, string title, string text, Guid userId, Guid? screenShotId, IEnumerable<Guid> tags)
    {
        Id = id;
        Title = title;
        Text = text;
        UserId = userId;
        ScreenShotId = screenShotId;
        Tags = tags.ToList();
        QuestionStatus = QuestionStatus.OPEN;
    }

    public Guid Id { get; set; }

    public string Title { get; set; }

    public string Text { get; set; }

    public Guid UserId { get; set; }

    public Guid? ScreenShotId { get; set; }

    public List<Answer> Answers { get; set; } = [];

    public Answer? Solution { get; set; }

    public List<Guid> Tags { get; set; } = [];

    public QuestionStatus QuestionStatus { get; set; }
}