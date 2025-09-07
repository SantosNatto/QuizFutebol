using Microsoft.AspNetCore.Mvc;
using QuizFutebol.Data;
using QuizFutebol.Models;

namespace QuizFutebol.Controllers
{
    public class QuizController : Controller
    {
        private readonly IQuestionRepository _repo;

        // chaves da Session
        private const string CurrentIndexKey = "CurrentIndex";
        private const string ScoreKey = "Score";

        public QuizController(IQuestionRepository repo)
        {
            _repo = repo;
        }

        // GET: /Quiz
        public IActionResult Index()
        {
            return View();
        }

        // POST: /Quiz/Start
        [HttpPost]
        public IActionResult Start()
        {
            HttpContext.Session.SetInt32(CurrentIndexKey, 0);
            HttpContext.Session.SetInt32(ScoreKey, 0);
            TempData.Remove("Feedback");
            return RedirectToAction("Question");
        }

        // GET: /Quiz/Question
        public IActionResult Question()
        {
            var index = HttpContext.Session.GetInt32(CurrentIndexKey) ?? 0;
            var questions = _repo.GetAll();

            if (index >= questions.Count)
                return RedirectToAction("Result");

            var question = questions[index];
            ViewBag.TotalQuestions = questions.Count;
            return View(question);
        }


        // POST: /Quiz/Answer
        [HttpPost]
        public IActionResult Answer(int selectedOption)
        {
            var index = HttpContext.Session.GetInt32(CurrentIndexKey) ?? 0;
            var score = HttpContext.Session.GetInt32(ScoreKey) ?? 0;

            var questions = _repo.GetAll();

            if (index < questions.Count)
            {
                var question = questions[index];
                if (selectedOption == question.CorrectIndex)
                {
                    score++;
                    TempData["Feedback"] = "✅ Acertou!";
                }
                else
                {
                    TempData["Feedback"] = $"❌ Errou! A correta era: {question.Options[question.CorrectIndex]}";
                }
            }

            // atualiza sessão
            HttpContext.Session.SetInt32(ScoreKey, score);
            HttpContext.Session.SetInt32(CurrentIndexKey, index + 1);

            return RedirectToAction("Question");
        }

        // GET: /Quiz/Result
        public IActionResult Result()
        {
            var score = HttpContext.Session.GetInt32(ScoreKey) ?? 0;
            var total = _repo.GetAll().Count;

            ViewBag.Score = score;
            ViewBag.Total = total;

            return View();
        }
    }
}
