using Microsoft.EntityFrameworkCore;
using QuestionDomain;

namespace QuestionData
{
    public class QuesContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<AnswerOption> AnswerOptions { get; set; }
        public QuesContext(DbContextOptions<QuesContext> options) : base(options) { }

    }
}