﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizNet.DataAccess.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Answer[] Answers { get; set; }
        public int CorrectAnswerIndex { get; set; }

    }
}
