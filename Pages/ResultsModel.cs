using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace quizz.Pages
{
    public class ResultsModel : PageModel
    {
        public string Answer { get; set; }

        public int AdultScore { get; set; }
        public int ChildScore { get; set; }
        public int ParentScore { get; set; }
        private readonly ILogger<ResultsModel> _logger;

        public ResultsModel(ILogger<ResultsModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            if (TempData["Answers"] != null)
            {
                string concatAnswer = TempData["Answers"].ToString();

                Answer = concatAnswer;
                char delimiter = ',';

                string[] listAnswer = concatAnswer.Split(delimiter);

                AdultScore=0;
                ChildScore=0;
                ParentScore=0;
                for (int i = 0; i < listAnswer.Length; i++)
                {
                    if (listAnswer[i] == "Adult")
                    {
                        AdultScore=AdultScore+1;
                    }
                    else if (listAnswer[i] == "Child")
                    {
                        ChildScore=ChildScore+1;
                    }
                    else if (listAnswer[i] == "Parent")
                    {
                        ParentScore=ParentScore+1;
                    }
                }
            }
        }
    }
}
