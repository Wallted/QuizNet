using AutoMapper;
using QuizNet.DataAccess.Models;
using QuizNet.Logic.DTOs;

namespace QuizNet.Logic.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Answer, AnswerDto>();
            CreateMap<Question, QuestionDto>();

            CreateMap<AnswerDto, Answer>();
            CreateMap<QuestionDto, Question>();
        }
    }
}