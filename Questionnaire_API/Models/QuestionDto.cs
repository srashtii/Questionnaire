using QuestionDomain;

namespace Questionnaire_API.Models
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public QuestionType Type { get; set; }
        public List<AnswerOptionDto>? AnswerOptions { get; set; } = new List<AnswerOptionDto>();
    }
}
