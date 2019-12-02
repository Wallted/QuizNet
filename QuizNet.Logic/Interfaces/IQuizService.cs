using QuizNet.Logic.DTOs;
using System.Collections.Generic;

namespace QuizNet.Logic.Interfaces
{
    public interface IQuizService
    {
        List<QuestionDto> GenerateQuiz();
    }
}