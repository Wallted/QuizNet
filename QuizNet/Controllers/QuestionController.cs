﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuizNet.DataAccess;
using QuizNet.DataAccess.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuizNet.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionController(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }
        public IActionResult GetAll()
        {
            var questions = _questionRepository.GetAll();
            return View(questions);
        }
        public IActionResult Get(int id)
        {
            var question = _questionRepository.GetById(id);
            return View(question);
        }
        public IActionResult Delete(int id)
        {
            _questionRepository.Delete(id);
            return RedirectToAction("GetAll");
        }

        public IActionResult Create()
        {
            var newQuestion = new Question();
            return View(newQuestion);
        }

        [HttpPost]
        public IActionResult Create(Question question)
        {
            _questionRepository.Add(question);
            
            return RedirectToAction("Get", new { Id = question.Id});
        }

        public IActionResult Update(int id)
        {
            var questionToUpdate = _questionRepository.GetById(id);

            return View(questionToUpdate);
        }

        [HttpPost]
        public IActionResult Update(Question questionToUpdate)
        {
            _questionRepository.Update(questionToUpdate);

            return RedirectToAction("Get", new { Id = questionToUpdate.Id });
        }
    }
}
