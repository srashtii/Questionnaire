using Microsoft.AspNetCore.Mvc;
using QuestionDomain;
using Questionnaire_API.Interfaces;
using Questionnaire_API.Models;
using Questionnaire_API.Services;
using System.Text.Json;

namespace Questionnaire_API.Controllers
{
    [ApiController]
    [Route("questionnaireApi/questions")]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionsController(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository ?? throw new ArgumentNullException(nameof(questionRepository));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestionDto>>> GetQuestions(
             int pageNumber = 1, int pageSize = 2
            )
        {

            var (questionEntities, paginationData) = await _questionRepository.GetQuestionsAsync(pageSize, pageNumber);
            if (questionEntities.Any())
            {
                var questionsDtos = questionEntities.Select(questionEntity => new QuestionDto
                {
                    Id = questionEntity.Id,
                    Text = questionEntity.Text,
                    Type = questionEntity.Type,
                    AnswerOptions = GetAnswerOptionDtos(questionEntity)

                });
                Response.Headers.Add("X-pagination", JsonSerializer.Serialize(paginationData));
                return Ok(questionsDtos);
            }
            return Ok(Enumerable.Empty<QuestionDto>());
        }
        private List<AnswerOptionDto> GetAnswerOptionDtos(Question questionEntity)
        {
            if (questionEntity.AnswerOptions != null)
            {
                var answeroptions = questionEntity.AnswerOptions.Select(x => new AnswerOptionDto
                {
                    Id = x.Id,
                    QuestionId = x.QuestionId,
                    Title = x.Title,
                    IsAnswer = x.IsAnswer
                }).ToList();
                return answeroptions;
            };
            return Enumerable.Empty<AnswerOptionDto>().ToList();
        }
    }
}
