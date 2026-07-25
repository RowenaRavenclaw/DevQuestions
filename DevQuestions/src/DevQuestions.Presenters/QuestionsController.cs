using DevQuestions.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DevQuestions.Presenters;

[ApiController]
[Route("[controller]")]
public class QuestionsController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateQuestionDto questionDto, CancellationToken cancellationToken)
    {
        return Ok("Questions Post");
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetQuestionDto? questionDto, CancellationToken cancellationToken)
    {
        return Ok("Questions Get");
    }

    [HttpGet("{questoinId:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid questoinId, CancellationToken cancellationToken)
    {
        return Ok("Questions GetById");
    }

    [HttpPut("{questoinId:guid}")]
    public async Task<IActionResult> Update(
        [FromRoute] Guid questoinId,
        [FromQuery] UpdateQuestionDto? questionDto,
        CancellationToken cancellationToken)
    {
        return Ok("Questions Update");
    }

    [HttpDelete("{questoinId:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid questoinId)
    {
        return Ok("Questions Delete");
    }

    [HttpPut("{questionId:guid}/solution")]
    public async Task<IActionResult> SelectSolution(
        [FromRoute] Guid questionId,
        [FromQuery] Guid answerId,
        CancellationToken cancellationToken)
    {
        return Ok("Questions SetCorrectAnswer");
    }

    [HttpPost("{questionId:guid}/answers")]
    public async Task<IActionResult> AddAnswer([FromRoute] Guid questionId, [FromBody] AddAnswerDto answerDto, CancellationToken cancellationToken)
    {
        return Ok("Answer Added");
    }
}

