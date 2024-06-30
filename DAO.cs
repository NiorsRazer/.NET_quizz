using System.Collections.Generic;
using mcq;
using Npgsql;

namespace util
{
    public class DAO
    {
        public static List<Question> getListQuestion(NpgsqlConnection connection)
        {
            List<Question> listQuestions = new List<Question>();

            try
            {
                connection.Open();

                string selectCommand = "SELECT * FROM question";

                using (var command = new NpgsqlCommand(selectCommand, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int questionId = reader.GetInt32(0);
                            string questionText = reader.GetString(1);

                            Question question = new Question()
                                .AddId(questionId)
                                .AddText(questionText);

                            listQuestions.Add(question);
                        }
                    }
                }
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return listQuestions;
        }

        public static List<Answer> getListAnswerById(int id, NpgsqlConnection connection)
        {
            List<Answer> listAnswers = new List<Answer>();

            try
            {
                connection.Open();

                string selectCommand = "SELECT * FROM v_answer WHERE id_question = @id";

                using (var command = new NpgsqlCommand(selectCommand, connection))
                {
                    command.Parameters.AddWithValue("id", id);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int answerId = reader.GetInt32(0);
                            string answerText = reader.GetString(1);
                            string answerType = reader.GetString(4);

                            Answer answer = new Answer()
                                .addId(answerId)
                                .addText(answerText)
                                .addType(answerType);

                            listAnswers.Add(answer);
                        }
                    }
                }
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return listAnswers;
        }
    }
}
