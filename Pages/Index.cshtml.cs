using connect;
using mcq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Npgsql;
using util;

namespace quizz.Pages;

public class IndexModel : PageModel
{
    public Questionnaire questionnaire = new Questionnaire();
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
            questionnaire = new Questionnaire(DAO.getListQuestion(connection));

            for (int i = 0; i < questionnaire.ListQuestion.Count; i++)
            {
                questionnaire.ListQuestion[i]
                    .AddListAnswers(
                        DAO.getListAnswerById(questionnaire.ListQuestion[i].Id,connection));
            }
        }
    }
}
