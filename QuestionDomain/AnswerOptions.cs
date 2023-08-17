using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace QuestionDomain
{
    public class AnswerOption
    {
        private bool _isAnswered;
        public int Id { get; set; }

        [MaxLength(100, ErrorMessage = "Anwser should not exceed 200 characters")]
        public string Title { get; set; }
        public Question Question { get; set; }
        public int QuestionId { get; set; }
        public bool IsAnswer
        {
            get => _isAnswered;

            set
            {
                _isAnswered = value;
                if (Question.Type == QuestionType.Text)
                    _isAnswered = true;

            }
        }
    }
}
