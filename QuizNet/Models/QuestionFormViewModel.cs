using QuizNet.DataAccess.Models;
using QuizNet.Logic.DTOs;
using System.Linq;

namespace QuizNet.Models
{
    public class QuestionFormViewModel
    {
        public QuestionFormViewModel()
        {
            this.Question = new QuestionDto();
        }

        public QuestionFormViewModel(Question question)
        {
            Question = new QuestionDto()
            {
                Id = question.Id,
                CorrectAnswerIndex = question.CorrectAnswerIndex,
                Text = question.Text,
                Answers = question.Answers.Select(y => new AnswerDto()
                {
                    Id = y.Id,
                    Text = y.Text,
                    QuestionId = y.QuestionId
                }).ToArray()
            };
        }

        public Question GetQuestion() {
            return new Question()
            {
                Answers = Question.Answers
                        .Select(a => new Answer() { Id = a.Id, Text = a.Text, QuestionId = a.QuestionId }).ToArray(),
                Text = Question.Text,
                Id = Question.Id,
                CorrectAnswerIndex = Question.CorrectAnswerIndex
            };
        }

        public QuestionDto Question { get; set; }
        public string ActionType {
            get {
                if (Question.Id == 0)
                    return "Create";
                else
                    return "Edit";
            }
        }
    }
}