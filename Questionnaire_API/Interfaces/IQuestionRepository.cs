using QuestionDomain;
using Questionnaire_API.Services;

namespace Questionnaire_API.Interfaces
{
    public interface IQuestionRepository
    {
        public Task<(IEnumerable<Question>, PaginationMetadata)> GetQuestionsAsync(int pageSize, int pageNumber);
        public Task<Question> GetQuestionByIdAsync(int id);
        public Task AddQuestionAsync(Question question);
        public Task UpdateQuestionAsync(Question question);
    }
}
