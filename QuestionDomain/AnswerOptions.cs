using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionDomain
{
    public class AnswerOption
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public Question Question { get; set; }
        public int QuestionId { get; set; }
    }
}
