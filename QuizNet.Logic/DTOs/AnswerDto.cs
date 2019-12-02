using System.ComponentModel.DataAnnotations;

namespace QuizNet.Logic.DTOs
{
    public class AnswerDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please specify answer text")]
        public string Text { get; set; }
        public int QuestionId { get; set; }
    }
}