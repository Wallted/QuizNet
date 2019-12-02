using AutoMapper;
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
        private readonly IMapper _mapper;

        public QuizService(IQuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public List<QuestionDto> GenerateQuiz()
        {
            var questions = _questionRepository.GetAll().ToList();
            var randomQuestions = questions.OrderBy(x => Guid.NewGuid()).Take(2).ToList();
            
            var randomQuestionsDto = _mapper.Map<List<QuestionDto>>(randomQuestions);
            return randomQuestionsDto;
        }
    }
}