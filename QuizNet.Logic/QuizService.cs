using QuizNet.DataAccess;
using QuizNet.Logic.DTOs;
using QuizNet.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuizNet.Logic
{
    public class QuizService : IQuizService
    {
        private readonly IQuestionRepository _questionRepository;
        public QuizService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }
        public List<QuestionDto> GenerateQuiz()
        {
            var questions = _questionRepository.GetAll().ToList();
            var randomQuestions = questions.OrderBy(x => Guid.NewGuid()).Take(2).ToList();

            List<QuestionDto> randomQuestionsDto = randomQuestions.Select(x => new QuestionDto()
            {
                Id = x.Id,
                CorrectAnswerIndex = x.CorrectAnswerIndex,
                Text = x.Text,
                Answers = x.Answers.Select(y => new AnswerDto()
                {
                    Id = y.Id,
                    Text = y.Text,
                    QuestionId = y.QuestionId
                }).ToArray()
            }).ToList();

            return randomQuestionsDto;
        }
    }
}