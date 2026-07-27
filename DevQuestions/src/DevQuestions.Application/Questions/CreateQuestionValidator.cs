using DevQuestions.Contracts.Qustions;
using FluentValidation;

namespace DevQuestions.Application.Questions;

public class CreateQuestionValidator : AbstractValidator<CreateQuestionDto>
{
    public CreateQuestionValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MaximumLength(500).WithMessage("Title is required");

        RuleFor(x => x.Text).NotEmpty().MaximumLength(5000).WithMessage("Text is required");

        RuleFor(x => x.UserId).NotEmpty();
    }
}