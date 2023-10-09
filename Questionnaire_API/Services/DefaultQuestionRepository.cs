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

        public async Task<(IEnumerable<Question>, PaginationMetadata)> GetQuestionsAsync(int pageSize, int pageNumber)
        {
            var res = await _context.Questions
                .Include(x => x.AnswerOptions)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();
            var totalItemCount = res.Count;
            var paginationMetadata = new PaginationMetadata(
                totalItemCount, pageSize, pageNumber);
            return (res, paginationMetadata);
        }

        public Task UpdateQuestionAsync(Question question)
        {
            throw new NotImplementedException();
        }
    }
}
