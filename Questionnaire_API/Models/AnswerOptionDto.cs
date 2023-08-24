using QuestionDomain;
using System.ComponentModel.DataAnnotations;

namespace Questionnaire_API.Models
{
    public class AnswerOptionDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int QuestionId { get; set; }
        public bool IsAnswer { get; set; }

    }
}