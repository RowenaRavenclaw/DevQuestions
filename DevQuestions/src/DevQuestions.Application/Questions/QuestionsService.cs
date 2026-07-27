using DevQuestions.Contracts.Qustions;
using DevQuestions.Domain.Questions;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace DevQuestions.Application.Questions;

public class QuestionsService : IQuestionsService
{
    private readonly IQuestionsRepository? _questionsRepository;
    private readonly ILogger<QuestionsService> _logger;
    private readonly IQuestionsRepository _questionsRepository1;
    private readonly IValidator<CreateQuestionDto> _validator;

    public QuestionsService(
        IQuestionsRepository? questionsRepository,
        IValidator<CreateQuestionDto> validator,
        ILogger<QuestionsService> logger, IQuestionsRepository questionsRepository1)
    {
        if (questionsRepository1 == null)
        {
            throw new ArgumentNullException(nameof(questionsRepository1));
        }

        if (questionsRepository1 == null)
        {
            throw new ArgumentNullException(nameof(questionsRepository1));
        }

        _questionsRepository = questionsRepository;
        _logger = logger;
        _questionsRepository1 = questionsRepository1 ?? throw new ArgumentNullException(nameof(questionsRepository1));
        _validator = validator;
    }

    public async Task<Guid> Create(CreateQuestionDto questionDto, CancellationToken cancellationToken)
    {
        // ვალიდაცია
        var validationResult = await _validator.ValidateAsync(questionDto, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        // ბიზნეს ლოგიკის ვალიდაცია
        int userQuestionsCount =
            await _questionsRepository.GetOpenedUSerQuestions(questionDto.UserId, cancellationToken);
        if (userQuestionsCount >= 3)
        {
            throw new ValidationException("User has reached the maximum number of open questions");
        }

        // უნდა შეიქმნას entity Question
        var questionId = Guid.NewGuid();

        var question = new Question(
            questionId,
            questionDto.Title,
            questionDto.Text,
            questionDto.UserId,
            null,
            questionDto.TagIds);

        // მონაცემთა ბაზაში შენახვა
        await _questionsRepository.AddAsync(question, cancellationToken);


        // ლოგირება წარმატებულ ან წარუმატებელ შენახვაზე
        _logger.LogInformation("Question {questionId} created", questionId);

        return questionId;
    }

    // public async Task<IActionResult> Update(
    //     [FromQuery] UpdateQuestionDto? questionDto,
    //     CancellationToken cancellationToken)
    // {
    //     return Ok("Questions Update");
    // }
    //
    // public async Task<IActionResult> Delete([FromRoute] Guid questoinId)
    // {
    //     return Ok("Questions Delete");
    // }
    //
    // public async Task<IActionResult> SelectSolution(
    //     [FromRoute] Guid questionId,
    //     [FromQuery] Guid answerId,
    //     CancellationToken cancellationToken)
    // {
    //     return Ok("Questions SetCorrectAnswer");
    // }
    //
    // public async Task<IActionResult> AddAnswer([FromRoute] Guid questionId, [FromBody] AddAnswerDto answerDto, CancellationToken cancellationToken)
    // {
    //     return Ok("Answer Added");
    // }
}