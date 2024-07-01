using connect;
using mcq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Npgsql;
using util;
using Newtonsoft.Json;

namespace quizz.Pages
{
    public class IndexModel : PageModel
    {
        public Questionnaire Questionnaire { get; set; }
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            PSQLCon connect = new PSQLCon();

            using (var connection = new NpgsqlConnection(connect.ConnectionString))
            {
                Questionnaire = new Questionnaire(DAO.getListQuestion(connection));

                for (int i = 0; i < Questionnaire.ListQuestion.Count; i++)
                {
                    Questionnaire.ListQuestion[i]
                        .AddListAnswers(
                            DAO.getListAnswerById(Questionnaire.ListQuestion[i].Id, connection));
                }
            }

            // Store the questionnaire in TempData
            TempData["Questionnaire"] = JsonConvert.SerializeObject(Questionnaire);
        }

        public IActionResult OnPost()
        {
            // Retrieve the questionnaire from TempData
            if (TempData["Questionnaire"] != null)
            {
                Questionnaire = JsonConvert.DeserializeObject<Questionnaire>((string)TempData["Questionnaire"]);
            }

            List<string> userAnswers = new List<string>();

            for (int i = 0; i < Questionnaire.ListQuestion.Count; i++)
            {
                var answer = Request.Form[$"q_{Questionnaire.ListQuestion[i].Id}"];
                userAnswers.Add(answer);
            }

            TempData["Answers"] = string.Join(",", userAnswers);

            return RedirectToPage("/Results");
        }
    }
}
