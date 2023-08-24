using Microsoft.AspNetCore.Mvc;
using QuestionDomain;
using Questionnaire_API.Interfaces;
using Questionnaire_API.Models;

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
        public async Task<ActionResult<IEnumerable<QuestionDto>>> GetQuestions(int? id)
        {
            if (id == null)
            {
                var questionEntities = await _questionRepository.GetQuestionsAsync();
                var questionsDtos = questionEntities.Select(questionEntity => new QuestionDto
                {
                    Id = questionEntity.Id,
                    Text = questionEntity.Text,
                    Type = questionEntity.Type,
                    AnswerOptions = GetAnswerOptionDtos(questionEntity)

                });
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
