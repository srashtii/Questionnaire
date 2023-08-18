using Microsoft.EntityFrameworkCore;
using QuestionDomain;

namespace QuestionData
{
    public class QuesContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<AnswerOption> AnswerOptions { get; set; }
        public QuesContext(DbContextOptions<QuesContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Question>().HasData(
                new Question
                {
                    Id = 1,
                    Text = "Which language do you prefer ?",
                    Type = QuestionType.Checkbox
                },
                new Question
                {
                    Id = 2,
                    Text = "Which programming language do you prefer ?",
                    Type = QuestionType.Checkbox
                },
                new Question
                {
                    Id = 3,
                    Text = "Which architecture do you work on ?",
                    Type = QuestionType.Selectbox

                },
                new Question
                {
                    Id = 4,
                    Text = "What do you mean by clean code ?",
                    Type = QuestionType.Text

                }
                );
            
            modelBuilder.Entity<AnswerOption>()
                
                .HasData(
                new AnswerOption
                {
                    Id = 1,
                    Title = "English",
                    IsAnswer = true,
                    QuestionId = 1,
                    //Question = new Question
                    //{
                    //    Id = 5,
                    //    Text = "Which language do you prefer ?",
                    //    Type = QuestionType.Checkbox
                    //}
                },
                new AnswerOption { Id = 2, Title = "French", IsAnswer = false, QuestionId = 1 },
                new AnswerOption { Id = 3, Title = "Python", IsAnswer = false, QuestionId = 2 },
                new AnswerOption { Id = 4, Title = "C#", IsAnswer = true, QuestionId = 2 },
                new AnswerOption { Id = 5, Title = "MVC", IsAnswer = false, QuestionId = 3 },
                new AnswerOption { Id = 6, Title = "Azure functions", IsAnswer = true, QuestionId = 3 },
                new AnswerOption { Id = 7, Title = "DDD Web API", IsAnswer = true, QuestionId = 3 },
                new AnswerOption { Id = 8, Title = "Code that follows best practices", IsAnswer = true, QuestionId = 4 }

            )
            ;
        }

    }
}