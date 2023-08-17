using Microsoft.EntityFrameworkCore;
using QuestionData;
using QuestionDomain;
using Questionnaire_API.Interfaces;

namespace Questionnaire_API.Services
{
    public class DefaultQuestionRepository : IQuestionRepository
    {
        private readonly QuesContext _context;
        public DefaultQuestionRepository(QuesContext quesContext)
        {
            _context = quesContext ?? throw new ArgumentNullException(nameof(quesContext));
        }
        public Task AddQuestionAsync(Question question)
        {
            throw new NotImplementedException();
        }

        public Task<Question> GetQuestionByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Question>> GetQuestionsAsync()
        {
            return await _context.Questions.ToListAsync();
        }

        public Task UpdateQuestionAsync(Question question)
        {
            throw new NotImplementedException();
        }
    }
}
    