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
                    Type = QuestionType.Checkbox,
                    AnswerOptions = new List<AnswerOption> {
                        new AnswerOption { Id=1, Title= "English" ,IsAnswer = true },
                    new AnswerOption { Id=1, Title= "French", IsAnswer= false }}
                },
                new Question
                {
                    Id = 1,
                    Text = "Which programming language do you prefer ?",
                    Type = QuestionType.Checkbox,
                    AnswerOptions = new List<AnswerOption> {
                        new AnswerOption { Id=1, Title= "Python" ,IsAnswer = false },
                    new AnswerOption { Id=1, Title= "C#", IsAnswer= true }}
                },
                new Question
                {
                    Id = 1,
                    Text = "Which architecture do you work on ?",
                    Type = QuestionType.Selectbox,
                    AnswerOptions = new List<AnswerOption> {
                        new AnswerOption { Id=1, Title= "MVC" ,IsAnswer = false },
                    new AnswerOption { Id=1, Title= "Azure functions", IsAnswer= true },
                    new AnswerOption { Id=1, Title= "DDD Web API", IsAnswer= true } }

                },
                new Question
                {
                    Id = 1,
                    Text = "What do you mean by clean code ?",
                    Type = QuestionType.Text,
                    AnswerOptions = new List<AnswerOption> {
                        new AnswerOption { Id = 1, Title = "Code that follows best practices", IsAnswer = true }
                    },

                }
                ); ;
        }

    }
}