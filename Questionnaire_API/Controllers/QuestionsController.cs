using Microsoft.AspNetCore.Mvc;
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
                var questionEntity = await _questionRepository.GetQuestionsAsync();
                var questionsDtos = questionEntity.Select(questionEntity => new QuestionDto
                {
                    Id = questionEntity.Id,
                    Text = questionEntity.Text,
                    Type = questionEntity.Type,

                });
                return Ok(questionsDtos);

            }
            return Ok(Enumerable.Empty<QuestionDto>());
        }

    }
}
