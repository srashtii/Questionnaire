using QuestionDomain;

namespace Questionnaire_API.Interfaces
{
    public interface IQuestionRepository
    {
        public Task<IEnumerable<Question>> GetQuestionsAsync();
        public Task<Question> GetQuestionByIdAsync(int id);
        public Task AddQuestionAsync(Question question);
        public Task UpdateQuestionAsync(Question question);
    }
}
