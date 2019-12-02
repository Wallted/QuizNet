using System.ComponentModel.DataAnnotations;

namespace QuizNet.Logic.DTOs
{
    public class QuestionDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please specify question text")]
        public string Text { get; set; }
        [StringLength(5)]
        public AnswerDto[] Answers { get; set; }
        public int CorrectAnswerIndex { get; set; }
    }
}